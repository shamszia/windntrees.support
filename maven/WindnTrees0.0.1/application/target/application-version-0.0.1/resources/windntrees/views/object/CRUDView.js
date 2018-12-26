/*  Copyright [2018] [Invincible Technologies]
 *  
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *  http://www.apache.org/licenses/LICENSE-2.0
 *    
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

///CRUDView provides observer independent data handling and communication capability 
///using get, post, find, create, update and delete calls to a hosted web service 
///and gets typed content objects. CRUDView extends functionality from SearchView.
///CRUDView is data or information extraction, edition, deletion, saving and 
///presentation CRUD component, this means its useful when information or data is 
///required to be created, edited, saved, searched and presented in textual, form 
///or grid (tabular) format.
///CRUDView extends from SearchView and for information about SearchView visit here.
/// </summary>
function CRUDView(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options});
    }
    
    //extend from search view
    var extOptions = Object.create(options);
    extOptions.instance = instance;
    extOptions.events = false;
    instance = SearchView(extOptions);
    
    /// <summary>Reference to master view.</summary>
    instance.MasterView = null;
    /// <summary>Reference to detail view.</summary>
    instance.DetailView = null;
    
    /// <summary>Gets the type of view.</summary>
    instance.getType = function () {
        return 'CRUDView';
    };

    /// <summary>Observer interface reference to the actual observer.</summary>
    instance.getMasterObserverInterface = function () {
        return instance.MasterView.getObserverInterface();
    };

    /// <summary>Gets view's actual underlying observer.</summary>
    instance.getMasterObserverObject = function () {
        var observerInterface = instance.getMasterObserverInterface();
        try {
            while (1) {
                observerInterface = observerInterface.getObserver();
            }
        } catch (e) {
        }
        return observerInterface;
    };

    /// <summary>Observer interface reference to the actual observer.</summary>
    instance.getDetailObserverInterface = function () {
        return instance.DetailView.getObserverInterface();
    };

    /// <summary>Gets view's actual underlying observer.</summary>
    instance.getDetailObserverObject = function () {
        var observerInterface = instance.getDetailObserverInterface();
        try {
            while (1) {
                observerInterface = observerInterface.getObserver();
            }
        } catch (e) {
        }
        return observerInterface;
    };

    /// <summary>Sets master view.</summary>
    instance.setMasterView = function (view) {
        instance.MasterView = view;
    };

    /// <summary>Gets master view.</summary>
    instance.getMasterView = function () {
        return instance.MasterView;
    };

    /// <summary>Sets related detail view.</summary>
    instance.setDetailView = function (view) {
        if (view !== null && view !== undefined) {

            var relatedView = CRUDRelatedView({'view': view});
            instance.DetailView = relatedView;
            instance.DetailView.setMasterView(this);

            /**
             * Extends relating master view's entity object with addDetailItem 
             * function at runtime.
             * 
             * options.name - items or subitems array name within an entity 
             * object graph
             * 
             * options.data - new item to insert
             * options.order - 'first' or 'last'
             * 
             * @param {type} options 
             */
            instance.getObserverInterface().getContentTypeObjectPrototype().addDetailItem = function (options) {
                var instance = this;
                var subitems = instance.get(options.name);

                if (subitems !== null && subitems !== undefined) {
                    if (Array.isArray(subitems)) {
                        if (options.order !== null && options.order !== undefined) {
                            if (options.order === 'first') {
                                subitems.splice(0, 0, JSON.parse(options.data));
                            } else {
                                subitems.push(JSON.parse(options.data));
                            }
                        } else {
                            subitems.splice(0, 0, JSON.parse(options.data));
                        }
                        return;
                    }
                }
            };

            /**
             * Extends relating master view's entity object with editOrRemoveDetailItem 
             * function at runtime.
             * 
             * options.name - items or subitems array name within an entity 
             * object graph.
             * 
             * options.data - entity object to edit or remove
             * options.action - 'edit' or 'remove'
             * 
             * @param {type} options 
             * 
             */
            instance.getObserverInterface().getContentTypeObjectPrototype().editOrRemoveDetailItem = function (options) {
                var instance = this;
                var subitems = instance.get(options.name);

                if (subitems !== null && subitems !== undefined) {
                    if (Array.isArray(subitems)) {
                        for (var i = 0; i < subitems.length; i++) {
                            var dataObject = JSON.parse(options.data);
                            var item = new options.dataPrototype.constructor(subitems[i]);
                            var dataItem = new options.dataPrototype.constructor(dataObject);
                            dataItem._datakey = dataObject._datakey;

                            if (typeof (item._datakey) === "string") {
                                if (typeof (dataItem._datakey) === "string") {
                                    if (item._datakey === dataItem._datakey) {
                                        if (options.action !== null && options.action !== undefined) {
                                            if (options.action === 'edit') {
                                                subitems.splice(i, 1, dataObject);
                                            } else if (options.action === 'remove') {
                                                subitems.splice(i, 1);
                                            } else {
                                                subitems.splice(i, 1, dataObject);
                                            }
                                        } else {
                                            subitems.splice(i, 1, dataObject);
                                        }
                                        return true;
                                    }
                                }
                            } else if (typeof (item._datakey) === "object") {
                                if (typeof (options.data._datakey) === "object") {
                                    var fieldNames = Object.getOwnPropertyNames(item);
                                    var matchFound = false;

                                    for (var j = 0; j < fieldNames.length; j++) {
                                        if (item[fieldNames[j]] === dataItem[fieldNames[j]]) {
                                            matchFound = true;
                                        } else {
                                            matchFound = false;
                                            break;
                                        }
                                    }

                                    if (matchFound) {
                                        if (options.action !== null && options.action !== undefined) {
                                            if (options.action === 'edit') {
                                                subitems.splice(i, 1, dataObject);
                                            } else if (options.action === 'remove') {
                                                subitems.splice(i, 1);
                                            } else {
                                                subitems.splice(i, 1, dataObject);
                                            }
                                        } else {
                                            subitems.splice(i, 1, dataObject);
                                        }
                                        return true;
                                    }
                                }
                            }
                        }
                        return false;
                    }
                }
            };

            /**
             * Loads DetailView's records based on the MasterView's record selection.
             * 
             * data.record - entity record to be set as master key record
             * data.page - page number
             * 
             * @param {type} data
             * @returns {undefined}
             */
            instance.selectDetail = function (data) {
                if (data.record === null || data.record === undefined) {
                    instance.find(data.page);
                } else {

                    if (data.navigation === null || data.navigation === undefined) {
                        instance.getObserverInterface().setMasterKeyRecord(data.record);
                    }

                    instance.getObserverInterface().displayGridProcessingActivity();

                    instance.getDetailObserverInterface().setCurrentList(data.page);
                    instance.getDetailObserverInterface().clearListRecordsView();
                    instance.getDetailObserverInterface().displayGridProcessingActivity();

                    instance.getDetailView().getCRUDProcessor().select({'uri': instance.getDetailView().URI,
                        'key': instance.getObserverInterface().getMasterKeyRecord().getKey(),
                        'source': data.source === undefined ? null : data.source,
                        'keyword': instance.getDetailObserverInterface().getKeyword(),
                        'size': instance.getDetailObserverInterface().getListSize(),
                        'page': data.page,
                        'callback': function (result) {

                            instance.getDetailObserverInterface().displayGridClearActivity();
                            instance.getObserverInterface().displayGridClearActivity();

                            if (instance.getDetailView().isResponseError()) {
                                instance.getDetailObserverInterface().displayGridFailureActivity();
                            } else {
                                if (instance.getDetailView().isInputError()) {
                                    instance.getDetailObserverInterface().setErrors(instance.getDetailView().getErrors());
                                } else {
                                    instance.getDetailObserverInterface().displayGridSuccessActivity();
                                    instance.getDetailObserverInterface().fillListRecordsView({
                                        page: data.page,
                                        responseData: instance.getDetailView().getCRUDProcessor().responseData(),
                                        records: instance.getDetailView().getCRUDProcessor().Records
                                    });
                                }
                            }
                        }
                    });
                }
            };

            if (instance.getObserverInterface().selectDetail === undefined) {
                /**
                 * Loads detail records based on MasterView's selected record.
                 * 
                 * data.record - selection entity record
                 * data.page - page number
                 * 
                 * @param {type} data
                 * 
                 * @returns {undefined}
                 */
                instance.getObserverInterface().selectDetail = function (data) {
                    instance.getObserverObject().selectDetail(data);
                };
            }

            if (instance.getObserverObject().selectDetail === undefined) {
                /**
                 * Loads detail records based on MasterView's selected record.
                 * 
                 * data.record - selection entity record
                 * data.page - page number
                 * 
                 * @param {type} data
                 * 
                 * @returns {undefined}
                 */
                instance.getObserverObject().selectDetail = function (data) {
                    if (instance.getObserverInterface().getMasterKeyRecord() !== null) {
                        if (instance.getObserverInterface().getMasterKeyRecord().getKey() !== data.record.getKey()) {
                            instance.selectDetail(data);
                        }
                    } else {
                        instance.selectDetail(data);
                    }
                };
            }

            /**
             * Observer find function definition.
             * 
             * @param {type} page
             * @returns {undefined}
             */
            instance.getDetailObserverInterface().findMaster = function (page) {
                instance.find(page);
            };

            /**
             * Observer find function definition.
             * 
             * @param {type} page
             * @returns {undefined}
             */
            instance.getDetailObserverObject().findMaster = function (page) {
                instance.find(page);
            };
        }
    };

    /// <summary>Gets related detail view.</summary>
    instance.getDetailView = function () {
        return instance.DetailView;
    };

    /// <summary>Sets master key record.</summary>
    instance.setMasterKeyRecord = function (record) {
        return instance.getObserverObject().setMasterKeyRecord(record);
    };

    /// <summary>Gets master key record.</summary>
    instance.getMasterKeyRecord = function () {
        return instance.getObserverObject().getMasterKeyRecord();
    };

    /// <summary>Gets master key record.</summary>
    instance.getContextualMasterKeyRecord = function () {
        return instance.getObserverObject().getMasterKeyRecord();
    };

    //CRUD Functions
    ////////////////////////////////////////////////////////////////////////////
    //Following includes entity related find, create, update and delete 
    //funcionality with observer updates.

    /// <summary>Format the content object time fields.</summary>
    instance.formatContent = function (options) {

        //get form object
        var content = (options.content !== null && options.content !== undefined) ? options.content : instance.getObserverInterface().getFormObject();

        //if update have time fields then format them in proper order.
        if (options.TimeFields !== null && options.TimeFields !== undefined) {

            if (Array.isArray(options.TimeFields)) {

                for (var i = 0; i < options.TimeFields.length; i++) {

                    //for each time field format time value. If the time field is a function then evalute and format otherwise just format it.

                    if (typeof (content[options.TimeFields[i]]) === "function") {

                        if (content[options.TimeFields[i]]() !== null && content[options.TimeFields[i]]() !== undefined) {

                            content[options.TimeFields[i]](moment(typeof (content[options.TimeFields[i]]) === "function" ? content[options.TimeFields[i]]() : content[options.TimeFields[i]]).format('YYYY-MM-DD HH:mm:ss'));
                        }
                    }
                    else {

                        if (content[options.TimeFields[i]] !== null && content[options.TimeFields[i]] !== undefined) {

                            content[options.TimeFields[i]] = moment(typeof (content[options.TimeFields[i]]) === "function" ? content[options.TimeFields[i]]() : content[options.TimeFields[i]]).format('YYYY-MM-DD HH:mm:ss');
                        }
                    }
                }

            } else {

                if (content[options.TimeFields] !== null && content[options.TimeFields] !== undefined) {

                    content[options.TimeFields] = moment(typeof (content[options.TimeFields]) === "function" ? content[options.TimeFields]() : content[options.TimeFields]).format('YYYY-MM-DD HH:mm:ss');
                }
            }

            content = instance.getObserverInterface().getStringifiedObject(content);

        } else {

            content = (options.content === null || options.content === undefined) ? (instance.getObserverInterface().getFormStringifiedObject()) : instance.getObserverInterface().getStringifiedObject(options.content);
        }

        if (options.target === 'CreateContent' || options.target === 'UpdateContent') {

            var uploadForm = (options.form !== null && options.form !== undefined) ? options.form : '__uploadform';

            if (document.forms[uploadForm] !== null && document.forms[uploadForm] !== undefined) {

                if (options.TimeFields !== null && options.TimeFields !== undefined) {

                    if (Array.isArray(options.TimeFields)) {

                        for (var i = 0; i < options.TimeFields.length; i++) {

                            if (document.forms[uploadForm][options.TimeFields[i]] !== null && document.forms[uploadForm][options.TimeFields[i]] !== undefined) {

                                //for each time input value format time value.
                                if (document.forms[uploadForm][options.TimeFields[i]].value !== null && document.forms[uploadForm][options.TimeFields[i]].value !== undefined) {

                                    document.forms[uploadForm][options.TimeFields[i]].value = moment((document.forms[uploadForm][options.TimeFields[i]]).value).format('YYYY-MM-DD HH:mm:ss');
                                }
                            }
                        }
                    } else {

                        document.forms[uploadForm][options.TimeFields].value = moment((document.forms[uploadForm][options.TimeFields]).value).format('YYYY-MM-DD HH:mm:ss');
                    }
                }
            }
        }

        return content;
    };

    /// <summary>Evaluates field against form content object.</summary>
    instance.evaluateOption = function (field) {

        var formObject = instance.getObserverInterface().getFormObject();

        if (formObject !== null && formObject !== undefined) {

            if (formObject[field] !== null && formObject[field] !== undefined) {

                field = ((typeof (formObject[field]) === "function") ? formObject[field]() : formObject[field]);
            }
        }

        return field;
    };

    /// <summary>Creates new record based on form view object.</summary>
    instance.create = function (options) {
        options = (options === null || options === undefined) ? {} : options;
        options.action = 'create';

        options.content = instance.formatContent(options);

        options.validate = (options.validate === null || options.validate === undefined) ? true : options.validate;
        options.placement = (options.placement === null || options.placement === undefined) ? 'first' : options.placement;
        instance.createOrUpdateOrDelete(options);
    };

    /// <summary>Updates new record based on form view object.</summary>
    instance.update = function (options) {
        options = (options === null || options === undefined) ? {} : options;
        options.action = 'update';

        options.content = instance.formatContent(options);

        instance.createOrUpdateOrDelete(options);
    };

    /// <summary>Deletes exisiting record based on provided record.</summary>
    instance.delete = function (options) {
        options = (options === null || options === undefined) ? {} : options;
        options.action = 'delete';
        
        if (options.content !== null && options.content !== undefined) {
            
            try {
                if (options.content.getType() === 'DetailKNObserver' ||
                        options.content.getType() === 'DetailObserver') {

                    options.content = options.content.getRecord();
                }
            } catch (e) {
            }
        }

        options.content = instance.formatContent(options);

        //options.content = (options.content === null || options.content === undefined) ? (instance.getObserverInterface().getFormStringifiedObject()) : instance.getObserverInterface().getStringifiedObject(options.content);
        instance.createOrUpdateOrDelete(options);
    };

    /**
     * CRUD - Observer Connectivity
     * *************************************************************************
     * Following connects observer to CRUD functionality when participating
     * in a CRUD view.
     */

    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {

        /// <summary>Observer create function definition.</summary>
        instance.getObserverInterface().create = function (options) {
            instance.create(options);
        };

        /// <summary>Observer update function definition.</summary>
        instance.getObserverInterface().update = function (options) {
            instance.update(options);
        };

        /// <summary>Observer delete function definition.</summary>
        instance.getObserverInterface().delete = function (record) {

            if (record.content === null || record.content === undefined) {
                
                instance.delete({
                    'content': record
                });
                
            } else {
                //it is already composed with content and other options.

                instance.delete(record);
            }
        };

        /// <summary>Gets contextual master key record for views resolution.</summary>
        instance.getObserverInterface().getContextualMasterKeyRecord = function () {
            instance.getContextualMasterKeyRecord();
        };
        
        /// <summary>Gets the attached view.</summary>
        instance.getObserverInterface().getDetailView = function () {
            return instance.getDetailView();
        };
        
        /// <summary>Gets the attached view.</summary>
        instance.getObserverInterface().getMasterView = function () {
            return instance.getMasterView();
        };
    }

    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {

        /// <summary>Observer create function definition.</summary>
        instance.getObserverObject().create = function (options) {
            instance.create(options);
        };

        /// <summary>Observer update function definition.</summary>
        instance.getObserverObject().update = function (options) {
            instance.update(options);
        };

        /// <summary>Observer delete function definition.</summary>
        instance.getObserverObject().delete = function (record) {

            if (record.content === null || record.content === undefined) {

                instance.delete({
                    'content': record
                });

            } else {
                //it is already composed with content and other options.

                instance.delete(record);
            }
        };

        /// <summary>Gets contextual master key record for views resolution.</summary>
        instance.getObserverObject().getContextualMasterKeyRecord = function () {
            instance.getContextualMasterKeyRecord();
        };
        
        /// <summary>Gets the attached view.</summary>
        instance.getObserverObject().getDetailView = function () {
            return instance.getDetailView();
        };
        
        /// <summary>Gets the attached view.</summary>
        instance.getObserverObject().getMasterView = function () {
            return instance.getMasterView();
        };
    }

    if (options.events !== null && options.events !== undefined) {
        if (options.events) {
            instance.subscribeEvents();
        }
    } else {
        instance.subscribeEvents();
    }
    
    if (options.contextpath !== null && options.contextpath !== undefined) {
        if (options.contextpath === 'load') {
            instance.loadContextPath();
        }
    }
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
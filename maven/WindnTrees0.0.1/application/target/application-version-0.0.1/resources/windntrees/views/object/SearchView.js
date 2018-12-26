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

/// <summary>
/// SearchView provides observer independent data handling and communication capability 
/// using get, post and find calls to a hosted web service and gets typed content 
/// objects SearchView extends functionality from ObjectView. 
/// SearchView is extract and present only CRUD component, this means its useful 
/// when information or data is required for extraction and presentation in textual 
/// or grid (tabular) format. 
/// SearchView extends from ObjectView and for information about ObjectView visit here.
/// </summary>
function SearchView(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options});
    }
    
    //extend from object view
    var extOptions = Object.create(options);
    extOptions.instance = instance;
    extOptions.events = false;
    instance = ObjectView(extOptions);
    
    /// <summary>Gets the type of view.</summary>
    instance.getType = function () {
        return 'SearchView';
    };
    
    /// <summary>Clears (resets) observer records list and view.</summary>
    instance.clearRecords = function () {

        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

            if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                if (instance.getObserverInterface().getType() === 'ListObserver'
                        || instance.getObserverInterface().getType() === 'ListKNObserver') {

                    instance.getObserverInterface().clearList();
                    instance.getObserverInterface().displayProcessing(false);

                } else {

                    instance.getObserverInterface().clearListRecordsView();
                    instance.getObserverInterface().displayProcessing(false);
                    instance.getObserverInterface().fillListRecordsView({
                        'page': 1,
                        'responseData': null,
                        'records': instance.getObserverInterface().getRecords(),
                        'immediateRecords': true
                    });
                }
            }
        }
    };

    /// <summary>Selects records based on provided key (views object key) and keyword (via observer keyword property) and page number.</summary>
    instance.select = function (options, fill) {

        if (instance.getObjectKey() !== null && instance.getObjectKey() !== undefined) {

            if (instance.getObjectKey().length === 0) {

                instance.setObjectKey(null);
                instance.find(options, fill);

            } else {

                if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                    instance.getObserverInterface().displayProcessingActivity();
                }

                if (typeof (options) === "object") {

                    options.uri = (options.uri !== null && options.uri !== undefined) ? options.uri : instance.URI;
                    options.keyword = (options.keyword !== null && options.keyword !== undefined) ? options.keyword : instance.getObserverInterface().getKeyword();
                    options.fill = fill;
                    instance.getCRUDProcessor().select(options);

                } else {

                    instance.getCRUDProcessor().select({
                        'uri': instance.URI,
                        'key': instance.getObjectKey(),
                        'keyword': instance.getObserverInterface().getKeyword(),
                        'size': instance.getObserverInterface().getListSize(),
                        'page': options,
                        'fill': fill
                    });
                }
            }

        } else {

            instance.find(options, fill);
        }
    };

    /// <summary>Selects records based on provided key (views object key) and keyword (via observer keyword property) and page number.</summary>
    instance.selectList = function (options, fill) {

        if (instance.getObjectKey() !== null && instance.getObjectKey() !== undefined) {

            if (instance.getObjectKey().length === 0) {

                instance.setObjectKey(null);
                instance.list(options, fill);

            } else {

                if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                    instance.getObserverInterface().displayProcessingActivity();
                }

                if (typeof (options) === "object") {

                    options.uri = (options.uri !== null && options.uri !== undefined) ? options.uri : instance.URI;
                    options.keyword = (options.keyword !== null && options.keyword !== undefined) ? options.keyword : instance.getObserverInterface().getKeyword();
                    options.fill = fill;
                    instance.getCRUDProcessor().selectList(options);

                } else {

                    instance.getCRUDProcessor().selectList({
                        'uri': instance.URI,
                        'key': instance.getObjectKey(),
                        'keyword': instance.getObserverInterface().getKeyword(),
                        'fill': fill
                    });
                }
            }

        } else {

            instance.list(options, fill);
        }
    };
    
    /// <summary>Find records based on provided keyword (via observer keyword property) and page number.</summary>
    instance.find = function (options, fill) {

        if (instance.getObjectKey() !== null && instance.getObjectKey() !== undefined) {

            if (instance.getObjectKey().length === 0) {

                instance.setObjectKey(null);
                instance.find(options, fill);

            } else {
                instance.select(options, fill);
            }
        } else {

            if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                instance.getObserverInterface().displayProcessingActivity();
            }

            if (typeof (options) === "object") {

                options.uri = (options.uri !== null && options.uri !== undefined) ? options.uri : instance.URI;
                options.keyword = (options.keyword !== null && options.keyword !== undefined) ? options.keyword : instance.getObserverInterface().getKeyword();
                options.fill = fill;
                instance.getCRUDProcessor().find(options);

            } else {

                instance.getCRUDProcessor().find({
                    'uri': instance.URI,
                    'keyword': instance.getObserverInterface().getKeyword(),
                    'size': instance.getObserverInterface().getListSize(),
                    'page': options,
                    'fill': fill
                });
            }
        }
    };

    /// <summary>Find records based on provided keyword (via observer keyword property) and page number.</summary>
    instance.list = function (options, fill) {

        if (instance.getObjectKey() !== null && instance.getObjectKey() !== undefined) {

            if (instance.getObjectKey().length === 0) {

                instance.setObjectKey(null);
                instance.list(options, fill);

            } else {
                instance.selectList(options, fill);
            }
        } else {

            if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                instance.getObserverInterface().displayProcessingActivity();
            }

            if (typeof (options) === "object") {

                options.uri = (options.uri !== null && options.uri !== undefined) ? options.uri : instance.URI;
                options.keyword = (options.keyword !== null && options.keyword !== undefined) ? options.keyword : instance.getObserverInterface().getKeyword();
                options.fill = fill;

                instance.getCRUDProcessor().list(options);

            } else {

                instance.getCRUDProcessor().list({
                    'uri': instance.URI,
                    'keyword': instance.getObserverInterface().getKeyword(),
                    'fill': fill
                });
            }
        }
    };

    /// <summary>Find records based on provided keyword (via observer keyword property) and page number.</summary>
    instance.findRequest = function (options) {

        var newOptions = Object.create(options);

        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

            instance.getObserverInterface().displayProcessingActivity();
        }

        newOptions.contentType = instance.extendContentMethods(newOptions);
        newOptions.scopeObject = options.scopeObject;

        newOptions.uri = (newOptions.uri !== null && newOptions.uri !== undefined) ? newOptions.uri : instance.newOptions().uri;
        newOptions.keyword = (newOptions.keyword !== null && newOptions.keyword !== undefined) ? newOptions.keyword : ((instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) ? instance.getObserverInterface().getKeyword() : null);
        newOptions.size = (newOptions.size !== null && newOptions.size !== undefined) ? newOptions.size : instance.getObserverInterface().getListSize(); 

        instance.getCRUDProcessor().find(newOptions);
    };
    
    /// <summary>List records based on provided keyword (via observer keyword property) and page number.</summary>
    instance.listRequest = function (options) {

        var newOptions = Object.create(options);

        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

            instance.getObserverInterface().displayProcessingActivity();
        }

        newOptions.contentType = instance.extendContentMethods(newOptions);
        newOptions.scopeObject = options.scopeObject;

        newOptions.uri = (newOptions.uri !== null && newOptions.uri !== undefined) ? newOptions.uri : instance.newOptions().uri; //instance.newOptions() referes to view constructing options. 
        newOptions.keyword = (newOptions.keyword !== null && newOptions.keyword !== undefined) ? newOptions.keyword : ((instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) ? instance.getObserverInterface().getKeyword() : null);

        instance.getCRUDProcessor().list(newOptions);
    };

    /// <summary>Loads view and related lists.</summary>
    instance.load = function (options, fill) {

        instance.LoadFields(options);
        instance.find(1, fill);
    };
    
    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {
        
        /** 
         * Observer clearRecords function definition.
         * 
         * @returns {undefined}
         */
        instance.getObserverInterface().clearRecords = function () {
            instance.clearRecords();
        };

        /** 
         * Observer select function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().select = function (page) {
            instance.select(page);
        };

        /** 
         * Observer selectList function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().selectList = function (page) {
            instance.selectList(page);
        };

        /** 
         * Observer find function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().find = function (page, fill) {
            instance.find(page, fill);
        };

        /** 
         * Observer list function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().list = function (page) {
            instance.list(page);
        };


        /** 
         * Observer findRequest function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().findRequest = function (options) {
            instance.findRequest(options);
        };

        /** 
         * Observer listRequest function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().listRequest = function (options) {
            instance.listRequest(options);
        };

        /** 
         * Observer load function definition.
         * 
         * @param {type} options
         * @returns {undefined}
         */
        instance.getObserverInterface().load = function (options, fill) {
            instance.load(options, fill);
        };
    }
    
    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {
        
        /** 
         * Observer clearRecords function definition.
         * 
         * @returns {undefined}
         */
        instance.getObserverObject().clearRecords = function () {
            instance.clearRecords();
        };
        
        /** 
         * Observer select function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().select = function (page) {
            instance.select(page);
        };

        /** 
         * Observer selectList function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().selectList = function (page) {
            instance.selectList(page);
        };

        /** 
         * Observer find function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().find = function (page, fill) {
            instance.find(page, fill);
        };

        /** 
         * Observer list function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().list = function (page) {
            instance.list(page);
        };


        /** 
         * Observer findRequest function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().findRequest = function (options) {
            instance.findRequest(options);
        };

        /** 
         * Observer listRequest function definition.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().listRequest = function (options) {
            instance.listRequest(options);
        };

        /** 
         * Observer load function definition.
         * 
         * @param {type} options
         * @returns {undefined}
         */
        instance.getObserverObject().load = function (options, fill) {
            instance.load(options, fill);
        };
    }
    
    /// <summary>Error processing and presenting event subscription.</summary>
    instance.presentErrors = function (event, eventData) {
        
        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.data.callback(eventData.result);
        } else {
            
            if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
                
                instance.getObserverInterface().displayClearActivity();
                instance.getObserverInterface().setErrors(instance.getErrors());
            }
        }
    };
    
    /// <summary>Record processing and presenting event subscription.</summary>
    instance.presentRecord = function (event, eventData) {

        eventData.event = "record.before.rendering.view.CRUD.WindnTrees";
        instance.notify(eventData);
        
        if (eventData !== null && eventData !== undefined) {

            if (eventData.code !== null && eventData.code !== undefined) {

                if (eventData.code.length > 0) {
                    instance.setAuthorizationCode(eventData.code);

                    if (eventData.data.codeField !== null && eventData.data.codeField !== undefined) {

                        $('[name=' + eventData.data.codeField + ']').val(eventData.code);
                    }
                    else {

                        $('[name=__RequestVerificationToken]').val(eventData.code);
                    }
                }
            }
        }

        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.observerType = "callback";
            eventData.data.callback(eventData.result);
        } else {
            
            if (eventData.request === 'get' ||
                    eventData.request === 'post') {
                
                if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                    //attach observer type information within event
                    eventData.observerType = instance.getObserverInterface().getType();

                    instance.getObserverInterface().displaySuccessActivity();
                    instance.getObserverInterface().displayFormSuccessActivity();

                    instance.getObserverInterface().setRecord(eventData.result);

                    if (instance.getObserverInterface().getType() === "CRUDObserver" || instance.getObserverInterface().getType() === "CRUDKNObserver") {

                        if (eventData.result !== null && eventData.result !== undefined) {

                            instance.getObserverInterface().setFormObject(eventData.result);
                        }
                        else {
                            
                            instance.getObserverInterface().displayFormNoRecordActivity();
                        }
                    }
                }
                return;
            }
            
            if (eventData.data !== null &&
                    eventData.data !== undefined) {
                
                if (eventData.data.detailEntity !== null &&
                        eventData.data.detailEntity !== undefined) {

                    eventData.entityType = "detailEntity";

                    var detailEntity = eventData.data.detailEntity;
                    detailEntity.setRecord(eventData.result);
                    
                    if (instance.getObserverInterface() !== null &&
                        instance.getObserverInterface() !== undefined) {


                        if (eventData.data.messageType !== null &&
                            eventData.data.messageType !== undefined) {

                            if (eventData.data.messageType === 'brief') {

                                instance.getObserverInterface().displaySaved();

                            } else {

                                instance.getObserverInterface().displaySuccessActivity();
                                instance.getObserverInterface().displayFormSuccessActivity();
                            }

                        } else {

                            instance.getObserverInterface().displaySuccessActivity();
                            instance.getObserverInterface().displayFormSuccessActivity();
                        }

                        

                        //attach observer type information within event
                        eventData.observerType = instance.getObserverInterface().getType();

                        instance.getObserverInterface().updateView({
                        'requestData': eventData.data,
                        'resetForm': eventData.data.resetForm,
                        'refObject': eventData.data.refObject,
                        'refActions': eventData.data.refActions,
                        'refInputs': eventData.data.refInputs,
                        'action': eventData.request,
                        'resultRecord': detailEntity,
                        'placement': (options.placement !== null && options.placement !== undefined) ? options.placement : 'first'
                    });
                    }
                    
                    return;
                }
            }

            if (instance.getObserverInterface() !== null &&
                instance.getObserverInterface() !== undefined) {
                
                if (eventData.data.messageType !== null &&
                    eventData.data.messageType !== undefined) {

                    if (eventData.data.messageType === 'brief') {

                        instance.getObserverInterface().displaySaved();

                    } else {

                        instance.getObserverInterface().displaySuccessActivity();
                        instance.getObserverInterface().displayFormSuccessActivity();
                    }

                } else {

                    instance.getObserverInterface().displaySuccessActivity();
                    instance.getObserverInterface().displayFormSuccessActivity();
                }

                //attach observer type information within event
                eventData.observerType = instance.getObserverInterface().getType();

                var record = eventData.result;

                instance.getObserverInterface().updateView({
                    'requestData': eventData.data,
                    'resetForm': eventData.data.resetForm,
                    'refObject': eventData.data.refObject,
                    'refActions': eventData.data.refActions,
                    'refInputs': eventData.data.refInputs,
                    'action': eventData.request,
                    'resultRecord': record,
                    'placement': (options.placement !== null && options.placement !== undefined) ? options.placement : 'first'
                });
            }
        }

        eventData.event = "record.after.rendering.view.CRUD.WindnTrees";
        instance.notify(eventData);
    };

    /// <summary>Multiple records processing and presenting event subscription.</summary>
    instance.presentRecords = function (event, eventData) {

        eventData.event = "records.before.rendering.view.CRUD.WindnTrees";
        instance.notify(eventData);

        if (eventData !== null && eventData !== undefined) {
            if (eventData.code !== null && eventData.code !== undefined) {

                if (eventData.code.length > 0) {
                    instance.setAuthorizationCode(eventData.code);

                    if (eventData.data.codeField !== null && eventData.data.codeField !== undefined) {

                        $('[name=' + eventData.data.codeField + ']').val(eventData.code);
                    }
                    else {

                        $('[name=__RequestVerificationToken]').val(eventData.code);
                    }
                }
            }
        }

        var listNumber = 1;
        var listSize = 10;

        //update page or list number from event data in a conventional
        //non-query object find call
        if (eventData.data.page !== null && eventData.data.page !== undefined) {

            listNumber = eventData.data.page;
        }
        else if (eventData.data.query !== null && eventData.data.query !== undefined) {

            //otherwise extract page and size values from query object
            if (eventData.data.query.page !== null && eventData.data.query.page !== undefined) {

                listNumber = eventData.data.query.page;
            }

            if (eventData.data.query.size !== null && eventData.data.query.size !== undefined) {

                listSize = eventData.data.query.size;
            }
        }


        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.observerType = "callback";

            eventData.data.callback(eventData.result);
        } else {

            if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {

                //attach observer type information within event
                eventData.observerType = instance.getObserverInterface().getType();

                var records = eventData.result;

                if (instance.getObserverInterface().getType() === "ListObserver" ||
                        instance.getObserverInterface().getType() === "ListKNObserver") {
                    
                    instance.getObserverInterface().fillList({'objects': records});

                } else {


                    if (eventData.data.messageType !== null &&
                        eventData.data.messageType !== undefined) {

                        if (eventData.data.messageType === 'brief') {

                            instance.getObserverInterface().displaySaved();

                        } else {

                            instance.getObserverInterface().displayProcessing(false);
                            instance.getObserverInterface().displaySuccessActivity();
                        }

                    } else {

                        instance.getObserverInterface().displayProcessing(false);
                        instance.getObserverInterface().displaySuccessActivity();
                    }

                    if (eventData.data.fill !== null && eventData.data.fill !== undefined) {

                        if (eventData.data.fill === 'continue') {

                            var currentList = instance.getObserverInterface().getCurrentList();
                            var existingRecords = instance.getObserverInterface().getRecords();
                            var newRecords = eventData.result;

                            if (eventData.data.page <= currentList) {
                                var listSize = instance.getObserverInterface().getListSize();
                                var listCount = instance.getObserverInterface().getRecords().length;

                                var startIndex = listSize * (eventData.data.page - 1);
                                startIndex = startIndex < 0 ? 0 : startIndex;

                                var deleteCount = listCount - startIndex;
                                deleteCount = deleteCount < 0 ? 0 : deleteCount;

                                existingRecords.splice(startIndex, deleteCount);
                            }

                            for (var i = 0; i < newRecords.length; i++) {
                                existingRecords.push(newRecords[i]);
                            }

                            //instance.getObserverInterface().setRecords(existingRecords);

                            instance.getObserverInterface().fillListRecordsView({
                                'page': listNumber,
                                'responseData': instance.getCRUDProcessor().responseData(),
                                'records': existingRecords,
                                'fill': 'continue',
                                'messageType': eventData.data.messageType
                            });

                        } else {

                            instance.getObserverInterface().fillListRecordsView({
                                'page': listNumber,
                                'responseData': instance.getCRUDProcessor().responseData(),
                                'records': records,
                                'messageType': eventData.data.messageType
                            });
                        }

                    } else {

                        instance.getObserverInterface().fillListRecordsView({
                            'page': listNumber,
                            'responseData': instance.getCRUDProcessor().responseData(),
                            'records': records,
                            'messageType': eventData.data.messageType
                        });
                    }
                }
            }
        }

        eventData.event = "records.after.rendering.view.CRUD.WindnTrees";
        instance.notify(eventData);

        $(window).trigger('view-direction-change');
    };
    
    /// <summary>Presents request failure.</summary>
    instance.presentFailRequest = function (event, eventData) {
        
        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.data.callback(eventData.result);
        } else {

            if (instance.getObserverInterface() !== null &&
                instance.getObserverInterface() !== undefined) {

                if (eventData.data.messageType !== null &&
                    eventData.data.messageType !== undefined) {

                    if (eventData.data.messageType === 'brief') {

                        instance.getObserverInterface().displayFailed();

                    } else {

                        instance.getObserverInterface().displayFailureActivity();
                    }

                } else {

                    instance.getObserverInterface().displayFailureActivity();
                }
            }
        }
    };

    /// <summary>Subscribe CRUDProcessor events.</summary>
    instance.subscribeEvents = function (eventsInstance) {
        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;
        
        $(instance.getCRUDProcessor()).on('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
        $(instance.getCRUDProcessor()).on('record.processor.CRUD.WindnTrees', eventsInstance.presentRecord);
        $(instance.getCRUDProcessor()).on('records.processor.CRUD.WindnTrees', eventsInstance.presentRecords);
        $(instance.getCRUDProcessor()).on('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);
    };
    
    /// <summary>Subscribe CRUDProcessor events.</summary>
    instance.unSubscribeEvents = function (eventsInstance) {
        
        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;
        
        $(instance.getCRUDProcessor()).off('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
        $(instance.getCRUDProcessor()).off('record.processor.CRUD.WindnTrees', eventsInstance.presentRecord);
        $(instance.getCRUDProcessor()).off('records.processor.CRUD.WindnTrees', eventsInstance.presentRecords);
        $(instance.getCRUDProcessor()).off('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);
    };
    
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
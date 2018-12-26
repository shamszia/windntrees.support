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
/// CRUDRelatedView extends from a view and form a master-detail relation that extends
/// addition, editing and deletion functionality for detail records (Obsolete).
/// </summary>
function CRUDRelatedView(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options});
    }

    instance = Object.create(options.view);
    
    /// <summary>Saves original reference to entity CRUD view.</summary>
    instance.OriginalView = options.view;

    /// <summary>Gets type of function construct.</summary>
    instance.getType = function () {
        return "CRUDRelatedView";
    };

    /// <summary>Returns original CRUDView.</summary>
    instance.getOriginalView = function () {
        return instance.OriginalView;
    };

    /// <summary>Gets contextual master key record.</summary>
    instance.getContextualMasterKeyRecord = function () {
        if (instance.getMasterKeyRecord() !== null &&
                instance.getMasterKeyRecord() !== undefined) {
            return instance.getMasterKeyRecord();
        } else {
            return instance.getMasterView().getContextualMasterKeyRecord();
        }
    };
    
    //Detail Functions Extensions
    //*************************************************************************
    //Following includes detail entity related find, create, update and delete 
    //funcionality with observer updates.

    /// <summary>Find records based on provided keyword (master key) input through (observer keyword property) and page number.</summary>
    instance.findDetail = function (page) {
        if (instance.getContextualMasterKeyRecord() !== null &&
                instance.getContextualMasterKeyRecord() !== undefined) {
            instance.getMasterView().selectDetail({
                'record': instance.getContextualMasterKeyRecord(),
                'page': page
            });
        }
    };

    /// <summary>Selects detail item by selection record observer.</summary>
    instance.selectDetailRecord = function () {
        instance.getObserverInterface().displayFormProcessing(true);
        
        instance.getCRUDProcessor().get({'uri': instance.getOriginalView().URI,
            'key': instance.getObserverInterface().getSelectedRecord(),
            'callback': function (result) {
                var originalRecordKey = null;
                if (instance.getObserverInterface().getFormObject() !== null &&
                        instance.getObserverInterface().getFormObject() !== undefined) {
                    if (instance.getObserverInterface().getFormObject().getKey() !== null &&
                            instance.getObserverInterface().getFormObject().getKey() !== undefined) {
                        originalRecordKey = instance.getObserverInterface().getFormObject().getKey();
                    }
                }
                //data.content, data.originalKey
                instance.getObserverInterface().setFormObject({'content': result,
                    'originalKey': originalRecordKey
                });
                instance.getObserverInterface().displayFormProcessing(false);
                instance.getObserverInterface().displayFormClearActivity();
                
                $('.modal').trigger('apply-form-locale');
            }});
    };

    /// <summary>Creates new detail item in selected master key record based on detail form view object.</summary>
    instance.createDetail = function (data, callback) {
        if (callback !== null && callback !== undefined) {
            instance.getMasterView().create(data.placement, callback);
        } else {
            if (data.placement !== null && data.placement !== undefined) {
                if (instance.getContextualMasterKeyRecord() !== null &&
                        instance.getContextualMasterKeyRecord() !== undefined) {
                    instance.getObserverInterface().displayFormProcessingActivity();
                    var masterRecord = instance.getContextualMasterKeyRecord();
                    masterRecord.addDetailItem({
                        'name': data.itemsfield,
                        'data': instance.getObserverInterface().getFormStringifiedObject(),
                        'dataPrototype': instance.getObserverInterface().getContentTypeObjectPrototype()
                    });
                    instance.getMasterView().update({
                        'content': masterRecord,
                        'callback': function (result) {
                            if (result !== null && result !== undefined) {
                                if (result.error) {
                                    instance.getObserverInterface().displayFormProcessing(false);
                                    instance.getObserverInterface().displayFormFailureActivity();
                                    instance.getMasterView().getObserverInterface().displayFailureActivity();
                                    var entityObject = instance.getObserverInterface().getContentTypeObject();
                                    var jsonObject = JSON.parse(instance.getObserverInterface().getFormStringifiedObject());
                                    masterRecord.removeDetailItem(entityObject.newObject(jsonObject));
                                } else {

                                    if (instance.getMasterView().getCRUDProcessor().responseData().contents !== null &&
                                            instance.getMasterView().getCRUDProcessor().responseData().contents !== undefined) {
                                        if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                            if (data.processReturnedResults) {
                                                var returnedDetailItems = typeof (instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]) === 'function' ? instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield];
                                                if (typeof (masterRecord[data.itemsfield]) === 'function') {
                                                    masterRecord[data.itemsfield](returnedDetailItems);
                                                } else {
                                                    masterRecord[data.itemsfield] = returnedDetailItems;
                                                }
                                            }
                                        }
                                    }

                                    instance.getObserverInterface().updateView({'action': 'update',
                                        'resultRecord': instance.getMasterView().getCRUDProcessor().Record,
                                        'placement': result.placement
                                    });

                                    instance.getObserverInterface().resetForm();
                                    instance.getObserverInterface().displayFormSuccessActivity();
                                    instance.getMasterView().getObserverInterface().displaySuccessActivity();

                                    var records = instance.getContentTypeObjects({'simpleObjects': ((typeof (masterRecord[data.itemsfield]) === "function") ? masterRecord[data.itemsfield]() : masterRecord[data.itemsfield])});
                                    if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                        if (data.processReturnedResults) {
                                            records = instance.getContentTypeObjects({'simpleObjects': ((typeof (instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]) === "function") ? instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().Record[data.itemsfield])});
                                        }
                                    }

                                    instance.getObserverInterface().fillListRecordsView({
                                        'page': instance.getObserverInterface().getCurrentList(),
                                        'responseData': instance.getMasterView().getCRUDProcessor().responseData(),
                                        'records': records,
                                        'immediateRecords': true
                                    });

                                    instance.getObserverInterface().displayFormProcessing(false);
                                }
                            }
                            $('.modal').trigger('apply-form-locale');
                        }
                    });
                }
            } else {
                if (instance.getContextualMasterKeyRecord() !== null && instance.getContextualMasterKeyRecord() !== undefined) {
                    instance.getObserverInterface().displayFormProcessingActivity();
                    var masterRecord = instance.getContextualMasterKeyRecord();
                    masterRecord.addDetailItem({
                        'name': data.itemsfield,
                        'data': instance.getObserverInterface().getFormStringifiedObject(),
                        'dataPrototype': instance.getObserverInterface().getContentTypeObjectPrototype()
                    });
                    instance.getMasterView().update({
                        'content': masterRecord,
                        'callback': function (result) {
                            if (result !== null && result !== undefined) {
                                if (result.error) {
                                    instance.getObserverInterface().displayFormProcessing(false);
                                    instance.getObserverInterface().displayFormFailureActivity();
                                    instance.getMasterView().getObserverInterface().displayFailureActivity();
                                    var entityObject = instance.getObserverInterface().getContentTypeObject();
                                    var jsonObject = JSON.parse(instance.getObserverInterface().getFormStringifiedObject());
                                    masterRecord.removeDetailItem(entityObject.newObject(jsonObject));
                                } else {

                                    if (instance.getMasterView().getCRUDProcessor().responseData().contents !== null &&
                                            instance.getMasterView().getCRUDProcessor().responseData().contents !== undefined) {

                                        if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                            if (data.processReturnedResults) {
                                                var returnedDetailItems = typeof (instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]) === 'function' ? instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield];
                                                if (typeof (masterRecord[data.itemsfield]) === 'function') {
                                                    masterRecord[data.itemsfield](returnedDetailItems);
                                                } else {
                                                    masterRecord[data.itemsfield] = returnedDetailItems;
                                                }
                                            }
                                        }
                                    }

                                    instance.getObserverInterface().updateView({'action': 'update',
                                        'resultRecord': instance.getMasterView().getCRUDProcessor().Record,
                                        'placement': data.placement
                                    });

                                    instance.getObserverInterface().resetForm();
                                    instance.getObserverInterface().displayFormSuccessActivity();
                                    instance.getMasterView().getObserverInterface().displaySuccessActivity();


                                    var records = instance.getContentTypeObjects({'simpleObjects': ((typeof (masterRecord[data.itemsfield]) === "function") ? masterRecord[data.itemsfield]() : masterRecord[data.itemsfield])});
                                    if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                        if (data.processReturnedResults) {
                                            records = instance.getContentTypeObjects({'simpleObjects': ((typeof (instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]) === "function") ? instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().Record[data.itemsfield])});
                                        }
                                    }

                                    instance.getObserverInterface().fillListRecordsView({
                                        'page': instance.getObserverInterface().getCurrentList(),
                                        'responseData': instance.getMasterView().getCRUDProcessor().responseData(),
                                        'records': records,
                                        'immediateRecords': true
                                    });
                                    instance.getObserverInterface().displayFormProcessing(false);
                                }
                            }
                            $('.modal').trigger('apply-form-locale');
                        }
                    });
                }
            }
        }
    };

    /// <summary>Updates detail item in selected master key record based on detail form view object.</summary>
    instance.updateDetail = function (data, callback) {

        if (callback !== null && callback !== undefined) {
            instance.getMasterView().update(callback);
        } else {
            if (instance.getContextualMasterKeyRecord() !== null &&
                    instance.getContextualMasterKeyRecord() !== undefined) {
                instance.getObserverInterface().displayFormProcessingActivity();
                var masterRecord = instance.getContextualMasterKeyRecord();
                masterRecord.editOrRemoveDetailItem({
                    'name': data.itemsfield,
                    'data': instance.getObserverInterface().getFormStringifiedObject(),
                    'action': "edit",
                    'dataPrototype': instance.getObserverInterface().getContentTypeObjectPrototype()
                });
                instance.getMasterView().update({
                    'content': masterRecord,
                    'callback': function (result) {

                    if (result !== null && result !== undefined) {
                        if (result.error) {
                            instance.getObserverInterface().displayFormProcessing(false);
                            instance.getObserverInterface().displayFormFailureActivity();
                            instance.getMasterView().getObserverInterface().displayFailureActivity();
                        } else {

                            if (instance.getMasterView().getCRUDProcessor().responseData().contents !== null &&
                                    instance.getMasterView().getCRUDProcessor().responseData().contents !== undefined) {

                                if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                    if (data.processReturnedResults) {
                                        var returnedDetailItems = typeof (instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]) === 'function' ? instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield];
                                        if (typeof (masterRecord[data.itemsfield]) === 'function') {
                                            masterRecord[data.itemsfield](returnedDetailItems);
                                        } else {
                                            masterRecord[data.itemsfield] = returnedDetailItems;
                                        }
                                    }
                                }
                            }

                            instance.getObserverInterface().updateView({'action': 'update',
                                'resultRecord': instance.getMasterView().getCRUDProcessor().Record,
                                'placement': data.placement
                            });
                            
                            instance.getObserverInterface().displayFormSuccessActivity();
                            instance.getMasterView().getObserverInterface().displaySuccessActivity();

                            var records = instance.getContentTypeObjects({'simpleObjects': ((typeof (masterRecord[data.itemsfield]) === "function") ? masterRecord[data.itemsfield]() : masterRecord[data.itemsfield])});
                            if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                if (data.processReturnedResults) {
                                    records = instance.getContentTypeObjects({'simpleObjects': ((typeof (instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]) === "function") ? instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().Record[data.itemsfield])});
                                }
                            }

                            instance.getObserverInterface().fillListRecordsView({
                                'page': instance.getObserverInterface().getCurrentList(),
                                'responseData': instance.getMasterView().getCRUDProcessor().responseData(),
                                'records': records,
                                'immediateRecords': true
                            });
                            instance.getObserverInterface().displayFormProcessing(false);
                        }
                    }
                    $('.modal').trigger('apply-form-locale');
                }
                });
            }
        }
    };

    /// <summary>Deletes detail item record based on input record.</summary>
    instance.deleteDetail = function (data, callback) {
        if (callback !== null && callback !== undefined) {
            instance.getOriginalView().delete(data.record, callback);
        } else {
            if (instance.getContextualMasterKeyRecord() !== null &&
                    instance.getContextualMasterKeyRecord() !== undefined) {
                instance.getObserverInterface().displayGridProcessingActivity();
                var masterRecord = instance.getContextualMasterKeyRecord();
                masterRecord.editOrRemoveDetailItem({
                    'name': data.itemsfield,
                    'data': instance.getObserverInterface().getStringifiedObject(data.record),
                    'action': "remove",
                    'dataPrototype': instance.getObserverInterface().getContentTypeObjectPrototype()
                });
                instance.getMasterView().update({
                    'content': masterRecord,
                    'callback': function (result) {
                        if (result !== null && result !== undefined) {
                            if (result.error) {
                                instance.getObserverInterface().displayGridFailureActivity();
                                instance.getMasterView().getObserverInterface().displayGridFailureActivity();

                            } else {

                                if (instance.getMasterView().getCRUDProcessor().responseData().contents !== null &&
                                        instance.getMasterView().getCRUDProcessor().responseData().contents !== undefined) {

                                    if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                        if (data.processReturnedResults) {
                                            var returnedDetailItems = typeof (instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]) === 'function' ? instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().responseData().contents[data.itemsfield];
                                            if (typeof (masterRecord[data.itemsfield]) === 'function') {
                                                masterRecord[data.itemsfield](returnedDetailItems);
                                            } else {
                                                masterRecord[data.itemsfield] = returnedDetailItems;
                                            }
                                        }
                                    }
                                }

                                instance.getObserverInterface().updateView({'action': 'update',
                                    'resultRecord': instance.getMasterView().getCRUDProcessor().Record,
                                    'placement': data.placement
                                });

                                instance.getObserverInterface().displayGridSuccessActivity();
                                instance.getMasterView().getObserverInterface().displaySuccessActivity();

                                var records = instance.getContentTypeObjects({'simpleObjects': ((typeof (masterRecord[data.itemsfield]) === "function") ? masterRecord[data.itemsfield]() : masterRecord[data.itemsfield])});
                                if (data.processReturnedResults !== null && data.processReturnedResults !== undefined) {
                                    if (data.processReturnedResults) {
                                        records = instance.getContentTypeObjects({'simpleObjects': ((typeof (instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]) === "function") ? instance.getMasterView().getCRUDProcessor().Record[data.itemsfield]() : instance.getMasterView().getCRUDProcessor().Record[data.itemsfield])});
                                    }
                                }

                                instance.getObserverInterface().fillListRecordsView({
                                    'page': instance.getObserverInterface().getCurrentList(),
                                    'responseData': instance.getMasterView().getCRUDProcessor().responseData(),
                                    'records': records,
                                    'immediateRecords': true
                                });
                            }
                        }
                        $('.modal').trigger('apply-form-locale');
                    }
                });
            }
        }
    };

    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {

        /**
         * Related detail view data members and functions extensions
         * *************************************************************************
         */

        if (instance.getObserverInterface().getContentTypeObjectPrototype() !== null &&
                instance.getObserverInterface().getContentTypeObjectPrototype() !== undefined) {

            if (instance.getObserverInterface().getContentTypeObjectPrototype().setRelatingRecord === undefined) {
                /**
                 * Sets relating record.
                 * 
                 * @param {type} data 
                 */
                instance.getObserverInterface().getContentTypeObjectPrototype().setRelatingRecord = function (data) {
                    var instance = this;
                    instance._relatedrecord = data;
                };
            }

            if (instance.getObserverInterface().getContentTypeObjectPrototype().getRelatingRecord === undefined) {
                /**
                 * Gets relating record.
                 */
                instance.getObserverInterface().getContentTypeObjectPrototype().getRelatingRecord = function () {
                    var instance = this;
                    return instance._relatedrecord;
                };
            }


            if (instance.getObserverInterface().getContentTypeObjectPrototype().setRelatingRecordId === undefined) {
                /**
                 * Sets relating record id.
                 * 
                 * @param {type} data 
                 */
                instance.getObserverInterface().getContentTypeObjectPrototype().setRelatingRecordId = function (data) {
                    var instance = this;
                    instance._relatedrecordid = data;
                };
            }

            if (instance.getObserverInterface().getContentTypeObjectPrototype().getRelatingRecordId === undefined) {
                /**
                 * Gets relating record id.
                 */
                instance.getObserverInterface().getContentTypeObjectPrototype().getRelatingRecordId = function () {
                    var instance = this;
                    return instance._relatedrecordid;
                };
            }
            

            if (instance.getObserverInterface().getContentTypeObjectPrototype().setRecordType === undefined) {
                /**
                 * Sets record type.
                 * 
                 * @param {type} data 
                 */
                instance.getObserverInterface().getContentTypeObjectPrototype().setRecordType = function (data) {
                    var instance = this;
                    instance._relatedrecordtype = data;
                };
            }

            if (instance.getObserverInterface().getContentTypeObjectPrototype().getRecordType === undefined) {
                /**
                 * Gets record type.
                 */
                instance.getObserverInterface().getContentTypeObjectPrototype().getRecordType = function () {
                    var instance = this;
                    return instance._relatedrecordtype;
                };
            }
        }

        /**
         * CRUD - Observer connectivity for dependent view functions
         * *************************************************************************
         * Following connects observers to detail functionality when participating
         * in a master-detail relationship.
         */

        /**
         * Resets form object and view mode.
         * 
         * data._relatedrecordtype -  reference record type
         * data._relatedrecord - reference record
         * 
         * @param {type} data
         * @returns {undefined}
         */
        instance.getObserverInterface().resetDetailForm = function (data) {
            instance.getObserverObject().resetDetailForm(data);
        };

        /**
         * Resets form for editing based on the indexed record.
         * 
         * @param {type} index
         * @returns {undefined}
         */
        instance.getObserverInterface().resetDetailFormForEditing = function (index) {
            instance.getObserverObject().resetDetailFormForEditing(index);
        };

        /**
         * Find records based on provided keyword (via observer keyword property) 
         * and page number.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverInterface().findDetail = function (page) {
            instance.getObserverObject().findDetail(page);
        };

        /**
         * Selects a record from existing detail records.
         * 
         * @returns {undefined}
         */
        instance.getObserverInterface().selectDetailRecord = function () {
            instance.getObserverObject().selectDetailRecord();
        };

        /**
         * Creates new detail item in selected master key record based on detail 
         * form view object.
         * 
         * options.content - entity instance
         * options.placement - 'first' or 'last'
         * callback - reference to callback function
         * 
         * @param {type} data
         * @param {type} callback
         * @returns {undefined}
         */
        instance.getObserverInterface().createDetail = function (data, callback) {
            instance.getObserverObject().createDetail(data, callback);
        };

        /**
         * Updates detail item in selected master key record based on detail 
         * form view object.
         * 
         * @param {type} data
         * @param {type} callback
         * @returns {undefined}
         */
        instance.getObserverInterface().updateDetail = function (data, callback) {
            instance.getObserverObject().updateDetail(data, callback);
        };

        /**
         * Deletes detail item record based on input record.
         * 
         * data.record - 
         * data.itemsfield
         * callback - 
         * 
         * @param {type} data
         * @param {type} callback 
         * @returns {undefined}
         */
        instance.getObserverInterface().deleteDetail = function (data, callback) {
            instance.getObserverObject().deleteDetail(data, callback);
        };
    }

    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {

        /**
         * Resets form object and view mode.
         * 
         * data._relatedrecordtype -  reference record type
         * data._relatedrecord - reference record
         * 
         * @param {type} data
         * @returns {undefined}
         */
        instance.getObserverObject().resetDetailForm = function (data) {
            instance.getObserverInterface().resetForm();
            if (data._relatedrecordtype !== null && data._relatedrecordtype !== undefined) {
                instance.getObserverInterface().getFormObject().setRecordType(data._relatedrecordtype);

                if (data._relatedrecordtype === "level1-record") {
                    instance.getObserverInterface().getFormObject().setRelatingRecord(data._relatedrecord);
                } else if (data._relatedrecordtype === "level1-record-id") {
                    instance.getObserverInterface().getFormObject().setRelatingRecordId(data._relatedrecordid);
                } else if (data._relatedrecordtype === "level2-record") {
                    instance.getObserverInterface().getFormObject().setRelatingRecord(data._relatedrecord);
                } else if (data._relatedrecordtype === "level2-record-id") {
                    instance.getObserverInterface().getFormObject().setRelatingRecordId(data._relatedrecordid);
                }
            }
        };

        /**
         * Resets form for editing based on the indexed record.
         * 
         * @param {type} index
         * @returns {undefined}
         */
        instance.getObserverObject().resetDetailFormForEditing = function (index) {
            instance.getObserverInterface().resetFormForEditing(index);
        };

        /**
         * Find records based on provided keyword (via observer keyword property) 
         * and page number.
         * 
         * @param {type} page
         * @returns {undefined}
         */
        instance.getObserverObject().findDetail = function (page) {
            instance.findDetail(page);
        };

        /**
         * Selects a record from existing detail records.
         * 
         * @returns {undefined}
         */
        instance.getObserverObject().selectDetailRecord = function () {
            instance.selectDetailRecord();
        };

        /**
         * Creates new detail item in selected master key record based on detail 
         * form view object.
         * 
         * options.content - entity instance
         * options.placement - 'first' or 'last'
         * callback - reference to callback function
         * 
         * @param {type} data
         * @param {type} callback
         * @returns {undefined}
         */
        instance.getObserverObject().createDetail = function (data, callback) {
            instance.createDetail(data, callback);
            instance.getObserverInterface().setSelectedRecord("");
        };

        /**
         * Updates detail item in selected master key record based on detail 
         * form view object.
         * 
         * @param {type} data
         * @param {type} callback
         * @returns {undefined}
         */
        instance.getObserverObject().updateDetail = function (data, callback) {
            instance.updateDetail(data, callback);
            instance.getObserverInterface().setSelectedRecord("");
        };

        /**
         * Deletes detail item record based on input record.
         * 
         * data.record - 
         * data.itemsfield
         * callback - 
         * 
         * @param {type} data
         * @param {type} callback 
         * @returns {undefined}
         */
        instance.getObserverObject().deleteDetail = function (data, callback) {
            instance.deleteDetail(data, callback);
            instance.getObserverInterface().setSelectedRecord("");
        };
    }

    return Object.create(instance);
}
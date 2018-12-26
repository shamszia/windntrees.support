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
/// CRUDKNObserver provides CRUD (create, read, update and delete) enabled records, 
/// record objects and their targets synchronization functionality with related 
/// user interface interactive capabilities.
/// CRUDKNObserver extends from SearchKNObserver and for information about extended 
/// data members refer here.
/// </summary>
function CRUDKNObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance , 'options': options});
    }
    
    var findOptions = Object.create(options);
    findOptions.instance = instance;
    instance = SearchKNObserver(findOptions);
    
    /// <summary>New mode caption.</summary>
    instance.NewModeCaption = ko.observable(instance.getMessageRepository().get("form.new.text"));
    
    /// <summary>Edit mode caption.</summary>
    instance.EditModeCaption = ko.observable(instance.getMessageRepository().get("form.edit.text"));
    
    /// <summary>Edit mode status.</summary>
    instance.EditMode = ko.observable(false);
    
    /// <summary>Form object.</summary>
    instance.FormObject = ko.observable(new (Object.getPrototypeOf(instance.ContentType)).constructor({}));
    
    /// <summary>Master key record object.</summary>
    instance.MasterKeyRecord = ko.observable(null);

    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "CRUDKNObserver";
    };

    /// <summary>Sets master key record in detail observer.</summary>
    instance.setMasterKeyRecord = function (data) {
        instance.MasterKeyRecord(data);
    };

    /// <summary>Gets master key record from detail observer.</summary>
    instance.getMasterKeyRecord = function () {
        return instance.MasterKeyRecord();
    };
    
    /// <summary>Gets observable master key record object.</summary>
    instance.getObservableMasterKeyRecord = function () {
        return instance.MasterKeyRecord;
    };
    
    /// <summary>Sets form's edit mode (true / false). </summary>
    instance.setEditMode = function (data) {
        instance.EditMode(data);
    };

    /// <summary>Gets form's edit mode.</summary>
    instance.getEditMode = function () {
        return instance.EditMode();
    };
    
    /// <summary>Gets observable edit mode object.</summary>
    instance.getObservableEditMode = function () {
        return instance.EditMode;
    };

    /// <summary>Sets form's new mode caption.</summary>
    instance.setNewModeCaption = function (data) {
        instance.NewModeCaption(data);
    };

    /// <summary>Gets form's new mode caption.</summary>
    instance.getNewModeCaption = function () {
        return instance.NewModeCaption();
    };
    
    /// <summary>Gets observable new mode caption object.</summary>
    instance.getObservableNewModeCaption = function () {
        return instance.NewModeCaption;
    };

    /// <summary>Sets form's edit mode caption.</summary>
    instance.setEditModeCaption = function (data) {
        instance.EditModeCaption(data);
    };

    /// <summary>Gets form's edit mode caption.</summary>
    instance.getEditModeCaption = function () {
        return instance.EditModeCaption();
    };
    
    /// <summary>Gets observable edit mode caption.</summary>
    instance.getObservableEditModeCaption = function () {
        return instance.EditModeCaption;
    };
    
    /// <summary>Sets form observer object with optional original key.</summary>
    instance.setFormObject = function (data) {
        var newObject = (data.content !== null && data.content !== undefined) ? data.content : data;
        instance.FormObject(newObject);
    };

    /// <summary>Gets form object.</summary>
    instance.getFormObject = function () {
        return instance.FormObject();
    };
    
    /// <summary>Gets observable form object.</summary>
    instance.getObservableFormObject = function () {
        return instance.FormObject;
    };

    /// <summary>Gets form's stringified JSON object.</summary>
    instance.getFormStringifiedObject = function () {
        return ko.toJSON(instance.FormObject());
    };

    /// <summary>Gets form's JSON object.</summary>
    instance.getFormJSONObject = function () {
        return JSON.parse(ko.toJSON(instance.FormObject()));
    };
    
    /// <summary>Resets selected record value.</summary>
    instance.resetRecord = function () {
        instance.setRecord(null);
    };

    /// <summary>Validate form object.</summary>
    instance.validateFormObject = function () {
        var errors = ko.validation.group(instance.FormObject(), {deep: true});
        errors.showAllMessages();
        if (errors().length > 0) {
            alert(instance.getMessageRepository().get("standard.err.text"));
            return false;
        }
        return true;
    };

    /// <summary>Synchronizes observer with view.</summary>
    instance.synchronizeView = function (options) {

        options = options === null || options === undefined ? {} : options;

        //set or define options.donotsync value to avoid observer / view synchronization
        if (options.donotsync === null || options.donotsync === undefined) {

            //select connected view
            var view = null;

            //if view is provided as part of synchronizing options then override with provided view
            if (options.view !== null && options.view !== undefined) {
                view = options.view;
            } else {
                view = instance.getView();
            }

            //check if observer is integrated with view
            if (view !== null && view !== undefined) {

                //check if view has key field value
                if (view.getObjectKey() !== null && view.getObjectKey() !== undefined) {

                    //if key object key (or referential key) exists then always extend form object with __referencekey field.
                    instance.FormObject()["__referencekey"] = view.getObjectKey();

                    //check if view has a key field
                    if (view.getKeyField() !== null && view.getKeyField() !== undefined) {

                        //if view has key field and related value information then check if the contentType form object supports view field

                        //if key field is a function then its observable and provide value as function argument.
                        if (typeof (instance.FormObject()[view.getKeyField()]) === "function") {

                            (instance.FormObject()[view.getKeyField()])(view.getObjectKey());

                        } else {

                            //if it is supported then update form field with object key value.
                            instance.FormObject()[view.getKeyField()] = view.getObjectKey();
                        }

                        var uploadForm = (options.form !== null && options.form !== undefined) ? options.form : "__uploadform";

                        if (document.forms[uploadForm] !== null && document.forms[uploadForm] !== undefined) {

                            if (document.forms[uploadForm][view.getKeyField()] !== null && document.forms[uploadForm][view.getKeyField()] !== undefined) {

                                document.forms[uploadForm][view.getKeyField()].value = view.getObjectKey();
                            }
                        }
                    }
                }
                
                if (view.getObjects() !== null && view.getObjects() !== undefined) {
                    
                    if (Array.isArray(view.getObjects())) {
                        
                        for (var i = 0; i < view.getObjects().length; i++) {
                            
                            var obj = view.getObjects()[i];
                            if (obj.field !== null && obj.field !== undefined) {
                                
                                //if object field is a function then its observable and provide value as function argument.
                                if (typeof (instance.FormObject()[obj.field]) === "function") {

                                    (instance.FormObject()[obj.field])(obj.object);

                                } else {

                                    //if it is not a function then set the value;
                                    instance.FormObject()[obj.field] = obj.object;
                                }
                            }
                        }
                        
                    } else {
                        
                        var obj = view.getObjects();
                        if (obj.field !== null && obj.field !== undefined) {

                            //if object field is a function then its observable and provide value as function argument.
                            if (typeof (instance.FormObject()[obj.field]) === "function") {

                                (instance.FormObject()[obj.field])(obj.object);

                            } else {

                                //if it is not a function then set the value;
                                instance.FormObject()[obj.field] = obj.object;
                            }
                        }
                    }
                }
            }
        }
    };

    /// <summary>Resets form object and view mode.</summary>
    instance.resetForm = function (options) {
        instance.displayFormClearActivity();
        instance.EditMode(false);
        instance.FormObject(new (instance.getContentTypeObjectPrototype()).constructor({}));
        
        if (options !== null && options !== undefined) {
            if (options.callback !== null && options.callback !== undefined) {

                if (typeof (options.callback) === "function") {

                    options.callback(options.callbackparams);
                }
            }
        }

        instance.synchronizeView(options);
    };

    /// <summary>Resets form for editing based on the indexed record.</summary>
    instance.resetFormForEditing = function (index) {
        instance.displayFormClearActivity();
        
        instance.EditMode(true);
        var indexValue = index();
        instance.SelectedRecordIndex = indexValue;

        var record = instance.Records()[indexValue];

        try {
            if (record.getType() === 'DetailObserver' ||
                    record.getType() === 'DetailKNObserver') {
                record = record.getRecord();
            }
        } catch (e) {
        }
        
        instance.FormObject(new (instance.getContentTypeObjectPrototype()).constructor(JSON.parse(ko.toJSON(record))));
    };

    /// <summary>Resets form for editing based on the data record.</summary>
    instance.resetFormForEditingByRecord = function (data) {
        instance.displayFormClearActivity();
        
        instance.EditMode(true);

        var record = data;

        try {

            if (data.getType() === 'DetailObserver' ||
                    data.getType() === 'DetailKNObserver') {
                record = record.getRecord();
            }

        } catch (e) {
        }

        instance.FormObject(new (instance.getContentTypeObjectPrototype()).constructor(JSON.parse(ko.toJSON(record))));
    };

    /// <summary>Updates new record and associated views.</summary>
    instance.updateNewRecordView = function (data) {
        
        if (data !== null && data !== undefined) {
            //if newly created record has request input infomration
            if (data.requestData !== null && data.requestData !== undefined) {
                // then reform form options with request input form information.
                // this information is important for reference key synchronization during 
                // a referential content form submission and preparing for new submission.
                data.form = data.requestData.form;
            }
        }

        instance.resetForm(data);

        if (data.record !== null && data.record !== undefined) {

            var newRecord = null;
            try {

                if (data.record.getType() === 'DetailObserver' ||
                        data.record.getType() === 'DetailKNObserver') {

                    newRecord = data.record;
                } else {
                    newRecord = new (instance.getContentTypeObjectPrototype()).constructor(JSON.parse(ko.toJSON(data.record)));
                }
            } catch (e) {
                newRecord = new (instance.getContentTypeObjectPrototype()).constructor(JSON.parse(ko.toJSON(data.record)));
            }

            if (data.order !== null && data.order !== undefined) {
                if (data.order === 'first') {
                    var oldRecords = instance.Records();
                    instance.Records([]);
                    instance.Records.push(newRecord);
                    for (var i = 0; i < oldRecords.length; i++) {
                        instance.Records.push(oldRecords[i]);
                    }
                } else {
                    instance.Records.push(newRecord);
                }
            } else {
                instance.Records.push(newRecord);
            }
        }

        instance.performRefObjectAction(data);
        $('.modal').trigger('apply-form-locale');
    };

    /// <summary>Updates existing record and associated views.</summary>
    instance.updateExistingRecordView = function (data) {
        instance.displaySuccessActivity();

        if (data.record !== null && data.record !== undefined) {

            data.record = new (instance.getContentTypeObjectPrototype()).constructor(JSON.parse(ko.toJSON(data.record)));

            for (var i = 0; i < instance.Records().length; i++) {
                var item = instance.Records()[i];
                var itemRecord = item;

                try {

                    if (itemRecord.getType() === 'DetailKNObserver' ||
                            itemRecord.getType() === 'DetailObserver') {

                        itemRecord = itemRecord.getRecord();

                        if (itemRecord.getKey() === data.record.getKey()) {

                            item.setRecord(data.record);
                        }

                    } else {
                        if (itemRecord.getKey() === data.record.getKey()) {
                            instance.Records.replace(item, data.record);
                        }

                    }

                } catch (e) {
                    if (itemRecord.getKey() === data.record.getKey()) {
                        instance.Records.replace(item, data.record);
                    }

                }
            }
        }
        
        if (data.resetForm !== null && data.resetForm !== undefined) {
            if (data.resetForm) {
                instance.FormObject(new (instance.getContentTypeObjectPrototype()).constructor({}));
                instance.EditMode(false);
                instance.displaySuccessActivity();
            }
        }
        
        instance.performRefObjectAction(data);

        $('.modal').trigger('apply-form-locale');
    };

    /// <summary>Updates deletion record and associated views.</summary>
    instance.updateDeletionRecordView = function (data) {
        instance.displaySuccessActivity();

        if (data.record !== null && data.record !== undefined) {

            var deletedRecord = new (instance.getContentTypeObjectPrototype()).constructor(JSON.parse(ko.toJSON(data.record)));

            for (var i = 0; i < instance.Records().length; i++) {
                var item = instance.Records()[i];
                var itemRecord = item;

                try {

                    if (itemRecord.getType() === 'DetailKNObserver' ||
                            itemRecord.getType() === 'DetailObserver') {

                        itemRecord = itemRecord.getRecord();
                    }

                } catch (e) {
                }

                if (itemRecord.getKey() === deletedRecord.getKey()) {
                    instance.Records.remove(item);
                }
            }
        }
        
        instance.performRefObjectAction(data);
    };
    
    /// <summary>Performs a reference action with reference input on a reference object.</summary>
    instance.performRefObjectAction = function (options) {
        if (options.refActions !== null && options.refActions !== undefined) {
            if (options.refObject !== null && options.refObject !== undefined) {

                if (Array.isArray(options.refActions)) {

                    for (var i = 0; i < options.refActions.length; i++) {
                        
                        var refInput = undefined;
                        if (options.refInputs !== null && options.refInputs !== undefined) {
                            
                            if (Array.isArray(options.refInputs)) {
                                refInput = options.refInputs[i];
                            } else {
                                refInput = options.refInputs;
                            }
                        }
                        options.refObject[options.refActions[i]](refInput);
                    }

                } else {
                    options.refObject[options.refActions](options.refInputs);
                }
            }
        }
    };

    /// <summary>Updates observer (data/views) with result record.</summary>
    instance.updateView = function (data) {
        instance.displayProcessing(false);
        instance.displayGridSuccessActivity();
        if (data.action === undefined) {
            if (data.placement !== null && data.placement !== undefined) {
                instance.updateNewRecordView({
                    'requestData': data.requestData,
                    'refObject': data.refObject,
                    'refActions': data.refActions,
                    'refInputs': data.refInputs,
                    'record': data.resultRecord,
                    'order': data.placement
                });
            } else {
                instance.updateNewRecordView({
                    'requestData': data.requestData,
                    'refObject': data.refObject,
                    'refActions': data.refActions,
                    'refInputs': data.refInputs,
                    'record': data.resultRecord,
                    'order': 'first'
                });
            }
        } else {
            if (data.action === 'create') {
                if (data.placement !== null && data.placement !== undefined) {
                    instance.updateNewRecordView({
                        'requestData': data.requestData,
                        'refObject': data.refObject,
                        'refActions': data.refActions,
                        'refInputs': data.refInputs,
                        'record': data.resultRecord,
                        'order': data.placement
                    });
                } else {
                    instance.updateNewRecordView({
                        'requestData': data.requestData,
                        'refObject': data.refObject,
                        'refActions': data.refActions,
                        'refInputs': data.refInputs,
                        'record': data.resultRecord,
                        'order': 'first'
                    });
                }
            } else if (data.action === 'update') {
                instance.updateExistingRecordView({
                    'requestData': data.requestData,
                    'refObject': data.refObject,
                    'refActions': data.refActions,
                    'refInputs': data.refInputs,
                    'record': data.resultRecord,
                    'resetForm': data.resetForm
                });
            } else if (data.action === 'delete') {
                instance.updateDeletionRecordView({
                    'requestData': data.requestData,
                    'refObject': data.refObject,
                    'refActions': data.refActions,
                    'refInputs': data.refInputs,
                    'record': data.resultRecord
                });
            }
        }
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
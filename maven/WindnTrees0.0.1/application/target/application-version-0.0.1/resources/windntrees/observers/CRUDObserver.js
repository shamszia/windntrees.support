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
/// CRUDObserver provides concrete observer independent CRUD (create, read, update 
/// and delete) enabled records, record objects and their targets synchronization 
/// functionality with related user interface interactive capabilities. 
/// CRUDObserver extends from SearchObserver and for information about extended 
/// functions refer here. 
/// </summary>
function CRUDObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.observer !== null && options.observer !== undefined) {

        if (typeof (options.observer) === "string") {
            
            //select and initializes observer.
            if (options.observer === "kn") {
                instance.Observer = new CRUDKNObserver(options);
            }

        } else {
            
            //if observer is provided it is selected.
            instance.Observer = options.observer;
        }
    } else {
        
        //if observer is not provided a default observer is initialized and selected.
        instance.Observer = new CRUDKNObserver(options);
    }
    
    
    var findOptions = Object.create(options);
    findOptions.instance = instance;
    findOptions.observer = instance.Observer;
    instance = SearchObserver(findOptions);
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'newparameter': instance.Observer, 'options': options});
    }
    
    /// <summary>Gets type of function construct.</summary>
    instance.getType = function () {
        return "CRUDObserver";
    };
    
    /// <summary>Sets master key record in detail observer.</summary>
    instance.setMasterKeyRecord =  function(data) {
        instance.getObserver().setMasterKeyRecord(data);
    };
    
    /// <summary>Gets master key record from detail observer.</summary>
    instance.getMasterKeyRecord = function () {
        return instance.getObserver().getMasterKeyRecord();
    };
    
    /// <summary>Gets observable master key record object.</summary>
    instance.getObservableMasterKeyRecord = function () {
        return instance.getObserver().getObservableMasterKeyRecord();
    };
    
    /// <summary>Sets form's edit mode (true / false). </summary>
    instance.setEditMode = function(data) {
        instance.getObserver().setEditMode(data);
    };
    
    /// <summary>Gets form's edit mode.</summary>
    instance.getEditMode = function() {
        return instance.getObserver().getEditMode();
    };
    
    /// <summary>Gets observable edit mode object.</summary>
    instance.getObservableEditMode = function () {
        return instance.getObserver().getObservableEditMode();
    };
    
    /// <summary>Sets form's new mode caption.</summary>
    instance.setNewModeCaption = function(data) {
        instance.getObserver().setNewModeCaption(data);
    };
    
    /// <summary>Gets form's new mode caption.</summary>
    instance.getNewModeCaption = function () {
        return instance.getObserver().getNewModeCaption();
    };
    
    /// <summary>Gets observable new mode caption object.</summary>
    instance.getObservableNewModeCaption = function () {
        return instance.getObserver().getObservableNewModeCaption();
    };
    
    /// <summary>Sets form's edit mode caption.</summary>
    instance.setEditModeCaption = function(data) {
        instance.getObserver().setEditModeCaption(data);
    };
    
    /// <summary>Gets form's edit mode caption.</summary>
    instance.getEditModeCaption = function () {
        return instance.getObserver().getEditModeCaption();
    };
    
    /// <summary>Gets observable edit mode caption.</summary>
    instance.getObservableEditModeCaption = function () {
        return instance.getObserver().getObservableEditModeCaption();
    };
    
    /// <summary>Sets form observer object with optional original key.</summary>
    instance.setFormObject = function (data) {
        var record = null; var recordid = null; var recordtype = null;
        if (instance.getFormObject()._relatedrecord !== undefined) {
            record = instance.getFormObject()._relatedrecord;
        }
        if (instance.getFormObject()._relatedrecordid !== undefined) {
            recordid = instance.getFormObject()._relatedrecordid;
        }
        if (instance.getFormObject()._relatedrecordtype !== undefined) {
            recordtype = instance.getFormObject()._relatedrecordtype;
        }
        
        instance.getObserver().setFormObject(data);
        
        if (data.originalKey !== null && data.originalKey !== undefined) {
            instance.getObserver().getFormObject()._datakey = data.originalKey;
        }
        if (record !== null) {
            instance.getFormObject()._relatedrecord =  record;
        }
        if (recordid !== null) {
            instance.getFormObject()._relatedrecordid = recordid;
        }
        if (recordtype !== null) {
            instance.getFormObject()._relatedrecordtype = recordtype;
        }
    };
    
    /// <summary>Gets form object.</summary>
    instance.getFormObject = function() {
        return instance.getObserver().getFormObject();
    };
    
    /// <summary>Gets observable form object.</summary>
    instance.getObservableFormObject = function () {
        return instance.getObserver().getObservableFormObject();
    };
    
    /// <summary>Gets form's JSON object.</summary>
    instance.getFormStringifiedObject = function() {
        return instance.getObserver().getFormStringifiedObject();
    };
    
    /// <summary>Gets form's JSON object.</summary>
    instance.getFormJSONObject = function() {
        return instance.getObserver().getFormJSONObject();
    };
    
    /// <summary>Resets selected record.</summary>
    instance.resetRecord = function () {
        instance.getObserver().setRecord(null);
    };

    /// <summary>Validate form object.</summary>
    instance.validateFormObject = function () {
        return instance.getObserver().validateFormObject();
    };

    /// <summary>Resets form object and view mode.</summary>
    instance.resetForm = function (options) {
        var record = null; var recordid = null; var recordtype = null;
        if (instance.getFormObject()._relatedrecord !== undefined) {
            record = instance.getFormObject()._relatedrecord;
        }
        if (instance.getFormObject()._relatedrecordid !== undefined) {
            recordid = instance.getFormObject()._relatedrecordid;
        }
        if (instance.getFormObject()._relatedrecordtype !== undefined) {
            recordtype = instance.getFormObject()._relatedrecordtype;
        }

        instance.getObserver().resetForm(options);
        
        if (record !== null) {
            instance.getFormObject()._relatedrecord =  record;
        }
        if (recordid !== null) {
            instance.getFormObject()._relatedrecordid = recordid;
        }
        if (recordtype !== null) {
            instance.getFormObject()._relatedrecordtype = recordtype;
        }
    };

    /// <summary>Resets form for editing based on the indexed record.</summary>
    instance.resetFormForEditing = function (index) {
        var record = null; var recordid = null; var recordtype = null;
        if (instance.getFormObject()._relatedrecord !== undefined) {
            record = instance.getFormObject()._relatedrecord;
        }
        if (instance.getFormObject()._relatedrecordid !== undefined) {
            recordid = instance.getFormObject()._relatedrecordid;
        }
        if (instance.getFormObject()._relatedrecordtype !== undefined) {
            recordtype = instance.getFormObject()._relatedrecordtype;
        }
        
        instance.getObserver().resetFormForEditing(index);
        
        if (record !== null) {
            instance.getFormObject()._relatedrecord =  record;
        }
        if (recordid !== null) {
            instance.getFormObject()._relatedrecordid = recordid;
        }
        if (recordtype !== null) {
            instance.getFormObject()._relatedrecordtype = recordtype;
        }
    };

    /// <summary>Resets form for editing based on the data record.</summary>
    instance.resetFormForEditingByRecord = function (data) {
        var record = null; var recordid = null; var recordtype = null;
        if (instance.getFormObject()._relatedrecord !== undefined) {
            record = instance.getFormObject()._relatedrecord;
        }
        if (instance.getFormObject()._relatedrecordid !== undefined) {
            recordid = instance.getFormObject()._relatedrecordid;
        }
        if (instance.getFormObject()._relatedrecordtype !== undefined) {
            recordtype = instance.getFormObject()._relatedrecordtype;
        }
        
        instance.getObserver().resetFormForEditingByRecord(data);
        
        if (record !== null) {
            instance.getFormObject()._relatedrecord =  record;
        }
        if (recordid !== null) {
            instance.getFormObject()._relatedrecordid = recordid;
        }
        if (recordtype !== null) {
            instance.getFormObject()._relatedrecordtype = recordtype;
        }
    };

    /// <summary>Updates new record and associated views.</summary>
    instance.updateNewRecordView = function (data) {
        instance.getObserver().updateNewRecordView(data);
    };

    /// <summary>Updates existing record and associated views.</summary>
    instance.updateExistingRecordView = function (record) {
        instance.getObserver().updateExistingRecordView(record);
    };

    /// <summary>Updates deletion record and associated views.</summary>
    instance.updateDeletionRecordView = function (record) {
        instance.getObserver().updateDeletionRecordView(record);
    };

    /// <summary>Updates observer (data/views) with result record.</summary>
    instance.updateView = function (data) {
        instance.getObserver().updateView(data);
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
};



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
/// ObjectKNObserver provides source and target synchronization functionality for a 
/// particular object source with related user interface interactive capabilities.
/// ObjectObserver extends from ActivityObserver and for information about activity 
/// functions refer here.
/// </summary>
function ObjectKNObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options });
    }
    
    instance = extender.extendField({'instance': instance,
        'field': 'InputObject',
        'value': (options.object !== null && options.object !== undefined) ? ko.observable(options.object) : ko.observable(null)});
    
    instance = extender.extendField({'instance': instance,
        'field': 'OutputObject',
        'value': (options.object !== null && options.object !== undefined) ? ko.observable(options.object) : ko.observable(null)});
    
    instance = extender.extendObjectInterface({'instance': instance,
        'field': 'OutputObject' });
    
    //if not extending from existing instance, this will ensure that instance is provided.
    var activityOptions = Object.create(options);
    activityOptions.instance = instance;
    //extends from ActivityKNObserver
    instance = ActivityKNObserver(activityOptions);
     
    if (instance.getContentTypeObjectPrototype() !== null 
            && instance.getContentTypeObjectPrototype() !== undefined ) {
        
        if (instance.getContentTypeObjectPrototype().get === undefined) {
            
            instance.getContentTypeObjectPrototype().get = function (name) {
                var instance = this;
                if (typeof (instance[name]) === "function") {
                    return instance[name]();
                } else {
                    return instance[name];
                }
            };
        }

        if (instance.getContentTypeObjectPrototype().getKey === undefined) {
            
            instance.getContentTypeObjectPrototype().getKey = function () {
                var instance = this;
                if (instance._datakey !== null && instance._datakey !== undefined) {
                    return instance._datakey;
                }
            };
        }

        if (instance.getContentTypeObjectPrototype().newObject === undefined) {
            
            instance.getContentTypeObjectPrototype().newObject = function (data) {
                return new (instance.getContentTypeObjectPrototype()).constructor(data);
            };
        }
        
    }
    
    if (options.inputObject !== null && options.inputObject !== undefined) {
        if (typeof (instance["InputObject"]) === "function") {
            instance["InputObject"] (options.inputObject);
        } else {
            instance["InputObject"] = options.inputObject;
        }
    } else {

        if (instance.getContentTypeObjectPrototype() !== null && instance.getContentTypeObjectPrototype() !== undefined) {

            if (typeof (instance["InputObject"]) === "function") {
                instance["InputObject"](instance.getContentTypeObjectPrototype().newObject({}));
            } else {
                instance["InputObject"] = instance.getContentTypeObjectPrototype().newObject({});
            }

        } else {

            if (typeof (instance["InputObject"]) === "function") {

                instance["InputObject"] ({});

            } else {

                instance["InputObject"] = {};
            }
        }
    }
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "ObjectKNObserver";
    };

    /// <summary>Sets form observer object with optional original key.</summary>
    instance.setFormObject = function (data) {
        var newObject = (data.content !== null && data.content !== undefined) ? data.content : data;
        instance.InputObject(newObject);
    };

    /// <summary>Gets form object.</summary>
    instance.getFormObject = function () {
        return instance.InputObject();
    };

    /// <summary>Gets observable form object.</summary>
    instance.getObservableFormObject = function () {
        return instance.InputObject;
    };

    /// <summary>Gets form's stringified JSON object.</summary>
    instance.getFormStringifiedObject = function () {
        return ko.toJSON(instance.InputObject());
    };

    /// <summary>Gets form's JSON object.</summary>
    instance.getFormJSONObject = function () {
        return JSON.parse(ko.toJSON(instance.InputObject()));
    };

    /// <summary>Validate form object.</summary>
    instance.validateFormObject = function () {
        var errors = ko.validation.group(instance.getFormObject(), { deep: true });
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
                    instance.getFormObject()["__referencekey"] = view.getObjectKey();

                    //check if view has a key field
                    if (view.getKeyField() !== null && view.getKeyField() !== undefined) {

                        //if view has key field and related value information then check if the contentType form object supports view field

                        //if key field is a function then its observable and provide value as function argument.
                        if (typeof (instance.getFormObject()[view.getKeyField()]) === "function") {

                            (instance.getFormObject()[view.getKeyField()])(view.getObjectKey());

                        } else {

                            //if it is supported then update form field with object key value.
                            instance.getFormObject()[view.getKeyField()] = view.getObjectKey();
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
                                if (typeof (instance.getFormObject()[obj.field]) === "function") {

                                    (instance.getFormObject()[obj.field])(obj.object);

                                } else {

                                    //if it is not a function then set the value;
                                    instance.getFormObject()[obj.field] = obj.object;
                                }
                            }
                        }
                        
                    } else {
                        
                        var obj = view.getObjects();
                        if (obj.field !== null && obj.field !== undefined) {

                            //if object field is a function then its observable and provide value as function argument.
                            if (typeof (instance.FormObject()[obj.field]) === "function") {

                                (instance.getFormObject()[obj.field])(obj.object);

                            } else {

                                //if it is not a function then set the value;
                                instance.getFormObject()[obj.field] = obj.object;
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

        instance.setFormObject(new (instance.getContentTypeObjectPrototype()).constructor({}));

        instance.synchronizeView(options);
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}

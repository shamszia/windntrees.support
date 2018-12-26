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

/* global Util */

/// <summary>
/// FlexHTML forms flexible HTML view based on provided HTML format and list of
/// FlexObjects. FlexHTML is capable of extracting information from a remote 
/// web service using GET / POST calls and display using observer or by directly
/// writing into node's innerHTML content. In case of observer less scenario 
/// the type of content, content node and error node must be defined.
/// </summary>
function FlexHTML(options) {
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

    /// <summary>Key</summary>
    instance.Key = options.key;
    
    /// <summary>HTML format value.</summary>
    instance.HTMLFormat = options.htmlformat;
    
    /// <summary>FLEX html value.</summary>
    instance.FlexHTML = options.flexhtml;
    
    /// <summary>Gets type of function construct.</summary>
    instance.getType = function () {
        return "FlexView";
    };
    
    /// <summary>Gets content node value.</summary>
    instance.getContentNode = function () {
        return instance.ContentNode;
    };
    
    /// <summary>Present view with input values and html format.</summary>
    instance.presentView = function (options) {
        
        //check for flexrecord
        var flexKey = instance.Key;
        var viewHTMLFormat = instance.HTMLFormat;
        var flexHTML = instance.FlexHTML;
        
        //if get or post update is available then update flex list with returned
        //record
        if (instance.getCRUDProcessor().getRecord() !== null 
                && instance.getCRUDProcessor().getRecord() !== undefined) {
            
            //FlexHTML returned by processor based on provided content information.
            flexHTML = instance.getCRUDProcessor().getRecord();
            viewHTMLFormat = flexHTML.html;
            flexKey =  flexHTML.key;
        }
        
        if (flexHTML !== null && flexHTML !== undefined) {

            if (flexHTML.items !== null && flexHTML.items !== undefined) {

                for (var i = 0; i < flexHTML.items.length; i++) {

                    var flexObject = flexHTML.items[i];
                    
                    if (flexObject.items !== null && flexObject.items !== undefined) {
                        
                        //first list item contains record key
                        var flexObjectKey = flexObject.items[0];
                        //second list item contains HTML format
                        var flexObjectHtml = flexObject.items[1];

                        for (var i = 2; i < flexObject.items.length; i++) {
                            
                            var objectExpValue = new RegExp('a' + i + '_', 'gi');
                            //this composes a flexible object html view that is 
                            //to be integrated in flex list html view.
                            flexObjectHtml = flexObjectHtml.replace(objectExpValue, Util().extractValue(flexObject.items[i], ""));
                        }
                    }
                    
                    var listExpValue = new RegExp('a' + i + '_', 'gi');
                    var listExpKeyValue = new RegExp('flexkey_', 'gi');
                    //this composes the flexible HTML view based on flexible object views.
                    viewHTMLFormat = flexObjectHtml.replace(listExpValue, Util().extractValue(flexObjectHtml, ""));
                    viewHTMLFormat = flexObjectHtml.replace(listExpKeyValue, Util().extractValue(flexKey, ""));
                }
            }
        }
        return viewHTMLFormat;
    };
    
    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {
        
        instance.getObserverInterface().presentView = function (options) {
            instance.presentView(options);
        };
    }
    
    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {
        
        instance.getObserverObject().presentView = function (options) {
            instance.presentView(options);
        };
    }
    
    /// <summary>Error processing and presenting event subscription.</summary>
    instance.presentErrors = function (event, eventData) {

        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.data.callback(eventData.result);
        } else {

            var htmlErrorOutput = "An error has occured.";
            if (instance.getMessageRepository() !== null && instance.getMessageRepository() !== undefined) {
                htmlErrorOutput = instance.getMessageRepository().get("standard.err.text");
            }

            if ((instance.ErrorNode !== null && instance.ErrorNode !== undefined)
                    || (instance.contenNode !== null && instance.contenNode !== undefined)) {

                htmlErrorOutput = "";
                for (var i = 0; i < instance.getErrors().length; i++) {

                    htmlErrorOutput += (instance.getErrors()[i] + ". ");

                }
            }

            if (instance.ErrorNode !== null && instance.ErrorNode !== undefined) {

                instance.ErrorNode.innerHTML = htmlErrorOutput;

            } else if (instance.ContentNode !== null && instance.ContentNode !== undefined) {

                instance.ContentNode.innerHtml = htmlErrorOutput;

            } else {

                if (instance.getObserverInterface() !== null
                        && instance.getObserverInterface() !== undefined) {
                    
                    instance.getObserverInterface().displayClearActivity();
                    instance.getObserverInterface().setErrors(instance.getErrors());
                }
            }
        }
    };
    
    /// <summary>Record processing and presenting event subscription.</summary>
    instance.presentRecord = function (event, eventData) {

        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.data.callback(eventData.result);
        } else {

            if (instance.ContentNode !== null && instance.ContentNode !== undefined) {

                instance.ContentNode.innerHTML = instance.presentView();

            } else {

                if (instance.getObserverInterface() !== null
                        && instance.getObserverInterface() !== undefined) {
                    
                    if (instance.getObserverInterface().getType() === "ListObserver" ||
                            instance.getObserverInterface().getType() === "ListKNObserver") {
                        
                        instance.getObserverInterface().displaySuccessActivity();
                        instance.getObserverInterface().updateItem({'object': instance});
                        
                    } else if (instance.getObserverInterface().getType() === "ObjectObserver" ||
                            instance.getObserverInterface().getType() === "ObjectKNObserver") {

                        instance.getObserverInterface().displaySuccessActivity();

                        instance.getObserverInterface().setObject({'content': instance.presentView()});

                    } else {

                        instance.getObserverInterface().setRecord({'content': instance.presentView()});
                    }
                }
            }
        }
    };

    /// <summary>Presents request failure.</summary>
    instance.presentFailRequest = function (event, eventData) {
        
        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.data.callback(eventData.result);
        } else {
            
            var htmlErrorOutput = "An error has occured.";
            if (instance.getMessageRepository() !== null && instance.getMessageRepository() !== undefined) {
                htmlErrorOutput = instance.getMessageRepository().get("standard.err.text");
            }
            
            if (instance.ErrorNode !== null && instance.ErrorNode !== undefined) {
                
                instance.ErrorNode.innerHTML = htmlErrorOutput;
                
            } else if (instance.ContentNode !== null && instance.ContentNode !== undefined) {

                instance.ContentNode.innerHtml = htmlErrorOutput;
                
            } else {
                
                if (instance.getObserverInterface() !== null
                        && instance.getObserverInterface() !== undefined) {
                    
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
        $(instance.getCRUDProcessor()).on('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);

        if (instance.getCRUDProcessor().getKey() !== null &&
                instance.getCRUDProcessor().getKey() !== undefined) {

            $('#' + instance.getCRUDProcessor().getKey()).on('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
            $('#' + instance.getCRUDProcessor().getKey()).on('record.processor.CRUD.WindnTrees', eventsInstance.presentRecord);
            $('#' + instance.getCRUDProcessor().getKey()).on('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);
        }
    };
    
    /// <summary>Subscribe CRUDProcessor events.</summary>
    instance.unSubscribeEvents = function (eventsInstance) {
        
        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;
        
        $(instance.getCRUDProcessor()).off('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
        $(instance.getCRUDProcessor()).off('record.processor.CRUD.WindnTrees', eventsInstance.presentRecord);
        $(instance.getCRUDProcessor()).off('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);

        if (instance.getCRUDProcessor().getKey() !== null &&
                instance.getCRUDProcessor().getKey() !== undefined) {

            $('#' + instance.getCRUDProcessor().getKey()).off('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
            $('#' + instance.getCRUDProcessor().getKey()).off('record.processor.CRUD.WindnTrees', eventsInstance.presentRecord);
            $('#' + instance.getCRUDProcessor().getKey()).off('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);
        }
    };
    
    if (options.events !== null && options.events !== undefined) {
        if (options.events) {
            instance.subscribeEvents();
        }
    } else {
        instance.subscribeEvents();
    }
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
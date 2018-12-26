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
/// FlexView presents information contained in a FlexObject using key, evaluator, 
/// result and content item objects. FlexView is capable of extracting information 
/// from a remote web service using GET / POST calls and display using observer or 
/// by directly writing into node's innerHTML content. In observer less scenario 
/// the type of content content,content node contentNode and error node errorNode 
/// must be defined.
/// FlexObject presents information in array of objects (or items). For further 
/// information about FlexObject visit here.
/// FlexView extends from ObjectView and for information about ObjectView visit here.
function FlexView(options) {
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
    
    /// <summary>Flex record.</summary>
    instance.FlexRecord = options.flexrecord;
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "FlexView";
    };
    
    /// <summary>Gets content node value.</summary>
    instance.getContentNode = function () {
        return instance.ContentNode;
    };
    
    /// <summary>Gets record based on key value.</summary>
    instance.getFlex = function (key) {
        
        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
            instance.getObserverInterface().displayProcessingActivity();
        }

        //checks on key value if present then use the key value, otherwise get object key
        key = (key !== null && key !== undefined) ? key : ((instance.ObjectKey !== null && instance.ObjectKey !== undefined) ? instance.ObjectKey : key);

        instance.getCRUDProcessor().get({
            'uri': instance.URI,
            'request': 'flexget',
            'key': key
        });
    };
    
    /// <summary>Gets record based on key value via post.</summary>
    instance.postFlex = function (key) {

        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
            instance.getObserverInterface().displayProcessingActivity();
        }

        //checks on key value if present then use the key value, otherwise get object key
        key = (key !== null && key !== undefined) ? key : ((instance.ObjectKey !== null && instance.ObjectKey !== undefined) ? instance.ObjectKey : key);

        instance.getCRUDProcessor().post({
            'uri': instance.URI,
            'request': 'flexpost',
            'key': key
        });
    };
    
    /// <summary>Gets record based on key value.</summary>
    instance.listFlex = function (keyword) {
        
        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
            instance.getObserverInterface().displayProcessingActivity();
        }

        //checks for keyword value if present then use the keyword value, otherwise observers keyword value
        keyword = (keyword !== null && keyword !== undefined) ? keyword : ((instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) ? instance.getObserverInterface().getKeyword() : keyword);

        instance.getCRUDProcessor().list({
            'uri': instance.URI,
            'method': 'GET',
            'request': 'flexlist',
            'keyword': keyword
        });
    };
    
    /// <summary>Gets record based on key value via post.</summary>
    instance.listFlexPost = function (keyword) {

        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
            instance.getObserverInterface().displayProcessingActivity();
        }

        //checks for keyword value if present then use the keyword value, otherwise observers keyword value
        keyword = (keyword !== null && keyword !== undefined) ? keyword : ((instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) ? instance.getObserverInterface().getKeyword() : keyword);

        instance.getCRUDProcessor().list({
            'uri': instance.URI,
            'request': 'flexlist',
            'keyword': keyword
        });
    };
    
    /// <summary>Present view with input values and html format.</summary>
    instance.presentView = function (options) {
        
        var htmlFormat = "";
        
        //check for flexrecord
        var flexObject = instance.FlexRecord;
        
        //if get or post update is available then update flex object with returned
        //record
        if (instance.getCRUDProcessor().getRecord() !== null 
                && instance.getCRUDProcessor().getRecord() !== undefined) {
            
            //typed FlexObject returned by processed based on provided content information.
            flexObject = instance.getCRUDProcessor().getRecord();
        }
        
        if (flexObject !== null && flexObject !== undefined) {
            
            var flexOptions = Object.create(instance.newOptions());
            flexOptions.flexobject = flexObject;
            
            htmlFormat = Util().getFlexOutput(flexOptions);
        }
        
        return htmlFormat;
    };
    
    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {
        
        instance.getObserverInterface().getFlex = function (options) {
            instance.getFlex(options);
        };
        
        instance.getObserverInterface().postFlex = function (options) {
            instance.postFlex(options);
        };
        
        instance.getObserverInterface().listFlex = function (options) {
            instance.listFlex(options);
        };
        
        instance.getObserverInterface().listFlexPost = function (options) {
            instance.listFlexPost(options);
        };
        
        instance.getObserverInterface().presentView = function (options) {
            instance.presentView(options);
        };
    }
    
    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {
        
        instance.getObserverObject().getFlex = function (options) {
            instance.getFlex(options);
        };
        
        instance.getObserverObject().postFlex = function (options) {
            instance.postFlex(options);
        };
        
        instance.getObserverObject().listFlex = function (options) {
            instance.listFlex(options);
        };
        
        instance.getObserverObject().listFlexPost = function (options) {
            instance.listFlexPost(options);
        };
        
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

    };
    
    /// <summary>Subscribe CRUDProcessor events.</summary>
    instance.unSubscribeEvents = function (eventsInstance) {
        
        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;
        
        $(instance.getCRUDProcessor()).off('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
        $(instance.getCRUDProcessor()).off('record.processor.CRUD.WindnTrees', eventsInstance.presentRecord);
        $(instance.getCRUDProcessor()).off('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);
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
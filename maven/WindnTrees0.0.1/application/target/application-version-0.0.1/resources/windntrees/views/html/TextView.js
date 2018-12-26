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

/**
 * TextView presents subject and description values in provided html format 
 * and css styles. TextView is capable of extracting information from a remote 
 * web service using GET / POST calls and display using observer or by directly
 * writing into node's innerHTML content. In case of observer less scenario 
 * the type of content, content node and error node must be defined.
 * 
 * options.contentnode
 * options.errornode
 * 
 * options.subject
 * options.description
 * options.url
 * options.html
 * options.css
 * 
 * options.uri - defines the address (unique resource identifier).
 * options.observer - view's own observer instance.
 * 
 * @param {type} options 
 * @returns {undefined}
 */

/// <summary>
/// TextView presents subject and description values in provided html format and 
/// css styles. TextView is capable of extracting information from a remote web 
/// service using GET / POST calls and display using observer or by directly writing 
/// into node's innerHTML content. In observer less scenario the type of content 
/// content, content node contentNode and error node errorNode must be defined.
/// In case of GET / POST response the corresponding content result fields for 
/// subject, description, url and urltitle must be mapped with options.subjectf, 
/// options.descriptionf, options.urlf and options.urltitlef fields. If a response 
/// field results in null or undefined value then this can be replaced by opted value, 
/// for example subject field can be provided with a default value like options.subject.
/// TextView extends from ObjectView and for information about ObjectView visit here.
/// </summary>
function TextView(options) {
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
    
    //content fields
    
    /// <summary>Subject text for view.</summary>
    instance.Subject = options.subject;
    
    /// <summary>Description text for view.</summary>
    instance.Description = options.description;
    
    /// <summary>URL for view.</summary>
    instance.URL = options.url;
    
    /// <summary>Title for URL displayed in view.</summary>
    instance.URLTitle = options.urltitle;
    
    /// <summary>HTML format.</summary>
    instance.HTML = options.html;
    
    /// <summary>CSS style.</summary>
    instance.CSS = options.css;
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "TextView";
    };
    
    /// <summary>Gets subject.</summary>
    instance.getSubject = function () {
        return instance.Subject;
    };
    
    /// <summary>Sets subject value.</summary>
    instance.setSubject = function (value) {
        instance.Subject = value;
    };
    
    /// <summary>Gets description value.</summary>
    instance.getDescription = function () {
        return instance.Description;
    };
    
    /// <summary>Sets description value.</summary>
    instance.setDescription = function (value) {
        instance.Description = value;
    };
    
    /// <summary>Gets URL value.</summary>
    instance.getURL = function () {
        return instance.URL;
    };
    
    /// <summary>Sets URL value.</summary>
    instance.setURL = function (value) {
        instance.URL = value;
    };
    
    /// <summary>Gets HTML value.</summary>
    instance.getHTML = function () {
        return instance.HTML;
    };
    
    /// <summary>Sets HTML value.</summary>
    instance.setHTML = function (value) {
        instance.HTML = value;
    };
    
    /// <summary>Gets CSS value.</summary>
    instance.getCSS = function () {
        return instance.CSS;
    };
    
    /// <summary>Sets CSS value.</summary>
    instance.setCSS = function (value) {
        instance.CSS = value;
    };
    
    /// <summary>Gets content node value.</summary>
    instance.getContentNode = function () {
        return instance.ContentNode;
    };
    
    /// <summary>Present view with input values and html format.</summary>
    instance.presentView = function (options) {
        
        var htmlFormat = instance.HTML;
        
        if (options !== null && options !== undefined) {
            if (options.html !== null && options.html !== undefined) {

                htmlFormat = options.html;

            } else {

                if (options.link !== null && options.link !== undefined) {
                    if (options.link) {

                        htmlFormat = "<a class='cssValue' href='urlValue' title='urlTitleValue'>subjectValue</a>";
                        
                    }
                }
            }
        }

        htmlFormat = htmlFormat.replace(/cssValue/gi, Util().extractValue(instance.CSS, Util().extractValue(instance.newOptions().css, "")));
        htmlFormat = htmlFormat.replace(/urlValue/gi, Util().extractValue(instance.URL, Util().extractValue(instance.newOptions().url, "")));
        htmlFormat = htmlFormat.replace(/urlTitleValue/gi, Util().extractValue(instance.URLTitle, Util().extractValue(instance.newOptions().urltitle, "")));
        htmlFormat = htmlFormat.replace(/subjectValue/gi, Util().extractValue(instance.Subject, Util().extractValue(instance.newOptions().subject, "")));
        htmlFormat = htmlFormat.replace(/descriptionValue/gi, Util().extractValue(instance.Description, Util().extractValue(instance.newOptions().description, "")));
        
        return htmlFormat;
    };
    
    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {
        
        instance.getObserverInterface().getSubject = function () {
            instance.getSubject();
        };
        
        instance.getObserverInterface().setSubject = function (subject) {
            instance.setSubject(subject);
        };
        
        instance.getObserverInterface().getDescription = function () {
            instance.getDescription();
        };
        
        instance.getObserverInterface().setDescription = function (description) {
            instance.setDescription(description);
        };
        
        instance.getObserverInterface().getURL = function () {
            instance.getURL();
        };
        
        instance.getObserverInterface().setURL = function (url) {
            instance.setURL(url);
        };
        
        instance.getObserverInterface().getHtml = function () {
            instance.getHtml();
        };
        
        instance.getObserverInterface().setHtml = function (html) {
            instance.setHtml(html);
        };
        
        instance.getObserverInterface().presentView = function (options) {
            instance.presentView(options);
        };
    }
    
    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {
        
        instance.getObserverObject().getSubject = function () {
            instance.getSubject();
        };
        
        instance.getObserverObject().setSubject = function (subject) {
            instance.setSubject(subject);
        };
        
        instance.getObserverObject().getDescription = function () {
            instance.getDescription();
        };
        
        instance.getObserverObject().setDescription = function (description) {
            instance.setDescription(description);
        };
        
        instance.getObserverObject().getURL = function () {
            instance.getURL();
        };
        
        instance.getObserverObject().setURL = function (url) {
            instance.setURL(url);
        };
        
        instance.getObserverObject().getHtml = function () {
            instance.getHtml();
        };
        
        instance.getObserverObject().setHtml = function (html) {
            instance.setHtml(html);
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
            
            instance.Subject = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().subjectf, "subject")], instance.newOptions().subject);
            instance.Description = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().descriptionf, "description")], instance.newOptions().description);
            instance.URL = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().urlf, "url")], instance.newOptions().url);
            instance.URLTitle = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().urltitlef, "urltitle")], instance.newOptions().urltitle);
            instance.HTML = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().htmlf, "html")], instance.newOptions().html);
            instance.CSS = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().cssf, "css")], instance.newOptions().css);

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
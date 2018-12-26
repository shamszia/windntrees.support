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
/// ContentList finds records based on input values and loads content video, image, 
/// subject and description values in provided html format and css styles. 
/// ContentList is capable of extracting information from a remote web service 
/// using GET / POST calls and display using observer or by directly writing into 
/// node's innerHTML content. In observer less scenario the type of content content, 
/// content node contentNode and error node errorNode must be defined.
/// ContentList extends from ObjectView and for information about ObjectView visit here.
/// </summary>
function ContentList(options) {
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
    
    /// <summary>Gets type of view.</summary>
    instance.getType = function () {
        return 'ContentList';
    };
    
    /// <summary>Clears (resets) observer records list and view.</summary>
    instance.clearRecords = function () {

        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
            
            if (instance.getObserverInterface().getType() === 'ListObserver' 
                    || instance.getObserverInterface().getType() === 'ListKNObserver') {
                
                instance.getObserverInterface().clearList();
                instance.getObserverInterface().displayProcessing(false);
                
            }
        }
    };

    /// <summary>
    /// Find records based on provided keyword (via observer keyword property) and page number.
    /// if observer is not available then finds records based on options.keyword, options.size, options.page and options.fill.
    /// </summary>
    instance.find = function (options) {
        
        if (instance.getObserverInterface() !== null && instance.getObserverInterface() !== undefined) {
            
            instance.getObserverInterface().displayProcessingActivity();
            instance.getCRUDProcessor().find({
                'uri': instance.URI,
                'contentType': options.contentType,
                'keyword': (options.keyword !== null && options.keyword !== undefined) ? options.keyword : instance.getObserverInterface().getKeyword(),
                'size': (options.size !== null && options.size !== undefined) ? options.size : (instance.getObserverInterface().getListSize() !== null && instance.getObserverInterface().getListSize() !== undefined) ? instance.getObserverInterface().getListSize() : 10,
                'page': options.page,
                'fill': options.fill
            });
            
        } else {
            
            instance.getCRUDProcessor().find({
                'uri': instance.URI,
                'contentType': options.contentType,
                'keyword': options.keyword,
                'size': options.size,
                'page': options.page,
                'fill': options.fill
            });
        }
    };
    
    /// <summary>Get component from record.</summary>
    instance.getRecordComponent = function (record) {
        
        var component;
        var recordOptions = Object.create(instance.newOptions());
        recordOptions.objectkey = record.getKey();

        if (instance.newOptions().subjectf !== null
                && instance.newOptions().subjectf !== undefined) {

            recordOptions.subject = Util().extractFieldValue(record[instance.newOptions().subjectf], "");
        }

        if (instance.newOptions().descriptionf !== null
                && instance.newOptions().descriptionf !== undefined) {

            recordOptions.description = Util().extractFieldValue(record[instance.newOptions().descriptionf], "");
        }

        if (instance.newOptions().urlf !== null
                && instance.newOptions().urlf !== undefined) {

            recordOptions.url = Util().extractFieldValue(record[instance.newOptions().urlf], "");
        }

        if (instance.newOptions().urltitlef !== null
                && instance.newOptions().urltitlef !== undefined) {

            recordOptions.urltitle = Util().extractFieldValue(record[instance.newOptions().urltitlef], "");
        }

        if (instance.newOptions().textviewhtmlf !== null
                && instance.newOptions().textviewhtmlf !== undefined) {

            recordOptions.html = Util().extractFieldValue(record[instance.newOptions().textviewhtmlf], "");
        }

        if (instance.newOptions().textviewcssf !== null
                && instance.newOptions().textviewcssf !== undefined) {

            recordOptions.css = Util().extractFieldValue(record[instance.newOptions().textviewcssf], "");
        }

        if (instance.newOptions().imagenamef !== null
                && instance.newOptions().imagenamef !== undefined) {

            recordOptions.imagename = Util().extractFieldValue(record[instance.newOptions().imagenamef], "");
        }

        if (instance.newOptions().imagepathf !== null
                && instance.newOptions().imagepathf !== undefined) {

            recordOptions.imagepath = Util().extractFieldValue(record[instance.newOptions().imagepathf], "");
        }

        if (instance.newOptions().imagetitlef !== null
                && instance.newOptions().imagetitlef !== undefined) {

            recordOptions.imagetitle = Util().extractFieldValue(record[instance.newOptions().imagetitlef], "");
        }
        
        if (instance.newOptions().imagewidthf !== null
                && instance.newOptions().imagewidthf !== undefined) {

            recordOptions.imagewidth = Util().extractFieldValue(record[instance.newOptions().imagewidthf], "");
        }

        if (instance.newOptions().imageheightf !== null
                && instance.newOptions().imageheightf !== undefined) {

            recordOptions.imageheight = Util().extractFieldValue(record[instance.newOptions().imageheightf], "");
        }

        if (instance.newOptions().imageviewhtmlf !== null
                && instance.newOptions().imageviewhtmlf !== undefined) {

            recordOptions.html = Util().extractFieldValue(record[instance.newOptions().imageviewhtmlf], "");
        }

        if (instance.newOptions().imageviewcssf !== null
                && instance.newOptions().imageviewcssf !== undefined) {

            recordOptions.css = Util().extractFieldValue(record[instance.newOptions().imageviewcssf], "");
        }

        if (instance.newOptions().videosrcf !== null
                && instance.newOptions().videosrcf !== undefined) {

            recordOptions.videosrc = Util().extractFieldValue(record[instance.newOptions().videosrcf], "");
        }

        if (instance.newOptions().crossoriginf !== null
                && instance.newOptions().crossoriginf !== undefined) {

            recordOptions.crossorigin = Util().extractFieldValue(record[instance.newOptions().crossoriginf], "");
        }

        if (instance.newOptions().posterf !== null
                && instance.newOptions().posterf !== undefined) {

            recordOptions.poster = Util().extractFieldValue(record[instance.newOptions().posterf], "");
        }

        if (instance.newOptions().preloadf !== null
                && instance.newOptions().preloadf !== undefined) {

            recordOptions.preload = Util().extractFieldValue(record[instance.newOptions().preloadf], "");
        }

        if (instance.newOptions().autoplayf !== null
                && instance.newOptions().autoplayf !== undefined) {

            recordOptions.autoplay = Util().extractFieldValue(record[instance.newOptions().autoplayf], "");
        }

        if (instance.newOptions().mediagroupf !== null
                && instance.newOptions().mediagroupf !== undefined) {

            recordOptions.mediagroup = Util().extractFieldValue(record[instance.newOptions().mediagroupf], "");
        }

        if (instance.newOptions().loopf !== null
                && instance.newOptions().loopf !== undefined) {

            recordOptions.loop = Util().extractFieldValue(record[instance.newOptions().loopf], "");
        }

        if (instance.newOptions().mutedf !== null
                && instance.newOptions().mutedf !== undefined) {

            recordOptions.muted = Util().extractFieldValue(record[instance.newOptions().mutedf], "");
        }

        if (instance.newOptions().controlsf !== null
                && instance.newOptions().controlsf !== undefined) {

            recordOptions.controls = Util().extractFieldValue(record[instance.newOptions().controlsf], instance.newOptions().controls);
        } else {

            if (instance.newOptions().controls !== null
                    && instance.newOptions().controls !== undefined) {

                recordOptions.controls = instance.newOptions().controls;
            }
        }

        if (instance.newOptions().videowidthf !== null
                && instance.newOptions().videowidthf !== undefined) {

            recordOptions.videowidth = Util().extractFieldValue(record[instance.newOptions().videowidthf], "");
        }

        if (instance.newOptions().videoheightf !== null
                && instance.newOptions().videoheightf !== undefined) {

            recordOptions.videoheight = Util().extractFieldValue(record[instance.newOptions().videoheightf], "");
        }

        if (instance.newOptions().avviewhtmlf !== null
                && instance.newOptions().avviewhtmlf !== undefined) {

            recordOptions.html = Util().extractFieldValue(record[instance.newOptions().avviewhtmlf], "");
        }

        if (instance.newOptions().avviewcssf !== null
                && instance.newOptions().avviewcssf !== undefined) {

            recordOptions.css = Util().extractFieldValue(record[instance.newOptions().avviewcssf], "");
        }

        if (recordOptions.subject.length > 0) {
            //viewType = "TextView";
            component = new TextView(recordOptions);
        }

        if (recordOptions.imagepath.length > 0) {
            //viewType = "ImageView";
            recordOptions.imagepath = (instance.newOptions().contextpath !== null && instance.newOptions().contextpath !== undefined) ? instance.newOptions().contextpath + recordOptions.imagepath : recordOptions.imagepath;
            component = new ImageView(recordOptions);
        }

        if (recordOptions.videosrc.length > 0) {
            //viewType = "AVView";
            recordOptions.videosrc = (instance.newOptions().contextpath !== null && instance.newOptions().contextpath !== undefined) ? instance.newOptions().contextpath + recordOptions.videosrc : recordOptions.videosrc;
            component = new AVView(recordOptions);
        }
        
        return component;
    };
    
    /// <summary>Present view with input values and html format.</summary>
    instance.presentView = function (options) {
        var htmlOutput = "";
        var records = [];

        if (options !== null && options !== undefined) {

            if (options.records !== null && options.records !== undefined) {

                records = options.records;

            } else {

                records = instance.getCRUDProcessor().getRecords();
            }
        } else {

            records = instance.getCRUDProcessor().getRecords();
        }

        for (var i = 0; i < records.length; i++) {
            
            htmlOutput += instance.getRecordComponent(records[i]).presentView();
        }
        
        return htmlOutput;
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
         * Observer find function definition.
         * 
         * @param {type} options
         * @returns {undefined}
         */
        instance.getObserverInterface().find = function (options) {
            instance.find(options);
        };
        
        /** 
         * Observer find function definition.
         * 
         * @param {type} options
         * @returns {undefined}
         */
        instance.getObserverInterface().presentView = function (options) {
            instance.presentView(options);
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
         * Observer find function definition.
         * 
         * @param {type} options
         * @returns {undefined}
         */
        instance.getObserverObject().find = function (options) {
            instance.find(options);
        };
        
        /** 
         * Observer find function definition.
         * 
         * @param {type} options
         * @returns {undefined}
         */
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

    /// <summary>Multiple records processing and presenting event subscription.</summary>
    instance.presentRecords = function (event, eventData) {

        if (eventData.data.callback !== null &&
                eventData.data.callback !== undefined) {

            eventData.data.callback(eventData.result);
        } else {

            if (instance.ContentNode !== null && instance.ContentNode !== undefined) {

                instance.ContentNode.innerHTML = instance.presentView();

            } else {

                if (instance.getObserverInterface() !== null
                        && instance.getObserverInterface() !== undefined) {

                    var records;

                    if (instance.getObserverInterface().getType() === "ListObserver" ||
                            instance.getObserverInterface().getType() === "ListKNObserver") {

                        if (instance.getObserverInterface().getListObject().getContentTypeObjectPrototype() !== null
                                && instance.getObserverInterface().getListObject().getContentTypeObjectPrototype() !== undefined) {

                            records = instance.getContentTypeObjects({'simpleObjects': eventData.result, 'contentPrototype': instance.getObserverInterface().getListObject().getContentTypeObjectPrototype()});
                        }

                    } else {

                        records = (instance.getObserverInterface().getContentTypeObject() !== null && instance.getObserverInterface().getContentTypeObject() !== undefined) ? instance.getContentTypeObjects({'simpleObjects': eventData.result}) : eventData.result;
                    }

                    instance.getObserverInterface().clearList();

                    for (var i = 0; i < records.length; i++) {
                        //var viewType = "TextView";
                        instance.getObserverInterface().newItem({'object': instance.getRecordComponent(records[i]) });
                    }
                    
                    instance.getObserverInterface().displaySuccessActivity();
                }
            }
        }

        $(window).trigger('view-direction-change');
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
        $(instance.getCRUDProcessor()).on('records.processor.CRUD.WindnTrees', eventsInstance.presentRecords);
        $(instance.getCRUDProcessor()).on('fail.processor.CRUD.WindnTrees', eventsInstance.presentFailRequest);
    };
    
    /// <summary>Subscribe CRUDProcessor events.</summary>
    instance.unSubscribeEvents = function (eventsInstance) {
        
        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;
        
        $(instance.getCRUDProcessor()).off('errors.processor.CRUD.WindnTrees', eventsInstance.presentErrors);
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
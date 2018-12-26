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
 * AVView presents video, image, subject and description values in provided html 
 * format and css styles. ImageView is capable of extracting information from a 
 * remote web service using GET / POST calls and display using observer or by 
 * directly writing into node's innerHTML content. In case of observer less 
 * scenario the type of content, content node and error node must be defined.
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
 * options.imagename
 * options.imagepath
 * options.imagetitle
 * 
 * options.videosrc
 * options.crossorigin
 * options.poster
 * options.preload
 * options.autoplay
 * options.mediagroup
 * options.loop
 * options.muted
 * options.controls
 * options.width
 * options.height
 * 
 * options.uri - defines the address (unique resource identifier).
 * options.observer - view's own observer instance.
 * 
 * @param {type} options 
 * @returns {undefined}
 */

/// <summary>
/// AVView presents video, image, subject and description values in provided html 
/// format and css styles. AVView is capable of extracting information from a remote 
/// web service using GET / POST calls and display using observer or by directly 
/// writing into node's innerHTML content. In observer less scenario the type of 
/// content content,content node contentNode and error node errorNode must be defined. 
/// In case of GET / POST response the corresponding content result fields for src, 
/// crossorigin, poster, preload, autoplay, mediagroup, loop, muted, controls, width and 
/// height must be mapped with options.videosrcf, options.crossoriginf, options.posterf, 
/// options.preloadf, options.autoplayf, options.mediagroupf, options.loopf, 
/// options.mutedf, options.controlsf, options.widthf and options.heightf fields. 
/// If a response field results in null or undefined value then this can be replaced 
/// by opted value, for example src field can be provided with a default value 
/// like options.videosrc and crossorigin can be opted with options.crossorigin. 
/// AVView extends from ImageView and for information about ImageView visit here.
/// </summary>
function AVView(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options});
    }
    
    //extends from text view
    var extOptions = Object.create(options);
    extOptions.instance = instance;
    extOptions.events = false;
    instance = ImageView(extOptions);
    
    /// <summary>Address of the resource.</summary>
    instance.VideoSrc = options.videosrc;
    
    /// <summary>How the element handles crossorigin requests.</summary>
    instance.CrossOrigin = options.crossorigin;
    
    /// <summary>Poster frame to show prior to video playback.</summary>
    instance.Poster = options.poster;
    
    /// <summary>Hints how much buffering the media resource will likely need.</summary>
    instance.Preload = options.preload;
    
    /// <summary>Hint that the media resource can be started automatically when the page is loaded.</summary>
    instance.Autoplay = options.autoplay; 
    
    /// <summary>Groups media elements together with an implicit MediaController</summary>
    instance.MediaGroup = options.mediagroup;
    
    /// <summary>Replay video in loop.</summary>
    instance.Loop = options.loop;
    
    /// <summary>Whether to mute the media resource by default.</summary>
    instance.Muted = options.muted;
    
    /// <summary>Show user agent controls.</summary>
    instance.Controls = options.controls;
    
    /// <summary>Horizontal dimension.</summary>
    instance.VideoWidth = options.videowidth;
    
    /// <summary>Vertical dimension.</summary>
    instance.VideoHeight = options.videoheight;
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "AVView";
    };
    
    /// <summary>Gets video source value.</summary>
    instance.getVideoSrc = function () {
        return instance.VideoSrc;
    };
    
    /// <summary>Sets video source value.</summary>
    instance.setVideoSrc = function (value) {
        instance.VideoSrc = value;
    };
    
    /// <summary>Gets crossorigin value.</summary>
    instance.getCrossOrigin = function () {
        return instance.CrossOrigin;
    };
    
    /// <summary>Sets crossorigin value.</summary>
    instance.setCrossOrigin = function (value) {
        instance.CrossOrigin = value;
    };
    
    /// <summary>Gets poster value.</summary>
    instance.getPoster = function () {
        return instance.Poster;
    };
    
    /// <summary>Sets poster value.</summary>
    instance.setPoster = function (value) {
        instance.Poster = value;
    };
    
    /// <summary>Gets preload value.</summary>
    instance.getPreload = function () {
        return instance.Preload;
    };
    
    /// <summary>Sets preload value.</summary>
    instance.setPreload = function (value) {
        instance.Preload = value;
    };
    
    /// <summary>Gets autoplay value.</summary>
    instance.getAutoplay = function () {
        return instance.Autoplay;
    };
    
    /// <summary>Sets autoplay value.</summary>
    instance.setAutoplay = function (value) {
        instance.Autoplay = value;
    };
    
    /// <summary>Gets mediagroup value.</summary>
    instance.getMediaGroup = function () {
        return instance.MediaGroup;
    };
    
    /// <summary>Sets mediagroup value.</summary>
    instance.setMediaGroup = function (value) {
        instance.MediaGroup = value;
    };
    
    /// <summary>Gets loop value.</summary>
    instance.getLoop = function () {
        return instance.Loop;
    };
    
    /// <summary>Sets loop value.</summary>
    instance.setLoop = function (value) {
        instance.Loop = value;
    };
    
    /// <summary>Gets muted value.</summary>
    instance.getMuted = function () {
        return instance.Muted;
    };
    
    /// <summary>Sets muted value.</summary>
    instance.setMuted = function (value) {
        instance.Muted = value;
    };
    
    /// <summary>Gets controls value.</summary>
    instance.getControls = function () {
        return instance.Controls;
    };
    
    /// <summary>Sets controls value.</summary>
    instance.setControls = function (value) {
        instance.Controls = value;
    };
    
    /// <summary>Gets width value.</summary>
    instance.getVideoWidth = function () {
        return instance.VideoWidth;
    };
    
    /// <summary>Sets width value.</summary>
    instance.setVideoWidth = function (value) {
        instance.VideoWidth = value;
    };
    
    /// <summary>Gets height value.</summary>
    instance.getVideoHeight = function () {
        return instance.VideoHeight;
    };
    
    /// <summary>Sets height value.</summary>
    instance.setVideoHeight = function (value) {
        instance.VideoHeight = value;
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

                        htmlFormat = "<a href='urlValue' title='urlTitleValue'><img alt='imageTitleValue' class='cssValue' src='imagePathValue' /></a><p>imageNameValue</p><p><video src='videoSrcValue' autoplay controls></video></p>";
                    }
                }
            }
        }

        htmlFormat = htmlFormat.replace(/cssValue/gi, Util().extractValue(instance.CSS, Util().extractValue(instance.newOptions().css, "")));
        htmlFormat = htmlFormat.replace(/urlValue/gi, Util().extractValue(instance.URL, Util().extractValue(instance.newOptions().url, "")));
        htmlFormat = htmlFormat.replace(/urlTitleValue/gi, Util().extractValue(instance.URLTitle, Util().extractValue(instance.newOptions().urltitle, "")));
        htmlFormat = htmlFormat.replace(/subjectValue/gi, Util().extractValue(instance.Subject, Util().extractValue(instance.newOptions().subject, "")));
        htmlFormat = htmlFormat.replace(/descriptionValue/gi, Util().extractValue(instance.Description, Util().extractValue(instance.newOptions().description, "")));
        
        htmlFormat = htmlFormat.replace(/imageNameValue/gi, Util().extractValue(instance.ImageName, Util().extractValue(instance.newOptions().imagename, "")));
        htmlFormat = htmlFormat.replace(/imagePathValue/gi, Util().extractValue(instance.ImagePath, Util().extractValue(instance.newOptions().imagepath, "")));
        htmlFormat = htmlFormat.replace(/imageTitleValue/gi, Util().extractValue(instance.ImageTitle, Util().extractValue(instance.newOptions().imagetitle, "")));
        
        htmlFormat = htmlFormat.replace(/imageWidthValue/gi, (instance.ImageWidth !== null && instance.ImageWidth !== undefined) ? (instance.ImageWidth > 0 ? "width='" + instance.ImageWidth + "'" : "") : Util().extractValue(instance.newOptions().imagewidth, ""));
        htmlFormat = htmlFormat.replace(/imageHeightValue/gi, (instance.ImageHeight !== null && instance.ImageHeight !== undefined) ? (instance.ImageHeight > 0 ? "height='" + instance.ImageHeight + "'" : "") : Util().extractValue(instance.newOptions().imageheight, ""));
        
        
        htmlFormat = htmlFormat.replace(/videoSrcValue/gi, (instance.VideoSrc !== null && instance.VideoSrc !== undefined) ? "src='" + instance.VideoSrc + "'" : Util().extractValue(instance.newOptions().videosrc, ""));
        htmlFormat = htmlFormat.replace(/crossOriginValue/gi, (instance.CrossOrigin !== null && instance.CrossOrigin !== undefined) ? "crossorigin='" + instance.CrossOrigin +"'" : Util().extractValue(instance.newOptions().crossorigin, ""));
        htmlFormat = htmlFormat.replace(/posterValue/gi, (instance.Poster !== null && instance.Poster !== undefined) ? "poster='" + instance.Poster + "'" : Util().extractValue(instance.newOptions().poster, ""));
        htmlFormat = htmlFormat.replace(/preloadValue/gi, Util().extractValue(instance.Preload, Util().extractValue(instance.newOptions().preload, "")));
        htmlFormat = htmlFormat.replace(/autoplayValue/gi, Util().extractValue(instance.Autoplay, Util().extractValue(instance.newOptions().autoplay, "")));
        htmlFormat = htmlFormat.replace(/mediaGroupValue/gi, (instance.MediaGroup !== null && instance.MediaGroup !== undefined) ? "mediagroup='" + instance.MediaGroup + "'" : Util().extractValue(instance.newOptions().mediagroup, ""));
        htmlFormat = htmlFormat.replace(/loopValue/gi, Util().extractValue(instance.Loop, Util().extractValue(instance.newOptions().loop, "")));
        htmlFormat = htmlFormat.replace(/mutedValue/gi, Util().extractValue(instance.Muted, Util().extractValue(instance.newOptions().muted, "")));
        htmlFormat = htmlFormat.replace(/controlsValue/gi, Util().extractValue(instance.Controls, Util().extractValue(instance.newOptions().controls, "")));
        htmlFormat = htmlFormat.replace(/videoWidthValue/gi, (instance.VideoWidth !== null && instance.VideoWidth !== undefined) ? (instance.VideoWidth > 0 ? "width='" + instance.VideoWidth + "'" : "") : Util().extractValue(instance.newOptions().videowidth, ""));
        htmlFormat = htmlFormat.replace(/videoHeightValue/gi, (instance.VideoHeight !== null && instance.VideoHeight !== undefined) ? (instance.VideoHeight > 0 ? "height='" + instance.VideoHeight + "'" : "") : Util().extractValue(instance.newOptions().videoheight, ""));

        return htmlFormat;
    };
    
    if (instance.getObserverInterface() !== null &&
            instance.getObserverInterface() !== undefined) {
        
        /**
     * Gets src value.
     * 
     * @returns {name}
     */
        instance.getObserverInterface().getVideoSrc = function () {
            return instance.getVideoSrc();
        };

        /**
         * Sets src value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setVideoSrc = function (value) {
            instance.setVideoSrc(value);
        };

        /**
         * Gets crossorigin value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getCrossOrigin = function () {
            return instance.getCrossOrigin();
        };

        /**
         * Sets crossorigin value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setCrossOrigin = function (value) {
            instance.setCrossOrigin(value);
        };

        /**
         * Gets poster value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getPoster = function () {
            return instance.getPoster();
        };

        /**
         * Sets poster value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setPoster = function (value) {
            instance.setPoster(value);
        };

        /**
         * Gets preload value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getPreload = function () {
            return instance.getPreload();
        };

        /**
         * Sets preload value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setPreload = function (value) {
            instance.setPreload(value);
        };

        /**
         * Gets autoplay value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getAutoplay = function () {
            return instance.getAutoplay();
        };

        /**
         * Sets autoplay value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setAutoplay = function (value) {
            instance.setAutoplay(value);
        };

        /**
         * Gets mediagroup value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getMediaGroup = function () {
            return instance.getMediaGroup();
        };

        /**
         * Sets mediagroup value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setMediaGroup = function (value) {
            instance.setMediaGroup(value);
        };

        /**
         * Gets loop value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getLoop = function () {
            return instance.getLoop();
        };

        /**
         * Sets loop value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setLoop = function (value) {
            instance.setLoop(value);
        };

        /**
         * Gets muted value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getMuted = function () {
            return instance.getMuted();
        };

        /**
         * Sets muted value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setMuted = function (value) {
            instance.setMuted(value);
        };

        /**
         * Gets controls value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getControls = function () {
            return instance.getControls();
        };

        /**
         * Sets controls value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setControls = function (value) {
            instance.setControls(value);
        };

        /**
         * Gets width value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getWidth = function () {
            return instance.getWidth();
        };

        /**
         * Sets width value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setWidth = function (value) {
            instance.setWidth(value);
        };

        /**
         * Gets height value.
         * 
         * @returns {name}
         */
        instance.getObserverInterface().getHeight = function () {
            return instance.getHeight();
        };

        /**
         * Sets height value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverInterface().setHeight = function (value) {
            instance.setHeight(value);
        };
        
        /**
        * Present view with input values and html format.
        * 
        * @param {type} options
        * @returns {String|TextView.present.htmlFormat}
        */
        instance.getObserverInterface().presentView = function (options) {
            instance.presentView(options);
        };
    }
    
    if (instance.getObserverObject() !== null &&
            instance.getObserverObject() !== undefined) {
        
        /**
     * Gets src value.
     * 
     * @returns {name}
     */
        instance.getObserverObject().getVideoSrc = function () {
            return instance.getVideoSrc();
        };

        /**
         * Sets src value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setVideoSrc = function (value) {
            instance.setVideoSrc(value);
        };

        /**
         * Gets crossorigin value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getCrossOrigin = function () {
            return instance.getCrossOrigin();
        };

        /**
         * Sets crossorigin value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setCrossOrigin = function (value) {
            instance.setCrossOrigin(value);
        };

        /**
         * Gets poster value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getPoster = function () {
            return instance.getPoster();
        };

        /**
         * Sets poster value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setPoster = function (value) {
            instance.setPoster(value);
        };

        /**
         * Gets preload value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getPreload = function () {
            return instance.getPreload();
        };

        /**
         * Sets preload value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setPreload = function (value) {
            instance.setPreload(value);
        };

        /**
         * Gets autoplay value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getAutoplay = function () {
            return instance.getAutoplay();
        };

        /**
         * Sets autoplay value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setAutoplay = function (value) {
            instance.setAutoplay(value);
        };

        /**
         * Gets mediagroup value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getMediaGroup = function () {
            return instance.getMediaGroup();
        };

        /**
         * Sets mediagroup value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setMediaGroup = function (value) {
            instance.setMediaGroup(value);
        };

        /**
         * Gets loop value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getLoop = function () {
            return instance.getLoop();
        };

        /**
         * Sets loop value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setLoop = function (value) {
            instance.setLoop(value);
        };

        /**
         * Gets muted value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getMuted = function () {
            return instance.getMuted();
        };

        /**
         * Sets muted value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setMuted = function (value) {
            instance.setMuted(value);
        };

        /**
         * Gets controls value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getControls = function () {
            return instance.getControls();
        };

        /**
         * Sets controls value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setControls = function (value) {
            instance.setControls(value);
        };

        /**
         * Gets width value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getWidth = function () {
            return instance.getWidth();
        };

        /**
         * Sets width value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setWidth = function (value) {
            instance.setWidth(value);
        };

        /**
         * Gets height value.
         * 
         * @returns {name}
         */
        instance.getObserverObject().getHeight = function () {
            return instance.getHeight();
        };

        /**
         * Sets height value.
         * 
         * @param {type} value
         * @returns {undefined}
         */
        instance.getObserverObject().setHeight = function (value) {
            instance.setHeight(value);
        };
        
        /**
        * Present view with input values and html format.
        * 
        * @param {type} options
        * @returns {String|TextView.present.htmlFormat}
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

            instance.ImageName = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().imagenamef, "imageName")], instance.newOptions().imagename);
            instance.ImageTitle = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().imagetitlef, "imageTitle")], instance.newOptions().imagetitle);
            instance.ImagePath = ((instance.newOptions().contextpath !== null && instance.newOptions().contextpath !== undefined) ? instance.newOptions().contextpath : "") + Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().imagepathf, "imagePath")], instance.newOptions().imagepath);
            
            instance.ImageWidth = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().imagewidthf, "imageWidth")], instance.newOptions().imagewidth);
            instance.ImageHeight = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().imageheightf, "imageHeight")], instance.newOptions().imageheight);
            
            instance.VideoSrc = ((instance.newOptions().contextpath !== null && instance.newOptions().contextpath !== undefined) ? instance.newOptions().contextpath : "") + Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().videosrcf, "videoSrc")], instance.newOptions().videosrc);
            
            instance.CrossOrigin = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().crossoriginf, "crossOrigin")], instance.newOptions().crossorigin);
            instance.Poster = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().posterf, "poster")], instance.newOptions().poster);
            instance.Preload = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().preloadf, "preload")], instance.newOptions().preload);
            instance.Autoplay = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().autoplayf, "autoplay")], instance.newOptions().autoplay);
            instance.MediaGroup = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().mediagroupf, "mediaGroup")], instance.newOptions().mediagroup);
            instance.Loop = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().loopf, "loop")], instance.newOptions().loop);
            instance.Muted = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().mutedf, "muted")], instance.newOptions().muted);
            instance.Controls = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().controlsf, "controls")], instance.newOptions().controls);
            
            instance.VideoWidth = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().videowidthf, "videoWidth")], instance.newOptions().videowidth);
            instance.VideoHeight = Util().extractFieldValue(eventData.result[Util().extractValue(instance.newOptions().videoheightf, "videoHeight")], instance.newOptions().videoheight);

            if (instance.ContentNode !== null && instance.ContentNode !== undefined) {

                instance.ContentNode.innerHTML = instance.presentView();

            } else {
                
                if (instance.getObserverInterface().getType() === "ListObserver" ||
                        instance.getObserverInterface().getType() === "ListKNObserver") {

                    instance.getObserverInterface().displaySuccessActivity();
                    instance.getObserverInterface().updateItem({'object': instance});

                } else if (instance.getObserverInterface() !== null
                        && instance.getObserverInterface() !== undefined) {

                    if (instance.getObserverInterface().getType() === "ObjectObserver" ||
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
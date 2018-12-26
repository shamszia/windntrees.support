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

/// <summary>InstanceExtender extends instances with common and useful functions.</summary>
function InstanceExtender(options) {
    var instance = this;
    
    /// <summary>Extends instance with new instance creation functionality.</summary>
    instance.extendNewInstance = function (extoptions) {
        var instance = extoptions.instance;

        /**
         * Integrates new instance functionality with provided instance.
         * 
         * @param {type} options 
         * @returns {Function}
         */
        instance.newInstance = function (options) {
            
            var instanceOptions = (options !== null && options !== undefined) ? options : instance.newOptions();
            instanceOptions.instance = undefined;
            
            if (extoptions.newparameter !== null && extoptions.newparameter !== undefined) {

                if (Array.isArray(extoptions.newparameter)) {

                    var newInstances = [];
                    for (var i = 0; i < extoptions.newparameter.length; i++) {

                        if (instanceOptions.observer !== null && instanceOptions.observer !== undefined) {
                            instanceOptions.observer = extoptions.newparameter.newInstance();
                        }
                        
                        newInstances[i] = extoptions.newparameter[i].newInstance();
                    }

                    return new (Object.getPrototypeOf(instance)).constructor(newInstances);
                } else {
                    
                    if (instanceOptions.observer !== null && instanceOptions.observer !== undefined) {
                        
                        instanceOptions.observer = extoptions.newparameter.newInstance();
                    }
                    
                    instanceOptions.instance = undefined;
                    return new (Object.getPrototypeOf(instance)).constructor(instanceOptions);
                }
            }
            return new (Object.getPrototypeOf(instance)).constructor(instanceOptions);
        };
        
        /**
         * Returns object instantiation options.
         * 
         * @returns {type.options}
         */
        instance.newOptions = function () {
            
            return extoptions.options;
        };
        
        return Object.create(instance);
    };
    
    /// <summary>Extends instance with field and related setter and getter functions.</summary>
    instance.extendField = function (options) {
        var instance = options.instance;

        if (options.field !== null && options.field !== undefined) {
            if (options.value !== null && options.value !== undefined) {
                //instance[options.field] = (typeof (options.value) === 'function') ? options.value() : options.value;
                instance[options.field] = options.value;
            }
            
            /**
             * Field setter function.
             * 
             * @param {type} object
             * @returns {undefined}
             */
            instance["set" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)] = function (object) {
                if (typeof (instance[options.field]) === 'function') {
                    instance[options.field](object);

                } else {
                    instance[options.field] = object;
                }
            };

            /**
             * Field getter function.
             * 
             * @returns {InstanceExtender|InstanceExtender.instance}
             */
            instance["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)] = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return instance[options.field]();

                } else {
                    return instance[options.field];
                }
            };

            /**
             * Observable getter function.
             * 
             * @returns {InstanceExtender|InstanceExtender.instance}
             */
            instance["getObservable" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)] = function () {
                return instance[options.field];
            };

            /**
             * Gets field stringified object.
             * 
             * @returns {String}
             */
            instance["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1) + "StringifiedJSONObject"] = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return JSON.stringify(instance[options.field]());

                } else {
                    return JSON.stringify(instance[options.field]);
                }
            };

            /**
             * Gets field JSON object.
             * 
             * @returns {Array|Object}
             */
            instance["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1) + "JSONObject"] = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return JSON.parse(JSON.stringify(instance[options.field]()));

                } else {
                    return JSON.parse(JSON.stringify(instance[options.field]));
                }
            };
        }
        
        return instance;
    };
    
    /// <summary>Extends instance with field observer interface and related setter and getter functions.</summary>
    instance.extendFieldObserver = function (options) {
        var instance = options.instance;
        
        var observer = options.observer;

        if (options.field !== null && options.field !== undefined) {
            
            /**
             * Field setter function.
             * 
             * @param {type} object
             * @returns {undefined}
             */
            instance["set" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)] = function (object) {
                observer["set" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)](object);
            };

            /**
             * Field getter function.
             * 
             * @returns {InstanceExtender|InstanceExtender.instance}
             */
            instance["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)] = function () {
                return observer["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)]();
            };

            /**
             * Observable getter function.
             * 
             * @returns {InstanceExtender|InstanceExtender.instance}
             */
            instance["getObservable" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)] = function () {
                return observer["getObservable" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1)]();
            };

            /**
             * Gets field stringified object.
             * 
             * @returns {String}
             */
            instance["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1) + "StringifiedJSONObject"] = function () {
                return observer["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1) + "StringifiedJSONObject"]();
            };

            /**
             * Gets field JSON object.
             * 
             * @returns {Array|Object}
             */
            instance["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1) + "JSONObject"] = function () {
                return observer["get" + options.field.substr(0, 1).toUpperCase() + options.field.substr(1, options.field.length - 1) + "JSONObject"]();
            };
        }
        
        return instance;
    };
    
    /// <summary>Extends instance with object interface.</summary>
    instance.extendObjectInterface = function (options) {
        var instance = options.instance;

        if (options.field !== null && options.field !== undefined) {

            /**
             * Sets field with object.
             * 
             * @param {type} object
             * @returns {undefined}
             */
            instance.setObject = function (object) {
                if (typeof (instance[options.field]) === 'function') {
                    instance[options.field](object);

                } else {
                    instance[options.field] = object;
                }
            };

            /**
             * Gets field object.
             * 
             * @returns {type.instance|InstanceExtender.extendObjectInterface.instance}
             */
            instance.getObject = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return instance[options.field]();

                } else {
                    return instance[options.field];
                }
            };
            
            /**
             * Gets field observer object.
             * 
             * @returns {type.instance|InstanceExtender.extendObjectInterface.instance}
             */
            instance.getObserverObject = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return instance[options.field]();

                } else {
                    return instance[options.field];
                }
            };

            /**
             * Gets observable field.
             * 
             * @returns {type.instance|InstanceExtender.extendObjectInterface.instance}
             */
            instance.getObservableObject = function () {
                return instance[options.field];
            };

            /**
             * Gets stringified field object.
             * 
             * @returns {String}
             */
            instance.getStringifiedObject = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return JSON.stringify(instance[options.field]());

                } else {
                    return JSON.stringify(instance[options.field]);
                }
            };

            /**
             * Gets JSON field object.
             * 
             * @returns {Array|Object}
             */
            instance.getJSONObject = function () {
                if (typeof (instance[options.field]) === 'function') {
                    return JSON.parse(JSON.stringify(instance[options.field]()));

                } else {
                    return JSON.parse(JSON.stringify(instance[options.field]));
                }
            };
        }
        
        return Object.create(instance);
    };
    
    /// <summary>Extends observer with observer interface.</summary>
    instance.extendObserverInterface = function (options) {
        var instance = options.instance;
        
        var observer = options.observer;

        if (instance !== null && instance !== undefined) {

            if (observer !== null && observer !== undefined) {
                
                /**
                 * Sets object using observer interface.
                 * 
                 * @param {type} object
                 * @returns {undefined}
                 */
                instance.setObject = function (object) {
                    observer.setObject(object);
                };

                /**
                 * Gets object using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getObject = function () {
                    return observer.getObject();
                };

                /**
                 * Gets object using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getObserverObject = function () {
                    return observer.getObject();
                };

                /**
                 * Gets observable object using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getObservableObject = function () {
                    return observer.getObservableObject();
                };

                /**
                 * Gets stringified JSON object using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getStringifiedObject = function () {
                    return observer.getStringifiedObject();
                };

                /**
                 * Gets JSON object using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getJSONObject = function () {
                    return observer.getJSONObject();
                };
                
                /**
                 * Gets concrete observer type using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getObserverType = function () {
                    return observer.getType();
                };
                
                /**
                 * Gets concrete observer using observer interface.
                 * 
                 * @returns {type.observer|InstanceExtender.extendObserverInterface.observer}
                 */
                instance.getObserver = function () {
                    return observer;
                };
            }
        }
        
        return Object.create(instance);
    };
    
    /// <summary>Extends instance with content object type extraction functions.</summary>
    instance.extendContentTypeObject = function (options) {
        var instance = options.instance;
        
        //type information
        instance.ContentType = options.contentType;

        /**
         * Gets content object.
         * 
         * @returns {instance.ContentType|.options.instance.ContentType}
         */
        instance.getContentTypeObject = function () {
            return instance.ContentType;
        };

        /**
         * Gets content object prototype.
         * 
         * @returns {Object}
         */
        instance.getContentTypeObjectPrototype = function () {
            if (instance.ContentType !== null && instance.ContentType !== undefined) {
                return Object.getPrototypeOf(instance.ContentType);
            }
            return null;
        };

        return Object.create(instance);
    };
    
    /// <summary>Extends instance with content observer type extraction functions.</summary>
    instance.extendContentObserver = function (options) {
        var instance = options.instance;
        
        var observer = options.observer;

        if (instance !== null && instance !== undefined) {
            if (observer !== null && observer !== undefined) {
                
                /**
                 * Gets content object using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getContentTypeObject = function () {
                    return observer.getContentTypeObject();
                };
                
                /**
                 * Gets content object prototype using observer interface.
                 * 
                 * @returns {unresolved}
                 */
                instance.getContentTypeObjectPrototype = function () {
                    return observer.getContentTypeObjectPrototype();
                };
            }
        }
        
        return Object.create(instance);
    };
}

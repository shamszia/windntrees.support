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

/// <summary>Utility methods for value extractions.</summary>
function Util () {
    var instance = Object.create({});
    
    /// <summary>Choose between object or a default value.</summary>
    instance.extractValue = function (objectValue, defaultValue) {
        
        if (objectValue !== null && objectValue !== undefined) {
            
            return objectValue;
        }
        
        return defaultValue;
    };
    
    /// <summary>Extracts field value with support for observable fields and a default value in case of failure.</summary>
    instance.extractFieldValue = function (fieldValue, defaultValue) {
        
        var extractedValue;
        
        if (fieldValue !== null && fieldValue !== undefined) {

            if (typeof (fieldValue) === "function") {

                extractedValue = fieldValue();

                if (extractedValue === null || extractedValue === undefined) {

                    if (defaultValue !== null && defaultValue !== undefined) {

                        return defaultValue;
                    }
                }
                return extractedValue;
            }
            
            return fieldValue;

        } else {
            
            return defaultValue;
        }
    };
    
    /// <summary>Evaluates flex (html or functions) object items.</summary>
    instance.getFlexOutput = function (options) {

        var output;

        if (options !== null && options !== undefined) {

            if (options.flexobject !== null && options.flexobject !== undefined) {

                var flexitems = options.flexobject.items;
                if (flexitems !== null && flexitems !== undefined) {

                    if (flexitems.length === 1) {

                        //output object already produced.
                        return flexitems[0];

                    } else if (flexitems.length > 10) {

                        var key = flexitems[0];
                        var evaluator = flexitems[1];
                        var result = flexitems[2];
                        var content = flexitems[3];

                        if (result === "object-output"
                            || result === "function-output") {

                            //if result is object-output or function-output then it 
                            //is considered that the evaluator is a function construct.
                            //
                            //
                            //if content is not object then take string content items 
                            //as input with key value

                            var typeFunction = evaluator;

                            var options1 = Object.create(options);
                            options1.key = key;
                            options1.items = Array.splice(0, 10);

                            if (result === "object-output") {

                                output = new typeFunction.constructor(options1);

                            } else if (result === "function-output") {

                                output = typeFunction.constructor(options1);
                            }

                        } else {

                            if (content === "object") {

                                //content: object
                                //items are list of objects that are to be evaluated in
                                //a string / text / html view
                                //
                                //
                                //and its not object-output or function-output

                                output = "";
                                for (var i = 10; i < flexitems.length; i++) {

                                    var options1 = Object.create(options);
                                    options1.flexobject = flexitems[i];

                                    output += Util().extractValue(instance.getFlexOutput(options1), "");
                                }

                            } else {

                                //content: html, text, string

                                if (result === "html"
                                    || result === "string"
                                    || result === "text") {

                                    //get html format
                                    output = evaluator;

                                    //replace key value
                                    var keyValue = new RegExp('a0_', 'gi');
                                    output = output.replace(keyValue, Util().extractValue(flexitems[0], ""));

                                    var pathValue = new RegExp('cp_', 'gi');
                                    output = output.replace(pathValue, Util().extractValue(options.contextpath, ""));

                                    //replace remaining items
                                    for (var i = 10; i < flexitems.length; i++) {

                                        var flexitem = flexitems[i];
                                        var expValue = new RegExp('a' + i + '_', 'gi');

                                        output = output.replace(expValue, Util().extractValue(flexitem, ""));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return ((output !== null && output !== undefined) ? output : "");
    };
    
    return instance;
}

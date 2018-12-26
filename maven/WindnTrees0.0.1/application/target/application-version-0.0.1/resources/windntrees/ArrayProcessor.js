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
/// Provides array processing functionality.
/// </summary>
function ArrayProcessor(options) {
    var instance = this;
    
    if (options.field !== null && options.field !== undefined) {
        if (options.value !== null && options.value !== undefined) {
            
            instance[options.field] = options.value;
        }
    } else {
        
        instance.Objects = options.objects;
    }
    
    /// <summary>Gets the type of function construct.</summary>
    instance.getType = function () {
        return "ArrayProcessor";
    };
    
    /// <summary>Gets array of objects.</summary>
    instance.getObjects = function () {
        
        if (options.field !== null && options.field !== undefined) {
            
            return instance[options.field];
        }
        return instance.Objects;
    };
    
    /// <summary>Gets object from list based on key value.</summary>
    instance.get = function (key) {

        if (key !== null && key !== undefined) {

            if (instance.getObjects() !== null && instance.getObjects() !== undefined) {
                
                for (var i = 0; i < instance.getObjects().length; i++) {
                    if (instance.getObjects()[i].key === key) {
                        return instance.getObjects()[i].value;
                    }
                }
            }
        }
        return null;
    };
    
    /// <summary>Add object in objects repository. If object exists its value will be replaced by provided object.</summary>
    instance.add = function (object) {
        
        if (object !== null && object !== undefined) {
            
            if (instance.getObjects() !== null && instance.getObjects() !== undefined) {
                
                for (var i = 0; i < instance.getObjects().length; i++) {
                    var item = instance.getObjects()[i];
                    if (item.getKey() === object.getKey()) {
                        item.setValue(object.getValue());
                        return;
                    }
                }
                instance.getObjects().push(object);
            }
        }
    };
    
    /// <summary>Removes object from objects repository.</summary>
    instance.remove = function (object) {
        
        if (object !== null && object !== undefined) {
            
            if (instance.getObjects() !== null && instance.getObjects() !== undefined) {
                
                for (var i = 0; i < instance.getObjects().length; i++) {
                    var item = instance.getObjects()[i];
                    if (item.getKey() === object.getKey()) {
                        instance.getObjects().splice(i, 1);
                        return;
                    }
                }
            }
        }
    };
    
    /// <summary>In instance extension scenario following checks whether instance is extended with array processor.</summary>
    instance.hasArrayProcessor = function () {
        return true;
    };
};
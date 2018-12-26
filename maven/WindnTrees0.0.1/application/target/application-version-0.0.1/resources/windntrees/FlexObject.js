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
/// FlexObject represents information or typed objects in collection of items in 
/// a type less manner. FlexObject in normal format is a collection (or array) 
/// of key, evaluator, result, content information and content objects composed 
/// in a format as explained in following sections. 
/// FlexObject in output format is composed of only one item with already processed result.
/// In normal format first 10 FlexObject items in array or collection defines 
/// configurational and or content evaluation information while remaining items 
/// are content objects that are processed either in a form view or yields in 
/// a function output.
/// </summary>
function FlexObject(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options});
    }
    
    instance.items = options.items;
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
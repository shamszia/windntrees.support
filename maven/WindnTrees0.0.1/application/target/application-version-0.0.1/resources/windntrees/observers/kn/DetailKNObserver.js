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
/// Record detail observer that stores record and its detail list of objects.
/// </summary>
function DetailKNObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance , 'options': options});
    }


    /// <summary>Record object.</summary>
    instance.Record = ko.observable(options.record);
    
    /// <summary>Referential (or detail) record object.</summary>
    instance.Detail = ko.observable(options.detail);
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "DetailKNObserver";
    };
    
    /// <summary>Gets a new instance.</summary>
    instance.newInstance = function() {
        return new (Object.getPrototypeOf(instance)).constructor(options);
    };

    /// <summary>Sets record and makes it observable.</summary>
    instance.setRecord = function (record) {
        instance.Record(record);
    };

    /// <summary>Gets record.</summary>
    instance.getRecord = function () {
        return instance.Record();
    };

    /// <summary>Gets observable record.</summary>
    instance.getObservableRecord = function () {
        return instance.Record;
    };

    /// <summary>Sets detail and makes it observable.</summary>
    instance.setDetail = function (detail) {
        instance.Detail(detail);
    };

    /// <summary>Gets detail.</summary>
    instance.getDetail = function () {
        return instance.Detail();
    };

    /// <summary>Gets observable detail.</summary>
    instance.getObservableDetail = function () {
        return instance.Detail;
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
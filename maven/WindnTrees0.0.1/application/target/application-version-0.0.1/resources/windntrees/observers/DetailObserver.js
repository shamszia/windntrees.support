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
/// Master detail records observer that stores record and related detail record objects.
/// </summary>
function DetailObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance , 'options': options});
    }
    
    if (options.observer !== null && options.observer !== undefined) {

        if (typeof (options.observer) === "string") {

            //select and initializes observer.
            if (options.observer === "kn") {
                
                instance.Observer = new DetailKNObserver(options);
            }

        } else {

            //if observer is provided it is selected.
            instance.Observer = options.observer;
        }
    } else {
        
        //if observer is not provided a default observer is initialized and selected.
        instance.Observer = new DetailKNObserver(options);
    }
    
    /// <summary>Gets observer object.</summary>
    instance.getObserver = function () {
        return instance.Observer;
    };
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getObserverType = function () {
        return instance.getObserver().getType();
    };
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "DetailObserver";
    };
    
    /// <summary>Gets a new instance.</summary>
    instance.newInstance = function() {
        return new (Object.getPrototypeOf(instance)).constructor(instance.getObserver().newInstance());
    };

    /// <summary>Sets record and makes it observable.</summary>
    instance.setRecord = function (record) {
        instance.getObserver().setRecord(record);
    };

    /// <summary>Gets record.</summary>
    instance.getRecord = function () {
        return instance.getObserver().getRecord();
    };

    /// <summary>Gets observable record.</summary>
    instance.getObservableRecord = function () {
        return instance.getObserver().getObservableRecord();
    };

    /// <summary>Sets detail and makes it observable.</summary>
    instance.setDetail = function (detail) {
        instance.getObserver().setDetail(detail);
    };

    /// <summary>Gets detail.</summary>
    instance.getDetail = function () {
        return instance.getObserver().getDetail();
    };

    /// <summary>Gets observable detail.</summary>
    instance.getObservableDetail = function () {
        return instance.getObserver().getObservableDetail();
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
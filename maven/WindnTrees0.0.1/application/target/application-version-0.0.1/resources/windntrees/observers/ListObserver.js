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
/// ListObserver provides concrete observer independent list, list objects and their 
/// targets synchronization functionality with related user interface interactive 
/// capabilities. 
/// ListObserver extends from ActivityObserver and for information about activity 
/// functions refer here.
/// </summary>
function ListObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.observer !== null && options.observer !== undefined) {

        if (typeof (options.observer) === "string") {

            //select and initializes observer.
            if (options.observer === "kn") {
                
                instance.Observer = new ListKNObserver(options);
            }

        } else {

            //if observer is provided it is selected.
            instance.Observer = options.observer;
        }
    } else {
        
        //if observer is not provided a default observer is initialized and selected.
        instance.Observer = new ListKNObserver(options);
    }
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'newparameter': instance.Observer, 'options': options});
    }
    
    instance = extender.extendFieldObserver({ 'instance': instance,
        'field': 'List',
        'observer': instance.Observer });
    
    instance = extender.extendObserverInterface({'instance': instance,
        'observer': instance.Observer });
    
    //extend from activity observer
    instance = ActivityObserver({'instance': instance, 'observer': instance.Observer });
    
    /// <summary>Gets the observer object.</summary>
    instance.getObserver = function () {
        return instance.Observer;
    };
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getObserverType = function () {
        return instance.getObserver().getType();
    };
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "ListObserver";
    };

    /// <summary>Gets entity object.</summary>
    instance.getListObject = function () {
        return instance.getObserver().getListObject();
    };

    /// <summary>Gets entity object prototype.</summary>
    instance.getListObjectPrototype = function () {
        return instance.getObserver().getListObjectPrototype();
    };

    /// <summary>Gets indexed stringified JSON object.</summary>
    instance.getIndexedStringifiedObject = function (index) {
        return instance.getObserver().getIndexedStringifiedObject(index);
    };

    /// <summary>Gets indexed JSON object.</summary>
    instance.getIndexedJSONObject = function (index) {
        return instance.getObserver().getIndexedJSONObject(index);
    };

    /// <summary>Empty/Clears the list.</summary>
    instance.clearList = function (readyStatus) {
        instance.getObserver().clearList(readyStatus);
    };

    /// <summary>Fill list records.</summary>
    instance.fillList = function (data, readyStatus) {
        instance.getObserver().fillList(data, readyStatus);
    };

    /// <summary>Gets list ready status.</summary>
    instance.isListReady = function () {

        return instance.getObserver().isListReady();
    };

    /// <summary>Sets list fill status to ready.</summary>
    instance.setListReady = function (status) {

        instance.getObserver().setListReady(status);
    };

    /// <summary>Gets list item.</summary>
    instance.getItem = function (key) {
        return instance.getObserver().getItem(key);
    };

    /// <summary>Add new object item in list.</summary>
    instance.newItem = function (data) {
        instance.getObserver().newItem(data);
    };

    /// <summary>Update existing list object.</summary>
    instance.updateItem = function (listObject) {
        instance.getObserver().updateItem(listObject);
    };

    /// <summary>Removes list object.</summary>
    instance.removeItem = function (listObject) {
        instance.getObserver().removeItem(listObject);
    };

    /// <summary>Updates list by adding, updating and removing list objects.</summary>
    instance.update = function (data) {
        instance.getObserver().update(data);
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
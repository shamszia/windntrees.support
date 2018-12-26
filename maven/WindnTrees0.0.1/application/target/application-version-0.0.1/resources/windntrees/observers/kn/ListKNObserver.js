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
/// ListObserver provides list, list objects and their targets synchronization 
/// functionality with related user interface interactive capabilities.
/// ListKNObserver extends from ActivityKNObserver and for information about 
/// activity functions refer here.
/// </summary>
function ListKNObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options });
    }
    
    /// <summary>List observer object</summary>
    instance.ListObject = options.object;
    
    instance = extender.extendField({'instance': instance,
        'field': 'List',
        'value': (options.list !== null && options.list !== undefined) ? ko.observableArray(options.list) : ko.observableArray([]) });
    instance = extender.extendObjectInterface({'instance': instance,
        'field': 'List' });

    /// <summary>List ready status.</summary>
    instance.ListReady = ko.observable(false);

    //if not extending from existing instance, this will ensure that instance is provided.
    var activityOptions = Object.create(options);
    activityOptions.instance = instance;
    //extends from ActivityKNObserver
    instance = ActivityKNObserver(activityOptions);
    
    /// <summary>Gets type of function construct.</summary>
    instance.getType = function () {
        return "ListKNObserver";
    };

    /// <summary>Gets list object.</summary>
    instance.getListObject = function () {
        return instance.ListObject;
    };

    /// <summary>Gets list object prototype.</summary>
    instance.getListObjectPrototype = function () {
        if (instance.ListObject !== null && instance.ListObject !== undefined) {
            return Object.getPrototypeOf(instance.ListObject);
        }
        return null;        
    };

    /// <summary>Gets indexed stringified JSON object.</summary>
    instance.getIndexedStringifiedObject = function (index) {
        if (index !== null && index !== undefined) {
            if (index >= 0) {
                return ko.toJSON(instance.List[index]);
            }
        }
        return null;
    };

    /// <summary>Gets indexed JSON object.</summary>
    instance.getIndexedJSONObject = function (index) {
        return JSON.parse(instance.getIndexedStringifiedObject(index));
    };

    /// <summary>Empty/Clears the list.</summary>
    instance.clearList = function (readyStatus) {
        instance.ListReady(readyStatus);
        instance.List([]);
    };

    /// <summary>Fill list records.</summary>
    instance.fillList = function (data,readyStatus) {

        if (data.objects !== null && data.objects !== undefined) {
            instance.List(data.objects);
            instance.ListReady(readyStatus);
        }
    };

    /// <summary>Gets status if observable item object exists.</summary>
    instance.isListReady = function () {

        return instance.ListReady();
    };
    
    /// <summary>Sets list fill status to ready.</summary>
    instance.setListReady = function (status) {

        instance.ListReady(status);
    };

    /// <summary>Gets list item based on key value.</summary>
    instance.getItem = function (key) {

        for (var i = 0; i < instance.List().length; i++) {

            var item = instance.List()[i];

            if (item.getKey() !== null && item.getKey() !== undefined) {

                if (item.getKey() === key) {

                    return item;
                }
            }
        }
        return null;
    };

    /// <summary>Add new object item in list.</summary>
    instance.newItem = function (data) {
        if (data.object !== null && data.object !== undefined) {
            var newObject = data.object;

            if (instance.ListObject !== null && instance.ListObject !== undefined) {

                if (newObject.getKey !== null && newObject.getKey !== undefined) {

                    newObject = instance.ListObject.newInstance({ key: newObject.getKey() });

                } else {

                    newObject = instance.ListObject.newInstance();
                }

                newObject.setObject(data.object);
            }
            
            if (data.order !== null && data.order !== undefined) {

                if (data.order === 'first') {
                    var oldLists = instance.List();
                    instance.List([]);
                    instance.List.push(newObject);
                    for (var i = 0; i < oldLists.length; i++) {
                        instance.List.push(oldLists[i]);
                    }
                } else {
                    instance.List.push(newObject);
                }
            } else {
                instance.List.push(newObject);
            }
        }
    };

    /// <summary>Update existing list object.</summary>
    instance.updateItem = function (data) {
        if (data !== null && data !== undefined) {
            
            var newObject = data.object;
            if (instance.ListObject !== null && instance.ListObject !== undefined) {
                
                newObject = instance.ListObject.newInstance();
                newObject.setObject(data.object);
            }
            
            for (var i = 0; i < instance.List().length; i++) {
                var item = instance.List()[i];

                if (newObject.getType() !== null && newObject.getType() !== undefined) {
                    if (newObject.getObject() === item.getObject()) {
                        instance.List.replace(item, newObject);
                    }
                } else {
                    if (newObject.getKey() !== undefined && item.getKey() !== undefined) {
                        if (item.getKey() === newObject.getKey()) {
                            instance.List.replace(item, newObject);
                        }
                    }
                }
            }
        }
    };

    /// <summary>Removes list object.</summary>
    instance.removeItem = function (data) {
        if (data !== null && data !== undefined) {
            
            var newObject = data.object;
            if (instance.ListObject !== null && instance.ListObject !== undefined) {
                
                newObject = instance.ListObject.newInstance();
                newObject.setObject(data.object);
            }
            
            for (var i = 0; i < instance.List().length; i++) {
                var item = instance.List()[i];
                
                if (newObject.getType() !== null && newObject.getType() !== undefined) {
                    if (newObject.getObject() === item.getObject()) {
                        instance.List.remove(item);
                    }
                } else {
                    if (newObject.getKey() !== undefined && item.getKey() !== undefined) {
                        if (item.getKey() === newObject.getKey()) {
                            instance.List.remove(item);
                        }
                    }
                }
            }
        }
    };

    /// <summary>Updates list by adding, updating and removing list objects.</summary>
    instance.update = function (data) {
        if (data.action === undefined) {
            if (data.placement !== null && data.placement !== undefined) {
                instance.newItem({
                    'object': data.object,
                    'order': data.placement
                });
            } else {
                instance.newItem({
                    'object': data.object,
                    'order': 'first'
                });
            }
        } else {
            if (data.action === 'create') {
                if (data.placement !== null && data.placement !== undefined) {
                    instance.newItem({
                        'object': data.object,
                        'order': data.placement
                    });
                } else {
                    instance.newItem({
                        'object': data.object,
                        'order': 'first'
                    });
                }
            } else if (data.action === 'update') {
                instance.updateItem(data.object);
            } else if (data.action === 'delete') {
                instance.removeItem(data.object);
            }
        }
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
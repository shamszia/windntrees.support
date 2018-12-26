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
/// CRUDSList provides different CRUDS or search sources for a view that might 
/// takes list of reference objects and selects between them based on user interaction 
/// in observer independent way. This allows to share same or different views 
/// between reference objects to enable or limit different use cases.
/// </summary>
function CRUDSList(options) {
    var instance = this;
    var extender = new InstanceExtender();
    
    instance = Object.create(new ArrayProcessor({
        'field': 'CRUDS',
        'value': ((options.cruds !== null && options.cruds !== undefined) ? options.cruds : [])
    }));
    instance = extender.extendObjectInterface({'instance': instance, 'field': 'Current'});
    
    /// <summary>Currently selected CRUD index from CRUDS list.</summary>
    instance.CRUDIndex = 0;
    
    if (options.observer !== null && options.observer !== undefined) {
        options.observer.setObject(instance.CRUDS[instance.CRUDIndex]);
    }
    
    /// <summary>Currently selected object (One or Zero).</summary>
    instance.Current = options.observer;
    
    /// <summary>Get array of CRUDS.</summary>
    instance.getCRUDS = function () {
        return instance.CRUDS;
    };
    
    /// <summary>Selects CRUD based on key or index value.</summary>
    instance.selectCRUD = function (options) {

        if (options.crudindex !== null && options.crudindex !== undefined) {
            
            instance.Current.setObject(instance.CRUDS[options.crudindex]);
            
        } else if (options.crudkey !== null && options.crudkey !== undefined) {
            
            if (instance.CRUDS !== null && instance.CRUDS !== undefined) {

                for (var i = 0; i < instance.CRUDS.length; i++) {

                    if (instance.CRUDS[i].getKey() === options.crudkey) {
                        instance.CRUDIndex = i;

                        instance.Current.setObject(instance.CRUDS[i]);
                        return;
                    }
                }
            }
        }
    };
    
    /// <summary>Gets next CRUD view.</summary>
    instance.nextCRUD = function () {
        instance.CRUDIndex += 1;
        if (instance.CRUDIndex >= instance.CRUDS.length) {
            instance.CRUDIndex = 0;
        } else if (instance.CRUDIndex < 0) {
            instance.CRUDIndex = instance.CRUDS.length > 0 ? (instance.CRUDS.length - 1) : 0;
        }
        
        instance.Current.setObject(instance.CRUDS[instance.CRUDIndex]);
    };
    
    /// <summary>Gets previous CRUD view.</summary>
    instance.prevCRUD = function () {
        instance.CRUDIndex -= 1;
        if (instance.CRUDIndex > instance.CRUDS.length) {
            instance.CRUDIndex = 0;
        } else if (instance.CRUDIndex < 0) {
            instance.CRUDIndex = instance.CRUDS.length > 0 ? (instance.CRUDS.length - 1) : 0;
        }
        
        instance.Current.setObject(instance.CRUDS[instance.CRUDIndex]);
    };
    
    /// <summary>Gets the currently selected object.</summary>
    instance.getCurrent = function () {
        return instance.Current;
    };
    
    return instance;
};

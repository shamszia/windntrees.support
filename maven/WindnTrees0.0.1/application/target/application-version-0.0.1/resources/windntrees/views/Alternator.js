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
/// Alternator alternates between Zero or One reference object in observer independent 
/// way based on user interaction. This allows to share same or different views 
/// between reference objects to enable or limit different use cases.
/// </summary>
function Alternator(options) {
    var instance = this;
    var extender = new InstanceExtender();
    instance = extender.extendObjectInterface({'instance': instance, 'field': 'Current'});
    
    /// <summary>Zero object and or view.</summary>
    instance.Zero = options.zero;
    
    /// <summary>One object and or view.</summary>
    instance.One = options.one;
    
    if (options.observer !== null && options.observer !== undefined) {
        if (options.object !== null && options.object !== undefined) {
            options.observer.setObject(options.object);
        } else {
            options.observer.setObject(options.zero);
        }
    }
    
    /// <summary>Currently selected object and or view.</summary>
    instance.Current = options.observer;
    
    /// <summary>Gets function construct type information.</summary>
    instance.getType = function () {
        return "Alternator";
    };

    /// <summary>Gets zero object.</summary>
    instance.getZero = function () {
        return instance.Zero;
    };

    /// <summary>Gets one object.</summary>
    instance.getOne = function () {
        return instance.One;
    };

    /// <summary>Alternates an object with other object.</summary>
    instance.alternate = function (object) {

        if (object !== null && object !== undefined) {
            instance.Current = object;
        }

        if (instance.Current.getObject() === instance.Zero) {
            instance.Current.setObject(instance.One);
        } else {
            instance.Current.setObject(instance.Zero);
        }
        
        return instance.Current;
    };

    /// <summary>Gets the currently selected object.</summary>
    instance.getCurrent = function () {
        return instance.Current;
    };
    
    return instance;
}

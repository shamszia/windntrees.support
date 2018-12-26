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
/// ObjectObserver provides concrete observer independent source and target synchronization 
/// functionality for a particular object source with related user interface 
/// interactive capabilities.
/// ObjectObserver extends from ActivityObserver and for information about activity 
/// functions refer here.
/// </summary>
function ObjectObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    instance = extender.extendFieldObserver({ 'instance': instance, 'field': 'InputObject', 'observer': options.observer });
    instance = extender.extendFieldObserver({ 'instance': instance, 'field': 'OutputObject', 'observer': options.observer });
    
    if (options.observer !== null && options.observer !== undefined) {

        if (typeof (options.observer) === "string") {

            //select and initializes observer.
            if (options.observer === "kn") {
                
                instance.Observer = new ObjectKNObserver(options);
            }

        } else {

            //if observer is provided it is selected.
            instance.Observer = options.observer;
        }
    } else {
        
        //if observer is not provided a default observer is initialized and selected.
        instance.Observer = new ObjectKNObserver(options);
    }
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'newparameter': instance.Observer, 'options': options});
    }
    
    instance = extender.extendContentObserver({'instance': instance,
        'observer': instance.Observer
    });

    instance = extender.extendObserverInterface({'instance': instance,
        'observer': instance.Observer
    });
    
    //extend from activity observer
    instance = ActivityObserver({'instance': instance, 'observer': instance.Observer});
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "ObjectObserver";
    };

    /// <summary>Sets form observer object with optional original key.</summary>
    instance.setFormObject = function (data) {

        instance.getObserver().setFormObject(data);
    };

    /// <summary>Gets form object.</summary>
    instance.getFormObject = function () {

        return instance.getObserver().getFormObject();
    };

    /// <summary>Gets observable form object.</summary>
    instance.getObservableFormObject = function () {

        return instance.getObserver().getObservableFormObject();
    };

    /// <summary>Gets form's stringified JSON object.</summary>
    instance.getFormStringifiedObject = function () {

        return instance.getObserver().getFormStringifiedObject();
    };

    /// <summary>Gets form's JSON object.</summary>
    instance.getFormJSONObject = function () {

        return instance.getObserver().getFormJSONObject();
    };

    /// <summary>Validate form object.</summary>
    instance.validateFormObject = function () {

        return instance.getObserver().validateFormObject();
    };

    /// <summary>Resets form object and view mode.</summary>
    instance.resetForm = function () {

        instance.getObserver().resetForm();
    };

    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }

    return instance;
}
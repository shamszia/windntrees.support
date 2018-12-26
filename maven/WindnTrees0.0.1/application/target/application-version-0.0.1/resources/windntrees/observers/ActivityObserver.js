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
/// ActivityObserver provides concrete observer independent basic user interface 
/// interactive capabilities with status monitoring.
/// </summary>
function ActivityObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.observer !== null && options.observer !== undefined) {

        if (typeof (options.observer) === "string") {
            
            //select and initializes observer.
            if (options.observer === "kn") {
                instance.Observer = new ActivityKNObserver(options);
            }

        } else {
            
            //if observer is provided it is selected.
            instance.Observer = options.observer;
        }
    } else {
        
        //if observer is not provided a default observer is initialized and selected.
        instance.Observer = new ActivityKNObserver(options);
    }
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'newparameter': instance.Observer, 'options': options});
    }
    
    instance = extender.extendContentObserver({'instance': instance,
            'observer': instance.Observer
        });
    
    //utility functions
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "ActivityObserver";
    };

    /// <summary>Gets observer instance key value.</summary>
    instance.getKey = function () {

        return instance.getObserver().getKey();
    };

    /// <summary>Sets observer view scope.</summary>
    instance.setViewScope = function (value) {

        instance.getObserver().setViewScope(value);
    };

    /// <summary>Gets observer view scope.</summary>
    instance.getViewScope = function () {

        return instance.getObserver().getViewScope();
    };

    /// <summary>Gets observers group type.</summary>
    instance.getObserversGroup = function () {
        return instance.getObserver().getObserversGroup();
    }
    
    /// <summary>Gets the type of internal observer.</summary>
    instance.getObserverType = function () {
        return instance.getObserver().getType();
    };
    
    /// <summary>Gets the observer object.</summary>
    instance.getObserver = function () {
        return instance.Observer;
    };
    
    /// <summary>Sets keyword message.</summary>
    instance.setKeyword = function (data) {
        instance.getObserver().setKeyword(data);
    };
    
    /// <summary>Gets keyword message.</summary>
    instance.getKeyword = function() {
        return instance.getObserver().getKeyword();
    };
    
    /// <summary>Check if the keyword has been entered.</summary>
    instance.isKeywordAvailable = function () {
        return instance.getObserver().isKeywordAvailable();
    };
    
    /// <summary>Gets observable keyword message.</summary>
    instance.getObservableKeyword = function() {
        return instance.getObserver().getObservableKeyword();
    };
    
    /// <summary>Gets internal observer message repository.</summary>
    instance.getMessageRepository = function() {
        return instance.getObserver().getMessageRepository();
    };
    
    /// <summary>Sets internal observer's shared observer object.</summary>
    instance.setSharedObject = function (object) {
        instance.getObserver().setSharedObject(object);
    };

    /// <summary>Gets internal observers shared object.</summary>
    instance.getSharedObject = function () {
        return instance.getObserver().getSharedObject();
    };
    
    /// <summary>Gets observable shared object.</summary>
    instance.getObservableSharedObject = function () {
        return instance.getObserver().getObservableSharedObject();
    };
    
    /// <summary>Gets internal observers stringified JSON object from provided immediate data object.</summary>
    instance.getStringifiedObject = function(data) {
        return instance.getObserver().getStringifiedObject(data);
    };
    
    /// <summary>Gets internal observer's JSON object from provided immediate data object.</summary>
    instance.getJSONObject = function(data) {
        return instance.getObserver().getJSONObject(data);
    };
    
    //status functions
    
    /// <summary>Sets internal observer errors into errors observerable list.</summary>
    instance.setErrors = function(data) {
        instance.getObserver().setErrors(data);
    };
    
    /// <summary>Gets internal observer errors list.</summary>
    instance.getErrors = function() {
        return instance.getObserver().getErrors();
    };
    
    /// <summary>Gets observerable errors list.</summary>
    instance.getObservableErrors = function() {
        return instance.getObserver().getObservableErrors();
    };
    
    /// <summary>Sets internal observers processing status (true/false).</summary>
    instance.setProcessing = function(data) {
        instance.getObserver().setProcessing(data);
    };
    
    /// <summary>Gets internal observers processing status.</summary>
    instance.getProcessing = function() {
        return instance.getObserver().getProcessing();
    };
    
    /// <summary>Gets observable processing status.</summary>
    instance.getObservableProcessing = function() {
        return instance.getObserver().getObservableProcessing();
    };
    
    /// <summary>Sets internal observers result message.</summary>
    instance.setResultMessage = function (data) {
        instance.getObserver().setResultMessage(data);
    };
    
    /// <summary>Gets internal observer's result message.</summary>
    instance.getResultMessage = function () {
        return instance.getObserver().getResultMessage();
    };
    
    /// <summary>Gets observable result message.</summary>
    instance.getObservableResultMessage = function () {
        return instance.getObserver().getObservableResultMessage();
    };
    
    /// <summary>Sets form processing status (true/false).</summary>
    instance.setFormProcessing = function(data) {
        instance.getObserver().setFormProcessing(data);
    };
    
    /// <summary>Gets form processing status.</summary>
    instance.getFormProcessing = function() {
        return instance.getObserver().getFormProcessing();
    };
    
    /// <summary>Gets observable processing status.</summary>
    instance.getObservableFormProcessing = function() {
        return instance.getObserver().getObservableFormProcessing();
    };
    
    /// <summary>Sets form result message.</summary>
    instance.setFormResultMessage = function (data) {
        instance.getObserver().setFormResultMessage(data);
    };
    
    /// <summary>Gets form result message.</summary>
    instance.getFormResultMessage = function () {
        return instance.getObserver().getFormResultMessage();
    };
    
    /// <summary>Gets form observable result message.</summary>
    instance.getObservableFormResultMessage = function () {
        return instance.getObserver().getObservableFormResultMessage();
    };

    /// <summary>Sets request progress.</summary>
    instance.setRequestProgress = function (value) {
        instance.getObserver().setRequestProgress(value);
    };

    /// <summary>Gets request progress.</summary>
    instance.getRequestProgress = function () {
        return instance.getObserver().getRequestProgress();
    };

    /// <summary>Sets print ready status.</summary>
    instance.setPrintReady = function (value) {
        instance.getObserver().setPrintReady(value);
    };

    /// <summary>Gets print request status.</summary>
    instance.isPrintReady = function () {
        return instance.getObserver().isPrintReady();
    };

    /// <summary>Display processing indicators.</summary>
    instance.displayProcessing = function (status) {
        instance.getObserver().displayProcessing(status);
    };

    /// <summary>Displays view's saved activity.</summary>
    instance.displaySaved = function () {
        instance.getObserver().displaySaved();
    };

    /// <summary>Displays view's failed activity.</summary>
    instance.displayFailed = function () {
        instance.getObserver().displayFailed();
    };
    
    /// <summary>Displays view's processing activity.</summary>
    instance.displayProcessingActivity = function () {
        instance.getObserver().displayProcessingActivity();
    };
    
    /// <summary>Displays clear activity.</summary>
    instance.displayClearActivity = function () {
        instance.getObserver().displayClearActivity();
    };
    
    /// <summary>Displays no record activity.</summary>
    instance.displayNoRecordActivity = function () {
        instance.getObserver().displayNoRecordActivity();
    };
    
    /// <summary>Displays view's successful activity.</summary>
    instance.displaySuccessActivity = function () {
        instance.getObserver().displaySuccessActivity();
    };
    
    /// <summary>Displays view's failure activity.</summary>
    instance.displayFailureActivity = function () {
        instance.getObserver().displayFailureActivity();
    };
    
    /// <summary>Display form processing status.</summary>
    instance.displayFormProcessing = function (status) {
        instance.getObserver().displayFormProcessing(status);
    };
    
    /// <summary>Displays form processing activity.</summary>
    instance.displayFormProcessingActivity = function () {
        instance.getObserver().displayFormProcessingActivity();
    };
    
    /// <summary>Displays form clear activity.</summary>
    instance.displayFormClearActivity = function () {
        instance.getObserver().displayFormClearActivity();
    };
    
    /// <summary>Displays form no record activity.</summary>
    instance.displayFormNoRecordActivity = function () {
        instance.getObserver().displayFormNoRecordActivity();
    };
    
    /// <summary>Displays form successful activity.</summary>
    instance.displayFormSuccessActivity = function () {
        instance.getObserver().displayFormSuccessActivity();
    };
    
    /// <summary>Displays form failure activity.</summary>
    instance.displayFormFailureActivity = function () {
        instance.getObserver().displayFormFailureActivity();
    };
    
    /// <summary>Display processing indicators.</summary>
    instance.displayGridProcessing = function (status) {
        instance.getObserver().displayGridProcessing(status);
    };
    
    /// <summary>Displays grid's processing activity.</summary>
    instance.displayGridProcessingActivity = function () {
        instance.getObserver().displayGridProcessingActivity();
    };
    
    /// <summary>Displays grid's successful activity.</summary>
    instance.displayGridSuccessActivity = function () {
        instance.getObserver().displayGridSuccessActivity();
    };
    
    /// <summary>Displays grid's failure activity.</summary>
    instance.displayGridFailureActivity = function () {
        instance.getObserver().displayGridFailureActivity();
    };
    
    /// <summary>Displays grid clear activity.</summary>
    instance.displayGridClearActivity = function () {
        instance.getObserver().displayGridClearActivity();
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}
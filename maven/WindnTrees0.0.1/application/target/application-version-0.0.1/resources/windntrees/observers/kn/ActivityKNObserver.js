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
/// ActivityKNObserver provides basic user interface interactive capabilities with status monitoring.
/// </summary>
function ActivityKNObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options });
    }
    
    instance = extender.extendContentTypeObject({'instance': instance, 'contentType': options.contentType });

    /// <summary>Key</summary>
    instance.Key = options.key;
    
    /// <summary>Keyword</summary>
    instance.Keyword = ko.observable(options.keyword);
    
    /// <summary>Messages repository.</summary>
    instance.MessageRepository = options.messages;
    
    /// <summary>Errors array.</summary>
    instance.Errors = ko.observableArray([]);
    
    /// <summary>Shared object.</summary>
    instance.SharedObject = ko.observable(null);
    
    /// <summary>Processing status.</summary>
    instance.Processing = ko.observable(false);
    
    /// <summary>Result message.</summary>
    instance.ResultMessage = ko.observable("");
    
    /// <summary>Form processing status.</summary>
    instance.FormProcessing = ko.observable(false);
    
    /// <summary>Form result message.</summary>
    instance.FormResultMessage = ko.observable("");
    
    /// <summary>Request progress.</summary>
    instance.RequestProgress = ko.observable(0);
    
    /// <summary>Print ready status.</summary>
    instance.PrintReady = ko.observable(false);
    
    /// <summary>View scope.</summary>
    instance.ViewScope = ko.observable((options.viewscope !== null && options.viewscope !== undefined) ? options.viewscope : "view" );
    
    //utility functions
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "ActivityKNObserver";
    };

    /// <summary>Gets observer instance key value.</summary>
    instance.getKey = function () {

        return instance.Key;
    };

    /// <summary>Sets observer view scope.</summary>
    instance.setViewScope = function (value) {

        instance.ViewScope(value);
    };

    /// <summary>Gets observer view scope.</summary>
    instance.getViewScope = function () {

        return instance.ViewScope();
    };

    /// <summary>Get observers group type.</summary>
    instance.getObserversGroup = function () {
        return "KN";
    };
    
    /// <summary>Check if the keyword has been entered.</summary>
    instance.isKeywordAvailable = function () {
        if (instance.Keyword() !== null && instance.Keyword() !== undefined) {
            if (instance.Keyword().length > 0) {
                return true;
            }
        }
        return false;
    };
    
    /// <summary>Sets keyword message.</summary>
    instance.setKeyword = function (data) {
        instance.Keyword(data);
    };
    
    /// <summary>Gets keyword message.</summary>
    instance.getKeyword = function() {
        return instance.Keyword();
    };
    
    /// <summary>Gets observable keyword message.</summary>
    instance.getObservableKeyword = function() {
        return instance.Keyword;
    };
    
    /// <summary>Gets message repository attached to observer.</summary>
    instance.getMessageRepository = function() {
        return instance.MessageRepository;
    };
    
    /// <summary>Sets shared observer object.</summary>
    instance.setSharedObject = function (object) {
        instance.SharedObject(object);
    };

    /// <summary>Gets shared object.</summary>
    instance.getSharedObject = function () {
        return instance.SharedObject();
    };
    
    /// <summary>Gets observable shared object.</summary>
    instance.getObservableSharedObject = function () {
        return instance.SharedObject;
    };
    
    /// <summary>Gets stringified JSON object from provided immediate data object.</summary>
    instance.getStringifiedObject = function(data) {
        return ko.toJSON(data);
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getJSONObject = function(data) {
        return JSON.parse(ko.toJSON(data));
    };
    
    //status functions
    
    /// <summary>Set errors into errors observer list.</summary>
    instance.setErrors = function(data) {
        instance.Errors(data);
    };
    
    /// <summary>Get errors from the observer errors list.</summary>
    instance.getErrors = function() {
        return instance.Errors();
    };
    
    /// <summary>Gets observerable errors list.</summary>
    instance.getObservableErrors = function() {
        return instance.Errors;
    };
    
    /// <summary>Sets processing status (true/false).</summary>
    instance.setProcessing = function(data) {
        instance.Processing(data);
    };
    
    /// <summary>Gets processing status.</summary>
    instance.getProcessing = function() {
        return instance.Processing();
    };
    
    /// <summary>Gets observable processing status.</summary>
    instance.getObservableProcessing = function() {
        return instance.Processing;
    };
    
    /// <summary>Sets result message.</summary>
    instance.setResultMessage = function (data) {
        instance.ResultMessage(data);
    };
    
    /// <summary>Gets result message.</summary>
    instance.getResultMessage = function () {
        return instance.ResultMessage();
    };
    
    /// <summary>Gets observable result message.</summary>
    instance.getObservableResultMessage = function () {
        return instance.ResultMessage;
    };
    
    /// <summary>Sets form processing status (true/false).</summary>
    instance.setFormProcessing = function(data) {
        instance.FormProcessing(data);
    };
    
    /// <summary>Gets form processing status.</summary>
    instance.getFormProcessing = function() {
        return instance.FormProcessing();
    };
    
    /// <summary>Gets observable form processing status.</summary>
    instance.getObservableFormProcessing = function() {
        return instance.FormProcessing;
    };
    
    /// <summary>Sets form result message.</summary>
    instance.setFormResultMessage = function (data) {
        instance.FormResultMessage(data);
    };
    
    /// <summary>Gets form result message.</summary>
    instance.getFormResultMessage = function () {
        return instance.FormResultMessage();
    };
    
    /// <summary>Gets observable form result message.</summary>
    instance.getObservableFormResultMessage = function () {
        return instance.FormResultMessage;
    };

    /// <summary>Sets request progress.</summary>
    instance.setRequestProgress = function (value) {
        instance.RequestProgress(value);
    };

    /// <summary>Gets request progress.</summary>
    instance.getRequestProgress = function () {
        return instance.RequestProgress();
    };

    /// <summary>Sets print ready status.</summary>
    instance.setPrintReady = function (value) {
        instance.PrintReady(value);
    };

    /// <summary>Gets print request status.</summary>
    instance.isPrintReady = function () {
        return instance.PrintReady();
    };

    /// <summary>Display processing indicators.</summary>
    instance.displayProcessing = function (status) {
        instance.Processing(status);
    };

    /// <summary>Displays view's saved activity.</summary>
    instance.displaySaved = function () {
        instance.ResultMessage(instance.getMessageRepository().get("form.saved.text"));
        instance.FormResultMessage(instance.getMessageRepository().get("form.saved.text"));
        instance.Processing(false);
        instance.FormProcessing(false);
    };

    /// <summary>Displays view's failed activity.</summary>
    instance.displayFailed = function () {
        instance.ResultMessage(instance.getMessageRepository().get("form.failed.text"));
        instance.FormResultMessage(instance.getMessageRepository().get("form.failed.text"));
        instance.Processing(false);
        instance.FormProcessing(false);
    };
    
    /// <summary>Displays view's processing activity.</summary>
    instance.displayProcessingActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("standard.processing.text"));
        instance.Processing(true);
    };
    
    /// <summary>Displays clear activity.</summary>
    instance.displayClearActivity = function () {
        instance.ResultMessage("");
        instance.Processing(false);
    };
    
    /// <summary>Displays no record activity.</summary>
    instance.displayNoRecordActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("form.noRecord.text"));
        instance.Processing(false);
    };
    
    /// <summary>Displays view's successful activity.</summary>
    instance.displaySuccessActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("standard.ok.text"));
        instance.Processing(false);
    };
    
    /// <summary>Displays view's failure activity.</summary>
    instance.displayFailureActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("standard.err.text"));
        instance.Processing(false);
    };
    
    /// <summary>Display form processing status.</summary>
    instance.displayFormProcessing = function (status) {
        instance.FormProcessing(status);
    };
    
    /// <summary>Displays form processing activity.</summary>
    instance.displayFormProcessingActivity = function () {
        instance.FormResultMessage(instance.getMessageRepository().get("standard.processing.text"));
        instance.FormProcessing(true);
    };
    
    /// <summary>Displays form clear activity.</summary>
    instance.displayFormClearActivity = function () {
        instance.FormResultMessage("");
        instance.FormProcessing(false);
    };
    
    /// <summary>Displays form no record activity.</summary>
    instance.displayFormNoRecordActivity = function () {
        instance.FormResultMessage(instance.getMessageRepository().get("form.noRecord.text"));
        instance.FormProcessing(false);
    };
    
    /// <summary>Displays form successful activity.</summary>
    instance.displayFormSuccessActivity = function () {
        instance.FormResultMessage(instance.getMessageRepository().get("standard.ok.text"));
        instance.FormProcessing(false);
    };
    
    /// <summary>Displays form failure activity.</summary>
    instance.displayFormFailureActivity = function () {
        instance.FormResultMessage(instance.getMessageRepository().get("standard.err.text"));
        instance.FormProcessing(false);
    };
    
    /// <summary>Display processing indicators.</summary>
    instance.displayGridProcessing = function (status) {
        instance.Processing(status);
    };
    
    /// <summary>Displays grid's processing activity.</summary>
    instance.displayGridProcessingActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("standard.processing.text"));
        instance.Processing(true);
    };
    
    /// <summary>Displays grid's successful activity.</summary>
    instance.displayGridSuccessActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("standard.ok.text"));
        instance.Processing(false);
    };
    
    /// <summary>Displays grid's failure activity.</summary>
    instance.displayGridFailureActivity = function () {
        instance.ResultMessage(instance.getMessageRepository().get("standard.err.text"));
        instance.Processing(false);
    };
    
    /// <summary>Displays grid clear activity.</summary>
    instance.displayGridClearActivity = function () {
        instance.ResultMessage("");
        instance.Processing(false);
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
}

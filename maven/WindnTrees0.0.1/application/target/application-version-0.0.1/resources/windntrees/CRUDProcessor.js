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
/// CRUDProcessor processes response data and errors returned by CRUDController 
/// and produces content and or error object(s). Returned objects are consumed 
/// by other components for further processing. For example, views utilize objects 
/// for presentation. Usually a CRUDProcessor deals with a CRUDController, 
/// a CRUDSource and or a CRUDConsumer.
/// </summary>
function CRUDProcessor(options) {
    var instance = this;
    
    /// <summary>Key is a unique identifier to differentiate between CRUDProcessor.</summary>
    instance.Key = options !== undefined ? options.key : null;
    
    /// <summary>CRUDController resposible for extracting response objects.</summary>
    instance.Controller = null;

    /// <summary>Recently extracted response object.</summary>
    instance.Record = null;
    
    /// <summary>Recently extracted list of response objects.</summary>
    instance.Records = [];
    
    /// <summary>Recently extracted list of response errors.</summary>
    instance.Errors = [];

    /// <summary>Processing event information.</summary>
    instance.ProcessingState = null;
    
    /// <summary>Processing status.</summary>
    instance.ProcessingStatus = false;

    /// <summary>Gets type of function construct.</summary>
    instance.getType = function () {
        return "CRUDProcessor";
    };

    /// <summary>Gets unique identification key value.</summary>
    instance.getKey = function () {
        return instance.Key;
    };

    /// <summary>Gets CRUDController linked with CRUDProcessor.</summary>
    instance.getController = function () {
        if (instance.Controller === null) {
            instance.Controller = new CRUDController();
        }
        return instance.Controller;
    };

    /// <summary>Requested response data.</summary>
    instance.responseData = function () {
        return instance.getController().responseData();
    };

    /// <summary>Response errors.</summary>
    instance.responseError = function () {
        return instance.getController().responseError();
    };

    /// <summary>Checks response for error.</summary>
    instance.isResponseError = function () {
        return instance.getController().isResponseError();
    };

    /// <summary>Checks response for input errors.</summary>
    instance.isInputError = function () {
        if (instance.Errors === null || instance.Errors === undefined) {
            return false;
        }

        return instance.Errors.length > 0;
    };

    /// <summary>Gets request processing status.</summary>
    instance.getProcessingStatus = function () {
        return instance.ProcessingStatus;
    };

    /// <summary>Gets in process request state.</summary>
    instance.getProcessingState = function () {
        return instance.ProcessingState;
    };

    /// <summary>Gets list of errors. Note that list of errors is only available when request has been completed and processed.</summary>
    instance.getErrors = function () {
        return instance.Errors;
    };

    /// <summary>Gets processed record. Note that record is only available when the request has been completed and processed.</summary>
    instance.getRecord = function () {
        return instance.Record;
    };

    /// <summary>Gets processed records. Note that records are only available when request has been completed and processed. </summary>
    instance.getRecords = function () {
        return instance.Records;
    };

    /// <summary>Gets server side context path for requested URI.</summary>
    instance.getContextPath = function (data) {
        instance.Record = null;
        instance.Errors = [];

        instance.getController().getContextPath(data);
    };

    /// <summary>Extracts data object by key from the specified URI. </summary>
    instance.get = function (data) {
        instance.Record = null;
        instance.Errors = [];

        instance.getController().get(data);
    };

    /// <summary>Extracts data object by composite key from the specified URI.</summary>
    instance.post = function (data) {
        instance.Record = null;
        instance.Errors = [];

        instance.getController().post(data);
    };

    /// <summary>Extracts paged list of data objects referenced by key and or a keyword from specified URI.</summary>
    instance.select = function (data) {
        instance.Records = [];
        instance.Errors = [];

        instance.getController().select(data);
    };

    /// <summary>Extracts paged list of data objects referenced by key and or a keyword from specified URI.</summary>
    instance.selectList = function (data) {
        instance.Records = [];
        instance.Errors = [];

        instance.getController().selectList(data);
    };

    /// <summary>Extracts paged list of data objects referenced by keyword from specified URI.</summary>
    instance.find = function (data) {
        instance.Records = [];
        instance.Errors = [];

        instance.getController().find(data);
    };

    /// <summary>Extracts list of data objects referenced by keyword from specified URI.</summary>
    instance.list = function (data) {
        instance.Records = [];
        instance.Errors = [];

        instance.getController().list(data);
    };

    /// <summary>Extracts list of data objects from specified URI.</summary>
    instance.listAll = function (data) {
        instance.Records = [];
        instance.Errors = [];

        instance.getController().listAll(data);
    };

    /// <summary>Saves new content object and processes response.</summary>
    instance.create = function (data) {
        instance.Record = null;
        instance.Errors = [];

        instance.getController().create(data);
    };

    /// <summary>Saves existing content object and processes response.</summary>
    instance.update = function (data) {
        instance.Record = null;
        instance.Errors = [];

        instance.getController().update(data);
    };

    /// <summary>Delete existing content object and processes response.</summary>
    instance.delete = function (data) {
        instance.Record = null;
        instance.Errors = [];

        instance.getController().delete(data);
    };

    /// <summary>Extracted and processed record data object in response to create, update and delete request calls.</summary>
    instance.processRecord = function (eventData) {
        var result = eventData.result;

        if (result !== null && result !== undefined) {

            if (result.errors !== null && result.errors !== undefined) {

                if (Array.isArray(result.errors)) {
                    for (var i = 0; i < result.errors.length; i++) {

                        var item = result.errors[i];
                        if (item !== null && item !== undefined) {
                            instance.Errors.push({"errField": item.field, "errMessage": item.defaultMessage});
                        }
                    }

                    instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': instance.Errors, 'code': result.code});
                } else {

                    instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': result.errors, 'code': result.code});
                }

            } else {

                if (eventData.request === 'delete' && (eventData.target === null || eventData.target === undefined)) {

                    try {

                        //check if the content information was provided within the request data
                        if (eventData.data.contentType !== null && eventData.data.contentType !== undefined) {
                            //if content information exists then take this information to construct
                            //new typed object

                            //instance.Record = options.contentType.newObject((typeof (eventData.data.content) === "string") ? JSON.parse(eventData.data.content) : eventData.data.content);

                            instance.Record = eventData.data.contentType.newObject((typeof (eventData.data.content) === "string") ? JSON.parse(eventData.data.content) : eventData.data.content);
                        }
                        else {

                            //if content information was not provided within the request then
                            //check for CRUDProcessor options for content information 

                            if (options.contentType !== null && options.contentType !== undefined) {
                                //if CRUDProcessor have content information then use this information
                                //to construct new typed content object.

                                //instance.Record = options.contentType.newObject(contentObject);
                                instance.Record = options.contentType.newObject((typeof (eventData.data.content) === "string") ? JSON.parse(eventData.data.content) : eventData.data.content);

                            } else {
                                //if content information is not provided within request or within
                                //CRUDProcessor then just the new object as it is.

                                //instance.Record = contentObject;
                                instance.Record = (typeof (eventData.data.content) === "string") ? JSON.parse(eventData.data.content) : eventData.data.content;
                            }
                        }
                    }
                    catch (e) {

                        instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': 'Exception occured during content processing.', 'code': result.code });
                    }

                    instance.notify({ 'event': 'record.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': instance.Record, 'code': result.code });

                } else {

                    var objectReady = false;
                    var contentObject = (result.contents !== null && result.contents !== undefined) ? result.contents : ((result.contents === null || result.contents === undefined) ? null : result);

                    if (contentObject !== null && contentObject !== undefined) {

                        try {

                            if (typeof (contentObject) === "object") {
                                objectReady = true;
                            } else {
                                JSON.parse(contentObject);
                                objectReady = true;
                            }

                        } catch (e) { }

                        try {

                            //if returned result is object ready only then construct typed objects
                            if (objectReady) {

                                //check if the content information was provided within the request data
                                if (eventData.data.contentType !== null && eventData.data.contentType !== undefined) {
                                    //if content information exists then take this information to construct
                                    //new typed object

                                    instance.Record = eventData.data.contentType.newObject(contentObject);
                                }
                                else {

                                    //if content information was not provided within the request then
                                    //check for CRUDProcessor options for content information 

                                    if (options.contentType !== null && options.contentType !== undefined) {
                                        //if CRUDProcessor have content information then use this information
                                        //to construct new typed content object.

                                        instance.Record = options.contentType.newObject(contentObject);

                                    } else {
                                        //if content information is not provided within request or within
                                        //CRUDProcessor then just the new object as it is.

                                        instance.Record = contentObject;
                                    }
                                }

                            } else {

                                //if returned result is not object ready then return reply as it is.

                                instance.Record = contentObject;
                            }
                        }
                        catch (e) {

                            instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': 'Exception occured during content processing.', 'code': result.code });
                        }

                        instance.notify({ 'event': 'record.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': instance.Record, 'code': result.code });

                    } else {

                        instance.notify({ 'event': 'record.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': contentObject, 'code': result.code });
                    }
                }
            }
        }
    };

    /// <summary>Extracted and processed list of record data objects in response to select, selectList, find, list and listAll.</summary>
    instance.processRecords = function (eventData) {
        var result = eventData.result;

        if (result.errors !== null && result.errors !== undefined) {

            if (Array.isArray(result.errors)) {
                for (var i = 0; i < result.errors.length; i++) {

                    var item = result.errors[i];
                    if (item !== null && item !== undefined) {
                        instance.Errors.push({"errField": item.field, "errMessage": item.defaultMessage});
                    }
                }

                instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': instance.Errors, 'code': result.code});
            } else {

                instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': result.errors, 'code': result.code});
            }

        } else {
            
            var contentArray = (result.contents !== null && result.contents !== undefined) ? result.contents : ((result.contents === null || result.contents === undefined) ? null : result);

            if (contentArray !== null && contentArray !== undefined) {

                for (var i = 0; i < contentArray.length; i++) {
                    var item = contentArray[i];
                    if (item !== null && item !== undefined) {

                        var objectReady = false;
                        try {
                            if (typeof (item) === "object") {
                                objectReady = true;
                            } else {
                                JSON.parse(item);
                                objectReady = true;
                            }
                        } catch (e) { }

                        try {

                            //if returned result is object ready only then construct typed objects
                            if (objectReady) {

                                //check if the content information was provided within the request data
                                if (eventData.data.contentType !== null && eventData.data.contentType !== undefined) {
                                    //if content information exists then take this information to construct
                                    //new typed object

                                    instance.Records.push(eventData.data.contentType.newObject(item));
                                }
                                else {

                                    //if content information was not provided within the request then
                                    //check for CRUDProcessor options for content information 

                                    if (options.contentType !== null && options.contentType !== undefined) {
                                        //if CRUDProcessor have content information then use this information
                                        //to construct new typed content object.

                                        instance.Records.push(options.contentType.newObject(item));
                                    } else {
                                        //if content information is not provided within request or within
                                        //CRUDProcessor then just the new object as it is.

                                        instance.Records.push(item);
                                    }
                                }

                            } else {

                                //if returned result is not object ready then return reply as it is.
                                instance.Records.push(item);
                            }
                        }
                        catch (e) {

                            instance.notify({ 'event': 'errors.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': 'Exception occured during content processing.', 'code': result.code });
                        }
                    }
                }

                instance.notify({ 'event': 'records.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': instance.Records, 'code': result.code });

            } else {

                instance.notify({ 'event': 'records.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': contentArray, 'code': result.code });
            }
        }
    };

    /// <summary>Notifies event subscribers with event information. </summary>
    instance.notify = function (eventData) {
        $(instance).trigger(eventData.event, eventData);
        if (instance.Key !== null && instance.Key !== undefined) {
            $(instance.Key).trigger(eventData.event, eventData);
        }
    };

    
    /// <summary>Processes request data before making request call.</summary>
    instance.beforeRequest = function (event, eventData) {
        instance.ProcessingState = {'event': event, 'triggerEvent': eventData};
        instance.ProcessingStatus = true;
    };
    
    /// <summary>Processes response data after making request call.</summary>
    instance.afterRequest = function (event, eventData) {
        instance.ProcessingState = {'event': event, 'triggerEvent': eventData};
        instance.ProcessingStatus = false;

        if (Array.isArray(eventData.result.contents)) {

            instance.processRecords(eventData);
        } else {

            instance.processRecord(eventData);
        }
    };

    /// <summary>Processes response error after making request call.</summary>
    instance.failRequest = function (event, eventData) {
        instance.ProcessingState = {'event': event, 'triggerEvent': eventData};
        instance.ProcessingStatus = false;

        instance.notify({'event': 'fail.processor.CRUD.WindnTrees', 'key': instance.Key, 'request': eventData.request, 'data': eventData.data, 'result': eventData.result});

    };

    /// <summary>Subscribes CRUDController events for processing.</summary>
    instance.subscribeCRUDControllerEvent = function (event, callback) {

        $(instance.getController()).on(event, callback);
    };

    /// <summary>Unsubscribes CRUDController events for processing.</summary>
    instance.unSubscribeCRUDControllerEvent = function (event, callback) {

        $(instance.getController()).off(event, callback);
    };

    /// <summary>Subscribes CRUDController events with events instance.</summary>
    instance.subscribeEvents = function (eventsInstance) {

        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;

        $(instance.getController()).on('before.request.CRUD.WindnTrees', eventsInstance.beforeRequest);
        $(instance.getController()).on('after.request.CRUD.WindnTrees', eventsInstance.afterRequest);
        $(instance.getController()).on('fail.request.CRUD.WindnTrees', eventsInstance.failRequest);
    };

    /// <summary>Unsubscribes CRUDController events with events instance.</summary>
    instance.unSubscribeEvents = function (eventsInstance) {

        eventsInstance = (eventsInstance !== null && eventsInstance !== undefined) ? eventsInstance : instance;

        $(instance.getController()).off('before.request.CRUD.WindnTrees', eventsInstance.beforeRequest);
        $(instance.getController()).off('after.request.CRUD.WindnTrees', eventsInstance.afterRequest);
        $(instance.getController()).off('fail.request.CRUD.WindnTrees', eventsInstance.failRequest);
    };

    instance.subscribeEvents();
}
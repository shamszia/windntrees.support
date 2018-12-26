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
/// SearchKNObserver provides records, record objects and their targets synchronization 
/// functionality with related user interface interactive capabilities.
/// SearchKNObserver extends from ActivityKNObserver and for information about 
/// activity functions refer here. 
/// </summary>
function SearchKNObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'options': options });
    }
    
    var activityOptions = Object.create(options);
    activityOptions.instance = instance;
    instance = ActivityKNObserver(activityOptions);
    
    //listactivity
    /// <summary>Extracted record object.</summary>
    instance.Record = ko.observable(null);
    
    /// <summary>Extracted list of record objects.</summary>
    instance.Records = ko.observableArray([]);
    
    /// <summary>Total record count.</summary>
    instance.RecordCount = ko.observable(0);
    
    /// <summary>Selected record object.</summary>
    instance.SelectedRecord = ko.observable(null);
    
    /// <summary>Selected record index.</summary>
    instance.SelectedRecordIndex = -1;

    /// <summary>List navigator.</summary>
    instance.ListNavigator = ko.observable(new ListNavigator({ 'currentList': 1, 'listSize': 1, 'totalRecords': 0, 'scrollSize': 1, 'listsource': instance.ListSource }));
    
    /// <summary>Listing scroll size.</summary>
    instance.ListingScrollSize = ko.observable(5);
    
    /// <summary>List size.</summary>
    instance.ListSize = ko.observable(10);
    
    /// <summary>Selected list number (or page)</summary>
    instance.CurrentList = ko.observable(1);
    
    /// <summary>List source.</summary>
    instance.ListSource = options.listsource;
    
    
    /// <summary>Gets type of function construct.</summary>
    instance.getType = function () {
        return "SearchKNObserver";
    };
    
    /// <summary>Sets record.</summary>
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
    
    /// <summary>Set observer records list with array object.</summary>
    instance.setRecords = function(data) {
        instance.Records(data);
    };
    
    /// <summary>Get records list from observer records.</summary>
    instance.getRecords = function() {
        return instance.Records();
    };
    
    /// <summary>Get records list from observer records.</summary>
    instance.getObservableRecords = function() {
        return instance.Records;
    };
    
    /// <summary>Sets record count.</summary>
    instance.setRecordCount = function(data) {
        instance.RecordCount(data);
    };
    
    /// <summary>Gets record count.</summary>
    instance.getRecordCount = function() {
        return instance.RecordCount();
    };
    
    /// <summary>Gets record count.</summary>
    instance.getObservableRecordCount = function() {
        return instance.RecordCount;
    };
    
    /// <summary>Sets selected record in detail observer.</summary>
    instance.setSelectedRecord = function (data) {
        instance.SelectedRecord(data);
    };
    
    /// <summary>Gets selected record from detail observer.</summary>
    instance.getSelectedRecord = function () {
        return instance.SelectedRecord();
    };
    
    /// <summary>Gets observable selected record.</summary>
    instance.getObservableSelectedRecord = function () {
        return instance.SelectedRecord;
    };
    
    /// <summary>Sets grid / list item current index.</summary>
    instance.setSelectedRecordIndex = function(data) {
        instance.SelectedRecordIndex(data);
    };
    
    /// <summary>Gets grid / list item current index.</summary>
    instance.getSelectedRecordIndex = function () {
        return instance.SelectedRecordIndex();
    };
    
    /// <summary>Gets observable selected record index.</summary>
    instance.getObservableSelectedRecordIndex = function () {
        return instance.SelectedRecordIndex;
    };
    
    /// <summary>Sets pagination view data object.</summary>
    instance.setListNavigator = function (navigator) {
        instance.ListNavigator(navigator);
    };
    
    /// <summary>Gets grid / list pagination data view.</summary>
    instance.getListNavigator = function () {
        return instance.ListNavigator();
    };
    
    /// <summary>Gets observable list navigator object.</summary>
    instance.getObservableListNavigator = function () {
        return instance.ListNavigator;
    };
    
    /// <summary>Sets grid / list scroll size.</summary>
    instance.setListingScrollSize = function(data) {
        instance.ListingScrollSize(data);
    };
    
    /// <summary>Gets grid / list scroll size.</summary>
    instance.getListingScrollSize = function () {
        return instance.ListingScrollSize();
    };
    
    /// <summary>Gets observable listing scroll size object.</summary>
    instance.getObservableListingScrollSize = function () {
        return instance.ListingScrollSize;
    };
    
    /// <summary>Sets grid / list data page size.</summary>
    instance.setListSize = function(data) {
        instance.ListSize(data);
    };
    
    /// <summary>Gets grid / list data page size.</summary>
    instance.getListSize = function () {
        return instance.ListSize();
    };
    
    /// <summary>Gets observable list size object.</summary>
    instance.getObservableListSize = function () {
        return instance.ListSize;
    };
    
    /// <summary>Sets grid / list current page.</summary>
    instance.setCurrentList = function(data) {
        instance.CurrentList(data);
    };
    
    /// <summary>Gets grid / list current page.</summary>
    instance.getCurrentList = function () {
        return instance.CurrentList();
    };

    /// <summary>Sets list source.</summary>
    instance.setListSource = function (value) {
        instance.ListSource = value;
    };

    /// <summary>Gets list source.</summary>
    instance.getListSource = function () {
        return instance.ListSource;
    };
    
    /// <summary>Gets observable current list object.</summary>
    instance.getObservableCurrentList = function () {
        return instance.CurrentList;
    };
    
    /// <summary>Gets indexed stringified JSON object.</summary>
    instance.getIndexedStringifiedObject = function (index) {
        if (index === undefined) {
            if (instance.SelectedRecordIndex >= 0) {
                return ko.toJSON(instance.Records[instance.SelectedRecordIndex]);
            }
        } else {
            if (index >= 0) {
                return ko.toJSON(instance.Records[index]);
            }
        }
    };
    
    /// <summary>Gets indexed JSON object.</summary>
    instance.getIndexedJSONObject = function(index) {
        return JSON.parse(instance.getIndexedStringifiedObject(index));
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getSelectedStringifiedObject = function() {
        return ko.toJSON(instance.SelectedRecord());
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getSelectedJSONObject = function() {
        return JSON.parse(ko.toJSON(instance.SelectedRecord()));
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getStringifiedObject = function(data) {
        return ko.toJSON(data);
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getJSONObject = function(data) {
        return JSON.parse(ko.toJSON(data));
    };
    
    /// <summary>Select a record based on index value.</summary>
    instance.selectRecord = function (options) {
        
        var selectedRecord = null;
        if (options.index !== null && options.index !== undefined) {
            selectedRecord = instance.Records()[options.index];
        } else if (options.record !== null && options.record !== undefined) {
            selectedRecord = options.record;
        }
        
        if (selectedRecord.getType() === 'DetailKNObserver'
                || selectedRecord.getType() === 'DetailObserver') {
            
            instance.setRecord(selectedRecord.getRecord());
        } else {
            
            instance.setRecord(selectedRecord);
        }
    };
    
    /// <summary>Resets list records, error list and record count views.</summary>
    instance.clearListRecordsView = function () {
        instance.Records([]);
        instance.Errors([]);
        instance.RecordCount(0);
    };

    /// <summary>Fills list records and associated views.</summary>
    instance.fillListRecordsView = function (data) {

        if (data.clearRecords !== null && data.clearRecords !== undefined) {
            if (data.clearRecords) {
                instance.clearListRecordsView();
            }
        } else {
            instance.clearListRecordsView();
        }
        
        if (data.records !== null && data.records !== undefined) {

            instance.Records(data.records);
        }

        if (data.immediateRecords !== null && data.immediateRecords !== undefined) {
            if (data.immediateRecords) {
                if (data.records !== null && data.records !== undefined) {
                    instance.RecordCount(data.records.length);
                    var pagesNavigator = new ListNavigator({ 'currentList': instance.CurrentList(), 'listSize': instance.ListSize(), 'totalRecords': data.records.length, 'scrollSize': instance.ListingScrollSize(), 'listsource': instance.ListSource });
                    instance.ListNavigator(pagesNavigator);
                    instance.CurrentList(data.page);

                    if (data.messageType !== null &&
                        data.messageType !== undefined) {

                        if (data.messageType === 'brief') {

                            instance.displaySaved();

                        } else {

                            instance.ResultMessage(instance.getMessageRepository().get("form.found.text") + " " + data.records.length + " " + instance.getMessageRepository().get("form.records.text") + " " + instance.getMessageRepository().get("form.displayingPage.text") + " " + instance.CurrentList() + " " + instance.getMessageRepository().get("form.of.text") + " " + instance.ListNavigator().calculateTotalPages() + " " + instance.getMessageRepository().get("form.totalPages.text"));
                        }
                    } else {

                        instance.ResultMessage(instance.getMessageRepository().get("form.found.text") + " " + data.records.length + " " + instance.getMessageRepository().get("form.records.text") + " " + instance.getMessageRepository().get("form.displayingPage.text") + " " + instance.CurrentList() + " " + instance.getMessageRepository().get("form.of.text") + " " + instance.ListNavigator().calculateTotalPages() + " " + instance.getMessageRepository().get("form.totalPages.text"));
                    }
                }
            }
        } else {
            
            //totalRecords, currentList, listSize
            data.responseData = typeof (data.responseData) === "string" ? JSON.parse(data.responseData) : data.responseData;

            if (data.responseData !== null && data.responseData !== undefined) {

                if (data.responseData.contents !== null && data.responseData.contents !== undefined) {

                    instance.RecordCount(data.responseData.totalRecords);
                    var pagesNavigator = new ListNavigator({ 'currentList': instance.CurrentList(), 'listSize': instance.ListSize(), 'totalRecords': data.responseData.totalRecords, 'scrollSize': instance.ListingScrollSize(), 'listsource': instance.ListSource});
                    instance.ListNavigator(pagesNavigator);
                    instance.CurrentList(data.page);

                    if (data.messageType !== null &&
                        data.messageType !== undefined) {

                        if (data.messageType === 'brief') {

                            instance.displaySaved();

                        } else {

                            instance.ResultMessage(instance.getMessageRepository().get("form.found.text") + " " + data.responseData.totalRecords + " " + instance.getMessageRepository().get("form.records.text") + " " + instance.getMessageRepository().get("form.displayingPage.text") + " " + instance.CurrentList() + " " + instance.getMessageRepository().get("form.of.text") + " " + instance.ListNavigator().calculateTotalPages() + " " + instance.getMessageRepository().get("form.totalPages.text"));
                        }
                    } else {

                        instance.ResultMessage(instance.getMessageRepository().get("form.found.text") + " " + data.responseData.totalRecords + " " + instance.getMessageRepository().get("form.records.text") + " " + instance.getMessageRepository().get("form.displayingPage.text") + " " + instance.CurrentList() + " " + instance.getMessageRepository().get("form.of.text") + " " + instance.ListNavigator().calculateTotalPages() + " " + instance.getMessageRepository().get("form.totalPages.text"));
                    }
                }
            }
        }
    };
    
    /// <summary>Composes list navigator observable object based on records, total records and current list.</summary>
    instance.composeNavigator = function (options) {
        
        if (options.responseData !== null && options.responseData !== undefined) {
            if (options.responseData.contents !== null && options.responseData.contents !== undefined) {
                
                instance.CurrentList(options.currentList);
                instance.RecordCount(options.responseData.totalRecords);

                var pagesNavigator = new ListNavigator({ 'currentList': instance.CurrentList(), 'listSize': instance.ListSize(), 'totalRecords': options.responseData.totalRecords, 'scrollSize': instance.ListingScrollSize(), 'listsource': instance.ListSource });
                instance.ListNavigator(pagesNavigator);
                instance.ResultMessage(instance.getMessageRepository().get("form.found.text") + " " + options.responseData.totalRecords + " " + instance.getMessageRepository().get("form.records.text") + " " + instance.getMessageRepository().get("form.displayingPage.text") + " " + instance.CurrentList() + " " + instance.getMessageRepository().get("form.of.text") + " " + instance.ListNavigator().calculateTotalPages() + " " + instance.getMessageRepository().get("form.totalPages.text"));
            }
        }
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
};



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

/// <summary></summary>
/// SearchObserver provides concrete observer independent records, record objects 
/// and their targets synchronization functionality with related user interface 
/// interactive capabilities.
/// SearchObserver extends from ActivityObserver and for information about activity 
/// functions refer here.
/// <summary></summary>
function SearchObserver(options) {
    var instance = (options.instance !== null && options.instance !== undefined) ? options.instance : this;
    var extender = new InstanceExtender();
    
    if (options.observer !== null && options.observer !== undefined) {

        if (typeof (options.observer) === "string") {
            
            //select and initializes observer.
            if (options.observer === "kn") {
                instance.Observer = new SearchKNObserver(options);
            }

        } else {
            
            //if observer is provided it is selected.
            instance.Observer = options.observer;
        }
    } else {
        
        //if observer is not provided a default observer is initialized and selected.
        instance.Observer = new SearchKNObserver(options);
    }
    
    var activityOptions = Object.create(options);
    activityOptions.instance = instance;
    activityOptions.observer = instance.Observer;
    
    instance = ActivityObserver(activityOptions);
    
    if (options.instance === null || options.instance === undefined) {
        instance = extender.extendNewInstance({ 'instance': instance, 'newparameter': instance.Observer, 'options': options});
    }
    
    /// <summary>Gets the type of the function construct.</summary>
    instance.getType = function () {
        return "SearchObserver";
    };
    
    /// <summary>Sets record.</summary>
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
    
    /// <summary>Set observer records list with array object.</summary>
    instance.setRecords = function(data) {
        instance.getObserver().setRecords(data);
    };
    
    /// <summary>Get records list from observer records.</summary>
    instance.getRecords = function() {
        return instance.getObserver().getRecords();
    };
    
    /// <summary>Get records list from observer records.</summary>
    instance.getObservableRecords = function() {
        return instance.getObserver().getObservableRecords();
    };
    
    /// <summary>Sets record count.</summary>
    instance.setRecordCount = function(data) {
        instance.getObserver().setRecordCount(data);
    };
    
    /// <summary>Gets record count.</summary>
    instance.getRecordCount = function() {
        return instance.getObserver().getRecordCount();
    };
    
    /// <summary>Gets record count.</summary>
    instance.getObservableRecordCount = function() {
        return instance.getObserver().getObservableRecordCount();
    };
    
    /// <summary>Sets selected record in detail observer.</summary>
    instance.setSelectedRecord = function (data) {
        instance.getObserver().setSelectedRecord(data);
    };
    
    /// <summary>Gets selected record from detail observer.</summary>
    instance.getSelectedRecord = function () {
        return instance.getObserver().getSelectedRecord();
    };
    
    /// <summary>Gets observable selected record.</summary>
    instance.getObservableSelectedRecord = function () {
        return instance.getObserver().getObservableSelectedRecord();
    };
    
    /// <summary>Sets grid / list item current index.</summary>
    instance.setSelectedRecordIndex = function(data) {
        instance.getObserver().setSelectedRecordIndex(data);
    };
    
    /// <summary>Gets grid / list item current index.</summary>
    instance.getSelectedRecordIndex = function () {
        return instance.getObserver().getSelectedRecordIndex();
    };
    
    /// <summary>Gets observable selected record index.</summary>
    instance.getObservableSelectedRecordIndex = function () {
        return instance.getObserver().getObservableSelectedRecordIndex();
    };
    
    /// <summary>Sets pagination view data object.</summary>
    instance.setListNavigator = function (navigator) {
        instance.getObserver().setListNavigator(navigator);
    };
    
    /// <summary>Gets grid / list pagination data view.</summary>
    instance.getListNavigator = function () {
        return instance.getObserver().getListNavigator();
    };
    
    /// <summary>Gets observable list navigator object.</summary>
    instance.getObservableListNavigator = function () {
        return instance.getObserver().getObservableListNavigator();
    };
    
    /// <summary>Sets grid / list scroll size.</summary>
    instance.setListingScrollSize = function(data) {
        instance.getObserver().setListingScrollSize(data);
    };
    
    /// <summary>Gets grid / list scroll size.</summary>
    instance.getListingScrollSize = function () {
        return instance.getObserver().getListingScrollSize();
    };
    
    /// <summary>Gets observable listing scroll size object.</summary>
    instance.getObservableListingScrollSize = function () {
        return instance.getObserver().getObservableListingScrollSize();
    };
    
    /// <summary>Sets grid / list data page size.</summary>
    instance.setListSize = function(data) {
        instance.getObserver().setListSize(data);
    };
    
    /// <summary>Gets grid / list data page size.</summary>
    instance.getListSize = function () {
        return instance.getObserver().getListSize();
    };
    
    /// <summary>Gets observable list size object.</summary>
    instance.getObservableListSize = function () {
        return instance.getObserver().getObservableListSize();
    };
    
    /// <summary>Sets grid / list current page.</summary>
    instance.setCurrentList = function(data) {
        instance.getObserver().setCurrentList(data);
    };
    
    /// <summary>Gets grid / list current page.</summary>
    instance.getCurrentList = function () {
        return instance.getObserver().getCurrentList();
    };

    /// <summary>Sets list source.</summary>
    instance.setListSource = function (value) {
        instance.getObserver().setListSource(data);
    };

    /// <summary>Gets list source.</summary>
    instance.getListSource = function () {
        return instance.getObserver().getListSource();
    };
    
    /// <summary>Gets observable current list object.</summary>
    instance.getObservableCurrentList = function () {
        return instance.getObserver().getObservableCurrentList();
    };
    
    /// <summary>Gets indexed stringified JSON object.</summary>
    instance.getIndexedStringifiedObject = function (index) {
        return instance.getObserver().getIndexedStringifiedObject(index);
    };
    
    /// <summary>Gets indexed JSON object.</summary>
    instance.getIndexedJSONObject = function(index) {
        return instance.getObserver().getIndexedJSONObject(index);
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getSelectedStringifiedObject = function() {
        return instance.getObserver().getSelectedStringifiedObject();
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getSelectedJSONObject = function() {
        return instance.getObserver().getSelectedJSONObject();
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getStringifiedObject = function(data) {
        return instance.getObserver().getStringifiedObject(data);
    };
    
    /// <summary>Gets JSON object from provided immediate data object.</summary>
    instance.getJSONObject = function(data) {
        return instance.getObserver().getJSONObject(data);
    };
    
    /// <summary>Selects record.</summary>
    instance.selectRecord = function (options) {
        instance.getObserver().selectRecord(options);
    };

    /// <summary>Resets list records, error list and record count views.</summary>
    instance.clearListRecordsView = function () {
        instance.getObserver().clearListRecordsView();
    };

    /// <summary>Fills list records and associated views.</summary>
    instance.fillListRecordsView = function (data) {
        instance.getObserver().fillListRecordsView(data);
    };
    
    /// <summary>Composes list navigator observable object based on records, total records and current list.</summary>
    instance.composeNavigator = function (options) {
        
        instance.getObserver().composeNavigator(options);
    };
    
    if (options.instance !== null && options.instance !== undefined) {
        return Object.create(instance);
    }
    
    return instance;
};



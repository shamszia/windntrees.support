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
/// Navigation link represented by list (or page) number and list source.
/// </summary>
function NavLink(number, listsource) {
    var instance = this;
    
    /// <summary>List source usually a view.</summary>
    instance.ListSource = listsource;
    
    /// <summary>List (or page) number.</summary>
    instance.Number = number;
    
    /// <summary>Data source dependent find function integration.</summary>
    instance.find = function (options, fill) {

        if (instance.ListSource !== null && instance.ListSource !== undefined) {

            return instance.ListSource.find(options, fill);
        }
    };

    /// <summary>Data source dependent list function integration.</summary>
    instance.list = function (options, fill) {

        if (instance.ListSource !== null && instance.ListSource !== undefined) {

            return instance.ListSource.list(options, fill);
        }
    };
    
    /// <summary>Data source dependent select function integration.</summary>
    instance.select = function (options, fill) {

        if (instance.ListSource !== null && instance.ListSource !== undefined) {

            return instance.ListSource.select(options, fill);
        }
    };

    /// <summary>Data source dependent select list function integration.</summary>
    instance.selectList = function (options, fill) {

        if (instance.ListSource !== null && instance.ListSource !== undefined) {

            return instance.ListSource.selectList(options, fill);
        }
    };
}

/// <summary>
/// ListNavigator data structure used to render navigation (or paging) 
/// links with scrolling size support.
/// </summary>
function ListNavigator(options) {
    var instance = this;

    /// <summary>NavLinks object or data source for list navigator.</summary>
    instance.Lists = [];
    
    /// <summary>Currently selected list number.</summary>
    instance.CurrentList = (options.currentList !== null && options.currentList !== undefined) ? options.currentList : 1;
    
    /// <summary>List size.</summary>
    instance.ListSize = (options.listSize !== null && options.listSize !== undefined) ? options.listSize : 10;
    
    /// <summary>Total records.</summary>
    instance.TotalRecords = (options.totalRecords !== null && options.totalRecords !== undefined) ? options.totalRecords: 0;
    
    /// <summary>List links scroll size.</summary>
    instance.ScrollSize = (options.scrollSize !== null && options.scrollSize !== undefined) ? options.scrollSize : 10; // Number of pages dispalyed
    
    /// <summary>Calculates total pages.</summary>
    instance.calculateTotalPages = function () {
        return Math.ceil(instance.TotalRecords / instance.ListSize);
    };

    /// <summary>Composes list navigator based on list source and navigation links.</summary>
    instance.composeLists = function (listsource) {
        instance.Lists = [];
        //find the pager scroll size offset to find min and max pages
        var pageOffset = Math.ceil(instance.ScrollSize / 2);
        var minPageNumber = options.currentList - pageOffset;
        var maxPageNumber = options.currentList + pageOffset;

        if (minPageNumber <= 0) {
            minPageNumber = 1;
        }

        if (minPageNumber + instance.ScrollSize > instance.calculateTotalPages()) {
            maxPageNumber = instance.calculateTotalPages();
        }
        else {
            maxPageNumber = minPageNumber + instance.ScrollSize;

            if (maxPageNumber > instance.calculateTotalPages()) {
                maxPageNumber = instance.calculateTotalPages();
            }
        }
        for (var i = minPageNumber; i <= maxPageNumber; i++) {

            var ls = (listsource !== null && listsource !== undefined) ? listsource : options.listsource;
            instance.Lists.push(new NavLink(i, ls));
        }
    };
    
    /// <summary>Gets list of navigation links.</summary>
    instance.getLists = function () {
        return instance.Lists;
    };

    /// <summary>Extends list navigator with its new instance reproductivity functionality.</summary>
    instance.newObject = function(options) {
        return new ListNavigator(options);
    };
    
    instance.composeLists();
}
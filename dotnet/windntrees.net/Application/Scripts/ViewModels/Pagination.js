/// <reference path="knockout-3.0.0.debug.js" />

/**
* Represents page number hyper link in pagination view model.
* @param {Number} a 
*/
function PageLinkViewModel(number) {
    var instance = this;
    instance.Number = number;
}

/**
* Pagination view model used to render paging list with page scroll size.
* @param {Number} currentPage 
* @param {Number} pageSize 
* @param {Number} totalRecords
* @param {Number} scrollSize
*/
function PaginationViewModel(currentPage, pageSize, totalRecords, scrollSize) {
    var instance = this;
    instance.PagesList = ko.observableArray([]);
    instance.ScrollSize = scrollSize; // Number of pages dispalyed

    instance.CurrentPage = currentPage;
    instance.PageSize = pageSize;
    instance.TotalRecords = totalRecords;

    instance.TotalPages = ko.computed(function () {
        return Math.ceil(instance.TotalRecords / instance.PageSize);
    }, self);

    instance.SetPagesList = function () {
        instance.PagesList.removeAll();
        //find the pager scroll size offset to find min and max pages
        var pageOffset = Math.ceil(instance.ScrollSize / 2);
        var minPageNumber = currentPage - pageOffset;
        var maxPageNumber = currentPage + pageOffset;

        if (minPageNumber <= 0) {
            minPageNumber = 1;
        }

        if (minPageNumber + instance.ScrollSize > instance.TotalPages()) {
            maxPageNumber = instance.TotalPages();
        }
        else {
            maxPageNumber = minPageNumber + instance.ScrollSize;

            if (maxPageNumber > instance.TotalPages()) {
                maxPageNumber = instance.TotalPages();
            }
        }
        for (var i = minPageNumber; i <= maxPageNumber; i++) {
            instance.PagesList.push(new PageLinkViewModel(i));
        }
    }
    instance.SetPagesList();
}
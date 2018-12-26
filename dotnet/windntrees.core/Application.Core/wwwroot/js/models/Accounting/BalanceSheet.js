function BalanceSheet(data) {
    var instance = this;

    instance.Assets = ko.observableArray(data.Assets);
    instance.Liabilities = ko.observableArray(data.Liabilities);
    instance.TotalAssets = ko.observable((data.TotalAssets === null || data.TotalAssets === undefined) ? 0 : data.TotalAssets);
    instance.TotalLiabilities = ko.observable((data.TotalLiabilities === null || data.TotalLiabilities === undefined) ? 0 : data.TotalLiabilities);

    instance.Result = ko.computed(function () {
        return instance.TotalAssets() - instance.TotalLiabilities();
    });
}
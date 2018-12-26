function LicenseInfo(data) {
    var instance = this;

    instance._datakey = data.ProductID;
    instance.ProductID = data.ProductID;

    instance.Code = ko.observable(data.Code);
    instance.Code.extend({
        maxLength: 1024
    });

    instance.RowVersion = data.RowVersion;
}
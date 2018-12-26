function LicenseInfo(data) {
    var instance = this;

    instance._datakey = data.ProductId;
    instance.ProductId = data.ProductId;

    instance.Code = ko.observable(data.Code);
    instance.Code.extend({
        maxLength: 1024
    });

    instance.RowVersion = data.RowVersion;
}
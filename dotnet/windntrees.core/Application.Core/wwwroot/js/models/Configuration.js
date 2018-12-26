function Configuration(data) {
    var instance = this;
    instance._datakey = data.Uid;

    instance.Uid = data.Uid;
    instance.KeyParam = ko.observable(data.KeyParam);
    instance.ValParam = ko.observable(data.ValParam);
    instance.RowVersion = data.RowVersion;
}
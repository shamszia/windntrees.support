function Configuration(data) {
    var instance = this;
    instance._datakey = data.UID;

    instance.UID = data.UID;
    instance.KeyParam = ko.observable(data.KeyParam);
    instance.ValParam = ko.observable(data.ValParam);
    instance.RowVersion = data.RowVersion;
}
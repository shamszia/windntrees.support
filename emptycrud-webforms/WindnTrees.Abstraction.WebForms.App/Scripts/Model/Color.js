function Color(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = ko.observable(data.UID);
    instance.Name = ko.observable(data.Name);
    instance.Description = ko.observable(data.Description);
    instance.RowVersion = data.RowVersion;
}
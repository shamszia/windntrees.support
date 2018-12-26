function Color(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 10
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 255
    });

    instance.RowVersion = data.RowVersion;
}
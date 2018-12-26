function Role(data) {
    var instance = this;

    instance._datakey = data.RoleId;

    instance.RoleId = ko.observable(data.RoleId);
    instance.RoleId.extend({
        required: true,
        maxLength: 128
    });

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 256
    });
}
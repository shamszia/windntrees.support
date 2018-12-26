function ApplicationRole(data) {
    var instance = this;

    instance._datakey = data.Id;

    instance.Id = ko.observable(data.Id);
    instance.Id.extend({
        required: true,
        maxLength: 128
    });

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 256
    });

    instance.NormalizedName = ko.observable(data.NormalizedName);
    instance.NormalizedName.extend({
        required: true,
        maxLength: 256
    });

    instance.ConcurrencyStamp = data.ConcurrencyStamp
}
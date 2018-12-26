function SdkComponentMember(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

    instance.Component = data.Component;

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 100
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 2048
    });

    instance.SortOrder = ko.observable(data.SortOrder);

    instance.RowVersion = data.RowVersion;
}
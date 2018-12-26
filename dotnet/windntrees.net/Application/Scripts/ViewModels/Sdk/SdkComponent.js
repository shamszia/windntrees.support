function SdkComponent(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;
    instance.Sdk = data.Sdk;

    instance.RecordTime = data.RecordTime;
    instance.UpdateTime = data.UpdateTime;

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 100
    });

    instance.Reference = ko.observable(data.Reference);
    instance.Reference.extend({
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
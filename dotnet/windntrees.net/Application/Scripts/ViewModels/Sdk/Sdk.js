function Sdk(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

    instance.RecordTime = data.RecordTime;
    instance.UpdateTime = data.UpdateTime;

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 100
    });

    instance.CodeName = ko.observable(data.CodeName);
    instance.CodeName.extend({
        maxLength: 100
    });

    instance.Version = ko.observable(data.Version);
    instance.Version.extend({
        maxLength: 20
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 2048
    });

    instance.RowVersion = data.RowVersion;
}
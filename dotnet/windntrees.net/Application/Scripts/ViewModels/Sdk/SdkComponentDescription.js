function SdkComponentDescription(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

    instance.Component = data.Component;

    instance.RecordTime = data.RecordTime;
    instance.UpdateTime = data.UpdateTime;

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 2048
    });

    instance.SortOrder = ko.observable(data.SortOrder);

    instance.RowVersion = data.RowVersion;
}
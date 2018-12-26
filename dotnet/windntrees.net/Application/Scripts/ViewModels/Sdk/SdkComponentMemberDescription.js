function SdkComponentMemberDescription(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;
    instance.ComponentMember = data.ComponentMember;

    instance.RecordTime = data.RecordTime;
    instance.UpdateTime = data.UpdateTime;

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 100
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 2048
    });

    instance.Code = ko.observable(data.Code);
    instance.Code.extend({
        maxLength: 20480
    });

    instance.SortOrder = ko.observable(data.SortOrder);

    instance.RowVersion = data.RowVersion;
}
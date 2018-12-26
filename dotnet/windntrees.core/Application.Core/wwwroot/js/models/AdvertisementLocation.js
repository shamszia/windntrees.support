function AdvertisementLocation(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.Uid = data.Uid;
    
    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 50
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 255
    });

    instance.RowVersion = data.RowVersion;
}
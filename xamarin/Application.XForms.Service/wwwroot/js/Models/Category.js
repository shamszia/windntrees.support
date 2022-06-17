function Category(data) {
    var instance = this;

    //required for row uniqueness 
    instance._datakey = data.Uid;

    instance.Uid = data.Uid;

    instance.Title = ko.observable(data.Title);
    instance.Title.extend({
        required: true,
        maxLength: 100
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 200
    });

    instance.RowVersion = data.RowVersion;
}
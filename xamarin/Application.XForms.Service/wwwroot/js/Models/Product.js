function Product(data) {
    var instance = this;

    //required for row uniqueness 
    instance._datakey = data.Uid;

    instance.Uid = data.Uid;
    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 100
    });
    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 1024
    });
    instance.Version = ko.observable(data.Version);
    instance.Version.extend({
        maxLength: 100
    });
    instance.Code = ko.observable(data.Code);
    instance.Code.extend({
        maxLength: 100
    });
    instance.LegalCode = ko.observable(data.LegalCode);
    instance.LegalCode.extend({
        maxLength: 100
    });
    instance.ProductYear = ko.observable(data.ProductYear);
    instance.ProductYear.extend({
        maxLength: 4
    });
    instance.Category = ko.observable(data.Category);
    instance.Category.extend({
        maxLength: 50
    });
    instance.Manufacturer = ko.observable(data.Manufacturer);
    instance.Manufacturer.extend({
        maxLength: 50
    });
    instance.Unit = ko.observable(data.Unit);
    instance.Unit.extend({
        maxLength: 50
    });
    instance.Color = ko.observable(data.Color);
    instance.Color.extend({
        maxLength: 50
    });
    instance.Service = ko.observable(data.Service);
    instance.Service.extend({
        maxLength: 50
    });
    instance.Picture = ko.observable(data.Picture);
    instance.Picture.extend({
        maxLength: 50
    });
    instance.RowVersion= data.RowVersion;
}       
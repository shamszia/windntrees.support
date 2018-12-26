function Product(data)
{
    var instance = this;

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

    instance.Manufacturer = ko.observable(data.Manufacturer);
    instance.Category = ko.observable(data.Category);
    instance.Unit = ko.observable(data.Unit);
    instance.Color = ko.observable(data.Color);

    instance.Service = ko.observable(data.Service);

    instance.Picture = ko.observable(data.Picture);
    instance.RowVersion = data.RowVersion;


    instance.BriefName = ko.computed(function () {
        if (instance.Name() !== null && instance.Name() !== undefined) {

            if (instance.Name().length > 50) {

                return (instance.Name().substring(0, 17) + " ...");
            }

            return instance.Name();
        }
    });

    instance.PictureLink = ko.computed(function () {
        return "../../uploads/product/" + instance.Picture();
    });
}
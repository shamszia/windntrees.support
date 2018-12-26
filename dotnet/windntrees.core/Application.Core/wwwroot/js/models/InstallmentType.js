function InstallmentType(data)
{
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 50
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 255
    });

    instance.Unit = ko.observable(data.Unit);
    instance.Unit.extend({
        required: true
    });

    instance.Installments = ko.observable(data.Installments);
    instance.Installments.extend({
        required: true
    });

    instance.RowVersion = data.RowVersion;

    instance.ComputedFunction = ko.computed(function () {
        if (instance.Name() != null) {
            return (instance.Name().length == 50) ? true : false;
        }
        return false;
    });
}
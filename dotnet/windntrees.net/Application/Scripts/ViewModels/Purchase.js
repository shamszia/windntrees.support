function Purchase(data)
{
    var instance = this;
    instance.UID = data.UID;

    instance.OwnerCNIC = ko.observable(data.OwnerCNIC);
    instance.OwnerCNIC.extend({
        required: true,
        minLength: 13,
        maxLength: 13
    });

    instance.OwnerName = ko.observable(data.OwnerName);
    instance.OwnerName.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.CNIC = ko.observable(data.CNIC);
    instance.CNIC.extend({
        required: true,
        minLength: 13,
        maxLength: 13
    });

    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.FName = ko.observable(data.FName);
    instance.FName.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.Address = ko.observable(data.Address);
    instance.Address.extend({
        required: true,
        maxLength: 255
    });

    instance.City = ko.observable(data.City);
    instance.City.extend({
        required: true,
        maxLength: 50
    });

    instance.State = ko.observable(data.State);
    instance.State.extend({
        required: true,
        maxLength: 50
    });

    instance.Country = ko.observable(data.Country);
    instance.Country.extend({
        required: true,
        maxLength: 50
    });

    instance.Phone = ko.observable(data.Phone);
    instance.Phone.extend({
        maxLength: 15
    });

    instance.CellNo = ko.observable(data.CellNo);
    instance.CellNo.extend({
        required: true,
        maxLength: 15
    });

    instance.WitnessCNIC1 = ko.observable(data.WitnessCNIC1);
    instance.WitnessCNIC1.extend({
        required: true,
        minLength: 13,
        maxLength: 13
    });

    instance.WitnessName1 = ko.observable(data.WitnessName1);
    instance.WitnessName1.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.WitnessCNIC2 = ko.observable(data.WitnessCNIC2);
    instance.WitnessCNIC2.extend({
        minLength: 13,
        maxLength: 13
    });

    instance.WitnessName2 = ko.observable(data.WitnessName2);
    instance.WitnessName2.extend({
        minLength: 5,
        maxLength: 50
    });

    instance.RegDate = ko.observable(data.RegDate);
    instance.RegDate.extend({
        required: true
    });

    instance.RegNo = ko.observable(data.RegNo);
    instance.RegNo.extend({
        required: true,
        minLength: 1,
        maxLength: 20
    });

    instance.SerialNo = ko.observable(data.SerialNo);
    instance.SerialNo.extend({
        maxLength: 50
    });

    instance.EngineNo = ko.observable(data.EngineNo);
    instance.EngineNo.extend({
        required: true,
        maxLength: 50
    });

    instance.ChasisNo = ko.observable(data.ChasisNo);
    instance.ChasisNo.extend({
        required: true,
        maxLength: 50
    });

    instance.Manufacturer = ko.observable(data.Manufacturer);
    instance.Category = ko.observable(data.Category);
    instance.HorsePower = ko.observable(data.HorsePower);
    instance.Color = ko.observable(data.Color);

    instance.ModelYear = ko.observable(data.ModelYear);
    instance.ModelYear.extend({
        required: true
    });

    instance.PurchasePrice = ko.observable(data.PurchasePrice);
    instance.PurchasePrice.extend({
        required: true
    });

    instance.PurchaseNote = ko.observable(data.PurchaseNote);

    instance.InStock = ko.observable(data.InStock);

    instance.CnicOk = ko.computed(function () {
        if (instance.CNIC() !== null && instance.CNIC() !== undefined)
        {
            return (instance.CNIC().length === 13) ? true : false;
        }
        return false;
    });

    instance.RegNoOk = ko.computed(function () {
        if (instance.RegNo() !== null && instance.RegNo() !== undefined) {
            return (instance.RegNo().length >= 1) ? true : false;
        }
        return false;
    });
}
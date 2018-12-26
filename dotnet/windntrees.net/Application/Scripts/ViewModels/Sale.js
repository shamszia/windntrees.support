function Sale(data)
{
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

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

    instance.RegDate = ko.observable(data.RegDate);
    instance.RegDate.extend({
        required: true
    });

    instance.RegNo = ko.observable(data.RegNo);
    instance.RegNo.extend({
        required: true,
        minLength: 5,
        maxLength: 20
    });

    instance.SerialNo = ko.observable(data.SerialNo);
    instance.SerialNo.extend({
        maxLength: 50
    });

    instance.EngineNo = ko.observable(data.EngineNo);
    instance.EngineNo.extend({
        maxLength: 50
    });

    instance.ChasisNo = ko.observable(data.ChasisNo);
    instance.ChasisNo.extend({
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

    instance.SalePrice = ko.observable(data.SalePrice);
    instance.SalePrice.extend({
        required: true
    });

    instance.Tax = ko.observable(data.Tax);
    instance.Tax.extend({
        required: true
    });

    instance.SalesNote = ko.observable(data.SalesNote);

    instance.CreditSale = ko.observable(data.CreditSale);
    instance.InstallmentUnit = ko.observable(data.InstallmentUnit);
    instance.Installments = ko.observable(data.Installments);
    instance.InitialPayment = ko.observable(data.InitialPayment);

    instance.RemainingCredit = ko.computed(function () {
        if (instance.CreditSale()) {
            return (instance.SalePrice() - instance.InitialPayment())
        }
        return false;
    });


    instance.CnicOk = ko.computed(function () {
        if (instance.CNIC() !== null && instance.CNIC() !== undefined) {
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
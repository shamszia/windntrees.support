function BusinessTransaction(data)
{
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;

    instance.TransactionTime = ko.observable(data.TransactionTime);

    instance.SellerCNIC = ko.observable(data.SellerCNIC);
    instance.SellerCNIC.extend({
        required: true,
        minLength: 13,
        maxLength: 13
    });

    instance.SellerName = ko.observable(data.SellerName);
    instance.SellerName.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.SellerFName = ko.observable(data.SellerFName);
    instance.SellerFName.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.SellerAddress = ko.observable(data.SellerAddress);
    instance.SellerAddress.extend({
        required: true,        
        maxLength: 255
    });

    instance.SellerCity = ko.observable(data.SellerCity);
    instance.SellerCity.extend({
        required: true,        
        maxLength: 50
    });

    instance.SellerState = ko.observable(data.SellerState);
    instance.SellerState.extend({
        required: true,
        maxLength: 50
    });

    instance.SellerCountry = ko.observable(data.SellerCountry);
    instance.SellerCountry.extend({
        required: true,        
        maxLength: 50
    });

    instance.SellerPhone = ko.observable(data.SellerPhone);
    instance.SellerPhone.extend({        
        maxLength: 15
    });

    instance.SellerCell = ko.observable(data.SellerCell);
    instance.SellerCell.extend({
        required: true,
        maxLength: 15
    });

    instance.ProductUID = data.ProductUID;
    instance.ProductName = ko.observable(data.ProductName);

    instance.ProductOwner = ko.observable(data.ProductOwner);
    instance.OwnerCNIC = ko.observable(data.OwnerCNIC);

    instance.PurchasePrice = ko.observable(data.PurchasePrice);
    instance.PurchasePrice.extend({
        required: true,
        maxLength: 8
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
        required: true,
        minLength: 13,
        maxLength: 13
    });

    instance.WitnessName2 = ko.observable(data.WitnessName2);
    instance.WitnessName2.extend({        
        minLength: 5,
        maxLength: 50
    });

    instance.PurchaseNote = ko.observable(data.PurchaseNote);

    instance.BuyingTime = ko.observable(data.BuyingTime);

    instance.BuyerCNIC = ko.observable(data.BuyerCNIC);
    instance.BuyerCNIC.extend({
        required: true,
        minLength: 13,
        maxLength: 13
    });

    instance.BuyerName = ko.observable(data.BuyerName);
    instance.BuyerName.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.BuyerFName = ko.observable(data.BuyerFName);
    instance.BuyerFName.extend({
        required: true,
        minLength: 5,
        maxLength: 50
    });

    instance.BuyerAddress = ko.observable(data.BuyerAddress);
    instance.BuyerAddress.extend({
        required: true,
        maxLength: 255
    });

    instance.BuyerCity = ko.observable(data.BuyerCity);
    instance.BuyerCity.extend({
        required: true,        
        maxLength: 50
    });

    instance.BuyerState = ko.observable(data.BuyerState);
    instance.BuyerState.extend({
        required: true,
        maxLength: 50
    });

    instance.BuyerCountry = ko.observable(data.BuyerCountry);
    instance.BuyerCountry.extend({
        required: true,        
        maxLength: 50
    });

    instance.BuyerPhone = ko.observable(data.BuyerPhone);
    instance.BuyerPhone.extend({
        maxLength: 15
    });

    instance.BuyerCell = ko.observable(data.BuyerCell);
    instance.BuyerCell.extend({
        required: true,
        maxLength: 15
    });

    instance.SalePrice = ko.observable(data.SalePrice);
    instance.SalePrice.extend({
        required: true,
        maxLength: 8
    });

    instance.Tax = ko.observable(data.Tax);
    instance.Tax.extend({
        required: true,
        maxLength: 8
    });

    instance.CreditSale = ko.observable(data.CreditSale == null ? false : data.CreditSale);
    instance.InstallmentUnit = ko.observable(data.InstallmentUnit == null ? '' : data.InstallmentUnit);
    instance.Installments = ko.observable(data.Installments == null ? 0 : data.Installments);

    instance.Payments = ko.observable((data.Payments == null || data.Payments == 'undefined') ? 0 : data.Payments);

    instance.SalesNote = ko.observable(data.SalesNote);

    instance.Active = ko.observable(data.Active)

    instance.RowVersion = data.RowVersion;

    instance.NotCreditSale = ko.computed(function () {
        return (instance.CreditSale() ? false : true);
    });

    instance.NotActive = ko.computed(function () {
        return (instance.Active() ? false : true);
    });

    instance.Sold = ko.computed(function () {

        if (instance.BuyerCNIC() == undefined)
        {
            return;
        }
        return (instance.BuyerCNIC().length > 0 ? true : false);
    });

    instance.NotSold = ko.computed(function () {

        if (instance.BuyerCNIC() == undefined) {
            return true;
        }
        return (instance.BuyerCNIC().length == 0 ? true : false);
    });

    instance.TotalSalePrice = ko.computed(function () {
        return instance.SalePrice() + instance.Tax();
    });

    instance.Savings = ko.computed(function () {
        var savings = instance.SalePrice() - instance.PurchasePrice();
        if (savings >= 0) {
            return savings;
        }
        else {
            return "[" + savings + "]";
        }
    });

    instance.RemainingPayments = ko.computed(function () {
        if (instance.CreditSale())
        {
            return (instance.SalePrice() + instance.Tax()) - instance.Payments();
        }
        return 0;
    });
}
function Transaction(data) {
    var instance = this;
    instance.UID = data.UID;
    instance.TransactionTime = ko.observable(data.TransactionTime);
    instance.Account = ko.observable(data.Account);
    instance.Particulars = ko.observable(data.Particulars);
    instance.Quantity = ko.observable(data.Quantity);
    instance.DrAmount = ko.observable(data.DrAmount);
    instance.CrAmount = ko.observable(data.CrAmount);
    instance.Status = ko.observable(data.Status);
    instance.RowVersion = data.RowVersion;

    instance.SuccessMessage = ko.observable("");
    instance.ErrorMessage = ko.observable("");
    instance.Processing = ko.observable(false);
}
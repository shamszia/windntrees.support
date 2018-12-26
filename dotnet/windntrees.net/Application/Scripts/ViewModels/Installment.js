function Installment(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;
    instance.TUID = data.TUID;

    instance.InstallmentTime = ko.observable(data.InstallmentTime);
    instance.InstallmentTime.extend({
        required: true
    });

    instance.Amount = ko.observable(data.Amount == null ? 0 : data.Amount);
    instance.Amount.extend({
        required: true
    });

    instance.RowVersion = data.RowVersion;

    instance.FormattedAmount = ko.computed(function () {
        return instance.Amount().toFixed(2);
    });
}
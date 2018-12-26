function AccountSummary(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.Account = ko.observable(data.Account);
    instance.Title = ko.observable(data.Title);
    instance.Debits = ko.observable(data.Debits);
    instance.Credits = ko.observable(data.Credits);

    instance.AccountTitle = ko.computed(function () {
        return instance.Account() + " - " + instance.Title();
    });

    instance.Debits_Credits = ko.computed(function () {
        var result = instance.Debits() - instance.Credits();
        if (result > 0) {

            return result;
        }
        else {
            return  "[" + Math.abs(result) + "]";
        }
    });

    instance.Credits_Debits = ko.computed(function () {
        var result = instance.Credits() - instance.Debits();
        if (result > 0) {

            return result;
        }
        else {
            return "[" + Math.abs(result) + "]";
        }
    });

    instance.RowVersion = data.RowVersion;
}
function TrialBalance(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.Account = ko.observable(data.Account);
    instance.Title = ko.observable(data.Title);
    instance.Debits = ko.observable(data.Debits);
    instance.Credits = ko.observable(data.Credits);

    instance.Balance = ko.computed(function () {
        return instance.Debits() - instance.Credits();
    });

    instance.AccountTitle = ko.computed(function () {
        return instance.Account() + " - " + instance.Title();
    });

    instance.RowVersion = data.RowVersion;
}
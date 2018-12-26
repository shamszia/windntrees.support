function ChartOfAccount(data) {
    var instance = this;

    instance._datakey = data.Uid;
    instance.Uid = data.Uid;

    instance.Account = ko.observable(data.Account);
    instance.Account.extend({
        required: true,
        maxLength: 20
    });

    instance.Title = ko.observable(data.Title);
    instance.Title.extend({
        required: true,
        maxLength: 50
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 255
    });

    instance.AccountTitle = ko.computed(function () {
        return instance.Account() + " - " + instance.Title();
    });

    instance.RowVersion = data.RowVersion;
}
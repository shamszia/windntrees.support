function Transaction(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.Uid = data.Uid;

    instance.TransactionTime = ko.observable(data.TransactionTime);

    instance.CompositeId = ko.observable((data.CompositeId === null || data.CompositeId === undefined) ? (moment(moment.utc(new Date()).toDate()).format('YYYY-MM-DD') + "-Transaction1") : data.CompositeId);

    instance.ReferenceId = ko.observable(data.ReferenceId);
    instance.ReferenceId.extend({
        maxLength: 100
    });

    instance.Reference = ko.observable(data.Reference);
    instance.Reference.extend({
        maxLength: 100
    });
    
    instance.AccountId = ko.observable(data.AccountId);
    instance.AccountId.extend({
        required: true
    });

    instance.AccountNo = ko.observable(data.AccountNo);
    instance.AccountNo.extend({
        required: true,
        maxLength: 20
    });

    instance.Title = ko.observable(data.Title);
    instance.Title.extend({
        required: true,
        maxLength: 50
    });

    instance.Particulars = ko.observable(data.Particulars);    
    instance.Particulars.extend({
        required: true,
        maxLength: 1000
    });

    instance.DrAmount = ko.observable(data.DrAmount);
    instance.DrAmount.extend({
        required: true,
        maxLength: 10
    });

    instance.CrAmount = ko.observable(data.CrAmount);
    instance.CrAmount.extend({
        required: true,
        maxLength: 10
    });

    instance.Quantity = ko.observable((data.Quantity !== null && data.Quantity !== undefined) ? data.Quantity : 1);
    instance.Quantity.extend({
        required: true
    });

    instance.Active = ko.observable(data.Active);
    instance.Username = ko.observable(data.Username);

    instance.LocalTransactionTime = ko.computed(function() {

        return new DateParser().parseDate(instance.TransactionTime(), true).toString('yyyy-MM-dd HH:mm:ss');
    });

    instance.RowVersion = data.RowVersion;
}
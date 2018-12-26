function CompositeTransaction(data) {
    var instance = this;

    instance.Transactions = ko.observableArray(data.Transactions);

    instance.AddTransaction = function (transaction) {
        instance.Transactions.push(transaction);
    };

    instance.RemoveTransaction = function (transaction) {
        instance.Transactions.remove(transaction);
    };

    instance.RowVersion = data.RowVersion;
}
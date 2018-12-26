function AccountTransaction(data) {
    var instance = this;

    instance._datakey = data.UId;
    instance.UId = data.UId;

    instance.AccountBalances = (data.AccountBalances !== null && data.AccountBalances !== undefined) ? data.AccountBalances : [];

    instance.addAccount = function (account) {

        instance.AccountBalances.push(account);
    };

    instance.RowVersion = data.RowVersion;
}
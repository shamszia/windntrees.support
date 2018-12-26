function AccountBalance(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.Uid = data.Uid;

    instance.Reference = data.Reference;
    instance.ReferenceId = data.ReferenceId;
    instance.Particulars = data.Particulars;

    instance.Account = data.Account;
    instance.Title = data.Title;
    instance.Debit = data.Debit;
    instance.Credit = data.Credit;

    instance.RowVersion = data.RowVersion;
}
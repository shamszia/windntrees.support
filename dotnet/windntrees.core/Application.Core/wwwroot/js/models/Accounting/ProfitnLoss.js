function ProfitnLoss(data) {
    var instance = this;

    instance.Revenues = ko.observableArray(data.Revenues);
    instance.Expenses = ko.observableArray(data.Expenses);
    instance.TotalRevenue = ko.observable((data.TotalRevenue === null || data.TotalRevenue === undefined) ? 0 : data.TotalRevenue);
    instance.TotalExpense = ko.observable((data.TotalExpense === null || data.TotalExpense === undefined) ? 0 : data.TotalExpense);

    instance.Result = ko.computed(function () {
        return instance.TotalRevenue() - instance.TotalExpense();
    });
}
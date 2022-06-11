function Employee(data) {
    var instance = this;

    instance._datakey = data.Id;

    instance.Id = ko.observable(data.Id);
    instance.Name = ko.observable(data.Name);
    instance.Salary = ko.observable(data.Salary);
    instance.Designation = ko.observable(data.Designation);
}
function Role(data) {
    var instance = this;
    instance.Id = ko.observable(data.Id);
    instance.Name = ko.observable((data.Name !== null && data.Name !== undefined) ? data.Name : data.Id);
    instance.NormalizedName = ko.observable(data.NormalizedName);
    instance.ConcurrencyStamp = data.ConcurrencyStamp;
}
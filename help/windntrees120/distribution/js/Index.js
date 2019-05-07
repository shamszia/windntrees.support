function Index(data) {
    var instance = this;
    instance._datakey = data.Id;

    instance.Id = data.Id
    instance.Title = data.Title;
    instance.Description = data.Description;
    instance.Url = data.Url;
    instance.Author = data.Author;
    instance.Company = data.Company;
    instance.Copyright = data.Copyright;



    instance.Namespaces = data.Namespaces;
    instance.Components = data.Components;
}
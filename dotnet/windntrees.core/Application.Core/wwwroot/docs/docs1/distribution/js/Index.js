function Index(data) {
    var instance = this;
    instance._datakey = data.Id;

    instance.Id = data.Id
    instance.Title = data.Title;
    instance.Description = data.Description;
    instance.Url = data.Url;
    instance.Namespaces = data.Namespaces;
    instance.Classes = data.Classes;
}
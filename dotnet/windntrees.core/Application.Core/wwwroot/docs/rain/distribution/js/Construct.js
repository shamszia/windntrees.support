function Construct(data) {
    var instance = this;
    instance._datakey = data.Namespace + ((data.Namespace !== null && data.Namespace !== undefined)? "." : "") + data.Class;

    instance.Id = data.Namespace + ((data.Namespace !== null && data.Namespace !== undefined) ? "." : "") + data.Class;

    instance.Namespace = data.Namespace;
    instance.Class = data.Class;
    instance.Attributes = data.Attributes;
    instance.Properties = data.Properties;
    instance.Constructors = data.Constructors;
    instance.Functions = data.Functions;
}
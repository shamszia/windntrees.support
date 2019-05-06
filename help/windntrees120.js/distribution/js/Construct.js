function Construct(data) {
    var instance = this;
    instance._datakey = data.Id;
    instance.Id = data.Id;

    instance.Scope = data.Scope;
    instance.Constraint = data.Constraint;
    instance.Partial = data.Partial;
    instance.Type = data.Type;
    instance.Name = data.Name;
    instance.Description = data.Description;
    instance.Comments = data.Comments;
    instance.Annotations = data.Annotations;

    instance.Constructs = data.Constructs;
}
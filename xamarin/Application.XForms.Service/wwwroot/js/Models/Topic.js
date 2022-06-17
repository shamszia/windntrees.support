function Topic(data) {
    var instance = this;

    //required for row uniqueness 
    instance._datakey = data.Uid;

    instance.Uid = data.Uid;

    instance.CategoryId = ko.observable(data.CategoryId);
    instance.CategoryId.extend({
        required: true
    });

    instance.SkillLevelId = ko.observable(data.SkillLevelId);
    instance.SkillLevelId.extend({
        required: true
    });

    instance.RecordTime = ko.observable(data.RecordTime);
    instance.UpdateTime = ko.observable(data.UpdateTime);

    instance.Menu = ko.observable(data.Menu);
    instance.Menu.extend({
        required: true,
        maxLength: 100
    });

    instance.Subject = ko.observable(data.Subject);
    instance.Subject.extend({
        required: true,
        maxLength: 100
    });

    instance.Description1 = ko.observable(data.Description1);
    instance.Description1.extend({
        maxLength: 200
    });

    instance.Description2 = ko.observable(data.Description2);
    instance.Description2.extend({
        maxLength: 200
    });

    instance.Active = ko.observable(data.Active);

    instance.RowVersion = data.RowVersion;

    //category reference object
    instance.Category = data.Category;
    //skill level reference object
    instance.SkillLevel = data.SkillLevel;
}
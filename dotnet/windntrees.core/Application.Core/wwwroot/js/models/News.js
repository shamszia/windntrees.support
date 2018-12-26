function News(data) {
    var instance = this;

    instance._datakey = data.UID;

    instance.UID = data.UID;
    instance.NewsTime = data.NewsTime;

    instance.Subject = ko.observable(data.Subject);
    instance.Subject.extend({
        required: true,
        maxLength: 100
    });

    instance.Detail = ko.observable(data.Detail);
    instance.Detail.extend({
        required: true,
        maxLength: 1024
    });

    instance.Source = ko.observable(data.Source);
    instance.Source.extend({
        maxLength: 100
    });

    instance.ImageFile = ko.observable(data.ImageFile);

    instance.WebLink = ko.observable(data.WebLink);
    instance.WebLink.extend({
        maxLength: 512
    });

    instance.IsApproved = ko.observable(data.IsApproved);
    instance.ApprovedBy = ko.observable(data.ApprovedBy);
    instance.RowVersion = data.RowVersion;

    instance.ItemDetail = ko.computed(function () {
        if (typeof instance.Detail() != "undefined")
        {
            if (instance.Detail().length > 150) {
                return (instance.Detail().substring(0, 150) + " ...");
            }
        }
        return "";
    });

    instance.TitleDetail = ko.computed(function () {
        if (typeof instance.Detail() != "undefined")
        {
            if (instance.Detail().length > 300) {
                return (instance.Detail().substring(0, 300) + " ...");
            }
        }
        return "";
    });

    instance.gridurl = ko.computed(function () {
        return "../../uploads/news/" + instance.ImageFile();
    });
}
function Advertisement(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.RecordTime = data.RecordTime;
    instance.UpdateTime = data.UpdateTime;

    instance.Uid = data.Uid;
    instance.ReferenceId = data.ReferenceId;

    instance.Heading = ko.observable(data.Heading);
    instance.Heading.extend({
        required: true,
        maxLength: 100
    });

    instance.SubHeading = ko.observable(data.SubHeading);
    instance.SubHeading.extend({
        required: true,
        maxLength: 100
    });

    instance.Detail = ko.observable(data.Detail);
    instance.Detail.extend({
        required: true,
        maxLength: 1024
    });

    instance.Picture = ko.observable(data.Picture);
    instance.Video = ko.observable(data.Video);

    instance.Link1 = ko.observable(data.Link1);
    instance.Link1.extend({
        maxLength: 512
    });

    instance.Link2 = ko.observable(data.Link2);
    instance.Link2.extend({
        maxLength: 512
    });

    instance.Source = ko.observable(data.Source);

    instance.Page = ko.observable(data.Page);
    instance.Location = ko.observable(data.Location);
    instance.SortOrder = ko.observable(data.SortOrder);

    instance.News = ko.observable(data.News);
    instance.Enabled = ko.observable(data.Enabled);

    instance.RowVersion = data.RowVersion;

    instance.BriefHeading = ko.computed(function () {
        if (instance.Heading() !== null && instance.Heading() !== undefined) {

            if (instance.Heading().length > 50) {

                return (instance.Heading().substring(0, 50) + " ...");
            }

            return instance.Heading();
        }
    });

    instance.BriefDetail = ko.computed(function () {
        if (instance.Detail() !== null && instance.Detail() !== undefined) {

            if (instance.Detail().length > 150) {

                return (instance.Detail().substring(0, 150) + " ...");
            }

            return instance.Detail();
        }
    });

    instance.LatestDetail = ko.computed(function () {

        if (instance.Detail() !== null && instance.Detail() !== undefined) {
            if (instance.Detail().length > 300) {

                return (instance.Detail().substring(0, 300) + " ...");
            }

            return instance.Detail();
        }
    });

    instance.PictureLink = ko.computed(function () {
        return "/uploads/image/" + instance.Picture();
    });

    instance.VideoLink = ko.computed(function () {
        return "/uploads/video/" + instance.Video();
    });
}
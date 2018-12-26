function Reference(data) {
    var instance = this;

    instance._datakey = data.Uid;

    instance.Uid = data.Uid;
    instance.ReferenceId = data.ReferenceId;
    
    instance.Name = ko.observable(data.Name);
    instance.Name.extend({
        required: true,
        maxLength: 100
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 1024
    });

    instance.ContentFile = ko.observable(data.ContentFile);
    instance.Size = ko.observable(data.Size);

    instance.Readable = ko.observable(data.Readable);
    instance.Picture = ko.observable(data.Picture);
    instance.AudioVideo = ko.observable(data.AudioVideo);
    instance.Download = ko.observable(data.Download);

    instance.RowVersion = data.RowVersion;

    instance.DownloadLink = ko.computed(function () {

        if (instance.Download() !== null && instance.Download() !== undefined) {

            if (instance.Download()) {

                if (instance.Readable()) {

                    return "/uploads/readable/" + instance.ContentFile();
                }

                else if (instance.Picture()) {

                    return "/uploads/image/" + instance.ContentFile();
                }

                else if (instance.AudioVideo()) {

                    return "/uploads/video/" + instance.ContentFile();
                }
            }
        }

        return "#";
    });

}
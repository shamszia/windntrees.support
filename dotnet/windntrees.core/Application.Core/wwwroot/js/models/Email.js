function Email(data) {
    var instance = this;

    instance.FromName = ko.observable(data.FromName);
    instance.FromName.extend({
        required: true,
        maxLength: 50
    });
    instance.FromEmail = ko.observable(data.FromEmail);
    instance.FromEmail.extend({
        required: true,
        email: true,
        maxLength: 100
    });

    instance.Subject = ko.observable(data.Subject);
    instance.Subject.extend({
        required: true,
        maxLength: 100
    });

    instance.Message = ko.observable(data.Message);
    instance.Message.extend({
        required: true,
        maxLength: 500
    });

    //instance.Captcha = ko.observable(data.Captcha);
    //instance.Captcha.extend({
    //    required: { message: 'Please type in characters as shown in image.' },
    //    maxLength: 20
    //});
}
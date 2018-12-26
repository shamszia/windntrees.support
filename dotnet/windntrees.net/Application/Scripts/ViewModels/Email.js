function Email(data) {
    var instance = this;

    instance.FromName = ko.observable(data.FromName);
    instance.FromName.extend({
        required: { message: 'Please enter your name here.' },
        maxLength: 50
    });
    instance.FromEmail = ko.observable(data.FromEmail);
    instance.FromEmail.extend({
        required: { message: 'Please enter your email here.' },
        email: true,
        maxLength: 100
    });

    instance.Subject = ko.observable(data.Subject);
    instance.Subject.extend({
        required: { message: 'Please enter your subject here.' },
        maxLength: 100
    });

    instance.Message = ko.observable(data.Message);
    instance.Message.extend({
        required: { message: 'Please enter your message here.' },
        maxLength: 500
    });

    instance.Captcha = ko.observable(data.Captcha);
    instance.Captcha.extend({
        required: { message: 'Please type in characters as shown in image.' },
        maxLength: 20
    });
}
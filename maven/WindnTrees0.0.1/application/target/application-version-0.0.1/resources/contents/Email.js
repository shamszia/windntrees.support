function Email(data) {
    var self = this;

    self.fromName = ko.observable(data.fromName);
    self.fromName.extend({
        required: true,
        maxLength: 50
    });
    self.fromEmail = ko.observable(data.fromEmail);
    self.fromEmail.extend({
        required: true,
        email: true,
        maxLength: 100
    });

    self.subject = ko.observable(data.subject);
    self.subject.extend({
        required: true,
        maxLength: 100
    });

    self.message = ko.observable(data.message);
    self.message.extend({
        required: true,
        maxLength: 500
    });

    self.captcha = ko.observable(data.captcha);
    self.captcha.extend({
        required: true,
        maxLength: 20
    });

    self.Successmessage = ko.observable("");
    self.Errormessage = ko.observable("");
    self.Processing = ko.observable(false);
    
    self.newObject = function(data){
        return new Email(data);
    };
}
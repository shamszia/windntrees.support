function User(data) {
    var instance = this;

    instance._datakey = data.Id;

    instance.Id = data.Id;

    instance.UserName = ko.observable(data.UserName);
    instance.UserName.extend({
        required: true,
        minLength: 6,
        maxLength: 32
    });

    instance.FirstName = ko.observable(data.FirstName);
    instance.FirstName.extend({
        required: true,
        minLength: 3,
        maxLength: 50
    });

    instance.LastName = ko.observable(data.LastName);
    instance.LastName.extend({
        maxLength: 50
    });

    instance.Password = ko.observable(data.Password);
    instance.Password.extend({
        required: true,
        minLength: 8,
        maxLength: 32
    });

    instance.ConfirmPassword = ko.observable();
    instance.ConfirmPassword.extend({
        areSame: instance.Password
    });

    instance.Sex = ko.observable(data.Sex);

    instance.Gender = ko.computed(function () {
        if (typeof instance.Sex() === 'undefined') {
            return "";
        }
        return instance.Sex() === "m" ? "male" : instance.Sex() === "f" ? "female" : "";
    });

    instance.Title = ko.observable(data.Title);

    instance.Email = ko.observable(data.Email);
    instance.Email.extend({
        required: true,
        email: true
    });

    instance.EmailConfirmed = ko.observable(data.EmailConfirmed);

    instance.ImageFile = ko.observable(data.ImageFile);

    instance.Package = ko.observable(data.Package);

    instance.CreationDate = ko.observable(data.CreationDate);
    instance.ExpiryDate = ko.observable(data.ExpiryDate);

    instance.Captcha = ko.observable();
    instance.SecurityStamp = ko.observable(data.SecurityStamp);

    instance.IsApproved = ko.observable(data.IsApproved);
    instance.ApprovedBy = ko.observable(data.ApprovedBy);
    instance.RowVersion = data.RowVersion;

    instance.Roles = ko.observableArray(data.Roles);

    instance.gridurl = ko.computed(function () {

        return "/uploads/users/" + instance.ImageFile();
    });
}

function UserEdit(data) {
    var instance = this;

    instance._datakey = data.Id;
    instance.Id = data.Id;

    instance.UserName = ko.observable(data.UserName);
    instance.UserName.extend({
        required: true,
        minLength: 6,
        maxLength: 32
    });

    instance.FirstName = ko.observable(data.FirstName);
    instance.FirstName.extend({
        required: true,
        minLength: 3,
        maxLength: 50
    });
    instance.LastName = ko.observable(data.LastName);
    instance.LastName.extend({
        maxLength: 50
    });

    instance.Sex = ko.observable(data.Sex);

    instance.Gender = ko.computed(function () {
        if (typeof instance.Sex() === undefined) {
            return "";
        }
        return instance.Sex() === "m" ? "male" : instance.Sex() === "f" ? "female" : "";
    });

    instance.Title = ko.observable(data.Title);

    instance.Email = ko.observable(data.Email);
    instance.Email.extend({
        required: true,
        email: true
    });

    instance.EmailConfirmed = ko.observable(data.EmailConfirmed);

    instance.ImageFile = ko.observable(data.ImageFile);

    instance.Package = ko.observable(data.Package);

    instance.CreationDate = ko.observable(data.CreationDate);
    instance.ExpiryDate = ko.observable(data.ExpiryDate);

    instance.IsApproved = ko.observable(data.IsApproved);
    instance.ApprovedBy = ko.observable(data.ApprovedBy);
    instance.RowVersion = data.RowVersion;

    instance.Roles = ko.observableArray();

    if (data.Roles != null) {
        for (var i = 0; i < data.Roles.length; i++) {
            instance.Roles.push(new Role(data.Roles[i]));
        }
    }

    instance.gridurl = ko.computed(function () {
        return "/uploads/users/" + instance.ImageFile();
    });
}

function UserEditModel(data) {
    var instance = this;

    instance._datakey = data.Id;
    instance.Id = data.Id;

    instance.FirstName = ko.observable(data.FirstName);
    instance.FirstName.extend({
        required: true,
        minLength: 3,
        maxLength: 50
    });

    instance.LastName = ko.observable(data.LastName);
    instance.LastName.extend({
        maxLength: 50
    });

    instance.Sex = ko.observable(data.Sex);

    instance.Gender = ko.computed(function () {
        if (typeof instance.Sex() === undefined) {
            return "";
        }
        return instance.Sex() === "m" ? "male" : instance.Sex() === "f" ? "female" : "";
    });

    instance.Title = ko.observable(data.Title);

    instance.Email = ko.observable(data.Email);
    instance.Email.extend({
        required: true,
        email: true
    });

    instance.ImageFile = ko.observable(data.ImageFile);

    instance.gridurl = ko.computed(function () {

        return "/uploads/users/" + instance.ImageFile();
    });
}
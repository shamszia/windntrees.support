function Company(data)
{
    //UID,LegalCode,NTN,STRN,LegalName,CompanyType,Description,Director,Secretary,Address,City,State,Country,Phone1,Phone2,Cell1,Cell2,Email,PaidUpCapital,Currency,ContactPerson,ContactPersonDesignation,ContactPersonPhone,ContactPersonCell,ContactPersonEmail,RowVersion
    var instance = this;

    instance._datakey = data.Uid;
    instance.Uid = data.Uid;

    instance.LegalCode = ko.observable(data.LegalCode);
    instance.LegalCode.extend({
        required: true,
        maxLength: 100
    });

    instance.Ntn = ko.observable(data.Ntn);
    instance.Ntn.extend({
        maxLength: 100
    });

    instance.Strn = ko.observable(data.Strn);
    instance.Strn.extend({
        maxLength: 100
    });

    instance.LegalName = ko.observable(data.LegalName);
    instance.LegalName.extend({
        required: true,
        maxLength: 255
    });

    //CompanyType,Description,Director,Secretary,Address,City,State,Country,Phone1,Phone2,Cell1,Cell2,Email,

    instance.CompanyType = ko.observable(data.CompanyType);
    instance.CompanyType.extend({
        maxLength: 100
    });

    instance.Description = ko.observable(data.Description);
    instance.Description.extend({
        maxLength: 1024
    });

    instance.Director = ko.observable(data.Director);
    instance.Director.extend({
        maxLength: 100
    });

    instance.Secretary = ko.observable(data.Secretary);
    instance.Secretary.extend({
        maxLength: 100
    });

    instance.Address = ko.observable(data.Address);
    instance.Address.extend({
        maxLength: 255
    });

    instance.City = ko.observable(data.City);
    instance.City.extend({
        maxLength: 100
    });

    instance.State = ko.observable(data.State);
    instance.State.extend({
        maxLength: 100
    });

    instance.Country = ko.observable(data.Country);
    instance.Country.extend({
        maxLength: 100
    });

    instance.Phone1 = ko.observable(data.Phone1);
    instance.Phone1.extend({
        maxLength: 20
    });

    instance.Phone2 = ko.observable(data.Phone2);
    instance.Phone2.extend({
        maxLength: 20
    });

    instance.Cell1 = ko.observable(data.Cell1);
    instance.Cell1.extend({
        maxLength: 20
    });

    instance.Cell2 = ko.observable(data.Cell2);
    instance.Cell2.extend({
        maxLength: 20
    });

    instance.Email = ko.observable(data.Email);
    instance.Email.extend({
        maxLength: 128
    });

    //PaidUpCapital,Currency,ContactPerson,ContactPersonDesignation,ContactPersonPhone,ContactPersonCell,ContactPersonEmail,RowVersion

    instance.PaidUpCapital = ko.observable(data.PaidUpCapital);
    instance.PaidUpCapital.extend({
        maxLength: 10
    });

    instance.Currency = ko.observable(data.Currency);
    instance.Currency.extend({
        maxLength: 10
    });

    instance.ContactPerson = ko.observable(data.ContactPerson);
    instance.ContactPerson.extend({
        maxLength: 100
    });

    instance.ContactPersonDesignation = ko.observable(data.ContactPersonDesignation);
    instance.ContactPersonDesignation.extend({
        maxLength: 100
    });

    instance.ContactPersonPhone = ko.observable(data.ContactPersonPhone);
    instance.ContactPersonPhone.extend({
        maxLength: 20
    });

    instance.ContactPersonCell = ko.observable(data.ContactPersonCell);
    instance.ContactPersonCell.extend({
        maxLength: 20
    });

    instance.ContactPersonEmail = ko.observable(data.ContactPersonEmail);
    instance.ContactPersonEmail.extend({
        maxLength: 128
    });

    instance.RowVersion = data.RowVersion;
}
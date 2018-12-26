/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
function CountryLanguage(data) {
    var instance = this;
    instance._datakey = data.countryCode + "/" + data.language;
    
    instance.countryCode = ko.observable(data.countryCode);
    instance.countryCode.extend({maxLength: 3});
    
    instance.language = ko.observable(data.language);
    instance.language.extend({maxLength: 30});
    instance.isOfficial = ko.observable(data.isOfficial);
    instance.isOfficial.extend({maxLength: 1});
    instance.percentage = ko.observable(data.percentage);
    instance.percentage.extend({maxLength: 4});
    
    instance.country = ko.observable(data.country);
}
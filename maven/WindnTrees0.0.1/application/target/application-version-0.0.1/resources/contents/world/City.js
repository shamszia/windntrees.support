/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
function City(data) {
    var instance = this;
    
    instance._datakey = data.id;
    
    instance.id = ko.observable(data.id);
    instance.name = ko.observable(data.name);
    instance.name.extend({maxLength: 35});
    instance.district = ko.observable(data.district);
    instance.district.extend({maxLength: 20});
    instance.population = ko.observable(data.population);
    instance.population.extend({maxLength: 10});
    
    instance.countryCapital = ko.observable(data.countryCapital);
    instance.country = ko.observable(data.country);
}


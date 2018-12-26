/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

function Country(data) {
    var instance = this;
    
    instance._datakey = data.code;
    
    instance.code = ko.observable(data.code);
    instance.code.extend({required: true, maxLength: 3});
    instance.code2 = ko.observable(data.code2);
    instance.code2.extend({required: true, maxLength: 2});
    
    instance.name = ko.observable(data.name);
    instance.name.extend({required: true, maxLength: 52});
    instance.localName = ko.observable(data.localName);
    instance.localName.extend({required: true, maxLength: 45});
    instance.governmentForm = ko.observable(data.governmentForm);
    instance.governmentForm.extend({required: true, maxLength: 45});
    instance.headOfState = ko.observable(data.headOfState);
    instance.headOfState.extend({maxLength: 60});
    
    instance.continent = ko.observable(data.continent);
    instance.continent.extend({required: true, maxLength: 13});
    instance.region = ko.observable(data.region);
    instance.region.extend({required: true, maxLength: 26});
    
    instance.surfaceArea = ko.observable(data.surfaceArea);
    instance.surfaceArea.extend({required: true, maxLength: 10});
    instance.population = ko.observable(data.population);
    instance.population.extend({required: true, maxLength: 11});
    
    instance.indepYear = ko.observable(data.indepYear);
    instance.indepYear.extend({maxLength: 4});
    
    instance.lifeExpectancy = ko.observable(data.lifeExpectancy);
    instance.lifeExpectancy.extend({maxLength: 5});
    
    instance.gnp = ko.observable(data.gnp);
    instance.gnp.extend({maxLength: 10});
    
    instance.gnpold = ko.observable(data.gnpold);
    instance.gnpold.extend({maxLength: 10});
    
    instance.capital = ko.observable(data.capital);
    instance.capital.extend({maxLength: 11});
    
    instance.cityCapital = ko.observable(data.cityCapital);
}

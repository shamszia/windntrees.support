/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.controllers.world;

import windntrees.CRUDController;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import data.world.CityRepository;
import windntrees.CRUDInterface;
import windntrees.CRUDSource;
import data.world.Country;
import data.world.CountryRepository;

/**
 *
 * @author shams
 */
@Controller
@RequestMapping(value = {"/world/country", "/world/country/index"})
public class World extends CRUDController<Country> {
    
    @Autowired
    CountryRepository countryRepository;
    
    @Autowired
    CityRepository cityRepository;
    
    @Override
    protected CRUDInterface<Country> getRepository() {
        return (CRUDInterface<Country>) new CRUDSource<Country> (countryRepository) ;
    }

    @Override
    protected Country generateNewKey(Country object) {
        return object;
    }

    
    @Override
    protected Country postCreate(Country object) {
        
        if (object.getCityCapital() != null) {
            object.getCityCapital().setCountry(null);
            object.getCityCapital().setCountryCapital(null);
        }
        
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected Country postUpdate(Country object) {
        
        if (object.getCityCapital() != null) {
            object.getCityCapital().setCountry(null);
            object.getCityCapital().setCountryCapital(null);
        }
        
        return object; //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    protected Country postRead(Country object) {
        
        if (object.getCityCapital() != null) {
            object.getCityCapital().setCountry(null);
            object.getCityCapital().setCountryCapital(null);
        }
        
        return object; //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    protected Page<Country> postRead(Page<Country> page) {
        
        for (int i = 0; i < page.getContent().size(); i++) {

            if (page.getContent().get(i).getCityCapital() != null) {
                page.getContent().get(i).getCityCapital().setCountry(null);
                page.getContent().get(i).getCityCapital().setCountryCapital(null);
            }

        }
        
        return page; //To change body of generated methods, choose Tools | Templates.
    }
    
    
    @RequestMapping(method = RequestMethod.GET)
    public String index(Model model)
    {
        return "world/country";
    }
    
}

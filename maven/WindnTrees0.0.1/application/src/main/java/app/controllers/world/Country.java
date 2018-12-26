/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.controllers.world;

import javax.validation.Valid;
import windntrees.CRUDController;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.http.HttpEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.Errors;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import windntrees.data.ResultObject;
import data.world.City;
import windntrees.CRUDInterface;
import windntrees.CRUDSource;
import data.world.CityRepository;

/**
 *
 * @author shams
 */
@Controller
@RequestMapping(value = {"/world/city", "/world/city/index"})
public class Country extends CRUDController<City> {
    
    @Autowired
    CityRepository cityRepository;
    
    @Override
    protected CRUDInterface<City> getRepository() {
        return (CRUDInterface<City>) new CRUDSource<City> (cityRepository) ;
    }

    @Override
    protected City generateNewKey(City object) {
        return object;
    }
    
    @RequestMapping(method = RequestMethod.GET)
    public String index(Model model)
    {
        return "world/country";
    }

    @Override
    protected City postCreate(City object) {
        if (object.getCountry() != null) {
            object.getCountry().setCityCapital(null);
        }
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected City postUpdate(City object) {
        if (object.getCountry() != null) {
            object.getCountry().setCityCapital(null);
        }
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected City postRead(City object) {
        if (object.getCountry() != null) {
            object.getCountry().setCityCapital(null);
        }
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected Page<City> postRead(Page<City> page) {
        
        for (int i = 0; i < page.getContent().size(); i++) {
            if (page.getContent().get(i).getCountry() != null) {
                page.getContent().get(i).getCountry().setCityCapital(null);
            }

            if (page.getContent().get(i).getCountryCapital() != null) {
                page.getContent().get(i).getCountryCapital().setCityCapital(null);
            }
        }
        
        return page; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected Page<City> postSelect(Page<City> page) {
        
        for (int i = 0; i < page.getContent().size(); i++) {

            if (page.getContent().get(i).getCountry() != null) {
                page.getContent().get(i).getCountry().setCityCapital(null);
            }

            if (page.getContent().get(i).getCountryCapital() != null) {
                page.getContent().get(i).getCountryCapital().setCityCapital(null);
            }

        }
        
        return page; //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    public HttpEntity<ResultObject> create(@Valid @RequestBody City objectForm, 
            Errors errors) {
        
        if(objectForm.getCountryCapital() != null) {
            //if country capital reference is set then clear existing country city capitals
            cityRepository.clearCapital(objectForm.getCountryCapital().getCode());
        }
        
        return super.create(objectForm, errors); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public HttpEntity<ResultObject> update(@Valid @RequestBody City objectForm, 
            Errors errors) {
        
        if(objectForm.getCountryCapital() != null) {
            //if country capital reference is set then clear existing country city capitals
            cityRepository.clearCapital(objectForm.getCountryCapital().getCode());
        }
        
        return super.update(objectForm, errors); //To change body of generated methods, choose Tools | Templates.
    }
    
}

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
import data.world.CountryLanguage;
import windntrees.CRUDInterface;
import windntrees.CRUDSource;
import data.world.CountryLanguageRepository;

/**
 *
 * @author shams
 */
@Controller
@RequestMapping(value = {"/world/language", "/world/language/index"})
public class Language extends CRUDController<CountryLanguage> {
    
    @Autowired
    CountryLanguageRepository countryLanguageRepository;
    
    @Override
    protected CRUDInterface<CountryLanguage> getRepository() {
        return (CRUDInterface<CountryLanguage>) new CRUDSource<CountryLanguage> (countryLanguageRepository) ;
    }

    @Override
    protected CountryLanguage generateNewKey(CountryLanguage object) {
        return object;
    }
    
    @RequestMapping(method = RequestMethod.GET)
    public String index(Model model)
    {
        return "world/country";
    }
    
    @Override
    protected CountryLanguage postCreate(CountryLanguage object) {
        if (object.getCountry() != null) {
            object.setCountry(null);
        }
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected CountryLanguage postUpdate(CountryLanguage object) {
        if (object.getCountry() != null) {
            object.setCountry(null);
        }
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected CountryLanguage postRead(CountryLanguage object) {
        if (object.getCountry() != null) {
            object.setCountry(null);
        }
        return object; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected Page<CountryLanguage> postRead(Page<CountryLanguage> page) {
        
        for (int i = 0; i < page.getContent().size(); i++) {
            if (page.getContent().get(i).getCountry() != null) {
                page.getContent().get(i).setCountry(null);
            }
        }
        return page; //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected Page<CountryLanguage> postSelect(Page<CountryLanguage> page) {
        
        for (int i = 0; i < page.getContent().size(); i++) {

            if (page.getContent().get(i).getCountry() != null) {
                page.getContent().get(i).setCountry(null);
            }
        }
        return page; //To change body of generated methods, choose Tools | Templates.
    }
}

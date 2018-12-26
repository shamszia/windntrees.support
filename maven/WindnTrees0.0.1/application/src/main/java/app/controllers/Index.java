/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.controllers;

import windntrees.BasicController;
import windntrees.data.SearchFilter;
import windntrees.data.UserInfo;
import javax.validation.Valid;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

/**
 *
 * @author shams
 */
@Controller
@RequestMapping(value = {"/", "/index"})
public class Index extends BasicController {

    @RequestMapping(method = RequestMethod.GET)
    public String index(Model model) {
        
        SearchFilter filterObject = new SearchFilter("", 10, 1);
        
        model.addAttribute("welcome", getWelcomeMessage());
        model.addAttribute("webappTitle", getWebAppProperties().getTitle());
        model.addAttribute("objectForm", filterObject);
        model.addAttribute("userInfo", new UserInfo());

        return "index";
    }

    @RequestMapping(method = RequestMethod.POST)
    public String index(Model model,
            @Valid @ModelAttribute("objectForm") SearchFilter objectForm,
            BindingResult result) {
        if (result.hasErrors()) {
            model.addAttribute("result", getStandardErrMessage());
        } else {
            model.addAttribute("result", getStandardOkMessage());
        }
        return "index";
    }

    @RequestMapping(value = "/navs", method = RequestMethod.GET)
    public String menu(Model model) {
        model.addAttribute("welcome", getWelcomeMessage());
        model.addAttribute("webappTitle", getWebAppProperties().getTitle());
        model.addAttribute("objectForm", new SearchFilter("", 10, 1));
        model.addAttribute("userInfo", new UserInfo());
        return "index";
    }

    @RequestMapping(value = "/navs", method = RequestMethod.POST)
    public String menu(Model model,
            @Valid @ModelAttribute("userInfo") UserInfo userInfo,
            BindingResult result) {

        if (result.hasErrors()) {
            model.addAttribute("result", getStandardErrMessage());
        } else {

            try {
                
                /*
                if (userInfo.getAuthenticatedUser() != null) {
                    if(userInfo.getAuthenticatedUser().trim().isEmpty()) {
                        userInfo.setAuthenticatedUser(null);
                    }
                }
                
                if (userInfo.getAuthenticatedRoles() != null) {
                    if (userInfo.getAuthenticatedRoles().trim().isEmpty()) {
                        userInfo.setAuthenticatedRoles(null);
                    }
                }*/
                
                session.setAttribute("userInfo", userInfo);
            } catch (Exception ex) {
                logger.error(ex.getMessage());
            }
            model.addAttribute("result", getStandardOkMessage());
        }
        model.addAttribute("objectForm", new SearchFilter("", 10, 1));
        model.addAttribute("userInfo", userInfo);
        return "index";
    }
}

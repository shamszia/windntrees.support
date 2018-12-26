/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.configuration;

import windntrees.data.WebAppProperties;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.env.Environment;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.handler.HandlerInterceptorAdapter;

/**
 *
 * @author shams
 */
public class RequestInterceptor extends HandlerInterceptorAdapter {

    private static final Logger logger = LoggerFactory
            .getLogger(HandlerInterceptorAdapter.class);

    @Autowired
    protected Environment env;

    @Autowired
    protected HttpSession session;

    @Override
    public void postHandle(HttpServletRequest request, HttpServletResponse response, Object handler, ModelAndView modelAndView) throws Exception {
        super.postHandle(request, response, handler, modelAndView); //To change body of generated methods, choose Tools | Templates.

        try {
            if (request.getHeader("x-requested-with") == null) {
                WebAppProperties webAppProperties = getWebAppProperties();
                modelAndView.addObject("webappinfo", webAppProperties);
            }
        } catch (Exception ex) {
            logger.error(ex.getMessage());
        }
    }

    @Override
    public void afterCompletion(HttpServletRequest request, HttpServletResponse response, Object handler, Exception ex) throws Exception {
        super.afterCompletion(request, response, handler, ex); //To change body of generated methods, choose Tools | Templates.

    }

    private WebAppProperties getWebAppProperties() {
        if (env != null) {
            return new WebAppProperties(
                    env.getProperty("webapp.theme", "default"),
                    env.getProperty("webapp.title", ""),
                    env.getProperty("webapp.description", ""),
                    env.getProperty("webapp.copyright", ""),
                    env.getProperty("webapp.domain", ""),
                    env.getProperty("webapp.addressLine1", ""),
                    env.getProperty("webapp.addressLine2", ""),
                    env.getProperty("webapp.addressLine3", ""),
                    env.getProperty("webapp.email", ""),
                    env.getProperty("webapp.phone1", ""),
                    env.getProperty("webapp.phone2", ""),
                    env.getProperty("webapp.fax", ""),
                    env.getProperty("webapp.mobile", ""),
                    env.getProperty("webapp.currency", ""),
                    env.getProperty("webapp.menucomposer.localeMode", "false"),
                    env.getProperty("webapp.menucomposer.dataStoreMode", "false"),
                    env.getProperty("webapp.menucomposer.renderingMode", "false")
            );
        }
        return null;
    }
}
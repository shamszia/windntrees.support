/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.configuration;

import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.transaction.annotation.EnableTransactionManagement;
import org.springframework.web.servlet.support.AbstractAnnotationConfigDispatcherServletInitializer;

/**
 *
 * @author shams
 */
@Configuration
@ComponentScan
@EnableJpaRepositories
@EnableTransactionManagement
@PropertySource(value = {"classpath:application.properties", "classpath:hibernate.properties"})
public class DispatcherServlet extends AbstractAnnotationConfigDispatcherServletInitializer {
    
    @Override
    protected Class<?>[] getRootConfigClasses() {
        
        return new Class [] {
            app.configuration.RootConfigurator.class,
            app.configuration.RootDatabaseConfigurator.class
        };
    }

    /********************Thymeleaf View Engine*********************/    
    @Override
    protected Class<?>[] getServletConfigClasses() {
        return new Class [] {
            app.configuration.ServletConfigurator.class,
            app.configuration.ThymeleafConfigurator.class
        };
    }

    @Override
    protected String[] getServletMappings() {
        return new String[] {
            "/"
        };
    }
    
    @Override
    public void onStartup(ServletContext servletContext) throws ServletException {
        super.onStartup(servletContext); //To change body of generated methods, choose Tools | Templates.
   
        //spring database profile selection using init parameters
        //servletContext.setInitParameter("spring.profiles.active", "hsql");
    }
}

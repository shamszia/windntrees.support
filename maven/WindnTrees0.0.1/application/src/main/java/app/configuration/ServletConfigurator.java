/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package app.configuration;

import java.util.Locale;
import org.springframework.beans.BeansException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;
import org.springframework.context.MessageSource;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.annotation.PropertySource;
import org.springframework.context.support.ReloadableResourceBundleMessageSource;
import org.springframework.core.env.Environment;
import org.springframework.web.servlet.LocaleResolver;
import org.springframework.web.servlet.config.annotation.EnableWebMvc;
import org.springframework.web.servlet.config.annotation.InterceptorRegistry;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurerAdapter;
import org.springframework.web.servlet.i18n.LocaleChangeInterceptor;
import org.springframework.web.servlet.i18n.SessionLocaleResolver;

/**
 *
 * @author shams
 */
@Configuration
@EnableWebMvc
@ComponentScan(basePackages = { "windntrees", "controls", "data", "app" })
@PropertySource("classpath:application.properties")
public class ServletConfigurator extends WebMvcConfigurerAdapter 
        implements ApplicationContextAware {
    
    @Autowired
    protected Environment env;
    
    protected ApplicationContext mAppContext = null;
    
    @Override
    public void setApplicationContext(ApplicationContext ac) throws BeansException {
        mAppContext = ac;
    }
    
    @Override
    public void addViewControllers(ViewControllerRegistry registry) {
        super.addViewControllers(registry); //To change body of generated methods, choose Tools | Templates.
        registry.addViewController("/").setViewName("index");
    }
    
    @Override
    public void addResourceHandlers(final ResourceHandlerRegistry registry) {
        super.addResourceHandlers(registry);
        registry.addResourceHandler("/resources/**").addResourceLocations("/resources/");
        registry.addResourceHandler("/fonts/**").addResourceLocations("/resources/fonts/");
    }

    @Override
    public void addInterceptors(InterceptorRegistry registry) {
        super.addInterceptors(registry); //To change body of generated methods, choose Tools | Templates.
        
        registry.addInterceptor(localeChangeInterceptor());
        registry.addInterceptor(requestInterceptor());
    }

    @Bean
    public LocaleResolver localeResolver()
    {
        SessionLocaleResolver slr = new SessionLocaleResolver();
        slr.setDefaultLocale(Locale.ENGLISH);
        return slr;
    }
    
    @Bean
    public LocaleChangeInterceptor localeChangeInterceptor()
    {
        LocaleChangeInterceptor lci = new LocaleChangeInterceptor();
        lci.setParamName("locale");
        return lci;
    }
    
    @Bean
    public RequestInterceptor requestInterceptor()
    {
        RequestInterceptor ri = new RequestInterceptor();
        return ri;
    }
    
    @Bean
    public MessageSource messageSource()
    {
        ReloadableResourceBundleMessageSource messageSource = new ReloadableResourceBundleMessageSource();
        
        messageSource.setBasenames(new String[]{
            "classpath:db/scripts",
            "classpath:locale/shared/menu-messages",
            "classpath:locale/shared/web-pages",
            "classpath:locale/shared/web-controls",
            "classpath:locale/shared/form-messages",
            "classpath:locale/shared/ko-messages",
            "classpath:locale/shared/validation-messages",
            "classpath:locale/shared/standard-messages"
        });
        
        messageSource.setDefaultEncoding("UTF-8");
        return messageSource;
    }
    
    /*
    @Bean
    public StringHttpMessageConverter stringHttpMessageConverter() {
        return new StringHttpMessageConverter(Charset.forName("UTF-8"));
    }
    
    @Bean
    public static PropertySourcesPlaceholderConfigurer propertySourcesPlaceholderConfigurer() {
        PropertySourcesPlaceholderConfigurer configurer = new PropertySourcesPlaceholderConfigurer();
        return configurer;
    }*/
    
    /* For CSRF - need to implement MyRequestDataValueProcessor
    @Bean
    public RequestDataValueProcessor requestDataValueProcessor() {
        return new MyRequestDataValueProcessor();
    }*/
}
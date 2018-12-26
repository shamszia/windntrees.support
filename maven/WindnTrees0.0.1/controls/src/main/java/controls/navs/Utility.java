/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs;

import controls.navs.content.LocaleItem;
import java.util.Locale;
import controls.navs.content.LocaleItemRepository;

/**
 *
 * @author shams
 */
public class Utility {
    
    private static String ltrLocales[] = {"en", "fr"};
    private static String rtlLocales[] = {"ur"};
    
    public static LanguageDirection getLanguageDirection(Locale locale) {

        if (locale == null) {
            return LanguageDirection.Default;
        } else {
            for (String ltrLocale : ltrLocales) {
                if (ltrLocale.equalsIgnoreCase(locale.getLanguage())) {
                    return LanguageDirection.LeftToRight;
                }
            }

            for (String rtlLocale : rtlLocales) {
                if (rtlLocale.equalsIgnoreCase(locale.getLanguage())) {
                    return LanguageDirection.RightToLeft;
                }
            }
        }
        return LanguageDirection.Default;
    }
    
    public static String getDataStoreLocaleMessage(String itemKey, String localeCode, LocaleItemRepository localeItemRepository) {
        
        if (localeItemRepository != null) {
            
            if (itemKey.startsWith("!")) {
                return itemKey.substring(1, itemKey.length());
            }
            
            LocaleItem localeMessage = localeItemRepository.read(itemKey, localeCode);
            if (localeMessage != null) {
                return localeMessage.getItemValue();
            }
        }
        return String.format("%1$s_%2$s", itemKey, localeCode);
    }
    
    public static String getDataStoreLocaleDefaultMessage(String itemKey, LocaleItemRepository localeItemRepository) {
        
        if (localeItemRepository != null) {
            
            if (itemKey.startsWith("!")) {
                return itemKey.substring(1, itemKey.length());
            }
            
            LocaleItem localeMessage = localeItemRepository.read(itemKey);
            if (localeMessage != null) {
                return localeMessage.getItemValue();
            }
        }
        return String.format("%1$s_default", itemKey);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Controls.Navs
{
    public class Utility
    {

        private static String[] ltrLocales = { "en", "fr" };
        private static String[] rtlLocales = { "ur" };

        public static LanguageDirection getLanguageDirection(String localeCode)
        {

            if (localeCode == null)
            {
                return LanguageDirection.Default;
            }
            else
            {
                foreach (String ltrLocale in ltrLocales)
                {
                    if (ltrLocale.Equals(localeCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return LanguageDirection.LeftToRight;
                    }
                }

                foreach (String rtlLocale in rtlLocales)
                {
                    if (rtlLocale.Equals(localeCode, StringComparison.OrdinalIgnoreCase))
                    {
                        return LanguageDirection.RightToLeft;
                    }
                }
            }
            return LanguageDirection.Default;
        }

        /*
        public static String getDataStoreLocaleMessage(String itemKey, String localeCode, LocaleItemRepository localeItemRepository)
        {

            if (localeItemRepository != null)
            {

                if (itemKey.startsWith("!"))
                {
                    return itemKey.substring(1, itemKey.length());
                }

                LocaleItem localeMessage = localeItemRepository.read(itemKey, localeCode);
                if (localeMessage != null)
                {
                    return localeMessage.getItemValue();
                }
            }
            return String.format("%1$s_%2$s", itemKey, localeCode);
        }

        public static String getDataStoreLocaleDefaultMessage(String itemKey, LocaleItemRepository localeItemRepository)
        {

            if (localeItemRepository != null)
            {

                if (itemKey.startsWith("!"))
                {
                    return itemKey.substring(1, itemKey.length());
                }

                LocaleItem localeMessage = localeItemRepository.read(itemKey);
                if (localeMessage != null)
                {
                    return localeMessage.getItemValue();
                }
            }
            return String.format("%1$s_default", itemKey);
        }*/
    }
}

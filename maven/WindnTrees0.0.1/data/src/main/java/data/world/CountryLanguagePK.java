//
// This file was generated by the Jeddict
//
package data.world;

import java.io.Serializable;

public class CountryLanguagePK implements Serializable {

    private String countryCode;

    private String language;

    public CountryLanguagePK() {
    }

    public CountryLanguagePK(String countryCode, String language) {
        this.countryCode = countryCode;
        this.language = language;
    }

    public String getCountryCode() {
        return this.countryCode;
    }

    public void setCountryCode(String countryCode) {
        this.countryCode = countryCode;
    }

    public String getLanguage() {
        return this.language;
    }

    public void setLanguage(String language) {
        this.language = language;
    }

    @Override
    public boolean equals(Object obj) {
        if (obj == null) {
            return false;
        }
        if (!java.util.Objects.equals(getClass(), obj.getClass())) {
            return false;
        }
        final CountryLanguagePK other = (CountryLanguagePK) obj;
        if (!java.util.Objects.equals(this.getCountryCode(), other.getCountryCode())) {
            return false;
        }
        if (!java.util.Objects.equals(this.getLanguage(), other.getLanguage())) {
            return false;
        }
        return true;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 73 * hash + (this.getCountryCode() != null ? this.getCountryCode().hashCode() : 0);
        hash = 73 * hash + (this.getLanguage() != null ? this.getLanguage().hashCode() : 0);
        return hash;
    }

    @Override
    public String toString() {
        return "CountrylanguagePK{" + " countryCode=" + countryCode + ", language=" + language + '}';
    }

}
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editoa.
 */
package data.world;

import java.util.List;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.transaction.annotation.Transactional;
import windntrees.RepositoryInterface;

/**
 *
 * @author shams
 */
public interface CountryLanguageRepository extends RepositoryInterface<CountryLanguage,String> {
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a WHERE a.language = ?1")
    CountryLanguage read(Object key);

    @Override
    public default CountryLanguage read(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a WHERE a.language LIKE ?1 ORDER BY a.language ASC")
    List<CountryLanguage> readByKeyword(String keyword);
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a WHERE a.language LIKE ?1 ORDER BY a.language ASC", 
            countQuery = "SELECT COUNT(a) FROM CountryLanguage a WHERE a.language LIKE ?1")
    Page<CountryLanguage> readByKeyword(String keyword, Pageable pageable);
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a ORDER BY a.language ASC")
    List<CountryLanguage> readAll();
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a ORDER BY a.language ASC", countQuery = "SELECT COUNT (a) FROM CountryLanguage a")
    Page<CountryLanguage> readAll(Pageable pageable);
    
    @Override
    @Modifying
    @Transactional
    @Query("DELETE FROM CountryLanguage WHERE language = ?1")
    void deleteByKey(Object key);

    @Override
    public default void deleteByKey(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    //Extensions
    ////////////////////////////////////////////////////////////////////////////
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a WHERE a.country.code = ?1 AND a.language LIKE ?2 ORDER BY a.language ASC")
    List<CountryLanguage> select(Object refKey, String keyword);
    
    @Override
    @Query(value = "SELECT a FROM CountryLanguage a WHERE a.country.code = ?1 AND a.language LIKE ?2 ORDER BY a.language ASC",
            countQuery = "SELECT COUNT(a) FROM CountryLanguage a WHERE a.country.code = ?1 AND a.language LIKE ?2")
    Page<CountryLanguage> select(Object refKey, String keyword, Pageable pageable);

    @Override
    public default List<CountryLanguage> selectWithin(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<CountryLanguage> selectWithin(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}

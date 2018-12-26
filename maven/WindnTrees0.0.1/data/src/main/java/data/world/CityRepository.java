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
public interface CityRepository extends RepositoryInterface<City,String> {
    
    @Override
    @Query(value = "SELECT a FROM City a WHERE a.name = ?1")
    City read(Object key);

    @Override
    public default City read(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    @Query(value = "SELECT a FROM City a WHERE a.name LIKE ?1 ORDER BY a.name ASC")
    List<City> readByKeyword(String keyword);
    
    @Override
    @Query(value = "SELECT a FROM City a WHERE a.name LIKE ?1 ORDER BY a.name ASC", 
            countQuery = "SELECT COUNT(a) FROM City a WHERE a.name LIKE ?1")
    Page<City> readByKeyword(String keyword, Pageable pageable);
    
    @Override
    @Query(value = "SELECT a FROM City a ORDER BY a.name ASC")
    List<City> readAll();
    
    @Override
    @Query(value = "SELECT a FROM City a ORDER BY a.name ASC", countQuery = "SELECT COUNT (a) FROM City a")
    Page<City> readAll(Pageable pageable);
    
    @Override
    @Modifying
    @Transactional
    @Query("DELETE FROM City WHERE name = ?1")
    void deleteByKey(Object key);

    @Override
    public default void deleteByKey(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    //Extensions
    ////////////////////////////////////////////////////////////////////////////
    
    @Override
    @Query(value = "SELECT a FROM City a, IN (a.country) r WHERE r.code = ?1 AND a.name LIKE ?2 ORDER BY a.name ASC")
    List<City> select(Object refKey, String keyword);
    
    @Override
    @Query(value = "SELECT a FROM City a, IN (a.country) r WHERE r.code = ?1 AND a.name LIKE ?2 ORDER BY a.name ASC",
            countQuery = "SELECT COUNT(a) FROM City a, IN (a.country) r WHERE r.code = ?1 AND a.name LIKE ?2")
    Page<City> select(Object refKey, String keyword, Pageable pageable);

    @Override
    public default List<City> selectWithin(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<City> selectWithin(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    //Business logic extensions
    ////////////////////////////////////////////////////////////////////////////
    
    @Modifying
    @Transactional
    @Query("Update City Set COUNTRYCAPITAL_Code=null WHERE CountryCode = ?1")
    void clearCapital(String countryCode);
    
    @Query(value = "SELECT a FROM City a WHERE a.countryCapital.code = ?1")
    City readCapital(Object key);
}

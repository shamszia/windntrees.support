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
public interface CountryRepository extends RepositoryInterface<Country,String> {
    
    @Override
    @Query(value = "SELECT a FROM Country a WHERE a.code = ?1")
    Country read(Object key);
    
    @Override
    public default Country read(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    @Query(value = "SELECT a FROM Country a WHERE a.code LIKE ?1 OR a.name LIKE ?1 ORDER BY a.name ASC")
    List<Country> readByKeyword(String keyword);
    
    @Override
    @Query(value = "SELECT a FROM Country a WHERE a.code LIKE ?1 OR a.name LIKE ?1 ORDER BY a.name ASC", countQuery = "SELECT COUNT(a) FROM Country a WHERE a.code LIKE ?1 OR a.name LIKE ?1")
    Page<Country> readByKeyword(String keyword, Pageable pageable);
    
    @Override
    @Query(value = "SELECT a FROM Country a ORDER BY a.name ASC")
    List<Country> readAll();
    
    @Override
    @Query(value = "SELECT a FROM Country a ORDER BY a.name ASC", countQuery = "SELECT COUNT (a) FROM Country a")
    Page<Country> readAll(Pageable pageable);
    
    @Override
    @Modifying
    @Transactional
    @Query("DELETE FROM Country WHERE name = ?1")
    void deleteByKey(Object key);

    @Override
    public default void deleteByKey(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    //Extensions
    ////////////////////////////////////////////////////////////////////////////
    
    @Override
    @Query(value = "SELECT a FROM Country a WHERE a.continent = ?1 AND a.name LIKE ?2 ORDER BY a.name ASC")
    List<Country> select(Object refKey, String keyword);
    
    @Override
    @Query(value = "SELECT a FROM Country a WHERE a.continent = ?1 AND a.name LIKE ?2 ORDER BY a.name ASC",countQuery = "SELECT COUNT(a) FROM Country a WHERE a.continent = ?1 AND a.name LIKE ?2")
    Page<Country> select(Object refKey, String keyword, Pageable pageable);

    @Override
    public default List<Country> selectWithin(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<Country> selectWithin(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}

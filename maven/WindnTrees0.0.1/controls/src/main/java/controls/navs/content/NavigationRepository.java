/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs.content;

import java.util.List;
import java.util.UUID;
import org.hibernate.annotations.Cascade;
import org.hibernate.annotations.CascadeType;
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
public interface NavigationRepository extends RepositoryInterface<Navigation, UUID> {
    
    //CRUD
    ////////////////////////////////////////////////////////////////////////////
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.id = ?1")
    Navigation read(Object key);

    @Override
    public default Navigation read(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.text IS NULL OR n.text LIKE ?1 ORDER BY n.sortOrder ASC")
    List<Navigation> readByKeyword(String keyword);
    
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.text IS NULL OR n.text LIKE ?1 ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM Navigation n WHERE n.text IS NULL OR n.text LIKE ?1")
    Page<Navigation> readByKeyword(String keyword, Pageable pageable);
    
    /*
    @Query(value = "SELECT n FROM Navigation n WHERE n.id = ?1 OR (n.text IS NULL OR n.text LIKE ?2) ORDER BY n.sortOrder ASC")
    List<Navigation> readByKeyword(UUID refKey, String keyword);
    
    @Query(value = "SELECT n FROM Navigation n WHERE n.id = ?1 OR (n.text IS NULL OR n.text LIKE ?2) ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM Navigation n WHERE n.id = ?1 OR (n.text IS NULL OR n.text LIKE ?2)")
    Page<Navigation> readByKeyword(UUID refKey, String keyword, Pageable pageable);
    */
    
    @Override
    @Query(value = "SELECT n FROM Navigation n ORDER BY n.sortOrder ASC")
    List<Navigation> readAll();
    
    @Override
    @Query(value = "SELECT n FROM Navigation n ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM Navigation n")
    Page<Navigation> readAll(Pageable pageable);
    
    @Override
    @Modifying
    @Transactional
    @Cascade(CascadeType.DELETE)
    @Query("DELETE FROM Navigation WHERE id= ?1")
    void deleteByKey(Object key);

    @Override
    public default void deleteByKey(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    //Extensions
    ////////////////////////////////////////////////////////////////////////////
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.menu.id = ?1 AND n.menu.name LIKE ?2 AND (n.text IS NULL OR n.text LIKE ?2) ORDER BY n.sortOrder ASC")
    List<Navigation> select(Object key, String keyword);
    
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.menu.id = ?1 AND n.menu.name LIKE ?2 AND (n.text IS NULL OR n.text LIKE ?2) ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM Navigation n WHERE n.menu.id = ?1 AND n.menu.name LIKE ?2 AND (n.text IS NULL OR n.text LIKE ?2)")
    Page<Navigation> select(Object key, String keyword, Pageable pageable);
    
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.parentItem.id = ?1 AND (n.parentItem.text IS NULL OR n.parentItem.text LIKE ?2) AND (n.text IS NULL OR n.text LIKE ?2) ORDER BY n.sortOrder ASC")
    List<Navigation> selectWithin(Object key, String keyword);
    
    @Override
    @Query(value = "SELECT n FROM Navigation n WHERE n.parentItem.id = ?1 AND (n.parentItem.text IS NULL OR n.parentItem.text LIKE ?2) AND (n.text IS NULL OR n.text LIKE ?2) ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM Navigation n WHERE n.parentItem.id = ?1 AND (n.parentItem.text IS NULL OR n.parentItem.text LIKE ?2) AND (n.text IS NULL OR n.text LIKE ?2)")
    Page<Navigation> selectWithin(Object key, String keyword, Pageable pageable);
}
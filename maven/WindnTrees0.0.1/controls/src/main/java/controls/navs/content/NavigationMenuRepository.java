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
public interface NavigationMenuRepository extends RepositoryInterface<NavigationMenu, UUID> {
    
    @Override
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.id = ?1")
    NavigationMenu read(Object key);

    @Override
    public default NavigationMenu read(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
    @Override
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.name LIKE ?1 ORDER BY n.sortOrder ASC")
    List<NavigationMenu> readByKeyword(String keyword);
    
    @Override
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.name LIKE ?1 ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM NavigationMenu n WHERE n.name LIKE ?1")
    Page<NavigationMenu> readByKeyword(String keyword, Pageable pageable);
    
    /*
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.id = ?1 OR n.name LIKE ?2 ORDER BY n.sortOrder ASC")
    List<NavigationMenu> readByKeyword(UUID id, String keyword);
    
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.id = ?1 OR n.name LIKE ?2 ORDER BY n.sortOrder ASC",
            countQuery = "SELECT COUNT(n) FROM NavigationMenu n WHERE n.id = ?1 OR n.name LIKE ?2")
    Page<NavigationMenu> readByKeyword(UUID id, String keyword, Pageable pageable);
    */
    
    @Override
    @Query(value = "SELECT n FROM NavigationMenu n ORDER BY n.sortOrder ASC")
    List<NavigationMenu> readAll();
    
    @Override
    @Query(value = "SELECT n FROM NavigationMenu n ORDER BY n.sortOrder ASC", countQuery = "SELECT COUNT(n) FROM NavigationMenu n")
    Page<NavigationMenu> readAll(Pageable pageable);
    
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.appKey = ?1 ORDER BY n.sortOrder ASC")
    List<NavigationMenu> readByAppKey(String appKey);
    
    @Query(value = "SELECT n FROM NavigationMenu n WHERE n.appKey IS NULL ORDER BY n.sortOrder ASC")
    List<NavigationMenu> readByNullAppKey();
    
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

    @Override
    public default List<NavigationMenu> select(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<NavigationMenu> select(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default List<NavigationMenu> selectWithin(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<NavigationMenu> selectWithin(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
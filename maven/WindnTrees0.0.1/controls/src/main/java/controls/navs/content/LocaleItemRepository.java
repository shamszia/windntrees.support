/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controls.navs.content;

import java.util.List;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.Query;
import windntrees.RepositoryInterface;

/**
 *
 * @author shams
 */
public interface LocaleItemRepository extends RepositoryInterface<LocaleItem, LocaleItemKey> {
    
    @Override
    @Query(value = "SELECT n FROM LocaleItem n WHERE n.itemKey = ?1 AND (n.itemLocale IS NULL OR n.itemLocale = '')")
    LocaleItem read(Object itemKey);
    
    @Override
    @Query(value = "SELECT n FROM LocaleItem n WHERE n.itemKey = ?1 AND n.itemLocale = ?2")
    LocaleItem read(Object[] readParams);
    
    @Query(value = "SELECT n FROM LocaleItem n WHERE n.itemKey = ?1 AND n.itemLocale = ?2")
    LocaleItem read(String itemKey, String itemLocale);
    
    @Override
    @Query(value = "SELECT n FROM LocaleItem n WHERE n.itemKey LIKE ?1 OR n.itemValue LIKE ?1 OR n.itemLocale LIKE ?1 ORDER BY n.itemKey ASC")
    List<LocaleItem> readByKeyword(String keyword);
    
    @Override
    @Query(value = "SELECT n FROM LocaleItem n WHERE n.itemKey LIKE ?1 OR n.itemLocale LIKE ?1 ORDER BY n.itemKey ASC", countQuery = "SELECT COUNT (n) FROM LocaleItem n WHERE n.itemKey LIKE ?1 OR n.itemLocale LIKE ?1")
    Page<LocaleItem> readByKeyword(String keyword, Pageable pageable);
    
    @Override
    @Query(value = "SELECT n FROM LocaleItem n ORDER BY n.itemKey ASC")
    List<LocaleItem> readAll();
    
    @Override
    @Query(value = "SELECT n FROM LocaleItem n ORDER BY n.itemKey ASC", countQuery = "SELECT COUNT (n) FROM LocaleItem n")
    Page<LocaleItem> readAll(Pageable pageable);

    @Override
    public default void deleteByKey(Object key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default void deleteByKey(Object[] key) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default List<LocaleItem> select(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<LocaleItem> select(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default List<LocaleItem> selectWithin(Object refKey, String keyword) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public default Page<LocaleItem> selectWithin(Object refKey, String keyword, Pageable pageable) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
}
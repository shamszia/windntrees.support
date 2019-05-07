/**
 * This file was generated by the Jeddict
 */
package controls.navs.content;

import java.io.Serializable;
import java.util.Set;
import javax.persistence.Basic;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.OrderBy;
import javax.persistence.Table;

@Entity
@Table(name = "navigation_menu")
public class NavigationMenu implements Serializable {

    @Column(name = "menu_id", table = "navigation_menu")
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    protected Long id;

    @Column(name = "app_key", table = "navigation_menu", length = 100)
    @Basic
    protected String appKey;

    @Column(name = "relative_url", table = "navigation_menu")
    @Basic
    protected String relativeUrl;

    @Column(name = "name_", table = "navigation_menu", nullable = false, length = 100)
    @Basic
    protected String name;

    @Column(name = "description", table = "navigation_menu")
    @Basic
    protected String description;

    @Column(name = "navigation_type", table = "navigation_menu")
    @Basic
    protected int navigationType;

    @Column(name = "sort_order", table = "navigation_menu", nullable = false)
    @Basic
    protected Integer sortOrder;

    @Column(name = "roles", table = "navigation_menu", length = 100)
    @Basic
    protected String roles;

    @Column(name = "users", table = "navigation_menu", length = 100)
    @Basic
    protected String users;

    @Column(name = "auth_mode", table = "navigation_menu")
    @Basic
    protected Boolean authMode;

    @OneToMany(cascade = {CascadeType.ALL}, fetch = FetchType.EAGER, targetEntity = Navigation.class, orphanRemoval = true, mappedBy = "menu")
    @OrderBy("sortOrder ASC")
    protected Set<Navigation> items;

    public Long getId() {
        return this.id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getAppKey() {
        return this.appKey;
    }

    public void setAppKey(String appKey) {
        this.appKey = appKey;
    }

    public String getRelativeUrl() {
        return this.relativeUrl;
    }

    public void setRelativeUrl(String relativeUrl) {
        this.relativeUrl = relativeUrl;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return this.description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public int getNavigationType() {
        return this.navigationType;
    }

    public void setNavigationType(int navigationType) {
        this.navigationType = navigationType;
    }

    public Integer getSortOrder() {
        return this.sortOrder;
    }

    public void setSortOrder(Integer sortOrder) {
        this.sortOrder = sortOrder;
    }

    public String getRoles() {
        return this.roles;
    }

    public void setRoles(String roles) {
        this.roles = roles;
    }

    public String getUsers() {
        return this.users;
    }

    public void setUsers(String users) {
        this.users = users;
    }

    public Boolean isAuthMode() {
        return this.authMode;
    }

    public void setAuthMode(Boolean authMode) {
        this.authMode = authMode;
    }

    public Set<Navigation> getItems() {
        return this.items;
    }

    public void setItems(Set<Navigation> items) {
        this.items = items;
    }
}
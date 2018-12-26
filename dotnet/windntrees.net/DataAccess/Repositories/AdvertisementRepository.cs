using System;
using System.Linq;
using Abstraction.Filters;
using System.Linq.Expressions;
using Abstraction.Repository;

namespace DataAccess.Repositories
{
    public class AdvertisementRepository : EntityRepository<Advertisement>
    {
        public AdvertisementRepository(DatabaseContext dbContext, string relatedObjects = "", bool enableLazyLoading = false) 
            : base(dbContext, relatedObjects, enableLazyLoading)
        { }

        protected override Advertisement GenerateNewKey(Advertisement contentObject)
        {
            contentObject.UID = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        protected override IQueryable<Advertisement> QueryRecords(IQueryable<Advertisement> query, SearchFilter searchQuery = null)
        {
            Expression<Func<Advertisement, bool>> condition = null;
            if (searchQuery != null)
            {
                if (!string.IsNullOrEmpty(searchQuery.key))
                {
                    Nullable<Guid> key = null;
                    try
                    {
                        key = Guid.Parse(searchQuery.key);
                    }
                    catch { }

                    if (key != null)
                    {
                        condition = l => (l.ReferenceID == key);
                        query = query.Where(condition);
                    }
                }

                if (searchQuery.keywords != null)
                {
                    var location = searchQuery.keywords.Where(l => l.Field == "Location").SingleOrDefault();

                    if (location != null)
                    {
                        condition = l => (l.Location.Contains(location.Value));
                        query = query.Where(condition);
                    }

                    var page = searchQuery.keywords.Where(l => l.Field == "Page").SingleOrDefault();
                    if (page != null)
                    {
                        condition = l => (l.Page.Contains(page.Value));
                        query = query.Where(condition);
                    }

                    var news = searchQuery.keywords.Where(l => l.Field == "News").SingleOrDefault();
                    if (news != null)
                    {
                        bool isNews = Boolean.Parse(news.Value);

                        condition = l => (l.News == isNews);
                        query = query.Where(condition);
                    }
                }

                if (!string.IsNullOrEmpty(searchQuery.keyword))
                {
                    condition = l => (l.Heading.Contains(searchQuery.keyword) || l.SubHeading.Contains(searchQuery.keyword) || l.Detail.Contains(searchQuery.keyword));
                    query = query.Where(condition);
                }
            }

            return query;
        }

        protected override IOrderedQueryable<Advertisement> SortRecords(IQueryable<Advertisement> query, SearchFilter searchQuery = null)
        {
            IOrderedQueryable<Advertisement> orderInterface = null;
            if (searchQuery != null)
            {
                if (searchQuery.descending)
                {
                    orderInterface = query.OrderByDescending(l => l.SortOrder).ThenBy(l=>l.Heading);
                }
                else
                {
                    orderInterface = query.OrderBy(l => l.SortOrder).ThenBy(l => l.Heading);
                }
            }
            return orderInterface;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WindnTrees.ICRUDS;

namespace WindnTrees.Abstraction.WebForms.App.DataAccess
{
    public class ColorEmptyRepository : WindnTrees.CRUDS.Repository.EntityEmptyRepository<Color>
    {
        public ColorEmptyRepository()
            : base(new webapplication7Entities(), "", false)
        {

        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse(key.ToString());
        }

        protected override IQueryable<Color> QueryRecords(IQueryable<Color> query, SearchInput queryObject = null)
        {
            queryObject.keyword = string.IsNullOrEmpty(queryObject.keyword) ? string.Empty : queryObject.keyword;
            query = query.Where(l => l.Name.Contains(queryObject.keyword) || l.Description.Contains(queryObject.keyword));
            return query;
        }

        protected override IOrderedQueryable<Color> SortRecords(IQueryable<Color> query, SearchInput queryObject = null)
        {
            return query.OrderBy(l => l.Name);
        }

        protected override Color GetContentForCreate()
        {
            return new Color
            {
                UID = Guid.NewGuid(),
                Name = string.Format("{0}{1}", "C", DateTime.Now.ToString("ddHHmmss")),
                Description = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };
        }

        protected override string GetIdForRead()
        {
            var color = new webapplication7Entities().Colors.OrderByDescending(l => l.Description).FirstOrDefault();
            return color.UID.ToString();
        }

        protected override Color GetContentForUpdate()
        {
            var color = new webapplication7Entities().Colors.OrderByDescending(l => l.Description).FirstOrDefault();
            color.Name = string.Format("{0}{1}", "C", DateTime.Now.ToString("ddHHmmss"));
            return color;
            //return new Color { Uid = color.Uid, Name = color.Name, Description = color.Description };
        }

        protected override Color GetContentForDelete()
        {
            var color = new webapplication7Entities().Colors.OrderByDescending(l => l.Description).FirstOrDefault();
            return color;
            //return new Color { Uid = color.Uid, Name = color.Name, Description = color.Description };
        }

        protected override SearchInput GetConditionsForListing()
        {
            return new SearchInput
            {
                keyword = ""
            };
        }

        //repository target (CRUDMethod)

        public Color CreateCRUD()
        {
            return base.Create();
        }

        public Color ReadCRUD()
        {
            return base.Read();
        }

        public Color UpdateCRUD()
        {
            return base.Update();
        }

        public Color DeleteCRUD()
        {
            return base.Delete();
        }

        public List<Color> ListCRUD()
        {
            return base.List();
        }

        public int ListCRUDTotal()
        {
            return base.ListTotal();
        }
    }
}
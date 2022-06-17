using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WindnTrees.CRUDS.Repository.Core;
using WindnTrees.ICRUDS.Standard;

namespace WindnTreesSEO.Models.Database.Repositories
{
    public class TopicRepository : EntityRepository<Topic>
    {
        public TopicRepository(ApplicationContext dbContext, string relatedObjects = "Category,SkillLevel")
            : base(dbContext, relatedObjects)
        { }

        protected override Topic GenerateNewKey(Topic contentObject)
        {
            contentObject.Uid = Guid.NewGuid();
            return contentObject;
        }

        protected override object GetTypedKey(object key)
        {
            return Guid.Parse((string)key);
        }

        /// <summary>
        /// Override to customize search.
        /// </summary>
        /// <param name="query">IQueryable (Set) repository interface.</param>
        /// <param name="searchQuery">Search object with input parameters to customize search.</param>
        /// <returns></returns>
        protected override IQueryable<Topic> QueryRecords(IQueryable<Topic> query, SearchInput searchQuery = null)
        {
            Expression<Func<Topic, bool>> condition = null;

            //Loads reference records based on key value
            if (!string.IsNullOrEmpty(searchQuery.key))
            {
                Nullable<Guid> keyGuid = null;
                try
                {
                    keyGuid = Guid.Parse(searchQuery.key);
                }
                catch { }

                if (keyGuid != null)
                {
                    query = query.Where(l => l.CategoryId == keyGuid);
                }
            }

            //check for keyword
            if (!string.IsNullOrEmpty(searchQuery.keyword))
            {
                condition = l => (l.Subject.Contains(searchQuery.keyword) || l.Description1.Contains(searchQuery.keyword) || l.Description2.Contains(searchQuery.keyword));
                query = query.Where(condition);
            }

            //check for reference keys
            if (searchQuery.keys != null)
            {
                //find category
                var category = ((List<SearchField>)searchQuery.keys).Where(l => l.field == "category").SingleOrDefault();
                if (category != null)
                {
                    Nullable<Guid> categoryId = null;

                    //check if reference value is selected
                    if (!string.IsNullOrEmpty(category.value))
                    {
                        try
                        {
                            categoryId = Guid.Parse(category.value);
                        }
                        catch { }

                        //optimize search
                        query = query.Where(l => l.CategoryId == categoryId);
                    }
                }

                //find skill
                var skill = ((List<SearchField>)searchQuery.keys).Where(l => l.field == "skill").SingleOrDefault();
                if (skill != null)
                {
                    Nullable<Guid> skillId = null;

                    //check if reference value is selected
                    if (!string.IsNullOrEmpty(skill.value))
                    {
                        try
                        {
                            skillId = Guid.Parse(skill.value);
                        }
                        catch { }

                        //optimize search
                        query = query.Where(l => l.SkillLevelId == skillId);
                    }
                }
            }
            return query;
        }

        /// <summary>
        /// Override to customize sort.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        protected override IOrderedQueryable<Topic> SortRecords(IQueryable<Topic> query, SearchInput searchQuery = null)
        {
            IOrderedQueryable<Topic> orderInterface = null;
            if (searchQuery.descend == null ? false : ((bool)searchQuery.descend))
            {
                orderInterface = query.OrderByDescending(l => l.Subject);
            }
            else
            {
                orderInterface = query.OrderBy(l => l.Subject);
            }
            return orderInterface;
        }

        /// <summary>
        /// Called against create request.
        /// </summary>
        /// <param name="contentObject"></param>
        /// <returns></returns>
        protected override Topic PostCreate(Topic contentObject)
        {
            //Following is only required if you want to load referential data 
            //against main entity against create CRUD call.
            var category = (new ApplicationContext()).Category.Where(l => l.Uid == contentObject.CategoryId).SingleOrDefault();
            if (category != null)
            {
                contentObject.Category = category;
            }

            var skillLevel = (new ApplicationContext()).SkillLevel.Where(l => l.Uid == contentObject.SkillLevelId).SingleOrDefault();
            if (skillLevel != null)
            {
                contentObject.SkillLevel = skillLevel;
            }

            return base.PostCreate(contentObject);
        }

        /// <summary>
        /// Override create method to update datetime fields.
        /// </summary>
        /// <param name="contentObject"></param>
        /// <returns></returns>
        public override Topic Create(Topic contentObject)
        {
            try
            {
                contentObject.RecordTime = DateTime.UtcNow;
                contentObject.UpdateTime = DateTime.UtcNow;

                return base.Create(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Override update method, following code may require appropriation or you must extend entity repository to generalize solution.
        /// </summary>
        /// <param name="contentObject"></param>
        /// <returns></returns>
        public override Topic Update(Topic contentObject)
        {
            try
            {
                contentObject.UpdateTime = DateTime.UtcNow;
                contentObject.Category = null;
                contentObject.SkillLevel = null;

                return base.Update(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Override delete method, following code may require appropriation or you must extend entity repository to generalize solution.
        /// </summary>
        /// <param name="contentObject"></param>
        /// <returns></returns>
        public override Topic Delete(Topic contentObject)
        {
            try
            {
                return base.Delete(contentObject);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

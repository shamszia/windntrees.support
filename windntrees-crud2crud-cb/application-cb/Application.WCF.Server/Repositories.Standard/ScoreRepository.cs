using Application.Models.Standard.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindnTrees.CRUDS.Repository.Standard;
using WindnTrees.ICRUDS.Standard;

namespace Application.WCF.Server.Repositories.Standard
{
    public delegate void ScoreResultDelegate(string method, object score);

    /// <summary>
    /// CB (Callback) ScoreRepository for example demonstration.
    /// </summary>
    public class ScoreRepository : ServiceCBRepository<Score>
    {
        #region FireScoreResultEvent
        public static event ScoreResultDelegate OnScoreResult = null;
        protected static void FireScoreResultEvent(string method, object score)
        {
            if (OnScoreResult != null)
            {
                OnScoreResult(method, score);
            }
        }
        #endregion

        public ScoreRepository()
            : base(null)
        {

        }

        #region CRUDL
        public override Score Create(Score contentObject)
        {
            //base.Create(contentObject);
            //do not call above function that internaly uses dbcontext dbset
            //this example does not required database context

            return null;
        }

        public override Score Read(object id)
        {
            //base.Read(id);
            //do not call above function that internaly uses dbcontext dbset
            //this example does not required database context

            return null;
        }

        public override Score Update(Score contentObject)
        {
            //base.Update(contentObject);
            //do not call above function that internaly uses dbcontext dbset
            //this example does not required database context

            return null;
        }

        public override Score Delete(Score contentObject)
        {
            //base.Delete(contentObject);
            //do not call above function that internaly uses dbcontext dbset
            //this example does not required database context

            return null;
        }

        public override List<Score> List(SearchInput queryObject)
        {
            //base.List(queryObject);
            //do not call above function that internaly uses dbcontext dbset
            //this example does not required database context

            return null;
        } 
        #endregion

        #region CRUDM_METHOD_SCALERS
        #region CRUDM_SCALER
        //CRUDM is the only (or should be) required method scaler for remote invocations.

        public override object Method(string target)
        {
            return base.Method(target);
        }

        public override object MethodObject(object contentObject, string target)
        {
            return base.MethodObject(contentObject, target);
        }
        #endregion

        #region CRUDM_CONTENT_EXTENSION_SCALER_FOR_WCF
        //Followings are WCF specific CRUDM extensions

        public override Score MethodContent(Score contentObject, string target)
        {
            return base.MethodContent(contentObject, target);
        }

        public override List<Score> MethodContentList(List<Score> contentObjects, string target)
        {
            return base.MethodContentList(contentObjects, target);
        }

        public override Score MethodSearch(SearchInput inputObject, string target)
        {
            return base.MethodSearch(inputObject, target);
        }

        public override List<Score> MethodSearchList(SearchInput inputObject, string target)
        {
            return base.MethodSearchList(inputObject, target);
        }

        public override object MethodSearchObject(SearchInput inputObject, string target)
        {
            return base.MethodSearchObject(inputObject, target);
        }
        #endregion
        #endregion

        #region CRUDM_CB_SCALE
        //Followig methods are invoked using CRUDM, no direct invocation from ServiceClient or WCFServiceClient.

        public override bool SubscribeServiceCallback(string id)
        {
            return base.SubscribeServiceCallback(id);
        }

        public override bool UnSubscribeServiceCallback(string id)
        {
            return base.UnSubscribeServiceCallback(id);
        }
        #endregion

        #region CRUDM_EXAMPLE_APPLICATION_SCALE
        /// <summary>
        /// Total Score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public object TotalScore(object score)
        {
            FireScoreResultEvent("TotalScore", score);

            return score;
        }

        /// <summary>
        /// Average Score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public object AvgScore(object score)
        {
            FireScoreResultEvent("AvgScore", score);

            return score;
        }

        /// <summary>
        /// Maximum Score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public object MaxScore(object score)
        {
            FireScoreResultEvent("MaxScore", score);

            return score;
        }

        /// <summary>
        /// Minimum Score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public object MinScore(object score)
        {
            FireScoreResultEvent("MinScore", score);

            return score;
        }

        /// <summary>
        /// Fail Score.
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public object FailScore(object score)
        {
            FireScoreResultEvent("FailScore", score);

            return score;
        }
        #endregion
    }
}

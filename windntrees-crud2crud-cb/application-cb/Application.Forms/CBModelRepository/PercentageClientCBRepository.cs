using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindnTrees.ICRUDS;

namespace ApplicationForms.CBModelRepository
{
    public delegate void ReportCBCommunicationResult(CBCommunicationType communicationType, string content, float result, string target = null);
    public delegate void ReportCBCommunicationResultList(CBCommunicationType communicationType, SearchInput searchInput, List<float> result, string target = null);

    /// <summary>
    /// Callback repositories does not require data returning, rather clients should use WCF CRUD2CRUD proxies for completing any callback event notices. 
    /// Forming a client = server = client CRUD2CRUD round communication and method invocations with one interface.
    /// </summary>
    public class PercentageClientCBRepository : WindnTrees.ICRUDS.ICRUDLMCBRepository<string>
    {
        #region FireCBCommunicationResult
        public event ReportCBCommunicationResult OnCBCommunicationResult = null;
        public void FireCBCommunicationResult(CBCommunicationType communicationType, string content, float result, string target = null)
        {
            if (OnCBCommunicationResult != null)
            {
                OnCBCommunicationResult(communicationType, content, result, target);
            }
        }
        #endregion

        #region FireCBCommunicationResultList
        public event ReportCBCommunicationResultList OnCBCommunicationResultList = null;
        public void FireCBCommunicationResultList(CBCommunicationType communicationType, SearchInput searchInput, List<float> result, string target = null)
        {
            if (OnCBCommunicationResultList != null)
            {
                OnCBCommunicationResultList(communicationType, searchInput, result, target);
            }
        }
        #endregion

        #region ClientID
        /// <summary>
        /// Percentage client id.
        /// </summary>
        private string m_ClientID = null;

        /// <summary>
        /// Gets client id.
        /// </summary>
        public string ClientID
        {
            get
            {
                return m_ClientID;
            }
        }
        #endregion

        #region PercentageRatio
        /// <summary>
        /// Percentage ratio.
        /// </summary>
        private float m_PercentageRatio = 100;

        public float PercentageRatio
        {
            get
            {
                return m_PercentageRatio;
            }
        }
        #endregion

        #region InputScoreList
        /// <summary>
        /// Input score list.
        /// </summary>
        private List<float> m_InputScoreList = new List<float>();

        /// <summary>
        /// Gets actual score list.
        /// </summary>
        public List<float> InputScoreList
        {
            get
            {
                return m_InputScoreList;
            }
        }
        #endregion

        #region ActualScoreList
        /// <summary>
        /// Actual score list.
        /// </summary>
        private List<float> m_ActualScoreList = new List<float>();

        /// <summary>
        /// Gets actual score list.
        /// </summary>
        public List<float> ActualScoreList
        {
            get
            {
                return m_ActualScoreList;
            }
        }
        #endregion

        #region PercentageScoreList
        /// <summary>
        /// Percentage score list.
        /// </summary>
        private List<float> m_PercentageScoreList = new List<float>();

        /// <summary>
        /// Gets percentage score list.
        /// </summary>
        public List<float> PercentageScoreList
        {
            get
            {
                return m_PercentageScoreList;
            }
        }
        #endregion

        #region ActualScore
        /// <summary>
        /// Set by create.
        /// </summary>
        private float m_ActualScore = 0;

        /// <summary>
        /// Gets total actual score.
        /// </summary>
        public float ActualScore
        {
            get
            {
                return m_ActualScore;
            }
        }
        #endregion

        #region PercentageScore
        /// <summary>
        /// Set by create and update method calls.
        /// </summary>
        private float m_PercentageScore = 0;

        /// <summary>
        /// Gets total percentage score.
        /// </summary>
        public float PercentageScore
        {
            get
            {
                return m_PercentageScore;
            }
        }
        #endregion

        #region FailScore
        /// <summary>
        /// Total of fail percentage score.
        /// </summary>
        private float m_FailScore = 0;

        public float FailScore
        {
            get
            {
                return m_FailScore;
            }
        }
        #endregion

        #region PercentageClientCBRepository
        /// <summary>
        /// Constructor initialization.
        /// </summary>
        /// <param name="percentageRatio"></param>
        public PercentageClientCBRepository(float percentageRatio)
        {
            m_ClientID = Guid.NewGuid().ToString();
            m_PercentageRatio = percentageRatio;
        }
        #endregion

        #region CRUDLM
        #region CRUDL
        #region CRUD
        #region Create
        /// <summary>
        /// Sets or resets percentage score.
        /// </summary>
        /// <param name="contentObject"></param>
        public void Create(string contentObject)
        {
            try
            {
                m_InputScoreList.Clear();
                m_ActualScoreList.Clear();
                m_PercentageScoreList.Clear();
                
                m_ActualScore = float.Parse(contentObject);
                m_PercentageScore = (m_ActualScore * (m_PercentageRatio / 100));
                m_FailScore = m_ActualScore - m_PercentageScore;

                m_InputScoreList.Add(float.Parse(contentObject));
                m_ActualScoreList.Add(m_ActualScore);
                m_PercentageScoreList.Add(m_PercentageScore);

                FireCBCommunicationResult(CBCommunicationType.Create, contentObject, m_PercentageScore);
            }
            catch { }
        }
        #endregion

        #region Read
        /// <summary>
        /// Should report latest percentage score using CRUD2CRUD proxy.
        /// </summary>
        /// <param name="id"></param>
        public void Read(object id)
        {
            try
            {
                FireCBCommunicationResult(CBCommunicationType.Read, (string)id, m_PercentageScore);
            }
            catch { 
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates new percentage score.
        /// </summary>
        /// <param name="contentObject"></param>
        public void Update(string contentObject)
        {
            try
            {
                m_ActualScore += float.Parse(contentObject);
                m_PercentageScore += (float.Parse(contentObject) * (m_PercentageRatio / 100));
                m_FailScore = m_ActualScore - m_PercentageScore;

                m_InputScoreList.Add(float.Parse(contentObject));
                m_ActualScoreList.Add(m_ActualScore);
                m_PercentageScoreList.Add(m_PercentageScore);

                FireCBCommunicationResult(CBCommunicationType.Update, contentObject, m_PercentageScore);
            }
            catch { }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Resets score to argument value of contentObject.
        /// </summary>
        /// <param name="contentObject"></param>
        public void Delete(string contentObject)
        {
            m_InputScoreList.Clear();
            m_ActualScoreList.Clear();
            m_PercentageScoreList.Clear();

            m_ActualScore = m_PercentageScore = m_FailScore = 0;

            m_ActualScore = float.Parse(contentObject);
            m_PercentageScore = (m_ActualScore * (m_PercentageRatio / 100));

            m_FailScore = m_ActualScore - m_PercentageScore;

            m_InputScoreList.Add(float.Parse(contentObject));
            m_ActualScoreList.Add(m_ActualScore);
            m_PercentageScoreList.Add(m_PercentageScore);

            FireCBCommunicationResult(CBCommunicationType.Delete, contentObject, m_PercentageScore);
        }
        #endregion 
        #endregion

        #region List
        /// <summary>
        /// Lists score using CRUD2CRUD proxy with event notifications. 
        /// </summary>
        /// <param name="searchInput"></param>
        public void List(SearchInput searchInput)
        {
            try
            {
                if (!string.IsNullOrEmpty(searchInput.key))
                {
                    if (searchInput.key.Equals("actual", StringComparison.OrdinalIgnoreCase))
                    {
                        FireCBCommunicationResultList(CBCommunicationType.Read, searchInput, ActualScoreList);
                    }
                    else if (searchInput.key.Equals("percentage", StringComparison.OrdinalIgnoreCase))
                    {
                        FireCBCommunicationResultList(CBCommunicationType.Read, searchInput, PercentageScoreList);
                    }
                }
            }
            catch { }
        }
        #endregion
        #endregion

        #region CRUDM
        #region Method
        /// <summary>
        /// This method map functions with target, otherwise, instead extend from CRUDLMCBRepository for automatic method invocations.
        /// </summary>
        /// <param name="target"></param>
        public void Method(string target)
        {
            switch (target)
            {
                case "avg":
                    Avg();
                    break;
                case "max":
                    Max();
                    break;
                case "min":
                    Min();
                    break;
                case "fail":
                    Fail();
                    break;
            }
        }
        #endregion

        #region MethodObject
        /// <summary>
        /// Map functions with target, otherwise, instead extend from CRUDLMCBRepository for automatic method invocations.
        /// </summary>
        /// <param name="contentObject"></param>
        /// <param name="target"></param>
        public void MethodObject(object contentObject, string target)
        {
            throw new NotImplementedException();
        }
        #endregion  
        #endregion
        #endregion

        #region CRUDM_SCALE
        //CRUDMethod (CRUDM) scales following method invocations without extending communication interface.

        //ICRUDLMCBRepository is client side proxy callback repository (server =to= client) interface that support string_json data type.

        //CRUD2CRUD proxy support IService, IServiceCB (callback/duplex channel), IWCFService, IWCFServiceCB (callback/duplex channel)
        //for client =to= server CRUD2CRUD communication.

        #region Avg
        /// <summary>
        /// Calculates average score from percentage scores.
        /// </summary>
        public void Avg()
        {
            if (m_PercentageScoreList.Count > 0)
            {
                var avgScore = m_PercentageScore / m_PercentageScoreList.Count;
                FireCBCommunicationResult(CBCommunicationType.MethodObject, null, avgScore, "avg");
            }
            else
            {
                FireCBCommunicationResult(CBCommunicationType.MethodObject, null, 0, "avg");
            }
        }
        #endregion

        #region Max
        /// <summary>
        /// Calculates maximum score from percentage scores.
        /// </summary>
        public void Max()
        {
            float maxScore = 0;
            foreach (var score in m_InputScoreList)
            {
                if (score > maxScore)
                {
                    maxScore = score;
                }
            }

            FireCBCommunicationResult(CBCommunicationType.MethodObject, null, maxScore, "max");
        }
        #endregion

        #region Min
        /// <summary>
        /// Calculates minimum score from percentage scores.
        /// </summary>
        public void Min()
        {
            float minScore = float.MaxValue;
            foreach (var score in m_InputScoreList)
            {
                if (score < minScore)
                {
                    minScore = score;
                }
            }

            FireCBCommunicationResult(CBCommunicationType.MethodObject, null, minScore, "min");
        }
        #endregion

        #region Fail
        /// <summary>
        /// Calculates fail score from percentage scores.
        /// </summary>
        public void Fail()
        {
            FireCBCommunicationResult(CBCommunicationType.MethodObject, null, m_FailScore, "fail");
        }
        #endregion 
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Application.Models.Standard.DataAccess.Adapter;
using WindnTrees.ICRUDS.Standard.Model;

namespace ApplicationWPFCore.ViewModels
{
    public class ProductViewModel : ObserverObject<Product>
    {
        #region TotalLists
        private string m_TotalLists = string.Empty;
        public string TotalLists
        {
            get
            {
                return m_TotalLists;
            }
            set
            {
                OnPropertyChanging("TotalLists");
                m_TotalLists = value;
                OnPropertyChanged("TotalLists");
            }
        }
        #endregion

        public ProductViewModel()
        {
            
        }
    }
}
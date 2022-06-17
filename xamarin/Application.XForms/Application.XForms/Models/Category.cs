using System;
using System.Collections.Generic;
using System.Text;

namespace Application.XForms.Models
{
    /// <summary>
    /// Category, data model for communication between CRUDView and CRUDController (CRUD2CRUD).
    /// </summary>
    public class Category
    {
        public Guid Uid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
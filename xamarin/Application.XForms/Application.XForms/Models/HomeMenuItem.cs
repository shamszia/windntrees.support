using System;
using System.Collections.Generic;
using System.Text;

namespace Application.XForms.Models
{
    public enum MenuItemType
    {
        Items,
        Empty,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}

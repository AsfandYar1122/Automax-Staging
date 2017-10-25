using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutomaxWebSite.Models
{
    public class SearchFilter
    {
        public string Name { get; set; }
       
        public string ModelName { get; set; }
        public int RegisterId { get; set; }
        public int ColorId { get; set; }
        public string EngineName { get; set; }
        public string Price { get; set; }
       
        public string Type { get; set; }
        public string Transmission { get; set; }
        public string MinYear { get; set; }
        public string MaxYear { get; set; }
        public string SortOrder { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public bool FilterExist { get; set; }

    }
}
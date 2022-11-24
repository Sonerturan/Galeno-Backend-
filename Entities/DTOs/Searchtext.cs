using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class Searchtext:IDto
    {
        public string LanguageName { get; set; }
        public string BranchName { get; set; }
        public string CityName { get; set; }
    }
}

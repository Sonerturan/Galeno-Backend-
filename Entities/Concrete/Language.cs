using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Language:IEntity
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
    }
}

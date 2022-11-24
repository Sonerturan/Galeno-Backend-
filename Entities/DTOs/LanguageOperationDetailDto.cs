using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class LanguageOperationDetailDto:IDto
    {
        public int LanguageOperationId { get; set; }
        public string LanguageName { get; set; }
        public int DoctorId { get; set; }
    }
}

using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BranchOperationDetailDto:IDto
    {
        public int BranchOperationId { get; set; }
        public string BranchName { get; set; }
        public int DoctorId { get; set; }
    }
}

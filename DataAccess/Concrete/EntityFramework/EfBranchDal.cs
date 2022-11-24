using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch, GalenoContext>, IBranchDal
    {
        public List<BranchOperationDetailDto> GetBranchOperationDetails()
        {
            using (GalenoContext context = new GalenoContext())
            {
                var result = from b in context.Branches
                             join bo in context.BranchOperations
                             on b.BranchId equals bo.BranchId
                             select new BranchOperationDetailDto
                             {
                                 BranchOperationId = bo.BranchOperationId,
                                 BranchName = b.BranchName,
                                 DoctorId = bo.DoctorId

                             };
                return result.ToList();
            }
        }
    }
}

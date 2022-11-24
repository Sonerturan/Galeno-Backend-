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
    public class EfBranchOperationDal : EfEntityRepositoryBase<BranchOperation, GalenoContext>, IBranchOperationDal
    {
        public List<BranchOperationDetailDto> GetBranchOperationDetails(Expression<Func<BranchOperationDetailDto, bool>> filter = null)
        {
            using (GalenoContext context = new GalenoContext())
            {
                var result = from d in context.Doctors
                             join bo in context.BranchOperations
                             on d.DoctorId equals bo.DoctorId
                             join b in context.Branches
                             on bo.BranchId equals b.BranchId
                             select new BranchOperationDetailDto
                             {
                                 BranchOperationId = bo.BranchOperationId,
                                 BranchName = b.BranchName,
                                 DoctorId = d.DoctorId
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}

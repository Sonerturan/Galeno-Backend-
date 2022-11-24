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
    public class EfLanguageOperationDal : EfEntityRepositoryBase<LanguageOperation, GalenoContext>, ILanguageOperationDal
    {
        public List<LanguageOperationDetailDto> GetLanguageOperationDetails(Expression<Func<LanguageOperationDetailDto, bool>> filter=null)
        {
            using (GalenoContext context = new GalenoContext())
            {
                var result = from d in context.Doctors
                             join lo in context.LanguageOperations
                             on d.DoctorId equals lo.DoctorId
                             join l in context.Languages
                             on lo.LanguageId equals l.LanguageId
                             select new LanguageOperationDetailDto
                             {
                                 LanguageOperationId=lo.LanguageOperationId,
                                 LanguageName=l.LanguageName,
                                 DoctorId = d.DoctorId
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}

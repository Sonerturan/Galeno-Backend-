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
    public class EfLanguageDal : EfEntityRepositoryBase<Language, GalenoContext>, ILanguageDal
    {
        public List<LanguageOperationDetailDto> GetLanguageOperationDetails()
        {
            using (GalenoContext context = new GalenoContext())
            {
                var result = from l in context.Languages
                             join lo in context.LanguageOperations
                             on l.LanguageId equals lo.LanguageId
                             select new LanguageOperationDetailDto
                             {
                                 LanguageOperationId=lo.LanguageOperationId,
                                 LanguageName = l.LanguageName,
                                 DoctorId = lo.DoctorId
                                 
                             };
                return result.ToList();
            }
        }
    }
}

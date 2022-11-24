using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ILanguageOperationDal : IEntityRepository<LanguageOperation>
    {
        List<LanguageOperationDetailDto> GetLanguageOperationDetails(Expression<Func<LanguageOperationDetailDto, bool>> filter=null);
    }
}

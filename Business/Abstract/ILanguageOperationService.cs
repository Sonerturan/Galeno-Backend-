using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILanguageOperationService
    {
        IDataResult<List<LanguageOperation>> GetAll();
        IDataResult<List<LanguageOperation>> GetAllByDoctorId(int id);
        IDataResult<List<LanguageOperation>> GetAllByLanguageId(int id);
        IResult Add(LanguageOperation languageOperation);
        IResult Update(LanguageOperation languageOperation);
        IResult Delete(LanguageOperation languageOperation);

        IDataResult<List<LanguageOperationDetailDto>> GetLanguageOperationDetails();
        IDataResult<List<LanguageOperationDetailDto>> GetAllByDoctorIdDetails(int id);

    }
}

using Business.Abstract;
using Business.Constans;
using Core.Aspects.AutoFac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public LanguageManager()
        {

        }

        [CacheAspect]
        public IDataResult<List<Language>> GetAll()
        {
            return new SuccessDataResult<List<Language>>(_languageDal.GetAll(), Messages.Listed);
        }


    }
}

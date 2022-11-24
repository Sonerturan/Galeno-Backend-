using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IExperienceService
    {
        IDataResult<List<Experience>> GetAll();
        IDataResult<List<Experience>> GetAllByDoctorId(int id);
        IResult Add(Experience experience);
        IResult Update(Experience experience);
        IResult Delete(Experience experience);

    }
}

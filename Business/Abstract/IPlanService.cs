using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPlanService
    {
        IResult Add(Plan plan);
        IResult Delete(Plan plan);
        IResult Update(Plan plan);
        IDataResult<List<Plan>> GetActivePlans();
        IDataResult<List<Plan>> GetAll();
    }
}

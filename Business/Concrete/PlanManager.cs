using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PlanManager : IPlanService
    {
        IPlanDal _planDal;

        public PlanManager(IPlanDal planDal)
        {
            _planDal = planDal;
        }
        [ValidationAspect(typeof(PlanValidator))]
        public IResult Add(Plan plan)
        {
            IResult result = BusinessRules.Run(CheckIfPlanAlreadyExists(plan.Date));
            if(result != null)
            {
                return result;
            }
            _planDal.Add(plan);
            return new SuccessResult();
        }

        public IResult Delete(Plan plan)
        {
            _planDal.Delete(plan);
            return new SuccessResult(Messages.PlanDeleted);
        }
        public IDataResult<List<Plan>> GetAll()
        {
            return new SuccessDataResult<List<Plan>>(_planDal.GetAll().ToList());
        }

        public IDataResult<List<Plan>> GetActivePlans()
        {
            return new SuccessDataResult<List<Plan>>(_planDal.GetAll(p=>p.Date>=DateTime.Now).ToList());
        }

        public IResult Update(Plan plan)
        {
            _planDal.Update(plan);
            return new SuccessResult();
        }
        
        private IResult CheckIfPlanAlreadyExists(DateTime date)
        {
            var listedPlans = _planDal.GetAll(p => p.Date == date);
            foreach (var plan in listedPlans)
            {                
                if(plan.Date == date)
                {
                    return new ErrorResult(Messages.YouAlreadyHavePlan);
                }
            }            
            return new SuccessResult();       
                      
        }
    }
}

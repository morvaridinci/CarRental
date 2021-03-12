using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin,brand.add")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidator(), brand);
            _brandDal.Add(brand);
            
            return new SuccessResult(Messages.BrandAdded);

        }

        [SecuredOperation("admin,brand.delete")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Brand>>  GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        [CacheAspect]
        public IDataResult<Brand> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(c=>c.BrandId==brandId));
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Brand brand)
        {
            _brandDal.Update(brand);
            _brandDal.Add(brand);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("admin,brand.update")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult();
        }
    }
}

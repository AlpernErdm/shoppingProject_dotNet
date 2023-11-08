using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.AddedCategory);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
            }
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.NoDataInList);

        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var result = _categoryDal.Get(p => p.CategoryId == categoryId);
            if (result != null)
            {
                return new SuccessDataResult<Category>(result);
            }
            return new SuccessDataResult<Category>(result, Messages.NoDataOnFilter);
        }

        public IResult Remove(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}

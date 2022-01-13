using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace core.Specifications
{
    public interface ISpecification<T>
    {
         Expression<Func<T,bool>> Criteria{get;}
         List<Expression<Func<T,object>>> Includes{get;}
         Expression<Func<T,object>> OrderBy{get;} // for order asc
          Expression<Func<T,object>> OrderByDescending{get;} //for order desc

          int Take{get;}//for filtering

          int Skip{get;}//also for filtering

          bool IspagingEnabled{get;}
    }
}
using Core.Entities;
using Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class TodoWithFiltersForCountSpecification : BaseSpecification<Todo>
    {
        public TodoWithFiltersForCountSpecification(TodoSpecParams todoSpecParams) :
            base(x =>
            (string.IsNullOrEmpty(todoSpecParams.Search) || x.Title.ToLower().Contains(todoSpecParams.Search)) &&
           (!todoSpecParams.CategoryId.HasValue || x.CategoryId == todoSpecParams.CategoryId) 
            )
        {

        }
    }
}

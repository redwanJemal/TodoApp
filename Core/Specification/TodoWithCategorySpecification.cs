using Core.Entities;
using Core.Specification;

namespace Core.Specifications
{
    public class TodoWithCategorySpecification : BaseSpecification<Todo>
    {
        public TodoWithCategorySpecification(TodoSpecParams todoParams) :
            base( x =>
            (string.IsNullOrEmpty(todoParams.Search) || x.Title.ToLower().Contains(todoParams.Search)) &&
            (!todoParams.CategoryId.HasValue || x.CategoryId == todoParams.CategoryId)
            )
        {
            AddIncludes(x => x.Category);
            AddOrderBy(x => x.Title);
            ApplyPaging(todoParams.PageSize * (todoParams.PageIndex - 1), todoParams.PageSize);

        }

        public TodoWithCategorySpecification(int criteria) : base(x => x.Id == criteria)
        {
            AddIncludes(x => x.Category);
        }
    }
}

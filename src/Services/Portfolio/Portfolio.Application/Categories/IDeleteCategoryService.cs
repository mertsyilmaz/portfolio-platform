using Portfolio.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Categories
{
    public interface IDeleteCategoryService
    {
        Task<DeleteCategoryResponse?> DeleteAsync(Guid id);
    }
}

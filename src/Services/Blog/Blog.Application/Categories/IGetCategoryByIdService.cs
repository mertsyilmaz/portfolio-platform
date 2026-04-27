using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public interface IGetCategoryByIdService
    {
        Task<GetCategoriesResponse> GetByIdAsync(Guid id);
    }
}

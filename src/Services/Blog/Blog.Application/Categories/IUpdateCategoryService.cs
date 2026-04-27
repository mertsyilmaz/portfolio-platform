using Blog.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Categories
{
    public interface IUpdateCategoryService
    {
        Task<UpdateCategoryResponse> UpdateAsync(Guid id, UpdateCategoryRequest request);
    }
}

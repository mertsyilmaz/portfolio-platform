using Portfolio.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Categories
{
    public interface IGetCategoryByIdService
    {
        Task<GetCategoryByIdResponse?> GetByIdAsync(Guid id);
    }
}

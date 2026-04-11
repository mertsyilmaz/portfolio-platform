using Portfolio.Contracts.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Application.Categories
{
    public interface IGetCategoriesService
    {
        Task<List<GetCategoriesResponse>> GetAllAsync();
    }
}

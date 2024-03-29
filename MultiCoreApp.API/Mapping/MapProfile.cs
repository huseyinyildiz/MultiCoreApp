﻿using AutoMapper;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Mapping
{
    public class MapProfile:Profile
    {

        public MapProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Category, CategoryWithProductsDto>();
            CreateMap<CategoryWithProductsDto, Category>();

            CreateMap<Product, ProductWithCategoryDto>();
            CreateMap<ProductWithCategoryDto, Product>();
        }

    }
}

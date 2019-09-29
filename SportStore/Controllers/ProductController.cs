﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportStore.Models;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models.ViewModels;
namespace SportStore.Controllers
{
    public class ProductController:Controller
    {
        private IProductRepository repository;
        public int PageSize =4;
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(int page=1) 
            ////=> View
            ////(repository.Products
            => View
            (new ProductsListViewModel
            {
                Products = repository.Products
            .OrderBy(p => p.ProductID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            });
        ////.OrderBy(p=>p.ProductID)
        ////.Skip((page-1)*PageSize)
        ////.Take(PageSize));
    }
}

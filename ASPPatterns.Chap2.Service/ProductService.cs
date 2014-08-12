﻿using System.Collections.Generic;
using System.Web;

namespace ASPPatterns.Chap2.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            string storageKey = string.Format("products_in_category_id_{0}", categoryId);
            IList<Product> products = (List<Product>) HttpContext.Current.Cache.Get(storageKey);
            if (products == null)
            {
                products = _productRepository.GetAllProductsIn(categoryId);
                HttpContext.Current.Cache.Insert(storageKey,products);
            }
            return products;
        }
    }
}

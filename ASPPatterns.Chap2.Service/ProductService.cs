﻿using System.Collections.Generic;

namespace ASPPatterns.Chap2.Service
{
    public class ProductService
    {
        private IProductRepository _productRepository;
        private ICacheStorage _cacheStorage;

        public ProductService(IProductRepository productRepository,ICacheStorage cacheStorage)
        {
            _productRepository = productRepository;
            _cacheStorage = cacheStorage;
        }

        public IList<Product> GetAllProductsIn(int categoryId)
        {
            string storageKey = string.Format("products_in_category_id_{0}", categoryId);
            IList<Product> products = _cacheStorage.Retrieve<List<Product>>(storageKey); //(List<Product>) HttpContext.Current.Cache.Get(storageKey);

            if (products == null)
            {
                string aa;
                products = _productRepository.GetAllProductsIn(categoryId);
                _cacheStorage.Store(storageKey, products);
            }
            return products;
        }
    }
}

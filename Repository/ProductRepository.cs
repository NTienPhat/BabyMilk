using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        public void CreateNewProduct(Product cate) => ProductDAO.Instance.CreateNewProduct(cate);

        public void DeleteProduct(Product cate) => ProductDAO.Instance.DeleteProduct(cate);

        public async Task<Product> GetProductById(int id) => await ProductDAO.Instance.GetProductById(id);

        public async Task<List<Product>> GetProduct(int page, int pageSize) => await ProductDAO.Instance.GetProduct(page, pageSize);

        public List<Product> SearchByKeyword(string keyword) => ProductDAO.Instance.SearchByKeyword(keyword);

        public void UpdateProduct(Product cate) => ProductDAO.Instance.UpdateProduct(cate);
    }
}

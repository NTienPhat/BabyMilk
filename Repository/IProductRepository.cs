using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProduct(int page, int pageSize);
        Task<List<Product>> GetAll();
        void DeleteProduct(Product cate);
        Task<Product> GetProductById(int id);
        void UpdateProduct(Product cate);
        void CreateNewProduct(Product cate);
        List<Product> SearchByKeyword(string keyword);
    }
}

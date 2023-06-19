using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductBabyDevelopmentRepository
    {
        List<ProductBabyDevelopment> GetProductBabyDevelopment();
        void DeleteProductBabyDevelopment(ProductBabyDevelopment cate);
        ProductBabyDevelopment GetProductBabyDevelopmentById(int id);
        void UpdateProductBabyDevelopment(ProductBabyDevelopment cate);
        void CreateNewProductBabyDevelopment(ProductBabyDevelopment cate);
    }
}

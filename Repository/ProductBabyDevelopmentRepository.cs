using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductBabyDevelopmentRepository : IProductBabyDevelopmentRepository
    {
        public void CreateNewProductBabyDevelopment(ProductBabyDevelopment cate) => ProductBabyDevelopmentDAO.Instance.CreateNewProductBabyDevelopment(cate);

        public void DeleteProductBabyDevelopment(ProductBabyDevelopment cate) => ProductBabyDevelopmentDAO.Instance.DeleteProductBabyDevelopment(cate);

        public ProductBabyDevelopment GetProductBabyDevelopmentById(int id) => ProductBabyDevelopmentDAO.Instance.GetProductBabyDevelopmentsId(id);

        public List<ProductBabyDevelopment> GetProductBabyDevelopment() => ProductBabyDevelopmentDAO.Instance.GetProductBabyDevelopment();

        public void UpdateProductBabyDevelopment(ProductBabyDevelopment cate) => ProductBabyDevelopmentDAO.Instance.UpdateProductBabyDevelopment(cate);
    }
}

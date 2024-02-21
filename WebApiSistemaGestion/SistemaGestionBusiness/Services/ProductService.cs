using SistemaGestionData.Interfaces;
using SistemaGestionEntities.models;
using SistemaGestionData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SistemaGestionBusiness.Services
{
    public class ProductService
    {
        private readonly IProductoRepository _productRepository;

        public ProductService(IProductoRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Producto? GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public IEnumerable<Producto> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public bool AddProduct(Producto product)
        {
            try
            {

                if (_productRepository.Add(product))
                {
                    Console.WriteLine($"Adding product: {product.FullProduct()}");
                    return true;
                }
                return false;
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product:", ex);
            }
        }


        public int DeleteProduct(int id)
        {
            if (id != -1)
            {
                int resultDeleteProduct = _productRepository.Delete(id);
                Console.WriteLine(resultDeleteProduct);
                return resultDeleteProduct;
            }
            else
            {
                throw new Exception("Could not delete product");
            }
        }

        public bool UpdateProduct(int id, Producto product)
        {
            try
            {
                if (id != -1)
                {
                    if(_productRepository.Update(id, product))
                    {
                        Console.WriteLine(product.FullProduct());
                        return true;
                    }
                }
                return false;
            }
            catch(Exception ex)
            {
                throw new Exception("An error occurred while updating the product:", ex);
            }
        }
    }

}

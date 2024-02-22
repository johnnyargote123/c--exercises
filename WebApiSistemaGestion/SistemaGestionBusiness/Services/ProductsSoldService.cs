using SistemaGestionEntities.models;
using SistemaGestionData.Interfaces;
using SistemaGestionData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionDTO;
using SistemaGestionMapper;

namespace SistemaGestionBusiness.Services
{
    public class ProductsSoldService
    {
        private readonly IProductsSoldRepository _productsSoldRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly ProductSoldMapper _productSoldMapper;

        public ProductsSoldService(IProductsSoldRepository productsSoldRepository, IProductoRepository productoRepository, ProductSoldMapper productSoldMapper)
        {
            _productsSoldRepository = productsSoldRepository;
            _productoRepository = productoRepository;
            _productSoldMapper = productSoldMapper;
        }



        public ProductoVendido? GetProductsSoldById(int id)
        {
            return _productsSoldRepository.GetById(id);
        }

        public List<ProductoVendidoDTO> GetProductSoldByUserId(int userId)
        {

            List<Producto> products = this._productoRepository.GetByUserId(userId);
            List<ProductoVendidoDTO> soldProducts = new List<ProductoVendidoDTO>();
            foreach (var productId in products)
            {
                List<ProductoVendidoDTO> productsSoldForProduct =  this._productSoldMapper.ListProductSoldDTOToMapper(this._productsSoldRepository.GetByProductId(productId.Id));

                


                soldProducts.AddRange(productsSoldForProduct);

            }
            return soldProducts;

        }

        public IEnumerable<ProductoVendido> GetAllProductsSold()
        {
            return _productsSoldRepository.GetAll();
        }

        public bool AddProductsSold(ProductoVendido productSold)
        {
            try
            {

                if (_productsSoldRepository.Add(productSold))
                {
                    Console.WriteLine($"Adding product Sold: {productSold.FullDataProductSold()}");
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the product Sold:", ex);
            }
        }

        public int DeleteProductsSold(int id)
        {
            if (id != -1)
            {
                int resultDeleteProductSold = _productsSoldRepository.Delete(id);
                Console.WriteLine(resultDeleteProductSold);
                return resultDeleteProductSold;
            }
            else
            {
                throw new Exception("Could not delete product Sold");
            }
        }

        public bool UpdateProductsSold(int id, ProductoVendido productSold)
        {
            try
            {
                if (id != -1)
                {
                    if (_productsSoldRepository.Update(id, productSold))
                    {
                        Console.WriteLine(productSold.FullDataProductSold());
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the user:", ex);
            }
        }
    }
}

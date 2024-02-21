using SistemaGestionEntities.models;
using SistemaGestionData.Interfaces;
using SistemaGestionData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBusiness.Services
{
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public Venta? GetSaleById(int id)
        {
            return _saleRepository.GetById(id);
        }
        public IEnumerable<Venta> GetAllSales()
        {
            return _saleRepository.GetAll();
        }


        public bool AddSale(Venta sale)
        {
            try
            {

                if (_saleRepository.Add(sale))
                {
                    Console.WriteLine($"Adding Sale: {sale.FullDataSale()}");
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the sale:", ex);
            }
        }

        public int DeleteSale(int id)
        {
            if (id != -1)
            {
                int resultDeleteSale = _saleRepository.Delete(id);
                Console.WriteLine(resultDeleteSale);
                return resultDeleteSale;
            }
            else
            {
                throw new Exception("Could not delete sale");
            }
        }

        public bool UpdateSale(int id, Venta sale)
        {
            try
            {
                if (id != -1)
                {
                    if (_saleRepository.Update(id, sale))
                    {
                        Console.WriteLine(sale.FullDataSale());
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the sale:", ex);
            }
        }



    }
}

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
    public class SaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly SaleMapper _saleMapper;

        public SaleService(ISaleRepository saleRepository, SaleMapper saleMapper)
        {
            _saleRepository = saleRepository;
            _saleMapper = saleMapper;
        }

        public Venta? GetSaleById(int id)
        {
            return _saleRepository.GetById(id);
        }

        public List<VentaDTO> GetSaleByUserId(int userId)
        {
            List<Venta> venta = this._saleRepository.GetByUserId(userId);
            List<VentaDTO> ventaDTO = this._saleMapper.ListSaleDTOToMapper(venta);
            return ventaDTO;
        }

        public List<Venta> GetAllSales()
        {
            return _saleRepository.GetAll();
        }


        public bool AddSale(VentaDTO sale)
        {
            try
            {
                Venta venta = this._saleMapper.SaleToMapper(sale);

                if (_saleRepository.Add(venta))
                {
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

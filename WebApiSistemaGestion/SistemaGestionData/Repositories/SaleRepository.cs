using Entities.models;
using SistemaGestionData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Repositories
{
    public class SaleRepository: ISaleRepository
    {

        private readonly IDatabaseContextFactory _contextFactory;

        public SaleRepository(IDatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Venta GetById(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    Venta? sale = _context.Venta.FirstOrDefault(u => u.Id == id);

                    if (sale == null)
                    {
                        throw new Exception("Sale not found with the specified ID.");
                    }

                    return sale;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user by ID.", ex);
            }

        }

        public IEnumerable<Venta> GetAll()
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    IEnumerable<Venta> saleList = _context.Venta.ToList();

                    if (saleList.Count() == 0)
                    {
                        throw new Exception("The list of sales is empty.");
                    }

                    return saleList;
                }


            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving sale.", ex);
            }
        }

        public bool Add(Venta sale)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    if (sale != null)
                    {
                        _context.Venta.Add(sale);
                        int _saleSaved = _context.SaveChanges();
                        if (_saleSaved > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                        throw new Exception("Sale cannot be null");
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the sale:", ex);

            }
        }

        public int Delete(int id)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {


                    var SaleToDelete = _context.Venta.FirstOrDefault(s => s.Id == id);

                    if (SaleToDelete != null)
                    {
                        _context.Venta.Remove(SaleToDelete);
                        _context.SaveChanges();
                        return id;
                    }
                    else
                    {
                        throw new Exception("No sale found with the provided ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while delete the sale:", ex);

            }

        }
        public bool Update(int id, Venta sale)
        {
            try
            {
                using (var _context = _contextFactory.CreateDbContext())
                {
                    var existingSale = _context.Venta.FirstOrDefault(s => s.Id == id);

                    if (existingSale != null)
                    {
                        existingSale.Comentarios = sale.Comentarios;
                        existingSale.IdUsuario = sale.IdUsuario;


                        _context.SaveChanges();
                        return true;
                    }

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while update the sale:", ex);
            }
        }
    }
}

using AplicacionTp6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionTp6.Services
{
    public interface IProductoService
    {
        //Servicio para traer productos
        Task<IEnumerable<Producto>> GetProductsAsync();
        //Servicio para crear productos
        Task<Producto> CreateProductAsync(Producto producto);
        //Servicio para editar productos
        Task<bool> UpdateProductAsync(int id, Producto producto); 
        //Servicio para eliminar productos
        Task<bool> DeleteProductAsync(int id); 
    }
}

using Entities.models;
using Microsoft.Extensions.DependencyInjection;
using SistemaGestionBusiness.Services;
using SistemaGestionData.Interfaces;
using SistemaGestionData.Repositories;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Configurar el contenedor de inyección de dependencias
            var serviceProvider = new ServiceCollection();
            DependencyInjectionService.RegisterServices(serviceProvider);

            // Construir el proveedor de servicios
            var provider = serviceProvider.BuildServiceProvider();

            // Obtener instancias de los servicios necesarios
            var productService = provider.GetService<ProductService>();
            var userService = provider.GetService<UserService>();
            var saleService = provider.GetService<SaleService>();
            var productsSoldService = provider.GetService<ProductsSoldService>();






            //------------------------------------------------------------------------------>>
            //-----------------------------------Usuarios----------------------------------->>
            //------------------------------------------------------------------------------>>




            // Usuario por ID -------------------------------------------------------------->>

            //Usuario? usuario = userService.GetUserById(1);
            //Console.WriteLine(usuario.FullDataUser());

            // Todos los Usuarios ---------------------------------------------------------->>

            //IEnumerable<Usuario> allUser = userService.GetAllUsers();

            //foreach (var usuarios in allUser)
            //{
            //    Console.WriteLine($"id:{usuarios.Id}, nombre:{usuarios.Nombre}, " +
            //        $"apellido:{usuarios.Apellido}, nombre de usuario:{usuarios.NombreUsuario}, " +
            //        $"contraseña:{usuarios.Contraseña}, mail:{usuarios.Mail}");
            //}

            // Agregar Usuario ----------------------------------------------------------->>

            //Usuario NewUser = new Usuario("Vicente", "Fernandez", "ElVice", "ViceFer123", "elrey123@hotmail.com");
            //userService.AddUser(NewUser);


            // Eliminar Usuario ---------------------------------------------------------->>

            //userService.DeleteUser(7);

            // Actualizar usuario -------------------------------------------------------->>

            //Usuario UpdateUser = new Usuario("Wilder", "Andrey", "WilIng", "wil123", "wilderAnd@hotmail.com");
            //userService.UpdateUser(3, UpdateUser);




            //------------------------------------------------------------------------------>>
            //-----------------------------------Productos---------------------------------->>
            //------------------------------------------------------------------------------>>




            //// Configurar el contenedor de inyección de dependencias
            //var serviceProvider = new ServiceCollection()
            //    .AddScoped<IProductoRepository, ProductRepository>()
            //    .AddScoped<ProductService>()
            //    .BuildServiceProvider();

            //// Obtener una instancia de ProductService del contenedor
            //var productService = serviceProvider.GetService<ProductService>();

            //// Utilizar el ProductService para realizar operaciones




            // Producto por ID ------------------------------------------------------------->>

            Producto producto = productService.GetProductById(1);
            Console.WriteLine(producto.FullProduct());

            // Todos los productos --------------------------------------------------------->>

            //IEnumerable<Producto> allproductos = productService.GetAllProducts();

            //foreach (var producto in allproductos)
            //{
            //    Console.WriteLine($"id:{producto.Id}, descripción:{producto.Descripciones},
            //    costo:{producto.Costo}, precio Venta:{producto.PrecioVenta},
            //    stock:{producto.IdUsuario}");
            //}


            // Agregar producto ----------------------------------------------------------->>

            //Producto NewProduct = new Producto("Pokebola", 900, 1200, 20, 1);
            //productService.AddProduct(NewProduct);
            //Console.WriteLine(productService.AddProduct(null));

            // Eliminar producto --------------------------------------------------------->>

            //productService.DeleteProduct(40);

            // Actualizar producto ------------------------------------------------------->>

            //Producto UpdateToProducto = new Producto("Buzo mediano XX", 1200, 3200, 10, 1);
            //productService.UpdateProduct(1,UpdateToProducto);





            //------------------------------------------------------------------------------>>
            //-----------------------------------Ventas------------------------------------->>
            //------------------------------------------------------------------------------>>




            // venta por ID ---------------------------------------------------------------->>

            //Venta? sale = saleService.GetSaleById(4);
            //Console.WriteLine(sale.FullDataSale());


            // Todas las ventas ------------------------------------------------------------>>

            //IEnumerable<Venta> allSales = saleService.GetAllSales();

            //foreach (var venta in allSales)
            //{
            //    Console.WriteLine($"id:{venta.Id}, Comentarios:{venta.Comentarios}, Id Usuario:{venta.IdUsuario}");
            //}


            // Agregar ventas ------------------------------------------------------------->>

            //Venta NewSale = new Venta( "Es mi comentario", 1);
            //saleService.AddSale(NewSale);

            // Eliminar venta ------------------------------------------------------------->>

            //saleService.DeleteSale(7);


            // Actualizar venta ----------------------------------------------------------->>

            //Venta UpdateToVenta = new Venta( "actualice comentario", 1);
            //saleService.UpdateSale(1, UpdateToVenta);





            //------------------------------------------------------------------------------>>
            //------------------------------Producto Vendido-------------------------------->>
            //------------------------------------------------------------------------------>>



            // Producto Vendido por ID ----------------------------------------------------->>

            //ProductoVendido? productsSold = productsSoldService.GetProductsSoldById(1);
            //Console.WriteLine(productsSold.FullDataProductSold());


            // Todos los productos vendidos ------------------------------------------------>>

            //IEnumerable<ProductoVendido> allproductosVendidos = productsSoldService.GetAllProductsSold();

            //foreach (var productosVendidos in allproductosVendidos)
            //{
            //    Console.WriteLine($"id:{productosVendidos.Id}, Stock:{productosVendidos.Stock}, Id Producto:{productosVendidos.IdProducto}, Id Venta:{productosVendidos.IdVenta}");
            //}


            // Agregar Producto Vendido ---------------------------------------------------->>

            //ProductoVendido NewProductSold = new ProductoVendido(40, 2, 1);
            //productsSoldService.AddProductsSold(NewProductSold);

            // Eliminar Producto Vendido --------------------------------------------------->>

            //productsSoldService.DeleteProductsSold(5);

            // Actualizar Producto Vendido -------------------------------------------------->>

            //ProductoVendido UpdateToProductoVendido = new ProductoVendido(10, 2, 1);
            //productsSoldService.UpdateProductsSold(2, UpdateToProductoVendido);

        }
    }
}
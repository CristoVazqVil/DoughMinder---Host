using Clases.Contratos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Numerics;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Servicio : IInsumo, IReceta, IEmpleado, IProveedor, IMovimiento, IProducto, ISolicitud, IPedido, ILogin
    {
        const int CODIGO_BASE = -1;
        const int CODIGO_UTILIZADO = -5;
        const int VALOR_POR_DEFECTO = 0;

        public int GuardarProveedor(Proveedor proveedor)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeProveedor = context.Proveedor.Any(i => i.RFC == proveedor.RFC);
                    if (existeProveedor)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        context.Proveedor.Add(proveedor);

                        codigo = context.SaveChanges();
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int GuardarEmpleado(Empleado empleado)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeEmpleado = context.Empleado.Any(i => i.Nombre == empleado.Usuario);
                    if (existeEmpleado)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        context.Empleado.Add(empleado);
                        

                        codigo = context.SaveChanges();
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int GuardarInsumo(Insumo insumo)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeInsumo = context.Insumo.Any(i => i.Nombre == insumo.Nombre || i.Codigo == insumo.Codigo);
                    if (existeInsumo)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        context.Insumo.Add(insumo);

                        codigo = context.SaveChanges();
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int GuardarProducto(Producto producto)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeProducto = context.Producto.Any(p => p.Nombre == producto.Nombre);
                    if (existeProducto)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        context.Producto.Add(producto);
                        codigo = context.SaveChanges();
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int GuardarReceta(Receta receta, Dictionary<int, float> listaInsumos)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeReceta = context.Receta.Any(r => r.Nombre == receta.Nombre || r.Codigo == receta.Codigo);
                    if (existeReceta)
                    {
                        codigo = VALOR_POR_DEFECTO;
                        return codigo;
                    }

                    context.Receta.Add(receta);

                    context.SaveChanges();

                    foreach (var kvp in listaInsumos)
                    {
                        InsumoReceta insumoReceta = new InsumoReceta
                        {
                            IdReceta = receta.IdReceta,
                            IdInsumo = kvp.Key,
                            Cantidad = kvp.Value
                        };

                        context.InsumoReceta.Add(insumoReceta);
                    }

                    codigo = context.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public Dictionary<int, string> RecuperarInsumos()
        {
            Dictionary<int, string> insumos = new Dictionary<int, string>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultados = context.Insumo
                        .Where(i => i.Estado == true)
                        .Select(i => new { i.IdInsumo, i.Nombre })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        insumos.Add(resultado.IdInsumo, resultado.Nombre);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return insumos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return insumos;
                }
            }

            return insumos;
        }


        public int RegistrarMovimiento(Movimiento movimiento)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;
                    context.Movimiento.Add(movimiento);
                    codigo = context.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public Dictionary<int, string> RecuperarRecetas()
        {
            Dictionary<int, string> recetas = new Dictionary<int, string>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultados = context.Receta
                        .Where(i => i.Estado == true)
                        .Select(i => new { i.IdReceta, i.Nombre })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        recetas.Add(resultado.IdReceta, resultado.Nombre);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return recetas;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return recetas;
                }
            }

            return recetas;
        }

        public Dictionary<string, string> RecuperarEmpleados()
        {
            Dictionary<string, string> empleados = new Dictionary<string, string>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultados = context.Empleado
                        .Select(i => new { i.Nombre, i.Paterno, i.RFC })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        empleados.Add(resultado.Nombre + " " + resultado.Paterno, resultado.RFC);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return empleados;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return empleados;
                }
            }

            return empleados;
        }

        public List<Proveedor> RecuperarProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Proveedor.Select(p => new {p.IdProveedor, p.Nombre, p.Telefono, p.Email, p.RFC, p.Estado}).ToList();
                    foreach (var item in resultado)
                    {
                        Proveedor proveedor = new Proveedor
                        {
                            IdProveedor = item.IdProveedor,
                            Nombre = item.Nombre,
                            Telefono = item.Telefono,
                            Email = item.Email,
                            RFC = item.RFC,
                            Estado = item.Estado,
                        };

                        proveedores.Add(proveedor);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return proveedores;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return proveedores;
                }
            }

            return proveedores;
        }

        public List<Insumo> RecuperarTodosInsumos()
        {
            List<Insumo> insumos = new List<Insumo>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Insumo.ToList();

                    foreach(var item in resultado)
                    {
                        Insumo insumo = new Insumo
                        {
                            IdInsumo = item.IdInsumo,
                            Nombre = item.Nombre,
                            CantidadKiloLitro = item.CantidadKiloLitro,
                            Estado = item.Estado,
                            RutaFoto = item.RutaFoto,
                            PrecioKiloLitro = item.PrecioKiloLitro,
                            Codigo = item.Codigo
                        };

                        insumos.Add(insumo);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return insumos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return insumos;
                }
            }

            return insumos;
        }

        public List<Producto> RecuperarProductosSinReceta()
        {
            List<Producto> productos = new List<Producto>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Producto.Where(p => p.IdReceta == null).ToList();
                    foreach (var item in resultado)
                    {
                        Producto producto = new Producto
                        {
                            CodigoProducto = item.CodigoProducto,
                            Nombre = item.Nombre,
                            Cantidad = item.Cantidad,
                            Precio = item.Precio,
                            IdReceta = item.IdReceta,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            Restricciones = item.Restricciones,
                            Foto = item.Foto,
                        };

                        productos.Add(producto);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
            }

            return productos;
        }

    public Empleado BuscarEmpleado(string RFC)
        {
            Empleado empleadoEncontrado = null;

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Empleado
                                        .Where(e => e.RFC == RFC)
                                        .FirstOrDefault();

                    if (resultado != null)
                    {
                        empleadoEncontrado = new Empleado
                        {
                            Usuario = resultado.Usuario,
                            Nombre = resultado.Nombre,
                            Paterno = resultado.Paterno,
                            Materno = resultado.Materno,
                            IdPuesto = resultado.IdPuesto,
                            Telefono = resultado.Telefono,
                            Estado = resultado.Estado,
                            Contraseña = resultado.Contraseña,
                            Direccion = resultado.Direccion,
                            Correo = resultado.Correo,
                            RFC = resultado.RFC
                            
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al buscar empleado: " + ex.Message);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine("Error al buscar empleado: " + ex.Message);
                }
            }

            return empleadoEncontrado;
        }


        public int ReemplazarEmpleado(string usuario)
        {
            int codigo = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var empleadoEncontrado = context.Empleado.FirstOrDefault(e => e.Usuario == usuario);

                    if (empleadoEncontrado != null)
                    {
                        context.Empleado.Remove(empleadoEncontrado);
                        codigo = context.SaveChanges();
                    }
                    else
                    {
                        codigo = -1;
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = -1;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = 0;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = -1;
            }

            return codigo;
        }

        public string RegistrarSolicitud(Solicitud solicitud, List<SolicitudProducto> solicitudProductos)
        {
            string clave = string.Empty;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.Log = Console.WriteLine;
                        context.Solicitud.Add(solicitud);

                        context.SaveChanges();
                        solicitud.Clave = $"SOL-{solicitud.IdSolicitud}";
                        context.SaveChanges();

                        List<Producto> productos = new List<Producto>();
                        List<Insumo> insumos = new List<Insumo>();

                        foreach (var sp in solicitudProductos)
                        {
                            sp.IdSolicitud = solicitud.IdSolicitud;
                            context.SolicitudProducto.Add(sp);

                            if (sp.ClaveProducto != null)
                            {
                                Producto producto = new Producto
                                {
                                    CodigoProducto = sp.ClaveProducto,
                                    Cantidad = (int?)sp.Cantidad,
                                };

                                productos.Add(producto);
                            }
                            
                            if (sp.IdInsumo != null)
                            {
                                Insumo insumo = new Insumo
                                {
                                    IdInsumo = (int)sp.IdInsumo,
                                    CantidadKiloLitro = (double?)sp.Cantidad,
                                };

                                insumos.Add(insumo);
                            }
                        }

                        context.SaveChanges();

                        int actualizacionProductos = ActualizarCantidadProductos(productos);
                        int actualizacionInsumos = ActualizarCantidadInsumos(insumos);

                        if (actualizacionProductos > 0 && actualizacionInsumos > 0)
                        {
                            context.SaveChanges();
                            transaction.Commit();
                            clave = solicitud.Clave;
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                clave = CODIGO_BASE.ToString();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                clave = CODIGO_BASE.ToString();
            }
             
            return clave;
        }

        public List<Producto> RecuperarProductosParaPedido()
        {
            List<Producto> productos = new List<Producto>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Producto.Where(p => p.Cantidad > 0 && p.Estado == true).ToList();
                    foreach (var item in resultado)
                    {
                        Producto producto = new Producto
                        {
                            CodigoProducto = item.CodigoProducto,
                            Nombre = item.Nombre,
                            Cantidad = item.Cantidad,
                            Precio = item.Precio,
                            IdReceta = item.IdReceta,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            Restricciones = item.Restricciones,
                            Foto = item.Foto,
                        };

                        productos.Add(producto);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
            }

            return productos;
        }

        public string RegistrarPedido(Pedido pedido, List<PedidoProducto> pedidoProductos)
        {
            string clavePedido = string.Empty;
            List<Producto> productos = new List<Producto>();

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.Log = Console.WriteLine;

                        context.Pedido.Add(pedido);
                        context.SaveChanges();

                        pedido.Clave = $"PED-{pedido.IdPedido}";
                        context.SaveChanges();

                        foreach (var pp in pedidoProductos)
                        {
                            pp.IdPedido = pedido.IdPedido;
                            context.PedidoProducto.Add(pp);

                            string cantidadString = "-" + pp.Cantidad;

                            Producto producto = new Producto()
                            {
                                CodigoProducto = pp.ClaveProducto,                            
                                Cantidad = int.Parse(cantidadString),
                            };

                            productos.Add(producto);
                        }

                        context.SaveChanges();

                        int actualizacion = ActualizarCantidadProductos(productos);

                        if (actualizacion > 0)
                        {
                            context.SaveChanges();
                            transaction.Commit();
                            clavePedido = pedido.Clave;
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                clavePedido = CODIGO_BASE.ToString();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                clavePedido = CODIGO_BASE.ToString();
            }

            return clavePedido;
        }

        public int VerificarUsuario(string usuario, string contraseña)
        {
            int resultado = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    var empleado = context.Empleado
                                          .Where(e => e.Usuario == usuario && e.Contraseña == contraseña)
                                          .Select(e => new { e.Estado })
                                          .FirstOrDefault();

                    if (empleado != null)
                    {
                        if (empleado.Estado.HasValue && empleado.Estado.Value)
                        {
                            resultado = 1; 
                        }
                        else
                        {
                            resultado = 0; 
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                resultado = -1;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                resultado = -1;
            }

            return resultado;
            
        }


        public Login RecuperarCuenta(string usuario, string contraseña)
        {
            Login login = null;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    var empleado = context.Empleado
                        .FirstOrDefault(e => e.Usuario == usuario && e.Contraseña == contraseña);

                    if (empleado != null)
                    {
                        login = new Login
                        {
                            Usuario = empleado.Usuario,
                            Nombre = $"{empleado.Nombre} {empleado.Paterno} {empleado.Materno}",
                            Puesto = (int)empleado.IdPuesto
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                login = null;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                login = null;
            }

            return login;
        }

        public List<Producto> RecuperarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Producto.ToList();
                    foreach (var item in resultado)
                    {
                        Producto producto = new Producto
                        {
                            CodigoProducto = item.CodigoProducto,
                            Nombre = item.Nombre,
                            Cantidad = item.Cantidad,
                            Precio = item.Precio,
                            IdReceta = item.IdReceta,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            Restricciones = item.Restricciones,
                            Foto = item.Foto,
                        };

                        productos.Add(producto);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
            }

            return productos;
        }
        
        public Insumo RecuperarInsumo(String codigoInsumo)
        {
            Insumo insumo = null;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    var insumoEntity = context.Insumo
                        .FirstOrDefault(i => i.Codigo == codigoInsumo);

                    if (insumoEntity != null)
                    {
                        insumo = new Insumo
                        {
                            IdInsumo = insumoEntity.IdInsumo,
                            Nombre = insumoEntity.Nombre,
                            PrecioKiloLitro = insumoEntity.PrecioKiloLitro,
                            CantidadKiloLitro = insumoEntity.CantidadKiloLitro,
                            RutaFoto = insumoEntity.RutaFoto,
                            Estado = insumoEntity.Estado,
                            Codigo = insumoEntity.Codigo
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                insumo = null;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                insumo = null;
            }

            return insumo;
        }

        public int ModificarInsumo(Insumo insumo, string codigoInsumo)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var insumoConMismoNombre = context.Insumo.FirstOrDefault(i => i.Nombre == insumo.Nombre && i.Codigo != codigoInsumo);
                    if (insumoConMismoNombre != null)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        var insumoExistente = context.Insumo.FirstOrDefault(i => i.Codigo == codigoInsumo);
                        if (insumoExistente != null)
                        {
                            bool insumoEnReceta = context.InsumoReceta.Any(ir => ir.IdInsumo == insumoExistente.IdInsumo);
                            if (!insumoEnReceta)
                            {
                                insumoExistente.Nombre = insumo.Nombre;
                                insumoExistente.PrecioKiloLitro = insumo.PrecioKiloLitro;
                                insumoExistente.CantidadKiloLitro = insumo.CantidadKiloLitro;
                                insumoExistente.RutaFoto = insumo.RutaFoto;
                                insumoExistente.Estado = insumo.Estado;

                                codigo = context.SaveChanges();
                            }
                            else
                            {
                                codigo = CODIGO_UTILIZADO;
                            }
                        }
                        else
                        {
                            codigo = VALOR_POR_DEFECTO;
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int DeshabilitarInsumo(string codigoInsumo)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var insumoExistente = context.Insumo.FirstOrDefault(i => i.Codigo == codigoInsumo);
                    if (insumoExistente != null)
                    {
                        bool insumoEnReceta = context.InsumoReceta.Any(ir => ir.IdInsumo == insumoExistente.IdInsumo);
                        if (!insumoEnReceta)
                        {
                            insumoExistente.Estado = false;

                            codigo = context.SaveChanges();
                        }
                        else
                        {
                            codigo = CODIGO_UTILIZADO;
                        }
                    }
                    else
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public Receta RecuperarReceta(string codigoReceta)
        {
            Receta receta = null;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    var recetaEntity = context.Receta
                        .FirstOrDefault(i => i.Codigo == codigoReceta);

                    if (recetaEntity != null)
                    {
                        receta = new Receta
                        {
                            IdReceta = recetaEntity.IdReceta,
                            Nombre = recetaEntity.Nombre,
                            Descripcion = recetaEntity.Descripcion,
                            Estado = recetaEntity.Estado,
                            Codigo = recetaEntity.Codigo
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                receta = null;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                receta = null;
            }

            return receta;
        }

        public int ModificarReceta(Receta receta, string codigoReceta, Dictionary<int, float> listaInsumos)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var recetaConMismoNombre = context.Receta.FirstOrDefault(r => r.Nombre == receta.Nombre && r.Codigo != codigoReceta);
                    if (recetaConMismoNombre != null)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        var recetaExistente = context.Receta.FirstOrDefault(r => r.Codigo == codigoReceta);
                        if (recetaExistente != null)
                        {
                            bool recetaEnProducto = context.Producto.Any(p => p.IdReceta == recetaExistente.IdReceta);
                            if (!recetaEnProducto)
                            {
                                var insumosRecetaAEliminar = context.InsumoReceta.Where(ir => ir.IdReceta == recetaExistente.IdReceta).ToList();
                                context.InsumoReceta.RemoveRange(insumosRecetaAEliminar);

                                recetaExistente.Nombre = receta.Nombre;
                                recetaExistente.Descripcion = receta.Descripcion;

                                codigo = context.SaveChanges();

                                foreach (var kvp in listaInsumos)
                                {
                                    InsumoReceta insumoReceta = new InsumoReceta
                                    {
                                        IdReceta = recetaExistente.IdReceta,
                                        IdInsumo = kvp.Key,
                                        Cantidad = kvp.Value
                                    };

                                    context.InsumoReceta.Add(insumoReceta);
                                }

                                codigo = context.SaveChanges();
                            }
                            else
                            {
                                codigo = CODIGO_UTILIZADO;
                            }
                        }
                        else
                        {
                            codigo = VALOR_POR_DEFECTO;
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int DeshabilitarReceta(string codigoReceta)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var recetaExistente = context.Receta.FirstOrDefault(r => r.Codigo == codigoReceta);
                    if (recetaExistente != null)
                    {
                        bool recetaEnProducto = context.Producto.Any(p => p.IdReceta == recetaExistente.IdReceta);
                        if (!recetaEnProducto)
                        {
                            recetaExistente.Estado = false;

                            codigo = context.SaveChanges();
                        }
                        else
                        {
                            codigo = CODIGO_UTILIZADO;
                        }
                    }
                    else
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public Producto RecuperarProducto(string codigoProducto)
        {
            Producto producto = null;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    var productoEntity = context.Producto
                        .FirstOrDefault(p => p.CodigoProducto == codigoProducto);

                    if (productoEntity != null)
                    {
                        producto = new Producto
                        {
                            CodigoProducto = productoEntity.CodigoProducto,
                            Nombre = productoEntity.Nombre,
                            Cantidad = productoEntity.Cantidad,
                            Precio = productoEntity.Precio,
                            IdReceta = productoEntity.IdReceta,
                            Descripcion = productoEntity.Descripcion,
                            Estado = productoEntity.Estado,
                            Restricciones = productoEntity.Restricciones,
                            Foto = productoEntity.Foto
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                producto = null;
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                producto = null;
            }

            return producto;
        }

        public int ModificarProducto(Producto producto, string codigoProducto)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var productoConMismoNombre = context.Producto.FirstOrDefault(p => p.Nombre == producto.Nombre && p.CodigoProducto != codigoProducto);
                    if (productoConMismoNombre != null)
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                    else
                    {
                        var productoExistente = context.Producto.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
                        if (productoExistente != null)
                        {
                            bool productoEnPedido = context.PedidoProducto.Any(pp => pp.ClaveProducto == productoExistente.CodigoProducto);
                            if (!productoEnPedido)
                            {
                                productoExistente.Nombre = producto.Nombre;
                                productoExistente.Cantidad = producto.Cantidad;
                                productoExistente.Precio = producto.Precio;
                                productoExistente.IdReceta = producto.IdReceta;
                                productoExistente.Descripcion = producto.Descripcion;
                                productoExistente.Estado = producto.Estado;
                                productoExistente.Restricciones = producto.Restricciones;
                                productoExistente.Foto = producto.Foto;

                                codigo = context.SaveChanges();
                            }
                            else
                            {
                                codigo = CODIGO_UTILIZADO;
                            }
                        }
                        else
                        {
                            codigo = VALOR_POR_DEFECTO;
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int DeshabilitarProducto(string codigoProducto)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var productoExistente = context.Producto.FirstOrDefault(p => p.CodigoProducto == codigoProducto);
                    if (productoExistente != null)
                    {
                        bool productoEnPedido = context.PedidoProducto.Any(pp => pp.ClaveProducto == productoExistente.CodigoProducto);
                        if (!productoEnPedido)
                        {
                            productoExistente.Estado = false;

                            codigo = context.SaveChanges();
                        }
                        else
                        {
                            codigo = CODIGO_UTILIZADO;
                        }
                    }
                    else
                    {
                        codigo = VALOR_POR_DEFECTO;
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }


         public int ReemplazarProveedor(string RFC)
        {
            int codigo = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    var proveedorEncontrado = context.Proveedor.FirstOrDefault(e => e.RFC == RFC);

                    if (proveedorEncontrado != null)
                    {
                        context.Proveedor.Remove(proveedorEncontrado);
                        codigo = context.SaveChanges();
                    }
                    else
                    {
                        codigo = -1;
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = -1;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = 0;
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = 0;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = -1;
            }

            return codigo;
        }

        public List<Receta> RecuperarRecetasCompletas()
        {
            List<Receta> recetas = new List<Receta>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Receta.ToList();
                    foreach (var item in resultado)
                    {
                        Receta receta = new Receta
                        {
                            IdReceta = item.IdReceta,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Estado = item.Estado,
                            Codigo = item.Codigo
                        };

                        recetas.Add(receta);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error de SQL: " + ex.Message);
                    return recetas;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine("Error de Entity Framework: " + ex.Message);
                    return recetas;
                }
            }

            return recetas;
        }


        public int CancelarPedido(string clave)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.Log = Console.WriteLine;

                        var pedido = context.Pedido.FirstOrDefault(p => p.Clave == clave);

                        if (pedido != null)
                        {
                            pedido.CostoTotal = 0;
                            pedido.Estado = "Cancelado";

                            var productosRecuperados = context.PedidoProducto.Where(pp => pp.IdPedido == pedido.IdPedido).ToList();
                            List<Producto> productos = new List<Producto>();

                            foreach (var pp in productosRecuperados)
                            {
                                Producto producto = new Producto()
                                {
                                    CodigoProducto = pp.ClaveProducto,
                                    Cantidad = pp.Cantidad,
                                };

                                productos.Add(producto);
                            }

                            int actualizacion = ActualizarCantidadProductos(productos);
                            codigo += context.SaveChanges();

                            if (actualizacion > 0)
                            {
                                codigo += context.SaveChanges();
                                transaction.Commit();
                            }
                            else
                            {
                                transaction.Rollback();
                            }
                        }
                        else
                        {
                            codigo = VALOR_POR_DEFECTO;
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int ModificarPedido(Pedido pedido, List<PedidoProducto> productosAgregados)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        context.Database.Log = Console.WriteLine;
                        var pedidoBase = context.Pedido.FirstOrDefault(p => p.IdPedido == pedido.IdPedido);
                        if (pedidoBase != null)
                        {
                            pedidoBase.Estado = pedido.Estado;
                            pedidoBase.CostoTotal = pedido.CostoTotal;
                        }

                        codigo = context.SaveChanges();

                        var productosRecuperados = context.PedidoProducto.Where(pp => pp.IdPedido == pedido.IdPedido).ToList();
                        List<PedidoProducto> productosPedidoActualizados = productosAgregados.ToList();
                        List<Producto> productosParaInventario = new List<Producto>();
                        List<PedidoProducto> productosAEliminar = new List<PedidoProducto>();

                        foreach (var pa in productosPedidoActualizados.ToList())
                        {
                            Producto producto = new Producto();
                            producto.CodigoProducto = pa.ClaveProducto;

                            foreach (var pr in productosRecuperados.ToList())
                            {
                                if (pa.ClaveProducto.Equals(pr.ClaveProducto))
                                {
                                    int diferenciaCantidad = (int)(pr.Cantidad - pa.Cantidad);

                                    if (pa.Cantidad < pr.Cantidad)
                                    {
                                        producto.Cantidad = diferenciaCantidad;
                                        productosParaInventario.Add(producto);
                                    }
                                    else if (pa.Cantidad > pr.Cantidad)
                                    {
                                        producto.Cantidad = -diferenciaCantidad;
                                        productosParaInventario.Add(producto);
                                    }

                                    productosAgregados.Remove(pa);
                                    productosAEliminar.Add(pr);
                                    break;
                                }
                            }
                        }

                        foreach (var pr in productosAEliminar)
                        {
                            productosRecuperados.Remove(pr);
                        }

                        foreach (var pa in productosAgregados)
                        {
                            Producto producto = new Producto();
                            producto.CodigoProducto = pa.ClaveProducto;

                            producto.Cantidad = -pa.Cantidad;
                            productosParaInventario.Add(producto);
                        }

                        foreach (var pr in productosRecuperados)
                        {
                            Producto producto = new Producto();
                            producto.CodigoProducto = pr.ClaveProducto;

                            productosParaInventario.Add(producto);
                        }

                        context.PedidoProducto.RemoveRange(productosAEliminar);
                        codigo += context.SaveChanges();

                        foreach (var ppa in productosPedidoActualizados)
                        {
                            ppa.IdPedido = pedido.IdPedido;
                            context.PedidoProducto.Add(ppa);
                        }

                        codigo += context.SaveChanges();

                        int actualizacion = ActualizarCantidadProductos(productosParaInventario);

                        if (actualizacion > 0)
                        {
                            context.SaveChanges();
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }

                    }
                }
            }
            catch (EntityException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public List<PedidoProducto> RecuperarProductosPorPedido(int idPedido)
        {
            List<PedidoProducto> productos = new List<PedidoProducto>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.PedidoProducto.Where(p => p.IdPedido == idPedido).ToList();
                    foreach (var item in resultado)
                    {
                        PedidoProducto producto = new PedidoProducto
                        {
                            IdPedido = item.IdPedido,
                            Cantidad = item.Cantidad,
                            ClaveProducto = item.ClaveProducto,
                            IdPedidoProducto = item.IdPedidoProducto,
                        };

                        productos.Add(producto);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return productos;
                }
            }

            return productos;
        }

        public List<Movimiento> RecuperarMovimientos()
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Movimiento.ToList();
                    foreach (var item in resultado)
                    {
                        Movimiento movimiento = new Movimiento
                        {
                            IdMovimiento = item.IdMovimiento,
                            Fecha = item.Fecha,
                            Descripcion = item.Descripcion,
                            CostoTotal = item.CostoTotal,
                        };

                        movimientos.Add(movimiento);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return movimientos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return movimientos;
                }
            }

            return movimientos;
        }

        public List<Solicitud> RecuperarSolicitudes()
        {
            List<Solicitud> solicitudes = new List<Solicitud>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Solicitud.ToList();
                    foreach (var item in resultado)
                    {
                        Solicitud solicitud = new Solicitud
                        {
                            IdSolicitud = item.IdSolicitud,
                            Fecha = item.Fecha,
                            CostoTotal = item.CostoTotal,
                        };

                        solicitudes.Add(solicitud);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return solicitudes;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return solicitudes;
                }
            }

            return solicitudes;
        }

        public List<Pedido> RecuperarPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Pedido.ToList();
                    foreach (var item in resultado)
                    {
                        Pedido pedido = new Pedido
                        {
                            IdPedido = item.IdPedido,
                            Estado = item.Estado,
                            TipoEntrega = item.TipoEntrega,
                            Direccion = item.Direccion,
                            CostoTotal = item.CostoTotal,
                            Fecha = item.Fecha,
                            NombreCliente = item.NombreCliente,
                            TelefonoCliente = item.TelefonoCliente,
                            Clave = item.Clave,
                            Usuario = item.Usuario
                        };

                        pedidos.Add(pedido);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return pedidos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return pedidos;
                }
            }

            return pedidos;
        }

        public List<Pedido> RecuperarPedidosNoCancelados()
        {
            List<Pedido> pedidos = new List<Pedido>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Pedido.Where(p => p.Estado != "Cancelado").ToList();
                    foreach (var item in resultado)
                    {
                        Pedido pedido = new Pedido
                        {
                            IdPedido = item.IdPedido,
                            Estado = item.Estado,
                            TipoEntrega = item.TipoEntrega,
                            Direccion = item.Direccion,
                            CostoTotal = item.CostoTotal,
                            Fecha = item.Fecha,
                            NombreCliente = item.NombreCliente,
                            TelefonoCliente = item.TelefonoCliente,
                            Clave = item.Clave,
                            Usuario = item.Usuario,
                        };

                        pedidos.Add(pedido);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return pedidos;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return pedidos;
                }
            }

            return pedidos;
        }

        public Pedido RecuperarPedido(string clave)
        {
            Pedido pedido = null;

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Pedido
                                        .Where(p => p.Clave == clave)
                                        .FirstOrDefault();

                    if (resultado != null)
                    {
                        pedido = new Pedido
                        {
                            IdPedido = resultado.IdPedido,
                            Clave = clave,
                            Direccion = resultado.Direccion,
                            CostoTotal = resultado.CostoTotal,
                            NombreCliente = resultado.NombreCliente,
                            Estado = resultado.Estado,
                            Fecha = resultado.Fecha,
                            TelefonoCliente = resultado.TelefonoCliente,
                            TipoEntrega = resultado.TipoEntrega,
                            Usuario = resultado.Usuario
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return pedido;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return pedido;
                }
            }

            return pedido;
        }

        public int ActualizarCantidadProductos(List<Producto> productos)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    foreach (var producto in productos)
                    {
                        var productoRecuperado = context.Producto.FirstOrDefault(p => p.CodigoProducto == producto.CodigoProducto);

                        if (productoRecuperado != null)
                        {
                            productoRecuperado.Cantidad += producto.Cantidad;
                        }
                    }

                    codigo = context.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                codigo = CODIGO_BASE;
            }
            catch (SqlException ex)
            {
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public int ActualizarCantidadInsumos(List<Insumo> insumos)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    foreach (var insumo in insumos)
                    {
                        var insumoRecuperado = context.Insumo.FirstOrDefault(i => i.IdInsumo == insumo.IdInsumo);

                        if (insumoRecuperado != null)
                        {
                            insumoRecuperado.CantidadKiloLitro += insumo.CantidadKiloLitro;
                        }
                    }

                    codigo = context.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                codigo = CODIGO_BASE;
            }
            catch (SqlException ex)
            {
                codigo = CODIGO_BASE;
            }

            return codigo;
        }

        public List<InsumoReceta> RecuperarInsumosPorReceta(int idReceta)
        {
            List<InsumoReceta> insumos = new List<InsumoReceta>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;

                try
                {
                    var resultado = context.InsumoReceta.Where(i => i.IdReceta == idReceta).ToList();
                    foreach (var item in resultado)
                    {
                        InsumoReceta insumo = new InsumoReceta
                        {
                            IdReceta = item.IdReceta,
                            IdInsumo = item.IdInsumo,
                            Cantidad = item.Cantidad,
                            IdInsumoReceta = item.IdInsumoReceta,
                        };

                        insumos.Add(insumo);
                    }
                }
                catch (SqlException ex)
                {
                    return insumos;
                }
                catch (EntityException ex)
                {
                    return insumos;
                }
            }

            return insumos;
        }


         public Dictionary<string, float> RecuperarInsumosDeReceta(int idReceta)
        {
            Dictionary<string, float> insumosDeReceta = new Dictionary<string, float>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultados = context.InsumoReceta
                        .Where(ir => ir.IdReceta == idReceta)
                        .Select(ir => new
                        {
                            InsumoNombre = ir.Insumo.Nombre,
                            Cantidad = ir.Cantidad
                        })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        float cantidadFloat = (float)resultado.Cantidad;
                        insumosDeReceta.Add(resultado.InsumoNombre, cantidadFloat);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return insumosDeReceta;
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                    return insumosDeReceta;
                }
            }

            return insumosDeReceta;
         }

        public Empleado BuscarEmpleadoPorUsuario(string usuario)
        {
            Empleado empleadoEncontrado = null;

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultado = context.Empleado
                                        .Where(e => e.Usuario == usuario)
                                        .FirstOrDefault();

                    if (resultado != null)
                    {
                        empleadoEncontrado = new Empleado
                        {
                            Usuario = resultado.Usuario,
                            Nombre = resultado.Nombre,
                            Paterno = resultado.Paterno,
                            Materno = resultado.Materno,
                            IdPuesto = resultado.IdPuesto,
                            Telefono = resultado.Telefono,
                            Estado = resultado.Estado,
                            Contraseña = resultado.Contraseña,
                            Direccion = resultado.Direccion,
                            Correo = resultado.Correo,
                            RFC = resultado.RFC

                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error al buscar empleado: " + ex.Message);
                }
                catch (EntityException ex)
                {
                    Console.WriteLine("Error al buscar empleado: " + ex.Message);
                }
            }

            return empleadoEncontrado;
        }
    }
}

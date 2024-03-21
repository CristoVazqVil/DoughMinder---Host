using Clases.Contratos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Servicio : IInsumo, IReceta, IEmpleado, IProveedor, IMovimiento, IProducto
    {
        const int CODIGO_BASE = -1;
        const int VALOR_POR_DEFECTO = 0;

        public int GuardarProveedor(Proveedor proveedor)
        {
            int codigo = VALOR_POR_DEFECTO;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeProveedor = context.Proveedor.Any(i => i.Nombre == proveedor.Nombre);
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
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
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
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
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

                    bool existeInsumo = context.Insumo.Any(i => i.Nombre == insumo.Nombre);
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
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
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
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
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

                    bool existeReceta = context.Receta.Any(r => r.Nombre == receta.Nombre);
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
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
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
                        .Select(i => new { i.IdInsumo, i.Nombre })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        insumos.Add(resultado.IdInsumo, resultado.Nombre);
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
                codigo = CODIGO_BASE;
            }
            catch (DbUpdateException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = VALOR_POR_DEFECTO;
            }
            catch (SqlException ex)
            {
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
                        .Select(i => new { i.IdReceta, i.Nombre })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        recetas.Add(resultado.IdReceta, resultado.Nombre);
                    }
                }
                catch (SqlException ex)
                {
                    return recetas;
                }
                catch (EntityException ex)
                {
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
                        .Select(i => new { i.Nombre, i.Paterno })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        empleados.Add(resultado.Nombre, resultado.Paterno);
                    }
                }
                catch (SqlException ex)
                {
                    return empleados;
                }
                catch (EntityException ex)
                {
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
                    var resultado = context.Proveedor.Select(p => new {p.IdProveedor, p.Nombre, p.Telefono, p.Email}).ToList();
                    foreach (var item in resultado)
                    {
                        Proveedor proveedor = new Proveedor
                        {
                            IdProveedor = item.IdProveedor,
                            Nombre = item.Nombre,
                            Telefono = item.Telefono,
                            Email = item.Email
                        };

                        proveedores.Add(proveedor);
                    }
                }
                catch (SqlException ex)
                {
                    return proveedores;
                }
                catch (EntityException ex)
                {
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
                            PrecioKiloLitro = item.PrecioKiloLitro
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
                            RutaFoto = item.RutaFoto,
                        };

                        productos.Add(producto);
                    }
                }
                catch (SqlException ex)
                {
                    return productos;
                }
                catch (EntityException ex)
                {
                    return productos;
                }
            }

            return productos;
        }
    }
}
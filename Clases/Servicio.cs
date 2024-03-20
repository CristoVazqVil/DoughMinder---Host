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
    public class Servicio : IInsumo, IReceta, IEmpleado, IProveedor
    {


        public int GuardarProveedor(Proveedor proveedor)
        {
            int codigo = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeProveedor = context.Proveedor.Any(i => i.Nombre == proveedor.Nombre);
                    if (existeProveedor)
                    {
                        codigo = 0;
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
                codigo = -1;
            }
            catch (DbUpdateException ex)
            {
                codigo = 0;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = 0;
            }
            catch (SqlException ex)
            {
                codigo = -1;
            }

            return codigo;
        }

        public int GuardarEmpleado(Empleado empleado)
        {
            int codigo = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeEmpleado = context.Empleado.Any(i => i.Nombre == empleado.Usuario);
                    if (existeEmpleado)
                    {
                        codigo = 0;
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
                codigo = -1;
            }
            catch (DbUpdateException ex)
            {
                codigo = 0;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = 0;
            }
            catch (SqlException ex)
            {
                codigo = -1;
            }

            return codigo;
        }

        public int GuardarInsumo(Insumo insumo)
        {
            int codigo = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeInsumo = context.Insumo.Any(i => i.Nombre == insumo.Nombre);
                    if (existeInsumo)
                    {
                        codigo = 0;
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
                codigo = -1;
            }
            catch (DbUpdateException ex)
            {
                codigo = 0;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = 0;
            }
            catch (SqlException ex)
            {
                codigo = -1;
            }

            return codigo;
        }

        public int GuardarReceta(Receta receta, Dictionary<int, float> listaInsumos)
        {
            int codigo = 0;

            try
            {
                using (var context = new DoughMinderEntities())
                {
                    context.Database.Log = Console.WriteLine;

                    bool existeReceta = context.Receta.Any(r => r.Nombre == receta.Nombre);
                    if (existeReceta)
                    {
                        codigo = 0;
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
                codigo = -1;
            }
            catch (DbUpdateException ex)
            {
                codigo = 0;
            }
            catch (DbEntityValidationException ex)
            {
                codigo = 0;
            }
            catch (SqlException ex)
            {
                codigo = -1;
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

        public Dictionary<string, string> RecuperarEmpleados()
        {
            Dictionary<string, string> empleados = new Dictionary<string, string>();

            using (var context = new DoughMinderEntities())
            {
                context.Database.Log = Console.WriteLine;
                try
                {
                    var resultados = context.Empleado
                        .Select(i => new { i.Nombre, i.Paterno, i.Usuario })
                        .ToList();

                    foreach (var resultado in resultados)
                    {
                        empleados.Add(resultado.Nombre + " " + resultado.Paterno, resultado.Usuario);
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

    }
}

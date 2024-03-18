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
    public class Servicio : IInsumo
    {
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
    }
}

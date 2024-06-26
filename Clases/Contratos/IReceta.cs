﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface IReceta
    {
        [OperationContract]
        int GuardarReceta(Receta receta, Dictionary<int, float> listaInsumos);

        [OperationContract]
        Dictionary<int, string> RecuperarRecetas();

        [OperationContract]
        Receta RecuperarReceta(String codigoReceta);

        [OperationContract]
        int ModificarReceta(Receta receta, String codigoReceta, Dictionary<int, float> listaInsumos);

        [OperationContract]
        int DeshabilitarReceta(String codigoReceta);

        [OperationContract]
        List<Receta> RecuperarRecetasCompletas();

        [OperationContract]
        List<InsumoReceta> RecuperarInsumosPorReceta(int idReceta);
    }
}

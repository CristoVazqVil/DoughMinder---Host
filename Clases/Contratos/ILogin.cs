using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Contratos
{
    [ServiceContract]
    internal interface ILogin
    {
        [OperationContract]
        int VerificarUsuario(string usuario, string contraseña);

        [OperationContract]
        Login RecuperarCuenta(string usuario, string contraseña);
    }

    [DataContract]
    public class Login
    {
        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int Puesto { get; set; }
    }
}

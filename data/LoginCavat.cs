using Cavat.ServiceCavat;
using InfoUsuarios;
using InfoUsuarios.cache;
/// <summary>
/// | Autor: Ing. Maria de Lourdes Sosa Cruz
/// Clase para el consumo del servicio que contiene  el acceso al sistema y el registro de los usuarios 
/// </summary>
namespace Cavat.data
{
    public class LoginCavat
    {
        ServiceCavatClient swCavat = new ServiceCavatClient();
        wRespuesta res = new wRespuesta();
        resultado rs = new resultado();
        login lg = new login();

        public resultado LoginDA(dataUser log)        {
            lg.usuariok__BackingField = UserLoginCache.userCache;
            lg.paswdk__BackingField = log.contrasena;
            lg.opck__BackingField = log.opc1;
            res = swCavat.AccesLogin(lg);
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }

        public int RegistroUser(dataUser reg)
        {
            Registro objReg = new Registro();
            objReg.nombre = reg.nombre;
            objReg.ape1 = reg.ape1;
            objReg.ape2 = reg.ape2;
            objReg.correo = reg.correo;
            objReg.cedulaP = reg.cedulaP;
            objReg.idPregunta = reg.idPregunta;
            objReg.respuesta = reg.respuesta;
            objReg.telCel = reg.telCel;
            objReg.numNotaria = reg.numNotaria;
            objReg.idStatus = reg.idStatus;
            objReg.idTipoUser = int.Parse(reg.idTipoUser);
            objReg.idTipoDoc = reg.idTipoDoc;
            objReg.nombreDoc = reg.nombreDoc;
            objReg.opck__BackingField = reg.opc1;

            int res = swCavat.ResgistroUser(objReg);

            return res;
        }
    }
}
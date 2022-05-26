using Cavat.ServiceCavat;
using InfoUsuarios;
using InfoUsuarios.cache;

namespace Cavat.data
{
    public class LoginCavat
    {
        public resultado LoginDA(dataUser log)
        {
            ServiceCavatClient swCavat = new ServiceCavatClient();
            wRespuesta res = new wRespuesta();

            resultado rs = new resultado();
            login lg = new login();

            lg.usuariok__BackingField = UserLoginCache.userCache;
            lg.paswdk__BackingField = log.contrasena;
            lg.opck__BackingField = log.opc1;

            res = swCavat.AccesLogin(lg);
            rs.mensaje = res.mensaje;
            rs.elDataSet = res.elDataSet;
            return rs;
        }
    }
}
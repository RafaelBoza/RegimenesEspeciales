using RegimenesEspeciales.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegimenesEspeciales
{
    
    public  class Tools
    {
        public RegUsu_devEntities1 _ctx = new RegUsu_devEntities1();
        public void SaveDP(DPersonales dp)
        {
            _ctx.DPersonales.Add(dp);
            _ctx.SaveChanges();
        }
    }
}
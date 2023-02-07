using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using RegimenesEspeciales.Contexto;


namespace RegimenesEspeciales
{
    public  class Tools
    {       
        public   DPersonales GetPersonales(string carnet)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("www.inass.gob.cu/apisuin/Suin/buscar");
            var postData = "{'Ci':'88081208344','Nombre':'','SegundoNombre':'','Apellido1':'','Apellido2':'','token':''}";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return new DPersonales();            
           
        }    

        public  DPersonales GetFromFichaUnica()
        {
            var dp = new DPersonales();
            Fuc_Response response = new Fuc_Response();
            using (StreamReader r = new StreamReader("response_ficha_unica.json"))
            {
                string json = r.ReadToEnd();
                response = JsonConvert.DeserializeObject<Fuc_Response>(json);
            }
            dp.CI = response.identidad_numero;
            return dp;
        }
    }

   
}
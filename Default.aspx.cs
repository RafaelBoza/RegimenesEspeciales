using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RegimenesEspeciales.Contexto;
using RestSharp;

namespace RegimenesEspeciales
{
    
    public partial class _Default : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

            var client = new RestClient("https://restcountries.com/v2/name/peru");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{'if':'kjsdfkjdsnf'}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

        }
    }
}
using Newtonsoft.Json;
using RegimenesEspeciales.Contexto;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RegimenesEspeciales.Aspx
{
    public partial class DatosPersonales : System.Web.UI.Page
    {
        private RegUsu_devEntities1 _ctx = new RegUsu_devEntities1();
        string titulo = "Regimenes Especiales", Msj, tipo;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if(!IsPostBack)
            {
                BindBaseContribucion();
                BindRegimen();                   
                multiview1.SetActiveView(view_buscar);
            }          
        }

        private void BindBaseContribucion()
        {
            var bases = _ctx.N_BaseC.Where(x=> x.IdBase > 14).ToList();
            bases.Add(new N_BaseC() { IdBase = 0, Descripbase = "" });

            drop_basecontribucion.DataSource = bases.OrderBy(x=> x.IdBase);
            drop_basecontribucion.DataTextField = "Descripbase";
            drop_basecontribucion.DataValueField = "IdBase";
            drop_basecontribucion.DataBind();

            drop_nuevabase.DataSource = bases.OrderBy(x => x.IdBase);
            drop_nuevabase.DataTextField = "Descripbase";
            drop_nuevabase.DataValueField = "IdBase";
            drop_nuevabase.DataBind();
        }
        private void BindRegimen()
        {
            var regimenes = _ctx.NRégimen.ToList();
            regimenes.Add(new NRégimen() { IdRégimen = 0, DesRégimen = "" });
            drop_regimen.DataSource = regimenes.OrderBy(x=> x.IdRégimen);
            drop_regimen.DataTextField = "DesRégimen";
            drop_regimen.DataValueField = "IdRégimen";
            drop_regimen.DataBind();
        }
        public DPersonales GetFromFichaUnica()
        {
            var dp = new DPersonales();
            Class1 response = new Class1();
            using (StreamReader r = new StreamReader("c:/response_ficha_unica.json"))
            {
                string json_str = r.ReadToEnd();               
                response = JsonConvert.DeserializeObject<Class1>(json_str);
            }
            dp.CI = response.identidad_numero;
            dp.Nombre = response.primer_nombre;
            dp.Nombre2 = response.segundo_nombre;
            dp.Apll = response.primer_apellido;
            dp.Apll2 = response.segundo_apellido;
            dp.Dirección = response.direccion;
            dp.IdSexo = response.sexo;
            dp.IdMun = response.municipio_residencia_cod_dpa;            
          
            return dp;
        }

        protected void btn_Buscar_Click(object sender, EventArgs e)
        {
            //validacion carnet
            if(string.IsNullOrEmpty(tbx_carnet.Text))
            {
                tipo = "error";
                Msj = "Debe teclear el carnet a buscar";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_buscar);
                return;
            }
            if(tbx_carnet.Text.Length != 11)
            {
                tipo = "error";
                Msj = "El carnet debe tener una longitud de 11 digitos";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_buscar);
                return;
            }
            if(tbx_carnet.Text.Any(x=> !char.IsDigit(x)))
            {
                tipo = "error";
                Msj = "El carnet solo debe contener números";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_buscar);
                return;
            }
            var dp = GetFromFichaUnica();
            if (dp != null)
            {                
                dp.IdEstado = 1;
                HttpContext.Current.Session["DPersonales"] = dp;

                tbx_nombres.Text = dp.First_Name();
                tbx_apellidos.Text = dp.Last_Name();
                tbx_direccion.Text = dp.Dirección;
                tbx_provincia.Text = _ctx.Provincias.FirstOrDefault(x => x.CodProv == _ctx.Municipios.FirstOrDefault(m => m.Cod_Mun == dp.IdMun).Cod_Prov).DescripProv;
                tbx_municipio.Text = _ctx.Municipios.FirstOrDefault(x => x.Cod_Mun == dp.IdMun).Descrip_Mun;
            }
           
            btn_registrar.Visible = !_ctx.DPersonales.Any(x => x.CI == dp.CI);
            btn_cambiarbase.Visible = _ctx.DPersonales.Any(x => x.CI == dp.CI);

            var inscrip = _ctx.Inscripción.FirstOrDefault(x => x.IdCI == dp.CI);
            if(inscrip!=null)
            {
                int id_inscrip = inscrip.IdInscrip;
                gvCambiosBase.DataSource = _ctx.HistorialContribución.Where(x => x.IdInscrip == id_inscrip).Select(s => new
                {
                    Descripbase = _ctx.N_BaseC.FirstOrDefault(x => x.IdBase == s.IdBase).Descripbase,
                    Porcentaje = s.Porcent,
                    Año = s.Año,
                    FechaCambio = s.FechaCambio
                }).ToList();
                gvCambiosBase.DataBind();
            }
            
            multiview1.SetActiveView(view_datospersonales);          
        }

        private void ClearControls()
        {
            //datos personales
            tbx_carnet.Text = string.Empty;
            tbx_nombres.Text = string.Empty;
            tbx_apellidos.Text = string.Empty;
            tbx_direccion.Text = string.Empty;
            tbx_provincia.Text = string.Empty;
            tbx_municipio.Text = string.Empty;
            //registro
            tbx_fecharegistro.Text = string.Empty;
            tbx_fechadesvinculacion.Text = string.Empty;
            drop_basecontribucion.ClearSelection();
            drop_regimen.ClearSelection();
            //cambio contrib
            drop_nuevabase.ClearSelection();
            tbx_base.Text = string.Empty;

            HttpContext.Current.Session["DPersonales"] = null;
            HttpContext.Current.Session["inscripcion"] = null;
        }

        protected void btn_registrar_Click(object sender, EventArgs e)
        {
            multiview1.SetActiveView(view_registro);
        }

        protected void btn_ancelar_Click(object sender, EventArgs e)
        {
            ClearControls();
            multiview1.SetActiveView(view_buscar);
        }
        
        protected void btn_cambiarbase_Click(object sender, EventArgs e)
        {
            var datosp = (DPersonales)HttpContext.Current.Session["DPersonales"];
            Contribución contrib = _ctx.Contribución.FirstOrDefault(x => x.Inscripción.IdCI == datosp.CI);
            tbx_base.Text = contrib.N_BaseC.Descripbase;
            multiview1.SetActiveView(view_cambio);
        }

        protected void view_buscar_Deactivate(object sender, EventArgs e)
        {
            multiview1.SetActiveView(view_datospersonales);
        }

        protected void btn_guardarbase_Click(object sender, EventArgs e)
        {
            //Validaciones Base Contribucion
            if (drop_nuevabase.SelectedValue == "0")
            {
                tipo = "error";
                Msj = "Debe seleccionar la base de contribución";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_registro);
                return;
            }
            var datosp = (DPersonales)HttpContext.Current.Session["DPersonales"];
            

            var contrib = _ctx.Contribución.FirstOrDefault(x => x.Inscripción.IdCI == datosp.CI);
            var historial = new HistorialContribución();
            historial.Año = contrib.Año;
            historial.IdBase = contrib.IdBase;
            historial.FechaCambio = DateTime.Now;
            historial.Porcent = contrib.Porcent;
            historial.IdInscrip = contrib.IdInscrip;

            contrib.IdBase = int.Parse(drop_nuevabase.SelectedValue);
            contrib.Año = DateTime.Now.Year.ToString().Trim();
            contrib.Porcent = 5.ToString().Trim();

            _ctx.HistorialContribución.Add(historial);
            _ctx.SaveChanges();

            ClearControls();
            multiview1.SetActiveView(view_buscar);
        }

        protected void btn_cancelarcambio_Click(object sender, EventArgs e)
        {
            ClearControls();
            multiview1.SetActiveView(view_buscar);
        }

        protected void btn_guardarregistro_Click(object sender, EventArgs e)
        {
            //Validaciones Fecha Registro
            if (string.IsNullOrEmpty(tbx_fecharegistro.Text))
            {
                tipo = "error";
                Msj = "Debe especificar la fecha de Registro";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_registro);
                return;
            }       
            //Validaciones Base Contribucion
            if(drop_basecontribucion.SelectedValue == "0")
            {
                tipo = "error";
                Msj = "Debe seleccionar la base de contribución";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_registro);
                return;
            }
            //Validaciones Regimen
            if (drop_regimen.SelectedValue == "0")
            {
                tipo = "error";
                Msj = "Debe seleccionar el régimen";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                multiview1.SetActiveView(view_registro);
                return;
            }
            //validaciones Fecha Desvinculacion
            if(!string.IsNullOrEmpty(tbx_fechadesvinculacion.Text))
            {
                var fecha_registro = DateTime.Parse(tbx_fecharegistro.Text);
                var fecha_desvinculacion = DateTime.Parse(tbx_fechadesvinculacion.Text);
                if(fecha_desvinculacion > fecha_registro)
                {
                    tipo = "error";
                    Msj = "La fecha de desvinculacion debe ser inferior a la fecha de registro";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ramdomtext", "alertme('" + titulo + "','" + Msj + "','" + tipo + "');", true);
                    multiview1.SetActiveView(view_registro);
                    return;
                }
            }

            //datos personales
            var dpersonales = (DPersonales)HttpContext.Current.Session["DPersonales"];
            dpersonales.IdRégimen = int.Parse(drop_regimen.SelectedValue);
            dpersonales.FCap = DateTime.Now;

            //contribucion
            var contribucion = new Contribución();
            contribucion.IdBase = int.Parse(drop_basecontribucion.SelectedValue);
            contribucion.Año = DateTime.Now.Year.ToString();
            contribucion.Porcent = 5.ToString().Trim();

            //inscripción
            Inscripción inscripción = new Inscripción();
            inscripción.DPersonales = dpersonales;
            inscripción.IdCI = dpersonales.CI;
            inscripción.FechaAlta = DateTime.Parse(tbx_fecharegistro.Text);
            inscripción.FechaBEstatal = DateTime.Parse(tbx_fechadesvinculacion.Text);
           
            inscripción.Contribución.Add(contribucion);
            HttpContext.Current.Session["inscripcion"] = inscripción;
            _ctx.Inscripción.Add(inscripción);
            _ctx.SaveChanges();

            ClearControls();
            multiview1.SetActiveView(view_buscar);
        }

        protected void btn_cancelar_registro_Click(object sender, EventArgs e)
        {
            ClearControls();
            multiview1.SetActiveView(view_buscar);
        }
    }
}
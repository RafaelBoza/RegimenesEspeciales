using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RegimenesEspeciales
{
    public class Class1
    {
        public string id { get; set; }
        public string identidad_numero { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string sexo { get; set; }
        public int edad { get; set; }
        public string nombre_padre { get; set; }
        public string nombre_madre { get; set; }
        public string direccion { get; set; }
        public int municipio_residencia_sid { get; set; }
        public string municipio_residencia { get; set; }
        public string municipio_residencia_cod_dpa { get; set; }
        public string municipio_residencia_cod_suin { get; set; }
        public int provincia_residencia_sid { get; set; }
        public string provincia_residencia { get; set; }
        public string provincia_residencia_cod_dpa { get; set; }
        public string provincia_residencia_cod_suin { get; set; }
        public DateTime fecha_act_rid { get; set; }
        public DateTime fecha_act_fuc { get; set; }
        public DateTime fecha_foto { get; set; }
        public object fecha_firma { get; set; }
        public bool fallecido { get; set; }
        public object fecha_act_rec { get; set; }
        public string nacimiento_anno_reg { get; set; }
        public string nacimiento_fecha { get; set; }
        public string nacimiento_tomo { get; set; }
        public string nacimiento_folio { get; set; }
        public int nacimiento_municipio_sid { get; set; }
        public string nacimiento_municipio { get; set; }
        public string nacimiento_municipio_cod_dpa { get; set; }
        public string nacimiento_municipio_cod_suin { get; set; }
        public int nacimiento_provincia_sid { get; set; }
        public string nacimiento_provincia { get; set; }
        public string nacimiento_provincia_cod_dpa { get; set; }
        public string nacimiento_provincia_cod_suin { get; set; }
        public int nacimiento_registro_civil_sid { get; set; }
        public string nacimiento_registro_civil { get; set; }
        public object defuncion_anno_reg { get; set; }
        public object defuncion_fecha { get; set; }
        public object defuncion_tomo { get; set; }
        public object defuncion_folio { get; set; }
        public object defuncion_registro_civil_sid { get; set; }
        public object defuncion_registro_civil { get; set; }
        public string ciudadania_sid { get; set; }
        public string ciudadania { get; set; }
        public string ciudadania_gentilicio { get; set; }
        public int condicion_migratoria_sid { get; set; }
        public string condicion_migratoria { get; set; }
    }
}
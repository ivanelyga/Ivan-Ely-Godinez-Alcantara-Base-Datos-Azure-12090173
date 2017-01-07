using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace basedatosazure
{
	public class TodoItem
	{
        string id;
       string tarea;
       string descripcion;
      string fecha_inicio;
       string fecha_fin;
       string status;
     string prioridad;
       string responsable;
        string dia;
        bool done;

        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [JsonProperty(PropertyName = "TAREA")]
        public string Tarea
        {
            get { return tarea; }
            set { tarea = value; }
        }

        [JsonProperty(PropertyName = "FECHA_INICIO")]
        public string Fecha_Inicio
        {
            get { return fecha_inicio; }
            set { fecha_inicio = value; }
        }
        [JsonProperty(PropertyName = "FECHA_FIN")]
        public string Fecha_Fin
        {
            get { return fecha_fin; }
            set { fecha_fin = value; }
        }
        [JsonProperty(PropertyName = "ESTADO")]
        public string Estado
        {
            get { return status; }
            set { status = value; }
        }
        [JsonProperty(PropertyName = "PRIORIDAD")]
        public string Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        [JsonProperty(PropertyName = "DESCRIPCION")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        [JsonProperty(PropertyName = "RESPONSABLE")]
        public string Responsable
        {
            get { return responsable; }
            set { responsable = value; }
        }
        [JsonProperty(PropertyName = "complete")]
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }
        [JsonProperty(PropertyName = "CREATEDAT")]
        public string Date
        {
            get { return dia; }
            set { dia = value; }
        }
        [UpdatedAt]
        public string Update { get; set; }
        [Version]
        public string Version { get; set; }
        
    }
}


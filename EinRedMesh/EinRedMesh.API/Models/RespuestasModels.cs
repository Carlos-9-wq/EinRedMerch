namespace EinRedMesh.API.Models
{
    public class RespuestasModels
    {
        public bool HayError { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
        public int Codigo { get; set; }

        public RespuestasModels(string mensajeError, object data=null) 
        {
            HayError= true;
            Mensaje= mensajeError;
            Codigo= 500;
            Data= data;
        }
        public RespuestasModels(int statusCode, string Menasaje, object data=null) 
        {
            HayError = statusCode<=299 ? false : true; 
            Mensaje= Menasaje;
            Codigo= statusCode;
            Data= data;
        }
    }
}

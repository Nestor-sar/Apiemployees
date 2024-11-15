using System.Net.Mail;
using System.Net;
using System.Text;
using System.IO;

namespace ApiEmpleados.Functions
{
    public class GeneralFunctions
    {
        public GeneralFunctions(IConfiguration configuration)
        {
            // Constructor - Puedes agregar aquí la configuración necesaria
        }

        public void AddLog(string newLog)
        {
            string carpetaLog = AppDomain.CurrentDomain.BaseDirectory + "Log/";
            if (!Directory.Exists(carpetaLog))
            {
                Directory.CreateDirectory(carpetaLog);
            }
            string RutaLog = carpetaLog + AppDomain.CurrentDomain.FriendlyName + "_" + DateTime.Now.ToString("dd-MM-yyyy") + ".Log";
            var registro = DateTime.Now + " " + newLog + "\n";
            var BytsNewlog = new UTF8Encoding(true).GetBytes(registro);

            using (FileStream Log = File.Open(RutaLog, FileMode.Append))
            {
                Log.Write(BytsNewlog, 0, BytsNewlog.Length);
            }
        }
    }
}

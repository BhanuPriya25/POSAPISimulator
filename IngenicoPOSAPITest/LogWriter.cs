using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Configuration;


namespace IngenicoPOSAPITest
{
    public class LogWriter
    {
        private string sLogFormat;
        private string sErrorTime;
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage)
        {
            //sLogFormat used to create log files format :
            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";

            //this variable used to create log filename format "
            //for example filename : ErrorLogYYYYMMDD
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;


            LogWrite(logMessage);
        }

        public LogWriter()
        {
            // TODO: Complete member initialization
        }
        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
           // m_exePath = ConfigurationSettings.AppSettings["LogPath"];
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log" + sErrorTime.ToString() + ".txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.Write("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                txtWriter.Write(" :{0}", logMessage);
                txtWriter.Write("\n-------------------------------------------------------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using IngenicoPOSAPITest.MiddlewareServiceReference;
namespace IngenicoPOSAPITest
{
    public partial class frmReportRequest : Form
    {
        public frmReportRequest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RequestCallBack callback = new RequestCallBack();
            InstanceContext context = new InstanceContext(callback);
            MiddlewareServiceReference.MiddlewareServiceClient Proxy = new MiddlewareServiceReference.MiddlewareServiceClient(context);
            int _requestType = Convert.ToInt32(txtReportType.Text.ToString());
            int _ack = Proxy.ReportRequest((ReportRequestType) _requestType);
           
            switch (_ack)
            {
                case 6:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Action Succeeded.");
                        const int _AC_Success = 0x06;
                        if (_ack == _AC_Success)
                        {
                            Proxy.WaitReportRequest(60);
                        }
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Invalid User Defined Field.");
                        break;
                    }
                case 9:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Incomplete data received.");
                        break;
                    }
                case 21:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Message not received by the terminal within a timeout.");
                        break;
                    }
                case 22:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Message length too big.");
                        break;
                    }
                case 24:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Invalid command type.");
                        break;
                    }
                case 33:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: INIT not received after the first power on.");
                        break;
                    }
                case 34:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Message format error in request message.");
                        break;
                    }
                case 35:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Error in request data.");
                        break;
                    }
                case 36:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: EDC is busy in either finalizing a previous request or doing an activity with the bank host.");
                        break;
                    }
                case 1:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: General Failure.");
                        break;
                    }
                case 91:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: POSAPI time out.");
                        break;
                    }
                case 92:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Syntax/format error or Invalid data tags.");
                        break;
                    }
                case 93:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: POSAPI Input/Output Error/Device not connected.");
                        break;
                    }
                case 94:
                    {
                        MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: POSAPI is busy/waiting for response from EDC.");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Unknkown Error Please Contact System Administrator");
                        break;
                    }
            }
        }
    }
}

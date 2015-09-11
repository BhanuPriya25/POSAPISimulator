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

namespace IngenicoPOSAPITest
{
    public partial class InitForm : Form
    {
        public InitForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            RequestCallBack callback = new RequestCallBack();
            InstanceContext context = new InstanceContext(callback);
            MiddlewareServiceReference.MiddlewareServiceClient Proxy = new MiddlewareServiceReference.MiddlewareServiceClient(context);
            //String _message = "Welcome";
            //int _displayTimeout = 5;	
            //int _ack =Proxy.Init(_message, _displayTimeout);
            #region own code
            try
            {
                if (Convert.ToString(txtMessage.Text) != "" && Convert.ToString(txtdisplayTimeout.Text) != "")
                {
                    String _message = Convert.ToString(txtMessage.Text);
                    int _displayTimeout = Convert.ToInt32(txtdisplayTimeout.Text);
                    int _ack = Proxy.Init(_message, _displayTimeout);

                    //MessageBox.Show(_ack.ToString());
                    switch (_ack)
                    {
                        case 6:
                            {
                                MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Action Succeeded.");
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
                else
                {
                    MessageBox.Show("Please enter any Message and its Display time out");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            #endregion
        }

        private void txtdisplayTimeout_TextChanged(object sender, EventArgs e)
        {
            bool b1 = Microsoft.VisualBasic.Information.IsNumeric(txtdisplayTimeout.Text);
            if (!b1)
            {
                txtdisplayTimeout.Text = "";   
            }
            
            
        }
    }
}

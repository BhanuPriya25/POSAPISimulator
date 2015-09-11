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
    public partial class frmTransactionRquest : Form
    {
        public static TxnResponseInfo txnResInfoData = new TxnResponseInfo();
        public frmTransactionRquest()
        {
            InitializeComponent();
        }
        private void frmTransactionRquest_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSendRequest_Click(object sender, EventArgs e)
        {
            RequestCallBack callback = new RequestCallBack();
            InstanceContext context = new InstanceContext(callback);
            MiddlewareServiceReference.MiddlewareServiceClient Proxy = new MiddlewareServiceReference.MiddlewareServiceClient(context);
            MiddlewareServiceReference.TransactionInfo _transaction = new MiddlewareServiceReference.TransactionInfo();
            
            
            #region own code

            if (txtTransactionId.Text != "" && txtTxnType.Text != "" && txtAmount.Text != "")
            {
                _transaction.transactionId = txtTransactionId.Text.ToString();
                _transaction.transactionAmount = Convert.ToDecimal(txtAmount.Text);
                _transaction.transactionType = txtTxnType.Text.ToString(); ;

                _transaction.invoiceNumber = txtInvoiceNo.Text.ToString();
                _transaction.privateData = txtPrivateData.Text.ToString();

                int _ack = Proxy.TransactionRequest(_transaction);
                switch (_ack)
                {
                    case 6:
                        {
                            MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Action Succeeded.");
                            const int _AC_Success = 0x06;
                            if (_ack == _AC_Success)
                            {
                                Proxy.WaitTransactionResponse(120000);
                            }
                            break;
                        }
                    case 5:
                        {
                            MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Invalid Amount.");
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
                    case 40:
                        {
                            MessageBox.Show("Response Code: " + _ack.ToString() + "\nDescription: Terminal is not initialized with host.");
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
                MessageBox.Show("Please enter values in required fields");
            }
            #endregion
        }

        public void ShowTransactionStatus(TxnResponseInfo txnResponse)
        {
            try
            {
                txnResInfoData = txnResponse;
                StringBuilder stringBuilder1 = new StringBuilder();
                stringBuilder1.Append("Transaction Id : " + txnResponse.DebitRequest.transactionId);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Transaction Amount : " + txnResponse.DebitRequest.transactionAmount.ToString());
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Transaction Type : " + (txnResponse.DebitRequest.transactionType == null ? string.Empty : txnResponse.DebitRequest.transactionType));
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Response Code : " + txnResponse.ResponseCode.Replace("\0", "\\0"));
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Response Message : " + txnResponse.ResponseMessage);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Authorization Code : " + txnResponse.AuthorizationCode);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Terminal ID : " + txnResponse.TerminalID);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Merchant ID : " + txnResponse.MerchantID);
                stringBuilder1.Append(Environment.NewLine);
                StringBuilder stringBuilder2 = stringBuilder1;
                string str1 = "Transaction Date/Time : ";
                DateTime transactionDate = txnResponse.TransactionDate;
                string str2 = Convert.ToDateTime(txnResponse.TransactionDate).ToLongDateString() + "/" + Convert.ToDateTime(txnResponse.TransactionDate).ToLongTimeString();
                string str3 = str1 + str2;
                stringBuilder2.Append(str3);
                                              
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Card Number : " + txnResponse.CardNumber);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Issuer Name : " + txnResponse.IssuerName);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Customer Name : " + txnResponse.CustomerName);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Invoice Number : " + txnResponse.InvoiceNumber);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Batch Number : " + txnResponse.BatchNumber);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Entry Mode : " + txnResponse.EntryMode.ToString());
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Retrival Reference Number : " + txnResponse.RetrivalReferenceNo);
                //************
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("**Application Identifier : " + txnResponse.ApplicationIdentifier);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("**Application Name : " + txnResponse.ApplicationName);
                //***********
                //int num = (int)MessageBox.Show(stringBuilder1.ToString());
                //int num = (int)MessageBox.Show("Transaction Compleated!");
                stringBuilder1.Append(Environment.NewLine);
                //Create Log on every transaction****
                LogReportData objlog = new LogReportData();
                objlog.LogReport();
            }
            catch (FaultException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (TimeoutException ex)
            {
                int num = (int)MessageBox.Show("POSAPI is not running or has timed out!");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        public void ShowTerminalStatus(TerminalStatusInfo terminatStatus)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Terminal Status : " + terminatStatus.terminalStatus);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Version Info : " + terminatStatus.softwareVersion);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Last Transaction Id : " + terminatStatus.lastTransactionId);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Last Transaction Amount: " + (object)terminatStatus.lastTransactionAmount);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Last Transaction Response Code : " + terminatStatus.lastTransactionResponseCode);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("POS Error Code : " + terminatStatus.PosErrorCode);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Middleware Error : " + terminatStatus.middlewareAckCode.ToString());
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Reversal Status : " + terminatStatus.reversalStatus.ToString());
                int num = (int)MessageBox.Show(stringBuilder.ToString());
            }
            catch (FaultException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (TimeoutException ex)
            {
                int num = (int)MessageBox.Show("Middleware is not runing or time out.");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }
        
        public void ShowReportRequest(ReportResultInfo objReportResult)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Flag: " + (object)objReportResult.flag);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Report Data: " + objReportResult.reportData);
                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append("Middleware Error : " + objReportResult.middlewareAckCode.ToString());
                int num = (int)MessageBox.Show(stringBuilder.ToString());
            }
            catch (FaultException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (TimeoutException ex)
            {
                int num = (int)MessageBox.Show("POSAPI is not running or has timed out!");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        public void ShowReportRequest(string str, TxnResponseInfo txnResponse)
        {
            try
            {
                StringBuilder stringBuilder1 = new StringBuilder();
                stringBuilder1.Append("Transaction Id : " + txnResponse.DebitRequest.transactionId);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Transaction Amount : " + txnResponse.DebitRequest.transactionAmount.ToString());
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Transaction Type : " + (txnResponse.DebitRequest.transactionType == null ? string.Empty : txnResponse.DebitRequest.transactionType));
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Response Code : " + txnResponse.ResponseCode.Replace("\0", "\\0"));
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Response Message : " + txnResponse.ResponseMessage);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Authorization Code : " + txnResponse.AuthorizationCode);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Terminal ID : " + txnResponse.TerminalID);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Merchant ID : " + txnResponse.MerchantID);
                stringBuilder1.Append(Environment.NewLine);
                StringBuilder stringBuilder2 = stringBuilder1;
                string str1 = "Transaction Date/Time : ";
                DateTime transactionDate = txnResponse.TransactionDate;
                string str2 = Convert.ToDateTime(txnResponse.TransactionDate).ToLongDateString() + "/" + Convert.ToDateTime(txnResponse.TransactionDate).ToLongTimeString();
                string str3 = str1 + str2;
                stringBuilder2.Append(str3);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Card Number : " + txnResponse.CardNumber);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Issuer Name : " + txnResponse.IssuerName);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Customer Name : " + txnResponse.CustomerName);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Invoice Number : " + txnResponse.InvoiceNumber);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Batch Number : " + txnResponse.BatchNumber);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Entry Mode : " + txnResponse.EntryMode.ToString());
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("Retrival Reference Number : " + txnResponse.RetrivalReferenceNo);
                //int num = (int)MessageBox.Show(stringBuilder1.ToString());
                stringBuilder1.Append(Environment.NewLine);
                //************
                stringBuilder1.Append("************************************\n");
                stringBuilder1.Append("**Application Identifier : " + txnResponse.ApplicationIdentifier);
                stringBuilder1.Append(Environment.NewLine);
                stringBuilder1.Append("**Application Name : " + txnResponse.ApplicationName);
                stringBuilder1.Append("\n************************************");
                //***********
                stringBuilder1.Append(str.ToString());
                 int num = (int)MessageBox.Show(stringBuilder1.ToString());
                
            }
            catch (FaultException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (TimeoutException ex)
            {
                int num = (int)MessageBox.Show("POSAPI is not running or has timed out!");
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        
    }
}

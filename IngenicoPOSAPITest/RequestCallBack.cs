using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IngenicoPOSAPITest.MiddlewareServiceReference;
using System.ServiceModel;
using log4net;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace IngenicoPOSAPITest
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class RequestCallBack: IMiddlewareServiceCallback
    {
        private string _strRTS;
        public string strTerminalStatus {
            get { return _strRTS; }
            set { _strRTS = value; } 
        }
        private string _strTxnResp;
        public string strTxnResponse
        {
            get { return _strTxnResp; }
            set { _strTxnResp = value; }
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string tvrtsi = string.Empty;
        public void ReportResult(MiddlewareServiceReference.ReportResultInfo RRInfo)
        {
            /*StringBuilder str = new StringBuilder();
            str.Append("Flag : " + RRInfo.flag.ToString());
            str.Append("\n\nReport Data :\n " + RRInfo.reportData.ToString());
            str.Append("\n\nMiddleware Error : " + RRInfo.middlewareAckCode.ToString());
            MessageBox.Show(str.ToString());
            string finalMsg = ConvertXMLtoMsg(RRInfo.reportData.ToString()).ToString();
            if(finalmsg.ToString() !="" && RRInfo.reportData.ToString().IndexOf("<TVR>") > -1)
            {
                //LogWriter objLog = new LogWriter(finalmsg.ToString());
                log.Info(finalmsg.ToString());
            }*/

            string finalMsg = ConvertXMLtoMsg(RRInfo.reportData.ToString() + "<AID>"+frmTransactionRquest.txnResInfoData.ApplicationIdentifier +"</AID><ANM>" + frmTransactionRquest.txnResInfoData.ApplicationName + "</ANM>").ToString();
             
            if (finalmsg.ToString() != "" && RRInfo.reportData.ToString().IndexOf("<TVR>") > -1)
            {
                tvrtsi = "Terminal Verification Results : " + RRInfo.reportData.Substring(RRInfo.reportData.IndexOf("<TVR>") + 5, RRInfo.reportData.IndexOf("</TVR>") - (RRInfo.reportData.IndexOf("<TVR>") + 5));
                tvrtsi += "\nTransaction Status Indicator : " + RRInfo.reportData.Substring(RRInfo.reportData.IndexOf("<TSI>") + 5, RRInfo.reportData.IndexOf("</TSI>") - (RRInfo.reportData.IndexOf("<TSI>") + 5));
            }
            
            if (RRInfo.flag.ToString() == "1")
            {
                new frmTransactionRquest().ShowReportRequest(tvrtsi, frmTransactionRquest.txnResInfoData);
            }
            if (finalmsg.ToString() != "" && RRInfo.reportData.ToString().IndexOf("<TVR>") > -1)
            {
                //LogWriter objLog = new LogWriter(finalmsg.ToString());
                log.Info(finalmsg.ToString());
               
            }
            //new frmTransactionRquest().ShowReportRequest(RRInfo);
        }
       
        public void ReturnTerminalStatus(MiddlewareServiceReference.TerminalStatusInfo ts)
        {
            /*StringBuilder str = new StringBuilder();
			str.Append("Terminal Status: " + ts.terminalStatus.ToString());
            str.Append("\nVersion info: " + ts.softwareVersion.ToString());
            str.Append("\nLast Transaction Id: " + ts.lastTransactionId.ToString());
            str.Append("\nLast Transaction Amount: " + ts.lastTransactionAmount.ToString());
            str.Append("\nLast Transaction Response code: " + ts.lastTransactionResponseCode.ToString());
            str.Append("\nPOS Error Code: " + ts.PosErrorCode.ToString());
            str.Append("\nMiddleware Acknowledgement Code: " + ts.middlewareAckCode.ToString());
            str.Append("\nReversal Status: " + ts.reversalStatus.ToString());
            MessageBox.Show(str.ToString());*/
            //new frmTransactionRquest().ShowTerminalStatus(ts);
            string asf="";
            
        }

        public void TransactionResponse(MiddlewareServiceReference.TxnResponseInfo txnResponse)
        {
            /*StringBuilder str = new StringBuilder();
            str.Append("Transaction Id : " + txnResponse.DebitRequest.transactionId.ToString());
            str.Append("\nTransaction Amount : " + txnResponse.DebitRequest.transactionAmount.ToString());
            str.Append("\nTransaction Type : " + txnResponse.DebitRequest.transactionType.ToString());
            str.Append("\nResponse Code : " + txnResponse.ResponseCode.ToString());
            str.Append("\nResponse Message : " + txnResponse.ResponseMessage.ToString());
            str.Append("\nAuthorization Code : " + txnResponse.AuthorizationCode.ToString());
            str.Append("\nTerminal ID : " + txnResponse.TerminalID.ToString());
            str.Append("\nMerchant ID : " + txnResponse.MerchantID.ToString());
            str.Append("\nTransaction Date/Time : " + txnResponse.TransactionDate.ToLongDateString() + "/" + txnResponse.TransactionDate.ToLongTimeString());
            str.Append("\nCard Number : " + txnResponse.CardNumber.ToString());
            str.Append("\nIssuer Name : " + txnResponse.IssuerName.ToString());
            str.Append("\nCustomer Name : " + txnResponse.CustomerName.ToString());
            str.Append("\nInvoice Number : " + txnResponse.InvoiceNumber.ToString());
            str.Append("\nBatch Number : " + txnResponse.BatchNumber.ToString());
            str.Append("\nEntry Mode : " + txnResponse.EntryMode.ToString());
            str.Append("\nRetrival Reference Number : " + txnResponse.RetrivalReferenceNo.ToString());
            MessageBox.Show(str.ToString());
            //LogReportData objlgr = new LogReportData();
            //objlgr.LogReport();*/
            try
            {
                new frmTransactionRquest().ShowTransactionStatus(txnResponse);
            }
            catch (FaultException ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        StringBuilder finalmsg = new StringBuilder();
        private string ConvertXMLtoMsg(string XMLMsg)
        {

            if (XMLMsg.IndexOf("<TYP>") > -1)
            {
                finalmsg.Append("{");
                finalmsg.Append("\"Type\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<TYP>") + 5, XMLMsg.IndexOf("</TYP>") - (XMLMsg.IndexOf("<TYP>") + 5)) + "\",");
                finalmsg.Append("\"Header\":");
                finalmsg.Append("{\"TerminalId\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<TID>") + 5, XMLMsg.IndexOf("</TID>") - (XMLMsg.IndexOf("<TID>") + 5)) + "\",");
                finalmsg.Append("\"MarchantId\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<MID>") + 5, XMLMsg.IndexOf("</MID>") - (XMLMsg.IndexOf("<MID>") + 5)) + "\",");
                finalmsg.Append("\"Date\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<DAT>") + 5, XMLMsg.IndexOf("</DAT>") - (XMLMsg.IndexOf("<DAT>") + 5)) + "\",");
                finalmsg.Append("\"Time\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<TIM>") + 5, XMLMsg.IndexOf("</TIM>") - (XMLMsg.IndexOf("<TIM>") + 5)) + "\"},");

            }
            if (XMLMsg.IndexOf("<TVR>") > -1)
            {
                finalmsg.Append("\"TerminalVerificationResults\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<TVR>") + 5, XMLMsg.IndexOf("</TVR>") - (XMLMsg.IndexOf("<TVR>") + 5)) + "\",");
                finalmsg.Append("\"TransactionStatusIndicator\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<TSI>") + 5, XMLMsg.IndexOf("</TSI>") - (XMLMsg.IndexOf("<TSI>") + 5)) + "\"");
                finalmsg.Append("\"ApplicationIdentifier\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<AID>") + 5, XMLMsg.IndexOf("</AID>") - (XMLMsg.IndexOf("<AID>") + 5)) + "\"");
                finalmsg.Append("\"ApplicationName\": \"" + XMLMsg.Substring(XMLMsg.IndexOf("<ANM>") + 5, XMLMsg.IndexOf("</ANM>") - (XMLMsg.IndexOf("<ANM>") + 5)) + "\"");
                finalmsg.Append("}");
                return finalmsg.ToString();
            }

            return "";
        }
        
    }

}

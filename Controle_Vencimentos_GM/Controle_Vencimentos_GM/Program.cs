using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Diagnostics;
using System.Web;


namespace Controle_Vencimentos_GM
{
    class Program
    {
        static void Main(string[] args)
        {
            Criar_Relatorio();
            EnviarEmail();
        }

        public static string invoices = "";

        public static void EnviarEmail()
        {
           
            string Something = string.Join("<br/>","");
            string senderName = "Relação de Invoices Vencidas"; //aparece no corpo do e-mail
            string senderEmail = "Financeiro Grupo Metal";

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("sistemagrupometal", "g5a7b9t3_123");

            List<string> destinatarios = new List<string>();

            destinatarios.Add("adriano.jribeiro1081@gmail.com");
            destinatarios.Add("adriano.jribeiro@grupometal.com.br");

            foreach (string destinatario in destinatarios)
            {
                MailMessage mail = new MailMessage();
                mail.Sender = new MailAddress("sistemagrupometal@gmail.com", "Invoices em Aberto");
                mail.From = new MailAddress("sistemagrupometal@gmail.com", "Invoices em Aberto");
                mail.To.Add(new MailAddress(destinatario, "Constas a Pagar"));
                mail.Subject = "Invoices em Aberto com o Prazo de Pagamento Vencido - Não Responder";
                mail.Body = "Remetente:  " + senderName + "<br/> Email : " + senderEmail + " <br/> Atenção as Invoices abaixo estão Vencidas: <br/>" + "<br/>" + Something;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                mail.Attachments.Add(new Attachment(invoices));

                
                try
                {
                    client.Send(mail);
                }
                catch (System.Exception erro)
                {
                   Console.WriteLine(erro.ToString());
                }
                finally
                {
                    mail = null;
                }
            }
            

            Console.WriteLine("e-mail enviado com sucesso", "Confirmação");
            Console.ReadKey();
        }

        public static void Criar_Relatorio()
        {
            try
            {
                Exportacao dados_exportacao = new Exportacao();

                ReportViewer reportViewer = new ReportViewer(); //cria objeto ReportViewer
                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.LocalReport.ReportEmbeddedResource = "Controle_Vencimentos_GM.relatorios.Faturas_Vencidas.rdlc";
                //Paramentros do Relatorios

                // reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Calibracao", Lista_Equipamentos()));

                DateTime data_atual = DateTime.Now;

                List<ReportParameter> listReportParameter = new List<ReportParameter>();
                listReportParameter.Add(new ReportParameter("data_atual", data_atual.ToLongDateString())); //paramentro para teste


                ReportDataSource teste = new ReportDataSource("DataSetFaturas", dados_exportacao.Faturas_Aberto()); // Link com o DataSet relatorio e DataTable do Banco


                reportViewer.LocalReport.DataSources.Add(teste);
                reportViewer.LocalReport.SetParameters(listReportParameter);

                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encodging;
                string extension;

                byte[] bytePDF = reportViewer.LocalReport.Render("Pdf", null, out mimeType, out encodging, out extension, out streamids, out warnings);

                FileStream fileStream = null;


                string diretorio_temp = @"c:\invoice_temp\";

                try
                {
                    if (!Directory.Exists(diretorio_temp))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(diretorio_temp);
                    }                
                }

                catch (Exception erro)
                {
                    erro.Message.ToString();
                }



                string nomeArquivoPDF = diretorio_temp + "Invoices_Vencidas" + DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss") + ".pdf";

                fileStream = new FileStream(nomeArquivoPDF, FileMode.Create);
                fileStream.Write(bytePDF, 0, bytePDF.Length);
                fileStream.Close();

                invoices = nomeArquivoPDF;

                //Process.Start(nomeArquivoPDF);
            }

            catch (Exception erro)
            {
                Console.WriteLine(erro);

            }
                      


        }


    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using FirebirdSql.Data.FirebirdClient;

namespace SincronizaNotas
{

    public partial class frmMain : Form
    {
        static string server = Properties.Settings.Default.ecodados;
        static FbConnection conexao = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void BtnAtualizar_Click(object sender, EventArgs e)
        {
            fswMonitor.EnableRaisingEvents = false;
            btnSincronizar.Enabled = false;
            await percorrer(tbxLog, progressBar);
            fswMonitor.EnableRaisingEvents = true;
            btnSincronizar.Enabled = true;
        }

        public async Task percorrer(RichTextBox tbxLog, ProgressBar progressBar)
        {
            conexao = new FbConnection(server);
            conexao.Open();
            data data = new data();

            string pathOrigem = Properties.Settings.Default.dirOrigem;
            int barValue = Directory.GetFiles(pathOrigem, "*.pdf", SearchOption.AllDirectories).Length;
            progressBar.Value = 0;
            progressBar.Maximum = barValue;
            

            try
            {
                await Task.Run(() =>
                {
                    foreach (string item in Directory.GetFiles(pathOrigem, "*.pdf", SearchOption.AllDirectories))
                    {
                        FileInfo itemInfo = new FileInfo(item);
                        tbxLog.Text += itemInfo.Name + "\n";
                        progressBar.Value++;
                        tbxLog.Select(tbxLog.Text.Length, 0);
                        tbxLog.ScrollToCaret();
                        data.verificaPDF(conexao, itemInfo.Name, itemInfo.FullName);
                    }
                });
                await Task.CompletedTask;

                progressBar.Value = 0;
                MessageBox.Show("Notas sincronizadas com sucesso!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ops! Algo inesperado aconteceu, contate o seu suporte." + "\n" + "\n" + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            finally
            {
                conexao.Close();
            }

        }

        void onFileCreated(object sender, FileSystemEventArgs e)
        {
            conexao = new FbConnection(server);
            conexao.Open();
            
            try
            {
                data data = new data();
                FileInfo info = new FileInfo(e.FullPath);
                data.verificaPDF(conexao, info.Name, info.FullName);
                tbxLog.Text += "Nova NFe encontrada \n" + info.Name + "\n";
            }
            catch (Exception erro)
            {
                MessageBox.Show("Ops! Algo inesperado aconteceu, contate o seu suporte." + "\n" + "\n" + erro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }   

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            fswMonitor.Path = Properties.Settings.Default.dirOrigem;
            fswMonitor.EnableRaisingEvents = true;
            btnSincronizar.Enabled = true;
        }
    }
}

namespace SincronizaNotas
{
    partial class frmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbxLog = new System.Windows.Forms.RichTextBox();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.fswMonitor = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.fswMonitor)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxLog
            // 
            this.tbxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxLog.BackColor = System.Drawing.Color.Black;
            this.tbxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLog.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.tbxLog.Location = new System.Drawing.Point(16, 15);
            this.tbxLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLog.Name = "tbxLog";
            this.tbxLog.ReadOnly = true;
            this.tbxLog.Size = new System.Drawing.Size(895, 452);
            this.tbxLog.TabIndex = 0;
            this.tbxLog.Text = "";
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSincronizar.Location = new System.Drawing.Point(811, 486);
            this.btnSincronizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(100, 28);
            this.btnSincronizar.TabIndex = 1;
            this.btnSincronizar.Text = "&Sincronizar";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(16, 486);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(787, 28);
            this.progressBar.TabIndex = 2;
            // 
            // fswMonitor
            // 
            this.fswMonitor.EnableRaisingEvents = true;
            this.fswMonitor.Filter = "*.pdf";
            this.fswMonitor.IncludeSubdirectories = true;
            this.fswMonitor.SynchronizingObject = this;
            this.fswMonitor.Created += new System.IO.FileSystemEventHandler(this.onFileCreated);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(927, 529);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.tbxLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sincroniza notas";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fswMonitor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbxLog;
        private System.Windows.Forms.Button btnSincronizar;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.IO.FileSystemWatcher fswMonitor;
    }
}


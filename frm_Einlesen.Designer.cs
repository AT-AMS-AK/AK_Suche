namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Einlesen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Einlesen));
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_extension = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_dtt = new System.Windows.Forms.TextBox();
            this.cmd_minus = new System.Windows.Forms.Button();
            this.cmd_plus = new System.Windows.Forms.Button();
            this.mtxt_buch_dat = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_kopie = new System.Windows.Forms.TextBox();
            this.lst_files = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.chk_rueckholung = new System.Windows.Forms.RadioButton();
            this.chk_dauerauftrag = new System.Windows.Forms.RadioButton();
            this.cmd_einlesen = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(556, 439);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(87, 27);
            this.cmd_schliessen.TabIndex = 10;
            this.cmd_schliessen.Text = "&Schliessen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.strip_info,
            this.lblLOCK,
            this.lblINS,
            this.lblNUM,
            this.lblCAPS,
            this.lblCON,
            this.labelDayDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(649, 28);
            this.statusStrip1.TabIndex = 49;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // strip_info
            // 
            this.strip_info.AutoSize = false;
            this.strip_info.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.strip_info.Name = "strip_info";
            this.strip_info.Size = new System.Drawing.Size(410, 23);
            this.strip_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.strip_info.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // lblLOCK
            // 
            this.lblLOCK.AutoSize = false;
            this.lblLOCK.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblLOCK.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.lblLOCK.Margin = new System.Windows.Forms.Padding(6);
            this.lblLOCK.Name = "lblLOCK";
            this.lblLOCK.Size = new System.Drawing.Size(14, 16);
            // 
            // lblINS
            // 
            this.lblINS.AutoSize = false;
            this.lblINS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblINS.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblINS.DoubleClickEnabled = true;
            this.lblINS.Name = "lblINS";
            this.lblINS.Size = new System.Drawing.Size(40, 23);
            this.lblINS.Text = "INS";
            this.lblINS.DoubleClick += new System.EventHandler(this.lblINS_DoubleClick);
            // 
            // lblNUM
            // 
            this.lblNUM.AutoSize = false;
            this.lblNUM.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblNUM.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblNUM.DoubleClickEnabled = true;
            this.lblNUM.Name = "lblNUM";
            this.lblNUM.Size = new System.Drawing.Size(40, 23);
            this.lblNUM.Text = "NUM";
            this.lblNUM.DoubleClick += new System.EventHandler(this.lblNUM_DoubleClick);
            // 
            // lblCAPS
            // 
            this.lblCAPS.AutoSize = false;
            this.lblCAPS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblCAPS.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblCAPS.DoubleClickEnabled = true;
            this.lblCAPS.Name = "lblCAPS";
            this.lblCAPS.Size = new System.Drawing.Size(40, 23);
            this.lblCAPS.Text = "CAPS";
            this.lblCAPS.DoubleClick += new System.EventHandler(this.lblCAPS_DoubleClick);
            // 
            // lblCON
            // 
            this.lblCON.Name = "lblCON";
            this.lblCON.Size = new System.Drawing.Size(39, 23);
            this.lblCON.Text = "lblCON";
            // 
            // labelDayDate
            // 
            this.labelDayDate.AutoSize = false;
            this.labelDayDate.Name = "labelDayDate";
            this.labelDayDate.Size = new System.Drawing.Size(130, 23);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_extension);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_dtt);
            this.groupBox1.Controls.Add(this.cmd_minus);
            this.groupBox1.Controls.Add(this.cmd_plus);
            this.groupBox1.Controls.Add(this.mtxt_buch_dat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_kopie);
            this.groupBox1.Controls.Add(this.lst_files);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_file);
            this.groupBox1.Controls.Add(this.chk_rueckholung);
            this.groupBox1.Controls.Add(this.chk_dauerauftrag);
            this.groupBox1.Location = new System.Drawing.Point(0, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 411);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selektieren sie den gewünschten Datenträger";
            // 
            // txt_extension
            // 
            this.txt_extension.Enabled = false;
            this.txt_extension.Location = new System.Drawing.Point(584, 261);
            this.txt_extension.Name = "txt_extension";
            this.txt_extension.Size = new System.Drawing.Size(36, 21);
            this.txt_extension.TabIndex = 19;
            this.txt_extension.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(295, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name des Datenträgers";
            // 
            // txt_dtt
            // 
            this.txt_dtt.Enabled = false;
            this.txt_dtt.Location = new System.Drawing.Point(298, 345);
            this.txt_dtt.Name = "txt_dtt";
            this.txt_dtt.Size = new System.Drawing.Size(322, 21);
            this.txt_dtt.TabIndex = 8;
            // 
            // cmd_minus
            // 
            this.cmd_minus.Location = new System.Drawing.Point(548, 179);
            this.cmd_minus.Name = "cmd_minus";
            this.cmd_minus.Size = new System.Drawing.Size(14, 23);
            this.cmd_minus.TabIndex = 6;
            this.cmd_minus.Text = "-";
            this.cmd_minus.UseVisualStyleBackColor = true;
            this.cmd_minus.Click += new System.EventHandler(this.cmd_minus_Click);
            this.cmd_minus.Enter += new System.EventHandler(this.cmd_minus_Enter);
            this.cmd_minus.Leave += new System.EventHandler(this.cmd_minus_Leave);
            // 
            // cmd_plus
            // 
            this.cmd_plus.Location = new System.Drawing.Point(528, 179);
            this.cmd_plus.Name = "cmd_plus";
            this.cmd_plus.Size = new System.Drawing.Size(14, 23);
            this.cmd_plus.TabIndex = 5;
            this.cmd_plus.Text = "+";
            this.cmd_plus.UseVisualStyleBackColor = true;
            this.cmd_plus.Click += new System.EventHandler(this.cmd_plus_Click);
            this.cmd_plus.Enter += new System.EventHandler(this.cmd_plus_Enter);
            this.cmd_plus.Leave += new System.EventHandler(this.cmd_plus_Leave);
            // 
            // mtxt_buch_dat
            // 
            this.mtxt_buch_dat.Location = new System.Drawing.Point(435, 179);
            this.mtxt_buch_dat.Mask = "__.__.____";
            this.mtxt_buch_dat.Name = "mtxt_buch_dat";
            this.mtxt_buch_dat.Size = new System.Drawing.Size(80, 21);
            this.mtxt_buch_dat.TabIndex = 4;
            this.mtxt_buch_dat.Enter += new System.EventHandler(this.mtxt_buch_dat_Enter);
            this.mtxt_buch_dat.Leave += new System.EventHandler(this.mtxt_buch_dat_Leave);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(295, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Buchungsdatum";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(295, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name der Datenträgerkopie";
            // 
            // txt_kopie
            // 
            this.txt_kopie.Location = new System.Drawing.Point(298, 261);
            this.txt_kopie.Name = "txt_kopie";
            this.txt_kopie.Size = new System.Drawing.Size(290, 21);
            this.txt_kopie.TabIndex = 7;
            this.txt_kopie.Enter += new System.EventHandler(this.txt_kopie_Enter);
            this.txt_kopie.Leave += new System.EventHandler(this.txt_kopie_Leave);
            // 
            // lst_files
            // 
            this.lst_files.Location = new System.Drawing.Point(12, 34);
            this.lst_files.Name = "lst_files";
            this.lst_files.Size = new System.Drawing.Size(252, 359);
            this.lst_files.TabIndex = 2;
            this.lst_files.UseCompatibleStateImageBehavior = false;
            this.lst_files.Click += new System.EventHandler(this.lst_files_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(295, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name der Protokollierungsdatei:";
            // 
            // txt_file
            // 
            this.txt_file.Location = new System.Drawing.Point(298, 123);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(312, 21);
            this.txt_file.TabIndex = 3;
            this.txt_file.Enter += new System.EventHandler(this.txt_file_Enter);
            this.txt_file.Leave += new System.EventHandler(this.txt_file_Leave);
            // 
            // chk_rueckholung
            // 
            this.chk_rueckholung.AutoSize = true;
            this.chk_rueckholung.Location = new System.Drawing.Point(277, 60);
            this.chk_rueckholung.Name = "chk_rueckholung";
            this.chk_rueckholung.Size = new System.Drawing.Size(97, 20);
            this.chk_rueckholung.TabIndex = 1;
            this.chk_rueckholung.TabStop = true;
            this.chk_rueckholung.Text = "Rückholung";
            this.chk_rueckholung.UseVisualStyleBackColor = true;
            this.chk_rueckholung.Click += new System.EventHandler(this.chk_rueckholung_Click);
            this.chk_rueckholung.Enter += new System.EventHandler(this.chk_rueckholung_Enter);
            this.chk_rueckholung.Leave += new System.EventHandler(this.chk_rueckholung_Leave);
            // 
            // chk_dauerauftrag
            // 
            this.chk_dauerauftrag.AutoSize = true;
            this.chk_dauerauftrag.Location = new System.Drawing.Point(277, 34);
            this.chk_dauerauftrag.Name = "chk_dauerauftrag";
            this.chk_dauerauftrag.Size = new System.Drawing.Size(104, 20);
            this.chk_dauerauftrag.TabIndex = 0;
            this.chk_dauerauftrag.TabStop = true;
            this.chk_dauerauftrag.Text = "Dauerauftrag";
            this.chk_dauerauftrag.UseVisualStyleBackColor = true;
            this.chk_dauerauftrag.Click += new System.EventHandler(this.chk_dauerauftrag_Click);
            this.chk_dauerauftrag.Enter += new System.EventHandler(this.chk_dauerauftrag_Enter);
            this.chk_dauerauftrag.Leave += new System.EventHandler(this.chk_dauerauftrag_Leave);
            // 
            // cmd_einlesen
            // 
            this.cmd_einlesen.Location = new System.Drawing.Point(463, 439);
            this.cmd_einlesen.Name = "cmd_einlesen";
            this.cmd_einlesen.Size = new System.Drawing.Size(87, 27);
            this.cmd_einlesen.TabIndex = 9;
            this.cmd_einlesen.Text = "&Einlesen";
            this.cmd_einlesen.UseVisualStyleBackColor = true;
            this.cmd_einlesen.Click += new System.EventHandler(this.cmd_einlesen_Click);
            // 
            // frm_Einlesen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 502);
            this.Controls.Add(this.cmd_einlesen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmd_schliessen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Einlesen";
            this.Text = "Datei einlesen";
            this.Activated += new System.EventHandler(this.frm_Einlesen_Activated);
            this.Load += new System.EventHandler(this.frm_Einlesen_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Einlesen_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_kopie;
        private System.Windows.Forms.ListView lst_files;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.RadioButton chk_rueckholung;
        private System.Windows.Forms.RadioButton chk_dauerauftrag;
        private System.Windows.Forms.Button cmd_einlesen;
        private System.Windows.Forms.MaskedTextBox mtxt_buch_dat;
        private System.Windows.Forms.Button cmd_minus;
        private System.Windows.Forms.Button cmd_plus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_dtt;
        private System.Windows.Forms.TextBox txt_extension;
    }
}
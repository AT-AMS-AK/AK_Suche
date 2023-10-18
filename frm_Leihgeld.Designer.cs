namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Leihgeld
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Leihgeld));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtxt_Bu_Date = new System.Windows.Forms.MaskedTextBox();
            this.txt_Betrag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chk_haben = new System.Windows.Forms.RadioButton();
            this.chk_soll = new System.Windows.Forms.RadioButton();
            this.cmd_buchen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_summe = new System.Windows.Forms.TextBox();
            this.cmd_druck = new System.Windows.Forms.Button();
            this.cmd_storno = new System.Windows.Forms.Button();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmd_aktual = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lst_buchungen = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxt_Bu_Date);
            this.groupBox1.Controls.Add(this.txt_Betrag);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.chk_haben);
            this.groupBox1.Controls.Add(this.chk_soll);
            this.groupBox1.Controls.Add(this.cmd_buchen);
            this.groupBox1.Location = new System.Drawing.Point(12, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buchungen";
            // 
            // mtxt_Bu_Date
            // 
            this.mtxt_Bu_Date.Location = new System.Drawing.Point(159, 37);
            this.mtxt_Bu_Date.Name = "mtxt_Bu_Date";
            this.mtxt_Bu_Date.Size = new System.Drawing.Size(83, 20);
            this.mtxt_Bu_Date.TabIndex = 3;
            this.mtxt_Bu_Date.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mtxt_Bu_Date_MouseClick);
            this.mtxt_Bu_Date.DoubleClick += new System.EventHandler(this.mtxt_Bu_Date_DoubleClick);
            this.mtxt_Bu_Date.Enter += new System.EventHandler(this.mtxt_Bu_Date_Enter);
            this.mtxt_Bu_Date.Leave += new System.EventHandler(this.mtxt_Bu_Date_Leave);
            // 
            // txt_Betrag
            // 
            this.txt_Betrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Betrag.Location = new System.Drawing.Point(346, 34);
            this.txt_Betrag.Name = "txt_Betrag";
            this.txt_Betrag.Size = new System.Drawing.Size(88, 23);
            this.txt_Betrag.TabIndex = 4;
            this.txt_Betrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Betrag.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_Betrag_MouseClick);
            this.txt_Betrag.DoubleClick += new System.EventHandler(this.txt_Betrag_DoubleClick);
            this.txt_Betrag.Enter += new System.EventHandler(this.txt_Betrag_Enter);
            this.txt_Betrag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Betrag_KeyPress);
            this.txt_Betrag.Leave += new System.EventHandler(this.txt_Betrag_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Buchungsdatum";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(268, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Betrag";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(455, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Buchungsart";
            // 
            // chk_haben
            // 
            this.chk_haben.AutoSize = true;
            this.chk_haben.Location = new System.Drawing.Point(548, 63);
            this.chk_haben.Name = "chk_haben";
            this.chk_haben.Size = new System.Drawing.Size(57, 17);
            this.chk_haben.TabIndex = 6;
            this.chk_haben.TabStop = true;
            this.chk_haben.Text = "Haben";
            this.chk_haben.UseVisualStyleBackColor = true;
            this.chk_haben.Enter += new System.EventHandler(this.chk_soll_Enter);
            this.chk_haben.Leave += new System.EventHandler(this.chk_soll_Leave);
            // 
            // chk_soll
            // 
            this.chk_soll.AutoSize = true;
            this.chk_soll.Location = new System.Drawing.Point(548, 38);
            this.chk_soll.Name = "chk_soll";
            this.chk_soll.Size = new System.Drawing.Size(42, 17);
            this.chk_soll.TabIndex = 5;
            this.chk_soll.TabStop = true;
            this.chk_soll.Text = "Soll";
            this.chk_soll.UseVisualStyleBackColor = true;
            this.chk_soll.Enter += new System.EventHandler(this.chk_soll_Enter);
            this.chk_soll.Leave += new System.EventHandler(this.chk_soll_Leave);
            // 
            // cmd_buchen
            // 
            this.cmd_buchen.Location = new System.Drawing.Point(635, 60);
            this.cmd_buchen.Name = "cmd_buchen";
            this.cmd_buchen.Size = new System.Drawing.Size(75, 23);
            this.cmd_buchen.TabIndex = 7;
            this.cmd_buchen.Text = "&Buchen";
            this.cmd_buchen.UseVisualStyleBackColor = true;
            this.cmd_buchen.Click += new System.EventHandler(this.cmd_buchen_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Gesamtbetrag";
            // 
            // txt_summe
            // 
            this.txt_summe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_summe.Location = new System.Drawing.Point(162, 435);
            this.txt_summe.Name = "txt_summe";
            this.txt_summe.Size = new System.Drawing.Size(153, 23);
            this.txt_summe.TabIndex = 2;
            // 
            // cmd_druck
            // 
            this.cmd_druck.Location = new System.Drawing.Point(408, 592);
            this.cmd_druck.Name = "cmd_druck";
            this.cmd_druck.Size = new System.Drawing.Size(131, 23);
            this.cmd_druck.TabIndex = 8;
            this.cmd_druck.Text = "Kontenblatt &drucken";
            this.cmd_druck.UseVisualStyleBackColor = true;
            this.cmd_druck.Click += new System.EventHandler(this.cmd_druck_Click);
            // 
            // cmd_storno
            // 
            this.cmd_storno.Location = new System.Drawing.Point(563, 592);
            this.cmd_storno.Name = "cmd_storno";
            this.cmd_storno.Size = new System.Drawing.Size(76, 23);
            this.cmd_storno.TabIndex = 9;
            this.cmd_storno.Text = "S&tornieren";
            this.cmd_storno.UseVisualStyleBackColor = true;
            this.cmd_storno.Click += new System.EventHandler(this.cmd_storno_Click);
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(663, 592);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(76, 23);
            this.cmd_schliessen.TabIndex = 10;
            this.cmd_schliessen.Text = "&Schließen";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 642);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 24);
            this.statusStrip1.TabIndex = 41;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // strip_info
            // 
            this.strip_info.AutoSize = false;
            this.strip_info.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.strip_info.Name = "strip_info";
            this.strip_info.Size = new System.Drawing.Size(410, 19);
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
            this.lblLOCK.Size = new System.Drawing.Size(14, 12);
            // 
            // lblINS
            // 
            this.lblINS.AutoSize = false;
            this.lblINS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblINS.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblINS.DoubleClickEnabled = true;
            this.lblINS.Name = "lblINS";
            this.lblINS.Size = new System.Drawing.Size(40, 19);
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
            this.lblNUM.Size = new System.Drawing.Size(40, 19);
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
            this.lblCAPS.Size = new System.Drawing.Size(40, 19);
            this.lblCAPS.Text = "CAPS";
            this.lblCAPS.DoubleClick += new System.EventHandler(this.lblCAPS_DoubleClick);
            // 
            // lblCON
            // 
            this.lblCON.Name = "lblCON";
            this.lblCON.Size = new System.Drawing.Size(46, 19);
            this.lblCON.Text = "lblCON";
            // 
            // labelDayDate
            // 
            this.labelDayDate.AutoSize = false;
            this.labelDayDate.Name = "labelDayDate";
            this.labelDayDate.Size = new System.Drawing.Size(130, 19);
            // 
            // cmd_aktual
            // 
            this.cmd_aktual.Location = new System.Drawing.Point(253, 592);
            this.cmd_aktual.Name = "cmd_aktual";
            this.cmd_aktual.Size = new System.Drawing.Size(131, 23);
            this.cmd_aktual.TabIndex = 42;
            this.cmd_aktual.Text = "&Aktualisieren";
            this.cmd_aktual.UseVisualStyleBackColor = true;
            this.cmd_aktual.Click += new System.EventHandler(this.cmd_aktual_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lst_buchungen);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(716, 417);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kontoblatt";
            // 
            // lst_buchungen
            // 
            this.lst_buchungen.Location = new System.Drawing.Point(6, 31);
            this.lst_buchungen.Name = "lst_buchungen";
            this.lst_buchungen.Size = new System.Drawing.Size(704, 380);
            this.lst_buchungen.TabIndex = 1;
            this.lst_buchungen.UseCompatibleStateImageBehavior = false;
            // 
            // frm_Leihgeld
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(758, 666);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmd_aktual);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.cmd_storno);
            this.Controls.Add(this.cmd_druck);
            this.Controls.Add(this.txt_summe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Leihgeld";
            this.Text = "Zuschusskonten für Wohnbaudarlehen";
            this.Activated += new System.EventHandler(this.frm_Leihgeld_Activated);
            this.Load += new System.EventHandler(this.frm_Leihgeld_Load);
            this.Enter += new System.EventHandler(this.frm_Leihgeld_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Leihgeld_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_summe;
        private System.Windows.Forms.Button cmd_druck;
        private System.Windows.Forms.Button cmd_storno;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton chk_haben;
        private System.Windows.Forms.RadioButton chk_soll;
        private System.Windows.Forms.Button cmd_buchen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxt_Bu_Date;
        private System.Windows.Forms.TextBox txt_Betrag;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.Button cmd_aktual;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lst_buchungen;
    }
}
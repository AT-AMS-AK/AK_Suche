namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Buchen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Buchen));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_betrag = new System.Windows.Forms.TextBox();
            this.mtxt_buchungsdatum = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_kontonr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_antragsteller = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_typ = new System.Windows.Forms.ComboBox();
            this.cbo_art = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_text = new System.Windows.Forms.TextBox();
            this.lst_buchungen = new System.Windows.Forms.ListView();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.cmd_buchen = new System.Windows.Forms.Button();
            this.cmd_storno = new System.Windows.Forms.Button();
            this.dgv_typ = new System.Windows.Forms.DataGridView();
            this.dgv_art = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_typ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_art)).BeginInit();
            this.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 600);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(766, 24);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_betrag);
            this.groupBox1.Controls.Add(this.mtxt_buchungsdatum);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_kontonr);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_antragsteller);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbo_typ);
            this.groupBox1.Controls.Add(this.cbo_art);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_text);
            this.groupBox1.Controls.Add(this.lst_buchungen);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 525);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manuell buchen";
            // 
            // txt_betrag
            // 
            this.txt_betrag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_betrag.Location = new System.Drawing.Point(152, 142);
            this.txt_betrag.Name = "txt_betrag";
            this.txt_betrag.Size = new System.Drawing.Size(87, 20);
            this.txt_betrag.TabIndex = 1;
            this.txt_betrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_betrag.Enter += new System.EventHandler(this.txt_betrag_Enter);
            this.txt_betrag.Leave += new System.EventHandler(this.txt_betrag_Leave);
            this.txt_betrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_betrag_MouseDown);
            // 
            // mtxt_buchungsdatum
            // 
            this.mtxt_buchungsdatum.Location = new System.Drawing.Point(614, 31);
            this.mtxt_buchungsdatum.Name = "mtxt_buchungsdatum";
            this.mtxt_buchungsdatum.Size = new System.Drawing.Size(107, 20);
            this.mtxt_buchungsdatum.TabIndex = 0;
            this.mtxt_buchungsdatum.Click += new System.EventHandler(this.mtxt_buchungsdatum_Click);
            this.mtxt_buchungsdatum.Enter += new System.EventHandler(this.mtxt_buchungsdatum_Enter);
            this.mtxt_buchungsdatum.Leave += new System.EventHandler(this.mtxt_buchungsdatum_Leave);
            this.mtxt_buchungsdatum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mtxt_buchungsdatum_MouseDown);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(496, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Buchungsdatum";
            // 
            // txt_kontonr
            // 
            this.txt_kontonr.Location = new System.Drawing.Point(614, 66);
            this.txt_kontonr.Name = "txt_kontonr";
            this.txt_kontonr.Size = new System.Drawing.Size(107, 20);
            this.txt_kontonr.TabIndex = 12;
            this.txt_kontonr.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(496, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Konto Nr.";
            // 
            // txt_antragsteller
            // 
            this.txt_antragsteller.Location = new System.Drawing.Point(152, 66);
            this.txt_antragsteller.Name = "txt_antragsteller";
            this.txt_antragsteller.Size = new System.Drawing.Size(297, 20);
            this.txt_antragsteller.TabIndex = 10;
            this.txt_antragsteller.TabStop = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(29, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 99;
            this.label5.Text = "Antragsteller";
            // 
            // cbo_typ
            // 
            this.cbo_typ.FormattingEnabled = true;
            this.cbo_typ.Location = new System.Drawing.Point(614, 142);
            this.cbo_typ.Name = "cbo_typ";
            this.cbo_typ.Size = new System.Drawing.Size(107, 21);
            this.cbo_typ.TabIndex = 3;
            this.cbo_typ.Enter += new System.EventHandler(this.cbo_typ_Enter);
            this.cbo_typ.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_typ_KeyUp);
            this.cbo_typ.Leave += new System.EventHandler(this.cbo_typ_Leave);
            // 
            // cbo_art
            // 
            this.cbo_art.FormattingEnabled = true;
            this.cbo_art.Location = new System.Drawing.Point(352, 142);
            this.cbo_art.Name = "cbo_art";
            this.cbo_art.Size = new System.Drawing.Size(97, 21);
            this.cbo_art.TabIndex = 2;
            this.cbo_art.Enter += new System.EventHandler(this.cbo_art_Enter);
            this.cbo_art.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_art_KeyUp);
            this.cbo_art.Leave += new System.EventHandler(this.cbo_art_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(496, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 99;
            this.label4.Text = "Buchungstyp";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(266, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Buchungsart";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(29, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Buchungsbetrag";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(29, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Buchungstext";
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(32, 199);
            this.txt_text.Multiline = true;
            this.txt_text.Name = "txt_text";
            this.txt_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_text.Size = new System.Drawing.Size(689, 78);
            this.txt_text.TabIndex = 4;
            this.txt_text.Enter += new System.EventHandler(this.txt_text_Enter);
            this.txt_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_text_KeyPress);
            this.txt_text.Leave += new System.EventHandler(this.txt_text_Leave);
            // 
            // lst_buchungen
            // 
            this.lst_buchungen.Location = new System.Drawing.Point(32, 292);
            this.lst_buchungen.MultiSelect = false;
            this.lst_buchungen.Name = "lst_buchungen";
            this.lst_buchungen.Size = new System.Drawing.Size(689, 213);
            this.lst_buchungen.TabIndex = 99;
            this.lst_buchungen.TabStop = false;
            this.lst_buchungen.UseCompatibleStateImageBehavior = false;
            this.lst_buchungen.Click += new System.EventHandler(this.lst_buchungen_Click);
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(676, 565);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliessen.TabIndex = 7;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_buchen
            // 
            this.cmd_buchen.Location = new System.Drawing.Point(470, 565);
            this.cmd_buchen.Name = "cmd_buchen";
            this.cmd_buchen.Size = new System.Drawing.Size(75, 23);
            this.cmd_buchen.TabIndex = 5;
            this.cmd_buchen.Text = "&Buchen";
            this.cmd_buchen.UseVisualStyleBackColor = true;
            this.cmd_buchen.Click += new System.EventHandler(this.cmd_buchen_Click);
            // 
            // cmd_storno
            // 
            this.cmd_storno.Location = new System.Drawing.Point(573, 565);
            this.cmd_storno.Name = "cmd_storno";
            this.cmd_storno.Size = new System.Drawing.Size(75, 23);
            this.cmd_storno.TabIndex = 6;
            this.cmd_storno.Text = "S&torno";
            this.cmd_storno.UseVisualStyleBackColor = true;
            this.cmd_storno.Click += new System.EventHandler(this.cmd_storno_Click);
            // 
            // dgv_typ
            // 
            this.dgv_typ.AllowUserToAddRows = false;
            this.dgv_typ.AllowUserToDeleteRows = false;
            this.dgv_typ.Location = new System.Drawing.Point(249, 534);
            this.dgv_typ.MaximumSize = new System.Drawing.Size(500, 500);
            this.dgv_typ.Name = "dgv_typ";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_typ.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_typ.ShowCellErrors = false;
            this.dgv_typ.ShowCellToolTips = false;
            this.dgv_typ.ShowEditingIcon = false;
            this.dgv_typ.ShowRowErrors = false;
            this.dgv_typ.Size = new System.Drawing.Size(189, 71);
            this.dgv_typ.TabIndex = 70;
            this.dgv_typ.Visible = false;
            // 
            // dgv_art
            // 
            this.dgv_art.AllowUserToAddRows = false;
            this.dgv_art.AllowUserToDeleteRows = false;
            this.dgv_art.Location = new System.Drawing.Point(44, 534);
            this.dgv_art.MaximumSize = new System.Drawing.Size(500, 500);
            this.dgv_art.Name = "dgv_art";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_art.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_art.ShowCellErrors = false;
            this.dgv_art.ShowCellToolTips = false;
            this.dgv_art.ShowEditingIcon = false;
            this.dgv_art.ShowRowErrors = false;
            this.dgv_art.Size = new System.Drawing.Size(184, 71);
            this.dgv_art.TabIndex = 71;
            this.dgv_art.Visible = false;
            // 
            // frm_Buchen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 624);
            this.Controls.Add(this.dgv_typ);
            this.Controls.Add(this.dgv_art);
            this.Controls.Add(this.cmd_storno);
            this.Controls.Add(this.cmd_buchen);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Buchen";
            this.Text = "Manuelle Buchungen zum Antrag";
            this.Activated += new System.EventHandler(this.frm_Buchen_Activated);
            this.Load += new System.EventHandler(this.frm_Buchen_Load);
            this.Enter += new System.EventHandler(this.frm_Buchen_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Buchen_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_typ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_art)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.ListView lst_buchungen;
        private System.Windows.Forms.Button cmd_buchen;
        private System.Windows.Forms.Button cmd_storno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_text;
        private System.Windows.Forms.ComboBox cbo_typ;
        private System.Windows.Forms.ComboBox cbo_art;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_antragsteller;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mtxt_buchungsdatum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_betrag;
        private System.Windows.Forms.DataGridView dgv_typ;
        private System.Windows.Forms.DataGridView dgv_art;
        private System.Windows.Forms.TextBox txt_kontonr;
    }
}
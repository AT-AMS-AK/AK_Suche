namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Mahnlauf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Mahnlauf));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_info = new System.Windows.Forms.ListView();
            this.cmd_log = new System.Windows.Forms.Button();
            this.txt_M4 = new System.Windows.Forms.TextBox();
            this.txt_M3 = new System.Windows.Forms.TextBox();
            this.txt_M2 = new System.Windows.Forms.TextBox();
            this.txt_M1 = new System.Windows.Forms.TextBox();
            this.txt_RA = new System.Windows.Forms.TextBox();
            this.txt_Uber = new System.Windows.Forms.TextBox();
            this.txt_Tilg = new System.Windows.Forms.TextBox();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.cmd_ML = new System.Windows.Forms.Button();
            this.cmd_Liste = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grp_2 = new System.Windows.Forms.GroupBox();
            this.chk_reset = new System.Windows.Forms.RadioButton();
            this.chk_ML5 = new System.Windows.Forms.RadioButton();
            this.chk_ML4 = new System.Windows.Forms.RadioButton();
            this.chk_ML3 = new System.Windows.Forms.RadioButton();
            this.chk_ML2 = new System.Windows.Forms.RadioButton();
            this.chk_ML1 = new System.Windows.Forms.RadioButton();
            this.grp_1 = new System.Windows.Forms.GroupBox();
            this.cmd_print = new System.Windows.Forms.Button();
            this.txt_offset = new System.Windows.Forms.TextBox();
            this.chk_wbd_log = new System.Windows.Forms.RadioButton();
            this.chk_ML_Log = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grp_2.SuspendLayout();
            this.grp_1.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(650, 24);
            this.statusStrip1.TabIndex = 22;
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
            this.groupBox1.Controls.Add(this.lst_info);
            this.groupBox1.Controls.Add(this.cmd_log);
            this.groupBox1.Controls.Add(this.txt_M4);
            this.groupBox1.Controls.Add(this.txt_M3);
            this.groupBox1.Controls.Add(this.txt_M2);
            this.groupBox1.Controls.Add(this.txt_M1);
            this.groupBox1.Controls.Add(this.txt_RA);
            this.groupBox1.Controls.Add(this.txt_Uber);
            this.groupBox1.Controls.Add(this.txt_Tilg);
            this.groupBox1.Controls.Add(this.cmd_schliessen);
            this.groupBox1.Controls.Add(this.cmd_ML);
            this.groupBox1.Controls.Add(this.cmd_Liste);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 440);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nicht bearbeitete Drucke seit dem letzten Mahnlauf";
            // 
            // lst_info
            // 
            this.lst_info.Location = new System.Drawing.Point(6, 37);
            this.lst_info.Name = "lst_info";
            this.lst_info.Size = new System.Drawing.Size(611, 357);
            this.lst_info.TabIndex = 27;
            this.lst_info.UseCompatibleStateImageBehavior = false;
            // 
            // cmd_log
            // 
            this.cmd_log.Location = new System.Drawing.Point(6, 404);
            this.cmd_log.Name = "cmd_log";
            this.cmd_log.Size = new System.Drawing.Size(75, 23);
            this.cmd_log.TabIndex = 17;
            this.cmd_log.Text = "L&og";
            this.cmd_log.UseVisualStyleBackColor = true;
            this.cmd_log.Click += new System.EventHandler(this.cmd_log_Click);
            // 
            // txt_M4
            // 
            this.txt_M4.Location = new System.Drawing.Point(296, 279);
            this.txt_M4.Name = "txt_M4";
            this.txt_M4.Size = new System.Drawing.Size(100, 20);
            this.txt_M4.TabIndex = 16;
            // 
            // txt_M3
            // 
            this.txt_M3.Location = new System.Drawing.Point(296, 243);
            this.txt_M3.Name = "txt_M3";
            this.txt_M3.Size = new System.Drawing.Size(100, 20);
            this.txt_M3.TabIndex = 15;
            // 
            // txt_M2
            // 
            this.txt_M2.Location = new System.Drawing.Point(296, 207);
            this.txt_M2.Name = "txt_M2";
            this.txt_M2.Size = new System.Drawing.Size(100, 20);
            this.txt_M2.TabIndex = 14;
            // 
            // txt_M1
            // 
            this.txt_M1.Location = new System.Drawing.Point(296, 169);
            this.txt_M1.Name = "txt_M1";
            this.txt_M1.Size = new System.Drawing.Size(100, 20);
            this.txt_M1.TabIndex = 13;
            // 
            // txt_RA
            // 
            this.txt_RA.Location = new System.Drawing.Point(296, 134);
            this.txt_RA.Name = "txt_RA";
            this.txt_RA.Size = new System.Drawing.Size(100, 20);
            this.txt_RA.TabIndex = 12;
            // 
            // txt_Uber
            // 
            this.txt_Uber.Location = new System.Drawing.Point(296, 97);
            this.txt_Uber.Name = "txt_Uber";
            this.txt_Uber.Size = new System.Drawing.Size(100, 20);
            this.txt_Uber.TabIndex = 11;
            // 
            // txt_Tilg
            // 
            this.txt_Tilg.Location = new System.Drawing.Point(296, 60);
            this.txt_Tilg.Name = "txt_Tilg";
            this.txt_Tilg.Size = new System.Drawing.Size(100, 20);
            this.txt_Tilg.TabIndex = 10;
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(542, 404);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliessen.TabIndex = 9;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_ML
            // 
            this.cmd_ML.Location = new System.Drawing.Point(448, 404);
            this.cmd_ML.Name = "cmd_ML";
            this.cmd_ML.Size = new System.Drawing.Size(75, 23);
            this.cmd_ML.TabIndex = 8;
            this.cmd_ML.Text = "&Mahnlauf";
            this.cmd_ML.UseVisualStyleBackColor = true;
            this.cmd_ML.Click += new System.EventHandler(this.cmd_ML_Click);
            // 
            // cmd_Liste
            // 
            this.cmd_Liste.Location = new System.Drawing.Point(357, 404);
            this.cmd_Liste.Name = "cmd_Liste";
            this.cmd_Liste.Size = new System.Drawing.Size(75, 23);
            this.cmd_Liste.TabIndex = 7;
            this.cmd_Liste.Text = "&Liste";
            this.cmd_Liste.UseVisualStyleBackColor = true;
            this.cmd_Liste.Click += new System.EventHandler(this.cmd_Liste_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(17, 286);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mahnschreiben für vierte Mahnung";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(17, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(273, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mahnschreiben für dritte Mahnung";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(273, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mahnschreiben für zweite Mahnung";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(273, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mahnschreiben für erste Mahnung";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(17, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Meldung an Rechtsanwalt";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Überzahlungsschreiben";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tilgungsschreiben";
            // 
            // grp_2
            // 
            this.grp_2.Controls.Add(this.chk_reset);
            this.grp_2.Controls.Add(this.chk_ML5);
            this.grp_2.Controls.Add(this.chk_ML4);
            this.grp_2.Controls.Add(this.chk_ML3);
            this.grp_2.Controls.Add(this.chk_ML2);
            this.grp_2.Controls.Add(this.chk_ML1);
            this.grp_2.Location = new System.Drawing.Point(263, 471);
            this.grp_2.Name = "grp_2";
            this.grp_2.Size = new System.Drawing.Size(383, 77);
            this.grp_2.TabIndex = 24;
            this.grp_2.TabStop = false;
            // 
            // chk_reset
            // 
            this.chk_reset.AutoSize = true;
            this.chk_reset.ForeColor = System.Drawing.Color.Gray;
            this.chk_reset.Location = new System.Drawing.Point(316, 48);
            this.chk_reset.Name = "chk_reset";
            this.chk_reset.Size = new System.Drawing.Size(53, 17);
            this.chk_reset.TabIndex = 5;
            this.chk_reset.TabStop = true;
            this.chk_reset.Text = "Reset";
            this.chk_reset.UseVisualStyleBackColor = true;
            this.chk_reset.Click += new System.EventHandler(this.chk_reset_Click);
            // 
            // chk_ML5
            // 
            this.chk_ML5.AutoSize = true;
            this.chk_ML5.Location = new System.Drawing.Point(196, 13);
            this.chk_ML5.Name = "chk_ML5";
            this.chk_ML5.Size = new System.Drawing.Size(139, 17);
            this.chk_ML5.TabIndex = 4;
            this.chk_ML5.TabStop = true;
            this.chk_ML5.Text = "Theoret.  Tilgungsstatus";
            this.chk_ML5.UseVisualStyleBackColor = true;
            this.chk_ML5.Click += new System.EventHandler(this.chk_ML5_Click);
            // 
            // chk_ML4
            // 
            this.chk_ML4.AutoSize = true;
            this.chk_ML4.Location = new System.Drawing.Point(161, 48);
            this.chk_ML4.Name = "chk_ML4";
            this.chk_ML4.Size = new System.Drawing.Size(119, 17);
            this.chk_ML4.TabIndex = 3;
            this.chk_ML4.TabStop = true;
            this.chk_ML4.Text = "Tilgungsaussetzung";
            this.chk_ML4.UseVisualStyleBackColor = true;
            this.chk_ML4.Click += new System.EventHandler(this.chk_ML4_Click);
            // 
            // chk_ML3
            // 
            this.chk_ML3.AutoSize = true;
            this.chk_ML3.Location = new System.Drawing.Point(99, 13);
            this.chk_ML3.Name = "chk_ML3";
            this.chk_ML3.Size = new System.Drawing.Size(77, 17);
            this.chk_ML3.TabIndex = 2;
            this.chk_ML3.TabStop = true;
            this.chk_ML3.Text = "Plausibilität";
            this.chk_ML3.UseVisualStyleBackColor = true;
            this.chk_ML3.Click += new System.EventHandler(this.chk_ML3_Click);
            // 
            // chk_ML2
            // 
            this.chk_ML2.AutoSize = true;
            this.chk_ML2.Location = new System.Drawing.Point(6, 48);
            this.chk_ML2.Name = "chk_ML2";
            this.chk_ML2.Size = new System.Drawing.Size(125, 17);
            this.chk_ML2.TabIndex = 1;
            this.chk_ML2.TabStop = true;
            this.chk_ML2.Text = "TIL vor Rückzahlung";
            this.chk_ML2.UseVisualStyleBackColor = true;
            this.chk_ML2.Click += new System.EventHandler(this.chk_ML2_Click);
            // 
            // chk_ML1
            // 
            this.chk_ML1.AutoSize = true;
            this.chk_ML1.Location = new System.Drawing.Point(6, 13);
            this.chk_ML1.Name = "chk_ML1";
            this.chk_ML1.Size = new System.Drawing.Size(75, 17);
            this.chk_ML1.TabIndex = 0;
            this.chk_ML1.TabStop = true;
            this.chk_ML1.Text = "Mahnstufe";
            this.chk_ML1.UseVisualStyleBackColor = true;
            this.chk_ML1.Click += new System.EventHandler(this.chk_ML1_Click);
            // 
            // grp_1
            // 
            this.grp_1.Controls.Add(this.cmd_print);
            this.grp_1.Controls.Add(this.txt_offset);
            this.grp_1.Controls.Add(this.chk_wbd_log);
            this.grp_1.Controls.Add(this.chk_ML_Log);
            this.grp_1.Location = new System.Drawing.Point(12, 471);
            this.grp_1.Name = "grp_1";
            this.grp_1.Size = new System.Drawing.Size(245, 77);
            this.grp_1.TabIndex = 26;
            this.grp_1.TabStop = false;
            // 
            // cmd_print
            // 
            this.cmd_print.Location = new System.Drawing.Point(160, 29);
            this.cmd_print.Name = "cmd_print";
            this.cmd_print.Size = new System.Drawing.Size(75, 23);
            this.cmd_print.TabIndex = 25;
            this.cmd_print.Text = "&Print";
            this.cmd_print.UseVisualStyleBackColor = true;
            this.cmd_print.Click += new System.EventHandler(this.cmd_print_Click);
            // 
            // txt_offset
            // 
            this.txt_offset.Location = new System.Drawing.Point(113, 10);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(41, 20);
            this.txt_offset.TabIndex = 24;
            this.txt_offset.Leave += new System.EventHandler(this.txt_offset_Leave);
            // 
            // chk_wbd_log
            // 
            this.chk_wbd_log.AutoSize = true;
            this.chk_wbd_log.Location = new System.Drawing.Point(10, 13);
            this.chk_wbd_log.Name = "chk_wbd_log";
            this.chk_wbd_log.Size = new System.Drawing.Size(75, 17);
            this.chk_wbd_log.TabIndex = 22;
            this.chk_wbd_log.TabStop = true;
            this.chk_wbd_log.Text = "WBD_Log";
            this.chk_wbd_log.UseVisualStyleBackColor = true;
            this.chk_wbd_log.Click += new System.EventHandler(this.chk_wbd_log_Click);
            // 
            // chk_ML_Log
            // 
            this.chk_ML_Log.AutoSize = true;
            this.chk_ML_Log.Location = new System.Drawing.Point(6, 54);
            this.chk_ML_Log.Name = "chk_ML_Log";
            this.chk_ML_Log.Size = new System.Drawing.Size(125, 17);
            this.chk_ML_Log.TabIndex = 23;
            this.chk_ML_Log.TabStop = true;
            this.chk_ML_Log.Text = "WBD_Mahnlauf_Log";
            this.chk_ML_Log.UseVisualStyleBackColor = true;
            this.chk_ML_Log.Click += new System.EventHandler(this.chk_ML_Log_Click);
            // 
            // frm_Mahnlauf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 575);
            this.Controls.Add(this.grp_1);
            this.Controls.Add(this.grp_2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Mahnlauf";
            this.Text = "Offene Drucke";
            this.Activated += new System.EventHandler(this.frm_Mahnlauf_Activated);
            this.Load += new System.EventHandler(this.Mahnlauf_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Mahnlauf_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grp_2.ResumeLayout(false);
            this.grp_2.PerformLayout();
            this.grp_1.ResumeLayout(false);
            this.grp_1.PerformLayout();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Button cmd_ML;
        private System.Windows.Forms.Button cmd_Liste;
        private System.Windows.Forms.TextBox txt_RA;
        private System.Windows.Forms.TextBox txt_Uber;
        private System.Windows.Forms.TextBox txt_Tilg;
        private System.Windows.Forms.TextBox txt_M4;
        private System.Windows.Forms.TextBox txt_M3;
        private System.Windows.Forms.TextBox txt_M2;
        private System.Windows.Forms.TextBox txt_M1;
        private System.Windows.Forms.Button cmd_log;
        private System.Windows.Forms.GroupBox grp_2;
        private System.Windows.Forms.RadioButton chk_ML5;
        private System.Windows.Forms.RadioButton chk_ML4;
        private System.Windows.Forms.RadioButton chk_ML3;
        private System.Windows.Forms.RadioButton chk_ML2;
        private System.Windows.Forms.RadioButton chk_ML1;
        private System.Windows.Forms.GroupBox grp_1;
        private System.Windows.Forms.TextBox txt_offset;
        private System.Windows.Forms.RadioButton chk_wbd_log;
        private System.Windows.Forms.RadioButton chk_ML_Log;
        private System.Windows.Forms.ListView lst_info;
        private System.Windows.Forms.RadioButton chk_reset;
        private System.Windows.Forms.Button cmd_print;
    }
}
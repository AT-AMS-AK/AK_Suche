namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Antraege
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Antraege));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelHideBank = new System.Windows.Forms.Panel();
            this.txt_iban = new System.Windows.Forms.TextBox();
            this.txt_bic = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.txt_ktonr = new System.Windows.Forms.TextBox();
            this.txt_bank_ort = new System.Windows.Forms.TextBox();
            this.txt_bank = new System.Windows.Forms.TextBox();
            this.txt_blz = new System.Windows.Forms.TextBox();
            this.txt_ort = new System.Windows.Forms.TextBox();
            this.txt_plz = new System.Windows.Forms.TextBox();
            this.txt_strasse = new System.Windows.Forms.TextBox();
            this.txt_geschlecht = new System.Windows.Forms.TextBox();
            this.txt_vorname = new System.Windows.Forms.TextBox();
            this.txt_zuname = new System.Windows.Forms.TextBox();
            this.txt_svnr = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_Output = new System.Windows.Forms.ListView();
            this.label10 = new System.Windows.Forms.Label();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.cmd_std_bearbeitern = new System.Windows.Forms.Button();
            this.cmd_antrag_neu = new System.Windows.Forms.Button();
            this.cmd_antrag_bearbeiten = new System.Windows.Forms.Button();
            this.txt_personid = new System.Windows.Forms.TextBox();
            this.txt_PVS_ID = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelHideBank);
            this.groupBox1.Controls.Add(this.txt_iban);
            this.groupBox1.Controls.Add(this.txt_bic);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt_Output);
            this.groupBox1.Controls.Add(this.txt_ktonr);
            this.groupBox1.Controls.Add(this.txt_bank_ort);
            this.groupBox1.Controls.Add(this.txt_bank);
            this.groupBox1.Controls.Add(this.txt_blz);
            this.groupBox1.Controls.Add(this.txt_ort);
            this.groupBox1.Controls.Add(this.txt_plz);
            this.groupBox1.Controls.Add(this.txt_strasse);
            this.groupBox1.Controls.Add(this.txt_geschlecht);
            this.groupBox1.Controls.Add(this.txt_vorname);
            this.groupBox1.Controls.Add(this.txt_zuname);
            this.groupBox1.Controls.Add(this.txt_svnr);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(714, 204);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Antragsteller ";
            // 
            // panelHideBank
            // 
            this.panelHideBank.Location = new System.Drawing.Point(334, 30);
            this.panelHideBank.Name = "panelHideBank";
            this.panelHideBank.Size = new System.Drawing.Size(356, 111);
            this.panelHideBank.TabIndex = 42;
            // 
            // txt_iban
            // 
            this.txt_iban.Enabled = false;
            this.txt_iban.Location = new System.Drawing.Point(483, 147);
            this.txt_iban.Name = "txt_iban";
            this.txt_iban.Size = new System.Drawing.Size(207, 21);
            this.txt_iban.TabIndex = 17;
            this.txt_iban.TextChanged += new System.EventHandler(this.txt_iban_TextChanged);
            // 
            // txt_bic
            // 
            this.txt_bic.Enabled = false;
            this.txt_bic.Location = new System.Drawing.Point(483, 116);
            this.txt_bic.Name = "txt_bic";
            this.txt_bic.Size = new System.Drawing.Size(207, 21);
            this.txt_bic.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(367, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 14);
            this.label12.TabIndex = 15;
            this.label12.Text = "IBAN:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(367, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 14);
            this.label11.TabIndex = 14;
            this.label11.Text = "BIC:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(121, 14);
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(207, 21);
            this.txt_Output.TabIndex = 13;
            this.txt_Output.Visible = false;
            // 
            // txt_ktonr
            // 
            this.txt_ktonr.Enabled = false;
            this.txt_ktonr.Location = new System.Drawing.Point(483, 90);
            this.txt_ktonr.Name = "txt_ktonr";
            this.txt_ktonr.Size = new System.Drawing.Size(207, 21);
            this.txt_ktonr.TabIndex = 11;
            // 
            // txt_bank_ort
            // 
            this.txt_bank_ort.Enabled = false;
            this.txt_bank_ort.Location = new System.Drawing.Point(483, 60);
            this.txt_bank_ort.Name = "txt_bank_ort";
            this.txt_bank_ort.Size = new System.Drawing.Size(207, 21);
            this.txt_bank_ort.TabIndex = 10;
            // 
            // txt_bank
            // 
            this.txt_bank.Enabled = false;
            this.txt_bank.Location = new System.Drawing.Point(536, 36);
            this.txt_bank.Name = "txt_bank";
            this.txt_bank.Size = new System.Drawing.Size(154, 21);
            this.txt_bank.TabIndex = 8;
            // 
            // txt_blz
            // 
            this.txt_blz.Enabled = false;
            this.txt_blz.Location = new System.Drawing.Point(483, 36);
            this.txt_blz.Name = "txt_blz";
            this.txt_blz.Size = new System.Drawing.Size(46, 21);
            this.txt_blz.TabIndex = 7;
            // 
            // txt_ort
            // 
            this.txt_ort.Enabled = false;
            this.txt_ort.Location = new System.Drawing.Point(174, 172);
            this.txt_ort.Name = "txt_ort";
            this.txt_ort.Size = new System.Drawing.Size(154, 21);
            this.txt_ort.TabIndex = 5;
            // 
            // txt_plz
            // 
            this.txt_plz.Enabled = false;
            this.txt_plz.Location = new System.Drawing.Point(121, 172);
            this.txt_plz.Name = "txt_plz";
            this.txt_plz.Size = new System.Drawing.Size(46, 21);
            this.txt_plz.TabIndex = 4;
            // 
            // txt_strasse
            // 
            this.txt_strasse.Enabled = false;
            this.txt_strasse.Location = new System.Drawing.Point(121, 145);
            this.txt_strasse.Name = "txt_strasse";
            this.txt_strasse.Size = new System.Drawing.Size(207, 21);
            this.txt_strasse.TabIndex = 2;
            // 
            // txt_geschlecht
            // 
            this.txt_geschlecht.Enabled = false;
            this.txt_geschlecht.Location = new System.Drawing.Point(121, 116);
            this.txt_geschlecht.Name = "txt_geschlecht";
            this.txt_geschlecht.Size = new System.Drawing.Size(207, 21);
            this.txt_geschlecht.TabIndex = 9;
            // 
            // txt_vorname
            // 
            this.txt_vorname.Enabled = false;
            this.txt_vorname.Location = new System.Drawing.Point(121, 90);
            this.txt_vorname.Name = "txt_vorname";
            this.txt_vorname.Size = new System.Drawing.Size(207, 21);
            this.txt_vorname.TabIndex = 6;
            // 
            // txt_zuname
            // 
            this.txt_zuname.Enabled = false;
            this.txt_zuname.Location = new System.Drawing.Point(121, 64);
            this.txt_zuname.Name = "txt_zuname";
            this.txt_zuname.Size = new System.Drawing.Size(207, 21);
            this.txt_zuname.TabIndex = 3;
            // 
            // txt_svnr
            // 
            this.txt_svnr.Enabled = false;
            this.txt_svnr.Location = new System.Drawing.Point(121, 41);
            this.txt_svnr.Name = "txt_svnr";
            this.txt_svnr.Size = new System.Drawing.Size(207, 21);
            this.txt_svnr.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(343, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 14);
            this.label9.TabIndex = 8;
            this.label9.Text = "Kontonummer:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(346, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ort:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(334, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "BLZ/Bezeichnung:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "PLZ / Ort:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Anschrift:Nr.:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Geschlecht:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vorname:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zuname:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Soz.Vers.-Nr.:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lst_Output
            // 
            this.lst_Output.Location = new System.Drawing.Point(12, 259);
            this.lst_Output.MultiSelect = false;
            this.lst_Output.Name = "lst_Output";
            this.lst_Output.Size = new System.Drawing.Size(714, 266);
            this.lst_Output.TabIndex = 12;
            this.lst_Output.UseCompatibleStateImageBehavior = false;
            this.lst_Output.Click += new System.EventHandler(this.lst_Output_Click);
            this.lst_Output.DoubleClick += new System.EventHandler(this.cmd_antrag_bearbeiten_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 24);
            this.label10.TabIndex = 3;
            this.label10.Text = "Anträge";
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(609, 531);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(117, 23);
            this.cmd_schliessen.TabIndex = 16;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_std_bearbeitern
            // 
            this.cmd_std_bearbeitern.Location = new System.Drawing.Point(413, 531);
            this.cmd_std_bearbeitern.Name = "cmd_std_bearbeitern";
            this.cmd_std_bearbeitern.Size = new System.Drawing.Size(190, 23);
            this.cmd_std_bearbeitern.TabIndex = 15;
            this.cmd_std_bearbeitern.Text = "S&tammdaten bearbeiten";
            this.cmd_std_bearbeitern.UseVisualStyleBackColor = true;
            this.cmd_std_bearbeitern.Click += new System.EventHandler(this.cmd_std_bearbeiten_Click);
            // 
            // cmd_antrag_neu
            // 
            this.cmd_antrag_neu.Location = new System.Drawing.Point(217, 531);
            this.cmd_antrag_neu.Name = "cmd_antrag_neu";
            this.cmd_antrag_neu.Size = new System.Drawing.Size(190, 23);
            this.cmd_antrag_neu.TabIndex = 14;
            this.cmd_antrag_neu.Text = "Antrag &neu anlegen";
            this.cmd_antrag_neu.UseVisualStyleBackColor = true;
            this.cmd_antrag_neu.Click += new System.EventHandler(this.cmd_antrag_neu_Click);
            // 
            // cmd_antrag_bearbeiten
            // 
            this.cmd_antrag_bearbeiten.Location = new System.Drawing.Point(16, 531);
            this.cmd_antrag_bearbeiten.Name = "cmd_antrag_bearbeiten";
            this.cmd_antrag_bearbeiten.Size = new System.Drawing.Size(190, 23);
            this.cmd_antrag_bearbeiten.TabIndex = 13;
            this.cmd_antrag_bearbeiten.Text = "Antrag &bearbeiten";
            this.cmd_antrag_bearbeiten.UseVisualStyleBackColor = true;
            this.cmd_antrag_bearbeiten.Click += new System.EventHandler(this.cmd_antrag_bearbeiten_Click);
            // 
            // txt_personid
            // 
            this.txt_personid.Location = new System.Drawing.Point(475, 0);
            this.txt_personid.Name = "txt_personid";
            this.txt_personid.Size = new System.Drawing.Size(205, 20);
            this.txt_personid.TabIndex = 12;
            this.txt_personid.Visible = false;
            // 
            // txt_PVS_ID
            // 
            this.txt_PVS_ID.Location = new System.Drawing.Point(133, 0);
            this.txt_PVS_ID.Name = "txt_PVS_ID";
            this.txt_PVS_ID.Size = new System.Drawing.Size(304, 20);
            this.txt_PVS_ID.TabIndex = 17;
            this.txt_PVS_ID.Visible = false;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 567);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(736, 24);
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
            this.labelDayDate.Name = "labelDayDate";
            this.labelDayDate.Size = new System.Drawing.Size(0, 19);
            // 
            // frm_Antraege
            // 
            this.AcceptButton = this.cmd_antrag_bearbeiten;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 591);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txt_personid);
            this.Controls.Add(this.txt_PVS_ID);
            this.Controls.Add(this.cmd_antrag_bearbeiten);
            this.Controls.Add(this.cmd_antrag_neu);
            this.Controls.Add(this.cmd_std_bearbeitern);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lst_Output);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Antraege";
            this.Text = "Information zum Antrag";
            this.Activated += new System.EventHandler(this.frm_Antraege_Activated);
            this.Load += new System.EventHandler(this.frm_Antraege_Load);
            this.Enter += new System.EventHandler(this.frm_Antraege_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Antraege_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ktonr;
        private System.Windows.Forms.TextBox txt_bank_ort;
        private System.Windows.Forms.TextBox txt_bank;
        private System.Windows.Forms.TextBox txt_blz;
        private System.Windows.Forms.TextBox txt_ort;
        private System.Windows.Forms.TextBox txt_plz;
        private System.Windows.Forms.TextBox txt_strasse;
        private System.Windows.Forms.TextBox txt_geschlecht;
        private System.Windows.Forms.TextBox txt_vorname;
        private System.Windows.Forms.TextBox txt_zuname;
        private System.Windows.Forms.TextBox txt_svnr;
        private System.Windows.Forms.ListView lst_Output;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Button cmd_std_bearbeitern;
        private System.Windows.Forms.Button cmd_antrag_neu;
        private System.Windows.Forms.Button cmd_antrag_bearbeiten;
        private System.Windows.Forms.TextBox txt_personid;
        private System.Windows.Forms.TextBox txt_PVS_ID;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.TextBox txt_iban;
        private System.Windows.Forms.TextBox txt_bic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelHideBank;



    }
}
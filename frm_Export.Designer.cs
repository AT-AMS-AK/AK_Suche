namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Export));
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_pfad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_konto = new System.Windows.Forms.GroupBox();
            this.chk_kegal = new System.Windows.Forms.RadioButton();
            this.chk_knein = new System.Windows.Forms.RadioButton();
            this.chk_kja = new System.Windows.Forms.RadioButton();
            this.gb_Trennzeichen = new System.Windows.Forms.GroupBox();
            this.chk_kanal = new System.Windows.Forms.RadioButton();
            this.chk_sp = new System.Windows.Forms.RadioButton();
            this.chk_tab = new System.Windows.Forms.RadioButton();
            this.gb_Einschrank = new System.Windows.Forms.GroupBox();
            this.mtxt_rueck = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_auszahl = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_eingang = new System.Windows.Forms.MaskedTextBox();
            this.chk_rueck = new System.Windows.Forms.RadioButton();
            this.chk_auszahl = new System.Windows.Forms.RadioButton();
            this.chk_eingang = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cob_status = new System.Windows.Forms.ComboBox();
            this.gb_geklagt = new System.Windows.Forms.GroupBox();
            this.chk_Beide = new System.Windows.Forms.RadioButton();
            this.chk_Nein = new System.Windows.Forms.RadioButton();
            this.chk_ja = new System.Windows.Forms.RadioButton();
            this.cmd_export = new System.Windows.Forms.Button();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.cmd_log = new System.Windows.Forms.Button();
            this.grp_1 = new System.Windows.Forms.GroupBox();
            this.cmd_print = new System.Windows.Forms.Button();
            this.txt_offset = new System.Windows.Forms.TextBox();
            this.chk_wbd_log = new System.Windows.Forms.RadioButton();
            this.chk_EXP_Log = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_konto.SuspendLayout();
            this.gb_Trennzeichen.SuspendLayout();
            this.gb_Einschrank.SuspendLayout();
            this.gb_geklagt.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(619, 24);
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
            this.lblCON.Size = new System.Drawing.Size(39, 19);
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
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_pfad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gb_konto);
            this.groupBox1.Controls.Add(this.gb_Trennzeichen);
            this.groupBox1.Controls.Add(this.gb_Einschrank);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 430);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export Files";
            // 
            // lst_info
            // 
            this.lst_info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_info.Location = new System.Drawing.Point(6, 29);
            this.lst_info.Name = "lst_info";
            this.lst_info.Size = new System.Drawing.Size(583, 401);
            this.lst_info.TabIndex = 47;
            this.lst_info.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(418, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Export.log";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(418, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "WBD_EXP_BUCH.dat";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(418, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "WBD_EXP_STD.dat";
            // 
            // txt_pfad
            // 
            this.txt_pfad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_pfad.Location = new System.Drawing.Point(16, 53);
            this.txt_pfad.Name = "txt_pfad";
            this.txt_pfad.Size = new System.Drawing.Size(387, 21);
            this.txt_pfad.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Verzeichnis für Export";
            this.label2.UseMnemonic = false;
            // 
            // gb_konto
            // 
            this.gb_konto.Controls.Add(this.chk_kegal);
            this.gb_konto.Controls.Add(this.chk_knein);
            this.gb_konto.Controls.Add(this.chk_kja);
            this.gb_konto.Location = new System.Drawing.Point(366, 267);
            this.gb_konto.Name = "gb_konto";
            this.gb_konto.Size = new System.Drawing.Size(200, 144);
            this.gb_konto.TabIndex = 2;
            this.gb_konto.TabStop = false;
            this.gb_konto.Text = "Konto ausgeglichen";
            // 
            // chk_kegal
            // 
            this.chk_kegal.AutoSize = true;
            this.chk_kegal.Location = new System.Drawing.Point(25, 102);
            this.chk_kegal.Name = "chk_kegal";
            this.chk_kegal.Size = new System.Drawing.Size(46, 17);
            this.chk_kegal.TabIndex = 5;
            this.chk_kegal.TabStop = true;
            this.chk_kegal.Text = "Egal";
            this.chk_kegal.UseVisualStyleBackColor = true;
            this.chk_kegal.Enter += new System.EventHandler(this.chk_kegal_Enter);
            this.chk_kegal.Leave += new System.EventHandler(this.chk_kegal_Leave);
            // 
            // chk_knein
            // 
            this.chk_knein.AutoSize = true;
            this.chk_knein.Location = new System.Drawing.Point(25, 67);
            this.chk_knein.Name = "chk_knein";
            this.chk_knein.Size = new System.Drawing.Size(47, 17);
            this.chk_knein.TabIndex = 4;
            this.chk_knein.TabStop = true;
            this.chk_knein.Text = "Nein";
            this.chk_knein.UseVisualStyleBackColor = true;
            this.chk_knein.Enter += new System.EventHandler(this.chk_knein_Enter);
            this.chk_knein.Leave += new System.EventHandler(this.chk_knein_Leave);
            // 
            // chk_kja
            // 
            this.chk_kja.AutoSize = true;
            this.chk_kja.Location = new System.Drawing.Point(25, 32);
            this.chk_kja.Name = "chk_kja";
            this.chk_kja.Size = new System.Drawing.Size(36, 17);
            this.chk_kja.TabIndex = 3;
            this.chk_kja.TabStop = true;
            this.chk_kja.Text = "Ja";
            this.chk_kja.UseVisualStyleBackColor = true;
            this.chk_kja.Enter += new System.EventHandler(this.chk_kja_Enter);
            this.chk_kja.Leave += new System.EventHandler(this.chk_kja_Leave);
            // 
            // gb_Trennzeichen
            // 
            this.gb_Trennzeichen.Controls.Add(this.chk_kanal);
            this.gb_Trennzeichen.Controls.Add(this.chk_sp);
            this.gb_Trennzeichen.Controls.Add(this.chk_tab);
            this.gb_Trennzeichen.Location = new System.Drawing.Point(367, 109);
            this.gb_Trennzeichen.Name = "gb_Trennzeichen";
            this.gb_Trennzeichen.Size = new System.Drawing.Size(200, 121);
            this.gb_Trennzeichen.TabIndex = 1;
            this.gb_Trennzeichen.TabStop = false;
            this.gb_Trennzeichen.Text = "Trennzeichen";
            // 
            // chk_kanal
            // 
            this.chk_kanal.AutoSize = true;
            this.chk_kanal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_kanal.Location = new System.Drawing.Point(24, 89);
            this.chk_kanal.Name = "chk_kanal";
            this.chk_kanal.Size = new System.Drawing.Size(33, 20);
            this.chk_kanal.TabIndex = 2;
            this.chk_kanal.TabStop = true;
            this.chk_kanal.Text = "#";
            this.chk_kanal.UseVisualStyleBackColor = true;
            this.chk_kanal.Enter += new System.EventHandler(this.chk_kanal_Enter);
            this.chk_kanal.Leave += new System.EventHandler(this.chk_kanal_Leave);
            // 
            // chk_sp
            // 
            this.chk_sp.AutoSize = true;
            this.chk_sp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_sp.Location = new System.Drawing.Point(24, 54);
            this.chk_sp.Name = "chk_sp";
            this.chk_sp.Size = new System.Drawing.Size(29, 20);
            this.chk_sp.TabIndex = 1;
            this.chk_sp.TabStop = true;
            this.chk_sp.Text = ";";
            this.chk_sp.UseVisualStyleBackColor = true;
            this.chk_sp.Enter += new System.EventHandler(this.chk_sp_Enter);
            this.chk_sp.Leave += new System.EventHandler(this.chk_sp_Leave);
            // 
            // chk_tab
            // 
            this.chk_tab.AutoSize = true;
            this.chk_tab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_tab.Location = new System.Drawing.Point(24, 19);
            this.chk_tab.Name = "chk_tab";
            this.chk_tab.Size = new System.Drawing.Size(84, 20);
            this.chk_tab.TabIndex = 0;
            this.chk_tab.TabStop = true;
            this.chk_tab.Text = "Tabulator";
            this.chk_tab.UseVisualStyleBackColor = true;
            this.chk_tab.Enter += new System.EventHandler(this.chk_tab_Enter);
            this.chk_tab.Leave += new System.EventHandler(this.chk_tab_Leave);
            // 
            // gb_Einschrank
            // 
            this.gb_Einschrank.Controls.Add(this.mtxt_rueck);
            this.gb_Einschrank.Controls.Add(this.mtxt_auszahl);
            this.gb_Einschrank.Controls.Add(this.mtxt_eingang);
            this.gb_Einschrank.Controls.Add(this.chk_rueck);
            this.gb_Einschrank.Controls.Add(this.chk_auszahl);
            this.gb_Einschrank.Controls.Add(this.chk_eingang);
            this.gb_Einschrank.Controls.Add(this.label1);
            this.gb_Einschrank.Controls.Add(this.cob_status);
            this.gb_Einschrank.Controls.Add(this.gb_geklagt);
            this.gb_Einschrank.Location = new System.Drawing.Point(16, 109);
            this.gb_Einschrank.Name = "gb_Einschrank";
            this.gb_Einschrank.Size = new System.Drawing.Size(307, 302);
            this.gb_Einschrank.TabIndex = 0;
            this.gb_Einschrank.TabStop = false;
            this.gb_Einschrank.Text = "Einschränkungskriterien";
            // 
            // mtxt_rueck
            // 
            this.mtxt_rueck.Location = new System.Drawing.Point(210, 179);
            this.mtxt_rueck.Mask = "__.__.____";
            this.mtxt_rueck.Name = "mtxt_rueck";
            this.mtxt_rueck.Size = new System.Drawing.Size(80, 20);
            this.mtxt_rueck.TabIndex = 11;
            this.mtxt_rueck.Enter += new System.EventHandler(this.mtxt_rueck_Enter);
            this.mtxt_rueck.Leave += new System.EventHandler(this.mtxt_rueck_Leave);
            // 
            // mtxt_auszahl
            // 
            this.mtxt_auszahl.Location = new System.Drawing.Point(210, 140);
            this.mtxt_auszahl.Mask = "__.__.____";
            this.mtxt_auszahl.Name = "mtxt_auszahl";
            this.mtxt_auszahl.Size = new System.Drawing.Size(80, 20);
            this.mtxt_auszahl.TabIndex = 10;
            this.mtxt_auszahl.Enter += new System.EventHandler(this.mtxt_auszahl_Enter);
            this.mtxt_auszahl.Leave += new System.EventHandler(this.mtxt_auszahl_Leave);
            // 
            // mtxt_eingang
            // 
            this.mtxt_eingang.Location = new System.Drawing.Point(210, 100);
            this.mtxt_eingang.Mask = "__.__.____";
            this.mtxt_eingang.Name = "mtxt_eingang";
            this.mtxt_eingang.Size = new System.Drawing.Size(80, 20);
            this.mtxt_eingang.TabIndex = 9;
            this.mtxt_eingang.Click += new System.EventHandler(this.chk_eingang_Click);
            this.mtxt_eingang.Enter += new System.EventHandler(this.mtxt_eingang_Enter);
            this.mtxt_eingang.Leave += new System.EventHandler(this.mtxt_eingang_Leave);
            // 
            // chk_rueck
            // 
            this.chk_rueck.AutoSize = true;
            this.chk_rueck.Location = new System.Drawing.Point(33, 180);
            this.chk_rueck.Name = "chk_rueck";
            this.chk_rueck.Size = new System.Drawing.Size(88, 17);
            this.chk_rueck.TabIndex = 5;
            this.chk_rueck.TabStop = true;
            this.chk_rueck.Text = "Rückzahlung";
            this.chk_rueck.UseVisualStyleBackColor = true;
            this.chk_rueck.Click += new System.EventHandler(this.chk_rueck_Click);
            this.chk_rueck.Enter += new System.EventHandler(this.chk_rueck_Enter);
            // 
            // chk_auszahl
            // 
            this.chk_auszahl.AutoSize = true;
            this.chk_auszahl.Location = new System.Drawing.Point(33, 141);
            this.chk_auszahl.Name = "chk_auszahl";
            this.chk_auszahl.Size = new System.Drawing.Size(114, 17);
            this.chk_auszahl.TabIndex = 4;
            this.chk_auszahl.TabStop = true;
            this.chk_auszahl.Text = "Auszahlungsdatum";
            this.chk_auszahl.UseVisualStyleBackColor = true;
            this.chk_auszahl.Click += new System.EventHandler(this.chk_auszahl_Click);
            this.chk_auszahl.Enter += new System.EventHandler(this.chk_auszahl_Enter);
            // 
            // chk_eingang
            // 
            this.chk_eingang.AutoSize = true;
            this.chk_eingang.Location = new System.Drawing.Point(34, 101);
            this.chk_eingang.Name = "chk_eingang";
            this.chk_eingang.Size = new System.Drawing.Size(98, 17);
            this.chk_eingang.TabIndex = 3;
            this.chk_eingang.TabStop = true;
            this.chk_eingang.Text = "Eingangsdatum";
            this.chk_eingang.UseVisualStyleBackColor = true;
            this.chk_eingang.Enter += new System.EventHandler(this.chk_eingang_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status";
            // 
            // cob_status
            // 
            this.cob_status.FormattingEnabled = true;
            this.cob_status.Location = new System.Drawing.Point(133, 37);
            this.cob_status.Name = "cob_status";
            this.cob_status.Size = new System.Drawing.Size(157, 21);
            this.cob_status.TabIndex = 1;
            this.cob_status.SelectedIndexChanged += new System.EventHandler(this.cob_status_SelectedIndexChanged);
            this.cob_status.Enter += new System.EventHandler(this.cob_status_Enter);
            this.cob_status.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cob_status_KeyUp);
            this.cob_status.Leave += new System.EventHandler(this.cob_status_Leave);
            // 
            // gb_geklagt
            // 
            this.gb_geklagt.Controls.Add(this.chk_Beide);
            this.gb_geklagt.Controls.Add(this.chk_Nein);
            this.gb_geklagt.Controls.Add(this.chk_ja);
            this.gb_geklagt.Location = new System.Drawing.Point(6, 228);
            this.gb_geklagt.Name = "gb_geklagt";
            this.gb_geklagt.Size = new System.Drawing.Size(295, 68);
            this.gb_geklagt.TabIndex = 0;
            this.gb_geklagt.TabStop = false;
            this.gb_geklagt.Text = "Geklagte";
            // 
            // chk_Beide
            // 
            this.chk_Beide.AutoSize = true;
            this.chk_Beide.Location = new System.Drawing.Point(200, 28);
            this.chk_Beide.Name = "chk_Beide";
            this.chk_Beide.Size = new System.Drawing.Size(52, 17);
            this.chk_Beide.TabIndex = 2;
            this.chk_Beide.TabStop = true;
            this.chk_Beide.Text = "Beide";
            this.chk_Beide.UseVisualStyleBackColor = true;
            this.chk_Beide.Enter += new System.EventHandler(this.chk_Beide_Enter);
            this.chk_Beide.Leave += new System.EventHandler(this.chk_Beide_Leave);
            // 
            // chk_Nein
            // 
            this.chk_Nein.AutoSize = true;
            this.chk_Nein.Location = new System.Drawing.Point(107, 28);
            this.chk_Nein.Name = "chk_Nein";
            this.chk_Nein.Size = new System.Drawing.Size(47, 17);
            this.chk_Nein.TabIndex = 1;
            this.chk_Nein.TabStop = true;
            this.chk_Nein.Text = "Nein";
            this.chk_Nein.UseVisualStyleBackColor = true;
            this.chk_Nein.Enter += new System.EventHandler(this.chk_Nein_Enter);
            this.chk_Nein.Leave += new System.EventHandler(this.chk_Nein_Leave);
            // 
            // chk_ja
            // 
            this.chk_ja.AutoSize = true;
            this.chk_ja.Location = new System.Drawing.Point(27, 28);
            this.chk_ja.Name = "chk_ja";
            this.chk_ja.Size = new System.Drawing.Size(36, 17);
            this.chk_ja.TabIndex = 0;
            this.chk_ja.TabStop = true;
            this.chk_ja.Text = "Ja";
            this.chk_ja.UseVisualStyleBackColor = true;
            this.chk_ja.Enter += new System.EventHandler(this.chk_ja_Enter);
            this.chk_ja.Leave += new System.EventHandler(this.chk_ja_Leave);
            // 
            // cmd_export
            // 
            this.cmd_export.Location = new System.Drawing.Point(442, 465);
            this.cmd_export.Name = "cmd_export";
            this.cmd_export.Size = new System.Drawing.Size(84, 23);
            this.cmd_export.TabIndex = 43;
            this.cmd_export.Text = "&Exportieren";
            this.cmd_export.UseVisualStyleBackColor = true;
            this.cmd_export.Click += new System.EventHandler(this.cmd_export_Click);
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(532, 465);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliessen.TabIndex = 44;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_log
            // 
            this.cmd_log.Location = new System.Drawing.Point(12, 465);
            this.cmd_log.Name = "cmd_log";
            this.cmd_log.Size = new System.Drawing.Size(75, 23);
            this.cmd_log.TabIndex = 45;
            this.cmd_log.Text = "&Log";
            this.cmd_log.UseVisualStyleBackColor = true;
            this.cmd_log.Click += new System.EventHandler(this.cmd_log_Click);
            // 
            // grp_1
            // 
            this.grp_1.Controls.Add(this.cmd_print);
            this.grp_1.Controls.Add(this.txt_offset);
            this.grp_1.Controls.Add(this.chk_wbd_log);
            this.grp_1.Controls.Add(this.chk_EXP_Log);
            this.grp_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_1.Location = new System.Drawing.Point(93, 448);
            this.grp_1.Name = "grp_1";
            this.grp_1.Size = new System.Drawing.Size(342, 68);
            this.grp_1.TabIndex = 46;
            this.grp_1.TabStop = false;
            // 
            // cmd_print
            // 
            this.cmd_print.Location = new System.Drawing.Point(243, 22);
            this.cmd_print.Name = "cmd_print";
            this.cmd_print.Size = new System.Drawing.Size(87, 27);
            this.cmd_print.TabIndex = 29;
            this.cmd_print.Text = "&Print";
            this.cmd_print.UseVisualStyleBackColor = true;
            this.cmd_print.Click += new System.EventHandler(this.cmd_print_Click);
            // 
            // txt_offset
            // 
            this.txt_offset.Location = new System.Drawing.Point(146, 12);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(47, 20);
            this.txt_offset.TabIndex = 24;
            // 
            // chk_wbd_log
            // 
            this.chk_wbd_log.AutoSize = true;
            this.chk_wbd_log.Location = new System.Drawing.Point(12, 15);
            this.chk_wbd_log.Name = "chk_wbd_log";
            this.chk_wbd_log.Size = new System.Drawing.Size(75, 17);
            this.chk_wbd_log.TabIndex = 22;
            this.chk_wbd_log.TabStop = true;
            this.chk_wbd_log.Text = "WBD_Log";
            this.chk_wbd_log.UseVisualStyleBackColor = true;
            this.chk_wbd_log.Click += new System.EventHandler(this.chk_wbd_log_Click);
            // 
            // chk_EXP_Log
            // 
            this.chk_EXP_Log.AutoSize = true;
            this.chk_EXP_Log.Location = new System.Drawing.Point(12, 42);
            this.chk_EXP_Log.Name = "chk_EXP_Log";
            this.chk_EXP_Log.Size = new System.Drawing.Size(111, 17);
            this.chk_EXP_Log.TabIndex = 23;
            this.chk_EXP_Log.TabStop = true;
            this.chk_EXP_Log.Text = "WBD_Export_Log";
            this.chk_EXP_Log.UseVisualStyleBackColor = true;
            this.chk_EXP_Log.Click += new System.EventHandler(this.chk_EX_Log_Click);
            // 
            // frm_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 547);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grp_1);
            this.Controls.Add(this.cmd_log);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.cmd_export);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Export";
            this.Text = "Export Files";
            this.Activated += new System.EventHandler(this.frm_Export_Activated);
            this.Load += new System.EventHandler(this.frm_Export_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Export_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_konto.ResumeLayout(false);
            this.gb_konto.PerformLayout();
            this.gb_Trennzeichen.ResumeLayout(false);
            this.gb_Trennzeichen.PerformLayout();
            this.gb_Einschrank.ResumeLayout(false);
            this.gb_Einschrank.PerformLayout();
            this.gb_geklagt.ResumeLayout(false);
            this.gb_geklagt.PerformLayout();
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
        private System.Windows.Forms.GroupBox gb_Einschrank;
        private System.Windows.Forms.Button cmd_export;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.GroupBox gb_geklagt;
        private System.Windows.Forms.RadioButton chk_Beide;
        private System.Windows.Forms.RadioButton chk_Nein;
        private System.Windows.Forms.RadioButton chk_ja;
        private System.Windows.Forms.RadioButton chk_rueck;
        private System.Windows.Forms.RadioButton chk_auszahl;
        private System.Windows.Forms.RadioButton chk_eingang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cob_status;
        private System.Windows.Forms.GroupBox gb_konto;
        private System.Windows.Forms.RadioButton chk_kegal;
        private System.Windows.Forms.RadioButton chk_knein;
        private System.Windows.Forms.RadioButton chk_kja;
        private System.Windows.Forms.GroupBox gb_Trennzeichen;
        private System.Windows.Forms.RadioButton chk_kanal;
        private System.Windows.Forms.RadioButton chk_sp;
        private System.Windows.Forms.RadioButton chk_tab;
        private System.Windows.Forms.MaskedTextBox mtxt_rueck;
        private System.Windows.Forms.MaskedTextBox mtxt_auszahl;
        private System.Windows.Forms.MaskedTextBox mtxt_eingang;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_pfad;
        private System.Windows.Forms.Button cmd_log;
        private System.Windows.Forms.GroupBox grp_1;
        private System.Windows.Forms.Button cmd_print;
        private System.Windows.Forms.TextBox txt_offset;
        private System.Windows.Forms.RadioButton chk_wbd_log;
        private System.Windows.Forms.RadioButton chk_EXP_Log;
        private System.Windows.Forms.ListView lst_info;
    }
}
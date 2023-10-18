namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Auswertung
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_gbv = new System.Windows.Forms.ComboBox();
            this.lbl_gbv = new System.Windows.Forms.Label();
            this.chk_100 = new System.Windows.Forms.RadioButton();
            this.chk_50 = new System.Windows.Forms.RadioButton();
            this.dgv_vorlage = new System.Windows.Forms.DataGridView();
            this.lbl_bis = new System.Windows.Forms.Label();
            this.lbl_von = new System.Windows.Forms.Label();
            this.cbo_tag_b = new System.Windows.Forms.ComboBox();
            this.cbo_mon_b = new System.Windows.Forms.ComboBox();
            this.cbo_jahr_b = new System.Windows.Forms.ComboBox();
            this.cbo_jahr_v = new System.Windows.Forms.ComboBox();
            this.cbo_mon_v = new System.Windows.Forms.ComboBox();
            this.cbo_tag_v = new System.Windows.Forms.ComboBox();
            this.lbl_jahr = new System.Windows.Forms.Label();
            this.lbl_mon = new System.Windows.Forms.Label();
            this.lbl_tag = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_vorlage = new System.Windows.Forms.ComboBox();
            this.cbo_bezirksstelle = new System.Windows.Forms.ComboBox();
            this.cbo_Bereich = new System.Windows.Forms.ComboBox();
            this.cmd_start = new System.Windows.Forms.Button();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cmd_Log = new System.Windows.Forms.Button();
            this.lst_info_aw = new System.Windows.Forms.ListView();
            this.grp_1 = new System.Windows.Forms.GroupBox();
            this.cmd_print = new System.Windows.Forms.Button();
            this.txt_offset = new System.Windows.Forms.TextBox();
            this.chk_wbd_log = new System.Windows.Forms.RadioButton();
            this.chk_CR_Log = new System.Windows.Forms.RadioButton();
            this.txt_out = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vorlage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.grp_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_gbv);
            this.groupBox1.Controls.Add(this.lbl_gbv);
            this.groupBox1.Controls.Add(this.chk_100);
            this.groupBox1.Controls.Add(this.chk_50);
            this.groupBox1.Controls.Add(this.dgv_vorlage);
            this.groupBox1.Controls.Add(this.lbl_bis);
            this.groupBox1.Controls.Add(this.lbl_von);
            this.groupBox1.Controls.Add(this.cbo_tag_b);
            this.groupBox1.Controls.Add(this.cbo_mon_b);
            this.groupBox1.Controls.Add(this.cbo_jahr_b);
            this.groupBox1.Controls.Add(this.cbo_jahr_v);
            this.groupBox1.Controls.Add(this.cbo_mon_v);
            this.groupBox1.Controls.Add(this.cbo_tag_v);
            this.groupBox1.Controls.Add(this.lbl_jahr);
            this.groupBox1.Controls.Add(this.lbl_mon);
            this.groupBox1.Controls.Add(this.lbl_tag);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_vorlage);
            this.groupBox1.Controls.Add(this.cbo_bezirksstelle);
            this.groupBox1.Controls.Add(this.cbo_Bereich);
            this.groupBox1.Location = new System.Drawing.Point(14, 597);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1086, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AK Auswertungen";
            // 
            // cb_gbv
            // 
            this.cb_gbv.FormattingEnabled = true;
            this.cb_gbv.Items.AddRange(new object[] {
            "ISA",
            "AKV",
            "RA",
            "Sonstige",
            "Alle"});
            this.cb_gbv.Location = new System.Drawing.Point(538, 66);
            this.cb_gbv.Name = "cb_gbv";
            this.cb_gbv.Size = new System.Drawing.Size(100, 23);
            this.cb_gbv.TabIndex = 74;
            this.cb_gbv.SelectedIndexChanged += new System.EventHandler(this.cb_gbv_SelectedIndexChanged);
            this.cb_gbv.Enter += new System.EventHandler(this.cb_gbv_Enter);
            this.cb_gbv.Leave += new System.EventHandler(this.cb_gbv_Leave);
            // 
            // lbl_gbv
            // 
            this.lbl_gbv.AutoSize = true;
            this.lbl_gbv.Location = new System.Drawing.Point(395, 69);
            this.lbl_gbv.Name = "lbl_gbv";
            this.lbl_gbv.Size = new System.Drawing.Size(137, 16);
            this.lbl_gbv.TabIndex = 73;
            this.lbl_gbv.Text = "Gläubigervertreter       ";
            // 
            // chk_100
            // 
            this.chk_100.AutoSize = true;
            this.chk_100.Location = new System.Drawing.Point(655, 66);
            this.chk_100.Name = "chk_100";
            this.chk_100.Size = new System.Drawing.Size(97, 20);
            this.chk_100.TabIndex = 72;
            this.chk_100.TabStop = true;
            this.chk_100.Text = "100% Zoom";
            this.chk_100.UseVisualStyleBackColor = true;
            this.chk_100.CheckedChanged += new System.EventHandler(this.chk_100_CheckedChanged);
            // 
            // chk_50
            // 
            this.chk_50.AutoSize = true;
            this.chk_50.Location = new System.Drawing.Point(655, 39);
            this.chk_50.Name = "chk_50";
            this.chk_50.Size = new System.Drawing.Size(90, 20);
            this.chk_50.TabIndex = 71;
            this.chk_50.TabStop = true;
            this.chk_50.Text = "50% Zoom";
            this.chk_50.UseVisualStyleBackColor = true;
            this.chk_50.CheckedChanged += new System.EventHandler(this.chk_50_CheckedChanged);
            // 
            // dgv_vorlage
            // 
            this.dgv_vorlage.AllowUserToAddRows = false;
            this.dgv_vorlage.AllowUserToDeleteRows = false;
            this.dgv_vorlage.Location = new System.Drawing.Point(112, 43);
            this.dgv_vorlage.MaximumSize = new System.Drawing.Size(583, 577);
            this.dgv_vorlage.Name = "dgv_vorlage";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_vorlage.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_vorlage.ShowCellErrors = false;
            this.dgv_vorlage.ShowCellToolTips = false;
            this.dgv_vorlage.ShowEditingIcon = false;
            this.dgv_vorlage.ShowRowErrors = false;
            this.dgv_vorlage.Size = new System.Drawing.Size(226, 37);
            this.dgv_vorlage.TabIndex = 70;
            this.dgv_vorlage.Visible = false;
            // 
            // lbl_bis
            // 
            this.lbl_bis.Location = new System.Drawing.Point(768, 69);
            this.lbl_bis.Name = "lbl_bis";
            this.lbl_bis.Size = new System.Drawing.Size(44, 16);
            this.lbl_bis.TabIndex = 20;
            this.lbl_bis.Text = "Bis";
            // 
            // lbl_von
            // 
            this.lbl_von.Location = new System.Drawing.Point(765, 40);
            this.lbl_von.Name = "lbl_von";
            this.lbl_von.Size = new System.Drawing.Size(47, 16);
            this.lbl_von.TabIndex = 19;
            this.lbl_von.Text = "Von";
            // 
            // cbo_tag_b
            // 
            this.cbo_tag_b.FormattingEnabled = true;
            this.cbo_tag_b.Location = new System.Drawing.Point(1012, 68);
            this.cbo_tag_b.Name = "cbo_tag_b";
            this.cbo_tag_b.Size = new System.Drawing.Size(47, 23);
            this.cbo_tag_b.TabIndex = 18;
            this.cbo_tag_b.SelectedIndexChanged += new System.EventHandler(this.cbo_tag_b_SelectedIndexChanged);
            this.cbo_tag_b.Enter += new System.EventHandler(this.cbo_tag_b_Enter);
            this.cbo_tag_b.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_tag_b_KeyUp);
            this.cbo_tag_b.Leave += new System.EventHandler(this.cbo_tag_b_Leave);
            // 
            // cbo_mon_b
            // 
            this.cbo_mon_b.FormattingEnabled = true;
            this.cbo_mon_b.Location = new System.Drawing.Point(923, 68);
            this.cbo_mon_b.Name = "cbo_mon_b";
            this.cbo_mon_b.Size = new System.Drawing.Size(60, 23);
            this.cbo_mon_b.TabIndex = 17;
            this.cbo_mon_b.SelectedIndexChanged += new System.EventHandler(this.cbo_mon_b_SelectedIndexChanged);
            this.cbo_mon_b.Enter += new System.EventHandler(this.cbo_mon_b_Enter);
            this.cbo_mon_b.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_mon_b_KeyUp);
            this.cbo_mon_b.Leave += new System.EventHandler(this.cbo_mon_b_Leave);
            // 
            // cbo_jahr_b
            // 
            this.cbo_jahr_b.FormattingEnabled = true;
            this.cbo_jahr_b.Location = new System.Drawing.Point(815, 68);
            this.cbo_jahr_b.Name = "cbo_jahr_b";
            this.cbo_jahr_b.Size = new System.Drawing.Size(79, 23);
            this.cbo_jahr_b.TabIndex = 16;
            this.cbo_jahr_b.SelectedIndexChanged += new System.EventHandler(this.cbo_jahr_b_SelectedIndexChanged);
            this.cbo_jahr_b.Enter += new System.EventHandler(this.cbo_jahr_b_Enter);
            this.cbo_jahr_b.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_jahr_b_KeyUp);
            this.cbo_jahr_b.Leave += new System.EventHandler(this.cbo_jahr_b_Leave);
            // 
            // cbo_jahr_v
            // 
            this.cbo_jahr_v.FormattingEnabled = true;
            this.cbo_jahr_v.Location = new System.Drawing.Point(816, 36);
            this.cbo_jahr_v.Name = "cbo_jahr_v";
            this.cbo_jahr_v.Size = new System.Drawing.Size(79, 23);
            this.cbo_jahr_v.TabIndex = 13;
            this.cbo_jahr_v.SelectedIndexChanged += new System.EventHandler(this.cbo_jahr_v_SelectedIndexChanged);
            this.cbo_jahr_v.Enter += new System.EventHandler(this.cbo_jahr_v_Enter);
            this.cbo_jahr_v.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_jahr_v_KeyUp);
            this.cbo_jahr_v.Leave += new System.EventHandler(this.cbo_jahr_v_Leave);
            // 
            // cbo_mon_v
            // 
            this.cbo_mon_v.FormattingEnabled = true;
            this.cbo_mon_v.Location = new System.Drawing.Point(923, 36);
            this.cbo_mon_v.Name = "cbo_mon_v";
            this.cbo_mon_v.Size = new System.Drawing.Size(60, 23);
            this.cbo_mon_v.TabIndex = 14;
            this.cbo_mon_v.SelectedIndexChanged += new System.EventHandler(this.cbo_mon_v_SelectedIndexChanged);
            this.cbo_mon_v.Enter += new System.EventHandler(this.cbo_mon_v_Enter);
            this.cbo_mon_v.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_mon_v_KeyUp);
            this.cbo_mon_v.Leave += new System.EventHandler(this.cbo_mon_v_Leave);
            // 
            // cbo_tag_v
            // 
            this.cbo_tag_v.FormattingEnabled = true;
            this.cbo_tag_v.Location = new System.Drawing.Point(1013, 37);
            this.cbo_tag_v.Name = "cbo_tag_v";
            this.cbo_tag_v.Size = new System.Drawing.Size(47, 23);
            this.cbo_tag_v.TabIndex = 15;
            this.cbo_tag_v.SelectedIndexChanged += new System.EventHandler(this.cbo_tag_v_SelectedIndexChanged);
            this.cbo_tag_v.Enter += new System.EventHandler(this.cbo_tag_v_Enter);
            this.cbo_tag_v.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_tag_v_KeyUp);
            this.cbo_tag_v.Leave += new System.EventHandler(this.cbo_tag_v_Leave);
            // 
            // lbl_jahr
            // 
            this.lbl_jahr.Location = new System.Drawing.Point(813, 17);
            this.lbl_jahr.Name = "lbl_jahr";
            this.lbl_jahr.Size = new System.Drawing.Size(81, 16);
            this.lbl_jahr.TabIndex = 10;
            this.lbl_jahr.Text = "Jahr";
            // 
            // lbl_mon
            // 
            this.lbl_mon.Location = new System.Drawing.Point(920, 17);
            this.lbl_mon.Name = "lbl_mon";
            this.lbl_mon.Size = new System.Drawing.Size(74, 16);
            this.lbl_mon.TabIndex = 9;
            this.lbl_mon.Text = "Monat";
            // 
            // lbl_tag
            // 
            this.lbl_tag.Location = new System.Drawing.Point(1009, 17);
            this.lbl_tag.Name = "lbl_tag";
            this.lbl_tag.Size = new System.Drawing.Size(58, 16);
            this.lbl_tag.TabIndex = 8;
            this.lbl_tag.Text = "Tag";
            this.lbl_tag.Click += new System.EventHandler(this.lbl_tag_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vorlage";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(395, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bezirksstelle   ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bereich";
            // 
            // cbo_vorlage
            // 
            this.cbo_vorlage.FormattingEnabled = true;
            this.cbo_vorlage.Location = new System.Drawing.Point(67, 33);
            this.cbo_vorlage.Name = "cbo_vorlage";
            this.cbo_vorlage.Size = new System.Drawing.Size(322, 23);
            this.cbo_vorlage.TabIndex = 2;
            this.cbo_vorlage.SelectedIndexChanged += new System.EventHandler(this.cbo_vorlage_SelectedIndexChanged);
            this.cbo_vorlage.Enter += new System.EventHandler(this.cbo_vorlage_Enter);
            this.cbo_vorlage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_vorlage_KeyUp);
            this.cbo_vorlage.Leave += new System.EventHandler(this.cbo_vorlage_Leave);
            // 
            // cbo_bezirksstelle
            // 
            this.cbo_bezirksstelle.FormattingEnabled = true;
            this.cbo_bezirksstelle.Location = new System.Drawing.Point(511, 36);
            this.cbo_bezirksstelle.Name = "cbo_bezirksstelle";
            this.cbo_bezirksstelle.Size = new System.Drawing.Size(127, 23);
            this.cbo_bezirksstelle.TabIndex = 1;
            this.cbo_bezirksstelle.SelectedIndexChanged += new System.EventHandler(this.cbo_bezirksstelle_SelectedIndexChanged);
            this.cbo_bezirksstelle.Enter += new System.EventHandler(this.cbo_bezirksstelle_Enter);
            this.cbo_bezirksstelle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbo_bezirksstelle_KeyUp);
            this.cbo_bezirksstelle.Leave += new System.EventHandler(this.cbo_bezirksstelle_Leave);
            // 
            // cbo_Bereich
            // 
            this.cbo_Bereich.FormattingEnabled = true;
            this.cbo_Bereich.Location = new System.Drawing.Point(67, 64);
            this.cbo_Bereich.Name = "cbo_Bereich";
            this.cbo_Bereich.Size = new System.Drawing.Size(323, 23);
            this.cbo_Bereich.TabIndex = 0;
            this.cbo_Bereich.SelectedIndexChanged += new System.EventHandler(this.cbo_Bereich_SelectedIndexChanged);
            this.cbo_Bereich.Enter += new System.EventHandler(this.cbo_Bereich_Enter);
            this.cbo_Bereich.Leave += new System.EventHandler(this.cbo_Bereich_Leave);
            // 
            // cmd_start
            // 
            this.cmd_start.Location = new System.Drawing.Point(910, 710);
            this.cmd_start.Name = "cmd_start";
            this.cmd_start.Size = new System.Drawing.Size(87, 27);
            this.cmd_start.TabIndex = 1;
            this.cmd_start.Text = "&Drucken";
            this.cmd_start.UseVisualStyleBackColor = true;
            this.cmd_start.Click += new System.EventHandler(this.cmd_start_Click);
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(1003, 710);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(87, 27);
            this.cmd_schliessen.TabIndex = 2;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 740);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1131, 28);
            this.statusStrip1.TabIndex = 42;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // strip_info
            // 
            this.strip_info.AutoSize = false;
            this.strip_info.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.strip_info.Name = "strip_info";
            this.strip_info.Size = new System.Drawing.Size(610, 23);
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
            this.lblCON.Size = new System.Drawing.Size(46, 23);
            this.lblCON.Text = "lblCON";
            // 
            // labelDayDate
            // 
            this.labelDayDate.Name = "labelDayDate";
            this.labelDayDate.Size = new System.Drawing.Size(0, 23);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(14, 14);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1088, 575);
            this.crystalReportViewer1.TabIndex = 43;
            this.crystalReportViewer1.ToolPanelWidth = 233;
            this.crystalReportViewer1.Error += new CrystalDecisions.Windows.Forms.ExceptionEventHandler(this.crystalReportViewer1_Error);
            this.crystalReportViewer1.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // cmd_Log
            // 
            this.cmd_Log.Location = new System.Drawing.Point(14, 710);
            this.cmd_Log.Name = "cmd_Log";
            this.cmd_Log.Size = new System.Drawing.Size(87, 27);
            this.cmd_Log.TabIndex = 44;
            this.cmd_Log.Text = "&Log";
            this.cmd_Log.UseVisualStyleBackColor = true;
            this.cmd_Log.Click += new System.EventHandler(this.cmd_Log_Click);
            // 
            // lst_info_aw
            // 
            this.lst_info_aw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_info_aw.Location = new System.Drawing.Point(263, 14);
            this.lst_info_aw.Name = "lst_info_aw";
            this.lst_info_aw.Size = new System.Drawing.Size(589, 549);
            this.lst_info_aw.TabIndex = 48;
            this.lst_info_aw.UseCompatibleStateImageBehavior = false;
            // 
            // grp_1
            // 
            this.grp_1.Controls.Add(this.cmd_print);
            this.grp_1.Controls.Add(this.txt_offset);
            this.grp_1.Controls.Add(this.chk_wbd_log);
            this.grp_1.Controls.Add(this.chk_CR_Log);
            this.grp_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_1.Location = new System.Drawing.Point(113, 696);
            this.grp_1.Name = "grp_1";
            this.grp_1.Size = new System.Drawing.Size(442, 42);
            this.grp_1.TabIndex = 50;
            this.grp_1.TabStop = false;
            // 
            // cmd_print
            // 
            this.cmd_print.Location = new System.Drawing.Point(349, 14);
            this.cmd_print.Name = "cmd_print";
            this.cmd_print.Size = new System.Drawing.Size(87, 27);
            this.cmd_print.TabIndex = 29;
            this.cmd_print.Text = "&Print";
            this.cmd_print.UseVisualStyleBackColor = true;
            this.cmd_print.Click += new System.EventHandler(this.cmd_print_Click);
            // 
            // txt_offset
            // 
            this.txt_offset.Location = new System.Drawing.Point(287, 14);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(47, 20);
            this.txt_offset.TabIndex = 24;
            this.txt_offset.Leave += new System.EventHandler(this.txt_offset_Leave);
            // 
            // chk_wbd_log
            // 
            this.chk_wbd_log.AutoSize = true;
            this.chk_wbd_log.Location = new System.Drawing.Point(6, 15);
            this.chk_wbd_log.Name = "chk_wbd_log";
            this.chk_wbd_log.Size = new System.Drawing.Size(75, 17);
            this.chk_wbd_log.TabIndex = 22;
            this.chk_wbd_log.TabStop = true;
            this.chk_wbd_log.Text = "WBD_Log";
            this.chk_wbd_log.UseVisualStyleBackColor = true;
            this.chk_wbd_log.Click += new System.EventHandler(this.chk_wbd_log_Click);
            // 
            // chk_CR_Log
            // 
            this.chk_CR_Log.Enabled = false;
            this.chk_CR_Log.Location = new System.Drawing.Point(118, 14);
            this.chk_CR_Log.Name = "chk_CR_Log";
            this.chk_CR_Log.Size = new System.Drawing.Size(96, 17);
            this.chk_CR_Log.TabIndex = 23;
            this.chk_CR_Log.TabStop = true;
            this.chk_CR_Log.Text = "WBD_CR_Log";
            this.chk_CR_Log.UseVisualStyleBackColor = true;
            this.chk_CR_Log.Click += new System.EventHandler(this.chk_CR_Log_Click);
            // 
            // txt_out
            // 
            this.txt_out.Location = new System.Drawing.Point(25, 204);
            this.txt_out.Multiline = true;
            this.txt_out.Name = "txt_out";
            this.txt_out.Size = new System.Drawing.Size(367, 359);
            this.txt_out.TabIndex = 51;
            this.txt_out.Visible = false;
            // 
            // frm_Auswertung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 768);
            this.Controls.Add(this.txt_out);
            this.Controls.Add(this.grp_1);
            this.Controls.Add(this.lst_info_aw);
            this.Controls.Add(this.cmd_Log);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.cmd_start);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frm_Auswertung";
            this.Text = "AK-Auswertungen";
            this.Activated += new System.EventHandler(this.frm_Auswertung_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_Auswertung_FormClosed);
            this.Load += new System.EventHandler(this.frm_Auswertung_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Auswertung_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_vorlage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grp_1.ResumeLayout(false);
            this.grp_1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_start;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_vorlage;
        private System.Windows.Forms.ComboBox cbo_bezirksstelle;
        private System.Windows.Forms.ComboBox cbo_Bereich;
        private System.Windows.Forms.Label lbl_mon;
        private System.Windows.Forms.Label lbl_tag;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.ComboBox cbo_jahr_v;
        private System.Windows.Forms.ComboBox cbo_mon_v;
        private System.Windows.Forms.ComboBox cbo_tag_v;
        private System.Windows.Forms.Label lbl_jahr;
        private System.Windows.Forms.Label lbl_bis;
        private System.Windows.Forms.Label lbl_von;
        private System.Windows.Forms.ComboBox cbo_tag_b;
        private System.Windows.Forms.ComboBox cbo_mon_b;
        private System.Windows.Forms.ComboBox cbo_jahr_b;
        private System.Windows.Forms.DataGridView dgv_vorlage;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.RadioButton chk_100;
        private System.Windows.Forms.RadioButton chk_50;
        private System.Windows.Forms.Button cmd_Log;
        private System.Windows.Forms.ListView lst_info_aw;
        private System.Windows.Forms.GroupBox grp_1;
        private System.Windows.Forms.Button cmd_print;
        private System.Windows.Forms.TextBox txt_offset;
        private System.Windows.Forms.RadioButton chk_wbd_log;
        private System.Windows.Forms.RadioButton chk_CR_Log;
        private System.Windows.Forms.TextBox txt_out;
        private System.Windows.Forms.ComboBox cb_gbv;
        private System.Windows.Forms.Label lbl_gbv;
    }
}
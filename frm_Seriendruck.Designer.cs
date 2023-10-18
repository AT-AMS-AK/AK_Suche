namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Seriendruck
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Seriendruck));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmd_schliesen = new System.Windows.Forms.Button();
            this.cmd_drucken = new System.Windows.Forms.Button();
            this.grp_Seriendruck = new System.Windows.Forms.GroupBox();
            this.chk_sonstige = new System.Windows.Forms.CheckBox();
            this.chk_ra = new System.Windows.Forms.CheckBox();
            this.chk_akv = new System.Windows.Forms.CheckBox();
            this.chk_isa = new System.Windows.Forms.CheckBox();
            this.grp_bestätigungstermin = new System.Windows.Forms.GroupBox();
            this.lbl_Tag = new System.Windows.Forms.Label();
            this.lst_Minutes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_bestetigung = new System.Windows.Forms.Label();
            this.mtxt_ConfirmationStartTime = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_ConfirmationPrintDate = new System.Windows.Forms.MaskedTextBox();
            this.opt_bdl = new System.Windows.Forms.CheckBox();
            this.opt_wbd = new System.Windows.Forms.CheckBox();
            this.chk_sort = new System.Windows.Forms.CheckBox();
            this.chk_bdl = new System.Windows.Forms.CheckBox();
            this.chk_wbd = new System.Windows.Forms.CheckBox();
            this.dgv_bezirksstelle = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxt_bis = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_von = new System.Windows.Forms.MaskedTextBox();
            this.dgv_Vorlage = new System.Windows.Forms.DataGridView();
            this.dgv_Status = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Bereich = new System.Windows.Forms.Label();
            this.cob_Vorlage = new System.Windows.Forms.ComboBox();
            this.cob_Status = new System.Windows.Forms.ComboBox();
            this.cob_Bezirksstelle = new System.Windows.Forms.ComboBox();
            this.cob_Bereich = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.grp_Seriendruck.SuspendLayout();
            this.grp_bestätigungstermin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bezirksstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Vorlage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Status)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 525);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(662, 24);
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
            // cmd_schliesen
            // 
            this.cmd_schliesen.Location = new System.Drawing.Point(565, 481);
            this.cmd_schliesen.Name = "cmd_schliesen";
            this.cmd_schliesen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliesen.TabIndex = 42;
            this.cmd_schliesen.Text = "&Schließen";
            this.cmd_schliesen.UseVisualStyleBackColor = true;
            this.cmd_schliesen.Click += new System.EventHandler(this.cmd_schliesen_Click);
            // 
            // cmd_drucken
            // 
            this.cmd_drucken.Location = new System.Drawing.Point(460, 481);
            this.cmd_drucken.Name = "cmd_drucken";
            this.cmd_drucken.Size = new System.Drawing.Size(75, 23);
            this.cmd_drucken.TabIndex = 43;
            this.cmd_drucken.Text = "&Drucken";
            this.cmd_drucken.UseVisualStyleBackColor = true;
            this.cmd_drucken.Click += new System.EventHandler(this.cmd_drucken_Click);
            // 
            // grp_Seriendruck
            // 
            this.grp_Seriendruck.Controls.Add(this.chk_sonstige);
            this.grp_Seriendruck.Controls.Add(this.chk_ra);
            this.grp_Seriendruck.Controls.Add(this.chk_akv);
            this.grp_Seriendruck.Controls.Add(this.chk_isa);
            this.grp_Seriendruck.Controls.Add(this.grp_bestätigungstermin);
            this.grp_Seriendruck.Controls.Add(this.opt_bdl);
            this.grp_Seriendruck.Controls.Add(this.opt_wbd);
            this.grp_Seriendruck.Controls.Add(this.chk_sort);
            this.grp_Seriendruck.Controls.Add(this.chk_bdl);
            this.grp_Seriendruck.Controls.Add(this.chk_wbd);
            this.grp_Seriendruck.Controls.Add(this.dgv_bezirksstelle);
            this.grp_Seriendruck.Controls.Add(this.label5);
            this.grp_Seriendruck.Controls.Add(this.label4);
            this.grp_Seriendruck.Controls.Add(this.mtxt_bis);
            this.grp_Seriendruck.Controls.Add(this.mtxt_von);
            this.grp_Seriendruck.Controls.Add(this.dgv_Vorlage);
            this.grp_Seriendruck.Controls.Add(this.dgv_Status);
            this.grp_Seriendruck.Controls.Add(this.label3);
            this.grp_Seriendruck.Controls.Add(this.label2);
            this.grp_Seriendruck.Controls.Add(this.label1);
            this.grp_Seriendruck.Controls.Add(this.Bereich);
            this.grp_Seriendruck.Controls.Add(this.cob_Vorlage);
            this.grp_Seriendruck.Controls.Add(this.cob_Status);
            this.grp_Seriendruck.Controls.Add(this.cob_Bezirksstelle);
            this.grp_Seriendruck.Controls.Add(this.cob_Bereich);
            this.grp_Seriendruck.Location = new System.Drawing.Point(12, 12);
            this.grp_Seriendruck.Name = "grp_Seriendruck";
            this.grp_Seriendruck.Size = new System.Drawing.Size(628, 451);
            this.grp_Seriendruck.TabIndex = 44;
            this.grp_Seriendruck.TabStop = false;
            this.grp_Seriendruck.Text = "Seriendruck";
            // 
            // chk_sonstige
            // 
            this.chk_sonstige.Location = new System.Drawing.Point(499, 318);
            this.chk_sonstige.Name = "chk_sonstige";
            this.chk_sonstige.Size = new System.Drawing.Size(73, 22);
            this.chk_sonstige.TabIndex = 88;
            this.chk_sonstige.Text = "Sonstige";
            this.chk_sonstige.UseVisualStyleBackColor = true;
            this.chk_sonstige.CheckedChanged += new System.EventHandler(this.chk_sonstige_CheckedChanged);
            // 
            // chk_ra
            // 
            this.chk_ra.Location = new System.Drawing.Point(371, 318);
            this.chk_ra.Name = "chk_ra";
            this.chk_ra.Size = new System.Drawing.Size(152, 22);
            this.chk_ra.TabIndex = 87;
            this.chk_ra.Text = "RA";
            this.chk_ra.UseVisualStyleBackColor = true;
            this.chk_ra.CheckedChanged += new System.EventHandler(this.chk_ra_CheckedChanged);
            // 
            // chk_akv
            // 
            this.chk_akv.Location = new System.Drawing.Point(246, 318);
            this.chk_akv.Name = "chk_akv";
            this.chk_akv.Size = new System.Drawing.Size(73, 22);
            this.chk_akv.TabIndex = 86;
            this.chk_akv.Text = "AKV";
            this.chk_akv.UseVisualStyleBackColor = true;
            this.chk_akv.CheckedChanged += new System.EventHandler(this.chk_akv_CheckedChanged);
            // 
            // chk_isa
            // 
            this.chk_isa.Location = new System.Drawing.Point(88, 318);
            this.chk_isa.Name = "chk_isa";
            this.chk_isa.Size = new System.Drawing.Size(152, 22);
            this.chk_isa.TabIndex = 85;
            this.chk_isa.Text = "ISA";
            this.chk_isa.UseVisualStyleBackColor = true;
            this.chk_isa.CheckedChanged += new System.EventHandler(this.chk_isa_CheckedChanged);
            // 
            // grp_bestätigungstermin
            // 
            this.grp_bestätigungstermin.Controls.Add(this.lbl_Tag);
            this.grp_bestätigungstermin.Controls.Add(this.lst_Minutes);
            this.grp_bestätigungstermin.Controls.Add(this.label8);
            this.grp_bestätigungstermin.Controls.Add(this.label7);
            this.grp_bestätigungstermin.Controls.Add(this.label6);
            this.grp_bestätigungstermin.Controls.Add(this.lbl_bestetigung);
            this.grp_bestätigungstermin.Controls.Add(this.mtxt_ConfirmationStartTime);
            this.grp_bestätigungstermin.Controls.Add(this.mtxt_ConfirmationPrintDate);
            this.grp_bestätigungstermin.Location = new System.Drawing.Point(1, 362);
            this.grp_bestätigungstermin.Name = "grp_bestätigungstermin";
            this.grp_bestätigungstermin.Size = new System.Drawing.Size(627, 89);
            this.grp_bestätigungstermin.TabIndex = 84;
            this.grp_bestätigungstermin.TabStop = false;
            this.grp_bestätigungstermin.Text = "Bestätigungstermin";
            // 
            // lbl_Tag
            // 
            this.lbl_Tag.Location = new System.Drawing.Point(68, 40);
            this.lbl_Tag.Name = "lbl_Tag";
            this.lbl_Tag.Size = new System.Drawing.Size(99, 23);
            this.lbl_Tag.TabIndex = 91;
            this.lbl_Tag.Text = "label9";
            // 
            // lst_Minutes
            // 
            this.lst_Minutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Minutes.FormattingEnabled = true;
            this.lst_Minutes.Location = new System.Drawing.Point(498, 34);
            this.lst_Minutes.Name = "lst_Minutes";
            this.lst_Minutes.Size = new System.Drawing.Size(50, 21);
            this.lst_Minutes.TabIndex = 90;
            //this.lst_Minutes.SelectedIndexChanged += new System.EventHandler(this.lst_Minutes_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(559, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 89;
            this.label8.Text = "Minuten";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(424, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Uhr - alle";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(262, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 87;
            this.label6.Text = "beginnend um";
            // 
            // lbl_bestetigung
            // 
            this.lbl_bestetigung.Location = new System.Drawing.Point(41, 40);
            this.lbl_bestetigung.Name = "lbl_bestetigung";
            this.lbl_bestetigung.Size = new System.Drawing.Size(32, 13);
            this.lbl_bestetigung.TabIndex = 86;
            this.lbl_bestetigung.Text = "am";
            // 
            // mtxt_ConfirmationStartTime
            // 
            this.mtxt_ConfirmationStartTime.Location = new System.Drawing.Point(369, 37);
            this.mtxt_ConfirmationStartTime.Mask = "90:00";
            this.mtxt_ConfirmationStartTime.Name = "mtxt_ConfirmationStartTime";
            this.mtxt_ConfirmationStartTime.PromptChar = ' ';
            this.mtxt_ConfirmationStartTime.Size = new System.Drawing.Size(47, 20);
            this.mtxt_ConfirmationStartTime.TabIndex = 85;
            this.mtxt_ConfirmationStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxt_ConfirmationStartTime.ValidatingType = typeof(System.DateTime);
            this.mtxt_ConfirmationStartTime.TextChanged += new System.EventHandler(this.mtxt_ConfirmationStartTime_TextChanged);
            // 
            // mtxt_ConfirmationPrintDate
            // 
            this.mtxt_ConfirmationPrintDate.Location = new System.Drawing.Point(169, 37);
            this.mtxt_ConfirmationPrintDate.Mask = "__.__.____";
            this.mtxt_ConfirmationPrintDate.Name = "mtxt_ConfirmationPrintDate";
            this.mtxt_ConfirmationPrintDate.Size = new System.Drawing.Size(80, 20);
            this.mtxt_ConfirmationPrintDate.TabIndex = 84;
            this.mtxt_ConfirmationPrintDate.TextChanged += new System.EventHandler(this.mtxt_ConfirmationPrintDate_TextChanged);
            // 
            // opt_bdl
            // 
            this.opt_bdl.Location = new System.Drawing.Point(246, 281);
            this.opt_bdl.Name = "opt_bdl";
            this.opt_bdl.Size = new System.Drawing.Size(73, 22);
            this.opt_bdl.TabIndex = 75;
            this.opt_bdl.Text = "BDL";
            this.opt_bdl.UseVisualStyleBackColor = true;
            this.opt_bdl.Enter += new System.EventHandler(this.opt_bdl_Enter);
            this.opt_bdl.Leave += new System.EventHandler(this.opt_bdl_Leave);
            // 
            // opt_wbd
            // 
            this.opt_wbd.Location = new System.Drawing.Point(246, 253);
            this.opt_wbd.Name = "opt_wbd";
            this.opt_wbd.Size = new System.Drawing.Size(73, 22);
            this.opt_wbd.TabIndex = 74;
            this.opt_wbd.Text = "WBD";
            this.opt_wbd.UseVisualStyleBackColor = true;
            this.opt_wbd.Enter += new System.EventHandler(this.opt_wbd_Enter);
            this.opt_wbd.Leave += new System.EventHandler(this.opt_wbd_Leave);
            // 
            // chk_sort
            // 
            this.chk_sort.Location = new System.Drawing.Point(371, 253);
            this.chk_sort.Name = "chk_sort";
            this.chk_sort.Size = new System.Drawing.Size(168, 22);
            this.chk_sort.TabIndex = 71;
            this.chk_sort.Text = "AntragsID / Name";
            this.chk_sort.UseVisualStyleBackColor = true;
            this.chk_sort.Enter += new System.EventHandler(this.chk_sort_Enter);
            this.chk_sort.Leave += new System.EventHandler(this.chk_sort_Leave);
            // 
            // chk_bdl
            // 
            this.chk_bdl.Location = new System.Drawing.Point(88, 281);
            this.chk_bdl.Name = "chk_bdl";
            this.chk_bdl.Size = new System.Drawing.Size(152, 22);
            this.chk_bdl.TabIndex = 70;
            this.chk_bdl.Text = "Bildungsdarlehen";
            this.chk_bdl.UseVisualStyleBackColor = true;
            this.chk_bdl.CheckedChanged += new System.EventHandler(this.chk_bdl_CheckedChanged);
            this.chk_bdl.Enter += new System.EventHandler(this.chk_bdl_Enter);
            this.chk_bdl.Leave += new System.EventHandler(this.chk_bdl_Leave);
            // 
            // chk_wbd
            // 
            this.chk_wbd.Location = new System.Drawing.Point(88, 253);
            this.chk_wbd.Name = "chk_wbd";
            this.chk_wbd.Size = new System.Drawing.Size(152, 22);
            this.chk_wbd.TabIndex = 69;
            this.chk_wbd.Text = "Wohnbaudarlehen";
            this.chk_wbd.UseVisualStyleBackColor = true;
            this.chk_wbd.CheckedChanged += new System.EventHandler(this.chk_wbd_CheckedChanged);
            this.chk_wbd.Enter += new System.EventHandler(this.chk_wbd_Enter);
            this.chk_wbd.Leave += new System.EventHandler(this.chk_wbd_Leave);
            // 
            // dgv_bezirksstelle
            // 
            this.dgv_bezirksstelle.AllowUserToAddRows = false;
            this.dgv_bezirksstelle.AllowUserToDeleteRows = false;
            this.dgv_bezirksstelle.Location = new System.Drawing.Point(453, 203);
            this.dgv_bezirksstelle.MaximumSize = new System.Drawing.Size(500, 500);
            this.dgv_bezirksstelle.Name = "dgv_bezirksstelle";
            this.dgv_bezirksstelle.ShowCellErrors = false;
            this.dgv_bezirksstelle.ShowCellToolTips = false;
            this.dgv_bezirksstelle.ShowEditingIcon = false;
            this.dgv_bezirksstelle.ShowRowErrors = false;
            this.dgv_bezirksstelle.Size = new System.Drawing.Size(174, 74);
            this.dgv_bezirksstelle.TabIndex = 68;
            //this.dgv_bezirksstelle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_bezirksstelle_CellContentClick);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(327, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Bis";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(42, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Von";
            // 
            // mtxt_bis
            // 
            this.mtxt_bis.Location = new System.Drawing.Point(371, 212);
            this.mtxt_bis.Name = "mtxt_bis";
            this.mtxt_bis.Size = new System.Drawing.Size(80, 20);
            this.mtxt_bis.TabIndex = 54;
            this.mtxt_bis.Enter += new System.EventHandler(this.mtxt_bis_Enter);
            this.mtxt_bis.Leave += new System.EventHandler(this.mtxt_bis_Leave);
            // 
            // mtxt_von
            // 
            this.mtxt_von.Location = new System.Drawing.Point(88, 208);
            this.mtxt_von.Name = "mtxt_von";
            this.mtxt_von.Size = new System.Drawing.Size(80, 20);
            this.mtxt_von.TabIndex = 53;
            this.mtxt_von.Enter += new System.EventHandler(this.mtxt_von_Enter);
            this.mtxt_von.Leave += new System.EventHandler(this.mtxt_von_Leave);
            // 
            // dgv_Vorlage
            // 
            this.dgv_Vorlage.AllowUserToAddRows = false;
            this.dgv_Vorlage.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Vorlage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Vorlage.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Vorlage.Location = new System.Drawing.Point(428, 0);
            this.dgv_Vorlage.Name = "dgv_Vorlage";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Vorlage.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Vorlage.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Vorlage.Size = new System.Drawing.Size(194, 74);
            this.dgv_Vorlage.TabIndex = 52;
            // 
            // dgv_Status
            // 
            this.dgv_Status.AllowUserToAddRows = false;
            this.dgv_Status.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Status.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Status.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Status.Location = new System.Drawing.Point(451, 110);
            this.dgv_Status.Name = "dgv_Status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Status.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Status.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Status.Size = new System.Drawing.Size(171, 74);
            this.dgv_Status.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(327, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Vorlage";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(42, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Status";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(327, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bezirksstelle";
            // 
            // Bereich
            // 
            this.Bereich.Location = new System.Drawing.Point(42, 56);
            this.Bereich.Name = "Bereich";
            this.Bereich.Size = new System.Drawing.Size(99, 13);
            this.Bereich.TabIndex = 4;
            this.Bereich.Text = "Bereich";
            // 
            // cob_Vorlage
            // 
            this.cob_Vorlage.FormattingEnabled = true;
            this.cob_Vorlage.Location = new System.Drawing.Point(330, 176);
            this.cob_Vorlage.Name = "cob_Vorlage";
            this.cob_Vorlage.Size = new System.Drawing.Size(209, 21);
            this.cob_Vorlage.TabIndex = 3;
            this.cob_Vorlage.SelectedIndexChanged += new System.EventHandler(this.cob_Vorlage_SelectedIndexChanged);
            this.cob_Vorlage.Enter += new System.EventHandler(this.cob_Vorlage_Enter);
            this.cob_Vorlage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cob_Vorlage_KeyUp);
            this.cob_Vorlage.Leave += new System.EventHandler(this.cob_Vorlage_Leave);
            // 
            // cob_Status
            // 
            this.cob_Status.FormattingEnabled = true;
            this.cob_Status.Location = new System.Drawing.Point(45, 176);
            this.cob_Status.Name = "cob_Status";
            this.cob_Status.Size = new System.Drawing.Size(209, 21);
            this.cob_Status.TabIndex = 2;
            this.cob_Status.SelectedIndexChanged += new System.EventHandler(this.cob_Status_SelectedIndexChanged);
            this.cob_Status.TextChanged += new System.EventHandler(this.cob_Status_TextChanged);
            this.cob_Status.Enter += new System.EventHandler(this.cob_Status_Enter);
            this.cob_Status.Leave += new System.EventHandler(this.cob_Status_Leave);
            // 
            // cob_Bezirksstelle
            // 
            this.cob_Bezirksstelle.FormattingEnabled = true;
            this.cob_Bezirksstelle.Location = new System.Drawing.Point(330, 83);
            this.cob_Bezirksstelle.Name = "cob_Bezirksstelle";
            this.cob_Bezirksstelle.Size = new System.Drawing.Size(209, 21);
            this.cob_Bezirksstelle.TabIndex = 1;
            this.cob_Bezirksstelle.SelectedIndexChanged += new System.EventHandler(this.cob_Bezirksstelle_SelectedIndexChanged);
            this.cob_Bezirksstelle.Enter += new System.EventHandler(this.cob_Bezirksstelle_Enter);
            this.cob_Bezirksstelle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cob_Bezirksstelle_KeyUp);
            this.cob_Bezirksstelle.Leave += new System.EventHandler(this.cob_Bezirksstelle_Leave);
            // 
            // cob_Bereich
            // 
            this.cob_Bereich.FormattingEnabled = true;
            this.cob_Bereich.Location = new System.Drawing.Point(45, 83);
            this.cob_Bereich.Name = "cob_Bereich";
            this.cob_Bereich.Size = new System.Drawing.Size(209, 21);
            this.cob_Bereich.TabIndex = 0;
            this.cob_Bereich.SelectedIndexChanged += new System.EventHandler(this.cob_Bereich_SelectedIndexChanged);
            this.cob_Bereich.Enter += new System.EventHandler(this.cob_Bereich_Enter);
            this.cob_Bereich.Leave += new System.EventHandler(this.cob_Bereich_Leave);
            // 
            // frm_Seriendruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 549);
            this.Controls.Add(this.grp_Seriendruck);
            this.Controls.Add(this.cmd_drucken);
            this.Controls.Add(this.cmd_schliesen);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Seriendruck";
            this.Text = "Drucken";
            this.Activated += new System.EventHandler(this.frm_Seriendruck_Activated);
            this.Load += new System.EventHandler(this.frm_Seriendruck_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Seriendruck_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grp_Seriendruck.ResumeLayout(false);
            this.grp_Seriendruck.PerformLayout();
            this.grp_bestätigungstermin.ResumeLayout(false);
            this.grp_bestätigungstermin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bezirksstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Vorlage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Status)).EndInit();
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
        private System.Windows.Forms.Button cmd_schliesen;
        private System.Windows.Forms.Button cmd_drucken;
        private System.Windows.Forms.GroupBox grp_Seriendruck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Bereich;
        private System.Windows.Forms.ComboBox cob_Vorlage;
        private System.Windows.Forms.ComboBox cob_Status;
        private System.Windows.Forms.ComboBox cob_Bezirksstelle;
        private System.Windows.Forms.ComboBox cob_Bereich;
        public System.Windows.Forms.DataGridView dgv_Vorlage;
        public System.Windows.Forms.DataGridView dgv_Status;
        private System.Windows.Forms.MaskedTextBox mtxt_von;
        private System.Windows.Forms.MaskedTextBox mtxt_bis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_bezirksstelle;
        private System.Windows.Forms.CheckBox chk_bdl;
        private System.Windows.Forms.CheckBox chk_wbd;
        private System.Windows.Forms.CheckBox chk_sort;
        private System.Windows.Forms.CheckBox opt_bdl;
        private System.Windows.Forms.CheckBox opt_wbd;
        private System.Windows.Forms.GroupBox grp_bestätigungstermin;
        private System.Windows.Forms.ComboBox lst_Minutes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_bestetigung;
        private System.Windows.Forms.MaskedTextBox mtxt_ConfirmationStartTime;
        private System.Windows.Forms.MaskedTextBox mtxt_ConfirmationPrintDate;
        private System.Windows.Forms.Label lbl_Tag;
        private System.Windows.Forms.CheckBox chk_sonstige;
        private System.Windows.Forms.CheckBox chk_ra;
        private System.Windows.Forms.CheckBox chk_akv;
        private System.Windows.Forms.CheckBox chk_isa;
    }
}
namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Einzeldruck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Einzeldruck));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.grp_Einzeldruck = new System.Windows.Forms.GroupBox();
            this.grp_bestätigungstermin = new System.Windows.Forms.GroupBox();
            this.lbl_Tag = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_bestetigung = new System.Windows.Forms.Label();
            this.mtxt_ConfirmationStartTime = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_ConfirmationPrintDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_sort = new System.Windows.Forms.CheckBox();
            this.cmd_Sichtbar = new System.Windows.Forms.Button();
            this.dgv_Vorlage = new System.Windows.Forms.DataGridView();
            this.dgv_Status = new System.Windows.Forms.DataGridView();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.cmd_Druck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_Vorlage = new System.Windows.Forms.ComboBox();
            this.cbo_Status = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.grp_Einzeldruck.SuspendLayout();
            this.grp_bestätigungstermin.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 271);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(715, 24);
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
            // grp_Einzeldruck
            // 
            this.grp_Einzeldruck.Controls.Add(this.grp_bestätigungstermin);
            this.grp_Einzeldruck.Controls.Add(this.label1);
            this.grp_Einzeldruck.Controls.Add(this.chk_sort);
            this.grp_Einzeldruck.Controls.Add(this.cmd_Sichtbar);
            this.grp_Einzeldruck.Controls.Add(this.dgv_Vorlage);
            this.grp_Einzeldruck.Controls.Add(this.dgv_Status);
            this.grp_Einzeldruck.Controls.Add(this.txt_Output);
            this.grp_Einzeldruck.Controls.Add(this.cmd_schliessen);
            this.grp_Einzeldruck.Controls.Add(this.cmd_Druck);
            this.grp_Einzeldruck.Controls.Add(this.label2);
            this.grp_Einzeldruck.Controls.Add(this.cbo_Vorlage);
            this.grp_Einzeldruck.Controls.Add(this.cbo_Status);
            this.grp_Einzeldruck.Location = new System.Drawing.Point(12, 12);
            this.grp_Einzeldruck.Name = "grp_Einzeldruck";
            this.grp_Einzeldruck.Size = new System.Drawing.Size(695, 251);
            this.grp_Einzeldruck.TabIndex = 43;
            this.grp_Einzeldruck.TabStop = false;
            this.grp_Einzeldruck.Text = "Einzeldruck";
            this.grp_Einzeldruck.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // grp_bestätigungstermin
            // 
            this.grp_bestätigungstermin.Controls.Add(this.lbl_Tag);
            this.grp_bestätigungstermin.Controls.Add(this.label7);
            this.grp_bestätigungstermin.Controls.Add(this.label6);
            this.grp_bestätigungstermin.Controls.Add(this.lbl_bestetigung);
            this.grp_bestätigungstermin.Controls.Add(this.mtxt_ConfirmationStartTime);
            this.grp_bestätigungstermin.Controls.Add(this.mtxt_ConfirmationPrintDate);
            this.grp_bestätigungstermin.Location = new System.Drawing.Point(6, 106);
            this.grp_bestätigungstermin.Name = "grp_bestätigungstermin";
            this.grp_bestätigungstermin.Size = new System.Drawing.Size(658, 89);
            this.grp_bestätigungstermin.TabIndex = 55;
            this.grp_bestätigungstermin.TabStop = false;
            this.grp_bestätigungstermin.Text = "Bestätigungstermin";
            // 
            // lbl_Tag
            // 
            this.lbl_Tag.Location = new System.Drawing.Point(51, 39);
            this.lbl_Tag.Name = "lbl_Tag";
            this.lbl_Tag.Size = new System.Drawing.Size(99, 23);
            this.lbl_Tag.TabIndex = 97;
            this.lbl_Tag.Text = "label9";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(347, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 96;
            this.label7.Text = "Uhr";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(245, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "um";
            // 
            // lbl_bestetigung
            // 
            this.lbl_bestetigung.Location = new System.Drawing.Point(24, 39);
            this.lbl_bestetigung.Name = "lbl_bestetigung";
            this.lbl_bestetigung.Size = new System.Drawing.Size(32, 13);
            this.lbl_bestetigung.TabIndex = 94;
            this.lbl_bestetigung.Text = "am";
            // 
            // mtxt_ConfirmationStartTime
            // 
            this.mtxt_ConfirmationStartTime.Location = new System.Drawing.Point(279, 36);
            this.mtxt_ConfirmationStartTime.Mask = "90:00";
            this.mtxt_ConfirmationStartTime.Name = "mtxt_ConfirmationStartTime";
            this.mtxt_ConfirmationStartTime.PromptChar = ' ';
            this.mtxt_ConfirmationStartTime.Size = new System.Drawing.Size(47, 20);
            this.mtxt_ConfirmationStartTime.TabIndex = 93;
            this.mtxt_ConfirmationStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mtxt_ConfirmationStartTime.ValidatingType = typeof(System.DateTime);
            this.mtxt_ConfirmationStartTime.TextChanged += new System.EventHandler(this.mtxt_ConfirmationStartTime_TextChanged);
            // 
            // mtxt_ConfirmationPrintDate
            // 
            this.mtxt_ConfirmationPrintDate.Location = new System.Drawing.Point(152, 36);
            this.mtxt_ConfirmationPrintDate.Mask = "__.__.____";
            this.mtxt_ConfirmationPrintDate.Name = "mtxt_ConfirmationPrintDate";
            this.mtxt_ConfirmationPrintDate.Size = new System.Drawing.Size(80, 20);
            this.mtxt_ConfirmationPrintDate.TabIndex = 92;
            this.mtxt_ConfirmationPrintDate.TextChanged += new System.EventHandler(this.mtxt_ConfirmationPrintDate_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 54;
            this.label1.Text = "Status";
            // 
            // chk_sort
            // 
            this.chk_sort.AutoSize = true;
            this.chk_sort.Location = new System.Drawing.Point(510, 18);
            this.chk_sort.Name = "chk_sort";
            this.chk_sort.Size = new System.Drawing.Size(112, 17);
            this.chk_sort.TabIndex = 52;
            this.chk_sort.Text = "AntragsID / Name";
            this.chk_sort.UseVisualStyleBackColor = true;
            this.chk_sort.Enter += new System.EventHandler(this.chk_sort_Enter);
            this.chk_sort.Leave += new System.EventHandler(this.chk_sort_Leave);
            // 
            // cmd_Sichtbar
            // 
            this.cmd_Sichtbar.BackColor = System.Drawing.SystemColors.Control;
            this.cmd_Sichtbar.Location = new System.Drawing.Point(370, 212);
            this.cmd_Sichtbar.Name = "cmd_Sichtbar";
            this.cmd_Sichtbar.Size = new System.Drawing.Size(75, 23);
            this.cmd_Sichtbar.TabIndex = 51;
            this.cmd_Sichtbar.Text = "Show";
            this.cmd_Sichtbar.UseVisualStyleBackColor = false;
            this.cmd_Sichtbar.Click += new System.EventHandler(this.cmd_Sichtbar_Click);
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
            this.dgv_Vorlage.Location = new System.Drawing.Point(192, 212);
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
            this.dgv_Vorlage.Size = new System.Drawing.Size(161, 32);
            this.dgv_Vorlage.TabIndex = 50;
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
            this.dgv_Status.Location = new System.Drawing.Point(106, 6);
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
            this.dgv_Status.Size = new System.Drawing.Size(258, 45);
            this.dgv_Status.TabIndex = 49;
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(0, 212);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(186, 32);
            this.txt_Output.TabIndex = 48;
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(589, 212);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliessen.TabIndex = 47;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_Druck
            // 
            this.cmd_Druck.Location = new System.Drawing.Point(494, 212);
            this.cmd_Druck.Name = "cmd_Druck";
            this.cmd_Druck.Size = new System.Drawing.Size(75, 23);
            this.cmd_Druck.TabIndex = 46;
            this.cmd_Druck.Text = "&Drucken";
            this.cmd_Druck.UseVisualStyleBackColor = true;
            this.cmd_Druck.Click += new System.EventHandler(this.cmd_Druck_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(384, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Vorlage";
            // 
            // cbo_Vorlage
            // 
            this.cbo_Vorlage.FormattingEnabled = true;
            this.cbo_Vorlage.Location = new System.Drawing.Point(387, 66);
            this.cbo_Vorlage.Name = "cbo_Vorlage";
            this.cbo_Vorlage.Size = new System.Drawing.Size(277, 21);
            this.cbo_Vorlage.TabIndex = 44;
            this.cbo_Vorlage.SelectedIndexChanged += new System.EventHandler(this.cbo_Vorlage_SelectedIndexChanged);
            this.cbo_Vorlage.Enter += new System.EventHandler(this.cbo_Vorlage_Enter);
            this.cbo_Vorlage.Leave += new System.EventHandler(this.cbo_Vorlage_Leave);
            // 
            // cbo_Status
            // 
            this.cbo_Status.FormattingEnabled = true;
            this.cbo_Status.Location = new System.Drawing.Point(53, 66);
            this.cbo_Status.Name = "cbo_Status";
            this.cbo_Status.Size = new System.Drawing.Size(281, 21);
            this.cbo_Status.TabIndex = 43;
            //this.cbo_Status.SelectedIndexChanged += new System.EventHandler(this.cbo_Status_SelectedIndexChanged);
            // 
            // frm_Einzeldruck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 295);
            this.Controls.Add(this.grp_Einzeldruck);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Einzeldruck";
            this.Text = "Einzeldruck für den Antrag";
            this.Activated += new System.EventHandler(this.frm_Einzeldruck_Activated);
            this.Load += new System.EventHandler(this.frm_Einzeldruck_Load);
            this.Enter += new System.EventHandler(this.frm_Einzeldruck_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Einzeldruck_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grp_Einzeldruck.ResumeLayout(false);
            this.grp_Einzeldruck.PerformLayout();
            this.grp_bestätigungstermin.ResumeLayout(false);
            this.grp_bestätigungstermin.PerformLayout();
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
        private System.Windows.Forms.GroupBox grp_Einzeldruck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chk_sort;
        private System.Windows.Forms.Button cmd_Sichtbar;
        public System.Windows.Forms.DataGridView dgv_Vorlage;
        public System.Windows.Forms.DataGridView dgv_Status;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Button cmd_Druck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_Vorlage;
        private System.Windows.Forms.ComboBox cbo_Status;
        private System.Windows.Forms.GroupBox grp_bestätigungstermin;
        private System.Windows.Forms.Label lbl_Tag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_bestetigung;
        private System.Windows.Forms.MaskedTextBox mtxt_ConfirmationStartTime;
        private System.Windows.Forms.MaskedTextBox mtxt_ConfirmationPrintDate;
    }
}
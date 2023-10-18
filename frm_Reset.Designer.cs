namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Reset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Reset));
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.cmd_update = new System.Windows.Forms.Button();
            this.lst_Output = new System.Windows.Forms.ListView();
            this.cbo_Bereich = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmd_load = new System.Windows.Forms.Button();
            this.txt_Output = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.opt_print = new System.Windows.Forms.RadioButton();
            this.opt_user = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(626, 503);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(98, 23);
            this.cmd_schliessen.TabIndex = 5;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_update
            // 
            this.cmd_update.Location = new System.Drawing.Point(446, 503);
            this.cmd_update.Name = "cmd_update";
            this.cmd_update.Size = new System.Drawing.Size(154, 23);
            this.cmd_update.TabIndex = 6;
            this.cmd_update.Text = "&Zurücksetzen";
            this.cmd_update.UseVisualStyleBackColor = true;
            this.cmd_update.Click += new System.EventHandler(this.cmd_update_Click);
            // 
            // lst_Output
            // 
            this.lst_Output.Location = new System.Drawing.Point(6, 63);
            this.lst_Output.Name = "lst_Output";
            this.lst_Output.Size = new System.Drawing.Size(718, 424);
            this.lst_Output.TabIndex = 7;
            this.lst_Output.UseCompatibleStateImageBehavior = false;
            // 
            // cbo_Bereich
            // 
            this.cbo_Bereich.FormattingEnabled = true;
            this.cbo_Bereich.Location = new System.Drawing.Point(79, 25);
            this.cbo_Bereich.Name = "cbo_Bereich";
            this.cbo_Bereich.Size = new System.Drawing.Size(266, 21);
            this.cbo_Bereich.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bereich";
            // 
            // cmd_load
            // 
            this.cmd_load.Location = new System.Drawing.Point(626, 23);
            this.cmd_load.Name = "cmd_load";
            this.cmd_load.Size = new System.Drawing.Size(98, 23);
            this.cmd_load.TabIndex = 10;
            this.cmd_load.Text = "&Laden";
            this.cmd_load.UseVisualStyleBackColor = true;
            this.cmd_load.Click += new System.EventHandler(this.cmd_load_Click);
            // 
            // txt_Output
            // 
            this.txt_Output.Location = new System.Drawing.Point(6, 493);
            this.txt_Output.Multiline = true;
            this.txt_Output.Name = "txt_Output";
            this.txt_Output.Size = new System.Drawing.Size(424, 41);
            this.txt_Output.TabIndex = 11;
            this.txt_Output.Visible = false;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
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
            this.groupBox1.Controls.Add(this.opt_print);
            this.groupBox1.Controls.Add(this.opt_user);
            this.groupBox1.Controls.Add(this.cbo_Bereich);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmd_schliessen);
            this.groupBox1.Controls.Add(this.cmd_update);
            this.groupBox1.Controls.Add(this.txt_Output);
            this.groupBox1.Controls.Add(this.cmd_load);
            this.groupBox1.Controls.Add(this.lst_Output);
            this.groupBox1.Location = new System.Drawing.Point(0, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(736, 540);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset";
            // 
            // opt_print
            // 
            this.opt_print.AutoSize = true;
            this.opt_print.Location = new System.Drawing.Point(499, 27);
            this.opt_print.Name = "opt_print";
            this.opt_print.Size = new System.Drawing.Size(93, 17);
            this.opt_print.TabIndex = 13;
            this.opt_print.TabStop = true;
            this.opt_print.Text = "Auswertungen";
            this.opt_print.UseVisualStyleBackColor = true;
            this.opt_print.Enter += new System.EventHandler(this.opt_print_Enter);
            // 
            // opt_user
            // 
            this.opt_user.AutoSize = true;
            this.opt_user.Location = new System.Drawing.Point(386, 27);
            this.opt_user.Name = "opt_user";
            this.opt_user.Size = new System.Drawing.Size(67, 17);
            this.opt_user.TabIndex = 12;
            this.opt_user.TabStop = true;
            this.opt_user.Text = "Benutzer";
            this.opt_user.UseVisualStyleBackColor = true;
            this.opt_user.Enter += new System.EventHandler(this.opt_user_Enter);
            // 
            // frm_Reset
            // 
            this.AcceptButton = this.cmd_schliessen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 579);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Reset";
            this.Text = "gesperrte Anträge entsperren";
            this.Activated += new System.EventHandler(this.frm_Reset_Activated);
            this.Load += new System.EventHandler(this.frm_Reset_Load);
            this.Enter += new System.EventHandler(this.frm_Reset_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Reset_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Button cmd_update;
        private System.Windows.Forms.ListView lst_Output;
        private System.Windows.Forms.ComboBox cbo_Bereich;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmd_load;
        private System.Windows.Forms.TextBox txt_Output;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton opt_print;
        private System.Windows.Forms.RadioButton opt_user;
    }
}
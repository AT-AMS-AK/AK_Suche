namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Version
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_Output = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.chk_ak_suche = new System.Windows.Forms.RadioButton();
            this.chk_get_data = new System.Windows.Forms.RadioButton();
            this.txt_version = new System.Windows.Forms.TextBox();
            this.chk_seriendruck = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(767, 24);
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
            this.groupBox1.Controls.Add(this.lst_Output);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(743, 372);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versionsmanagement";
            // 
            // lst_Output
            // 
            this.lst_Output.Location = new System.Drawing.Point(6, 39);
            this.lst_Output.Name = "lst_Output";
            this.lst_Output.Size = new System.Drawing.Size(731, 327);
            this.lst_Output.TabIndex = 0;
            this.lst_Output.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(657, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "&Schließen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chk_ak_suche
            // 
            this.chk_ak_suche.AutoSize = true;
            this.chk_ak_suche.Location = new System.Drawing.Point(257, 398);
            this.chk_ak_suche.Name = "chk_ak_suche";
            this.chk_ak_suche.Size = new System.Drawing.Size(73, 17);
            this.chk_ak_suche.TabIndex = 44;
            this.chk_ak_suche.TabStop = true;
            this.chk_ak_suche.Text = "AK Suche";
            this.chk_ak_suche.UseVisualStyleBackColor = true;
            this.chk_ak_suche.CheckedChanged += new System.EventHandler(this.chk_ak_suche_CheckedChanged);
            // 
            // chk_get_data
            // 
            this.chk_get_data.AutoSize = true;
            this.chk_get_data.Location = new System.Drawing.Point(355, 399);
            this.chk_get_data.Name = "chk_get_data";
            this.chk_get_data.Size = new System.Drawing.Size(113, 17);
            this.chk_get_data.TabIndex = 45;
            this.chk_get_data.TabStop = true;
            this.chk_get_data.Text = "PL/SQL Get_Data";
            this.chk_get_data.UseVisualStyleBackColor = true;
            this.chk_get_data.CheckedChanged += new System.EventHandler(this.chk_get_data_CheckedChanged);
            // 
            // txt_version
            // 
            this.txt_version.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_version.Enabled = false;
            this.txt_version.Location = new System.Drawing.Point(12, 398);
            this.txt_version.Name = "txt_version";
            this.txt_version.Size = new System.Drawing.Size(239, 20);
            this.txt_version.TabIndex = 46;
            // 
            // chk_seriendruck
            // 
            this.chk_seriendruck.AutoSize = true;
            this.chk_seriendruck.Location = new System.Drawing.Point(497, 398);
            this.chk_seriendruck.Name = "chk_seriendruck";
            this.chk_seriendruck.Size = new System.Drawing.Size(124, 17);
            this.chk_seriendruck.TabIndex = 47;
            this.chk_seriendruck.TabStop = true;
            this.chk_seriendruck.Text = "PL/SQL Seriendruck";
            this.chk_seriendruck.UseVisualStyleBackColor = true;
            this.chk_seriendruck.CheckedChanged += new System.EventHandler(this.chk_seriendruck_CheckedChanged);
            // 
            // frm_Version
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 455);
            this.Controls.Add(this.chk_seriendruck);
            this.Controls.Add(this.txt_version);
            this.Controls.Add(this.chk_get_data);
            this.Controls.Add(this.chk_ak_suche);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frm_Version";
            this.Text = "WBD Versionsmanagement";
            this.Activated += new System.EventHandler(this.frm_Version_Activated);
            this.Load += new System.EventHandler(this.frm_version_Load);
            this.Enter += new System.EventHandler(this.frm_Version_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Version_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lst_Output;
        private System.Windows.Forms.RadioButton chk_ak_suche;
        private System.Windows.Forms.RadioButton chk_get_data;
        private System.Windows.Forms.TextBox txt_version;
        private System.Windows.Forms.RadioButton chk_seriendruck;
    }
}
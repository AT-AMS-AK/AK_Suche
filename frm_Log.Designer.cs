namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Log));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lst_info = new System.Windows.Forms.ListView();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.opt_DG = new System.Windows.Forms.RadioButton();
            this.opt_AP = new System.Windows.Forms.RadioButton();
            this.opt_AD = new System.Windows.Forms.RadioButton();
            this.opt_EX = new System.Windows.Forms.RadioButton();
            this.opt_AU = new System.Windows.Forms.RadioButton();
            this.opt_DA = new System.Windows.Forms.RadioButton();
            this.opt_BC = new System.Windows.Forms.RadioButton();
            this.opt_DE = new System.Windows.Forms.RadioButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_offset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.opt_Error = new System.Windows.Forms.RadioButton();
            this.cmd_print = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lst_info);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(575, 442);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log - Einträge";
            // 
            // lst_info
            // 
            this.lst_info.Location = new System.Drawing.Point(6, 32);
            this.lst_info.Name = "lst_info";
            this.lst_info.Size = new System.Drawing.Size(563, 404);
            this.lst_info.TabIndex = 0;
            this.lst_info.UseCompatibleStateImageBehavior = false;
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(704, 446);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(84, 23);
            this.cmd_schliessen.TabIndex = 17;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // opt_DG
            // 
            this.opt_DG.AutoSize = true;
            this.opt_DG.Location = new System.Drawing.Point(600, 44);
            this.opt_DG.Name = "opt_DG";
            this.opt_DG.Size = new System.Drawing.Size(142, 17);
            this.opt_DG.TabIndex = 18;
            this.opt_DG.TabStop = true;
            this.opt_DG.Text = "Dokumentengenerierung";
            this.opt_DG.UseVisualStyleBackColor = true;
            this.opt_DG.Click += new System.EventHandler(this.opt_DG_Click);
            // 
            // opt_AP
            // 
            this.opt_AP.AutoSize = true;
            this.opt_AP.Location = new System.Drawing.Point(600, 280);
            this.opt_AP.Name = "opt_AP";
            this.opt_AP.Size = new System.Drawing.Size(77, 17);
            this.opt_AP.TabIndex = 20;
            this.opt_AP.TabStop = true;
            this.opt_AP.Text = "Application";
            this.opt_AP.UseVisualStyleBackColor = true;
            this.opt_AP.Click += new System.EventHandler(this.opt_AP_Click);
            // 
            // opt_AD
            // 
            this.opt_AD.AutoSize = true;
            this.opt_AD.Location = new System.Drawing.Point(600, 248);
            this.opt_AD.Name = "opt_AD";
            this.opt_AD.Size = new System.Drawing.Size(145, 17);
            this.opt_AD.TabIndex = 21;
            this.opt_AD.TabStop = true;
            this.opt_AD.Text = "Anweisungsdatum setzen";
            this.opt_AD.UseVisualStyleBackColor = true;
            this.opt_AD.Click += new System.EventHandler(this.opt_AD_Click);
            // 
            // opt_EX
            // 
            this.opt_EX.AutoSize = true;
            this.opt_EX.Location = new System.Drawing.Point(600, 216);
            this.opt_EX.Name = "opt_EX";
            this.opt_EX.Size = new System.Drawing.Size(55, 17);
            this.opt_EX.TabIndex = 22;
            this.opt_EX.TabStop = true;
            this.opt_EX.Text = "Export";
            this.opt_EX.UseVisualStyleBackColor = true;
            this.opt_EX.Click += new System.EventHandler(this.opt_EX_Click);
            // 
            // opt_AU
            // 
            this.opt_AU.AutoSize = true;
            this.opt_AU.Location = new System.Drawing.Point(600, 181);
            this.opt_AU.Name = "opt_AU";
            this.opt_AU.Size = new System.Drawing.Size(93, 17);
            this.opt_AU.TabIndex = 23;
            this.opt_AU.TabStop = true;
            this.opt_AU.Text = "Authentication";
            this.opt_AU.UseVisualStyleBackColor = true;
            this.opt_AU.Click += new System.EventHandler(this.opt_AU_Click);
            // 
            // opt_DA
            // 
            this.opt_DA.AutoSize = true;
            this.opt_DA.Location = new System.Drawing.Point(600, 76);
            this.opt_DA.Name = "opt_DA";
            this.opt_DA.Size = new System.Drawing.Size(139, 17);
            this.opt_DA.TabIndex = 24;
            this.opt_DA.TabStop = true;
            this.opt_DA.Text = "Datenträger Auszahlung";
            this.opt_DA.UseVisualStyleBackColor = true;
            this.opt_DA.Click += new System.EventHandler(this.opt_DA_Click);
            // 
            // opt_BC
            // 
            this.opt_BC.AutoSize = true;
            this.opt_BC.Location = new System.Drawing.Point(600, 111);
            this.opt_BC.Name = "opt_BC";
            this.opt_BC.Size = new System.Drawing.Size(98, 17);
            this.opt_BC.TabIndex = 25;
            this.opt_BC.TabStop = true;
            this.opt_BC.Text = "Datenträger BC";
            this.opt_BC.UseVisualStyleBackColor = true;
            this.opt_BC.Click += new System.EventHandler(this.opt_BC_Click);
            // 
            // opt_DE
            // 
            this.opt_DE.AutoSize = true;
            this.opt_DE.Location = new System.Drawing.Point(600, 143);
            this.opt_DE.Name = "opt_DE";
            this.opt_DE.Size = new System.Drawing.Size(116, 17);
            this.opt_DE.TabIndex = 26;
            this.opt_DE.TabStop = true;
            this.opt_DE.Text = "Datenträger Einzug";
            this.opt_DE.UseVisualStyleBackColor = true;
            this.opt_DE.Click += new System.EventHandler(this.opt_DE_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 24);
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
            // txt_offset
            // 
            this.txt_offset.Location = new System.Drawing.Point(667, 379);
            this.txt_offset.Name = "txt_offset";
            this.txt_offset.Size = new System.Drawing.Size(48, 20);
            this.txt_offset.TabIndex = 43;
            this.txt_offset.Leave += new System.EventHandler(this.txt_offset_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(593, 386);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Offset";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // opt_Error
            // 
            this.opt_Error.AutoSize = true;
            this.opt_Error.Location = new System.Drawing.Point(600, 356);
            this.opt_Error.Name = "opt_Error";
            this.opt_Error.Size = new System.Drawing.Size(72, 17);
            this.opt_Error.TabIndex = 45;
            this.opt_Error.TabStop = true;
            this.opt_Error.Text = "WBD Log";
            this.opt_Error.UseVisualStyleBackColor = true;
            this.opt_Error.Click += new System.EventHandler(this.opt_Error_Click);
            // 
            // cmd_print
            // 
            this.cmd_print.Location = new System.Drawing.Point(600, 446);
            this.cmd_print.Name = "cmd_print";
            this.cmd_print.Size = new System.Drawing.Size(84, 23);
            this.cmd_print.TabIndex = 18;
            this.cmd_print.Text = "&Drucken";
            this.cmd_print.UseVisualStyleBackColor = true;
            this.cmd_print.Click += new System.EventHandler(this.cmd_print_Click);
            // 
            // frm_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 510);
            this.Controls.Add(this.cmd_print);
            this.Controls.Add(this.opt_Error);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_offset);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.opt_DE);
            this.Controls.Add(this.opt_BC);
            this.Controls.Add(this.opt_DA);
            this.Controls.Add(this.opt_AU);
            this.Controls.Add(this.opt_EX);
            this.Controls.Add(this.opt_AD);
            this.Controls.Add(this.opt_AP);
            this.Controls.Add(this.opt_DG);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Log";
            this.Text = "Log - Einträge";
            this.Activated += new System.EventHandler(this.frm_Log_Activated);
            this.Load += new System.EventHandler(this.frm_Log_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Log_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.RadioButton opt_DG;
        private System.Windows.Forms.RadioButton opt_AP;
        private System.Windows.Forms.RadioButton opt_AD;
        private System.Windows.Forms.RadioButton opt_EX;
        private System.Windows.Forms.RadioButton opt_AU;
        private System.Windows.Forms.RadioButton opt_DA;
        private System.Windows.Forms.RadioButton opt_BC;
        private System.Windows.Forms.RadioButton opt_DE;
        private System.Windows.Forms.ListView lst_info;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.TextBox txt_offset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton opt_Error;
        private System.Windows.Forms.Button cmd_print;
    }
}
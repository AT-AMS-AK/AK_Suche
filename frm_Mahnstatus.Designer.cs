namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Mahnstatus
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbo_Mahnstatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmd_setzen = new System.Windows.Forms.Button();
            this.lst_Mahnstatus = new System.Windows.Forms.ListView();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.dgv_Mahnstatus = new System.Windows.Forms.DataGridView();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mahnstatus)).BeginInit();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 338);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(631, 24);
            this.statusStrip1.TabIndex = 61;
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
            this.groupBox1.Controls.Add(this.cbo_Mahnstatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmd_setzen);
            this.groupBox1.Controls.Add(this.lst_Mahnstatus);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(607, 271);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mahnstatus";
            // 
            // cbo_Mahnstatus
            // 
            this.cbo_Mahnstatus.FormattingEnabled = true;
            this.cbo_Mahnstatus.Location = new System.Drawing.Point(144, 56);
            this.cbo_Mahnstatus.Name = "cbo_Mahnstatus";
            this.cbo_Mahnstatus.Size = new System.Drawing.Size(220, 21);
            this.cbo_Mahnstatus.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mahnstatus auf -";
            // 
            // cmd_setzen
            // 
            this.cmd_setzen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_setzen.Location = new System.Drawing.Point(430, 56);
            this.cmd_setzen.Name = "cmd_setzen";
            this.cmd_setzen.Size = new System.Drawing.Size(75, 23);
            this.cmd_setzen.TabIndex = 1;
            this.cmd_setzen.Text = "s&etzen\r\n";
            this.cmd_setzen.UseVisualStyleBackColor = true;
            this.cmd_setzen.Click += new System.EventHandler(this.cmd_setzen_Click);
            // 
            // lst_Mahnstatus
            // 
            this.lst_Mahnstatus.Location = new System.Drawing.Point(6, 102);
            this.lst_Mahnstatus.Name = "lst_Mahnstatus";
            this.lst_Mahnstatus.Size = new System.Drawing.Size(595, 143);
            this.lst_Mahnstatus.TabIndex = 0;
            this.lst_Mahnstatus.UseCompatibleStateImageBehavior = false;
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(543, 299);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliessen.TabIndex = 63;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // dgv_Mahnstatus
            // 
            this.dgv_Mahnstatus.AllowUserToAddRows = false;
            this.dgv_Mahnstatus.AllowUserToDeleteRows = false;
            this.dgv_Mahnstatus.Location = new System.Drawing.Point(20, 251);
            this.dgv_Mahnstatus.MaximumSize = new System.Drawing.Size(500, 500);
            this.dgv_Mahnstatus.Name = "dgv_Mahnstatus";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Mahnstatus.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Mahnstatus.ShowCellErrors = false;
            this.dgv_Mahnstatus.ShowCellToolTips = false;
            this.dgv_Mahnstatus.ShowEditingIcon = false;
            this.dgv_Mahnstatus.ShowRowErrors = false;
            this.dgv_Mahnstatus.Size = new System.Drawing.Size(338, 71);
            this.dgv_Mahnstatus.TabIndex = 70;
            this.dgv_Mahnstatus.Visible = false;
            // 
            // frm_Mahnstatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 362);
            this.Controls.Add(this.dgv_Mahnstatus);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "frm_Mahnstatus";
            this.Text = "Mahnstatus des aktuellen Antrages";
            this.Activated += new System.EventHandler(this.frm_Mahnstatus_Activated);
            this.Load += new System.EventHandler(this.frm_Mahnstatus_Load);
            this.Enter += new System.EventHandler(this.frm_Mahnstatus_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Mahnstatus_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mahnstatus)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmd_setzen;
        private System.Windows.Forms.ListView lst_Mahnstatus;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.DataGridView dgv_Mahnstatus;
        private System.Windows.Forms.ComboBox cbo_Mahnstatus;
    }
}
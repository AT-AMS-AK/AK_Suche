namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_mitschuldner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mitschuldner));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmd_aktual = new System.Windows.Forms.Button();
            this.chk_Bankgarantie = new System.Windows.Forms.CheckBox();
            this.cmd_Schliessen = new System.Windows.Forms.Button();
            this.cmd_Loeschen = new System.Windows.Forms.Button();
            this.cmd_Speichern = new System.Windows.Forms.Button();
            this.cmd_Suchen = new System.Windows.Forms.Button();
            this.cmd_aendern = new System.Windows.Forms.Button();
            this.lst_mitschuldner = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmd_aktual);
            this.groupBox1.Controls.Add(this.chk_Bankgarantie);
            this.groupBox1.Controls.Add(this.cmd_Schliessen);
            this.groupBox1.Controls.Add(this.cmd_Loeschen);
            this.groupBox1.Controls.Add(this.cmd_Speichern);
            this.groupBox1.Controls.Add(this.cmd_Suchen);
            this.groupBox1.Controls.Add(this.cmd_aendern);
            this.groupBox1.Controls.Add(this.lst_mitschuldner);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(603, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mitschuldner";
            // 
            // cmd_aktual
            // 
            this.cmd_aktual.Location = new System.Drawing.Point(208, 208);
            this.cmd_aktual.Name = "cmd_aktual";
            this.cmd_aktual.Size = new System.Drawing.Size(85, 23);
            this.cmd_aktual.TabIndex = 7;
            this.cmd_aktual.Text = "&Aktualisieren";
            this.cmd_aktual.UseVisualStyleBackColor = true;
            this.cmd_aktual.Click += new System.EventHandler(this.cmd_aktual_Click);
            // 
            // chk_Bankgarantie
            // 
            this.chk_Bankgarantie.AutoSize = true;
            this.chk_Bankgarantie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_Bankgarantie.Location = new System.Drawing.Point(32, 181);
            this.chk_Bankgarantie.Name = "chk_Bankgarantie";
            this.chk_Bankgarantie.Size = new System.Drawing.Size(89, 17);
            this.chk_Bankgarantie.TabIndex = 6;
            this.chk_Bankgarantie.Text = "Bankgarantie";
            this.chk_Bankgarantie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chk_Bankgarantie.UseVisualStyleBackColor = true;
            // 
            // cmd_Schliessen
            // 
            this.cmd_Schliessen.Location = new System.Drawing.Point(511, 208);
            this.cmd_Schliessen.Name = "cmd_Schliessen";
            this.cmd_Schliessen.Size = new System.Drawing.Size(85, 23);
            this.cmd_Schliessen.TabIndex = 5;
            this.cmd_Schliessen.Text = "&Schließen";
            this.cmd_Schliessen.UseVisualStyleBackColor = true;
            this.cmd_Schliessen.Click += new System.EventHandler(this.cmd_Schliessen_Click);
            // 
            // cmd_Loeschen
            // 
            this.cmd_Loeschen.Location = new System.Drawing.Point(410, 208);
            this.cmd_Loeschen.Name = "cmd_Loeschen";
            this.cmd_Loeschen.Size = new System.Drawing.Size(85, 23);
            this.cmd_Loeschen.TabIndex = 4;
            this.cmd_Loeschen.Text = "&Löschen";
            this.cmd_Loeschen.UseVisualStyleBackColor = true;
            this.cmd_Loeschen.Click += new System.EventHandler(this.cmd_Loeschen_Click);
            // 
            // cmd_Speichern
            // 
            this.cmd_Speichern.Location = new System.Drawing.Point(309, 208);
            this.cmd_Speichern.Name = "cmd_Speichern";
            this.cmd_Speichern.Size = new System.Drawing.Size(85, 23);
            this.cmd_Speichern.TabIndex = 3;
            this.cmd_Speichern.Text = "S&peichern";
            this.cmd_Speichern.UseVisualStyleBackColor = true;
            this.cmd_Speichern.Click += new System.EventHandler(this.cmd_Speichern_Click);
            // 
            // cmd_Suchen
            // 
            this.cmd_Suchen.Location = new System.Drawing.Point(107, 208);
            this.cmd_Suchen.Name = "cmd_Suchen";
            this.cmd_Suchen.Size = new System.Drawing.Size(85, 23);
            this.cmd_Suchen.TabIndex = 2;
            this.cmd_Suchen.Text = "S&uchen";
            this.cmd_Suchen.UseVisualStyleBackColor = true;
            this.cmd_Suchen.Click += new System.EventHandler(this.cmd_Suchen_Click);
            // 
            // cmd_aendern
            // 
            this.cmd_aendern.Location = new System.Drawing.Point(6, 208);
            this.cmd_aendern.Name = "cmd_aendern";
            this.cmd_aendern.Size = new System.Drawing.Size(85, 23);
            this.cmd_aendern.TabIndex = 1;
            this.cmd_aendern.Text = "STD-&Ändern";
            this.cmd_aendern.UseVisualStyleBackColor = true;
            this.cmd_aendern.Click += new System.EventHandler(this.cmd_aendern_Click);
            // 
            // lst_mitschuldner
            // 
            this.lst_mitschuldner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_mitschuldner.Location = new System.Drawing.Point(6, 50);
            this.lst_mitschuldner.MultiSelect = false;
            this.lst_mitschuldner.Name = "lst_mitschuldner";
            this.lst_mitschuldner.Size = new System.Drawing.Size(585, 121);
            this.lst_mitschuldner.TabIndex = 0;
            this.lst_mitschuldner.UseCompatibleStateImageBehavior = false;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(615, 24);
            this.statusStrip1.TabIndex = 70;
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
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(310, 12);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(300, 46);
            this.txt_output.TabIndex = 71;
            this.txt_output.Visible = false;
            // 
            // frm_mitschuldner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 311);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_mitschuldner";
            this.Text = "Mitschuldner zum aktuellem Antrag";
            this.Activated += new System.EventHandler(this.frm_mitschuldner_Activated);
            this.Load += new System.EventHandler(this.frm_mitschuldner_Load);
            this.Enter += new System.EventHandler(this.frm_mitschuldner_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_mitschuldner_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmd_Schliessen;
        private System.Windows.Forms.Button cmd_Loeschen;
        private System.Windows.Forms.Button cmd_Speichern;
        private System.Windows.Forms.Button cmd_Suchen;
        private System.Windows.Forms.Button cmd_aendern;
        private System.Windows.Forms.ListView lst_mitschuldner;
        private System.Windows.Forms.CheckBox chk_Bankgarantie;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.Button cmd_aktual;
    }
}
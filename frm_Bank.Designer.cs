namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Bank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Bank));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.GB_Bank_Ein = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOwnerIn = new System.Windows.Forms.TextBox();
            this.gb_status = new System.Windows.Forms.GroupBox();
            this.lbl_ein_Index = new System.Windows.Forms.Label();
            this.lbl_ein_idx = new System.Windows.Forms.Label();
            this.opt_x = new System.Windows.Forms.RadioButton();
            this.opt_r = new System.Windows.Forms.RadioButton();
            this.opt_f = new System.Windows.Forms.RadioButton();
            this.txt_iban_ein = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmd_loeschen_ein = new System.Windows.Forms.Button();
            this.cmd_speichern_ein = new System.Windows.Forms.Button();
            this.cmd_Bank_Ein = new System.Windows.Forms.Button();
            this.cmd_uebernehmen = new System.Windows.Forms.Button();
            this.GB_Bank_Aus = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOwnerOut = new System.Windows.Forms.TextBox();
            this.txt_iban_aus = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmd_loeschen_aus = new System.Windows.Forms.Button();
            this.cmd_speichern_aus = new System.Windows.Forms.Button();
            this.cmd_Bank_Aus = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.addressBox = new System.Windows.Forms.GroupBox();
            this.placeBox = new System.Windows.Forms.TextBox();
            this.streetBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.GB_Bank_Ein.SuspendLayout();
            this.gb_status.SuspendLayout();
            this.GB_Bank_Aus.SuspendLayout();
            this.addressBox.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(624, 24);
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
            // GB_Bank_Ein
            // 
            this.GB_Bank_Ein.Controls.Add(this.label2);
            this.GB_Bank_Ein.Controls.Add(this.txtOwnerIn);
            this.GB_Bank_Ein.Controls.Add(this.gb_status);
            this.GB_Bank_Ein.Controls.Add(this.txt_iban_ein);
            this.GB_Bank_Ein.Controls.Add(this.label9);
            this.GB_Bank_Ein.Controls.Add(this.cmd_loeschen_ein);
            this.GB_Bank_Ein.Controls.Add(this.cmd_speichern_ein);
            this.GB_Bank_Ein.Controls.Add(this.cmd_Bank_Ein);
            this.GB_Bank_Ein.Enabled = false;
            this.GB_Bank_Ein.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GB_Bank_Ein.Location = new System.Drawing.Point(35, 177);
            this.GB_Bank_Ein.Name = "GB_Bank_Ein";
            this.GB_Bank_Ein.Size = new System.Drawing.Size(557, 147);
            this.GB_Bank_Ein.TabIndex = 11;
            this.GB_Bank_Ein.TabStop = false;
            this.GB_Bank_Ein.Text = "Einzug von";
            // 
            // label2
            // 
            this.label2.AllowDrop = true;
            this.label2.Location = new System.Drawing.Point(104, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Kontoinhaber";
            // 
            // txtOwnerIn
            // 
            this.txtOwnerIn.Enabled = false;
            this.txtOwnerIn.Location = new System.Drawing.Point(206, 25);
            this.txtOwnerIn.Name = "txtOwnerIn";
            this.txtOwnerIn.Size = new System.Drawing.Size(237, 20);
            this.txtOwnerIn.TabIndex = 23;
            this.txtOwnerIn.TextChanged += new System.EventHandler(this.txtOwnerIn_TextChanged);
            // 
            // gb_status
            // 
            this.gb_status.Controls.Add(this.lbl_ein_Index);
            this.gb_status.Controls.Add(this.lbl_ein_idx);
            this.gb_status.Controls.Add(this.opt_x);
            this.gb_status.Controls.Add(this.opt_r);
            this.gb_status.Controls.Add(this.opt_f);
            this.gb_status.Enabled = false;
            this.gb_status.Location = new System.Drawing.Point(6, 92);
            this.gb_status.Name = "gb_status";
            this.gb_status.Size = new System.Drawing.Size(255, 51);
            this.gb_status.TabIndex = 22;
            this.gb_status.TabStop = false;
            this.gb_status.Text = "Status";
            // 
            // lbl_ein_Index
            // 
            this.lbl_ein_Index.Location = new System.Drawing.Point(210, 20);
            this.lbl_ein_Index.Name = "lbl_ein_Index";
            this.lbl_ein_Index.Size = new System.Drawing.Size(45, 22);
            this.lbl_ein_Index.TabIndex = 4;
            this.lbl_ein_Index.Text = "Index";
            // 
            // lbl_ein_idx
            // 
            this.lbl_ein_idx.Location = new System.Drawing.Point(186, 19);
            this.lbl_ein_idx.Name = "lbl_ein_idx";
            this.lbl_ein_idx.Size = new System.Drawing.Size(28, 23);
            this.lbl_ein_idx.TabIndex = 3;
            this.lbl_ein_idx.Text = "10";
            // 
            // opt_x
            // 
            this.opt_x.AutoSize = true;
            this.opt_x.Location = new System.Drawing.Point(121, 18);
            this.opt_x.Name = "opt_x";
            this.opt_x.Size = new System.Drawing.Size(64, 19);
            this.opt_x.TabIndex = 2;
            this.opt_x.TabStop = true;
            this.opt_x.Text = "Unbek.";
            this.opt_x.UseVisualStyleBackColor = true;
            // 
            // opt_r
            // 
            this.opt_r.AutoSize = true;
            this.opt_r.Location = new System.Drawing.Point(70, 18);
            this.opt_r.Name = "opt_r";
            this.opt_r.Size = new System.Drawing.Size(46, 19);
            this.opt_r.TabIndex = 1;
            this.opt_r.TabStop = true;
            this.opt_r.Text = "Rck";
            this.opt_r.UseVisualStyleBackColor = true;
            // 
            // opt_f
            // 
            this.opt_f.AutoSize = true;
            this.opt_f.Location = new System.Drawing.Point(9, 18);
            this.opt_f.Name = "opt_f";
            this.opt_f.Size = new System.Drawing.Size(48, 19);
            this.opt_f.TabIndex = 0;
            this.opt_f.TabStop = true;
            this.opt_f.Text = "First";
            this.opt_f.UseVisualStyleBackColor = true;
            // 
            // txt_iban_ein
            // 
            this.txt_iban_ein.Enabled = false;
            this.txt_iban_ein.Location = new System.Drawing.Point(206, 59);
            this.txt_iban_ein.Name = "txt_iban_ein";
            this.txt_iban_ein.Size = new System.Drawing.Size(237, 20);
            this.txt_iban_ein.TabIndex = 21;
            this.txt_iban_ein.TextChanged += new System.EventHandler(this.txt_iban_ein_TextChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(104, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "IBAN";
            // 
            // cmd_loeschen_ein
            // 
            this.cmd_loeschen_ein.Location = new System.Drawing.Point(368, 88);
            this.cmd_loeschen_ein.Name = "cmd_loeschen_ein";
            this.cmd_loeschen_ein.Size = new System.Drawing.Size(75, 23);
            this.cmd_loeschen_ein.TabIndex = 17;
            this.cmd_loeschen_ein.Text = "&Löschen";
            this.cmd_loeschen_ein.UseVisualStyleBackColor = true;
            this.cmd_loeschen_ein.Click += new System.EventHandler(this.cmd_loeschen_ein_Click);
            // 
            // cmd_speichern_ein
            // 
            this.cmd_speichern_ein.Enabled = false;
            this.cmd_speichern_ein.Location = new System.Drawing.Point(267, 88);
            this.cmd_speichern_ein.Name = "cmd_speichern_ein";
            this.cmd_speichern_ein.Size = new System.Drawing.Size(75, 23);
            this.cmd_speichern_ein.TabIndex = 16;
            this.cmd_speichern_ein.Text = "S&peichern";
            this.cmd_speichern_ein.UseVisualStyleBackColor = true;
            this.cmd_speichern_ein.Click += new System.EventHandler(this.cmd_speichern_ein_Click);
            // 
            // cmd_Bank_Ein
            // 
            this.cmd_Bank_Ein.Location = new System.Drawing.Point(466, 45);
            this.cmd_Bank_Ein.Name = "cmd_Bank_Ein";
            this.cmd_Bank_Ein.Size = new System.Drawing.Size(75, 23);
            this.cmd_Bank_Ein.TabIndex = 15;
            this.cmd_Bank_Ein.Text = "&Bank ...";
            this.cmd_Bank_Ein.UseVisualStyleBackColor = true;
            this.cmd_Bank_Ein.Click += new System.EventHandler(this.cmd_Bank_Ein_Click);
            // 
            // cmd_uebernehmen
            // 
            this.cmd_uebernehmen.Location = new System.Drawing.Point(6, 52);
            this.cmd_uebernehmen.Name = "cmd_uebernehmen";
            this.cmd_uebernehmen.Size = new System.Drawing.Size(77, 23);
            this.cmd_uebernehmen.TabIndex = 7;
            this.cmd_uebernehmen.Text = "Über&nehmen";
            this.cmd_uebernehmen.UseVisualStyleBackColor = true;
            this.cmd_uebernehmen.Click += new System.EventHandler(this.cmd_uebernehmen_Click);
            // 
            // GB_Bank_Aus
            // 
            this.GB_Bank_Aus.Controls.Add(this.label1);
            this.GB_Bank_Aus.Controls.Add(this.txtOwnerOut);
            this.GB_Bank_Aus.Controls.Add(this.txt_iban_aus);
            this.GB_Bank_Aus.Controls.Add(this.label8);
            this.GB_Bank_Aus.Controls.Add(this.cmd_loeschen_aus);
            this.GB_Bank_Aus.Controls.Add(this.cmd_speichern_aus);
            this.GB_Bank_Aus.Controls.Add(this.cmd_uebernehmen);
            this.GB_Bank_Aus.Controls.Add(this.cmd_Bank_Aus);
            this.GB_Bank_Aus.Location = new System.Drawing.Point(35, 39);
            this.GB_Bank_Aus.Name = "GB_Bank_Aus";
            this.GB_Bank_Aus.Size = new System.Drawing.Size(557, 132);
            this.GB_Bank_Aus.TabIndex = 0;
            this.GB_Bank_Aus.TabStop = false;
            this.GB_Bank_Aus.Text = "Überweisung auf";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(104, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Kontoinhaber";
            // 
            // txtOwnerOut
            // 
            this.txtOwnerOut.Enabled = false;
            this.txtOwnerOut.Location = new System.Drawing.Point(206, 25);
            this.txtOwnerOut.Name = "txtOwnerOut";
            this.txtOwnerOut.Size = new System.Drawing.Size(237, 20);
            this.txtOwnerOut.TabIndex = 18;
            this.txtOwnerOut.TextChanged += new System.EventHandler(this.txtOwnerOut_TextChanged);
            // 
            // txt_iban_aus
            // 
            this.txt_iban_aus.Enabled = false;
            this.txt_iban_aus.Location = new System.Drawing.Point(206, 66);
            this.txt_iban_aus.Name = "txt_iban_aus";
            this.txt_iban_aus.Size = new System.Drawing.Size(237, 20);
            this.txt_iban_aus.TabIndex = 13;
            this.txt_iban_aus.TextChanged += new System.EventHandler(this.txt_iban_aus_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(104, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "IBAN";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // cmd_loeschen_aus
            // 
            this.cmd_loeschen_aus.Location = new System.Drawing.Point(368, 95);
            this.cmd_loeschen_aus.Name = "cmd_loeschen_aus";
            this.cmd_loeschen_aus.Size = new System.Drawing.Size(75, 23);
            this.cmd_loeschen_aus.TabIndex = 9;
            this.cmd_loeschen_aus.Text = "&Löschen";
            this.cmd_loeschen_aus.UseVisualStyleBackColor = true;
            this.cmd_loeschen_aus.Click += new System.EventHandler(this.cmd_loeschen_aus_Click);
            // 
            // cmd_speichern_aus
            // 
            this.cmd_speichern_aus.Enabled = false;
            this.cmd_speichern_aus.Location = new System.Drawing.Point(267, 95);
            this.cmd_speichern_aus.Name = "cmd_speichern_aus";
            this.cmd_speichern_aus.Size = new System.Drawing.Size(75, 23);
            this.cmd_speichern_aus.TabIndex = 8;
            this.cmd_speichern_aus.Text = "S&peichern";
            this.cmd_speichern_aus.UseVisualStyleBackColor = true;
            this.cmd_speichern_aus.Click += new System.EventHandler(this.cmd_speichern_aus_Click);
            // 
            // cmd_Bank_Aus
            // 
            this.cmd_Bank_Aus.Location = new System.Drawing.Point(466, 39);
            this.cmd_Bank_Aus.Name = "cmd_Bank_Aus";
            this.cmd_Bank_Aus.Size = new System.Drawing.Size(75, 23);
            this.cmd_Bank_Aus.TabIndex = 6;
            this.cmd_Bank_Aus.Text = "&Bank ...";
            this.cmd_Bank_Aus.UseVisualStyleBackColor = true;
            this.cmd_Bank_Aus.Click += new System.EventHandler(this.cmd_Bank_Aus_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(421, 330);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 18;
            this.saveBtn.Text = "&Speichern";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Visible = false;
            this.saveBtn.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // addressBox
            // 
            this.addressBox.Controls.Add(this.placeBox);
            this.addressBox.Controls.Add(this.streetBox);
            this.addressBox.Controls.Add(this.label4);
            this.addressBox.Controls.Add(this.label3);
            this.addressBox.Enabled = false;
            this.addressBox.Location = new System.Drawing.Point(162, 1);
            this.addressBox.Name = "addressBox";
            this.addressBox.Size = new System.Drawing.Size(472, 71);
            this.addressBox.TabIndex = 43;
            this.addressBox.TabStop = false;
            this.addressBox.Text = "Anschrift";
            this.addressBox.Visible = false;
            // 
            // placeBox
            // 
            this.placeBox.Location = new System.Drawing.Point(200, 45);
            this.placeBox.Name = "placeBox";
            this.placeBox.Size = new System.Drawing.Size(237, 20);
            this.placeBox.TabIndex = 3;
            this.placeBox.TextChanged += new System.EventHandler(this.placeBox_TextChanged);
            // 
            // streetBox
            // 
            this.streetBox.Location = new System.Drawing.Point(200, 15);
            this.streetBox.Name = "streetBox";
            this.streetBox.Size = new System.Drawing.Size(237, 20);
            this.streetBox.TabIndex = 2;
            this.streetBox.TextChanged += new System.EventHandler(this.streetBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(104, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ort";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(104, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Straße";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(517, 330);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 44;
            this.closeBtn.Text = "Schließen";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // frm_Bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 382);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.addressBox);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.GB_Bank_Aus);
            this.Controls.Add(this.GB_Bank_Ein);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Bank";
            this.Text = "Bankverbindungen des Antragstellers";
            this.Activated += new System.EventHandler(this.frm_Bank_Activated);
            this.Load += new System.EventHandler(this.frm_Bank_Load);
            this.Enter += new System.EventHandler(this.frm_Bank_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Bank_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.GB_Bank_Ein.ResumeLayout(false);
            this.GB_Bank_Ein.PerformLayout();
            this.gb_status.ResumeLayout(false);
            this.gb_status.PerformLayout();
            this.GB_Bank_Aus.ResumeLayout(false);
            this.GB_Bank_Aus.PerformLayout();
            this.addressBox.ResumeLayout(false);
            this.addressBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox GB_Bank_Ein;
        private System.Windows.Forms.Button cmd_Bank_Ein;
        private System.Windows.Forms.Button cmd_loeschen_ein;
        private System.Windows.Forms.Button cmd_speichern_ein;
        private System.Windows.Forms.Button cmd_uebernehmen;
        private System.Windows.Forms.GroupBox GB_Bank_Aus;
        private System.Windows.Forms.Button cmd_loeschen_aus;
        private System.Windows.Forms.Button cmd_speichern_aus;
        private System.Windows.Forms.Button cmd_Bank_Aus;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.TextBox txt_iban_aus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_iban_ein;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gb_status;
        private System.Windows.Forms.RadioButton opt_x;
        private System.Windows.Forms.RadioButton opt_r;
        private System.Windows.Forms.RadioButton opt_f;
        private System.Windows.Forms.Label lbl_ein_Index;
        private System.Windows.Forms.Label lbl_ein_idx;
        private System.Windows.Forms.TextBox txtOwnerIn;
        private System.Windows.Forms.TextBox txtOwnerOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox addressBox;
        private System.Windows.Forms.TextBox placeBox;
        private System.Windows.Forms.TextBox streetBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button closeBtn;
    }
}
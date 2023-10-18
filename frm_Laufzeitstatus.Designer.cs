namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Laufzeitstatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Laufzeitstatus));
            this.lst_output = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_Aussetzungen = new System.Windows.Forms.ComboBox();
            this.mtxt_von = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_bis = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmd_speichern = new System.Windows.Forms.Button();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.txt_betrag = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtxt_Rueckbis = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_Aussetzungen = new System.Windows.Forms.DataGridView();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.mtxt_RAB = new System.Windows.Forms.MaskedTextBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Aussetzungen)).BeginInit();
            this.SuspendLayout();
            // 
            // lst_output
            // 
            this.lst_output.Location = new System.Drawing.Point(12, 156);
            this.lst_output.Name = "lst_output";
            this.lst_output.Size = new System.Drawing.Size(584, 126);
            this.lst_output.TabIndex = 0;
            this.lst_output.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Laufzeitstatus";
            // 
            // cbo_Aussetzungen
            // 
            this.cbo_Aussetzungen.FormattingEnabled = true;
            this.cbo_Aussetzungen.Location = new System.Drawing.Point(12, 73);
            this.cbo_Aussetzungen.Name = "cbo_Aussetzungen";
            this.cbo_Aussetzungen.Size = new System.Drawing.Size(303, 21);
            this.cbo_Aussetzungen.TabIndex = 1;
            this.cbo_Aussetzungen.SelectedIndexChanged += new System.EventHandler(this.cbo_Aussetzungen_SelectedIndexChanged);
            // 
            // mtxt_von
            // 
            this.mtxt_von.Location = new System.Drawing.Point(372, 74);
            this.mtxt_von.Mask = "__.__.____";
            this.mtxt_von.Name = "mtxt_von";
            this.mtxt_von.Size = new System.Drawing.Size(80, 20);
            this.mtxt_von.TabIndex = 2;
            //this.mtxt_von.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxt_von_MaskInputRejected);
            this.mtxt_von.TextChanged += new System.EventHandler(this.Content_Changed);
            this.mtxt_von.Enter += new System.EventHandler(this.mtxt_von_Enter);
            this.mtxt_von.Leave += new System.EventHandler(this.mtxt_von_Leave);
            // 
            // mtxt_bis
            // 
            this.mtxt_bis.Location = new System.Drawing.Point(516, 74);
            this.mtxt_bis.Mask = "__.__.____";
            this.mtxt_bis.Name = "mtxt_bis";
            this.mtxt_bis.Size = new System.Drawing.Size(80, 20);
            this.mtxt_bis.TabIndex = 3;
            this.mtxt_bis.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxt_bis_MaskInputRejected);
            this.mtxt_bis.TextChanged += new System.EventHandler(this.Content_Changed);
            this.mtxt_bis.Enter += new System.EventHandler(this.mtxt_bis_Enter);
            this.mtxt_bis.Leave += new System.EventHandler(this.mtxt_bis_Leave);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(321, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "von";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(469, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "bis";
            // 
            // cmd_speichern
            // 
            this.cmd_speichern.Location = new System.Drawing.Point(422, 288);
            this.cmd_speichern.Name = "cmd_speichern";
            this.cmd_speichern.Size = new System.Drawing.Size(75, 23);
            this.cmd_speichern.TabIndex = 6;
            this.cmd_speichern.Text = "S&peichern";
            this.cmd_speichern.UseVisualStyleBackColor = true;
            this.cmd_speichern.Click += new System.EventHandler(this.cmd_speichern_Click);
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(521, 288);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(75, 23);
            this.cmd_schliessen.TabIndex = 7;
            this.cmd_schliessen.Text = "&Schliessen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // txt_betrag
            // 
            this.txt_betrag.Location = new System.Drawing.Point(246, 113);
            this.txt_betrag.MaxLength = 10;
            this.txt_betrag.Name = "txt_betrag";
            this.txt_betrag.Size = new System.Drawing.Size(69, 20);
            this.txt_betrag.TabIndex = 4;
            this.txt_betrag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_betrag.TextChanged += new System.EventHandler(this.Content_Changed);
            this.txt_betrag.Enter += new System.EventHandler(this.txt_betrag_Enter);
            this.txt_betrag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_betrag_KeyPress);
            this.txt_betrag.Leave += new System.EventHandler(this.txt_betrag_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(175, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "auf";
            // 
            // mtxt_Rueckbis
            // 
            this.mtxt_Rueckbis.Location = new System.Drawing.Point(516, 113);
            this.mtxt_Rueckbis.Mask = "__.__.____";
            this.mtxt_Rueckbis.Name = "mtxt_Rueckbis";
            this.mtxt_Rueckbis.Size = new System.Drawing.Size(80, 20);
            this.mtxt_Rueckbis.TabIndex = 5;
            this.mtxt_Rueckbis.TextChanged += new System.EventHandler(this.Content_Changed);
            this.mtxt_Rueckbis.Enter += new System.EventHandler(this.mtxt_Rueckbis_Enter);
            this.mtxt_Rueckbis.Leave += new System.EventHandler(this.mtxt_Rueckbis_Leave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(340, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Rückstandstilgung";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 320);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(609, 24);
            this.statusStrip1.TabIndex = 14;
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
            this.lblCON.Size = new System.Drawing.Size(46, 15);
            this.lblCON.Text = "lblCON";
            // 
            // labelDayDate
            // 
            this.labelDayDate.AutoSize = false;
            this.labelDayDate.Name = "labelDayDate";
            this.labelDayDate.Size = new System.Drawing.Size(130, 19);
            // 
            // dgv_Aussetzungen
            // 
            this.dgv_Aussetzungen.AllowUserToAddRows = false;
            this.dgv_Aussetzungen.AllowUserToDeleteRows = false;
            this.dgv_Aussetzungen.Location = new System.Drawing.Point(268, 168);
            this.dgv_Aussetzungen.MaximumSize = new System.Drawing.Size(500, 500);
            this.dgv_Aussetzungen.Name = "dgv_Aussetzungen";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Aussetzungen.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Aussetzungen.ShowCellErrors = false;
            this.dgv_Aussetzungen.ShowCellToolTips = false;
            this.dgv_Aussetzungen.ShowEditingIcon = false;
            this.dgv_Aussetzungen.ShowRowErrors = false;
            this.dgv_Aussetzungen.Size = new System.Drawing.Size(329, 95);
            this.dgv_Aussetzungen.TabIndex = 70;
            this.dgv_Aussetzungen.Visible = false;
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(372, 16);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(212, 20);
            this.txt_output.TabIndex = 71;
            // 
            // mtxt_RAB
            // 
            this.mtxt_RAB.Location = new System.Drawing.Point(236, 34);
            this.mtxt_RAB.Mask = "__.__.____";
            this.mtxt_RAB.Name = "mtxt_RAB";
            this.mtxt_RAB.Size = new System.Drawing.Size(80, 20);
            this.mtxt_RAB.TabIndex = 72;
            // 
            // frm_Laufzeitstatus
            // 
            this.AcceptButton = this.cmd_speichern;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 344);
            this.Controls.Add(this.mtxt_RAB);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.dgv_Aussetzungen);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mtxt_Rueckbis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_betrag);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.cmd_speichern);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtxt_bis);
            this.Controls.Add(this.mtxt_von);
            this.Controls.Add(this.cbo_Aussetzungen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lst_output);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Laufzeitstatus";
            this.Text = "Laufzeitstatus des aktuellen Antrages";
            this.Activated += new System.EventHandler(this.frm_Laufzeitstatus_Activated);
            this.Load += new System.EventHandler(this.Laufzeitstatus_Load);
            this.Enter += new System.EventHandler(this.frm_Laufzeitstatus_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_Laufzeitstatus_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Aussetzungen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lst_output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_Aussetzungen;
        private System.Windows.Forms.MaskedTextBox mtxt_von;
        private System.Windows.Forms.MaskedTextBox mtxt_bis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmd_speichern;
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.TextBox txt_betrag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox mtxt_Rueckbis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel strip_info;
        private System.Windows.Forms.ToolStripStatusLabel lblINS;
        private System.Windows.Forms.ToolStripStatusLabel lblNUM;
        private System.Windows.Forms.ToolStripStatusLabel lblCAPS;
        private System.Windows.Forms.ToolStripStatusLabel lblCON;
        private System.Windows.Forms.ToolStripStatusLabel labelDayDate;
        private System.Windows.Forms.DataGridView dgv_Aussetzungen;
        private System.Windows.Forms.TextBox txt_output;
        private System.Windows.Forms.MaskedTextBox mtxt_RAB;
        private System.Windows.Forms.ToolStripStatusLabel lblLOCK;
    }
}
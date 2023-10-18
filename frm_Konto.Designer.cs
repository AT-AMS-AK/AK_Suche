namespace Addit.AK.WBD.AK_Suche
{
    partial class frm_Konto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Konto));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.opt_Bar = new System.Windows.Forms.RadioButton();
            this.opt_Rest = new System.Windows.Forms.RadioButton();
            this.opt_Storno = new System.Windows.Forms.RadioButton();
            this.opt_Zinsen = new System.Windows.Forms.RadioButton();
            this.opt_Ueber = new System.Windows.Forms.RadioButton();
            this.opt_Rueck = new System.Windows.Forms.RadioButton();
            this.opt_Tilgung = new System.Windows.Forms.RadioButton();
            this.opt_Gesamt = new System.Windows.Forms.RadioButton();
            this.mtxt_rueck_bis_real = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_rueck_bis_vertr = new System.Windows.Forms.MaskedTextBox();
            this.mtxt_rueck_ab = new System.Windows.Forms.MaskedTextBox();
            this.lst_Tilgungsstatus = new System.Windows.Forms.ListView();
            this.txt_d_betr = new System.Windows.Forms.TextBox();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.txt_anzahl = new System.Windows.Forms.TextBox();
            this.txt_konto_real = new System.Windows.Forms.TextBox();
            this.txt_konto_vert = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_darlehensnr = new System.Windows.Forms.TextBox();
            this.txt_antragsteller = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lst_buchungen = new System.Windows.Forms.ListView();
            this.cmd_schliessen = new System.Windows.Forms.Button();
            this.cmd_buchen = new System.Windows.Forms.Button();
            this.cmd_drucken = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 686);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(850, 24);
            this.statusStrip1.TabIndex = 62;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.mtxt_rueck_bis_real);
            this.groupBox1.Controls.Add(this.mtxt_rueck_bis_vertr);
            this.groupBox1.Controls.Add(this.mtxt_rueck_ab);
            this.groupBox1.Controls.Add(this.lst_Tilgungsstatus);
            this.groupBox1.Controls.Add(this.txt_d_betr);
            this.groupBox1.Controls.Add(this.txt_rate);
            this.groupBox1.Controls.Add(this.txt_anzahl);
            this.groupBox1.Controls.Add(this.txt_konto_real);
            this.groupBox1.Controls.Add(this.txt_konto_vert);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_darlehensnr);
            this.groupBox1.Controls.Add(this.txt_antragsteller);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lst_buchungen);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 621);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kontenblatt";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.opt_Bar);
            this.panel1.Controls.Add(this.opt_Rest);
            this.panel1.Controls.Add(this.opt_Storno);
            this.panel1.Controls.Add(this.opt_Zinsen);
            this.panel1.Controls.Add(this.opt_Ueber);
            this.panel1.Controls.Add(this.opt_Rueck);
            this.panel1.Controls.Add(this.opt_Tilgung);
            this.panel1.Controls.Add(this.opt_Gesamt);
            this.panel1.Location = new System.Drawing.Point(654, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 289);
            this.panel1.TabIndex = 35;
            // 
            // opt_Bar
            // 
            this.opt_Bar.AutoSize = true;
            this.opt_Bar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Bar.Location = new System.Drawing.Point(7, 253);
            this.opt_Bar.Name = "opt_Bar";
            this.opt_Bar.Size = new System.Drawing.Size(84, 17);
            this.opt_Bar.TabIndex = 15;
            this.opt_Bar.TabStop = true;
            this.opt_Bar.Text = "Barauslagen";
            this.opt_Bar.UseVisualStyleBackColor = true;
            this.opt_Bar.CheckedChanged += new System.EventHandler(this.opt_Bar_CheckedChanged);
            // 
            // opt_Rest
            // 
            this.opt_Rest.AutoSize = true;
            this.opt_Rest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Rest.Location = new System.Drawing.Point(8, 219);
            this.opt_Rest.Name = "opt_Rest";
            this.opt_Rest.Size = new System.Drawing.Size(78, 17);
            this.opt_Rest.TabIndex = 14;
            this.opt_Rest.TabStop = true;
            this.opt_Rest.Text = "Resttilgung";
            this.opt_Rest.UseVisualStyleBackColor = true;
            this.opt_Rest.CheckedChanged += new System.EventHandler(this.opt_Rest_CheckedChanged);
            // 
            // opt_Storno
            // 
            this.opt_Storno.AutoSize = true;
            this.opt_Storno.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Storno.Location = new System.Drawing.Point(9, 185);
            this.opt_Storno.Name = "opt_Storno";
            this.opt_Storno.Size = new System.Drawing.Size(56, 17);
            this.opt_Storno.TabIndex = 13;
            this.opt_Storno.TabStop = true;
            this.opt_Storno.Text = "Storno";
            this.opt_Storno.UseVisualStyleBackColor = true;
            this.opt_Storno.CheckedChanged += new System.EventHandler(this.opt_Storno_CheckedChanged);
            // 
            // opt_Zinsen
            // 
            this.opt_Zinsen.AutoSize = true;
            this.opt_Zinsen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Zinsen.Location = new System.Drawing.Point(8, 151);
            this.opt_Zinsen.Name = "opt_Zinsen";
            this.opt_Zinsen.Size = new System.Drawing.Size(57, 17);
            this.opt_Zinsen.TabIndex = 12;
            this.opt_Zinsen.TabStop = true;
            this.opt_Zinsen.Text = "Zinsen";
            this.opt_Zinsen.UseVisualStyleBackColor = true;
            this.opt_Zinsen.CheckedChanged += new System.EventHandler(this.opt_Zinsen_CheckedChanged);
            // 
            // opt_Ueber
            // 
            this.opt_Ueber.AutoSize = true;
            this.opt_Ueber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Ueber.Location = new System.Drawing.Point(8, 117);
            this.opt_Ueber.Name = "opt_Ueber";
            this.opt_Ueber.Size = new System.Drawing.Size(108, 17);
            this.opt_Ueber.TabIndex = 11;
            this.opt_Ueber.TabStop = true;
            this.opt_Ueber.Text = "Überzahlungsliste";
            this.opt_Ueber.UseVisualStyleBackColor = true;
            this.opt_Ueber.CheckedChanged += new System.EventHandler(this.opt_Ueber_CheckedChanged);
            // 
            // opt_Rueck
            // 
            this.opt_Rueck.AutoSize = true;
            this.opt_Rueck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Rueck.Location = new System.Drawing.Point(8, 83);
            this.opt_Rueck.Name = "opt_Rueck";
            this.opt_Rueck.Size = new System.Drawing.Size(106, 17);
            this.opt_Rueck.TabIndex = 10;
            this.opt_Rueck.TabStop = true;
            this.opt_Rueck.Text = "Rückholungsliste";
            this.opt_Rueck.UseVisualStyleBackColor = true;
            this.opt_Rueck.CheckedChanged += new System.EventHandler(this.opt_Rueck_CheckedChanged);
            // 
            // opt_Tilgung
            // 
            this.opt_Tilgung.AutoSize = true;
            this.opt_Tilgung.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Tilgung.Location = new System.Drawing.Point(8, 49);
            this.opt_Tilgung.Name = "opt_Tilgung";
            this.opt_Tilgung.Size = new System.Drawing.Size(83, 17);
            this.opt_Tilgung.TabIndex = 9;
            this.opt_Tilgung.TabStop = true;
            this.opt_Tilgung.Text = "Tilgungsliste";
            this.opt_Tilgung.UseVisualStyleBackColor = true;
            this.opt_Tilgung.CheckedChanged += new System.EventHandler(this.opt_Tilgung_CheckedChanged);
            // 
            // opt_Gesamt
            // 
            this.opt_Gesamt.AutoSize = true;
            this.opt_Gesamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opt_Gesamt.Location = new System.Drawing.Point(7, 15);
            this.opt_Gesamt.Name = "opt_Gesamt";
            this.opt_Gesamt.Size = new System.Drawing.Size(104, 17);
            this.opt_Gesamt.TabIndex = 8;
            this.opt_Gesamt.TabStop = true;
            this.opt_Gesamt.Text = "Gesamtübersicht";
            this.opt_Gesamt.UseVisualStyleBackColor = true;
            this.opt_Gesamt.CheckedChanged += new System.EventHandler(this.opt_Gesamt_CheckedChanged);
            // 
            // mtxt_rueck_bis_real
            // 
            this.mtxt_rueck_bis_real.Location = new System.Drawing.Point(468, 92);
            this.mtxt_rueck_bis_real.Name = "mtxt_rueck_bis_real";
            this.mtxt_rueck_bis_real.Size = new System.Drawing.Size(80, 20);
            this.mtxt_rueck_bis_real.TabIndex = 34;
            // 
            // mtxt_rueck_bis_vertr
            // 
            this.mtxt_rueck_bis_vertr.Location = new System.Drawing.Point(468, 124);
            this.mtxt_rueck_bis_vertr.Name = "mtxt_rueck_bis_vertr";
            this.mtxt_rueck_bis_vertr.Size = new System.Drawing.Size(80, 20);
            this.mtxt_rueck_bis_vertr.TabIndex = 33;
            // 
            // mtxt_rueck_ab
            // 
            this.mtxt_rueck_ab.Location = new System.Drawing.Point(145, 135);
            this.mtxt_rueck_ab.Name = "mtxt_rueck_ab";
            this.mtxt_rueck_ab.Size = new System.Drawing.Size(80, 20);
            this.mtxt_rueck_ab.TabIndex = 32;
            // 
            // lst_Tilgungsstatus
            // 
            this.lst_Tilgungsstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_Tilgungsstatus.Location = new System.Drawing.Point(26, 189);
            this.lst_Tilgungsstatus.Name = "lst_Tilgungsstatus";
            this.lst_Tilgungsstatus.Size = new System.Drawing.Size(622, 126);
            this.lst_Tilgungsstatus.TabIndex = 31;
            this.lst_Tilgungsstatus.UseCompatibleStateImageBehavior = false;
            // 
            // txt_d_betr
            // 
            this.txt_d_betr.Location = new System.Drawing.Point(145, 61);
            this.txt_d_betr.Name = "txt_d_betr";
            this.txt_d_betr.Size = new System.Drawing.Size(80, 20);
            this.txt_d_betr.TabIndex = 30;
            // 
            // txt_rate
            // 
            this.txt_rate.Location = new System.Drawing.Point(145, 85);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.Size = new System.Drawing.Size(80, 20);
            this.txt_rate.TabIndex = 29;
            // 
            // txt_anzahl
            // 
            this.txt_anzahl.Location = new System.Drawing.Point(145, 108);
            this.txt_anzahl.Name = "txt_anzahl";
            this.txt_anzahl.Size = new System.Drawing.Size(80, 20);
            this.txt_anzahl.TabIndex = 28;
            // 
            // txt_konto_real
            // 
            this.txt_konto_real.Location = new System.Drawing.Point(705, 92);
            this.txt_konto_real.Name = "txt_konto_real";
            this.txt_konto_real.Size = new System.Drawing.Size(95, 20);
            this.txt_konto_real.TabIndex = 25;
            // 
            // txt_konto_vert
            // 
            this.txt_konto_vert.Location = new System.Drawing.Point(705, 124);
            this.txt_konto_vert.Name = "txt_konto_vert";
            this.txt_konto_vert.Size = new System.Drawing.Size(96, 20);
            this.txt_konto_vert.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(646, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Kontostand";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(23, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Darlehensbetrag ";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(23, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Ratenhöhe";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(23, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ratenanzahl\r\n";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(23, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Rückzahlung abr ";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(323, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Rückzahlung bis (vetr.) ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(23, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tilgungsstatus";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(643, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "vertr";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(323, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Rückzahlung bis (real)";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(646, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "real ";
            // 
            // txt_darlehensnr
            // 
            this.txt_darlehensnr.Location = new System.Drawing.Point(659, 29);
            this.txt_darlehensnr.Name = "txt_darlehensnr";
            this.txt_darlehensnr.Size = new System.Drawing.Size(142, 20);
            this.txt_darlehensnr.TabIndex = 12;
            // 
            // txt_antragsteller
            // 
            this.txt_antragsteller.Location = new System.Drawing.Point(145, 29);
            this.txt_antragsteller.Name = "txt_antragsteller";
            this.txt_antragsteller.Size = new System.Drawing.Size(314, 20);
            this.txt_antragsteller.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(539, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Darlehens-Nr.:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(23, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Antragsteller ";
            // 
            // lst_buchungen
            // 
            this.lst_buchungen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_buchungen.Location = new System.Drawing.Point(27, 331);
            this.lst_buchungen.Name = "lst_buchungen";
            this.lst_buchungen.Size = new System.Drawing.Size(621, 274);
            this.lst_buchungen.TabIndex = 8;
            this.lst_buchungen.UseCompatibleStateImageBehavior = false;
            // 
            // cmd_schliessen
            // 
            this.cmd_schliessen.Location = new System.Drawing.Point(711, 651);
            this.cmd_schliessen.Name = "cmd_schliessen";
            this.cmd_schliessen.Size = new System.Drawing.Size(127, 23);
            this.cmd_schliessen.TabIndex = 64;
            this.cmd_schliessen.Text = "&Schließen";
            this.cmd_schliessen.UseVisualStyleBackColor = true;
            this.cmd_schliessen.Click += new System.EventHandler(this.cmd_schliessen_Click);
            // 
            // cmd_buchen
            // 
            this.cmd_buchen.Location = new System.Drawing.Point(559, 651);
            this.cmd_buchen.Name = "cmd_buchen";
            this.cmd_buchen.Size = new System.Drawing.Size(127, 23);
            this.cmd_buchen.TabIndex = 65;
            this.cmd_buchen.Text = "Manuell &buchen";
            this.cmd_buchen.UseVisualStyleBackColor = true;
            this.cmd_buchen.Click += new System.EventHandler(this.cmd_buchen_Click);
            // 
            // cmd_drucken
            // 
            this.cmd_drucken.Location = new System.Drawing.Point(407, 651);
            this.cmd_drucken.Name = "cmd_drucken";
            this.cmd_drucken.Size = new System.Drawing.Size(127, 23);
            this.cmd_drucken.TabIndex = 66;
            this.cmd_drucken.Text = "Kontenblatt &drucken";
            this.cmd_drucken.UseVisualStyleBackColor = true;
            this.cmd_drucken.Click += new System.EventHandler(this.cmd_drucken_Click);
            // 
            // frm_Konto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 710);
            this.Controls.Add(this.cmd_drucken);
            this.Controls.Add(this.cmd_schliessen);
            this.Controls.Add(this.cmd_buchen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_Konto";
            this.Text = "Manuell Buchen und Kontoblatt ";
            this.Activated += new System.EventHandler(this.Konto_Activated);
            this.Load += new System.EventHandler(this.Konto_Load);
            this.Enter += new System.EventHandler(this.Konto_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Konto_KeyUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button cmd_schliessen;
        private System.Windows.Forms.Button cmd_buchen;
        private System.Windows.Forms.Button cmd_drucken;
        private System.Windows.Forms.TextBox txt_darlehensnr;
        private System.Windows.Forms.TextBox txt_antragsteller;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lst_buchungen;
        private System.Windows.Forms.MaskedTextBox mtxt_rueck_bis_real;
        private System.Windows.Forms.MaskedTextBox mtxt_rueck_bis_vertr;
        private System.Windows.Forms.MaskedTextBox mtxt_rueck_ab;
        private System.Windows.Forms.ListView lst_Tilgungsstatus;
        private System.Windows.Forms.TextBox txt_d_betr;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.TextBox txt_anzahl;
        private System.Windows.Forms.TextBox txt_konto_real;
        private System.Windows.Forms.TextBox txt_konto_vert;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton opt_Bar;
        private System.Windows.Forms.RadioButton opt_Rest;
        private System.Windows.Forms.RadioButton opt_Storno;
        private System.Windows.Forms.RadioButton opt_Zinsen;
        private System.Windows.Forms.RadioButton opt_Ueber;
        private System.Windows.Forms.RadioButton opt_Rueck;
        private System.Windows.Forms.RadioButton opt_Tilgung;
        private System.Windows.Forms.RadioButton opt_Gesamt;
    }
}
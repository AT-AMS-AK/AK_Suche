using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using Miracle.MPP.WebPCI;
using Addit.AK.WBD.AK_Suche.AuthService;
using Addit.AK.WBD.AK_Suche.DataService ;
using Addit.AK.Util;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_AK_Suche : Form
    {
#region 1
        private ListViewColumnSorter lvwColumnSorter;

        // private  AKK_Helper H = new AKK_Helper();
        //public static Color c_get_focus = Color.Blue;
        //public static Color c_lost_focus = Color.Black;
        //public static Color c_lock = Color.LightPink;
        //public static Color c_unlock = Color.LightGreen;
        //public static Color c_inaktiv = Color.LightGray;

        // public Miracle.MPP.WebPCI.Application PVS_APP = new Miracle.MPP.WebPCI.Application();
        public Miracle.MPP.WebPCI.DataObject PVS_do_WE;
        public Miracle.MPP.WebPCI.Window PVS_wnd_WE;
        //public static clsA_PVS_connection PVS_CON;
        private Button button1;
        private Label lbl_Vorname;
        private Label lbl_Zuname;
        private Label lbl_SVNr;
        private MaskedTextBox mtxt_SVNr;
        private TextBox txt_DLNr;
        private TextBox txt_Vorname;
        private TextBox txt_Zuname;
        private Button cmd_Leer;
        private Button cmd_Suche;
        private MaskedTextBox mtxt_Gebdat;
        private Label lbl_Gebdat;
        private GroupBox groupBox1;
        private Label lbl_DLNr;
        private ListView lst_Output;
        private CheckBox chk_ms;
        private TextBox txt_output;
        private Button cmd_antrag;
        private TextBox txt_pvs_id;
        private Button cmd_std_neu;
        private Button cmd_std_bearbeiten;
        private TextBox txt_personid;
        private CheckBox chk_sort;
        private Button cmd_reset;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel strip_info;
        private ToolStripStatusLabel lblLOCK;
        private ToolStripStatusLabel lblINS;
        private ToolStripStatusLabel lblNUM;
        private ToolStripStatusLabel lblCAPS;
        private ToolStripStatusLabel lblCON;
        private ToolStripStatusLabel labelDayDate;

        private Button cmd_leihgeld;
        private Button cmd_datentraeger;
        private Button cmd_druck;
        private Button cmd_Auswertung;
        private RadioButton opt_MS;

        private string str_scope;
        private TextBox txt_datumswerte;
        private Button cmd_log;
        private Button cmd_version;
        private ToolStripStatusLabel PVSTrace;
        private string var_pvs_ap;

        #endregion 
        public frm_AK_Suche(string[] args)
        {
            
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lst_Output.ListViewItemSorter = lvwColumnSorter;

            //Argumente der .exe überprüfen
            if (args.Length == 0)
            {
                //args[0] = "3";
                //args[1] = "N";
                //args[2] = "c:\\tmp\\WBDl.og.log";
                //args[3] = "SSO";
                 throw new System.ApplicationException("Falsche Anzahl an Argumenten");
            }
            else
            {
                if (!(args.Length == 4))
                {
                    throw new System.ApplicationException("Falsche Anzahl an Argumenten");
                }
                else
                {
                    if (args[0] == "0")
                        str_scope = "3";        // für Klagenfurt
                    else
                        str_scope = args[0];
                }
                
                //Überprüfung ob PVS rückverfolgt werden soll und Single sign on aktviviert werden soll
                AKK_Helper.C = new clsA_Config();
                AKK_Helper.PVSTrace = "N";
                if (args[1].ToString().ToUpper() == "J" || args[1].ToString().ToUpper() == "Y")
                {
                    AKK_Helper.PVSTrace = "Y";
                    AKK_Helper.PVSTraceFile = args[2];
                }
                AKK_Helper.C.strG_SSO_WBD = "N";
                if (args[3] == "SSO")
                {
                    AKK_Helper.C.strG_SSO_WBD = "Y";
                }

                //Verschieden Errormeldungen setzen
                AKK_Helper.str_error.Add("FC001", "Fehler : ");
                AKK_Helper.str_error.Add("FC002", "Keine Einträge gefunden!");
                AKK_Helper.str_error.Add("FC003", "Keine gültige Selektion!");
                AKK_Helper.str_error.Add("FC004", "Kein gültiger Antragsteller selektiert!");
                AKK_Helper.str_error.Add("FC005", "Datum ungültig!");
                AKK_Helper.str_error.Add("FC006", "Suche läuft . . . ");
                AKK_Helper.str_error.Add("FC007", "SVNR unvollständig!");
                AKK_Helper.str_error.Add("FC008", "Unvollständige Darlehensdaten!");
                AKK_Helper.str_error.Add("FC009", "Ungültiges Datum");
                AKK_Helper.str_error.Add("FC010", "Fehler beim Starten der PVS - ");
            }
        }
     
        # region INITIALIZE

        private void cmd_Schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frm_AK_Suche_Activated(object sender, EventArgs e)
        {

            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate,1);
            PVSTrace.Visible = false;
            if (AKK_Helper.PVSTrace == "Y")
            {
                // PVSTrace.Text = "Tr";
                PVSTrace.Visible = true;
                PVSTrace.BackColor = AKK_Helper.c_Trace;
            }

            

        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AK_Suche));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_datumswerte = new System.Windows.Forms.TextBox();
            this.opt_MS = new System.Windows.Forms.RadioButton();
            this.chk_sort = new System.Windows.Forms.CheckBox();
            this.txt_personid = new System.Windows.Forms.TextBox();
            this.txt_pvs_id = new System.Windows.Forms.TextBox();
            this.chk_ms = new System.Windows.Forms.CheckBox();
            this.mtxt_Gebdat = new System.Windows.Forms.MaskedTextBox();
            this.lbl_Gebdat = new System.Windows.Forms.Label();
            this.cmd_Leer = new System.Windows.Forms.Button();
            this.cmd_Suche = new System.Windows.Forms.Button();
            this.mtxt_SVNr = new System.Windows.Forms.MaskedTextBox();
            this.txt_DLNr = new System.Windows.Forms.TextBox();
            this.txt_Vorname = new System.Windows.Forms.TextBox();
            this.txt_Zuname = new System.Windows.Forms.TextBox();
            this.lbl_DLNr = new System.Windows.Forms.Label();
            this.lbl_Vorname = new System.Windows.Forms.Label();
            this.lbl_Zuname = new System.Windows.Forms.Label();
            this.lbl_SVNr = new System.Windows.Forms.Label();
            this.lst_Output = new System.Windows.Forms.ListView();
            this.txt_output = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmd_antrag = new System.Windows.Forms.Button();
            this.cmd_std_neu = new System.Windows.Forms.Button();
            this.cmd_std_bearbeiten = new System.Windows.Forms.Button();
            this.cmd_reset = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.strip_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLOCK = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblINS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNUM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCAPS = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCON = new System.Windows.Forms.ToolStripStatusLabel();
            this.PVSTrace = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDayDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmd_leihgeld = new System.Windows.Forms.Button();
            this.cmd_datentraeger = new System.Windows.Forms.Button();
            this.cmd_druck = new System.Windows.Forms.Button();
            this.cmd_Auswertung = new System.Windows.Forms.Button();
            this.cmd_log = new System.Windows.Forms.Button();
            this.cmd_version = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_datumswerte);
            this.groupBox1.Controls.Add(this.opt_MS);
            this.groupBox1.Controls.Add(this.chk_sort);
            this.groupBox1.Controls.Add(this.txt_personid);
            this.groupBox1.Controls.Add(this.txt_pvs_id);
            this.groupBox1.Controls.Add(this.chk_ms);
            this.groupBox1.Controls.Add(this.mtxt_Gebdat);
            this.groupBox1.Controls.Add(this.lbl_Gebdat);
            this.groupBox1.Controls.Add(this.cmd_Leer);
            this.groupBox1.Controls.Add(this.cmd_Suche);
            this.groupBox1.Controls.Add(this.mtxt_SVNr);
            this.groupBox1.Controls.Add(this.txt_DLNr);
            this.groupBox1.Controls.Add(this.txt_Vorname);
            this.groupBox1.Controls.Add(this.txt_Zuname);
            this.groupBox1.Controls.Add(this.lbl_DLNr);
            this.groupBox1.Controls.Add(this.lbl_Vorname);
            this.groupBox1.Controls.Add(this.lbl_Zuname);
            this.groupBox1.Controls.Add(this.lbl_SVNr);
            this.groupBox1.Location = new System.Drawing.Point(12, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(713, 211);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suchkriterien";
            // 
            // txt_datumswerte
            // 
            this.txt_datumswerte.BackColor = System.Drawing.SystemColors.Control;
            this.txt_datumswerte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_datumswerte.Enabled = false;
            this.txt_datumswerte.Location = new System.Drawing.Point(468, 46);
            this.txt_datumswerte.Name = "txt_datumswerte";
            this.txt_datumswerte.Size = new System.Drawing.Size(120, 13);
            this.txt_datumswerte.TabIndex = 18;
            this.txt_datumswerte.Text = "< 1930 - 2029 >";
            this.txt_datumswerte.Visible = false;
            // 
            // opt_MS
            // 
            this.opt_MS.AutoSize = true;
            this.opt_MS.Location = new System.Drawing.Point(414, 144);
            this.opt_MS.Name = "opt_MS";
            this.opt_MS.Size = new System.Drawing.Size(41, 17);
            this.opt_MS.TabIndex = 17;
            this.opt_MS.TabStop = true;
            this.opt_MS.Text = "MS";
            this.opt_MS.UseVisualStyleBackColor = true;
            this.opt_MS.Visible = false;
            // 
            // chk_sort
            // 
            this.chk_sort.AutoSize = true;
            this.chk_sort.Enabled = false;
            this.chk_sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.205F);
            this.chk_sort.Location = new System.Drawing.Point(293, 178);
            this.chk_sort.Name = "chk_sort";
            this.chk_sort.Size = new System.Drawing.Size(68, 17);
            this.chk_sort.TabIndex = 16;
            this.chk_sort.Text = "Sortieren";
            this.chk_sort.UseVisualStyleBackColor = true;
            this.chk_sort.Visible = false;
            this.chk_sort.CheckedChanged += new System.EventHandler(this.chk_sort_CheckedChanged);
            // 
            // txt_personid
            // 
            this.txt_personid.Location = new System.Drawing.Point(468, 99);
            this.txt_personid.Name = "txt_personid";
            this.txt_personid.Size = new System.Drawing.Size(256, 20);
            this.txt_personid.TabIndex = 14;
            this.txt_personid.Visible = false;
            // 
            // txt_pvs_id
            // 
            this.txt_pvs_id.Location = new System.Drawing.Point(468, 73);
            this.txt_pvs_id.Name = "txt_pvs_id";
            this.txt_pvs_id.Size = new System.Drawing.Size(244, 20);
            this.txt_pvs_id.TabIndex = 13;
            this.txt_pvs_id.Visible = false;
            // 
            // chk_ms
            // 
            this.chk_ms.AutoSize = true;
            this.chk_ms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.205F);
            this.chk_ms.Location = new System.Drawing.Point(292, 144);
            this.chk_ms.Name = "chk_ms";
            this.chk_ms.Size = new System.Drawing.Size(86, 17);
            this.chk_ms.TabIndex = 12;
            this.chk_ms.Text = "Mitschuldner";
            this.chk_ms.UseVisualStyleBackColor = true;
            this.chk_ms.CheckedChanged += new System.EventHandler(this.chk_ms_CheckedChanged);
            this.chk_ms.Enter += new System.EventHandler(this.chk_ms_Enter);
            this.chk_ms.Leave += new System.EventHandler(this.chk_ms_Leave);
            // 
            // mtxt_Gebdat
            // 
            this.mtxt_Gebdat.Location = new System.Drawing.Point(376, 47);
            this.mtxt_Gebdat.Mask = "00/00/0000";
            this.mtxt_Gebdat.Name = "mtxt_Gebdat";
            this.mtxt_Gebdat.Size = new System.Drawing.Size(80, 20);
            this.mtxt_Gebdat.TabIndex = 2;
            this.mtxt_Gebdat.ValidatingType = typeof(System.DateTime);
            this.mtxt_Gebdat.Enter += new System.EventHandler(this.mtxt_Gebdat_Enter);
            this.mtxt_Gebdat.Leave += new System.EventHandler(this.mtxt_Gebdat_Leave);
            // 
            // lbl_Gebdat
            // 
            this.lbl_Gebdat.Location = new System.Drawing.Point(256, 46);
            this.lbl_Gebdat.Name = "lbl_Gebdat";
            this.lbl_Gebdat.Size = new System.Drawing.Size(114, 20);
            this.lbl_Gebdat.TabIndex = 11;
            this.lbl_Gebdat.Text = "Geb.-Datum";
            this.lbl_Gebdat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmd_Leer
            // 
            this.cmd_Leer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.205F);
            this.cmd_Leer.Location = new System.Drawing.Point(594, 172);
            this.cmd_Leer.Name = "cmd_Leer";
            this.cmd_Leer.Size = new System.Drawing.Size(98, 23);
            this.cmd_Leer.TabIndex = 7;
            this.cmd_Leer.Text = "L&eere Maske";
            this.cmd_Leer.UseVisualStyleBackColor = true;
            this.cmd_Leer.Click += new System.EventHandler(this.cmd_Leer_Click);
            // 
            // cmd_Suche
            // 
            this.cmd_Suche.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.205F);
            this.cmd_Suche.Location = new System.Drawing.Point(457, 172);
            this.cmd_Suche.Name = "cmd_Suche";
            this.cmd_Suche.Size = new System.Drawing.Size(98, 23);
            this.cmd_Suche.TabIndex = 6;
            this.cmd_Suche.Text = "S&uche";
            this.cmd_Suche.UseVisualStyleBackColor = true;
            this.cmd_Suche.Click += new System.EventHandler(this.cmd_Suche_Click);
            // 
            // mtxt_SVNr
            // 
            this.mtxt_SVNr.Location = new System.Drawing.Point(150, 48);
            this.mtxt_SVNr.Mask = "9999-999999";
            this.mtxt_SVNr.Name = "mtxt_SVNr";
            this.mtxt_SVNr.Size = new System.Drawing.Size(100, 20);
            this.mtxt_SVNr.TabIndex = 1;
            this.mtxt_SVNr.Enter += new System.EventHandler(this.mtxt_SVNr_Enter);
            this.mtxt_SVNr.Leave += new System.EventHandler(this.mtxt_SVNr_Leave);
            // 
            // txt_DLNr
            // 
            this.txt_DLNr.Location = new System.Drawing.Point(150, 145);
            this.txt_DLNr.MaxLength = 11;
            this.txt_DLNr.Name = "txt_DLNr";
            this.txt_DLNr.Size = new System.Drawing.Size(100, 20);
            this.txt_DLNr.TabIndex = 5;
            this.txt_DLNr.Enter += new System.EventHandler(this.txt_DLNr_Enter);
            this.txt_DLNr.Leave += new System.EventHandler(this.txt_DLNr_Leave);
            this.txt_DLNr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_DLNr_MouseDown);
            // 
            // txt_Vorname
            // 
            this.txt_Vorname.Location = new System.Drawing.Point(150, 102);
            this.txt_Vorname.Name = "txt_Vorname";
            this.txt_Vorname.Size = new System.Drawing.Size(305, 20);
            this.txt_Vorname.TabIndex = 4;
            this.txt_Vorname.Enter += new System.EventHandler(this.txt_Vorname_Enter);
            this.txt_Vorname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Vorname_KeyPress);
            this.txt_Vorname.Leave += new System.EventHandler(this.txt_Vorname_Leave);
            // 
            // txt_Zuname
            // 
            this.txt_Zuname.Location = new System.Drawing.Point(150, 75);
            this.txt_Zuname.Name = "txt_Zuname";
            this.txt_Zuname.Size = new System.Drawing.Size(305, 20);
            this.txt_Zuname.TabIndex = 3;
            this.txt_Zuname.Enter += new System.EventHandler(this.txt_Zuname_Enter);
            this.txt_Zuname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Zuname_KeyPress);
            this.txt_Zuname.Leave += new System.EventHandler(this.txt_Zuname_Leave);
            // 
            // lbl_DLNr
            // 
            this.lbl_DLNr.Location = new System.Drawing.Point(6, 145);
            this.lbl_DLNr.Name = "lbl_DLNr";
            this.lbl_DLNr.Size = new System.Drawing.Size(120, 20);
            this.lbl_DLNr.TabIndex = 3;
            this.lbl_DLNr.Text = "Darlehens-Nr.:";
            this.lbl_DLNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Vorname
            // 
            this.lbl_Vorname.Location = new System.Drawing.Point(6, 101);
            this.lbl_Vorname.Name = "lbl_Vorname";
            this.lbl_Vorname.Size = new System.Drawing.Size(120, 20);
            this.lbl_Vorname.TabIndex = 2;
            this.lbl_Vorname.Text = "Vorname:";
            this.lbl_Vorname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_Zuname
            // 
            this.lbl_Zuname.Location = new System.Drawing.Point(6, 75);
            this.lbl_Zuname.Name = "lbl_Zuname";
            this.lbl_Zuname.Size = new System.Drawing.Size(120, 20);
            this.lbl_Zuname.TabIndex = 1;
            this.lbl_Zuname.Text = "Zuname:";
            this.lbl_Zuname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_SVNr
            // 
            this.lbl_SVNr.Location = new System.Drawing.Point(6, 48);
            this.lbl_SVNr.Name = "lbl_SVNr";
            this.lbl_SVNr.Size = new System.Drawing.Size(120, 20);
            this.lbl_SVNr.TabIndex = 0;
            this.lbl_SVNr.Text = "Soz. Vers.-Nr.:";
            this.lbl_SVNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lst_Output
            // 
            this.lst_Output.Location = new System.Drawing.Point(12, 299);
            this.lst_Output.MultiSelect = false;
            this.lst_Output.Name = "lst_Output";
            this.lst_Output.Size = new System.Drawing.Size(713, 195);
            this.lst_Output.TabIndex = 9;
            this.lst_Output.UseCompatibleStateImageBehavior = false;
            this.lst_Output.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lst_Output_ColumnClick);
            this.lst_Output.SelectedIndexChanged += new System.EventHandler(this.lst_Output_SelectedIndexChanged);
            this.lst_Output.Click += new System.EventHandler(this.lst_Output_Click);
            this.lst_Output.DoubleClick += new System.EventHandler(this.lst_Output_DoubleClick);
            // 
            // txt_output
            // 
            this.txt_output.Location = new System.Drawing.Point(12, 10);
            this.txt_output.Multiline = true;
            this.txt_output.Name = "txt_output";
            this.txt_output.Size = new System.Drawing.Size(158, 66);
            this.txt_output.TabIndex = 13;
            this.txt_output.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 500);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Schließen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmd_antrag
            // 
            this.cmd_antrag.Location = new System.Drawing.Point(480, 500);
            this.cmd_antrag.Name = "cmd_antrag";
            this.cmd_antrag.Size = new System.Drawing.Size(97, 23);
            this.cmd_antrag.TabIndex = 14;
            this.cmd_antrag.Text = "&Anträge";
            this.cmd_antrag.UseVisualStyleBackColor = true;
            this.cmd_antrag.Click += new System.EventHandler(this.cmd_antrag_Click);
            // 
            // cmd_std_neu
            // 
            this.cmd_std_neu.Location = new System.Drawing.Point(241, 500);
            this.cmd_std_neu.Name = "cmd_std_neu";
            this.cmd_std_neu.Size = new System.Drawing.Size(190, 23);
            this.cmd_std_neu.TabIndex = 15;
            this.cmd_std_neu.Text = "Stammdaten &neu anlegen";
            this.cmd_std_neu.UseVisualStyleBackColor = true;
            this.cmd_std_neu.Click += new System.EventHandler(this.cmd_std_neu_Click);
            // 
            // cmd_std_bearbeiten
            // 
            this.cmd_std_bearbeiten.Location = new System.Drawing.Point(12, 500);
            this.cmd_std_bearbeiten.Name = "cmd_std_bearbeiten";
            this.cmd_std_bearbeiten.Size = new System.Drawing.Size(190, 23);
            this.cmd_std_bearbeiten.TabIndex = 16;
            this.cmd_std_bearbeiten.Text = "Stammdaten &bearbeiten";
            this.cmd_std_bearbeiten.UseVisualStyleBackColor = true;
            this.cmd_std_bearbeiten.Click += new System.EventHandler(this.cmd_std_bearbeiten_Click);
            // 
            // cmd_reset
            // 
            this.cmd_reset.Location = new System.Drawing.Point(635, 12);
            this.cmd_reset.Name = "cmd_reset";
            this.cmd_reset.Size = new System.Drawing.Size(90, 23);
            this.cmd_reset.TabIndex = 17;
            this.cmd_reset.Text = "&Reset\r\n";
            this.cmd_reset.UseVisualStyleBackColor = true;
            this.cmd_reset.Click += new System.EventHandler(this.cmd_reset_Click);
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
            this.PVSTrace,
            this.labelDayDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 533);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(736, 29);
            this.statusStrip1.TabIndex = 40;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // strip_info
            // 
            this.strip_info.AutoSize = false;
            this.strip_info.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.strip_info.Name = "strip_info";
            this.strip_info.Size = new System.Drawing.Size(410, 24);
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
            this.lblLOCK.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.lblLOCK.Name = "lblLOCK";
            this.lblLOCK.Size = new System.Drawing.Size(14, 13);
            // 
            // lblINS
            // 
            this.lblINS.AutoSize = false;
            this.lblINS.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.lblINS.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblINS.DoubleClickEnabled = true;
            this.lblINS.Name = "lblINS";
            this.lblINS.Size = new System.Drawing.Size(40, 24);
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
            this.lblNUM.Size = new System.Drawing.Size(40, 24);
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
            this.lblCAPS.Size = new System.Drawing.Size(40, 24);
            this.lblCAPS.Text = "CAPS";
            this.lblCAPS.DoubleClick += new System.EventHandler(this.lblCAPS_DoubleClick);
            // 
            // lblCON
            // 
            this.lblCON.Name = "lblCON";
            this.lblCON.Size = new System.Drawing.Size(46, 24);
            this.lblCON.Text = "lblCON";
            // 
            // PVSTrace
            // 
            this.PVSTrace.AutoSize = false;
            this.PVSTrace.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.PVSTrace.Font = new System.Drawing.Font("Tahoma", 7F);
            this.PVSTrace.Margin = new System.Windows.Forms.Padding(4, 8, 4, 8);
            this.PVSTrace.Name = "PVSTrace";
            this.PVSTrace.Size = new System.Drawing.Size(14, 13);
            this.PVSTrace.Text = "T";
            // 
            // labelDayDate
            // 
            this.labelDayDate.Name = "labelDayDate";
            this.labelDayDate.Size = new System.Drawing.Size(0, 24);
            // 
            // cmd_leihgeld
            // 
            this.cmd_leihgeld.Location = new System.Drawing.Point(525, 12);
            this.cmd_leihgeld.Name = "cmd_leihgeld";
            this.cmd_leihgeld.Size = new System.Drawing.Size(90, 23);
            this.cmd_leihgeld.TabIndex = 42;
            this.cmd_leihgeld.Text = "&Leihgeld";
            this.cmd_leihgeld.UseVisualStyleBackColor = true;
            this.cmd_leihgeld.Click += new System.EventHandler(this.cmd_leihgeld_Click);
            // 
            // cmd_datentraeger
            // 
            this.cmd_datentraeger.Location = new System.Drawing.Point(415, 12);
            this.cmd_datentraeger.Name = "cmd_datentraeger";
            this.cmd_datentraeger.Size = new System.Drawing.Size(90, 23);
            this.cmd_datentraeger.TabIndex = 43;
            this.cmd_datentraeger.Text = "&Datenträger";
            this.cmd_datentraeger.UseVisualStyleBackColor = true;
            this.cmd_datentraeger.Click += new System.EventHandler(this.cmd_datentraeger_Click);
            // 
            // cmd_druck
            // 
            this.cmd_druck.Location = new System.Drawing.Point(305, 12);
            this.cmd_druck.Name = "cmd_druck";
            this.cmd_druck.Size = new System.Drawing.Size(90, 23);
            this.cmd_druck.TabIndex = 44;
            this.cmd_druck.Text = "Ser&iendruck";
            this.cmd_druck.UseVisualStyleBackColor = true;
            this.cmd_druck.Click += new System.EventHandler(this.cmd_druck_Click);
            // 
            // cmd_Auswertung
            // 
            this.cmd_Auswertung.Location = new System.Drawing.Point(190, 12);
            this.cmd_Auswertung.Name = "cmd_Auswertung";
            this.cmd_Auswertung.Size = new System.Drawing.Size(97, 23);
            this.cmd_Auswertung.TabIndex = 45;
            this.cmd_Auswertung.Text = "Aus&wertungen";
            this.cmd_Auswertung.UseVisualStyleBackColor = true;
            this.cmd_Auswertung.Click += new System.EventHandler(this.cmd_Auswertung_Click);
            // 
            // cmd_log
            // 
            this.cmd_log.Location = new System.Drawing.Point(98, 12);
            this.cmd_log.Name = "cmd_log";
            this.cmd_log.Size = new System.Drawing.Size(70, 23);
            this.cmd_log.TabIndex = 46;
            this.cmd_log.Text = "&Lo&g";
            this.cmd_log.UseVisualStyleBackColor = true;
            this.cmd_log.Click += new System.EventHandler(this.cmd_log_Click);
            // 
            // cmd_version
            // 
            this.cmd_version.Location = new System.Drawing.Point(12, 12);
            this.cmd_version.Name = "cmd_version";
            this.cmd_version.Size = new System.Drawing.Size(70, 23);
            this.cmd_version.TabIndex = 47;
            this.cmd_version.Text = "Inf&o";
            this.cmd_version.UseVisualStyleBackColor = false;
            this.cmd_version.Click += new System.EventHandler(this.cmd_version_Click);
            // 
            // frm_AK_Suche
            // 
            this.AcceptButton = this.cmd_Suche;
            this.ClientSize = new System.Drawing.Size(736, 562);
            this.Controls.Add(this.cmd_version);
            this.Controls.Add(this.cmd_log);
            this.Controls.Add(this.cmd_Auswertung);
            this.Controls.Add(this.cmd_druck);
            this.Controls.Add(this.cmd_datentraeger);
            this.Controls.Add(this.cmd_leihgeld);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmd_reset);
            this.Controls.Add(this.cmd_std_bearbeiten);
            this.Controls.Add(this.cmd_std_neu);
            this.Controls.Add(this.cmd_antrag);
            this.Controls.Add(this.txt_output);
            this.Controls.Add(this.lst_Output);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frm_AK_Suche";
            this.Text = "Suche für Wohnbaudarlehen";
            this.Activated += new System.EventHandler(this.frm_AK_Suche_Activated);
            this.Load += new System.EventHandler(this.frm_AK_Suche_Load);
            this.Enter += new System.EventHandler(this.frm_AK_Suche_Activated);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_AK_Suche_KeyUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 
    
# endregion



        private void frm_AK_Suche_Load(object sender, EventArgs e) //Wenn die Form geladen wurde
        {
            frm_Version frm_version = new frm_Version();
            frm_version.read_verion_info(sender, e);
            frm_version = null;

            AKK_Helper.FindControls(this);

            chk_sort.Visible = false;

            if (AKK_Helper.checkLogin() == true)
            {
                
                AKK_Helper.authService.getUser(out AKK_Helper.My_user, AKK_Helper.SessionToken);
                //

                Boolean canWrite = AKK_Helper.My_user.CanWrite;

                AKK_Helper.UserId = AKK_Helper.My_user.UserId.ToString();
                AKK_Helper.UserName = AKK_Helper.My_user.Username;
                AKK_Helper.PVSUserId = AKK_Helper.My_user.PvsUsername;
                AKK_Helper.PVSPW = AKK_Helper.My_user.PvsPassword;
                // 16-04-2012 KJ
                //
                try
                {
                    AKK_Helper.my_printer = AKK_Helper.My_user.Settings.First<KeyValuePair<string, string>>(a => a.Key == "PRINTER").Value;
                }
                catch
                {
                    AKK_Helper.my_printer = "";
                }

                opt_MS.Enabled = false;

                this.Cursor = Cursors.WaitCursor;
                this.LoadINI(AKK_Helper.SessionToken, this.str_scope);
                this.Cursor = Cursors.Default;

                // 07-12-2012 by KJ

                cmd_version.Enabled = false;
                cmd_Auswertung.Enabled = false;
                cmd_log.Enabled = false;
                cmd_druck.Enabled = false;
                cmd_datentraeger.Enabled = false;
                cmd_leihgeld.Enabled = false;
                cmd_reset.Enabled = false;
                cmd_std_bearbeiten.Enabled = false;
                cmd_std_neu.Enabled = false;

                if (AKK_Helper.My_user.CanWrite == true)
                {
                    cmd_version.Enabled = true;
                    cmd_Auswertung.Enabled = true;
                    cmd_log.Enabled = true;
                    cmd_druck.Enabled = true;
                    cmd_datentraeger.Enabled = true;
                    cmd_leihgeld.Enabled = true;
                    cmd_reset.Enabled = true;
                    cmd_std_bearbeiten.Enabled = true;
                    cmd_std_neu.Enabled = true;

                }
                else
                {    // CanWrite = False
                    if (AKK_Helper.My_user.CanRead == true)
                    {
                        if (AKK_Helper.C.strG_Suche_Info == AKK_Helper.c_Yes) cmd_version.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_Log == AKK_Helper.c_Yes) cmd_log.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_Auswertung == AKK_Helper.c_Yes) cmd_Auswertung.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_Seriendruck == AKK_Helper.c_Yes) cmd_druck.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_Datenträger == AKK_Helper.c_Yes) cmd_datentraeger.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_Leihgeld == AKK_Helper.c_Yes) cmd_leihgeld.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_Reset == AKK_Helper.c_Yes) cmd_reset.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_STD_Bearbeiten == AKK_Helper.c_Yes) cmd_std_bearbeiten.Enabled = true;
                        if (AKK_Helper.C.strG_Suche_STD_Neu == AKK_Helper.c_Yes) cmd_std_neu.Enabled = true;
                    }
                }
                // 16-04-2012 KJ
                //

                // Read Crystal Report User Info
                // User and Password in PVS-Credential
                //
                string crToken;
                AuthService.AuthServiceClient authClient = new AuthService.AuthServiceClient();
                AuthService.Response resp = authClient.doLogin(out  crToken, AKK_Helper.C.strG_CR_User, AKK_Helper.C.strG_CR_PW);
                AKK_Helper.CrToken = crToken;
                if (resp.ResponseCode != 0)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                    AKK_Helper.CrToken = "";
                    AKK_Helper.CrPW = "";
                    AKK_Helper.CrUser = "";
                }
                else
                {
                    AuthService.User crUser;
                    resp = authClient.getUser(out crUser, crToken);
                    if (resp.ResponseCode != 0)
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                        AKK_Helper.CrToken = "";
                        AKK_Helper.CrPW = "";
                        AKK_Helper.CrUser = "";
                    }
                    else
                    {
                        AKK_Helper.CrPW = crUser.PvsPassword;
                        AKK_Helper.CrUser = crUser.PvsUsername;
                    }
                }


                string crPVSToken;
                AuthService.AuthServiceClient authClientPVS = new AuthService.AuthServiceClient();
                AuthService.Response respPVS = authClient.doLogin(out  crPVSToken, AKK_Helper.C.strG_CRPVS_User, AKK_Helper.C.strG_CRPVS_PW);
                AKK_Helper.CrPVSToken = crPVSToken;
                if (respPVS.ResponseCode != 0)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                    AKK_Helper.CrPVSToken = "";
                    AKK_Helper.CrPVSPW = "";
                    AKK_Helper.CrPVSUser = "";
                }
                else
                {
                    AuthService.User crPVSUser;
                    resp = authClient.getUser(out crPVSUser, crPVSToken);
                    if (respPVS.ResponseCode != 0)
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(respPVS);
                        AKK_Helper.CrPVSToken = "";
                        AKK_Helper.CrPVSPW = "";
                        AKK_Helper.CrPVSUser = "";
                    }
                    else
                    {
                        AKK_Helper.CrPVSPW = crPVSUser.PvsPassword;
                        AKK_Helper.CrPVSUser = crPVSUser.PvsUsername;
                    }
                }

                strip_info.ForeColor = AKK_Helper.c_lost_focus;
                strip_info.Text = "Version " + AKK_Helper.obj_version.str_version + " Datum " + AKK_Helper.obj_version.str_version_date + "    " + AKK_Helper.UserName + " (" + AKK_Helper.UserId + ")";
                // 
                // read actual Version of ak_suche from DB
                // compare actual Version with db version
                // 
                DataService.Response resp1 = new DataService.Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                resp1 = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "VERC", "");
                DateTime dt_new = DateTime.Now;
                DateTime dt_act = DateTime.Now;
                string str_new = "01.01.2000";
                string str_ver = "";
                if (resp1.ResponseCode == 0)
                {
                    for (Int32 i = 0; i < cols.Count; i++)
                    {
                        if (cols[i].DM_col_01.ToString() != null)
                        {
                            str_new = cols[i].DM_col_01.ToString();    // Date
                        }
                        if (cols[i].DM_col_02.ToString() != null)
                        {
                            str_ver = cols[i].DM_col_02.ToString();    // Version
                        }
                    }
                    DateTime.TryParse(str_new, out dt_new);
                    DateTime.TryParse(AKK_Helper.obj_version.str_version_date, out dt_act);
                }
                if (dt_new > dt_act)
                {
                    strip_info.ForeColor = AKK_Helper.c_Version;
                    strip_info.Text = "Es gibt eine aktuellere Version : " + str_ver + " / " + str_new.Substring(0, 10);
                }
                else
                {
                    strip_info.ForeColor = AKK_Helper.c_lost_focus;
                    strip_info.Text = "Version " + AKK_Helper.obj_version.str_version + " Datum " + AKK_Helper.obj_version.str_version_date + "    " + AKK_Helper.UserName + " (" + AKK_Helper.UserId + ")";
                }

                // 
                // mtxt_SVNr.Text  = "5012-250667"; Erwin Raffler
                // txt_Zuname.Text = "KOHOUT";
                //txt_DLNr.Text = "01003045575";
                //txt_DLNr.Text = "09003230624";  
                //txt_DLNr.Text = "05001158440";
                //txt_DLNr.Text = "99002003186";
                //txt_DLNr.Text = "06003164746";
                //txt_DLNr.Text = "09002229193";
                //txt_DLNr.Text = "10003232323";
                //txt_DLNr.Text = "96438095729";
                // txt_Vorname.Text  = "Jürgen";
                // txt_DLNr.Text = "09002227816";

                this.Cursor = Cursors.Default;
                AKK_Helper.PVS_CON = new clsA_PVS_connection("PVS");
                //AKK_Helper.PVS_CON.Version = "2.8";
                //AKK_Helper.PVS_CON.CreatorName = "WBD";
                //AKK_Helper.PVS_CON.Nodename = "pvs";
                //AKK_Helper.PVS_CON.Databasename = "CONEXDBA";
                //AKK_Helper.PVS_CON.User = "SSCHMAUT";
                //AKK_Helper.PVS_CON.PW = "workflow";

                AKK_Helper.PVS_CON.Version = AKK_Helper.C.strG_PCI_Version;
                AKK_Helper.PVS_CON.CreatorName = AKK_Helper.C.strG_PCI_Creator;
                AKK_Helper.PVS_CON.Nodename = AKK_Helper.C.strG_PCI_Node;
                AKK_Helper.PVS_CON.Databasename = AKK_Helper.C.strG_PCI_DB;
                AKK_Helper.PVS_CON.User = AKK_Helper.PVSUserId;
                AKK_Helper.PVS_CON.PW = AKK_Helper.PVSPW;

                //AKK_Helper.PVS_CON.PW = "kohout";
                //AKK_Helper.PVS_CON.User = "SSCHMAUT";

                lst_Output.Clear();
                lst_Output.Columns.Add("Index", -1, HorizontalAlignment.Left);                 // 00
                lst_Output.Columns.Add("Nachname", 150, HorizontalAlignment.Left);             // 01
                lst_Output.Columns.Add("Vorname", 150, HorizontalAlignment.Left);              // 02
                lst_Output.Columns.Add("SVNr.", 100, HorizontalAlignment.Left);                // 03
                lst_Output.Columns.Add("Geschl.", 70, HorizontalAlignment.Left);               // 04
                lst_Output.Columns.Add("GebDat.", 80, HorizontalAlignment.Left);               // 05
                lst_Output.Columns.Add("PLZ", 60, HorizontalAlignment.Left);                   // 06
                lst_Output.Columns.Add("Ort", 100, HorizontalAlignment.Left);                  // 07
                lst_Output.Columns.Add("Strasse", 150, HorizontalAlignment.Left);              // 08
                lst_Output.Columns.Add("HausNr.", 100, HorizontalAlignment.Left);              // 09
                lst_Output.Columns.Add("Tuer", 100, HorizontalAlignment.Left);                 // 10
                lst_Output.Columns.Add("Titel", 100, HorizontalAlignment.Left);                // 11
                lst_Output.Columns.Add("Nation", 50, HorizontalAlignment.Left);                // 12
                lst_Output.Columns.Add("PVS_ID", 200, HorizontalAlignment.Left);               // 13
                lst_Output.Columns.Add("Person_ID", 100, HorizontalAlignment.Left);            // 14

                lst_Output.View = View.Details;
                lst_Output.Font = new Font(lst_Output.Font.FontFamily, AKK_Helper.FontSize);
                lst_Output.GridLines = true;
                lst_Output.LabelEdit = true;
                lst_Output.AllowColumnReorder = true;
                lst_Output.CheckBoxes = false;
                lst_Output.FullRowSelect = true;

                //foreach (ColumnHeader ch in lst_Output.Columns)
                //{
                //    // ch.Width = -2;
                //}

                mtxt_SVNr.Focus();

                //TEST DS 03.10.2018

                /*AKK_Helper.PVS_CON = new clsA_PVS_connection("PVS");

                AKK_Helper.PVS_CON.Version = AKK_Helper.C.strG_PCI_Version;
                AKK_Helper.PVS_CON.CreatorName = AKK_Helper.C.strG_PCI_Creator;
                AKK_Helper.PVS_CON.Nodename = AKK_Helper.C.strG_PCI_Node;
                AKK_Helper.PVS_CON.Databasename = AKK_Helper.C.strG_PCI_DB;
                AKK_Helper.PVS_CON.User = AKK_Helper.PVSUserId;
                AKK_Helper.PVS_CON.PW = AKK_Helper.PVSPW;




                //EXT Reference Errormeldungslösung
                AKK_Helper.PVS_CON.CreatorName = "WBD";*/

            }
            else {

                this.Close();

            }

           

            

            

            //
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            this.Close();
        }
        //
        // Strip Region
        // 
        #region strip and Keyboard
        private void lblINS_DoubleClick(object sender, EventArgs e)
        {
            AKK_Helper.set_insert(lblINS);
        }
        private void lblNUM_DoubleClick(object sender, EventArgs e)
        {
            AKK_Helper.set_numlock(lblNUM);
        }
        private void lblCAPS_DoubleClick(object sender, EventArgs e)
        {
            AKK_Helper.set_capslock(lblCAPS);
        }
        private void frm_AK_Suche_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        # endregion
        //
        // Colors
        //
# region Color
        private void txt_Vorname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Vorname.Text == "")
            {
                if (e.KeyChar != 8)
                {
                    String str = e.KeyChar.ToString();
                    txt_Vorname.SelectedText = str.ToUpper();
                    e.Handled = true;
                }
            }
        }

        private void cmd_Leer_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            mtxt_SVNr.Text = String.Empty;
            mtxt_Gebdat.Text = String.Empty;
            txt_Zuname.Text = String.Empty;
            txt_Vorname.Text = String.Empty;
            txt_DLNr.Text = String.Empty;
            chk_ms.Checked = false;
            opt_MS.Checked = false; 
            mtxt_SVNr.Focus();
            chk_ms.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void mtxt_SVNr_Enter(object sender, EventArgs e)
        {
            lbl_SVNr.ForeColor = AKK_Helper.c_get_focus;
        }

        private void mtxt_SVNr_Leave(object sender, EventArgs e)
        {
            //
            // masked field bbbb-bbbbbb
            // is checked for valid value
            // - means emplty !!!
            //
            lbl_SVNr.ForeColor = AKK_Helper.c_lost_focus;
            Boolean is_valid = true;
            if (mtxt_SVNr.Text.Trim() != "-")
            {
                if (mtxt_SVNr.Text.Length != 11)
                    is_valid = false;
            }

            if ((mtxt_SVNr.Text.Substring(0, 5) == "    -") & (mtxt_SVNr.Text.Length != 5))
                is_valid = false;
            if (is_valid == false)
            {
                this.Cursor = Cursors.Default;
                AKK_Helper.show_msg(AKK_Helper.str_error["FC007"], strip_info, this.Cursor);
                mtxt_SVNr.Focus();
                mtxt_SVNr.SelectAll();
            }
        }

        private void txt_Zuname_Enter(object sender, EventArgs e)
        {
            lbl_Zuname.ForeColor = AKK_Helper.c_get_focus;
        }

        private void txt_Zuname_Leave(object sender, EventArgs e)
        {
            lbl_Zuname.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void txt_Vorname_Enter(object sender, EventArgs e)
        {
            lbl_Vorname.ForeColor = AKK_Helper.c_get_focus;
        }

        private void txt_Vorname_Leave(object sender, EventArgs e)
        {
            lbl_Vorname.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void txt_DLNr_Leave(object sender, EventArgs e)
        {
            lbl_DLNr.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void txt_DLNr_Enter(object sender, EventArgs e)
        {
            lbl_DLNr.ForeColor = AKK_Helper.c_get_focus;
            txt_DLNr.SelectAll();
        }

        private void mtxt_Gebdat_Leave(object sender, EventArgs e)
        {

            lbl_Gebdat.ForeColor = AKK_Helper.c_lost_focus;
            if (AKK_Helper.is_date(mtxt_Gebdat.Text) == false)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC005"], strip_info, this.Cursor);
                mtxt_Gebdat.Focus();
                mtxt_Gebdat.SelectAll();
            }
            else 
            {
                if (mtxt_Gebdat.Text.Trim() != ".  .")
                {
                    DateTime dt;
                    DateTime.TryParse(mtxt_Gebdat.Text, out dt);
                    mtxt_Gebdat.Text = dt.ToShortDateString();
                }
            }
        }

        private void mtxt_Gebdat_Enter(object sender, EventArgs e)
        {
            lbl_Gebdat.ForeColor = AKK_Helper.c_get_focus;

        }

# endregion
       

        private void chk_ms_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ms.Checked == true)
            {
                //mtxt_SVNr.Text = string.Empty;
                txt_DLNr.Text = string.Empty;
                // mtxt_SVNr.Enabled = false;
                txt_DLNr.Enabled = false;
            }
            else
            {
                mtxt_SVNr.Enabled = true;
                txt_DLNr.Enabled = true;
            }
        }
        private void chk_ms_Enter(object sender, EventArgs e)
        {
            chk_ms.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_ms_Leave(object sender, EventArgs e)
        {
            chk_ms.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void txt_DLNr_MouseDown(object sender, MouseEventArgs e)
        {
            txt_DLNr.SelectAll();
        }
        private void lst_Output_DoubleClick(object sender, EventArgs e)
        {

            ListView lv = (ListView)sender;
            ListViewItem li = null;
            for (int i = lv.SelectedItems.Count - 1; i >= 0; i--)
            {
                li = lv.SelectedItems[i];
                i = 0;
            }
            DC_ak_suche obj_suche = new DC_ak_suche();
            obj_suche.DM_pvs_id = li.SubItems[13].Text.ToString();   // EXT_Doid 

            if (obj_suche .DM_pvs_id.Substring (3,2) == "AP" )
            {
                obj_suche.DM_is_MS = true;                        // Suche Antarge wo mitschuldner (AP) dabei ist 
                obj_suche.DM_pvs_ap = "-1";
                obj_suche.DM_bv_ikey = string.Empty;              // no Bankverbindung
                opt_MS.Checked = true;
                var_pvs_ap = obj_suche.DM_pvs_id;                 // Save MS

                Boolean is_ok = show_antrag_data(obj_suche, true);
                
            }
            else
                {
                    if (opt_MS.Checked == true)
                        obj_suche.DM_pvs_ap = var_pvs_ap;
                    
                    obj_suche.DM_is_MS = false;   // Suche Antrag von PE
                    // obj_suche.DM_is_AP = false;
                    Boolean is_ok = show_antrag_data(obj_suche, false);
                    
                }
        }
        private void lst_Output_Click(object sender, EventArgs e)
        {
            ListViewItem li = null;
            for (int i = lst_Output.SelectedItems.Count - 1; i >= 0; i--)
            {
                li = lst_Output.SelectedItems[i];
                i = 0;
            }
            txt_pvs_id.Text = li.SubItems[13].Text.ToString();
            txt_personid.Text = li.SubItems[14].Text.ToString();

            strip_info.Text = li.SubItems[1].Text.ToString() + " " +
                              li.SubItems[2].Text.ToString() + " " +
                              li.SubItems[3].Text.ToString() + " ";
            if (li.SubItems[13].Text.ToString().Substring(3, 2) == "AP") 
            {
                chk_ms.ForeColor = AKK_Helper.c_MS;
            }
            else
            {
                chk_ms.ForeColor = AKK_Helper.c_lost_focus;
            }
            this.Refresh();
            li = null;
        }
        //
        // Check Connection to PVS application
        // and if necessary establish new one
        //
        //public Boolean check_PVS()
        //{
        //    this.Cursor = Cursors.WaitCursor;
            
            
        //    if ((PVS_CON.PVS_APP == null ) || (PVS_CON.PVS_APP.Connected == false) )
        //    {
        //        PVS_CON.PVS_APP.CreatorPCIVersion = PVS_CON.Version;
        //        PVS_CON.PVS_APP.CreatorName = PVS_CON.CreatorName;
        //        PVS_CON.PVS_APP.NodeName = PVS_CON.Nodename;
        //        PVS_CON.PVS_APP.DatabaseName = PVS_CON.Databasename;
        //        PVS_CON.PVS_APP.Visible = false;
        //        PVS_CON.PVS_APP.Connect(PVS_CON .User , PVS_CON.PW);
        //        PVS_CON.PVS_APP.Visible = false;
        //    }
         
        //    //
        //    if (PVS_CON.PVS_APP.Connected == true) { lblCON.Text = "on"; }
        //    else lblCON.Text = "off";
        //    //
        //    this.Cursor = Cursors.Default;
        //    return PVS_CON.PVS_APP.Connected;
        //}
        void PVS_do_WE_OnUpdate()
        {
            try
            {
                Boolean is_ok = get_PVS_Data(PVS_do_WE);
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                //TEST DS 16.10.2018
                //AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.InnerException.Message.ToString(), strip_info, this.Cursor);
            }

        }
        public Boolean get_PVS_Data(Miracle.MPP.WebPCI.DataObject PVS_do )
        {

            ListViewItem LVI = new ListViewItem();
            LVI = AKK_Helper.get_PVS_Data_LVI(PVS_do);
            SetListbox(LVI);

            return true;
        }
        public Boolean get_PVS_Data_New(Miracle.MPP.WebPCI.DataObject PVS_do)
        {

            ListViewItem LVI = new ListViewItem();
            LVI = AKK_Helper.get_PVS_Data_LVI(PVS_do);
            SetListboxNew(LVI);

            return true;
        }

        delegate void SetLstCallback(ListViewItem LIV);
        private void SetListbox(ListViewItem LIV)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lst_Output.InvokeRequired)
            {
                SetLstCallback d = new SetLstCallback(SetListbox);
                this.Invoke(d, new object[] { LIV });
            }
            else
            {
                ListViewItem li = null;

                for (int i = lst_Output.SelectedItems.Count - 1; i >= 0; i--)
                {
                    li = lst_Output.SelectedItems[i];
                    lst_Output.SelectedItems[i].Remove();

                    string str_Index = li.SubItems[0].Text.ToString();
                    ListViewItem LVI_ORA = new ListViewItem(str_Index);
                    Int32 iCount = li.SubItems.Count;
                    for (Int32 ic = 1; ic < iCount; ic++)          // From 1 --> first Value ignored 
                    {
                        LVI_ORA.SubItems.Add(LIV.SubItems[ic]);
                    }

                    this.lst_Output.Items.Add(LVI_ORA);            // Add changed ListItem

                    lvwColumnSorter.SortColumn = 0;                // sort Index Column 
                    lvwColumnSorter.Order = SortOrder.Ascending;

                    this.lst_Output.Sort();
                    this.lst_Output.Refresh();

                    LVI_ORA.Selected = true;
                    lst_Output.Select();

                    str_Index = null;
                }
            }
        }
        private void SetListboxNew(ListViewItem LIV)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lst_Output.InvokeRequired )
            {
                SetLstCallback d = new SetLstCallback(SetListboxNew);
                this.Invoke(d, new object[] { LIV });
            }
            else
            {
                this.lst_Output.Items.Clear();
                this.lst_Output.Items.Add(LIV);
            }
        }

        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txt_output.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_output.Text = text;
            }
        }
        
        private void lst_Output_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lst_Output.Sort();

        }
        private void chk_sort_CheckedChanged(object sender, EventArgs e)
        {
            /*if (lst_Output.Items.Count > 0)
                if (chk_sort.Checked == true)
                    lst_Output.Columns[0].Width = 0;
                else
                    lst_Output.Columns[0].Width = -2;*/
        }
       
        void PVS_wnd_WE_OnAssign(object rows)
        {
            Miracle.MPP.WebPCI.Collection pvs_col = (Miracle.MPP.WebPCI.Collection)rows;
            foreach (Miracle.MPP.WebPCI.DataObject pvsdo in pvs_col)
            {

                try
                {
                    Boolean is_ok = get_PVS_Data_New(pvsdo);
                }
                catch (Exception ex)
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                    //TEST DS 16.10.2018
                   // AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.InnerException.Message.ToString(), strip_info, this.Cursor);
                }
            }
        }
   
        private void LoadINI( string sessionToken, string str_BZST)
        {
          if (AKK_Helper.checkLogin() == true)
          {
              try
              {

                  DC_Columns cols = new DC_Columns();
                  DataService.DataServiceClient client = new DataServiceClient();
                  Addit.AK.WBD.AK_Suche.DataService.Response resp =
                        client.get_Init(out cols, AKK_Helper.SessionToken, str_BZST);

                  if (resp.ResponseCode == 0)
                  {
                      Int32 int_col_count = cols.Count;

                      for (Int32 ix = 0; ix < int_col_count; ix++)
                      {
                          // if (cols[ix].DM_col_01.ToString() == "100") AKK_Helper.C.strG_AKApplikation = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "101") AKK_Helper.C.strG_AKApplikation = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "102") AKK_Helper.C.strG_BEZIRK = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "103") AKK_Helper.C.strG_CR_Ora_Instanc = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "104") AKK_Helper.C.strG_CRPVS_Ora_Instanc = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "103") AKK_Helper.C.strG_Vorlage = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "104") AKK_Helper.C.strG_Kontrolliste = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "105") AKK_Helper.C.strG_INET = cols[ix].DM_col_02;
                          // HLPFILEWBD=P:\AK\HELP\WBD.HTM      106     --> DTT
                          // HLPFILEDR=P:\AK\HELP\DRUCK.HTM     107     --> DTT
                          // HLPFILEUG=P:\AK\HELP\URGENZ.HTM    108     --> DTT
                          // HLPFILEMAHN=P:\AK\HELP\MAHN.HTM    109     --> DTT
                          // HLPFILELFZ=P:\AK\HELP\LAUFZ.HTM    110     --> DTT
                          // HLPFILETEIL=P:\AK\HELP\TEILEN.HTM  111     --> DTT müssen noch implementiert werden !!! 09-02-2011
                          // HLPFILEMB=P:\AK\HELP\BUCHEN.HTM    112     --> sin für Datenträger . . . 
                          // if (cols[ix].DM_col_01.ToString() == "113") AKK_Helper.C.strG_DTT_DIR_ORI = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "114") AKK_Helper.C.strG_DTT_DIR_SAV = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "115") AKK_Helper.C.strG_DTT_DIR_PRO = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "116") AKK_Helper.C.strG_CR_User = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "117") AKK_Helper.C.strG_CR_PW = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "118") AKK_Helper.C.strG_CRPVS_User = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "119") AKK_Helper.C.strG_CRPVS_PW = cols[ix].DM_col_02;

                          // if (cols[ix].DM_col_01.ToString() == "118") AKK_Helper.C.strFileG_MS2 = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "119") AKK_Helper.C.strFileG_MS3 = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "120") AKK_Helper.C.strFileG_MSB = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "121") AKK_Helper.C.strG_DSN = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "122") AKK_Helper.C.strG_UID = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "123") AKK_Helper.C.strG_PWD = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "124") AKK_Helper.C.strG_PVS_DSN = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "125") AKK_Helper.C.strG_PVS_UID = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "126") AKK_Helper.C.strG_PVS_PWD = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "127") AKK_Helper.C.strTILG_O_LZV = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "128") AKK_Helper.C.strSENK_O_LZV = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "129") AKK_Helper.C.strTILG_M_LZV = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "130") AKK_Helper.C.strSENK_M_LZV = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "131") AKK_Helper.C.strSOLL_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "132") AKK_Helper.C.strHABEN_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "133") AKK_Helper.C.strVIGEN_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "134") AKK_Helper.C.strURG_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "135") AKK_Helper.C.strABL_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "136") AKK_Helper.C.strLEER_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "137") AKK_Helper.C.strBEARBEITEN_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "138") AKK_Helper.C.strPOS_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "139") AKK_Helper.C.strGEN_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "140") AKK_Helper.C.strGEN_ALL_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "141") AKK_Helper.C.strKLGEN_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "142") AKK_Helper.C.strKLGENGES_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "143") AKK_Helper.C.strG_WBD_MN1 = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "144") AKK_Helper.C.strG_WBD_MN2 = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "145") AKK_Helper.C.strG_WBD_MN3 = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "146") AKK_Helper.C.strG_WBD_MN4 = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "147") AKK_Helper.C.strG_WBD_RZ = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "148") AKK_Helper.C.strG_WBD_GEKL = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "149") AKK_Helper.C.strG_MethodeID = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "150") AKK_Helper.C.strG_TemplateID = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "151") AKK_Helper.C.strRCK_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "152") AKK_Helper.C.strTILG_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "153") AKK_Helper.C.strÜBERZ_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "154") AKK_Helper.C.strRST_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "155") AKK_Helper.C.strZIN_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "156") AKK_Helper.C.strSTORNO_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "157") AKK_Helper.C.strSPLIT_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "158") AKK_Helper.C.strBAR_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "159") AKK_Helper.C.intSPLIT_KEY = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "160") AKK_Helper.C.strBereichKey = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "161") AKK_Helper.C.strEIGEN_CODE = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "162") AKK_Helper.C.strSANIERUNG_CODE = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "163") AKK_Helper.C.strWOHNUNG_CODE = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "164") AKK_Helper.C.strALTERNATIV_CODE = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "165") AKK_Helper.C.strALLE_CODE = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "166") AKK_Helper.C.strG_WW = cols[ix].DM_col_02;
                          // #WW                                167
                          // WW                                 168
                          // #DDE_PRINT                         169
                          // #DDE_PRINT_EXT1                    170
                          // #DDE_PRINT_EXT2                    171
                          // #DDE_PRINT_EXT                     172
                          // DDE_PRINT                          173
                          // DDE_PRINT_EXT1                     174
                          // DDE_PRINT_EXT2                     175
                          // DDE_PRINT_EXT                      176
                          //if (cols[ix].DM_col_01.ToString() == "177") AKK_Helper.C.strG_AnredeMann = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "178") AKK_Helper.C.strG_AnredeFrau = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "179") AKK_Helper.C.strG_CodeMann = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "180") AKK_Helper.C.strG_CodeFrau = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "181") AKK_Helper.C.strG_PCI_DB = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "182") AKK_Helper.C.strG_PCI_Creator = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "183") AKK_Helper.C.strG_PCI_Version = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "184") AKK_Helper.C.strG_PCI_Node = cols[ix].DM_col_02;
                          // if (cols[ix].DM_col_01.ToString() == "185") AKK_Helper.C.strVisible = cols[ix].DM_col_02;

                          //if (cols[ix].DM_col_01.ToString() == "186") AKK_Helper.C.strG_HOST = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "187") AKK_Helper.C.strG_PORT = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "188") AKK_Helper.C.strG_USER = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "189") AKK_Helper.C.strG_PWRD = cols[ix].DM_col_02;
                          //if (cols[ix].DM_col_01.ToString() == "190") AKK_Helper.C.strG_SID = cols[ix].DM_col_02;
                          //// WBD_DRUCK
                          if (cols[ix].DM_col_01.ToString() == "191") AKK_Helper.C.strG_SWBD_IB = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "192") AKK_Helper.C.strG_SWBD_NG = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "193") AKK_Helper.C.strG_SWBD_PO = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "194") AKK_Helper.C.strG_SWBD_UG = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "195") AKK_Helper.C.strG_SWBD_VZ = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "196") AKK_Helper.C.strG_SWBD_TL = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "197") AKK_Helper.C.strG_SWBD_UZ = cols[ix].DM_col_02;
                          //
                          if (cols[ix].DM_col_01.ToString() == "201") AKK_Helper.C.strG_WBD_RZ05 = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "202") AKK_Helper.C.strSDAT = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "203") AKK_Helper.C.strKontoBlattLG = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "204") AKK_Helper.C.strVIGENGES_CODE = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "205") AKK_Helper.C.strKontoBlatt = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "206") AKK_Helper.C.strMLPfad = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "207") AKK_Helper.C.strExportPfad = cols[ix].DM_col_02;
                          if (cols[ix].DM_col_01.ToString() == "208") AKK_Helper.C.strG_SSO_PVS = cols[ix].DM_col_02.ToUpper();   // Single Sign On


                        if (cols[ix].DM_col_01.ToString() == "209") AKK_Helper.C. strG_Suche_Info  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "210") AKK_Helper.C. strG_Suche_Log  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "211") AKK_Helper.C. strG_Suche_Auswertung  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "212") AKK_Helper.C. strG_Suche_Seriendruck  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "213") AKK_Helper.C. strG_Suche_Datenträger  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "214") AKK_Helper.C. strG_Suche_Leihgeld  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "215") AKK_Helper.C. strG_Suche_Reset  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "216") AKK_Helper.C. strG_Suche_STD_Bearbeiten  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "217") AKK_Helper.C. strG_Suche_STD_Neu  = cols[ix].DM_col_02.ToUpper();   

                        if (cols[ix].DM_col_01.ToString() == "218") AKK_Helper.C. strG_Antrag_Bankverbindung  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "219") AKK_Helper.C. strG_Antrag_Mitschuldner  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "220") AKK_Helper.C. strG_Antrag_Status_ändern  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "221") AKK_Helper.C. strG_Antrag_Urgenz  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "222") AKK_Helper.C. strG_Antrag_Mahnstatus  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "223") AKK_Helper.C. strG_Antrag_Kontenblatt  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "224") AKK_Helper.C. strG_Antrag_Drucken  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "225") AKK_Helper.C. strG_Antrag_Speichern  = cols[ix].DM_col_02.ToUpper();
                        if (cols[ix].DM_col_01.ToString() == "236") AKK_Helper.C. strG_Urgenz_Urgenz_Speichern = cols[ix].DM_col_02.ToUpper();   

                        if (cols[ix].DM_col_01.ToString() == "227") AKK_Helper.C. strG_Bankverbindung_AUS_Bank  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "228") AKK_Helper.C. strG_Bankverbindung_AUS_Übernehmen  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "229") AKK_Helper.C. strG_Bankverbindung_AUS_Speichern  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "230") AKK_Helper.C. strG_Bankverbindung_AUS_Löschen  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "231") AKK_Helper.C. strG_Bankverbindung_EIN_Bank  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "232") AKK_Helper.C. strG_Bankverbindung_EIN_Speichern  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "233") AKK_Helper.C. strG_Bankverbindung_EIN_Löschen  = cols[ix].DM_col_02.ToUpper();   

                        if (cols[ix].DM_col_01.ToString() == "234") AKK_Helper.C. strG_Mitschuldner_Ändern  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "235") AKK_Helper.C. strG_Mitschuldner_Suchen  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "236") AKK_Helper.C. strG_Mitschuldner_Aktualisieren  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "237") AKK_Helper.C. strG_Mitschuldner_Speichern  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "238") AKK_Helper.C. strG_Mitschuldner_Löschen  = cols[ix].DM_col_02.ToUpper();   

                        if (cols[ix].DM_col_01.ToString() == "239") AKK_Helper.C. strG_Kontoblatt_Drucken  = cols[ix].DM_col_02.ToUpper();   
                        if (cols[ix].DM_col_01.ToString() == "240") AKK_Helper.C. strG_Kontoblatt_Manuell_Buchen  = cols[ix].DM_col_02.ToUpper();
                        if (cols[ix].DM_col_01.ToString() == "241") AKK_Helper.C.strG_Info_Antrag_Neu = cols[ix].DM_col_02.ToUpper();
                        if (cols[ix].DM_col_01.ToString() == "242") AKK_Helper.C.strG_Info_Stammdaten_Bearbeiten = cols[ix].DM_col_02.ToUpper();

                        if (cols[ix].DM_col_01.ToString() == "243") AKK_Helper.C.strGEN_ISH_CODE = cols[ix].DM_col_02;

                        if (cols[ix].DM_col_01.ToString() == "244") AKK_Helper.C.strG_SISH_IB = cols[ix].DM_col_02;
                        if (cols[ix].DM_col_01.ToString() == "245") AKK_Helper.C.strG_SISH_NG = cols[ix].DM_col_02;
                        if (cols[ix].DM_col_01.ToString() == "246") AKK_Helper.C.strG_SISH_PO = cols[ix].DM_col_02;
                        if (cols[ix].DM_col_01.ToString() == "247") AKK_Helper.C.strG_SISH_UG = cols[ix].DM_col_02;
                        if (cols[ix].DM_col_01.ToString() == "248") AKK_Helper.C.strG_SISH_VZ = cols[ix].DM_col_02;
                        if (cols[ix].DM_col_01.ToString() == "249") AKK_Helper.C.strG_SISH_TL = cols[ix].DM_col_02;
                        if (cols[ix].DM_col_01.ToString() == "250") AKK_Helper.C.strG_SISH_UZ = cols[ix].DM_col_02;

                        if (cols[ix].DM_col_01.ToString() == "251") AKK_Helper.C.strG_Print_Temp = cols[ix].DM_col_02;


                      }
//                      // C.strG_AK_Connection = "Data Source=" + C.strG_DSN + ";User Id=" + C.strG_UID + ";Password=" + C.strG_PWD;
                  //    AKK_Helper.C.strG_AK_Connection = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(";
                  //    AKK_Helper.C.strG_AK_Connection = AKK_Helper.C.strG_AK_Connection + "HOST=" + AKK_Helper.C.strG_HOST;                                            // 10.140.4.131
                  //    AKK_Helper.C.strG_AK_Connection = AKK_Helper.C.strG_AK_Connection + ")(PORT=" + AKK_Helper.C.strG_PORT;                                         // 1521
                  //    AKK_Helper.C.strG_AK_Connection = AKK_Helper.C.strG_AK_Connection + ")))(CONNECT_DATA=(SERVER=dedicated)(SERVICE_NAME=" + AKK_Helper.C.strG_SID; // pvss9i
                  //    AKK_Helper.C.strG_AK_Connection = AKK_Helper.C.strG_AK_Connection + ")));User Id=" + AKK_Helper.C.strG_USER;                                     // workflow
                  //    AKK_Helper.C.strG_AK_Connection = AKK_Helper.C.strG_AK_Connection + ";Password=" + AKK_Helper.C.strG_PWRD;                                       // addit
                  //    AKK_Helper.C.strG_AK_Connection = AKK_Helper.C.strG_AK_Connection + ";";
                  }
                  else
                  {
                      this.Cursor = Cursors.Default;
                      AKK_Helper.handleServiceError(resp);
                  }

              }
              catch (Exception ex)
              {
                  AKK_Helper.show_msg("Fehler beim lesen WBD_Config - " + ex.Message.ToString (), strip_info, this.Cursor);
              }
          }
       }
        public Boolean show_antrag_data(DC_ak_suche obj_suche, Boolean is_Suche)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                try
                {
                    DC_get_person_antrag cgpa = new DC_get_person_antrag();
                    DataService.DataServiceClient client = new DataServiceClient();

 

                    Addit.AK.WBD.AK_Suche.DataService.Response resp = client.Get_Person_List(out cgpa, obj_suche, AKK_Helper.SessionToken);
                    if (resp.ResponseCode == 0)
                    {
                        Int32 int_ant_count = cgpa.obj_lst_ak_antraege.Count;
                        Int32 int_per_count = cgpa.obj_lst_ak_person.Count;
                        //
                        if (int_per_count > 0)    // Any records found
                        {
                            if (is_Suche == true)
                            {
                                txt_output.Text = String.Empty;
                                lst_Output.Items.Clear();
                                strip_info.Text = int_per_count.ToString() + " Einträge gefunden";
                                //
                                #region 1
                                for (int i = 0; i < int_per_count; i++)
                                {
                                    ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_nachname);       // 1
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_vorname);        // 2
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_svnr);           // 3
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_geschlecht);     // 4
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_gebdat);         // 5
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_plz);            // 6
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_ortname);        // 7
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_strassename);    // 8
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_hausnr);         // 9
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_tuer);           // 10
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_akadtitelid);    // 11
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_nationid);       // 12
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_PVS_ID);         // 13
                                    LVI_ORA.SubItems.Add(cgpa.obj_lst_ak_person[i].DM_person_id);      // 14

                                    lst_Output.Items.Add(LVI_ORA);
                                    LVI_ORA = null;
                                }
                                //
                                // Lod Antraege
                                //
                                if (int_ant_count > 0)    // Any records found
                                {
                                    for (int i = 0; i < int_ant_count; i++)
                                    {
                                        txt_output.Text = txt_output.Text
                                                        + cgpa.obj_lst_ak_antraege[i].DM_ant_ikey + " "
                                                        + cgpa.obj_lst_ak_antraege[i].DM_std_extdoid_fkey + "  "
                                                        + cgpa.obj_lst_ak_antraege[i].DM_ant_verst_am + "\r\n";
                                    }
                                }


                                if (int_ant_count > 0)    // Any records found
                                {
                                    for (int i = 0; i < int_ant_count; i++)
                                    {
                                        txt_output.Text = txt_output.Text
                                                        + cgpa.obj_lst_ak_antraege[i].DM_ant_ikey + " "
                                                        + cgpa.obj_lst_ak_antraege[i].DM_std_extdoid_fkey + "  "
                                                        + cgpa.obj_lst_ak_antraege[i].DM_ant_verst_am + "\r\n";
                                    }
                                }
                                #endregion
                            }
                            //
                            // Only one Antrag --> show immediate
                            //  
                            if (int_per_count == 1)
                            {
                                strip_info.Text =
                                    cgpa.obj_lst_ak_person[0].DM_svnr + " " +
                                    cgpa.obj_lst_ak_person[0].DM_nachname + " " +
                                    cgpa.obj_lst_ak_person[0].DM_vorname;

                                frm_Antraege frm_antraege = new frm_Antraege();
                                frm_antraege.obj_ak_Per_Ant = cgpa;
                                // frm_antraege.obj_version = obj_version;
                                frm_antraege.PVS_CON = AKK_Helper.PVS_CON;
                                frm_antraege.ShowDialog();
                                frm_antraege = null;
                            }
                        }
                        else
                        {
                            AKK_Helper.show_msg(AKK_Helper.str_error["FC002"], strip_info, this.Cursor);
                            lst_Output.Items.Clear();
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                }
                catch (Exception ex)
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                    //TEST DS 16.10.2018
                    //TODO weg
                  //  AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.InnerException.Message.ToString(), strip_info, this.Cursor);
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        private void cmd_Suche_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {

                lst_Output.Items.Clear();
                this.Cursor = Cursors.WaitCursor;

                strip_info.Text = AKK_Helper.str_error["FC006"];
                this.Refresh();

                Boolean is_valid = true;
                DC_ak_suche obj_suche = new DC_ak_suche();

                opt_MS.Checked = false;
                var_pvs_ap = "-1";
                obj_suche.DM_pvs_ap = "-1";
                obj_suche.DM_is_MS = chk_ms.Checked;   // for Name, SVNR, ExtKEY
                chk_ms.ForeColor = AKK_Helper.c_lost_focus;

                if (txt_DLNr.Text != "")
                { obj_suche.DM_DarlNr = txt_DLNr.Text; }
                else
                {
                    if (mtxt_SVNr.Text != "    -")
                        if (mtxt_SVNr.Text.Length == 11)
                        {
                            obj_suche.DM_svnr = mtxt_SVNr.Text.Substring(0, 4) + mtxt_SVNr.Text.Substring(5, 6);
                        }
                        else
                        {
                            AKK_Helper.show_msg("SVNr muss 10 stellig sein", strip_info, this.Cursor);
                            is_valid = false;
                            mtxt_SVNr.Focus ();
                        }
                        else
                        {
                            if (txt_Vorname.TextLength == 0 & txt_Zuname.TextLength == 0)
                            {
                                is_valid = false;
                                AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                                if (chk_ms.Checked == true)
                                    txt_Zuname.Focus();
                                else
                                    mtxt_SVNr.Focus();

                            }
                            else
                            {
                                if ((txt_Zuname.TextLength == 0) & (txt_Vorname.TextLength != 0))
                                {
                                    is_valid = false;
                                    AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                                    txt_Vorname.Focus();
                                }
                                {
                                    obj_suche.DM_vorname = txt_Vorname.Text;
                                    obj_suche.DM_zuname = txt_Zuname.Text.ToUpper();
                                    if (mtxt_Gebdat.Text == "  .  .")
                                        obj_suche.DM_gebdat = "";
                                    else
                                        obj_suche.DM_gebdat = mtxt_Gebdat.Text;
                                }
                            }

                        }

                }
                if (is_valid == true)
                {
                    obj_suche.DM_bv_ikey = string.Empty;                 // no Bankverbindung
                    Boolean is_ok = show_antrag_data(obj_suche, true);
                }
                strip_info.Text = lst_Output.Items.Count.ToString() + " Einträge gefunden";
                this.Refresh();

                //lst_Output.Columns.Add("Nachname", 00, HorizontalAlignment.Left);
                //lst_Output.Columns.Add("Vorname", 00, HorizontalAlignment.Left);
                //LoadINI(sessionToken, str_BZST);
                //lst_Output.View = View.List;
                /*lst_Output.Columns.Clear();
                lst_Output.Columns.Add("ID", 00, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Nachname", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Vorname", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("SVNr.", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Geschlecht", 25, HorizontalAlignment.Left);
                lst_Output.Columns.Add("GebDat.", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("PLZ", 40, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Ort", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Strasse", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("HausNr.", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Tuer", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Titel", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Nation", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("PVS_ID", 100, HorizontalAlignment.Left);
                lst_Output.Columns.Add("Person_ID", 100, HorizontalAlignment.Left);
                lst_Output.View = View.Details;
                lst_Output.FullRowSelect = true;
                lst_Output.GridLines = true;
                this.Refresh();*/
                this.Cursor = Cursors.Default;
            }
        }
        private void cmd_std_bearbeiten_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            try
            {
                //
                // enable PVS Windows 
                //
                this.Cursor = Cursors.WaitCursor;
                //
                if (txt_personid.Text != "")
                {
                    strip_info.Text = txt_personid.Text + " : Personenverwaltung wird gestartet . . .";
                   
                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {
                   
                        string str_where = "PersonID = " + txt_personid.Text;
                        Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere("PE", str_where, null, null);
                        if (pvs_col.Count > 0)
                        {
                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                            {
                                try
                                {
                                    PVS_do_WE = pvs_do;                // Create Dataobject
                                    PVS_do_WE.OnUpdate += new Miracle.MPP.WebPCI.DataObject.OnUpdateEventHandler(PVS_do_WE_OnUpdate);
                                    // 
                                    PVS_wnd_WE = pvs_do.Edit();    // Create Window
                                    PVS_wnd_WE.SetAssignMode("addIT", false);
                                    PVS_wnd_WE.Activate();         // activate Window 
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                                    //TEST DS 16.10.2018
                                   // AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.InnerException.Message.ToString(), strip_info, this.Cursor);
                                }
                            }
                        }
                        else
                        {
                            AKK_Helper.show_msg("Keine Daten für PersonID=" + txt_personid.Text, strip_info, this.Cursor);
                        }
                    }
                }
                else
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                }
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + ex.InnerException, strip_info, this.Cursor);
            }
            strip_info.Text = "";
            this.Cursor = Cursors.Default;
        }
        private void cmd_antrag_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {

                if (lst_Output.SelectedItems.Count >= 1)
                {
                    lst_Output_DoubleClick(lst_Output, e);

                    //ListViewItem li = null;
                    //for (int i = lst_Output.SelectedItems.Count - 1; i >= 0; i--)
                    //{
                    //    li = lst_Output.SelectedItems[i];
                    //    i = 0;
                    //}
                    //// string x13 = li.SubItems[13].Text.ToString();

                    //DC_ak_suche obj_suche = new DC_ak_suche();
                    //obj_suche.DM_pvs_id = li.SubItems[13].Text.ToString();   // Int Doid 
                    //if (obj_suche.DM_pvs_id.Substring(3, 2) == "AP")
                    //{
                    //    obj_suche.DM_is_MS = true;    // Suche Antarge wo mitschuldner (AP) dabei ist 
                    //}
                    //else
                    //{
                    //    obj_suche.DM_is_MS = false;   // Suche Antrag von PE
                    //}
                    //Boolean is_ok = show_antrag_data(obj_suche,false);
                }
                else
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC004"], strip_info, this.Cursor);
                }

            }
        }
        private void cmd_reset_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Reset frm_reset = new frm_Reset();
                frm_reset.ShowDialog();
            }
        }
        private void cmd_std_neu_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            try
            {
                this.Cursor = Cursors.WaitCursor;
                strip_info.Text = "Personenverwaltung wird gestartet . . .";
                if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                {
                    PVS_wnd_WE = AKK_Helper.PVS_CON.PVS_APP.OpenWindow("PE", "LIST");
                    PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                    PVS_wnd_WE.SetAssignMode("addIT", false);
                    // PVS_wnd_WE.SetNewMode(); 09-07-2012 by KJ 4

                    // PVS_wnd_WE.SearchCondition = "Nachname='" + "3X'";
                    // PVS_wnd_WE.Read();

                    PVS_wnd_WE.Activate();         // activate Window 
                }
            }
            catch (Exception ex)
            {
               
                AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + ex.InnerException , strip_info, this.Cursor);
            }

            strip_info.Text = "";
            this.Cursor = Cursors.Default;
        }
        private void cmd_leihgeld_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Leihgeld frm_leihgeld = new frm_Leihgeld();
                frm_leihgeld.ShowDialog();
            }
        }
        private void cmd_datentraeger_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Datentraeger frm_datentraeger = new frm_Datentraeger();
                frm_datentraeger.ShowDialog();
            }
        }
        private void cmd_druck_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Seriendruck frm_seriendruck = new frm_Seriendruck();
                frm_seriendruck.ShowDialog();
            }
        }

        private void cmd_Auswertung_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Auswertung frm_auswertung = new frm_Auswertung();
                frm_auswertung.ShowDialog();
            }
        }

        private void cmd_log_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Log frm_log = new frm_Log();
                frm_log.ShowDialog();
            }
        }

        private void cmd_version_Click(object sender, EventArgs e)
        {
            strip_info.ForeColor = AKK_Helper.c_lost_focus; 
            if (AKK_Helper.checkLogin() == true)
            {
                frm_Version frm_version = new frm_Version();
                frm_version.ShowDialog();
            }
        }

        private void txt_Zuname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txt_Zuname.Text == "")
            {
                if (e.KeyChar != 8)
                {
                    String str = e.KeyChar.ToString();
                    txt_Zuname.SelectedText = str.ToUpper();
                    e.Handled = true;
                }
            }
        }

        private void lst_Output_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

       
      
       

    }    // Class
}        // Namespace


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Runtime.Serialization;
using Addit.AK.WBD.AK_Suche.DataService;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Konto : Form
    {
        public string str_antragsteller;
        public string str_rueck_ab;
        public string str_rueck_bis_real;
        public string str_rueck_bis_vertr;
        public string str_darlehensnr;
        public string str_d_betr;
        public string str_rate;
        public string str_anzahl;
        public string str_konto_real;
        public string str_konto_vert;
        public string str_WBDIkey;
        public string AntId;

        //David Stefitz 05.02.2019 Änderung bei ISH
        public bool bool_ish;


        public DC_wbd_antrag antrag;



        public frm_Konto()
        {
            InitializeComponent();
        }

        private void Konto_Load(object sender, EventArgs e)
        {

        //public string strG_Kontoblatt_Manuell_Buchen { set; get; }
        //public string strG_Kontoblatt_Drucken { set; get; }   


            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_buchen.Enabled = true;
                cmd_drucken.Enabled = true;
            }
            else
            {
                cmd_buchen.Enabled = false;
                cmd_drucken.Enabled = false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Kontoblatt_Manuell_Buchen == AKK_Helper.c_Yes )   cmd_buchen.Enabled = true;
                    if (AKK_Helper.C.strG_Kontoblatt_Drucken == AKK_Helper.c_Yes ) cmd_drucken.Enabled = true;
                }
            }

            if (AKK_Helper.checkLogin() == true)
            {
                AKK_Helper.FindControls(this);

                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                //
                this.Cursor = Cursors.WaitCursor;
                //
                mtxt_rueck_ab.Mask = @"00\.00\.0000";
                mtxt_rueck_bis_real.Mask = @"00\.00\.0000";
                mtxt_rueck_bis_vertr.Mask = @"00\.00\.0000";
                //
                // Alle felder diablen
                //
                mtxt_rueck_ab.Enabled = false;
                mtxt_rueck_bis_real.Enabled = false;
                mtxt_rueck_bis_vertr.Enabled = false;

                txt_antragsteller.Enabled = false;
                txt_darlehensnr.Enabled = false;
                txt_d_betr.Enabled = false;
                txt_rate.Enabled = false;
                txt_anzahl.Enabled = false;
                txt_konto_real.Enabled = false;
                txt_konto_vert.Enabled = false;

                if (bool_ish)
                {
                    
                    //David Stefitz 05.02.2019 Andere Label Bezeichnung für ISH 
                    //mtxt_rueck_ab.Visible = false;
                    label9.Text = "Laufzeit";
                    //label8.Visible = false;

                }
               
                mtxt_rueck_ab.Text = str_rueck_ab;

               
                txt_antragsteller.Text = str_antragsteller;
                
                mtxt_rueck_bis_real.Text = str_rueck_bis_real;
                mtxt_rueck_bis_vertr.Text = str_rueck_bis_vertr;
                txt_darlehensnr.Text = str_darlehensnr;
                txt_d_betr.Text = str_d_betr;
                txt_rate.Text = str_rate;
                txt_anzahl.Text = str_anzahl;
                txt_konto_real.Text = AKK_Helper.FormatBetragPlus(str_konto_real);
                txt_konto_vert.Text = AKK_Helper.FormatBetragPlus(str_konto_vert);
                //
                // Init Tilgungsstatus
                //
                lst_Tilgungsstatus.Clear();

                lst_Tilgungsstatus.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 0
                lst_Tilgungsstatus.Columns.Add("Status", 300, HorizontalAlignment.Left);                // 1
                lst_Tilgungsstatus.Columns.Add("von", 90, HorizontalAlignment.Left);                    // 2
                lst_Tilgungsstatus.Columns.Add("bis", 90, HorizontalAlignment.Left);                    // 3
                lst_Tilgungsstatus.Columns.Add("Rückstandstilgung", 138, HorizontalAlignment.Left);     // 4

                lst_Tilgungsstatus.View = View.Details;
                lst_Tilgungsstatus.Font = new Font(lst_Tilgungsstatus.Font.FontFamily, AKK_Helper.FontSize);
                lst_Tilgungsstatus.GridLines = true;
                lst_Tilgungsstatus.LabelEdit = true;
                lst_Tilgungsstatus.AllowColumnReorder = true;
                lst_Tilgungsstatus.CheckBoxes = false;
                lst_Tilgungsstatus.FullRowSelect = true;
                //
                // Init Buchungen
                //
                lst_buchungen.Clear();

                lst_buchungen.Columns.Add("Index", -1, HorizontalAlignment.Left);                      // 0
                lst_buchungen.Columns.Add("Datum",85, HorizontalAlignment.Left);                      // 1
                lst_buchungen.Columns.Add("Betrag", 80, HorizontalAlignment.Right);                    // 2
                lst_buchungen.Columns.Add("B.-Art", 60, HorizontalAlignment.Left);                     // 3
                lst_buchungen.Columns.Add("B.-Typ", 60, HorizontalAlignment.Left);                     // 4
                lst_buchungen.Columns.Add("Buchungstext", 400, HorizontalAlignment.Left);              // 5
                lst_buchungen.Columns.Add("WBK_Ikey", -1, HorizontalAlignment.Left);                   // 6
                lst_buchungen.Columns.Add("Art", -1, HorizontalAlignment.Left);                        // 7
                lst_buchungen.Columns.Add("Typ", -1, HorizontalAlignment.Left);                        // 8

                // lst_buchungen .Columns
                //
                lst_buchungen.View = View.Details;
                lst_buchungen.Font = new Font(lst_buchungen.Font.FontFamily, AKK_Helper.FontSize);
                lst_buchungen.GridLines = true;
                lst_buchungen.LabelEdit = true;
                lst_buchungen.AllowColumnReorder = true;
                lst_buchungen.CheckBoxes = false;
                lst_buchungen.FullRowSelect = true;
                //
                // Load Tilgungsstatus
                //
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "TIL3", str_WBDIkey);
                if (resp.ResponseCode == 0)
                {
                    Int32 i = 0;
                    for (Int32 index = 0; index < cols.Count; index++)
                    {
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());
                        //
                        LVI_ORA.SubItems.Add(cols[index].DM_col_01.ToString());                              // 1  Status
                        LVI_ORA.SubItems.Add(cols[index].DM_col_02.ToString().Substring(0, 10));             // 2  von
                        LVI_ORA.SubItems.Add(cols[index].DM_col_03.ToString().Substring(0, 10));             // 3  bis
                        if (cols[index].DM_col_04.ToString().Length > 10)
                        {
                            LVI_ORA.SubItems.Add(cols[index].DM_col_04.ToString().Substring(0,10));                              // 4  Rückstand
                        }
                        else
                        {
                            LVI_ORA.SubItems.Add(cols[index].DM_col_04.ToString());                              // 4  Rückstand
                        }
                        lst_Tilgungsstatus.Items.Add(LVI_ORA);
                        i++;
                        LVI_ORA = null;
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }

                //
                // Load all Buchungen
                //
                opt_Gesamt.Checked = true;

            }
        }
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
        private void Konto_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
        }
        private void Konto_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }

        private void Read_Buchungen(string str_Code)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                lst_buchungen.Items.Clear();

                resp = client.Read_Buchungen(out cols, AKK_Helper.SessionToken, str_WBDIkey, str_Code);
                if (resp.ResponseCode == 0)
                {
                    Int32 i = 0;
                    for (Int32 index = 0; index < cols.Count; index++)
                    {
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());
                        //
                        LVI_ORA.SubItems.Add(cols[index].DM_col_01.ToString().Substring(0, 10));             // 1  Datum
                        LVI_ORA.SubItems.Add(AKK_Helper.FormatBetrag(
                                            cols[index].DM_col_02.ToString()));                              // 2  Betrag
                        LVI_ORA.SubItems.Add(cols[index].DM_col_03.ToString());                              // 3  B-Art
                        LVI_ORA.SubItems.Add(cols[index].DM_col_04.ToString());                              // 4  B-Typ
                        LVI_ORA.SubItems.Add(cols[index].DM_col_05.ToString());                              // 5  Buchungstext
                        LVI_ORA.SubItems.Add(cols[index].DM_col_06.ToString());                              // 6  WBK_Ikey
                        LVI_ORA.SubItems.Add(cols[index].DM_col_07.ToString());                              // 6  BuchungsArt
                        LVI_ORA.SubItems.Add(cols[index].DM_col_08.ToString());                              // 7  BuchungsTyp
                        //         
                        //    
                        if (cols[index].DM_col_07.ToString() == "1")
                        {
                            LVI_ORA.ForeColor = Color.Black;
                            LVI_ORA.UseItemStyleForSubItems = true;
                        }
                        else
                        {
                            LVI_ORA.ForeColor = Color.Red;
                            LVI_ORA.UseItemStyleForSubItems = true;
                        }
                        lst_buchungen.Items.Add(LVI_ORA);
                        i++;
                        LVI_ORA = null;
                    }
                    strip_info.Text = "Es wurden " + cols.Count.ToString().Trim() + " Buchungen gefunden";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void opt_Gesamt_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen("");
        }
        private void opt_Tilgung_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strTILG_CODE);
        }
        private void opt_Rueck_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strRCK_CODE);
        }
        private void opt_Ueber_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strÜBERZ_CODE);
        }
        private void opt_Zinsen_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strZIN_CODE);
        }
        private void opt_Storno_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strSTORNO_CODE);
        }
        private void opt_Rest_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strRST_CODE);
        }
        private void opt_Bar_CheckedChanged(object sender, EventArgs e)
        {
            Read_Buchungen(AKK_Helper.C.strBAR_CODE);
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_drucken_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                List<string> lst_lines = new List<string>();
                Int32 int_count = lst_buchungen.Items.Count;

                for (Int32 i = 0; i < int_count; i++)
                {
                    ListViewItem LVI_ORA = lst_buchungen.Items[i];
                    string str_D = (LVI_ORA.SubItems[1].Text.ToString()).PadRight(20, ' ');
                    string str_B = (LVI_ORA.SubItems[2].Text.ToString()).PadLeft(13, ' ');
                    string str_A = (LVI_ORA.SubItems[3].Text.ToString()).PadLeft(10, ' ');
                    string str_T = (LVI_ORA.SubItems[4].Text.ToString()).PadLeft(10, ' ');

                    string str_str = str_D + str_B + str_A + str_T; //  +@"  \par";  --> lt Bruno nicht notwendig!!!
                    lst_lines.Add(str_str);
                }

                Dictionary<string, string> dict_values = new Dictionary<string, string>();
                dict_values.Add("ANTRAGSTELLER", txt_antragsteller.Text);
                dict_values.Add("DL_NR", txt_darlehensnr.Text);
                dict_values.Add("RESTSCHULD", txt_konto_real .Text);

                print_kontoblatt(AKK_Helper.SessionToken, AKK_Helper.C.strKontoBlatt, dict_values, lst_lines);
            }
        }

        private void print_kontoblatt(string sessionToken, 
                                      string str_templatename, 
                                      Dictionary<string, string> dict_values, 
                                      List<string> lst_lines)

        {
            if (AKK_Helper.checkLogin() == true)
            {
                DocumentGeneration.DocumentGenerationClient docClient = new DocumentGeneration.DocumentGenerationClient();
                DocumentGeneration.Response resp = docClient.doPrintWithValues(AKK_Helper.SessionToken, AKK_Helper.my_printer, str_templatename, dict_values, lst_lines.ToArray<string>());
                if (resp.ResponseCode != 0)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                else
                {
                    AKK_Helper.show_msg("Kontoblatt erfolgreich gedruckt!", strip_info, this.Cursor);
                }
            }
        }

        private void cmd_buchen_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                //

                frm_Buchen frm_buchen = new frm_Buchen();

                frm_buchen.str_antragsteller = txt_antragsteller.Text;
                frm_buchen.str_darlehensnr = txt_darlehensnr.Text;
                frm_buchen.str_WBDIkey = str_WBDIkey;
                frm_buchen.str_konto_real = txt_konto_real.Text;
                frm_buchen.AntId = this.AntId;
                frm_buchen.antrag = this.antrag;
                frm_buchen.ShowDialog();
                // actualize Kontostand
                txt_konto_real.Text = AKK_Helper.FormatBetrag(frm_buchen.str_konto_real);
                str_konto_real = txt_konto_real.Text;
                //
                frm_buchen = null;
                //
                // Update actual Buchungen
                //
                opt_Gesamt.Checked = false;
                opt_Gesamt.Checked = true;
                //
                this.Cursor = Cursors.Default;
            }


        }

       

    } // Form
}     // Namespace

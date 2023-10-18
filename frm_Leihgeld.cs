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
    public partial class frm_Leihgeld : Form
    {
        private double dbl_summe = 0;
        //
        public frm_Leihgeld()
        {
            InitializeComponent();
        }

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
        private void frm_Leihgeld_KeyUp(object sender, KeyEventArgs e)
        {
         AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Leihgeld_Activated(object sender, EventArgs e)
        {
              AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate,1);
        }
        # endregion

        private void frm_Leihgeld_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);
            //
            this.Cursor = Cursors.WaitCursor;
            chk_haben.Checked = true;
            mtxt_Bu_Date.Mask = @"00\.00\.0000";
            mtxt_Bu_Date.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");
            txt_Betrag.Text = AKK_Helper.FormatBetrag("0");
            txt_summe.Enabled = false;
            //
            // Load Buchungen
            //
            // wko_ikey, wko_bdat, wko_betrag, wko_art, wko_stamp, wko_usernr, wko_storno
            //
            lst_buchungen.Clear();

            lst_buchungen.Columns.Add("Index", -1, HorizontalAlignment.Left);                        // 0
            lst_buchungen.Columns.Add("WKO_IKey", -1, HorizontalAlignment.Left);                     // 1
            lst_buchungen.Columns.Add("Buchungsdatum", 120, HorizontalAlignment.Left);               // 2
            lst_buchungen.Columns.Add("Betrag", 100, HorizontalAlignment.Right);                     // 3
            lst_buchungen.Columns.Add("Buchungsart", 100, HorizontalAlignment.Left);                 // 4
            lst_buchungen.Columns.Add("Timestamp", -1, HorizontalAlignment.Left);                   // 5
            lst_buchungen.Columns.Add("User", -1, HorizontalAlignment.Left);                         // 6
            lst_buchungen.Columns.Add("Storno", -1, HorizontalAlignment.Left);                       // 7
            lst_buchungen.Columns.Add("BUA_Ikey", -1, HorizontalAlignment.Left);                     // 8
            lst_buchungen.Columns.Add("Summe", -1, HorizontalAlignment.Left);                       // 9
            //
            lst_buchungen.View = View.Details;
            lst_buchungen.Font = new Font(lst_buchungen.Font.FontFamily, AKK_Helper.FontSize);
            lst_buchungen.GridLines = true;
            lst_buchungen.LabelEdit = true;
            lst_buchungen.AllowColumnReorder = true;
            lst_buchungen.CheckBoxes = false;
            lst_buchungen.FullRowSelect = true;
            lst_buchungen.MultiSelect = false;
            //
           
            dbl_summe = fill_buchungen();
            // Show total sum
            txt_summe.Text = AKK_Helper.FormatBetrag(dbl_summe.ToString());
            //
            txt_Betrag.Focus();
            txt_Betrag.SelectAll();

        }
        private double fill_buchungen()
        {
            if (AKK_Helper.checkLogin() == true)
            {
                dbl_summe = 0;                   // Reset Sum
                Double dbl_wert = 0;             // Init Wert
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                //
                // Load Buchungen
                //
                lst_buchungen.Items.Clear();
                //
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "KTO1", "");
                if (resp.ResponseCode == 0)
                {
                    Int32 i = 0;
                    for (Int32 index = 0; index < cols.Count; index++)
                    {
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());
                        //
                        LVI_ORA.SubItems.Add(cols[index].DM_col_01.ToString());                          // 0 Ikey
                        LVI_ORA.SubItems.Add(cols[index].DM_col_02.ToString().Substring(0, 10));         // 1  Buchungsdatum
                        //LVI_ORA.SubItems.Add(AKK_Helper.FormatBetragOhneKomma(
                                            //cols[index].DM_col_03.ToString()));                          // 2  Betrag

                        LVI_ORA.SubItems.Add(AKK_Helper.FormatBetrag(
                        cols[index].DM_col_03.ToString()));  
                        Double.TryParse(cols[index].DM_col_03.ToString(), out dbl_wert);                 // calc Sum
                        if (cols[index].DM_col_07.ToString() == "1")
                        {
                            LVI_ORA.ForeColor = Color.Blue;
                            LVI_ORA.UseItemStyleForSubItems = true;
                            if (cols[index].DM_col_04.ToString() == "1")
                            {
                                LVI_ORA.SubItems.Add("Haben Storno");                                    // 3  Buchungs ART
                            }
                            else
                            {
                                LVI_ORA.ForeColor = Color.Blue;
                                LVI_ORA.UseItemStyleForSubItems = true;
                                LVI_ORA.SubItems.Add("Soll Storno");                                     // 3  Buchungs ART
                            }
                        }
                        else
                        {




                            if (cols[index].DM_col_04.ToString() == "1")
                            {
                                LVI_ORA.ForeColor = Color.Black;
                                LVI_ORA.UseItemStyleForSubItems = true;
                                LVI_ORA.SubItems.Add("Haben");                                           // 3  Buchungs ART
                                dbl_summe = dbl_summe + dbl_wert;
                            }
                            else
                            {
                                LVI_ORA.ForeColor = Color.Red;
                                LVI_ORA.UseItemStyleForSubItems = true;
                                LVI_ORA.SubItems.Add("Soll");                                           // 3  Buchungs ART
                                dbl_summe = dbl_summe - dbl_wert;
                            }
                        }
                        LVI_ORA.SubItems.Add(cols[index].DM_col_05.ToString());                          // 4  Timestamp
                        LVI_ORA.SubItems.Add(cols[index].DM_col_06.ToString());                          // 5  User
                        LVI_ORA.SubItems.Add(cols[index].DM_col_07.ToString());                          // 6  Storno
                        LVI_ORA.SubItems.Add(cols[index].DM_col_04.ToString());                          // 7  B-Art ikey

                        LVI_ORA.SubItems.Add(dbl_summe.ToString());                                      // 8  Storno

                        lst_buchungen.Items.Add(LVI_ORA);
                        i++;
                        LVI_ORA = null;
                    }
                    //
                    // letzten Eintrag selektieren
                    //

                    lst_buchungen.Items[lst_buchungen.Items.Count - 1].Selected = true;
                    lst_buchungen.Select();
                    lst_buchungen.EnsureVisible(lst_buchungen.Items.Count - 1);
                    strip_info.Text = lst_buchungen.Items.Count.ToString() + " Buchungen wurden gefunden!";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                this.Cursor = Cursors.Default;
                return dbl_summe;
            }
            return 0;
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //
        // chk Soll / Haben
        //
        private void chk_soll_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_soll_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }
        //
        // txt_betrag
        //
        private void txt_Betrag_Enter(object sender, EventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_get_focus;
            txt_Betrag.SelectAll();
        }
        private void txt_Betrag_Leave(object sender, EventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_lost_focus;
            txt_Betrag.Text = AKK_Helper.FormatBetrag(txt_Betrag.Text);
        }
        private void txt_Betrag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = AKK_Helper.format_input_number(sender, e, txt_Betrag.Text.ToString());
        }
        private void txt_Betrag_MouseClick(object sender, MouseEventArgs e)
        {
            txt_Betrag_Enter(sender, e);
        }
        private void txt_Betrag_DoubleClick(object sender, EventArgs e)
        {
            txt_Betrag.Text = AKK_Helper.FormatBetrag("0");
        }
        //
        // mtxt_Bu_Date
        //
        private void mtxt_Bu_Date_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = AKK_Helper.c_get_focus;
            mtxt_Bu_Date.SelectAll();  
        }
        private void mtxt_Bu_Date_Leave(object sender, EventArgs e)
        {

            if (AKK_Helper.is_date(mtxt_Bu_Date.Text) == true)
            {
                label5.ForeColor = AKK_Helper.c_lost_focus;
            }
            else 
            {
                this.Cursor = Cursors.Default;
                AKK_Helper.show_msg("Ungültiges Buchungsdatum!", strip_info, this.Cursor);
                mtxt_Bu_Date.Focus();
                mtxt_Bu_Date.SelectAll();
            }

        }
        private void mtxt_Bu_Date_MouseClick(object sender, MouseEventArgs e)
        {
            mtxt_Bu_Date_Enter(sender, e);
        }
        private void mtxt_Bu_Date_DoubleClick(object sender, EventArgs e)
        {
            mtxt_Bu_Date.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");
        }

        private void cmd_buchen_Click(object sender, EventArgs e)
        {
            //     string sessionToken,
            //     string str_usernr,
            //     string str_Bu_Datum,
            //     string str_Bu_Betrag,
            //     string str_Ant_Ikey,
            //     string str_Soll)
            //
            if (AKK_Helper.checkLogin() == true)
            {
                Double dbl_betrag = 0;

                Double.TryParse(txt_Betrag.Text, out dbl_betrag);
                if (dbl_betrag <= 0)
                {
                    AKK_Helper.show_msg("Ungültiger Buchungsbetrag!", strip_info, this.Cursor);
                    txt_Betrag.Focus();
                    txt_Betrag.SelectAll();
                }
                else
                {

                    if (AKK_Helper.is_empty(mtxt_Bu_Date.Text) == true)
                    {
                        AKK_Helper.show_msg("Ungültiges Buchungsdatum!", strip_info, this.Cursor);
                        mtxt_Bu_Date.Focus();
                        mtxt_Bu_Date.SelectAll();
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string str_Soll = "";
                        //
                        if (chk_soll.Checked == true)
                        {
                            str_Soll = "S";
                        }
                        else
                        {
                            str_Soll = "H";
                        };

                        Response resp = new Response();
                        DC_Columns cols = new DC_Columns();
                        DataService.DataServiceClient client = new DataServiceClient();
                        //
                        // Load Buchungen
                        //
                        lst_buchungen.Items.Clear();
                        //
                        resp = client.Insert_wbd_kto(AKK_Helper.SessionToken,
                                                      AKK_Helper.UserId,
                                                      mtxt_Bu_Date.Text,
                                                      txt_Betrag.Text,
                                                      "2",
                                                      str_Soll,
                                                      "N",
                                                      "-1");
                        if (resp.ResponseCode == 0)
                        {
                            AKK_Helper.show_msg("Buchungen erfolgreich gespeichert!", strip_info, this.Cursor);
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }

                        dbl_summe = fill_buchungen();
                        txt_summe.Text = AKK_Helper.FormatBetrag(dbl_summe.ToString());
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }
        private void cmd_storno_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                //lst_buchungen.Columns.Add("Buchungsdatum", 100, HorizontalAlignment.Left);               // 2
                //lst_buchungen.Columns.Add("Betrag", 80, HorizontalAlignment.Left);                       // 3
                //lst_buchungen.Columns.Add("Buchungsart", 100, HorizontalAlignment.Left);                 // 4
                //lst_buchungen.Columns.Add("Timestamp", 100, HorizontalAlignment.Left);                   // 5
                //lst_buchungen.Columns.Add("User", 50, HorizontalAlignment.Left);                         // 6
                //lst_buchungen.Columns.Add("Storno", 50, HorizontalAlignment.Left);                       // 7
                if (lst_buchungen.SelectedItems.Count <= 0)
                {
                    AKK_Helper.show_msg("Keine gültige Buchung selektiert", strip_info, this.Cursor);
                }
                else
                {
                    ListViewItem li = null;
                    for (int i = lst_buchungen.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        li = lst_buchungen.SelectedItems[i];

                        if (li.SubItems[7].Text.ToString() == "1")
                        {
                            AKK_Helper.show_msg("Dies ist bereits ein Stornosatz!", strip_info, this.Cursor);
                        }
                        else
                        {
                            this.Cursor = Cursors.WaitCursor;
                            string str_Soll = "";
                            //
                            if (li.SubItems[8].Text.ToString() == "1")
                            {
                                str_Soll = "H";
                            }
                            else
                            {
                                str_Soll = "S";
                            };

                            Response resp = new Response();
                            DC_Columns cols = new DC_Columns();
                            DataService.DataServiceClient client = new DataServiceClient();
                            Double dbl_betrag = 0;
                            Double.TryParse(li.SubItems[3].Text.ToString(), out dbl_betrag);
                            string str_Betr = (dbl_betrag * (-1)).ToString();
                            //
                            // Load Buchungen
                            //
                            lst_buchungen.Items.Clear();
                            //
                            resp = client.Insert_wbd_kto(AKK_Helper.SessionToken,
                                                          AKK_Helper.UserId,
                                                          DateTime.Now.Date.ToString("dd.MM.yyyy"),   // BU Date
                                                          str_Betr,             // BU Betrag
                                                          "2",                                        // WBD  
                                                          str_Soll,                                   // S / H vom selektiertem Datensatz 
                                                          "J",                                        // Storno Ja
                                                          li.SubItems[1].Text.ToString());            // akt WKO_ikey for Storno
                            if (resp.ResponseCode == 0)
                            {
                                AKK_Helper.show_msg("Buchungen erfolgreich gespeichert!", strip_info, this.Cursor);
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                AKK_Helper.handleServiceError(resp);
                            }
                        }
                    }
                    dbl_summe = fill_buchungen();
                    txt_summe.Text = AKK_Helper.FormatBetrag(dbl_summe.ToString());
                    this.Cursor = Cursors.Default;

                }
            }
        }
        private void cmd_aktual_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                dbl_summe = fill_buchungen();
                txt_summe.Text = AKK_Helper.FormatBetrag(dbl_summe.ToString());
            }
        }

        private void cmd_druck_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                List<string> lst_lines = new List<string>();
                Int32 int_count = lst_buchungen.Items.Count;

                for (Int32 i = 0; i < int_count; i++)
                {
                    ListViewItem LVI_ORA = lst_buchungen.Items[i];
                    string str_D = (LVI_ORA.SubItems[2].Text.ToString()).PadRight(20, ' ');
                    string str_B = (LVI_ORA.SubItems[3].Text.ToString()).PadLeft(20, ' ');
                    string str_A = (LVI_ORA.SubItems[4].Text.ToString()).PadLeft(10, ' ');


                    string str_str = str_D + str_B + str_A; //  +@"  \par"; 
                    lst_lines.Add(str_str);
                }

                Dictionary<string, string> dict_values = new Dictionary<string, string>();
                dict_values.Add("GESAMT", txt_summe.Text);

                print_kontoblatt(AKK_Helper.SessionToken, AKK_Helper.C.strKontoBlattLG, dict_values, lst_lines);

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

       
         
    }  // Form
}      // Namespace

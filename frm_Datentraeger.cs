using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using Addit.AK.WBD.AK_Suche.AuthService;
using Addit.AK.WBD.AK_Suche.DataService ;
using Addit.AK.WBD.AK_Suche.BankRecordCarrier ;
using Addit.AK.Util;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Datentraeger : Form
    {
        private string str_date = System.DateTime.Today.ToString("dd.MM.yyyy");
        private string str_mj = System .DateTime .Today .Month .ToString ().PadLeft (2,'0') + "." + 
                                System .DateTime .Today .Year .ToString ();
        Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
        DataService.DataServiceClient client = new DataServiceClient();

        public frm_Datentraeger()
        {
            InitializeComponent();
        }
        #region strip and Keyboard
        //
        // Strip Region
        // 
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
        private void frm_Datentraeger_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }
        private void frm_Datentraeger_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        # endregion

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Datentraeger_Load(object sender, EventArgs e)
        {

        
            AKK_Helper.FindControls(this);

            mtxt_verst_am_mit_koop.Mask      = @"00\.00\.0000";
            mtxt_verst_am_ohne_koop.Mask = @"00\.00\.0000";
            mtxt_anweis_am.Mask     = @"00\.00\.0000";
            mtxt_anweis_dat_am.Mask = @"00\.00\.0000";
            mtxt_ausz_am.Mask       = @"00\.00\.0000";
            mtxt_monjahr.Mask       = @"00\.0000";

          //  mtxt_verst_am_ohne_koop.Enabled      = false;
           // mtxt_verst_am_mit_koop.Enabled = false;
            mtxt_anweis_am.Enabled     = false;
            mtxt_anweis_dat_am.Enabled = false;
            mtxt_ausz_am.Enabled       = false;
            mtxt_monjahr.Enabled       = false;

            txt_pw1.Enabled = false;
            txt_pw2.Enabled = false;

            grp_1.Visible = false;
            lst_info.Visible = false;

         

           AKK_Helper.Init_lst_info(lst_info);
        }
        // dynamische Zuweisungen
        private void chk_DT_lesen_Enter(object sender, EventArgs e)
        {
            set_value(sender, false, false, false, false );
            strip_info.Text = "Einlesen des Datenträgers im v3 Format";
        }
        private void chk_DT_lesen_Leave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_DT_lesen_MouseLeave(object sender, EventArgs e)
        {
            lost_focus(sender);

        }
        private void chk_DT_erstellen_Enter(object sender, EventArgs e)
        {
            set_value(sender, true, false, false, false);
            strip_info.Text = "Erstellen des Datenträgers im SEPA Format";
        }
        private void chk_DT_erstellen_Leave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_DT_erstellen_MouseLeave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_DT_neu_erstellen_Enter(object sender, EventArgs e)
        {
            set_value(sender, false, true, false, false);
            strip_info.Text = "Erneutes Erstellen des Datenträgers im SEPA Format";
        }
        private void chk_DT_neu_erstellen_Leave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_DT_neu_erstellen_MouseLeave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_DT_einziehen_Enter(object sender, EventArgs e)
        {
            set_value(sender, false, false, true, false);
            strip_info.Text = "Erstellen des Einzugsdatenträgers im SEPA Format";
        }
        private void chk_DT_einziehen_Leave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_DT_einziehen_MouseLeave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_Datum_setzen_Enter(object sender, EventArgs e)
        {
            set_value(sender, false, false, false, true);
            strip_info.Text = "Setzen des Auszahlungsdatums für ein bestimmtes Anweisungsdatum";
        }
        private void chk_Datum_setzen_Leave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        private void chk_Datum_setzen_MouseLeave(object sender, EventArgs e)
        {
            lost_focus(sender);
        }
        // Fixe zuweisungen
        private void chk_Jahresumstellung_Enter(object sender, EventArgs e)
        {
            lost_pw();
            chk_Jahresumstellung.ForeColor = AKK_Helper.c_get_focus;
            strip_info.Text = "Zurücksetzen der Grunddaten für den aktuellen ID ( Jahr / SNr )";
             
        }
        private void chk_Jahresumstellung_Leave(object sender, EventArgs e)
        {
            chk_Jahresumstellung.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_Mahnlauf_Enter(object sender, EventArgs e)
        {
            lost_pw();
            chk_Mahnlauf.ForeColor = AKK_Helper.c_get_focus;
            strip_info.Text = "Mahnlauf starten";
        }
        private void chk_Mahnlauf_Leave(object sender, EventArgs e)
        {
            chk_Mahnlauf.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_Passwort_aendern_Enter(object sender, EventArgs e)
        {
            chk_Passwort_aendern.ForeColor = AKK_Helper.c_get_focus;
            label6.ForeColor = AKK_Helper.c_get_focus;
            label7.ForeColor = AKK_Helper.c_get_focus;
            strip_info.Text = "Zurücksetzen der Passworte für WBD und Conexdba";
            txt_pw1.Enabled = true;
            txt_pw2.Enabled = true;
            txt_pw2.Text = "";
            txt_pw1.Text = "";
            txt_pw1.Focus();
        }
        private void chk_Passwort_aendern_Leave(object sender, EventArgs e)
        {
            chk_Passwort_aendern.ForeColor = AKK_Helper.c_lost_focus;
            label6.ForeColor = AKK_Helper.c_lost_focus;
            label7.ForeColor = AKK_Helper.c_lost_focus;
           
            txt_pw1.Enabled = false;
            txt_pw2.Enabled = false;
        }
        private void chk_WBD_Export_Enter(object sender, EventArgs e)
        {
            lost_pw();
            chk_WBD_Export.ForeColor = AKK_Helper.c_get_focus;
            strip_info.Text = "Export der WBD Daten";
        }
        private void chk_WBD_Export_Leave(object sender, EventArgs e)
        {
            chk_WBD_Export.ForeColor = AKK_Helper.c_lost_focus;
        }
        // dynamische Zuweisungen
        private void set_value(object sender, Boolean is_ver, Boolean is_an, Boolean is_jm, Boolean is_aus)
        {


            label1.ForeColor = AKK_Helper.c_lost_focus;
            label8.ForeColor = AKK_Helper.c_lost_focus;
            label2.ForeColor = AKK_Helper.c_lost_focus;
            label3.ForeColor = AKK_Helper.c_lost_focus;
            label4.ForeColor = AKK_Helper.c_lost_focus;
            label5.ForeColor = AKK_Helper.c_lost_focus;

            lost_pw();

            chk_DT_lesen .ForeColor         = AKK_Helper.c_lost_focus;
            chk_DT_erstellen_ohne_koop.ForeColor     = AKK_Helper.c_lost_focus;
            chk_DT_erstellen_mit_koop.ForeColor = AKK_Helper.c_lost_focus;
            chk_DT_neu_erstellen .ForeColor = AKK_Helper.c_lost_focus;
            chk_DT_einziehen .ForeColor     = AKK_Helper.c_lost_focus;
            chk_Datum_setzen .ForeColor     = AKK_Helper.c_lost_focus;

            RadioButton rb = (RadioButton)sender;
            rb.ForeColor = AKK_Helper.c_get_focus;
            //
            //MiRo
          //  mtxt_verst_am_mit_koop.Enabled = is_ver;
           // mtxt_verst_am_ohne_koop.Enabled = is_ver;


            mtxt_anweis_am.Enabled = is_an;
            mtxt_monjahr.Enabled = is_jm;
            mtxt_ausz_am.Enabled = is_aus;
            mtxt_anweis_dat_am.Enabled = is_aus;

           // mtxt_verst_am_mit_koop.Text = "";
           // mtxt_verst_am_ohne_koop.Text = "";
            mtxt_anweis_am.Text = "";
            mtxt_monjahr.Text = "";
            mtxt_ausz_am.Text = "";
            mtxt_anweis_dat_am.Text = "";


            //MiRo
            mtxt_verst_am_mit_koop.Text = DateTime.Now.ToString();
            mtxt_verst_am_ohne_koop.Text = DateTime.Now.ToString();

            if (is_ver == true)
            {
                
                label1.ForeColor = AKK_Helper.c_get_focus;
                mtxt_verst_am_mit_koop.Text = str_date;
                mtxt_verst_am_mit_koop.Focus();
                mtxt_verst_am_mit_koop.SelectAll();

                mtxt_verst_am_ohne_koop.Text = str_date;
                mtxt_verst_am_ohne_koop.Focus();
                mtxt_verst_am_ohne_koop.SelectAll();              
                 
            }

            if (is_an == true)
            {
                label2.ForeColor = AKK_Helper.c_get_focus;
                mtxt_anweis_am.Text = str_date;
                mtxt_anweis_am.Focus();
                mtxt_anweis_am.SelectAll();
            }

            if (is_jm == true)
            {
                label3.ForeColor = AKK_Helper.c_get_focus;
                mtxt_monjahr.Text = str_mj;
                mtxt_monjahr.Focus();
                mtxt_monjahr.SelectAll();
            }


            if (is_aus == true)
            {
                label4.ForeColor = AKK_Helper.c_get_focus;
                label5.ForeColor = AKK_Helper.c_get_focus;
                mtxt_ausz_am.Text = str_date;
                mtxt_ausz_am.Focus();
                mtxt_ausz_am.SelectAll();
                mtxt_anweis_dat_am.Text = "";
            }
        }
        private void lost_focus(object sender )
        {
            RadioButton rb = (RadioButton)sender;
            rb.ForeColor = AKK_Helper.c_lost_focus;

            label1.ForeColor = AKK_Helper.c_lost_focus;
            label2.ForeColor = AKK_Helper.c_lost_focus;
            label3.ForeColor = AKK_Helper.c_lost_focus;
            label4.ForeColor = AKK_Helper.c_lost_focus;
            label5.ForeColor = AKK_Helper.c_lost_focus;

            lost_pw();
        }
        private void lost_pw()
        {
            label6.ForeColor = AKK_Helper.c_lost_focus;
            label7.ForeColor = AKK_Helper.c_lost_focus;

            txt_pw1.Enabled = false;
            txt_pw2.Enabled = false;

            chk_Passwort_aendern.ForeColor = AKK_Helper.c_lost_focus;
        }
        //
        // Bearbeiter
        //
        private void cmd_bearbeiten_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (chk_DT_lesen.Checked == true)
                {
                    if (!rdb_ish.Checked)
                    {
                        DTT_lesen();
                    }
                }
                // Datenträger erstellen

                if (chk_DT_erstellen_ohne_koop.Checked == true)
                {
                    if (rdb_ish.Checked)
                    {

                        DT_Auszahlung_erstellen(mtxt_verst_am_ohne_koop.Text, "N", "I", false);
                    }
                    else
                    {

                        DT_Auszahlung_erstellen(mtxt_verst_am_ohne_koop.Text, "N", "W", false);
                    }
                }

                if (chk_DT_erstellen_mit_koop.Checked == true)
                {
                  
                    if (rdb_ish.Checked)
                    {

                        DT_Auszahlung_erstellen(mtxt_verst_am_mit_koop.Text, "N", "I", true);
                    }
                    else
                    {

                        DT_Auszahlung_erstellen(mtxt_verst_am_mit_koop.Text, "N", "W", true);
                    }

                }

                // Datenträger erneut erstellen
                if (chk_DT_neu_erstellen.Checked == true)
                {
                    if (rdb_ish.Checked)
                    {
                        DT_Auszahlung_erstellen(mtxt_anweis_am.Text, "J", "I", false);
                    }
                    else
                    {
                        DT_Auszahlung_erstellen(mtxt_anweis_am.Text, "J", "W", false);
                    }
                }
                if (chk_DT_einziehen.Checked == true && !rdb_ish.Checked)
                {
                    DT_Einzug_erstellen(mtxt_monjahr.Text);
                }

                // Datum setzen
                if (chk_Datum_setzen.Checked == true)
                {
                    if (mtxt_anweis_dat_am.Text.Trim() == ".  .")
                    {
                        AKK_Helper.show_msg("Anweisdatum muss erfasst werden", strip_info, this.Cursor);
                        mtxt_anweis_dat_am.Focus();
                        mtxt_anweis_dat_am.SelectAll();
                    }
                    else
                    {
                        if (rdb_ish.Checked)
                        {
                            Datum_setzen(true);
                        }
                        else
                        {
                            Datum_setzen(false);

                        }
                    };
                }
                // Jahresumstellung
                if (chk_Jahresumstellung.Checked == true)
                {
                    if (rdb_ish.Checked)
                    {
                        Reset_Jahr("18");
                    }
                    else
                    {
                        Reset_Jahr("2");
                    }
                    
                }
                // Mahnlauf
                if (chk_Mahnlauf.Checked == true)
                {
                    Mahnlauf(false);
                }
                if (chk_Mahnlauf_ISH.Checked && rdb_ish.Checked)
                {
                    Mahnlauf(true);
                }
                // Passwort ändern
                if (chk_Passwort_aendern.Checked == true)
                {
                    Passwort_Aendern();
                }
                if (chk_WBD_Export.Checked == true)
                {
                    Export_WBD();
                }
            }

        }
        private void DTT_lesen()
        {
            frm_Einlesen frm_einlesen = new frm_Einlesen();
            frm_einlesen.ShowDialog();
            frm_einlesen = null;
        }

        public void Datum_setzen(bool ish)
        {
            this.Cursor = Cursors.WaitCursor;
            //

            if (ish)
            {

                string str_count = "";
                DC_lst_ak_error lst_ak_error = new DC_lst_ak_error();
                resp = client.Datum_setzen(out lst_ak_error,
                                           out str_count,
                       AKK_Helper.SessionToken,
                       AKK_Helper.UserId,
                       mtxt_ausz_am.Text,
                       mtxt_anweis_dat_am.Text,
                       "13");
                //
                this.Cursor = Cursors.Default;
                if (resp.ResponseCode == 0)
                {
                    AKK_Helper.show_msg("Bei " + str_count + " Darlehen wurde das Auszahlungsdatum auf " + mtxt_ausz_am.Text + " gesetzt", strip_info, this.Cursor);

                    // 26-08-2011 KJ Liste wird laut Fr. Schmautz nicht benötigt
                    //
                    /*
                    if (lst_ak_error != null)
                    {
                        List<string> lst_lines = new List<string>();
                        Int32 int_count = lst_ak_error.Count;

                        for (Int32 i = 0; i < int_count; i++)
                        {
                            DC_ak_error ak_error = lst_ak_error[i];
                            string str_A = (ak_error.DM_Datum);
                            string str_B = (ak_error.DM_Dl);
                            string str_C = (ak_error.DM_Text);

                            string str_str = str_A + "     " + str_B +  "     " + str_C; //  +@"  \par";
                            lst_lines.Add(str_str);
                        }

                        Dictionary<string, string> dict_values = new Dictionary<string, string>();
                        // dict_values.Add("ANTRAGSTELLER",txt_antragsteller .Text);
                        // dict_values.Add("DL_NR", txt_darlehensnr.Text);
                        print_kontoblatt(AKK_Helper.SessionToken, AKK_Helper.C.strSDAT, dict_values, lst_lines);

                    }
                     * */
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }


            }
            else
            {
                    string str_count = "";
                    DC_lst_ak_error lst_ak_error = new DC_lst_ak_error();
                    resp = client.Datum_setzen(out lst_ak_error,
                                               out str_count,
                           AKK_Helper.SessionToken,
                           AKK_Helper.UserId,
                           mtxt_ausz_am.Text,
                           mtxt_anweis_dat_am.Text,
                           "3");
                    //
                    this.Cursor = Cursors.Default;
                    if (resp.ResponseCode == 0)
                    {
                        AKK_Helper.show_msg("Bei " + str_count + " Darlehen wurde das Auszahlungsdatum auf " + mtxt_ausz_am.Text + " gesetzt", strip_info, this.Cursor);

                        // 26-08-2011 KJ Liste wird laut Fr. Schmautz nicht benötigt
                        //
                        /*
                        if (lst_ak_error != null)
                        {
                            List<string> lst_lines = new List<string>();
                            Int32 int_count = lst_ak_error.Count;

                            for (Int32 i = 0; i < int_count; i++)
                            {
                                DC_ak_error ak_error = lst_ak_error[i];
                                string str_A = (ak_error.DM_Datum);
                                string str_B = (ak_error.DM_Dl);
                                string str_C = (ak_error.DM_Text);

                                string str_str = str_A + "     " + str_B +  "     " + str_C; //  +@"  \par";
                                lst_lines.Add(str_str);
                            }

                            Dictionary<string, string> dict_values = new Dictionary<string, string>();
                            // dict_values.Add("ANTRAGSTELLER",txt_antragsteller .Text);
                            // dict_values.Add("DL_NR", txt_darlehensnr.Text);
                            print_kontoblatt(AKK_Helper.SessionToken, AKK_Helper.C.strSDAT, dict_values, lst_lines);

                        }
                         * */
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

            }
            

        }
        private void print_kontoblatt(string sessionToken,
                                      string str_templatename,
                                      Dictionary<string, string> dict_values,
                                      List<string> lst_lines)

        {
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
                        AKK_Helper.show_msg("Kontrollliste erfolgreich gedruckt!", strip_info, this.Cursor);
                    }
                }
            }

        }
        public void Mahnlauf(bool ish)
        {
            frm_Mahnlauf frm_mahnlauf = new frm_Mahnlauf();
            if (ish)
            {
                frm_mahnlauf.ish = true;
            }
            else
            {
                frm_mahnlauf.ish = false;
            }
            frm_mahnlauf.ShowDialog();
            frm_mahnlauf = null;
        }
        public void Export_WBD()
        {
            frm_Export frm_export = new frm_Export();
            frm_export  .ShowDialog();
            frm_export = null;
        }
        public void Reset_Jahr(string var_ant_ikey_c)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();

                resp = client.Reset_Jahr(AKK_Helper.SessionToken,
                                         AKK_Helper.UserId,
                                         var_ant_ikey_c);
                if (resp.ResponseCode == 0)
                {
                    strip_info.Text = "Grunddaten für Antrags-ID geändert!";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
            }
        }
        public void Passwort_Aendern()
        {
            if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
            {
                AKK_Helper.SessionToken = null;
                AKK_Helper.checkLogin();

                if (txt_pw1.Text == txt_pw2.Text)
                {  
                    AKK_Helper.authService.setPassword(AKK_Helper.SessionToken, txt_pw1.Text);
                    AKK_Helper.SessionToken = null;
                    AKK_Helper.checkLogin();
                    //
                    // PVS PW ändern
                    //
                    try
                    {
                        AKK_Helper.PVS_CON.PVS_APP.ChangePassword(AKK_Helper.PVSPW, txt_pw1.Text);
                        AKK_Helper.PVSPW = txt_pw1.Text;
                        AKK_Helper.PVS_CON.PVS_APP.Connect(AKK_Helper.PVSUserId, AKK_Helper.PVSPW);
                        AKK_Helper.show_msg("Passwort für WBD und PVS erfolgreich geändert!", strip_info, this.Cursor);
                    }
                    catch (Exception ex)
                    {
                        AKK_Helper.show_msg("Fehler beim Update des PVS Passwortes : " + ex.Message, strip_info, this.Cursor);
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Passwort Verifizierung fehlgeschlagen", strip_info, this.Cursor);
                }
            }
            else
            {
                AKK_Helper.show_msg("Anmeldung bei PVS fehlgeschlagen - " + AKK_Helper.PVSUserId , strip_info, this.Cursor);
            }
        }
        
        private void DT_Auszahlung_erstellen(string str_date, string str_yn, string ish, bool isCoopPartner)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (AKK_Helper.is_date(str_date) == true)
                {
                    DateTime dt_date = new DateTime();
                    if (DateTime.TryParse(str_date, out dt_date) == true)
                    {


                        cmd_bearbeiten.Enabled = false;
                        cmd_schliessen.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;

                        //neue Variable ish, dient als Weiche wann welche SEPA Auszahlungen gemacht werden sollen
                        Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response resp = new Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response();
                        BankRecordCarrier.BankRecordCarrierClient client = new BankRecordCarrier.BankRecordCarrierClient();
                        client.generateSepaAuszahlungCompleted += generateSepaAuszahlungCompleted;
                       client.generateSepaAuszahlungAsync(AKK_Helper.SessionToken, dt_date, str_yn, ish, isCoopPartner);

                        string str_info = "";
                        if (str_yn == "N")
                        {
                            str_info = "AusDT für VerstDat. ";
                        }
                        else
                        {
                            str_info = "AusDT erneut für AnwDat. ";
                        }
                        strip_info.Text = str_info + str_date + " am " +
                                          DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                          DateTime.Now.Hour.ToString("00") + " Uhr " +
                                          DateTime.Now.Minute.ToString("00") + " gestartet ...";


                    }
                    else
                    {
                       
                        AKK_Helper.show_msg("Fehler beim Parsen des Datums - " + str_date, strip_info, this.Cursor);
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Kein gültiges Datum erfasst", strip_info, this.Cursor);
                }
            }
        }
      private void generateSepaAuszahlungCompleted(object sender, BankRecordCarrier.generateSepaAuszahlungCompletedEventArgs args)
        
        {
            cmd_bearbeiten.Enabled = true;
            cmd_schliessen.Enabled = true;
            this.Cursor = Cursors.Default;
            if (args.Result.ResponseCode == 0)
            {
                AKK_Helper.show_msg("Auszahlungs - Datenträger erfolgreich erstellt!", strip_info, this.Cursor);
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                    
                    
                    AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("Fehler beim Erstellen des Auszahlungs - Datenträgers! - " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }


        }

   
        private void DT_Einzug_erstellen(string str_monjahr)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                str_date = "01." + str_monjahr;
                if (AKK_Helper.is_date(str_date) == true)
                {
                    DateTime dt_date = new DateTime();
                    if (DateTime.TryParse(str_date, out dt_date) == true)
                    {
                        cmd_bearbeiten.Enabled = false;
                        cmd_schliessen.Enabled = false;
                        cmd_log.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;

                        Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response resp = new Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response();
                        BankRecordCarrier.BankRecordCarrierClient client = new BankRecordCarrier.BankRecordCarrierClient();
                        client.generateSepaEinzugCompleted += generateSepaEinzugCompleted;
                        client.generateSepaEinzugAsync(AKK_Helper.SessionToken, dt_date);

                        strip_info.Text = "Einzug DT " + " am " +
                                          DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                          DateTime.Now.Hour.ToString("00") + " Uhr " +
                                          DateTime.Now.Minute.ToString("00") + " gestartet ...";


                    }
                    else
                    {
                        AKK_Helper.show_msg("Fehler beim Parsen des Datums - " + mtxt_monjahr.Text, strip_info, this.Cursor);
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Kein gültiges Datum erfasst", strip_info, this.Cursor);
                }
            }
        }
        private void generateSepaEinzugCompleted(object sender, BankRecordCarrier.generateSepaEinzugCompletedEventArgs args)
        {
            cmd_bearbeiten.Enabled = true;
            cmd_schliessen.Enabled = true;
            cmd_log.Enabled = true;
            this.Cursor = Cursors.Default;
            if (args.Result.ResponseCode == 0)
            {
                AKK_Helper.show_msg("Einzahlungs - Datenträger erfolgreich erstellt!", strip_info, this.Cursor);

                
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                    
                    AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("Fehler beim Erstellen des Einzahlung - Datenträgers! - " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }

        }

        //
        // LOG Bereich
        //
# region LOG
        private void cmd_log_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                grp_1.Visible = !grp_1.Visible;
                grp_1.Font = new Font(grp_1.Font.FontFamily, AKK_Helper.FontSize);
                lst_info.Visible = !lst_info.Visible;
                strip_info.Text = "";
                txt_offset.Text = "100";

                lst_info.View = View.Details;

                lst_info.Font = new Font(lst_info.Font.FontFamily, AKK_Helper.FontSize);

                lst_info.GridLines = true;
                lst_info.LabelEdit = true;
                lst_info.AllowColumnReorder = true;
                lst_info.CheckBoxes = false;
                lst_info.FullRowSelect = true;

                lst_info.Items.Clear();
                chk_wbd_log.Checked = false;
                chk_DT_Log.Checked = false;
                if (grp_1.Visible == false)
                    strip_info.Text = "";
                chk_DT_Log.Checked = false;
                chk_Auszahl.Enabled = false;
                chk_einzahlung.Enabled = false;
                chk_Datum.Enabled = false;
            }
        }
        private void txt_offset_Leave(object sender, EventArgs e)
        {
            Int32 int_i = 0;
            Int32.TryParse(txt_offset.Text, out int_i);
            if (int_i > 100)
                int_i = 100;
            txt_offset.Text = int_i.ToString();
        }
        private void chk_wbd_log_Click(object sender, EventArgs e)
        {
            chk_Auszahl.Enabled = false;
            chk_einzahlung.Enabled = false;
            chk_Datum.Enabled = false;
       
            AKK_Helper.set_wbd(lst_info, "LOG1", txt_offset.Text, strip_info, this.Cursor);
        }
        private void chk_DT_Log_Click(object sender, EventArgs e)
        {
            chk_Auszahl.Enabled = true;
            chk_einzahlung.Enabled = true;
            chk_Datum.Enabled = true;

            AKK_Helper.set_not_wbd(lst_info, "DT1", txt_offset.Text, strip_info, this.Cursor);
  
        }
        private void chk_Auszahl_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Auszahl.Checked == true )
            
            {

             // fill_ListInfo("DT1", txt_offset.Text);
             AKK_Helper.set_not_wbd(lst_info, "DT1", txt_offset.Text, strip_info, this.Cursor);
             chk_einzahlung.Checked = false;
             chk_Datum.Checked = false;
            }
        }
        private void chk_einzahlung_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_einzahlung.Checked == true)
            {
                // fill_ListInfo("DT2", txt_offset.Text);
                AKK_Helper.set_not_wbd(lst_info, "DT2", txt_offset.Text, strip_info, this.Cursor);
                chk_Auszahl.Checked = false;
                chk_Datum.Checked = false;
            }
        }
        private void chk_Datum_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Datum    .Checked == true)
            {
                // fill_ListInfo("DT3", txt_offset.Text);
                AKK_Helper.set_not_wbd(lst_info, "DT3", txt_offset.Text, strip_info, this.Cursor);
                chk_einzahlung.Checked = false;
                chk_Auszahl.Checked = false;
            }
        }
        private void cmd_print_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (AKK_Helper.Print_LST_Box(lst_info, 10, 22, 0, -1, -1) == true)
                {
                    AKK_Helper.show_msg("Druck erfolgreich  beendet!", strip_info, this.Cursor);
                }
            }
        }
#endregion

        private void mtxt_ausz_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_date(mtxt_ausz_am.Text) == false)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC005"], strip_info, this.Cursor);
                mtxt_ausz_am.Focus();
                mtxt_ausz_am.SelectAll();
            }
        }

        private void mtxt_anweis_dat_am_Leave(object sender, EventArgs e)
        {
            if (mtxt_anweis_dat_am.Text.Trim() == ".  .")
            {
                AKK_Helper.show_msg("Anweisdatum muss erfasst werden", strip_info, this.Cursor);
                mtxt_anweis_dat_am.Focus();
                mtxt_anweis_dat_am.SelectAll();
            }
            else
            {
                if (AKK_Helper.is_date(mtxt_anweis_dat_am.Text) == false)
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC005"], strip_info, this.Cursor);
                    mtxt_anweis_dat_am.Focus();
                    mtxt_anweis_dat_am.SelectAll();
                }
            }
        }

        private void mtxt_verst_am_Leave_mit_koop(object sender, EventArgs e)
        {
            if (AKK_Helper.is_date(mtxt_verst_am_mit_koop.Text) == false)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC005"], strip_info, this.Cursor);
                mtxt_verst_am_mit_koop.Focus();
                mtxt_verst_am_mit_koop.SelectAll();
            }
        }

        private void mtxt_verst_am_Leave_ohne_koop(object sender, EventArgs e)
        {
            if (AKK_Helper.is_date(mtxt_verst_am_ohne_koop.Text) == false)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC005"], strip_info, this.Cursor);
                mtxt_verst_am_ohne_koop.Focus();
                mtxt_verst_am_ohne_koop.SelectAll();
            }
        }

        private void mtxt_anweis_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_date(mtxt_anweis_am.Text) == false)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC005"], strip_info, this.Cursor);
                mtxt_anweis_am.Focus();
                mtxt_anweis_am.SelectAll();
            }
        }

        private void rdb_ish_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_ish.Checked)
            {
                chk_DT_einziehen.Checked = false;
                chk_DT_einziehen.Enabled = false;

                chk_WBD_Export.Checked = false;
                chk_WBD_Export.Enabled = false;

                chk_DT_lesen.Checked = false;
                chk_DT_lesen.Enabled = false;

                chk_DT_erstellen_ohne_koop.Checked = true;
                chk_DT_erstellen_mit_koop.Checked = true;

                grp_1.Enabled = false;
                cmd_log.Enabled = false;

                chk_Mahnlauf.Enabled = false;
                chk_Mahnlauf_ISH.Enabled = true;
            }
            else
            {
                chk_DT_lesen.Checked = true;
                chk_DT_lesen.Enabled = true;
                chk_DT_einziehen.Enabled = true;
                chk_WBD_Export.Enabled = true;

                grp_1.Enabled = true;
                cmd_log.Enabled = true;

                chk_Mahnlauf.Enabled = true;
                chk_Mahnlauf_ISH.Enabled = false;
            }
        }

        private void rdb_wbd_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioWithCooperationPartner_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_DT_erstellen_ohne_koop_CheckedChanged(object sender, EventArgs e)
        {

        }

        

      

         

        

    }  // Form
}      // Namespace

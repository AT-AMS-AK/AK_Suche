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
using Miracle.MPP.WebPCI;


namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Export : Form
    {
        private string str_date = DateTime.Now.Date.ToString("dd.MM.yyyy");

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
        private void frm_Export_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Export_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }

        public frm_Export()
        {
            InitializeComponent();
        }
        private void frm_Export_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);

            gb_Einschrank.Font = new Font(gb_Einschrank.Font.FontFamily, AKK_Helper.FontSize);
            gb_geklagt.Font = new Font(gb_geklagt.Font.FontFamily, AKK_Helper.FontSize);
            gb_konto .Font = new Font(gb_konto.Font.FontFamily, AKK_Helper.FontSize);
            gb_Trennzeichen.Font = new Font(gb_Trennzeichen.Font.FontFamily, AKK_Helper.FontSize);
                
            grp_1.Visible = false;
            lst_info.Visible = false;
            txt_pfad.Enabled = false;
            txt_pfad.Text = AKK_Helper.C.strExportPfad;

            chk_Nein.Checked = true;
            chk_tab.Checked = true;
            chk_kegal.Checked = true; 

            mtxt_eingang.Enabled = false;
            mtxt_auszahl.Enabled = false;
            mtxt_rueck.Enabled = false;

            chk_eingang.Checked = false;
            chk_auszahl.Checked = false;
            chk_rueck.Checked = false;

            mtxt_eingang.Mask = @"00\.00\.0000";
            mtxt_auszahl.Mask = @"00\.00\.0000";
            mtxt_rueck.Mask   = @"00\.00\.0000";

            filllistbox();

            cob_status.SelectedIndex = 0;
            cob_status.Focus();
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmd_export_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                if (AKK_Helper.is_date(str_date) == true)
                {
                    string strX_date = str_date;
                    string str_datart = "B";
                    string str_datum = "";
                    string str_klage = "";
                    string str_trenn = "";
                    string str_konto = "";
                    string str_status = "";
                    string str_statusWort = "";
                    //
                    Int32 int_i = 0;
                    Int32.TryParse(cob_status.SelectedValue.ToString(), out int_i);
                    if (int_i < 0)
                    {
                        str_status = "-1";
                        str_statusWort = "Alle Stati";
                    }
                    else
                    {
                        str_status = cob_status.SelectedValue.ToString();
                        str_statusWort = cob_status.Text.ToString();
                    }

                    //
                    // Datum
                    //
                    if (chk_auszahl.Checked == true)
                    {
                        if (AKK_Helper.is_empty_date(mtxt_auszahl.Text) == false)
                        {
                            strX_date = mtxt_auszahl.Text;
                            str_datart = "A";
                        }
                    }
                    else
                    {
                        if (chk_eingang.Checked == true)
                        {
                            if (AKK_Helper.is_empty_date(mtxt_eingang.Text) == false)
                            {
                                strX_date = mtxt_eingang.Text;
                                str_datart = "E";
                            }
                        }
                        else
                        {
                            if (AKK_Helper.is_empty_date(mtxt_rueck.Text) == false)
                            {
                                if (chk_rueck.Checked == true)
                                {
                                    strX_date = mtxt_rueck.Text;
                                    str_datart = "R";
                                }
                            }
                        }
                    }
                    //
                    // Klage
                    //
                    if (chk_ja.Checked == true)
                    {
                        str_klage = "-1";
                    }
                    else
                    {
                        if (chk_Nein.Checked == true)
                        {
                            str_klage = "0";
                        }
                        else
                        {
                            str_klage = "9";
                        }
                    }
                    //
                    // Trennzeichen
                    //
                    if (chk_tab.Checked == true)
                    {
                        str_trenn = "T";
                    }
                    else
                    {
                        if (chk_sp.Checked == true)
                        {
                            str_trenn = "S";
                        }
                        else
                        {
                            str_trenn = "K";
                        }

                    }
                    //
                    // konto
                    //
                    if (chk_kja.Checked == true)
                    {
                        str_konto = "0";
                    }
                    else
                    {
                        if (chk_knein.Checked == true)
                        {
                            str_konto = "1";
                        }
                        else
                        {
                            str_konto = "-1";
                        }
                    }


                    DateTime dt_date = new DateTime();
                    if (DateTime.TryParse(strX_date, out dt_date) == true)
                    {
                        cmd_export.Enabled = false;
                        cmd_schliessen.Enabled = false;

                        str_datum = dt_date.ToString().Substring(0, 2) +
                                    dt_date.ToString().Substring(3, 2) +
                                    dt_date.ToString().Substring(6, 4);

                        this.Cursor = Cursors.WaitCursor;

                        Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
                        DataService.DataServiceClient client = new DataService.DataServiceClient();

                        //client.generateSepaEinzugCompleted += generateSepaEinzugCompleted;
                        //client.generateSepaEinzugAsync(AKK_Helper.SessionToken, dt_date);

                        client.Export_WBDCompleted += Export_WBDCompleted;
                        client.Export_WBDAsync(AKK_Helper.SessionToken,
                                                AKK_Helper.UserId,
                                                str_status,
                                                str_konto,
                                                str_klage,
                                                str_datart,
                                                str_datum,
                                                str_trenn,
                                                txt_pfad.Text,
                                                str_statusWort);

                        strip_info.Text = "Export " + " am " +
                                          DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                          DateTime.Now.Hour.ToString("00") + " Uhr " +
                                          DateTime.Now.Minute.ToString("00") + " gestartet ...";


                    }
                    else
                    {
                        AKK_Helper.show_msg("Fehler beim Parsen des Datums - " + strX_date, strip_info, this.Cursor);
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Kein gültiges Datum erfasst", strip_info, this.Cursor);
                }
            }
        }
        private void Export_WBDCompleted(object sender, Export_WBDCompletedEventArgs args)
    {
            cmd_export.Enabled = true;
            cmd_schliessen.Enabled = true;

            this.Cursor = Cursors.Default;
            if (args.Result.ResponseCode == 0)
            {
                
                AKK_Helper.show_msg("WBD Export erfolgreich erstellt!", strip_info, this.Cursor);
                strip_info.Text = args.str_info.ToString();
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                    
                    AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("Fehler beim Erstellen WBD Exports - " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }

        }


        private void cob_status_Enter(object sender, EventArgs e)
        {
            label1.ForeColor =  AKK_Helper.c_get_focus;
        }
        private void cob_status_Leave(object sender, EventArgs e)
        {
            label1.ForeColor= AKK_Helper.c_lost_focus;
        }
        private void chk_eingang_Enter(object sender, EventArgs e)
        {
            chk_eingang.ForeColor = AKK_Helper.c_get_focus;
            mtxt_eingang.Enabled = true;
            mtxt_eingang.Text = str_date;
            mtxt_auszahl.Text = "";
            mtxt_rueck.Text = "";
            mtxt_eingang.SelectAll();
            mtxt_eingang.Focus();
            
        }
        private void chk_eingang_Click(object sender, EventArgs e)
        {
            if (chk_eingang.Checked == true)
            {
                mtxt_auszahl.Text = "";
                mtxt_eingang.Text = str_date;
                mtxt_rueck.Text = "";
            }
            else
            {
                mtxt_eingang.Text = "";
            }
        }
        private void mtxt_eingang_Enter(object sender, EventArgs e)
        {
            chk_eingang.ForeColor = AKK_Helper.c_get_focus;
            mtxt_eingang.SelectAll();
        }
        private void mtxt_eingang_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_eingang.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_eingang.Text) == false)
                {
                    mtxt_eingang.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_eingang.Text, strip_info, this.Cursor);
                    mtxt_eingang.SelectAll();
                }
            }
            chk_eingang.ForeColor = AKK_Helper.c_lost_focus;
        }
      
        private void chk_auszahl_Enter(object sender, EventArgs e)
        {
            chk_auszahl.ForeColor = AKK_Helper.c_get_focus;
            mtxt_auszahl.Enabled = true;
            mtxt_auszahl.Text = str_date;
            mtxt_eingang.Text = "";
            mtxt_rueck.Text = "";
            mtxt_auszahl.SelectAll();
            mtxt_auszahl.Focus();
        }
        private void chk_auszahl_Click(object sender, EventArgs e)
        {
            if (chk_auszahl.Checked == true)
            {
                mtxt_auszahl.Text = str_date;
                mtxt_eingang.Text = "";
                mtxt_rueck.Text = "";
            }
            else
            {
                mtxt_auszahl.Text = "";
            }
        }
        private void mtxt_auszahl_Enter(object sender, EventArgs e)
        {
            chk_auszahl.ForeColor = AKK_Helper.c_get_focus;
            mtxt_auszahl.SelectAll();
        }
        private void mtxt_auszahl_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_auszahl .Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_auszahl.Text) == false)
                {
                    mtxt_auszahl.Focus();
                    AKK_Helper.show_msg( AKK_Helper.str_error["FC009"] + " " + mtxt_auszahl.Text, strip_info, this.Cursor);
                    mtxt_auszahl.SelectAll();
                }
            }
            chk_auszahl.ForeColor = AKK_Helper.c_lost_focus;
        }
        
        private void chk_rueck_Enter(object sender, EventArgs e)
        {
            chk_rueck.ForeColor = AKK_Helper.c_get_focus;
            mtxt_rueck.Enabled = true;
            mtxt_rueck.Text = str_date;
            mtxt_eingang.Text = "";
            mtxt_auszahl.Text = "";
            mtxt_rueck.SelectAll();
            mtxt_rueck.Focus();
        }
        private void chk_rueck_Click(object sender, EventArgs e)
        {
            if (chk_rueck.Checked == true)
            {
                mtxt_auszahl.Text = "";
                mtxt_eingang.Text = "";
                mtxt_rueck.Text = str_date;
            }
            else
            {
                mtxt_rueck.Text = "";
            }
        }
        private void mtxt_rueck_Enter(object sender, EventArgs e)
        {
            chk_rueck.ForeColor = AKK_Helper.c_get_focus;
            mtxt_rueck.SelectAll();
        }
        private void mtxt_rueck_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_rueck.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_rueck.Text) == false)
                {
                    mtxt_rueck.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_rueck.Text, strip_info, this.Cursor);
                    mtxt_rueck.SelectAll();
                }
            }
            chk_rueck.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void chk_ja_Enter(object sender, EventArgs e)
        {
            chk_ja.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_ja_Leave(object sender, EventArgs e)
        {
            chk_ja.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_Nein_Enter(object sender, EventArgs e)
        {
            chk_Nein.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_Nein_Leave(object sender, EventArgs e)
        {
            chk_Nein.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_Beide_Enter(object sender, EventArgs e)
        {
            chk_Beide.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_Beide_Leave(object sender, EventArgs e)
        {
            chk_Beide.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_tab_Enter(object sender, EventArgs e)
        {
            chk_tab.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_tab_Leave(object sender, EventArgs e)
        {
            chk_tab.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_sp_Enter(object sender, EventArgs e)
        {
            chk_sp.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_sp_Leave(object sender, EventArgs e)
        {
            chk_sp.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_kanal_Enter(object sender, EventArgs e)
        {
            chk_kanal.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_kanal_Leave(object sender, EventArgs e)
        {
            chk_kanal.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_kja_Enter(object sender, EventArgs e)
        {
            chk_kja.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_kja_Leave(object sender, EventArgs e)
        {

            chk_kja.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_knein_Enter(object sender, EventArgs e)
        {
            chk_knein.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_knein_Leave(object sender, EventArgs e)
        {
            chk_knein.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_kegal_Enter(object sender, EventArgs e)
        {
            chk_kegal.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_kegal_Leave(object sender, EventArgs e)
        {
            chk_kegal.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void filllistbox()
        {    
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DC_Columns cols = new DC_Columns();
                    Response resp = null;
                    DataService.DataServiceClient client = new DataServiceClient();
                    //
                    // Bildungsträger
                    //
                    resp = null;
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST3", "");
                    if (resp.ResponseCode == 0)
                    {
                        AKK_Helper.fill_Listbox(cob_status, cols);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                }
                this.Cursor = Cursors.Default;
            }

        }

        # region LOG
        private void cmd_log_Click(object sender, EventArgs e)
        {

            if (AKK_Helper.checkLogin() == true)
            {
                grp_1.Visible = !grp_1.Visible;
                lst_info.Visible = !lst_info.Visible;
                strip_info.Text = "";
                txt_offset.Text = "100";

                AKK_Helper.Init_lst_info(lst_info);

                //lst_info.View = View.Details;
                //lst_info.Font = new Font(lst_info.Font.FontFamily, AKK_Helper.FontSize);
                //lst_info.GridLines = true;
                //lst_info.LabelEdit = true;
                //lst_info.AllowColumnReorder = true;
                //lst_info.CheckBoxes = false;
                //lst_info.FullRowSelect = true;
                //lst_info.Items.Clear();

                chk_wbd_log.Checked = false;
                chk_EXP_Log.Checked = false;
                if (grp_1.Visible == false)
                    strip_info.Text = "";
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
        //private void set_wbd()
        //{
        //    lst_info.Clear();  // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 
        //    lst_info.Columns.Add("Index", 00, HorizontalAlignment.Left);                  // 00
        //    lst_info.Columns.Add("Key", 50, HorizontalAlignment.Left);                    // 01
        //    lst_info.Columns.Add("Timestamp", 120, HorizontalAlignment.Left);             // 02
        //    lst_info.Columns.Add("Programm", 150, HorizontalAlignment.Left);              // 03
        //    lst_info.Columns.Add("Fehlerbeschreibung", 300, HorizontalAlignment.Left);    // 04
        //    lst_info.Columns.Add("Statement", 900, HorizontalAlignment.Left);             // 05
        //}
        //private void set_EXP()   //select err_user, err_datum, err_dl, err_text from WBD_ERROR
        //{
        //    lst_info.Clear();
        //    lst_info.Columns.Add("Index", 00, HorizontalAlignment.Left);                  // 00
        //    lst_info.Columns.Add("User", 50, HorizontalAlignment.Left);                   // 01
        //    lst_info.Columns.Add("Timestamp", 120, HorizontalAlignment.Left);             // 02
        //    lst_info.Columns.Add("DarlehnsNr.", 120, HorizontalAlignment.Left);           // 03
        //    lst_info.Columns.Add("Fehlerbeschreibung", 600, HorizontalAlignment.Left);    // 04
        //}
        private void chk_wbd_log_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_wbd(lst_info,"LOG1", txt_offset.Text, strip_info, this.Cursor);
        }
        private void chk_EX_Log_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "EX1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void cmd_print_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (AKK_Helper.Print_LST_Box(lst_info, -1, 20, 12, 0, -1) == true)
                {
                    AKK_Helper.show_msg("Druck erfolgreich  beendet!", strip_info, this.Cursor);
                }
            }
        }

        private void cob_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cob_status.SelectedIndex.ToString(), cob_status.Text);
        }

        private void cob_status_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cob_status);
        }
        #endregion

      

      
      
    }  // Form
}   // Namespace 


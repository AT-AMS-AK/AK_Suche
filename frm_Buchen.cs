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
using System.Text.RegularExpressions;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Buchen : Form
    {
        public string str_darlehensnr;
        public string str_antragsteller;
        public string str_WBDIkey;
        public string str_konto_real;

        public string AntId;
        //
        private Boolean is_Buch = true;
        private string str_lst_Buchungsdatum;
        private string str_lst_Betrag;
        private string str_lst_Art;
        private string str_lst_Typ;
        private string str_lst_Text;
        private string str_lst_Buchung_Ikey;
        private string str_lst_Storno;
        private string str_lst_Art_Ikey;
        private string str_lst_Typ_Ikey;
        internal DC_wbd_antrag antrag;

        public frm_Buchen()
        {
            InitializeComponent();
        }

        #region strip info
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
        private void frm_Buchen_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Buchen_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
            mtxt_buchungsdatum.Focus();
            mtxt_buchungsdatum.SelectAll();
        }
        #endregion

        private void frm_Buchen_Load(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                // labelDayDate.Text = System.DateTime.Today.DayOfWeek + ", " + System.DateTime.Today.Day + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Year;
                AKK_Helper.FindControls(this);

                txt_text.Height = (Int16)AKK_Helper.FontSize * 7;

                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                //
                this.Cursor = Cursors.WaitCursor;

                cmd_storno.Enabled = false;
                is_Buch = true;
                //
                mtxt_buchungsdatum.Mask = @"00\.00\.0000";
                mtxt_buchungsdatum.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");
                //
                txt_betrag.Text = AKK_Helper.FormatBetrag("0,00");
                txt_kontonr.Enabled = false;
                txt_kontonr.Text = str_darlehensnr;
                //
                txt_antragsteller.Enabled = false;
                txt_antragsteller.Text = str_antragsteller;
                //
                //
                // Init Buchungen
                //
                lst_buchungen.Clear();


                lst_buchungen.Columns.Add("Index", -1, HorizontalAlignment.Left);                      // 0
                lst_buchungen.Columns.Add("Datum", 85, HorizontalAlignment.Left);                      // 1
                lst_buchungen.Columns.Add("Betrag", 80, HorizontalAlignment.Right);                    // 2
                lst_buchungen.Columns.Add("B.-Art", 60, HorizontalAlignment.Left);                     // 3
                lst_buchungen.Columns.Add("B.-Typ", 60, HorizontalAlignment.Left);                     // 4
                lst_buchungen.Columns.Add("Buchungstext", 400, HorizontalAlignment.Left);              // 5
                lst_buchungen.Columns.Add("wbk_ikey", -1, HorizontalAlignment.Left);                   // 6
                lst_buchungen.Columns.Add("Storno", -1, HorizontalAlignment.Left);                     // 7
                lst_buchungen.Columns.Add("BUA_ikey", -1, HorizontalAlignment.Left);                   // 8
                lst_buchungen.Columns.Add("BUT_ikey", -1, HorizontalAlignment.Left);                   // 9

                lst_buchungen.View = View.Details;
                lst_buchungen.Font = new Font(lst_buchungen.Font.FontFamily, AKK_Helper.FontSize);
                lst_buchungen.GridLines = true;
                lst_buchungen.LabelEdit = true;
                lst_buchungen.AllowColumnReorder = true;
                lst_buchungen.CheckBoxes = false;
                lst_buchungen.FullRowSelect = true;
                lst_buchungen.MultiSelect = false;



                //
                // Fill buchungen
                //
                fill_buchungen();
                //
                // Buchungsart      
                //
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BCH1", "");
                if (resp.ResponseCode == 0)
                {
                    AKK_Helper.fill_Listbox(cbo_art, cols);
                    AKK_Helper.fill_dgv(dgv_art, cols);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }

                //
                // Buchungstyp 
                //
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BCH2", "");
                if (resp.ResponseCode == 0)
                {
                    AKK_Helper.fill_Listbox(cbo_typ, cols);
                    AKK_Helper.fill_dgv(dgv_typ, cols);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                AKK_Helper.ChangeBoxSel(cbo_art, AKK_Helper.C.strHABEN_CODE, 0, dgv_art);
                AKK_Helper.ChangeBoxSel(cbo_typ, AKK_Helper.C.strTILG_CODE, 2, dgv_typ);

                labelDayDate.Text = cols.Count.ToString() + " Buchungen gefunden";
                this.Cursor = Cursors.Default;
                txt_betrag.Text = AKK_Helper.FormatBetrag("0,00");


            }
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fill_buchungen()
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                //

                lst_buchungen.Items.Clear();

                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BCH3", str_WBDIkey);
                if (resp.ResponseCode == 0)
                {
                    Int32 i = 0;
                    for (Int32 index = 0; index < cols.Count; index++)
                    {
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());
                        //
                        LVI_ORA.SubItems.Add(cols[index].DM_col_01.ToString().Substring(0, 10));           // 1  Buchungsdatum
                        LVI_ORA.SubItems.Add(AKK_Helper.FormatBetrag(cols[index].DM_col_02.ToString())); // 2  Betrag
                        LVI_ORA.SubItems.Add(cols[index].DM_col_03.ToString());                            // 3  Type
                        LVI_ORA.SubItems.Add(cols[index].DM_col_04.ToString());                            // 4  Art
                        LVI_ORA.SubItems.Add(cols[index].DM_col_05.ToString());                            // 5  Buchungstext
                        LVI_ORA.SubItems.Add(cols[index].DM_col_06.ToString());                            // 6  wbk_ikey
                        LVI_ORA.SubItems.Add(cols[index].DM_col_07.ToString());                            // 7  Storno
                        LVI_ORA.SubItems.Add(cols[index].DM_col_08.ToString());                            // 8  Bua_Ikey_c
                        LVI_ORA.SubItems.Add(cols[index].DM_col_09.ToString());                            // 9  But_Ikey_c
                        //    

                        if (cols[index].DM_col_08.ToString() == "1")
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
                        LVI_ORA = null;
                    }

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }

            }
        }
        //
        // txt_Betrag
        //
        private void txt_betrag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = AKK_Helper.format_input_number(sender, e, txt_betrag.Text.ToString());
        }
        private void txt_betrag_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
            txt_betrag.SelectAll();
        }
        private void txt_betrag_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_lost_focus;
            txt_betrag.Text = AKK_Helper.FormatBetrag(txt_betrag.Text);
        }
        private void txt_betrag_MouseDown(object sender, MouseEventArgs e)
        {
            txt_betrag_Enter(sender, e);
        }

        private void txt_text_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_get_focus;
            cmd_buchen.IsAccessible = false;
        }
        private void txt_text_Leave(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_lost_focus;
            cmd_buchen.IsAccessible = true;
        }

        private void cbo_art_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_art);
        }
        private void cbo_typ_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_typ);
        }

        private void cbo_art_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_art_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cbo_typ_Enter(object sender, EventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_typ_Leave(object sender, EventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void mtxt_buchungsdatum_Enter(object sender, EventArgs e)
        {
            label7.ForeColor = AKK_Helper.c_get_focus;
            mtxt_buchungsdatum.SelectAll();
        }
        private void mtxt_buchungsdatum_Leave(object sender, EventArgs e)
        {

            if (AKK_Helper.is_empty_date(mtxt_buchungsdatum.Text) == true)
            {
                AKK_Helper.show_msg("Es wurde kein gültiges Datum eingegeben", strip_info, this.Cursor);

                mtxt_buchungsdatum.Focus();
                mtxt_buchungsdatum.SelectAll();
            }
            else
            {
                if (AKK_Helper.is_date(mtxt_buchungsdatum.Text) == false)
                {
                    AKK_Helper.show_msg("Es wurde kein gültiges Datum eingegeben - " + mtxt_buchungsdatum.Text, strip_info, this.Cursor);
                    mtxt_buchungsdatum.Focus();
                    mtxt_buchungsdatum.SelectAll();
                }
                else
                {
                    DateTime DT_now = DateTime.Now;
                    DateTime DT_BUCH = new DateTime();

                    DateTime.TryParse(mtxt_buchungsdatum.Text, out DT_BUCH);

                    if (DT_BUCH > DT_now)
                    {
                        AKK_Helper.show_msg("Das Buchungsdatumn muß vor dem Tagesdatum liegen - " + mtxt_buchungsdatum.Text, strip_info, this.Cursor);
                        mtxt_buchungsdatum.Focus();
                        mtxt_buchungsdatum.SelectAll();
                    }

                }
            }
            label7.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_buchungsdatum_MouseDown(object sender, MouseEventArgs e)
        {
            mtxt_buchungsdatum_Enter(sender, e);
        }

        private void lst_buchungen_Click(object sender, EventArgs e)
        {
            if (is_Buch == true)
            {
                is_Buch = false;
            }
            else
            {
                ListViewItem li = null;
                for (int i = lst_buchungen.SelectedItems.Count - 1; i >= 0; i--)
                {
                    li = lst_buchungen.SelectedItems[i];
                    i = 0;
                }
                // save values  
                str_lst_Buchungsdatum = li.SubItems[1].Text.ToString();   // Buchungsdatum
                str_lst_Betrag = li.SubItems[2].Text.ToString();   // Betrag
                str_lst_Art = li.SubItems[3].Text.ToString();   // Art
                str_lst_Typ = li.SubItems[4].Text.ToString();   // Typ
                str_lst_Text = li.SubItems[5].Text.ToString();   // text
                str_lst_Buchung_Ikey = li.SubItems[6].Text.ToString();   // Buchungsikey
                str_lst_Storno = li.SubItems[7].Text.ToString();   // Storno
                str_lst_Art_Ikey = li.SubItems[8].Text.ToString();   // Buchzngsart Ikey
                str_lst_Typ_Ikey = li.SubItems[9].Text.ToString();   // Buchungstyp Ikey
                //
                if (str_lst_Storno != "0")
                {

                    AKK_Helper.show_msg("Stornierte Buchungen können nicht storniert werden!", strip_info, this.Cursor);
                    cmd_storno.Enabled = false;
                    return;

                }
                cmd_storno.Enabled = true;



            }
        }
        private void cmd_buchen_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }
                else
                {

                    double dbl_Betrag = 0;
                    Double.TryParse(txt_betrag.Text, out dbl_Betrag);
                    if ((dbl_Betrag == 0) ||
                        (AKK_Helper.is_empty_date(mtxt_buchungsdatum.Text) == true) ||
                        (cbo_art.SelectedIndex < 0) ||
                        (cbo_typ.SelectedIndex < 0))
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.show_msg("Betrag, Datum, Buchungsart und Buchungstyp müssen erfasst werden!", strip_info, this.Cursor);
                        txt_betrag.Focus();
                    }
                    else
                    {


                        Response resp = new Response();
                        DC_Columns cols = new DC_Columns();
                        DataService.DataServiceClient client = new DataServiceClient();


                        //var buchungsDatum = AuthHelper.ChangeDateFormatForDatabase(txtBuchungsdatum.Text);
                        var buchungsDatum = mtxt_buchungsdatum.Text;
                        var betrag = txt_betrag.Text;
                        var buchungsTyp = cbo_typ.SelectedValue.ToString();
                        var buchungsArt = cbo_art.SelectedValue.ToString(); // 2=="SOLL"

                        var nachzahlungsGesamtbetrag = client.GetNachzahlungsbetrag(this.AntId);

                        if (buchungsTyp == "13" && buchungsArt == "1")
                        {
                            AKK_Helper.show_msg($"Nachzahlung kann nur under \"SOLL\" gebucht werden.", strip_info, this.Cursor);
                            return;
                        }



                        if (buchungsTyp == "13" && buchungsArt == "2")
                        {
                            if (nachzahlungsGesamtbetrag <= 0)
                            {
                                AKK_Helper.show_msg($"Für diesen Antrag gibt es noch keinen Nachzahlungsbetrag.", strip_info, this.Cursor);
                                return;
                            }

                            if (nachzahlungsGesamtbetrag != (int)Double.Parse(betrag))
                            {
                                AKK_Helper.show_msg($"Betrag muss gleich hoch sein wie der gespeicherte Nachzahlungsbetrag! ({nachzahlungsGesamtbetrag})", strip_info, this.Cursor);
                                return;
                            }


                            var nachzahlungsdatum = antrag.Nachzahlungsdatum;
                            if (!String.IsNullOrEmpty(nachzahlungsdatum))
                            {
                                AKK_Helper.show_msg($"Nachzahlung wurde für diesen Antrag bereits ausgezahlt!", strip_info, this.Cursor);
                                return;
                            }
                        }



                        string str_new_konto_stand;

                        var buchungsbetrag = Regex.Replace(txt_betrag.Text, @"\s+", "");

                        resp = client.Update_Buchung(out str_new_konto_stand,
                                                     AKK_Helper.SessionToken,
                                                     AKK_Helper.UserId,
                                                     str_WBDIkey,
                                                     str_darlehensnr,
                                                     mtxt_buchungsdatum.Text,
                                                     buchungsbetrag,
                                                     cbo_art.SelectedValue.ToString(),
                                                     cbo_typ.SelectedValue.ToString(),
                                                     txt_text.Text,
                                                     "0",                           // kein STORNO   
                                                     "-1");                         // keine neue Buchung
                        if (resp.ResponseCode == 0)
                        {
                            //
                            // Fill buchungen
                            //
                            fill_buchungen();
                            //
                            // Set new KONTOSTAND
                            //
                            str_konto_real = str_new_konto_stand;
                            //
                            // reset parameters
                            //
                            AKK_Helper.ChangeBoxSel(cbo_art, AKK_Helper.C.strHABEN_CODE, 0, dgv_art);
                            AKK_Helper.ChangeBoxSel(cbo_typ, AKK_Helper.C.strTILG_CODE, 2, dgv_typ);

                            txt_betrag.Text = AKK_Helper.FormatBetrag("0,00");
                            txt_betrag.Focus();
                            txt_betrag.SelectAll();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                    }
                }
            }
        }
        private void cmd_storno_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }
                else
                {
                    if (lst_buchungen.SelectedItems.Count > 0)
                    {
                        //str_lst_Buchungsdatum = li.SubItems[1].Text.ToString();   // Buchungsdatum
                        //str_lst_Betrag        = li.SubItems[2].Text.ToString();   // Betrag
                        //str_lst_Art           = li.SubItems[3].Text.ToString();   // Art
                        //str_lst_Typ           = li.SubItems[4].Text.ToString();   // Typ
                        //str_lst_Text          = li.SubItems[5].Text.ToString();   // text
                        //str_lmst_Buchung_Ikey  = li.SubItems[6].Text.ToString();   // Buchungsikey
                        //str_lst_Storno        = li.SubItems[7].Text.ToString();   // Storno
                        //str_lst_Art_Ikey      = li.SubItems[8].Text.ToString();   // Buchungsart Ikey
                        //str_lst_Typ_Ikey      = li.SubItems[9].Text.ToString();   // Buchungstyp Ikey

                        string str_Date = DateTime.Now.Date.ToString("dd.MM.yyyy");

                        double dbl_Betrag = 0;
                        Double.TryParse(str_lst_Betrag, out dbl_Betrag);

                        Response resp = new Response();
                        DC_Columns cols = new DC_Columns();
                        DataService.DataServiceClient client = new DataServiceClient();

                        string str_new_konto_stand = "";
                        //
                        resp = client.Update_Buchung(out str_new_konto_stand,
                                                     AKK_Helper.SessionToken,
                                                     AKK_Helper.UserId,
                                                     str_WBDIkey,
                                                     str_darlehensnr,
                                                     str_Date,
                                                     str_lst_Betrag,
                                                     str_lst_Art_Ikey,
                                                     str_lst_Typ_Ikey,
                                                     str_lst_Text,
                                                     "1",                           // EIN STORNO   
                                                     str_lst_Buchung_Ikey);         // storniere alte Buchung
                        if (resp.ResponseCode == 0)
                        {
                            //
                            // Fill buchungen
                            //
                            fill_buchungen();
                            //
                            // Set new KONTOSTAND
                            //
                            str_konto_real = str_new_konto_stand;
                            //
                            // reset parameters
                            //
                            AKK_Helper.ChangeBoxSel(cbo_art, AKK_Helper.C.strHABEN_CODE, 0, dgv_art);
                            AKK_Helper.ChangeBoxSel(cbo_typ, AKK_Helper.C.strTILG_CODE, 2, dgv_typ);
                            //
                            txt_betrag.Text = AKK_Helper.FormatBetrag("0,00");
                            txt_betrag.Focus();
                            txt_betrag.SelectAll();
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                    }
                    else
                    {
                        AKK_Helper.show_msg("Keine gültige Buchung selektiert!", strip_info, this.Cursor);
                        txt_betrag.Focus();
                        txt_betrag.SelectAll();
                    }
                    cmd_storno.Enabled = false;
                }   // Lock

            }
        }


        private void txt_text_KeyPress(object sender, KeyPressEventArgs e)
        {


        }

        private void mtxt_buchungsdatum_Click(object sender, EventArgs e)
        {
            label7.ForeColor = AKK_Helper.c_get_focus;
            mtxt_buchungsdatum.SelectAll();
        }


    }  // Form
}      // Namespace

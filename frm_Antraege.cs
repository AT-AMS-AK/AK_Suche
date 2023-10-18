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
using Addit.AK.WBD.AK_Suche.DataService;
using Addit.AK.WBD.AK_Suche.AuthService;
using Miracle.MPP.WebPCI;
using System.Text.RegularExpressions;



namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Antraege : Form
    {

        private Color c_get_focus = Color.Blue;
        private Color c_lost_focus = Color.Black;
        private int save_i;

        public Miracle.MPP.WebPCI.DataObject PVS_do_WE;
        public Miracle.MPP.WebPCI.Window PVS_wnd_WE;

        public frm_Antraege()
        {
            InitializeComponent();
        }

        public DC_get_person_antrag obj_ak_Per_Ant { set; get; }
        public clsA_PVS_connection PVS_CON { set; get; }
        public User my_User { set; get; }
        #region strip
        private void frm_Antraege_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);

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
        private void frm_Antraege_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        #endregion
        private void frm_Antraege_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);


            label10.Font = new Font(label1.Font.FontFamily, AKK_Helper.FontSizeFrm);
            label10.Height = (Int16)AKK_Helper.FontSizeFrm * 2;
            //
            // 03-09-2012 by KJ
            //if (PVS_CON.PVS_APP.Connected == true)
            //    lblCON.Text = "on";
            //else
            //    lblCON.Text = "off";
            // 03-09-2012 by KJ
            //
            // labelDayDate.Text = System.DateTime.Today.DayOfWeek + ", " + System.DateTime.Today.Day + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Year;
            // read the current status of the specified keys
            strip_info.Text = "Version " + AKK_Helper.obj_version.str_version + " Datum " + AKK_Helper.obj_version.str_version_date + "    " + AKK_Helper.UserName + " (" + AKK_Helper.UserId + ")";
            lst_Output.Clear();

            lst_Output.Columns.Add("Index", -1, HorizontalAlignment.Left);                     // 0
            lst_Output.Columns.Add("Antrags-ID", 150, HorizontalAlignment.Left);              // 1
            lst_Output.Columns.Add("Eingangsdatum", 100, HorizontalAlignment.Left);           // 2
            lst_Output.Columns.Add("Betrag", 100, HorizontalAlignment.Right);                 // 3
            lst_Output.Columns.Add("Verständigungsdatum", 100, HorizontalAlignment.Left);     // 4
            lst_Output.Columns.Add("Auszahlungsdatum", 100, HorizontalAlignment.Left);        // 5
            lst_Output.Columns.Add("Status", 105, HorizontalAlignment.Left);                  // 6
            lst_Output.Columns.Add("Verwendungszweck", 50, HorizontalAlignment.Left);         // 7
            lst_Output.Columns.Add("ant_ikey", -1, HorizontalAlignment.Left);                 // 8
            lst_Output.Columns.Add("ant_ikey_c", -1, HorizontalAlignment.Left);               // 9
            lst_Output.Columns.Add("std_ikey", -1, HorizontalAlignment.Left);                 // 10
            lst_Output.Columns.Add("knt_ikey", -1, HorizontalAlignment.Left);                 // 11
            lst_Output.Columns.Add("ant_bez_am", -1, HorizontalAlignment.Left);               // 12
            lst_Output.Columns.Add("ant_svnr", -1, HorizontalAlignment.Left);                 // 13
            lst_Output.Columns.Add("ant_lock", -1, HorizontalAlignment.Left);                 // 14
            lst_Output.Columns.Add("ant_std_extdoid_fkey", -1, HorizontalAlignment.Left);     // 15
            lst_Output.Columns.Add("ant_code_c", -1, HorizontalAlignment.Left);               // 16
            lst_Output.Columns.Add("ant_status", -1, HorizontalAlignment.Left);               // 17
            lst_Output.Columns.Add("wbd_ueber_fkey", -1, HorizontalAlignment.Left);           // 18

            lst_Output.Columns.Add("BLZ", 150, HorizontalAlignment.Left);                      // 19
            lst_Output.Columns.Add("Bankname", 100, HorizontalAlignment.Left);                 // 20
            lst_Output.Columns.Add("Anmerkung", 100, HorizontalAlignment.Left);                // 21
            lst_Output.Columns.Add("Kontonummer", 150, HorizontalAlignment.Left);              // 22
            lst_Output.Columns.Add("BIC", 100, HorizontalAlignment.Left);                      // 23
            lst_Output.Columns.Add("IBAN", 150, HorizontalAlignment.Left);                     // 24

            lst_Output.View = View.Details;
            lst_Output.Font = new Font(lst_Output.Font.FontFamily, AKK_Helper.FontSize);
            lst_Output.GridLines = true;
            lst_Output.LabelEdit = true;
            lst_Output.AllowColumnReorder = true;
            lst_Output.CheckBoxes = false;
            lst_Output.FullRowSelect = true;

            fill_listbox();

            txt_svnr.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_svnr.ToString();
            txt_zuname.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_nachname.ToString();
            txt_vorname.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_vorname.ToString();
            if (obj_ak_Per_Ant.obj_lst_ak_person[0].DM_geschlecht.ToString() == "W" || obj_ak_Per_Ant.obj_lst_ak_person[0].DM_geschlecht.ToString() == "w")
                txt_geschlecht.Text = "weiblich";
            else
                txt_geschlecht.Text = "männlich";
            txt_strasse.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_strassename.ToString()
                             + " " + obj_ak_Per_Ant.obj_lst_ak_person[0].DM_hausnr.ToString()
                             + " " + obj_ak_Per_Ant.obj_lst_ak_person[0].DM_tuer.ToString();
            txt_ort.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_ortname.ToString();
            txt_plz.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_plz.ToString();

            txt_personid.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_person_id.ToString();
            txt_PVS_ID.Text = obj_ak_Per_Ant.obj_lst_ak_person[0].DM_PVS_ID.ToString();

            if (lst_Output.Items.Count > 0)
            {
                ListViewItem li = null;
                li = lst_Output.Items[0];

                txt_blz.Text = li.SubItems[19].Text.ToString();
                txt_bank.Text = li.SubItems[20].Text.ToString();
                txt_bank_ort.Text = li.SubItems[21].Text.ToString();
                txt_ktonr.Text = li.SubItems[22].Text.ToString();
                txt_bic.Text = li.SubItems[23].Text.ToString();
                txt_iban.Text = li.SubItems[24].Text.ToString();
            }

            cmd_std_bearbeitern.Enabled = false;
            cmd_antrag_neu.Enabled = false;

            panelHideBank.Visible = true;

            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_std_bearbeitern.Enabled = true;
                cmd_antrag_neu.Enabled = true;
            }
            else
            {    // CanWrite = False
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Info_Stammdaten_Bearbeiten == AKK_Helper.c_Yes) cmd_std_bearbeitern.Enabled = true;
                    if (AKK_Helper.C.strG_Info_Antrag_Neu == AKK_Helper.c_Yes) cmd_antrag_neu.Enabled = true;
                }
            }
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void cmd_std_bearbeiten_Click(object sender, EventArgs e)
        {

            //
            // enable PVS Windows 
            //
            // 30-10-2012 by KJ - zusätzliche try-catch Blöcke eingebaut
            //                    FM : Fehler beim Starten der PVS -
            //                    ohne Angabe der Exception ???
            //
            this.Cursor = Cursors.WaitCursor;
            strip_info.Text = txt_personid.Text + " : Personenverwaltung wird gestartet . . .";
            try
            {
                //AKK_Helper.show_msg("TEST David Stefitz " + AKK_Helper.PVS_CON.User + " - " + AKK_Helper.PVS_CON.PW + " - " + AKK_Helper.PVS_CON.CreatorName + " - " + AKK_Helper.PVS_CON.Databasename + " - " + AKK_Helper.PVS_CON.Nodename + " - " + AKK_Helper.PVS_CON.Version + " - " + AKK_Helper.PVS_CON.PVS_APP.URL + " - " + AKK_Helper.PVS_CON.PVS_APP.Path, strip_info, this.Cursor);

                if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                {

                    try
                    {
                        string str_where = "PersonID = " + txt_personid.Text;
                        Miracle.MPP.WebPCI.Collection pvs_col = PVS_CON.PVS_APP.SelectWhere("PE", str_where, null, null);
                        if (pvs_col.Count > 0)
                        {
                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                            {
                                try
                                {
                                    PVS_do_WE = pvs_do;             // Create Dataobject
                                    PVS_do_WE.OnUpdate += new Miracle.MPP.WebPCI.DataObject.OnUpdateEventHandler(PVS_do_WE_OnUpdate);
                                    try
                                    {
                                        PVS_wnd_WE = pvs_do.Edit();  // Create Window
                                        PVS_wnd_WE.SetAssignMode("addIT", false);
                                        // PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                                        try
                                        {
                                            PVS_wnd_WE.Activate();         // activate Window 
                                        }
                                        catch (Exception ex)
                                        {
                                            AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + " EC004 " + ex.InnerException, strip_info, this.Cursor);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + " EC003 " + ex.InnerException, strip_info, this.Cursor);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + " EC002 " + ex.InnerException, strip_info, this.Cursor);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + " EC001 " + ex.InnerException, strip_info, this.Cursor);
                    }
                }
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + ex.InnerException, strip_info, this.Cursor);
            }
            strip_info.Text = "";
            this.Cursor = Cursors.Default;

        }
        private void cmd_antrag_bearbeiten_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {


                if (lst_Output.Items.Count == 1)
                    lst_Output.Items[0].Selected = true;
                if (lst_Output.SelectedItems.Count >= 1)
                {
                    ListViewItem li = null;
                    for (int i = lst_Output.SelectedItems.Count - 1; i >= 0; i--)
                    {

                        li = lst_Output.SelectedItems[i];
                        save_i = li.Index; ;
                        i = 0;
                    }
                    DC_ak_suche obj_suche = new DC_ak_suche();
                    obj_suche.DM_ant_ikey = li.SubItems[8].Text.ToString();   // ant_ID

                    DC_ak_antraege obj_antrag = new DC_ak_antraege();

                    obj_antrag.DM_ant_id = li.SubItems[1].Text.ToString();                       // 1
                    obj_antrag.DM_ant_eing_dat = li.SubItems[2].Text.ToString();                 // 2
                    obj_antrag.DM_ant_betrag = li.SubItems[3].Text.ToString();                   // 3
                    obj_antrag.DM_ant_verst_am = li.SubItems[4].Text.ToString();                 // 4
                    obj_antrag.DM_wbd_ausz_am = li.SubItems[5].Text.ToString();                  // 5
                    obj_antrag.DM_ast_typ_c = li.SubItems[6].Text.ToString();                    // 6
                    obj_antrag.DM_vwz_code_c = li.SubItems[7].Text.ToString();                   // 7

                    obj_antrag.DM_ant_ikey = li.SubItems[8].Text.ToString();                     // 8
                    obj_antrag.DM_ant_ikey_c = li.SubItems[9].Text.ToString();                   // 9
                    obj_antrag.DM_std_fkey = li.SubItems[10].Text.ToString();                    // 10
                    obj_antrag.DM_knt_fkey = li.SubItems[11].Text.ToString();                    // 11
                    obj_antrag.DM_ant_bez_am = li.SubItems[12].Text.ToString();                  // 12
                    obj_antrag.DM_ant_svnr = li.SubItems[13].Text.ToString();                    // 13
                    obj_antrag.DM_ant_lock = li.SubItems[14].Text.ToString();                    // 14
                    obj_antrag.DM_std_extdoid_fkey = li.SubItems[15].Text.ToString();            // 15
                    obj_antrag.DM_ant_code_c = li.SubItems[16].Text.ToString();                  // 16
                    obj_antrag.DM_ant_status = li.SubItems[17].Text.ToString();                  // 17
                    obj_antrag.DM_wbd_ueber_fkey = li.SubItems[18].Text.ToString();              // 18 

                    Boolean is_ok = show_wbd_antrag_data(obj_suche, obj_antrag);
                }
                else
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC004"], strip_info, this.Cursor);
                }

            }
        }
        private void cmd_antrag_neu_Click(object sender, EventArgs e)
        {
            Boolean bol_hasAntrag;
            bol_hasAntrag = false;

            ListViewItem li = null;
            for (int i = lst_Output.Items.Count - 1; i >= 0; i--)
            {
                li = lst_Output.Items[i];
                if ((li.SubItems[6].Text.ToString() != "Tilgung") &&    // Negativ
                    (li.SubItems[6].Text.ToString() != "Negativ"))      // Tilgung
                {
                    bol_hasAntrag = true;
                    i = 0;
                }
            }

            if (bol_hasAntrag == true)
            {
                AKK_Helper.show_msg("Antragsteller hat bereits ein laufendes Darlehen!", strip_info, this.Cursor);
            }

            if (AKK_Helper.checkLogin() == true)
            {



                // SELECT d.ANT_IKEY, d.WBD_ANT_ID, vwz_ikey_c FROM AKF_ANTRAEGE a, WBD_DATA d WHERE a.ANT_IKEY = d.ANT_IKEY 
                // AND a.ANT_IKEY_C = 2 AND a.STD_FKEY = 'DO\PE\$101000001414590' AND d.WBD_TILG_AM IS NULL



                DC_wbd_antrag obj_Wbd_Antrag = new DC_wbd_antrag();
                DC_ak_antraege obj_antrag = new DC_ak_antraege();

                obj_Wbd_Antrag.DM_ant_ikey = "-1";
                if (obj_Wbd_Antrag != null)
                {
                    frm_wbd_antrag frm_wbd_Antrag = new frm_wbd_antrag();
                    frm_wbd_Antrag.obj_wbd_antrag = obj_Wbd_Antrag;
                    frm_wbd_Antrag.obj_person = obj_ak_Per_Ant.obj_lst_ak_person[0];
                    frm_wbd_Antrag.obj_antrag = obj_antrag;
                    frm_wbd_Antrag.PVS_CON = PVS_CON;

                    frm_wbd_Antrag.ShowDialog();

                    obj_antrag = frm_wbd_Antrag.obj_antrag;
                    frm_wbd_Antrag = null;

                    if (obj_antrag != null)
                    {
                        int int_count = lst_Output.Items.Count + 1;
                        ListViewItem LVI_ORA = new ListViewItem(int_count.ToString());

                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_id);                      // 1
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_eing_dat);                // 2

                        LVI_ORA.SubItems.Add(AKK_Helper.FormatBetragOhneKomma(
                                         obj_antrag.DM_ant_betrag));                     // 06-07-2011 by KJ Formatierung hat gefehlt
                        // LVI_ORA.SubItems.Add(obj_antrag.DM_ant_betrag);               // 3
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_verst_am);                // 4
                        LVI_ORA.SubItems.Add(obj_antrag.DM_wbd_ausz_am);                 // 5
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ast_typ_c);                   // 6
                        LVI_ORA.SubItems.Add(obj_antrag.DM_vwz_code_c);                  // 7

                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_ikey);                    // 8
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_ikey_c);                  // 9
                        LVI_ORA.SubItems.Add(obj_antrag.DM_std_fkey);                    // 10
                        LVI_ORA.SubItems.Add(obj_antrag.DM_knt_fkey);                    // 11
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_bez_am);                  // 12
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_svnr);                    // 13
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_lock);                    // 14
                        LVI_ORA.SubItems.Add(obj_antrag.DM_std_extdoid_fkey);            // 15
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_code_c);                  // 16
                        LVI_ORA.SubItems.Add(obj_antrag.DM_ant_status);                  // 17
                        LVI_ORA.SubItems.Add(obj_antrag.DM_wbd_ueber_fkey);              // 18
                        // if (obj_antrag.DM_wbd_ueber_fkey != null)
                        if (AKK_Helper.is_empty(obj_antrag.DM_wbd_ueber_fkey) == false)
                        {
                            DC_bankverbindung_data BV = AKK_Helper.read_BV(obj_antrag.DM_wbd_ueber_fkey);
                            LVI_ORA.SubItems.Add(BV.DM_str_blz);
                            LVI_ORA.SubItems.Add(BV.DM_str_name);
                            LVI_ORA.SubItems.Add(BV.DM_str_anmerkung);
                            LVI_ORA.SubItems.Add(BV.DM_str_kontonr);
                            LVI_ORA.SubItems.Add(BV.DM_str_bic);
                            LVI_ORA.SubItems.Add(BV.DM_str_iban);


                            BV = null;
                        }
                        else
                        {
                            LVI_ORA.SubItems.Add("");            // 19
                            LVI_ORA.SubItems.Add("");            // 20
                            LVI_ORA.SubItems.Add("");            // 21 
                            LVI_ORA.SubItems.Add("");            // 22   
                            LVI_ORA.SubItems.Add("");            // 23   
                            LVI_ORA.SubItems.Add("");            // 24   
                        }
                        lst_Output.Items.Add(LVI_ORA);
                        LVI_ORA = null;
                    }
                }
            }
        }
        private void fill_listbox()
        {
            if ((obj_ak_Per_Ant != null) & (obj_ak_Per_Ant.obj_lst_ak_antraege != null))
            {
                lst_Output.Items.Clear();
                Int32 int_ant_count = obj_ak_Per_Ant.obj_lst_ak_antraege.Count;


                for (Int32 i = 0; i < int_ant_count; i++)
                {
                    ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_id);                      // 1
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_eing_dat);                // 2
                    LVI_ORA.SubItems.Add(AKK_Helper.FormatBetragOhneKomma(
                                      obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_betrag));                   // 3
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_verst_am);                // 4
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_wbd_ausz_am);                 // 5
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ast_typ_c);                   // 6
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_vwz_code_c);                  // 7

                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_ikey);                    // 8
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_ikey_c);                  // 9
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_std_fkey);                    // 10
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_knt_fkey);                    // 11
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_bez_am);                  // 12
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_svnr);                    // 13
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_lock);                    // 14
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_std_extdoid_fkey);            // 15
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_code_c);                  // 16
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_status);                  // 17
                    LVI_ORA.SubItems.Add(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_wbd_ueber_fkey);              // 18
                    // if (obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_wbd_ueber_fkey != null)
                    if (AKK_Helper.is_empty(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_wbd_ueber_fkey) == false)
                    {
                        DC_bankverbindung_data BV = AKK_Helper.read_BV(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_wbd_ueber_fkey);
                        LVI_ORA.SubItems.Add(BV.DM_str_blz);
                        LVI_ORA.SubItems.Add(BV.DM_str_name);
                        LVI_ORA.SubItems.Add(BV.DM_str_anmerkung);
                        LVI_ORA.SubItems.Add(BV.DM_str_kontonr);
                        LVI_ORA.SubItems.Add(BV.DM_str_bic);
                        LVI_ORA.SubItems.Add(BV.DM_str_iban);

                        if (AKK_Helper.FormatBetragOhneKomma(
                                       obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_betrag).Equals("12"))
                        {
                            string x = "12";
                        }

                        BV = null;
                    }   
                        //MiRo load data from the database
                    else if (AKK_Helper.is_empty(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_wbd_ueber_fkey) && !AKK_Helper.is_empty(obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_ikey))
                    {
                        DC_ak_suche obj_suche = new DC_ak_suche();
                        obj_suche.DM_ant_ikey = obj_ak_Per_Ant.obj_lst_ak_antraege[i].DM_ant_ikey;
                        DC_wbd_antrag obj_Wbd_Antrag = new DC_wbd_antrag();
                        DataService.DataServiceClient client = new DataServiceClient();
                        DataService.Response resp = client.Get_Wbd_Antrag(out obj_Wbd_Antrag, obj_suche, AKK_Helper.SessionToken);

                        if (resp.ResponseCode == 0)
                        {
                            LVI_ORA.SubItems.Add("");
                            LVI_ORA.SubItems.Add(obj_Wbd_Antrag.DM_wbd_ownerIn); //TODO checken
                            LVI_ORA.SubItems.Add(obj_Wbd_Antrag.DM_wbd_anmerk);
                            LVI_ORA.SubItems.Add("");
                            LVI_ORA.SubItems.Add("");
                            LVI_ORA.SubItems.Add(obj_Wbd_Antrag.DM_wbd_ibanIn);
                        }
                        resp = null;
                        client = null;
                        obj_Wbd_Antrag = null;
                        obj_suche = null;

                    }
                    else
                    {
                        LVI_ORA.SubItems.Add("");   // 19
                        LVI_ORA.SubItems.Add("");  // 20
                        LVI_ORA.SubItems.Add("");            // 21 
                        LVI_ORA.SubItems.Add("");            // 23  
                        LVI_ORA.SubItems.Add("");            // 24 
                        LVI_ORA.SubItems.Add("");
                    }
                    lst_Output.Items.Add(LVI_ORA);
                    LVI_ORA = null;

                }

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
            // li = lst_Output.Items[0];
            txt_blz.Text = li.SubItems[19].Text.ToString();
            txt_bank.Text = li.SubItems[20].Text.ToString();
            txt_bank_ort.Text = li.SubItems[21].Text.ToString();
            txt_ktonr.Text = li.SubItems[22].Text.ToString();
            txt_bic.Text = li.SubItems[23].Text.ToString();
            txt_iban.Text = li.SubItems[24].Text.ToString();
            li = null;
        }

        //public Boolean check_PVS()
        //{
        //    this.Cursor = Cursors.WaitCursor;
        //    if ((PVS_CON.PVS_APP == null) || (PVS_CON.PVS_APP.Connected == false))
        //    {
        //        PVS_CON.PVS_APP.CreatorPCIVersion = PVS_CON.Version;
        //        PVS_CON.PVS_APP.CreatorName = PVS_CON.CreatorName;
        //        PVS_CON.PVS_APP.NodeName = PVS_CON.Nodename;
        //        PVS_CON.PVS_APP.DatabaseName = PVS_CON.Databasename;
        //        PVS_CON.PVS_APP.Visible = false;
        //        PVS_CON.PVS_APP.Connect(PVS_CON.User, PVS_CON.PW);
        //        PVS_CON.PVS_APP.Visible = false;
        //    }
        //    //else
        //    //{
        //    //    if (PVS_CON.PVS_APP.Connected == false)
        //    //    {
        //    //        PVS_CON.PVS_APP.CreatorPCIVersion = PVS_CON.Version;
        //    //        PVS_CON.PVS_APP.CreatorName = PVS_CON.CreatorName;
        //    //        PVS_CON.PVS_APP.NodeName = PVS_CON.Nodename;
        //    //        PVS_CON.PVS_APP.DatabaseName = PVS_CON.Databasename;
        //    //        PVS_CON.PVS_APP.Visible = false;
        //    //        PVS_CON.PVS_APP.Connect(PVS_CON.User, PVS_CON.PW);
        //    //        PVS_CON.PVS_APP.Visible = false;
        //    //    }
        //    //}
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
            }

        }
        public Boolean get_PVS_Data(Miracle.MPP.WebPCI.DataObject PVS_do)
        {
            //Miracle.MPP.WebPCI.Field f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(35);     // Nachname 35
            //Miracle.MPP.WebPCI.Field f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(36);     // Vorname 36
            //Miracle.MPP.WebPCI.Field f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(37);     // SVNR 37
            //Miracle.MPP.WebPCI.Field f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(39);     // Geschlecht  39
            //Miracle.MPP.WebPCI.Field f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(38);     // GebDat 38

            //Miracle.MPP.WebPCI.Field f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(20);     // PLZ 20
            //Miracle.MPP.WebPCI.Field f7 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(14);     // Ortsname 14
            //Miracle.MPP.WebPCI.Field f8 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(23);     // Strassenname 23
            //Miracle.MPP.WebPCI.Field f9 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(24);     // Hausnummer 24
            //Miracle.MPP.WebPCI.Field f10 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(25);    // Tuer 25

            //Miracle.MPP.WebPCI.Field f11 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(43);    // akad.Titel 43
            //Miracle.MPP.WebPCI.Field f12 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(7);     // NationID 7
            //Miracle.MPP.WebPCI.Field f13 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(0);     // PVS_ID 0
            //Miracle.MPP.WebPCI.Field f14 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(34);    // PersonID 34


            Miracle.MPP.WebPCI.Field f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Nachname"];       // Nachname 35
            Miracle.MPP.WebPCI.Field f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Vorname"];        // Vorname 36
            Miracle.MPP.WebPCI.Field f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["SVNR"];           // SVNR 37
            Miracle.MPP.WebPCI.Field f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Geschlecht"];     // Geschlecht  39
            Miracle.MPP.WebPCI.Field f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["GebDat"];         // GebDat 38

            Miracle.MPP.WebPCI.Field f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["PLZ"];            // PLZ 20
            Miracle.MPP.WebPCI.Field f7 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Ortsname"];       // Ortsname 14
            Miracle.MPP.WebPCI.Field f8 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Strassenname"];   // Strassenname 23
            Miracle.MPP.WebPCI.Field f9 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["HausNr"];         // Hausnummer 24
            Miracle.MPP.WebPCI.Field f10 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Tuer"];          // Tuer 25

            Miracle.MPP.WebPCI.Field f11 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["AkadTitelID"];   // akad.Titel 43
            Miracle.MPP.WebPCI.Field f12 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["NationID"];      // NationID 7
            Miracle.MPP.WebPCI.Field f13 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Key"];           // PVS_ID 0
            Miracle.MPP.WebPCI.Field f14 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["PersonID"];      // PersonID 34

            f1.Value = check_null(f1);
            f2.Value = check_null(f2);
            f3.Value = check_null(f3);
            f4.Value = check_null(f4);
            f5.Value = check_null(f5);
            f6.Value = check_null(f6);


            f7.Value = check_null(f7);
            f8.Value = check_null(f8);
            f9.Value = check_null(f9);
            f10.Value = check_null(f10);
            f11.Value = check_null(f11);
            f12.Value = check_null(f12);

            f13.Value = check_null(f13);
            f14.Value = check_null(f14);

            SetText_zuname(f1.Value.ToString());
            SetText_vorname(f2.Value.ToString());
            SetText_svnr(f3.Value.ToString());
            if (f4.Value.ToString() == "W" || f4.Value.ToString() == "w")
                SetText_geschlecht("weiblich");
            else
                SetText_geschlecht("männlich");

            // txt_geb_dat.Text = f5.Value.ToString();
            SetText_plz(f6.Value.ToString());
            SetText_ort(f7.Value.ToString());
            SetText_strasse(f8.Value.ToString() + " " +
                            f9.Value.ToString() + " " +
                            f10.Value.ToString());

            return true;
        }
        private string check_null(Miracle.MPP.WebPCI.Field f)
        {
            if (f.Value == null)
                return string.Empty;
            else
                return f.Value.ToString();
        }

        # region delegate

        delegate void SetTextCallback(string text);
        private void SetText_zuname(string text)
        {
            if (this.txt_zuname.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_zuname);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_zuname.Text = text;
            }
        }
        private void SetText_vorname(string text)
        {
            if (this.txt_vorname.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_vorname);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_vorname.Text = text;
            }
        }
        private void SetText_svnr(string text)
        {
            if (this.txt_svnr.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_svnr);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_svnr.Text = text;
            }
        }
        private void SetText_geschlecht(string text)
        {
            if (this.txt_geschlecht.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_geschlecht);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_geschlecht.Text = text;
            }
        }
        private void SetText_plz(string text)
        {
            if (this.txt_plz.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_plz);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_plz.Text = text;
            }
        }
        private void SetText_ort(string text)
        {
            if (this.txt_ort.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_ort);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_ort.Text = text;
            }
        }
        private void SetText_strasse(string text)
        {
            if (this.txt_strasse.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_strasse);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_strasse.Text = text;
            }
        }
        # endregion

        public Boolean show_wbd_antrag_data(DC_ak_suche obj_suche, DC_ak_antraege obj_antrag)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                try
                {

                    DC_wbd_antrag obj_Wbd_Antrag = new DC_wbd_antrag();
                    DataService.DataServiceClient client = new DataServiceClient();
                    DataService.Response resp = client.Get_Wbd_Antrag(out obj_Wbd_Antrag, obj_suche, AKK_Helper.SessionToken);

                    if (resp.ResponseCode == 0)
                    {
                        if (obj_Wbd_Antrag != null)
                        {
                            frm_wbd_antrag frm_wbd_Antrag = new frm_wbd_antrag();
                            frm_wbd_Antrag.obj_wbd_antrag = obj_Wbd_Antrag;
                            frm_wbd_Antrag.obj_person = obj_ak_Per_Ant.obj_lst_ak_person[0];
                            frm_wbd_Antrag.obj_antrag = obj_antrag;
                            frm_wbd_Antrag.PVS_CON = PVS_CON;

                            frm_wbd_Antrag.ShowDialog();
                            if (frm_wbd_Antrag.obj_antrag != null)
                            {
                                // New 27-09-2011 by KJ 
                                obj_antrag = frm_wbd_Antrag.obj_antrag;
                                // New 27-09-2011 by KJ 
                                // if (AKK_Helper.is_empty(frm_wbd_Antrag.str_ast_ikey_c_return) == false)
                                //{
                                if (obj_ak_Per_Ant.obj_lst_ak_antraege.Count == 0)
                                {
                                    obj_ak_Per_Ant.obj_lst_ak_antraege.Add(obj_antrag);  // Neuer Antrag
                                }
                                else
                                {
                                    if (obj_ak_Per_Ant.obj_lst_ak_antraege[save_i] != null)
                                        obj_ak_Per_Ant.obj_lst_ak_antraege[save_i] = obj_antrag;  // bestehender Antrag 
                                }
                                // obj_ak_Per_Ant.obj_lst_ak_antraege[save_i].DM_ant_status = frm_wbd_Antrag.str_ast_ikey_c_return;
                                // obj_ak_Per_Ant.obj_lst_ak_antraege[save_i].DM_ast_typ_c = frm_wbd_Antrag.str_ast_word_return;
                                fill_listbox();     // refresh Listbox 07-07-2011
                                // }
                            }
                            frm_wbd_Antrag = null;

                        }
                        else
                        {
                            AKK_Helper.show_msg(AKK_Helper.str_error["FC002"], strip_info, this.Cursor);
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
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txt_iban_TextChanged(object sender, EventArgs e)
        {
            this.formatIban();
        }

        private void formatIban()
        {
            string iban1 = "";
            string iban2 = "";
            string iban3 = "";
            string iban4 = "";
            string iban5 = "";

            string ibanOhneFormatAus;
            string iban;

            if (!String.IsNullOrEmpty(txt_iban.Text))// && !txt_iban.Text.Contains(" ")
            {

                /**
                ibanOhneFormatAus = txt_iban.Text;
                iban1 = txt_iban.Text.Substring(0, 4);
                iban2 = txt_iban.Text.Substring(4, 4);
                iban3 = txt_iban.Text.Substring(8, 4);
                iban4 = txt_iban.Text.Substring(12, 4);
                iban5 = txt_iban.Text.Substring(16, 4);

                txt_iban.Text = iban1 + " " + iban2 + " " + iban3 + " " + iban4 + " " + iban5;
                **/
                iban = txt_iban.Text;
                iban = Regex.Replace(iban, @"\s+", "");
                iban = Regex.Replace(iban, ".{4}", "$0 ");
                txt_iban.Text = iban1;


            }

        }







    }   // Form
}       // Namespace

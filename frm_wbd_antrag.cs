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
using System.Text.RegularExpressions;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_wbd_antrag : Form
    {
        public frm_wbd_antrag()
        {
            InitializeComponent();
        }
        public clsA_PVS_connection PVS_CON { set; get; }
        public DC_wbd_antrag obj_wbd_antrag { set; get; }
        public DC_person_data obj_person { set; get; }
        public DC_ak_antraege obj_antrag { set; get; }
        // public string str_ast_ikey_c_return;
        // public string str_ast_word_return;

        public static Boolean is_locked = false;    // locked in DB
        public static Boolean is_my_lock = false;   // is locked by me
        public static Boolean is_saved = false;     // indicate that DL is saved #


        public bool IsCoopPartner { private set; get; }
        public static string Verstaendigt_AM { private set; get; }


        public string AntId;


        private Boolean is_Geklagt = true;
        // private Boolean is_Fehler = false;     //  Verhindert das Überschreiben des mtxt_geplante_auszahlung.Text Auszahlungsmonats bei einer Fehleingabe
        // private Boolean is_AusGepl = false;
        private Boolean is_Neu = false;
        private Boolean vwzChanged = false;
        private Boolean is_fLoad = false;
        private Boolean chk_klage_first = false;
        private static Boolean isBankeinzug = false;
        private Int32 lng_AntragsIkey;
        private Int32 lng_WBDikey;
        private Boolean onLoad = true;


        public string Referenz { get; private set; }
        public BankInfo BankInf { get; set; }

        // private string strAusGepTmp = "";
        // private Int32 intAusGepTmp = 0;
        // private string strAusGeplOld = "";
        // private Int32 intAusGeplOld = 0;


        private bool referenceChanged = false;



        public static bool IsBankeinzug
        {
            get
            {
                return isBankeinzug;
            }
            private set
            {
                isBankeinzug = value;
            }
        }

        private void frm_wbd_antrag_Load(object sender, EventArgs e)
        {

            IsCoopPartner = false;


            //Test David Stefitz
            onLoad = true;

            //mtxt_Bestaetigungsdatum.Mask = @"00\.00\.0000";

            //mtxt_Bestaetigungsdatum.Text = "15.02.2016";
            //mtxt_Bestaetigungszeit.Text = "10:25";
            //
            // check availability of cmd_controlls
            //
            cmd_bankverbindung.Enabled = false;
            cmd_mitschuldner.Enabled = false;
            cmd_status_aendern.Enabled = false;
            cmd_urgenz.Enabled = false;
            cmd_mahnstatus.Enabled = false;
            cmd_kontenblatt.Enabled = false;
            cmd_drucken.Enabled = false;
            cmd_speichern.Enabled = false;

            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_bankverbindung.Enabled = true;
                cmd_mitschuldner.Enabled = true;
                cmd_status_aendern.Enabled = true;
                cmd_urgenz.Enabled = true;
                cmd_mahnstatus.Enabled = true;
                cmd_kontenblatt.Enabled = true;
                cmd_drucken.Enabled = true;
                cmd_speichern.Enabled = true;
            }
            else
            {    // CanWrite = False
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Urgenz == AKK_Helper.c_Yes) cmd_urgenz.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Drucken == AKK_Helper.c_Yes) cmd_drucken.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Speichern == AKK_Helper.c_Yes) cmd_speichern.Enabled = true;
                }
            }

            if (AKK_Helper.checkLogin() == true)
            {
                // str_ast_ikey_c_return = ""; 27-09-2011
                is_saved = false;

                AKK_Helper.FindControls(this);

                txt_Antragsinfo.Height = (Int16)AKK_Helper.FontSize * 5;
                txt_anmerkung.Height = (Int16)AKK_Helper.FontSize * 6;

                groupBox2.Font = new Font(groupBox2.Font.FontFamily, AKK_Helper.FontSize);
                groupBox3.Font = new Font(groupBox3.Font.FontFamily, AKK_Helper.FontSize);

                // labelDayDate.Text = System.DateTime.Today.DayOfWeek + ", " + System.DateTime.Today.Day + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Year;
                // read the current status of the specified keys
                strip_info.Text = "Version " + AKK_Helper.obj_version.str_version + " Datum " + AKK_Helper.obj_version.str_version_date + "    " + AKK_Helper.UserName + " (" + AKK_Helper.UserId + ")";



                AKK_Helper.fill_Monate(lst_Monat, AKK_Helper.c_mit_leer);
                AKK_Helper.fill_Jahre(lst_Jahr, AKK_Helper.c_mit_leer);

                lst_mitschuldner.Clear();
                //lst_mitschuldner.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
                //lst_mitschuldner.Columns.Add("User", -1, HorizontalAlignment.Left);                   // 01
                lst_mitschuldner.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 02
                //lst_mitschuldner.Columns.Add("Typ", -1, HorizontalAlignment.Left);                    // 03
                lst_mitschuldner.Columns.Add("Name", 100, HorizontalAlignment.Left);                  // 04
                lst_mitschuldner.Columns.Add("Vorname/Filiale", 120, HorizontalAlignment.Left);       // 05
                lst_mitschuldner.Columns.Add("SVNr/BLZ", 100, HorizontalAlignment.Left);              // 06
                lst_mitschuldner.Columns.Add("Strasse", 150, HorizontalAlignment.Left);               // 07
                lst_mitschuldner.Columns.Add("Ort", 250, HorizontalAlignment.Left);                   // 08


                lst_mitschuldner.View = View.Details;
                lst_mitschuldner.Font = new Font(lst_mitschuldner.Font.FontFamily, AKK_Helper.FontSize);
                lst_mitschuldner.GridLines = true;
                lst_mitschuldner.LabelEdit = true;
                lst_mitschuldner.AllowColumnReorder = true;
                lst_mitschuldner.CheckBoxes = false;
                lst_mitschuldner.FullRowSelect = true;

                dgv_ablehnung.Visible = false;
                dgv_antragsstatus.Visible = false;
                dgv_bezirksstelle.Visible = false;
                dgv_verwendungszweck.Visible = false;
                txt_output.Visible = false;

                label16.Visible = false;




                this.AntId = obj_wbd_antrag.DM_wbd_ant_id;

                //
                // Check New Antrag
                //
                if (obj_wbd_antrag.DM_ant_ikey == "-1")
                {
                    is_Neu = true;
                    mtxt_eingang_am.Enabled = true;
                    // Neuer Antrag? Bank, Bankeinzug und Mitschuldner nicht verfügbar, erst nach speichern
                    cmd_bankverbindung.Enabled = false;
                    cmd_mitschuldner.Enabled = false;
                    chk_Bankeinzug.Enabled = false;
                }
                else
                {
                    is_Neu = false;
                    mtxt_eingang_am.Enabled = false;
                    cmd_bankverbindung.Enabled = true;
                    cmd_mitschuldner.Enabled = true;
                    chk_Bankeinzug.Enabled = true;
                }
                //
                // Check lock
                //
                is_locked = false;
                is_my_lock = false;

                if (is_Neu != true)
                {
                    if (AKK_Helper.is_empty(obj_antrag.DM_ant_lock) == false)
                    {
                        if (obj_antrag.DM_ant_lock == AKK_Helper.UserId)
                        {
                            is_locked = false;
                            is_my_lock = true;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.show_msg("Antrag wird bereits vom User - " + GetName(obj_antrag.DM_ant_lock) + " (" + obj_antrag.DM_ant_lock + ") bearbeitet!", strip_info, this.Cursor);
                            is_locked = true;
                            is_my_lock = false;
                        }
                    }
                    else
                    {
                        Set_Lock(obj_wbd_antrag.DM_ant_ikey, "AKF_antraege", true);
                        is_my_lock = true;
                    }
                    AKK_Helper.str_Old_Status = obj_wbd_antrag.DM_ast_ikey_c;

                    //TODO überprüfen!!!!
                    this.BankInf = new BankInfo(obj_wbd_antrag.DM_wbd_ibanIn, obj_wbd_antrag.DM_wbd_ownerIn, obj_wbd_antrag.DM_wbd_ibanOut, obj_wbd_antrag.DM_wbd_ownerOut, obj_wbd_antrag.DM_wbd_referenz, obj_wbd_antrag.DM_wbd_strasse, obj_wbd_antrag.DM_wbd_ort, obj_wbd_antrag.DM_wbd_coopPartner);
                    this.Referenz = BankInf.Referenz;

                }

                if (((obj_wbd_antrag.DM_wbd_ant_id == null || obj_wbd_antrag.DM_wbd_ant_id == string.Empty) ||
                   (obj_wbd_antrag.DM_wbd_darl_nr == null || obj_wbd_antrag.DM_wbd_darl_nr == string.Empty)) &&
                     is_Neu == false)
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["F008"] + obj_wbd_antrag.DM_wbd_darl_nr + "/" + obj_wbd_antrag.DM_wbd_ant_id, strip_info, this.Cursor);
                }
                else
                {

                    // die folgenden Textfelder werden berechnet und dürfen nicht verändert werden.

                    txt_rate.Enabled = false;
                    txt_kosten.Enabled = false;
                    txt_tilg_stand.Enabled = false;
                    txt_aktKontostand.Enabled = false;
                    cbo_bezirksstelle.Enabled = true;
                    mtxt_rueckbisvertr.Enabled = false;
                    mtxt_rueckbisreal.Enabled = false;

                    // Dei folgenden Textfelder werden durch aktivieren gestezt ( Druck ... )

                    txt_antragsteller.Enabled = false;
                    txt_antrags_id.Enabled = false;
                    txt_darlehensnummer.Enabled = false;
                    mtxt_mahnstufe.Enabled = false;
                    chk_geklagt.Enabled = false;
                    mtxt_urgenz_am.Enabled = false;
                    mtxt_genehmigt_am.Enabled = false;
                    mtxt_verstaendigt_am.Enabled = false;
                    mtxt_anweisung_am.Enabled = false;
                    mtxt_auszahlung_am.Enabled = false;
                    mtxt_geklagt_am.Enabled = false;
                    mtxt_tilgung_am.Enabled = false;
                    // folgende Controlls gibt es nur zu bestimmten Bedingungen
                    cmd_urgenz.Enabled = false;
                    cbo_ablehnung.Enabled = false;
                    lbl_ablehnung.Enabled = false;

                    // Füllen der ComboBoxen
                    AKK_Helper.isG_first = true;
                    fill_Listboxen(is_Neu);
                    AKK_Helper.isG_first = false;
                    //
                    cbo_bildungstraeger.SelectedIndex = 0;

                    mtxt_geplante_auszahlung.Mask = @"##\.##";
                    mtxt_geplante_auszahlung.Enabled = false;     // --> MUSS auf false gesetzt werden
                    mtxt_geplante_auszahlung.Visible = false;     // --> MUSS auf false gesetzt werden

                    mtxt_eingang_am.Mask = @"00\.00\.0000";
                    mtxt_urgenz_am.Mask = @"00\.00\.0000";
                    mtxt_genehmigt_am.Mask = @"00\.00\.0000";
                    mtxt_verstaendigt_am.Mask = @"00\.00\.0000";
                    mtxt_anweisung_am.Mask = @"00\.00\.0000";
                    mtxt_auszahlung_am.Mask = @"00\.00\.0000";
                    mtxt_geklagt_am.Mask = @"00\.00\.0000";
                    mtxt_tilgung_am.Mask = @"00\.00\.0000";

                    mtxt_rueckab.Mask = @"00\.00\.0000";
                    mtxt_rueckbisreal.Mask = @"00\.00\.0000";
                    mtxt_rueckbisvertr.Mask = @"00\.00\.0000";

                    txt_antragsteller.Text = obj_person.DM_vorname + " " + obj_person.DM_nachname;


                    // set default value
                    //   AKK_Helper.ChangeBoxSel(cbo_verwendungszweck, AKK_Helper.C.strLEER_CODE, 2, dgv_verwendungszweck);
                    //AKK_Helper.ChangeBoxSel(cbo_ablehnung, AKK_Helper.C.strLEER_CODE, 2, dgv_ablehnung);
                    //AKK_Helper.ChangeBoxSel(cbo_bezirksstelle, AKK_Helper.C.strG_BEZIRK, 2, dgv_bezirksstelle);
                    //
                    // Bildungstraeger NEU
                    //
                    cbo_verwendungszweck.Enabled = true;
                    cbo_bildungstraeger.Enabled = false;  // 12-005-2011 by KJ

                    //Test 15.10.2018 David Stefitz
                    //cbo_bildungstraeger.SelectedValue = 0;

                    //



                    if (is_Neu == true)
                    {
                        // Folgende Controls werden beim Anlegen eines neuen DL nicht benötigt
                        mtxt_genehmigt_am.Enabled = false;
                        cmd_status_aendern.Enabled = false;
                        cmd_kontenblatt.Enabled = false;
                        cmd_mahnstatus.Enabled = false;
                        cmd_drucken.Enabled = false;
                        cmd_mitschuldner.Enabled = false;
                        cmd_bankverbindung.Enabled = false;
                        mtxt_rueckab.Enabled = true;
                        chk_Bankeinzug.Checked = false;
                        // Die AUftragsID und die DLNr. werden erst beim Speichern generiert.
                        txt_antrags_id.Text = "";
                        txt_darlehensnummer.Text = "";
                        txt_laufzeitstatus.Text = "";
                        txt_Dif.Enabled = false;
                        chk_scheidung.Enabled = false;
                        chk_unterfertigt.Enabled = false;
                        txt_laufzeitstatus.Enabled = false;
                        //
                        // Get IDs from akf_sysno
                        //
                        lng_AntragsIkey = AKK_Helper.get_ID(10001);
                        lng_WBDikey = AKK_Helper.get_ID(11100);
                        obj_wbd_antrag.DM_wbd_ikey = lng_WBDikey.ToString();
                        obj_wbd_antrag.DM_ant_ikey = lng_AntragsIkey.ToString();

                        obj_antrag.DM_ant_ikey = lng_AntragsIkey.ToString();
                        obj_antrag.DM_std_extdoid_fkey = obj_person.DM_PVS_ID.Substring(7, (obj_person.DM_PVS_ID.Length - 7));
                        obj_antrag.DM_std_fkey = obj_person.DM_PVS_ID;
                        obj_antrag.DM_ant_svnr = obj_person.DM_svnr;

                        mtxt_eingang_am.Focus();
                        mtxt_eingang_am.SelectAll();

                        // Ablehnungsgrund & Verwendungszweck 09.10.2018 David Stefitz

                        cbo_ablehnung.Enabled = false;
                        lbl_ablehnung.Enabled = false;

                        cbo_verwendungszweck.SelectedIndex = 0;

                        cbo_ablehnung.Text = "";
                        cbo_ablehnung.SelectedValue = "-10";




                    }

                    else    // is old ANTRAG
                    {

                        if (is_locked == true)
                        {
                            cmd_speichern.Enabled = false;
                            mtxt_eingang_am.Enabled = false;
                            cbo_verwendungszweck.Enabled = false;
                            cbo_bildungstraeger.Enabled = false;  // 12-05-2011 by KJ
                            cmd_status_aendern.Enabled = false;
                            cmd_kontenblatt.Enabled = false;
                            cmd_mahnstatus.Enabled = false;
                        }
                        txt_antrags_id.Text = obj_wbd_antrag.DM_wbd_ant_id;
                        txt_darlehensnummer.Text = obj_wbd_antrag.DM_wbd_darl_nr;
                        mtxt_geplante_auszahlung.Text = obj_wbd_antrag.DM_wbd_ausz_gepl;
                        mtxt_eingang_am.Text = obj_wbd_antrag.DM_wbd_ant_ein;
                        mtxt_urgenz_am.Text = obj_wbd_antrag.DM_wbd_urg_am;
                        mtxt_genehmigt_am.Text = obj_wbd_antrag.DM_wbd_gen_am;
                        mtxt_anweisung_am.Text = obj_wbd_antrag.DM_wbd_anweis_am;
                        mtxt_auszahlung_am.Text = obj_wbd_antrag.DM_wbd_ausz_am;

                        mtxt_geklagt_am.Text = obj_wbd_antrag.DM_wbd_klage_am;
                        mtxt_tilgung_am.Text = obj_wbd_antrag.DM_wbd_tilg_am;
                        txt_darlehensbetrag.Text = AKK_Helper.FormatBetragOhneKomma(obj_wbd_antrag.DM_wbd_d_betr);
                        if (obj_wbd_antrag.DM_wbd_rate.ToString() == "")
                            txt_rate.Text = AKK_Helper.FormatBetragOhneKomma("0");
                        else
                            txt_rate.Text = AKK_Helper.FormatBetragOhneKomma(obj_wbd_antrag.DM_wbd_rate);

                        txt_kosten.Text = AKK_Helper.FormatBetrag(obj_wbd_antrag.DM_wbd_kosten);
                        mtxt_laufzeit.Text = obj_wbd_antrag.DM_wbd_laufzeit;
                        txt_anmerkung.Text = obj_wbd_antrag.DM_wbd_anmerk;

                        if (obj_wbd_antrag.DM_wbd_scheidung == "N" || obj_wbd_antrag.DM_wbd_scheidung == "n")
                        {
                            chk_scheidung.Checked = false;
                            txt_antragsteller.ForeColor = Color.Black;
                        }
                        else
                        {
                            chk_scheidung.Checked = true;
                            txt_antragsteller.ForeColor = Color.Red;
                        }

                        if (obj_wbd_antrag.DM_wbd_unter == "0")
                            chk_unterfertigt.Checked = false;
                        else
                            chk_unterfertigt.Checked = true;

                        if ((obj_wbd_antrag.DM_wbd_mahnstufe == "1") ||
                            (obj_wbd_antrag.DM_wbd_mahnstufe == "2") ||
                            (obj_wbd_antrag.DM_wbd_mahnstufe == "3") ||
                            (obj_wbd_antrag.DM_wbd_mahnstufe == "4"))
                            mtxt_mahnstufe.Text = obj_wbd_antrag.DM_wbd_mahnstufe;
                        else
                        {
                            mtxt_mahnstufe.Text = "0";
                            obj_wbd_antrag.DM_wbd_mahnstufe = "0";
                        }
                        // Aktualisiert
                        txt_Antragsinfo.Text = strAktualisiert(obj_wbd_antrag.DM_wbd_akt_am, obj_wbd_antrag.DM_wbd_akt_von);


                        if (obj_wbd_antrag.DM_wbd_klage == "0")
                        {
                            chk_klage_first = true;
                            chk_geklagt.Checked = false;
                            chk_klage_first = false;
                            is_Geklagt = false;
                            chk_geklagt.Enabled = true;
                        }
                        else
                        {
                            chk_klage_first = true;
                            chk_geklagt.Checked = true;
                            chk_klage_first = false;
                            is_Geklagt = true;

                            chk_geklagt.Enabled = true;
                            if (AKK_Helper.My_user.CanWrite == true)
                            {
                                cmd_status_aendern.Enabled = true;
                                cmd_mahnstatus.Enabled = true;
                            }
                            else
                            {
                                cmd_status_aendern.Enabled = false;
                                cmd_mahnstatus.Enabled = false;
                                if (AKK_Helper.My_user.CanRead == true)
                                {
                                    if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = true;
                                    if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = true;
                                }

                            }

                            txt_darlehensbetrag.Enabled = true;
                            mtxt_laufzeit.Enabled = true;
                            cbo_verwendungszweck.Enabled = true;
                            cbo_bildungstraeger.Enabled = true; // 12-05-2011 by KJ
                            cbo_ablehnung.Enabled = true;
                            cbo_antragsstatus.Enabled = true;
                            cbo_ablehnung.Enabled = true;
                            mtxt_rueckab.Enabled = true;
                            // mtxt_geplante_auszahlung.Enabled = true;
                            lst_Monat.Enabled = true;
                            lst_Jahr.Enabled = true;

                        }
                        Int32 i_value;
                        Int32.TryParse(obj_wbd_antrag.DM_wbd_d_betr, out i_value);
                        if (i_value != 0)
                        {
                            if (AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_verst_am.ToString()) == true)
                            {
                                mtxt_rueckab.Enabled = true;
                            }

                        }

                        // Verwendungszweck
                        AKK_Helper.ChangeBoxSel(cbo_verwendungszweck, obj_wbd_antrag.DM_vvwz_ikey_neu_c, 1, dgv_verwendungszweck);
                        // Bildungsträger
                        cbo_bildungstraeger.SelectedValue = obj_wbd_antrag.DM_wbd_bt;

                        //
                        // Nach Verständigung, 
                        // gibt es keine Änderungen mehr
                        //
                        if (AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_verst_am) == false)
                        {
                            txt_darlehensbetrag.Enabled = false;
                            mtxt_laufzeit.Enabled = false;
                            mtxt_rueckab.Enabled = false;
                            mtxt_verstaendigt_am.Text = obj_wbd_antrag.DM_wbd_verst_am;
                        }

                        //
                        txt_aktKontostand.Text = AKK_Helper.FormatBetragPlus(obj_wbd_antrag.DM_wbd_kstand);

                        //
                        // Antragsstatus
                        if (obj_wbd_antrag.DM_ast_ikey_c != "")
                        {


                            AKK_Helper.isG_first = true;
                            switch (obj_wbd_antrag.DM_ast_ikey_c)
                            {
                                case "11":
                                    fill_Antragsstatus(true);
                                    break;
                                case "12":
                                    fill_Antragsstatus(true);
                                    break;
                                case "13":
                                    fill_Antragsstatus(true);
                                    break;
                                case "14":
                                    fill_Antragsstatus(true);
                                    break;
                                case "15":
                                    fill_Antragsstatus(true);
                                    break;
                                case "16":
                                    fill_Antragsstatus(true);
                                    break;
                                case "17":
                                    fill_Antragsstatus(true);
                                    break;
                            }
                            AKK_Helper.ChangeBoxSel(cbo_antragsstatus, obj_wbd_antrag.DM_ast_ikey_c, 1, dgv_antragsstatus);
                            AKK_Helper.isG_first = false;
                            if (((cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_UG) || (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_UG)) && (is_Geklagt == false))  // AKK_Helper.C.strURG_CODE) && (is_Geklagt == false))
                            {
                                if (AKK_Helper.My_user.CanWrite == true)
                                {
                                    cmd_urgenz.Enabled = true;
                                }
                                else
                                {
                                    cmd_urgenz.Enabled = false;
                                    if (AKK_Helper.My_user.CanRead == true)
                                    {
                                        if (AKK_Helper.C.strG_Antrag_Urgenz == AKK_Helper.c_Yes) cmd_urgenz.Enabled = true;
                                    }
                                }
                                cbo_verwendungszweck.Enabled = false;
                                cbo_bildungstraeger.Enabled = false;
                            }
                            else
                            {
                                cmd_urgenz.Enabled = false;
                                cbo_verwendungszweck.Enabled = false;
                                cbo_bildungstraeger.Enabled = false;
                            }
                            if (cbo_antragsstatus.Text.ToString() == AKK_Helper.C.strPOS_CODE)
                            {
                                chk_geklagt.Enabled = true;
                            }
                            else
                            {
                                chk_geklagt.Enabled = false;
                            }
                            AKK_Helper.str_Old_Status = obj_wbd_antrag.DM_ast_ikey_c;
                        }
                        else
                        {
                            AKK_Helper.str_Old_Status = "-10";
                        }
                        // Ablehnungsgrund
                        if (obj_wbd_antrag.DM_abl_ikey_c != "")
                        {
                            AKK_Helper.ChangeBoxSel(cbo_ablehnung, obj_wbd_antrag.DM_abl_ikey_c, 1, dgv_ablehnung);
                            if ((cbo_ablehnung.Text.ToString() == AKK_Helper.C.strLEER_CODE) && (is_Geklagt == false))
                            {
                                cbo_ablehnung.Enabled = true;
                                lbl_ablehnung.Enabled = true;
                            }
                        }
                        // Bezirksstelle
                        if (obj_wbd_antrag.DM_bzs_ikey_c != "")
                        {
                            AKK_Helper.ChangeBoxSel(cbo_bezirksstelle, obj_wbd_antrag.DM_bzs_ikey_c, 1, dgv_bezirksstelle);
                        }

                        mtxt_geplante_auszahlung.Text = obj_wbd_antrag.DM_wbd_ausz_gepl.ToString();

                        if (AKK_Helper.is_empty_YYMM(mtxt_geplante_auszahlung.Text) == false)
                        {
                            string strJ = mtxt_geplante_auszahlung.Text.Substring(0, 2);
                            string strM = mtxt_geplante_auszahlung.Text.Substring(3, 2);
                            Int32 intJ = 0;
                            Int32 intM = 0;
                            Int32.TryParse(strJ, out intJ);
                            Int32.TryParse(strM, out intM);
                            if (intJ > 80)
                            {   // 02-10-2015 by KJ was 16 ( for -15 to + 15 years )
                                // changed to -30 to + 10
                                intJ = 31 - (System.DateTime.Now.Year - (1900 + intJ));
                            }
                            else
                            {   // 02-10-2015 by KJ was 16 ( for -15 to + 15 years )
                                // changed to -30 to + 10
                                intJ = 31 - (System.DateTime.Now.Year - (2000 + intJ));
                            }
                            // 02-10-2015 by KJ if < 0 empty
                            intJ = (intJ > 0) ? intJ : 0;
                            // 02-10-2015 by KJ
                            lst_Jahr.SelectedIndex = intJ;
                            lst_Monat.SelectedIndex = intM;
                        }
                        else
                        {
                            lst_Jahr.SelectedIndex = 0;
                            lst_Monat.SelectedIndex = 0;
                        }
                        if (AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_rz_beg) == false)
                        {
                            mtxt_rueckab.Text = obj_wbd_antrag.DM_wbd_rz_beg;
                            // 10-12-2012 by KJ
                            if (AKK_Helper.My_user.CanWrite == true)
                            {
                                cmd_bankverbindung.Enabled = true;
                                cmd_mitschuldner.Enabled = true;
                            }
                            else
                            {
                                cmd_bankverbindung.Enabled = false;
                                cmd_mitschuldner.Enabled = false;
                                if (AKK_Helper.My_user.CanRead == true)
                                {
                                    if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                    if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                }
                            }
                            // 10-12-2012 by KJ
                        }
                        else
                        {
                            cmd_bankverbindung.Enabled = false;
                            cmd_mitschuldner.Enabled = false;
                        }
                        //
                        // ist das Rückzahlungsdatum noch nicht gegeben,
                        // können keine Änderungen am Laufzeitstaus dem Mahhnstatus
                        // wurde der Antrag geklagt, darf nur das Kontoblatt bearbeitet werden.
                        //
                        if (AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_rz_beg) == false)
                        {
                            if (is_Geklagt == false)
                            {
                                if (AKK_Helper.My_user.CanWrite == true)
                                {
                                    cmd_status_aendern.Enabled = true;
                                    cmd_mahnstatus.Enabled = true;
                                }
                                else
                                {
                                    cmd_status_aendern.Enabled = false;
                                    cmd_mahnstatus.Enabled = false;
                                    if (AKK_Helper.My_user.CanRead == true)
                                    {
                                        if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = true;
                                        if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = true;
                                    }
                                }
                            }
                            else
                            {
                                cmd_status_aendern.Enabled = false;
                                cmd_mahnstatus.Enabled = false;
                                mtxt_rueckab.Enabled = false;
                            }
                        }
                        if ((AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_rz_beg) == true) &&
                             (is_Geklagt == false) &&
                             (AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_verst_am) == true)
                            )
                        {
                            mtxt_rueckab.Enabled = true;
                        }
                        else
                        {
                            if ((AKK_Helper.is_empty_date(obj_wbd_antrag.DM_wbd_rz_beg) == false) || (is_Geklagt = true))
                                mtxt_rueckab.Enabled = false;
                        }

                        mtxt_rueckbisvertr.Text = obj_wbd_antrag.DM_wbd_rz_bis_ver;
                        mtxt_rueckbisreal.Text = obj_wbd_antrag.DM_wbd_rz_bis_real;
                        txt_aktKontostand.Text = AKK_Helper.FormatBetragPlus(obj_wbd_antrag.DM_wbd_kstand);
                        //
                        // Tilgungsstand berechnen
                        //
                        bool ish = false;
                        if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                        {
                            ish = true;
                        }
                        double dbl_Tilgungsstatus = 0.0;
                        Response resp = new Response();
                        DataService.DataServiceClient client1 = new DataServiceClient();

                        double dbl_dl;
                        double.TryParse(txt_darlehensbetrag.Text, out dbl_dl);

                        double dbl_konto;
                        double.TryParse(txt_aktKontostand.Text, out dbl_konto);

                        resp = client1.Get_Akt_TilgungsST(out dbl_Tilgungsstatus,
                                      AKK_Helper.SessionToken,
                                      obj_wbd_antrag.DM_wbd_ikey,
                                      txt_rate.Text,
                                      mtxt_rueckab.Text,
                                      mtxt_rueckbisreal.Text,
                                      txt_kosten.Text,
                                      txt_darlehensbetrag.Text,
                                      ish);


                        if (!is_Neu && obj_wbd_antrag.DM_wbd_coopPartner.Equals("1"))
                        {
                            this.chkBKoordinationspartner.Checked = true;
                            this.chkBKoordinationspartner.Enabled = false;
                            this.IsCoopPartner = true;
                        }

                        this.referenzBox.Text = this.obj_wbd_antrag.DM_wbd_referenz;

                        if (resp.ResponseCode == 0)
                        {

                            if (mtxt_auszahlung_am.Text != "  .  .")
                            {
                                //David Stefitz 10.05.2019 Tilgungsstatus wurde nicht richtig angezeigt, wird jetzt neu berechnet
                                txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                            }
                            else
                            {
                                dbl_Tilgungsstatus = 0;
                                txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                            }

                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                        }
                        //
                        // Befüllen des aktuellen Tilgungsstandes
                        //
                        resp = new Response();
                       var  client2 = new DataServiceClient();
                        string str_Tilgungstext = "";
                        resp = client2.Get_Info_Status(out str_Tilgungstext,
                                                       AKK_Helper.SessionToken,
                                                       obj_wbd_antrag.DM_wbd_ikey,
                                                       mtxt_rueckbisreal.Text);
                        if (resp.ResponseCode == 0)
                        {
                            txt_laufzeitstatus.Text = str_Tilgungstext;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            txt_laufzeitstatus.Text = "";
                        }



                        //
                        // Mitschuldner WBD_MTS1, WBD_MTS2, WBD_MTS3
                        //

                        read_mitschuldner();

                        
  
                        //
                        // Berechnung der Differenz zwischen tatsächlichem
                        // und theoretischem Kontostand
                        //
                        //double dbl_dl;
                        //double.TryParse(txt_darlehensbetrag.Text, out dbl_dl);

                        double dbl_tilg;
                        double.TryParse(txt_tilg_stand.Text, out dbl_tilg);

                        //double dbl_konto;
                        //double.TryParse(txt_aktKontostand.Text, out dbl_konto);




                        double dbl_sum = AKK_Helper.Calc_Diff(mtxt_auszahlung_am.Text,
                                                      mtxt_rueckab.Text,
                                                      dbl_dl,
                                                      dbl_tilg,
                                                      dbl_konto);
                        //David Stefitz 05.02.2019 Änderung von > auf < als weil das Konto Negativ angegeben wird!
                        //David Stefitz 16.07.2019 Wieder auf > geändert war ein Denkfehler
                        if (dbl_konto > 0)
                        {
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                        }
                        else
                        {
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus(dbl_sum.ToString());
                        }
                        //
                        // Mahnstufe
                        //
                        if (AKK_Helper.is_empty(obj_wbd_antrag.DM_wbd_mahnstufe) == true)
                            mtxt_mahnstufe.Text = "0";
                        else
                            mtxt_mahnstufe.Text = obj_wbd_antrag.DM_wbd_mahnstufe;
                        //
                        // Unterfertigt
                        //
                        if (obj_wbd_antrag.DM_wbd_unter == "0")
                        {
                            chk_unterfertigt.Checked = false;
                            is_fLoad = false;
                            chk_unterfertigt.Enabled = true;
                        }
                        else
                        {
                            chk_unterfertigt.Checked = true;
                            is_fLoad = true;
                            txt_darlehensbetrag.Enabled = false;
                            mtxt_laufzeit.Enabled = false;
                            mtxt_rueckab.Enabled = false;
                            //mtxt_geplante_auszahlung.Enabled = false;
                            lst_Monat.Enabled = false;
                            lst_Jahr.Enabled = false;

                            chk_unterfertigt.Enabled = false;

                        }
                        //
                        // Bankeinzug
                        //
                        if (obj_wbd_antrag.DM_wbd_einzug == "0")
                            chk_Bankeinzug.Checked = false;
                        else
                            chk_Bankeinzug.Checked = true;

                        // immer false !!!
                        txt_laufzeitstatus.Enabled = false;
                        isBankeinzug = false;  // is changed at load procedure

                        set_fields();   // 19-07-2011 KJ 

                        mtxt_eingang_am.Focus();
                        mtxt_eingang_am.SelectAll();

                        //Protokollierung Stefitz David 29.08.2018
                        DataService.DataServiceClient clientProt = new DataServiceClient();
                        clientProt.Insert_WBD_Protocol(Int32.Parse(AKK_Helper.UserId.ToString()), "SELECT", "WBD_ANTRAG/" + obj_antrag.DM_ant_code_c, obj_wbd_antrag.DM_wbd_ant_id, Int32.Parse(obj_wbd_antrag.DM_ant_ikey), "Status: " + cbo_antragsstatus.Text + ", Auszahlungsbetrag: " + AKK_Helper.FormatBetragOhneKomma(obj_wbd_antrag.DM_wbd_d_betr), AKK_Helper.SessionToken);
                       
                        //
                    }   // Ende Load Form
                } // ungültige Darlehnsdaten !!!
                mtxt_eingang_am.Focus();
                mtxt_eingang_am.SelectAll();
                txt_kosten.Visible = false;


                nachzahlungsBetragTextBox.Enabled = false;
                nachzahlungsDatumTextBox.Enabled = false;

                var statusValue = cbo_antragsstatus.SelectedValue.ToString();

                var client = new DataServiceClient();
                var nachzahlungsbetrag = client.GetNachzahlungsbetrag(obj_wbd_antrag.DM_wbd_ant_id);
                var nachzahlungsdatum = obj_wbd_antrag.Nachzahlungsdatum;

                if (!String.IsNullOrEmpty(nachzahlungsdatum))
                {
                    nachzahlungsDatumTextBox.Text = nachzahlungsdatum;
                }

                if ((statusValue == "3" || statusValue == "13") && String.IsNullOrEmpty(nachzahlungsdatum)) //Positiv und noch nichts ausgezahlt
                {
                    nachzahlungsBetragTextBox.Enabled = true;
                }

                if (nachzahlungsbetrag > 0)
                {
                    nachzahlungsBetragTextBox.Text = nachzahlungsbetrag.ToString();
                }


            }

        }

        public void read_mitschuldner()
        {
            if (AKK_Helper.checkLogin() == true)
            {

                Response resp = new Response();
                DataService.DataServiceClient client = new DataServiceClient();

                //
                // Mitschuldner WBD_MTS1, WBD_MTS2, WBD_MTS3
                //
                string str_ms1 = "-1";  // init mit -1 für PL/SQL
                string str_ms2 = "-1";  // init mit -1 für PL/SQL
                string str_ms3 = "-1";  // init mit -1 für PL/SQL
                if ((AKK_Helper.is_empty(obj_wbd_antrag.DM_wbd_mts1) == false))
                    str_ms1 = obj_wbd_antrag.DM_wbd_mts1;
                if ((AKK_Helper.is_empty(obj_wbd_antrag.DM_wbd_mts2) == false))
                    str_ms2 = obj_wbd_antrag.DM_wbd_mts2;
                if ((AKK_Helper.is_empty(obj_wbd_antrag.DM_wbd_mts3) == false))
                    str_ms3 = obj_wbd_antrag.DM_wbd_mts3;
                //
                // str_ms2 = @"DO\BZ\$101000001810425";
                // str_ms3 = @"DO\AP\$101000015074344";
                // str_ms3 = @"-1";
                resp = new Response();
                client = new DataServiceClient();
                DC_lst_ak_cursor obj_mitschuldner = new DC_lst_ak_cursor();
                resp = client.Get_Mitschuldner(out obj_mitschuldner, AKK_Helper.SessionToken, AKK_Helper.UserId, str_ms1, str_ms2, str_ms3);
                if (resp.ResponseCode == 0)
                {
                    lst_mitschuldner.Items.Clear();
                    if (obj_mitschuldner != null)
                    {
                        Int32 int_mit_count = obj_mitschuldner.Count;
                        if (int_mit_count > 0)    // Any records found
                        {
                            for (int i = 0; i < int_mit_count; i++)
                            {
                                ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                                //LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_User);             // 1 
                                //LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Index);            // 2
                                //LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_01);           // 3 Type
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_02);           // 4 NN & Bank
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_03);           // 5 VN & Filiale
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_04);           // 6 SVNR & BLZ
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_08 + " " +
                                                     obj_mitschuldner[i].DM_Dat_09 + " " +
                                                     obj_mitschuldner[i].DM_Dat_10);           // 7 Str HNR Tur 
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_05 + " " +
                                                     obj_mitschuldner[i].DM_Dat_06 + " " +
                                                     obj_mitschuldner[i].DM_Dat_07);           // 8 Nat PLZ Ort

                                lst_mitschuldner.Items.Add(LVI_ORA);
                                LVI_ORA = null;

                            }
                        }
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
            }      // check Login
        }
        public void fill_Listboxen(Boolean isX_Neu)
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
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BT1", "");
                    if (resp.ResponseCode == 0)
                    {
                        DC_Columns c = new DC_Columns();
                        for (int i = 0; i < cols.Count; i++)
                        {
                            if (int.Parse(cols[i].DM_col_02) < 50 && int.Parse(cols[i].DM_col_02) > 0)
                            {
                                c.Add(cols[i]);
                            }
                        }
                        AKK_Helper.fill_Listbox(cbo_bildungstraeger, c);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                    //
                    // Fill Antragsstatus
                    //

                    //if (isX_Neu == true)
                    //    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST4P", AKK_Helper.C.strURG_CODE);
                    //else
                    // Urgen ist imme vorhanden!!!
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST4", "");

                    if (resp.ResponseCode == 0)
                    {
                        DC_Columns c = new DC_Columns();
                        for (int i = 0; i < cols.Count - 1; i++)
                        {
                            if (int.Parse(cols[i].DM_col_02) < 10 && int.Parse(cols[i].DM_col_02) > 0)
                            {
                                c.Add(cols[i]);
                            }
                        }
                        AKK_Helper.fill_Listbox(cbo_antragsstatus, c);
                        AKK_Helper.fill_dgv(dgv_antragsstatus, c);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                    //
                    // Fill Vewrwendungszweck
                    //

                    resp = null;
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "VWZ6", "");
                    if (resp.ResponseCode == 0)
                    {
                        if (!vwzChanged)
                        {
                            AKK_Helper.fill_Listbox(cbo_verwendungszweck, cols);
                            AKK_Helper.fill_dgv(dgv_verwendungszweck, cols);
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                    if (vwzChanged)
                    {
                        vwzChanged = false;
                    }

                    //
                    // Fill Ablehnungsgrund
                    //
                    resp = null;
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "ABL5", "");
                    if (resp.ResponseCode == 0)
                    {
                        AKK_Helper.fill_Listbox(cbo_ablehnung, cols);
                        AKK_Helper.fill_dgv(dgv_ablehnung, cols);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }
                    //
                    // Bezirksstellen
                    //
                    resp = null;
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BZS4", "");
                    if (resp.ResponseCode == 0)
                    {
                        AKK_Helper.fill_Listbox(cbo_bezirksstelle, cols);
                        AKK_Helper.fill_dgv(dgv_bezirksstelle, cols);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }
                    if (is_Neu == false)
                    {
                        //
                        // Tilgungsaussetzung
                        //
                        resp = null;
                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "TGS4", obj_wbd_antrag.DM_wbd_ikey);
                        if (resp.ResponseCode == 0)
                        {
                            AKK_Helper.fill_dgv(dgv_Tilgung, cols);
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                        cols = null;
                    }

                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                }
                this.Cursor = Cursors.Default;
                /*if (onLoad)
                {
                    onLoad = false;
                }*/
            }

        }
        public void Set_Lock(String ant_ikey, String str_table, Boolean set_lock)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                string str_nr = null;
                if (set_lock == true)
                    str_nr = AKK_Helper.UserId.ToString();
                else str_nr = "''";

                try
                {
                    DataService.DataServiceClient ClientBase = new DataServiceClient();
                    Response resp = ClientBase.SetLock(AKK_Helper.SessionToken, str_table, str_nr, ant_ikey);
                    if (resp.ResponseCode != 0)
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

            }

        }
        private void cmd_show_Click(object sender, EventArgs e)
        {
            dgv_ablehnung.Visible = !(dgv_ablehnung.Visible);
            dgv_antragsstatus.Visible = !(dgv_antragsstatus.Visible);
            dgv_bezirksstelle.Visible = !(dgv_bezirksstelle.Visible);
            dgv_verwendungszweck.Visible = !(dgv_verwendungszweck.Visible);
            txt_output.Visible = !(txt_output.Visible);
            dgv_Tilgung.Visible = !(dgv_Tilgung.Visible);
        }

        private void cmd_beenden_Click(object sender, EventArgs e)
        {
            // only unlock if not already locked at openening form
            if (is_my_lock == true)
            {
                Set_Lock(obj_wbd_antrag.DM_ant_ikey, "AKF_antraege", false);
                is_my_lock = false;
                is_locked = false;
            }
            else
            {
                if (is_locked == true)
                {
                    isBankeinzug = false;
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }
            }
            if (isBankeinzug == true)
            {
                if (MessageBox.Show("Wollen sie die Änderungen speichern?", "Änderungen speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd_speichern_Click(sender, e);
                }
            }


            if (is_saved == false)
            {
                // str_ast_word_return = ""; 27-09-211
                obj_antrag = null;
            }
            this.Close();
        }

        public string strAktualisiert(string strX_am, string strX_von)
        {
            string str_name = GetName(strX_von);
            string str_return = "Aktualisiert am " +
                                obj_wbd_antrag.DM_wbd_akt_am.ToString() +
                                " von " +
                                str_name +
                                " / " +
                                strX_von;
            return (str_return);
        }
        public string GetName(string str_von)
        {
            string str_info = "";
            if (AKK_Helper.checkLogin() == true)
            {

                try
                {
                    DC_Columns cols = new DC_Columns();
                    DataService.DataServiceClient ClientBase = new DataServiceClient();
                    Response resp = ClientBase.get_SQL_Data(out cols, AKK_Helper.SessionToken, "USR1", str_von);

                    if (resp.ResponseCode == 0)
                    {
                        if (cols.Count > 0)
                            str_info = cols[0].DM_col_01.ToString();
                        else
                            str_info = "Unbekannt";
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

            }
            return str_info;
        }
        private void cmd_drucken_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }
                else
                {
                    frm_Einzeldruck frm_einzeldruck = new frm_Einzeldruck();
                    // frm_einzeldruck.str_Status = cbo_antragsstatus.SelectedIndex.ToString();
                    frm_einzeldruck.str_AntIkey = obj_wbd_antrag.DM_ant_ikey;
                    frm_einzeldruck.str_Status = cbo_antragsstatus.SelectedValue.ToString();
                    if (cbo_verwendungszweck.SelectedValue.ToString() == "29")//ish
                    {
                        switch (frm_einzeldruck.str_Status)
                        {
                            case "1":
                                frm_einzeldruck.str_Status = "11";
                                break;
                            case "2":
                                frm_einzeldruck.str_Status = "12";
                                break;
                            case "3":
                                frm_einzeldruck.str_Status = "13";
                                break;
                            case "4":
                                frm_einzeldruck.str_Status = "14";
                                break;
                            case "5":
                                frm_einzeldruck.str_Status = "15";
                                break;
                            case "6":
                                frm_einzeldruck.str_Status = "16";
                                break;
                            case "7":
                                frm_einzeldruck.str_Status = "17";
                                break;
                        }
                    }
                    if (cbo_ablehnung.SelectedValue != null)
                    {
                        frm_einzeldruck.str_ablehnung = cbo_ablehnung.SelectedValue.ToString();
                    }
                    else
                    {

                        frm_einzeldruck.str_ablehnung = "-10";

                    }
                    // eventually set new date values
                    frm_einzeldruck.str_urgenz_am = mtxt_urgenz_am.Text;
                    frm_einzeldruck.str_genehmigt_am = mtxt_genehmigt_am.Text;
                    frm_einzeldruck.str_verstaendigt_am = mtxt_verstaendigt_am.Text;
                    frm_einzeldruck.str_tilgung_am = mtxt_tilgung_am.Text;
                    //
                    if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                    {
                        frm_einzeldruck.ish = true;
                    }
                    else
                    {
                        frm_einzeldruck.ish = false;
                    }
                    frm_einzeldruck.ShowDialog();
                    //
                    // Reset values
                    //
                    mtxt_urgenz_am.Enabled = true;
                    mtxt_genehmigt_am.Enabled = true;
                    mtxt_verstaendigt_am.Enabled = true;
                    mtxt_tilgung_am.Enabled = true;

                    mtxt_urgenz_am.Text = frm_einzeldruck.str_urgenz_am;
                    mtxt_genehmigt_am.Text = frm_einzeldruck.str_genehmigt_am;
                    mtxt_verstaendigt_am.Text = frm_einzeldruck.str_verstaendigt_am;
                    mtxt_tilgung_am.Text = frm_einzeldruck.str_tilgung_am;

                    mtxt_tilgung_am.Refresh();
                    mtxt_urgenz_am.Refresh();
                    mtxt_genehmigt_am.Refresh();
                    mtxt_verstaendigt_am.Refresh();

                    mtxt_urgenz_am.Enabled = false;
                    mtxt_genehmigt_am.Enabled = false;
                    mtxt_verstaendigt_am.Enabled = false;
                    mtxt_tilgung_am.Enabled = false;
                    frm_einzeldruck = null;
                    this.Refresh();
                }
            }
        }
        //
        //  mtmt_eingang_am 2
        //
        private void mtxt_eingang_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_eingang_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_eingang_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_eingang_am.Text) == false)
                {
                    mtxt_eingang_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_eingang_am.Text, strip_info, this.Cursor);
                }
            }
            if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false && AKK_Helper.is_date(mtxt_rueckab.Text) == true && AKK_Helper.is_date(mtxt_eingang_am.Text) == true)
            {
                DateTime dt_eingang;
                DateTime dt_rueck;
                DateTime.TryParse(mtxt_rueckab.Text, out dt_rueck);     // rueckab vom DL als Parameter
                DateTime.TryParse(mtxt_eingang_am.Text, out dt_eingang);
                System.TimeSpan diffResult = dt_rueck.Subtract(dt_eingang);

                if (diffResult.Days <= 0)
                {
                    AKK_Helper.show_msg("Das Eingangsdatum muss vor dem Rückzahlungsdatum sein.", strip_info, this.Cursor);
                    mtxt_eingang_am.Focus();
                    mtxt_eingang_am.SelectAll();
                    return;
                }
            }
            label2.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_eingang_am_Enter(object sender, EventArgs e)
        {
            mtxt_eingang_am.SelectAll();
            label2.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_eingang_am_MouseDown(object sender, MouseEventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
            mtxt_eingang_am.SelectAll();
        }
        //
        //   mtxt_urgenz_am 3
        //
        private void mtxt_urgenz_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_urgenz_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_urgenz_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_urgenz_am.Text) == false)
                {
                    mtxt_urgenz_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_urgenz_am.Text, strip_info, this.Cursor);
                }
            }
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_urgenz_am_Enter(object sender, EventArgs e)
        {
            mtxt_urgenz_am.SelectAll();
            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_urgenz_am_MouseDown(object sender, MouseEventArgs e)
        {
            mtxt_urgenz_am.SelectAll();
            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        //
        //   mtxt_genehmigt_am 4
        //
        private void mtxt_genehmigt_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_genehmigt_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_genehmigt_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_genehmigt_am.Text) == false)
                {
                    mtxt_genehmigt_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_genehmigt_am.Text, strip_info, this.Cursor);
                }
            }
            label4.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_genehmigt_am_Enter(object sender, EventArgs e)
        {
            mtxt_genehmigt_am.SelectAll();
            label4.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_genehmigt_am_MouseDown(object sender, MouseEventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_get_focus;
            mtxt_genehmigt_am.SelectAll();
        }
        //
        //   mtxt_verstaendigt_am 5
        //
        private void mtxt_verstaendigt_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_verstaendigt_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_verstaendigt_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_verstaendigt_am.Text) == false)
                {
                    mtxt_verstaendigt_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_verstaendigt_am.Text, strip_info, this.Cursor);
                }
                Verstaendigt_AM = mtxt_verstaendigt_am.Text;
            }
            label5.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_verstaendigt_am_Enter(object sender, EventArgs e)
        {
            mtxt_verstaendigt_am.SelectAll();
            label5.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_verstaendigt_am_MouseDown(object sender, MouseEventArgs e)
        {
            mtxt_verstaendigt_am.SelectAll();
            label5.ForeColor = AKK_Helper.c_get_focus;
        }
        //
        //   mtxt_anweisung_am 6
        //
        private void mtxt_anweisung_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_anweisung_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_anweisung_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_anweisung_am.Text) == false)
                {
                    mtxt_anweisung_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_anweisung_am.Text, strip_info, this.Cursor);
                }
            }
            label6.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_anweisung_am_Enter(object sender, EventArgs e)
        {
            mtxt_anweisung_am.SelectAll();
            label6.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_anweisung_am_MouseDown(object sender, MouseEventArgs e)
        {
            mtxt_anweisung_am.SelectAll();
            label6.ForeColor = AKK_Helper.c_get_focus;
        }

        //
        //   mtxt_auszahlung_am 7
        //
        private void mtxt_auszahlung_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_auszahlung_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_auszahlung_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_auszahlung_am.Text) == false)
                {
                    mtxt_auszahlung_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_auszahlung_am.Text, strip_info, this.Cursor);
                }
            }
            label7.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_auszahlung_am_Enter(object sender, EventArgs e)
        {
            mtxt_auszahlung_am.SelectAll();
            label7.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_auszahlung_am_MouseDown(object sender, MouseEventArgs e)
        {
            mtxt_auszahlung_am.SelectAll();
            label7.ForeColor = AKK_Helper.c_get_focus;
        }
        //
        //   mtxt_geklagt_a 8
        //
        private void mtxt_geklagt_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_geklagt_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_geklagt_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_geklagt_am.Text) == false)
                {
                    mtxt_geklagt_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_geklagt_am.Text, strip_info, this.Cursor);
                }
            }
            label8.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_geklagt_am_Enter(object sender, EventArgs e)
        {
            mtxt_geklagt_am.SelectAll();
            label8.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_geklagt_am_MouseDown(object sender, MouseEventArgs e)
        {
            label8.ForeColor = AKK_Helper.c_get_focus;
            mtxt_geklagt_am.SelectAll();
        }
        //
        //   mtxt_tilgung_am 9
        //
        private void mtxt_tilgung_am_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_tilgung_am_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_tilgung_am.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_tilgung_am.Text) == false)
                {
                    mtxt_tilgung_am.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_tilgung_am.Text, strip_info, this.Cursor);
                }
            }
            label9.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_tilgung_am_Enter(object sender, EventArgs e)
        {
            mtxt_tilgung_am.SelectAll();
            label9.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_tilgung_am_MouseDown(object sender, MouseEventArgs e)
        {
            label9.ForeColor = AKK_Helper.c_get_focus;
            mtxt_tilgung_am.SelectAll();
        }
        //
        //   cbo_verwendungszweck 15
        //
        private void cbo_verwendungszweck_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void cbo_verwendungszweck_Enter(object sender, EventArgs e)
        {
            label15.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_verwendungszweck_Leave(object sender, EventArgs e)
        {
            label15.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_verwendungszweck_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_verwendungszweck);
        }

        private void fill_Antragsstatus(Boolean ish)
        {
            try
            {

                DC_Columns cols = new DC_Columns();
                DC_Columns c = new DC_Columns();
                Response resp = null;
                DataService.DataServiceClient client = new DataServiceClient();
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST4", "");
                if (resp.ResponseCode == 0)
                {
                    for (int i = 0; i < cols.Count; i++)
                    {
                        if (ish)
                        {
                            if (int.Parse(cols[i].DM_col_02) > 10)
                            {
                                c.Add(cols[i]);
                            }
                        }
                        else
                        {
                            if (int.Parse(cols[i].DM_col_02) < 10 && int.Parse(cols[i].DM_col_02) > 0)
                            {
                                c.Add(cols[i]);
                            }
                        }

                    }
                    AKK_Helper.fill_Listbox(cbo_antragsstatus, c);
                    AKK_Helper.fill_dgv(dgv_antragsstatus, c);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                AKK_Helper.show_msg(AKK_Helper.str_error["CJ003"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor); //neuer Error
            }
        }
        private void cbo_verwendungszweck_SelectedIndexChanged(object sender, EventArgs e)
        {
            vwzChanged = true;
            chkBKoordinationspartner.Enabled = false;
            chkBKoordinationspartner.Checked = false;
            AKK_Helper.set_actual_index(cbo_verwendungszweck.SelectedIndex.ToString(), cbo_verwendungszweck.Text);
            if (cbo_verwendungszweck.SelectedValue.ToString() == "20" || cbo_verwendungszweck.SelectedValue.ToString() == "29") //if wbd oder ish
            {
                cbo_bildungstraeger.Visible = true;
                cbo_bildungstraeger.Enabled = true;
            }
            else
            {
                cbo_bildungstraeger.Enabled = false;
                cbo_bildungstraeger.SelectedIndex = 0;
                cbo_bildungstraeger.Visible = false;
            }

            if (cbo_verwendungszweck.SelectedValue.ToString() == "20")
            {
                label16.Visible = true;
                label16.Text = "Bildungsträger:";
            }
            else
            {
                label16.Visible = false;
            }





            if (cbo_verwendungszweck.SelectedValue.ToString() == "30")
            {
                chkBKoordinationspartner.Enabled = true;
            }




            if (cbo_verwendungszweck.SelectedValue.ToString() == "29") //ISH
            {
                AKK_Helper.C.strBereichKey = "18";

                txt_rate.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                label28.Visible = false;
                label16.Visible = true;
                label16.Text = "Gläubigervertreter:";
                mtxt_laufzeit.Visible = false;

                cmd_mitschuldner.Text = "Firma";

                chk_scheidung.Enabled = false;
                chk_Bankeinzug.Enabled = false;

                chk_scheidung.Visible = false;
                chk_Bankeinzug.Visible = false;
            }
            else //WBD
            {
                AKK_Helper.C.strBereichKey = "2";

                txt_rate.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                label28.Visible = true;
                mtxt_laufzeit.Visible = true;

                cmd_mitschuldner.Text = "Mitschuldner";
                chk_scheidung.Enabled = true;
                chk_Bankeinzug.Enabled = true;

                chk_scheidung.Visible = true;
                chk_Bankeinzug.Visible = true;
            }

            try
            {
                DC_Columns cols = new DC_Columns();
                //DC_Columns scols = new DC_Columns();
                DC_Columns c = new DC_Columns();
                //DC_Columns s = new DC_Columns();

                Response resp = null;
                //Response sresp = null;
                DataService.DataServiceClient client = new DataServiceClient();
                //DataService.DataServiceClient sclient = new DataServiceClient();
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BT1", "");
                //sresp = client.get_SQL_Data(out scols, AKK_Helper.SessionToken, "AST4", "");
                if (resp.ResponseCode == 0)
                {
                    if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                    {
                        txt_rate.Visible = false;
                        txt_kosten.Visible = false;
                        mtxt_laufzeit.Text = "6";
                        mtxt_laufzeit.Enabled = false;
                        label16.Text = "Gläubigervertr.";
                        for (int i = 0; i < cols.Count; i++)
                        {
                            if (int.Parse(cols[i].DM_col_02) > 49)
                            {
                                c.Add(cols[i]);
                            }
                        }
                        /*for (int i = 0; i < scols.Count; i++)
                        {
                            if (int.Parse(scols[i].DM_col_02) > 10)
                            {
                                s.Add(scols[i]);
                            }
                        }*/
                        fill_Antragsstatus(true);
                    }
                    else
                    {
                        if (!txt_rate.Visible)
                        {
                            txt_rate.Visible = true;
                            txt_rate.Text = "";
                        }
                        /*if (!txt_kosten.Visible)
                        {
                            txt_kosten.Visible = true;
                            txt_kosten.Text = "";
                        }*/
                        if (!mtxt_laufzeit.Enabled)
                        {
                            mtxt_laufzeit.Enabled = true;
                            mtxt_laufzeit.Text = "";
                        }
                        label16.Text = "Bildungsträger";
                        for (int i = 0; i < cols.Count; i++)
                        {
                            if (int.Parse(cols[i].DM_col_02) < 50 && int.Parse(cols[i].DM_col_02) > 0)
                            {
                                c.Add(cols[i]);
                            }
                        }
                        fill_Antragsstatus(false);
                        /*for (int i = 0; i < scols.Count; i++)
                        {
                            if (int.Parse(scols[i].DM_col_02) < 10 && int.Parse(scols[i].DM_col_02) > 0)
                            {
                                s.Add(scols[i]);
                            }
                        }*/
                    }
                    AKK_Helper.fill_Listbox(cbo_bildungstraeger, c);
                    //AKK_Helper.fill_Listbox(cbo_antragsstatus, s);

                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                AKK_Helper.show_msg(AKK_Helper.str_error["CJ002"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor); //neuer Error
            }



            // Status neu laden
            /*try
            {
                DC_Columns cols = new DC_Columns();
                DC_Columns c = new DC_Columns();

                Response resp = null;
                DataService.DataServiceClient client = new DataServiceClient();
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST4", "");
                if (resp.ResponseCode == 0)
                {
                    for (int i = 0; i < cols.Count - 1; i++)
                    {
                        if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                        {
                            if (int.Parse(cols[i].DM_col_04) < 10)
                            {
                                c.Add(cols[i]);
                            }
                        }
                        else
                        {
                            if (int.Parse(cols[i].DM_col_04) > 10)
                            {
                                c.Add(cols[i]);
                            }
                        }
                    }
                    AKK_Helper.fill_Listbox(cbo_antragsstatus, c);
                    AKK_Helper.fill_dgv(dgv_antragsstatus, c);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                AKK_Helper.show_msg(AKK_Helper.str_error["CJ003"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor); //neuer Error
            }*/
            this.Cursor = Cursors.Default;


        }
        //
        // Bildungsträger
        //
        private void cbo_bildungstraeger_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void cbo_bildungstraeger_Enter(object sender, EventArgs e)
        {
            label16.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_bildungstraeger_Leave(object sender, EventArgs e)
        {
            label16.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_bildungstraeger_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_bildungstraeger);
        }
        private void cbo_bildungstraeger_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_bildungstraeger.SelectedIndex.ToString(), cbo_bildungstraeger.Text);
        }
        //
        // Geklagt und Scheidung
        //
        private void chk_geklagt_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_klage_first == false)
            {
                isBankeinzug = true;
                if (cbo_antragsstatus.SelectedValue.ToString() != AKK_Helper.C.strG_SWBD_PO && cbo_antragsstatus.SelectedValue.ToString() != AKK_Helper.C.strG_SISH_PO)
                {
                    if (chk_geklagt.Checked == true)
                    {
                        AKK_Helper.show_msg("Dieser Status ist in dieser Situation nicht möglich", strip_info, this.Cursor);
                        chk_geklagt.Checked = false;
                        is_Geklagt = false;
                    }
                }
                else
                {
                    if (chk_geklagt.Checked == true)
                    {
                        is_Geklagt = true;
                        isBankeinzug = true;
                        // txt_anmerkung.Text = txt_anmerkung.Text + " geklagt";
                        txt_anmerkung.Text = "geklagt"; // 26-08-2011 KJ

                        DateTime today = DateTime.Now;
                        mtxt_geklagt_am.Text = today.ToString("dd.MM.yyyy");
                        chk_geklagt.Enabled = true;
                        cmd_status_aendern.Enabled = false;
                        cmd_mahnstatus.Enabled = false;
                        txt_darlehensbetrag.Enabled = false;
                        mtxt_laufzeit.Enabled = false;
                        cbo_verwendungszweck.Enabled = false;
                        cbo_bildungstraeger.Enabled = false;
                        cbo_ablehnung.Enabled = false;
                        mtxt_rueckab.Enabled = false;
                        mtxt_genehmigt_am.Enabled = false;
                        //mtxt_geplante_auszahlung.Enabled = false;
                        lst_Monat.Enabled = false;
                        lst_Jahr.Enabled = false;

                    }
                    else
                    {
                        is_Geklagt = true;
                    }
                }
            }
        }
        private void chk_scheidung_CheckedChanged(object sender, EventArgs e)
        {

            isBankeinzug = true;
            if (chk_scheidung.Checked == true)
                txt_antragsteller.BackColor = Color.Beige;
            else
                txt_antragsteller.BackColor = SystemColors.InactiveBorder;

        }
        //
        // Darlegensbetrag
        //
        private void txt_darlehensbetrag_Enter(object sender, EventArgs e)
        {
            label21.ForeColor = AKK_Helper.c_get_focus;
            txt_darlehensbetrag.SelectAll();
        }
        private void txt_darlehensbetrag_Leave(object sender, EventArgs e)
        {

            if (AKK_Helper.checkLogin() == true)
            {
                double Betrag = 0;
                Int32 IntLaufzeit = 0;
                double DblRate = 0.00;
                DateTime dt1_rueckbisvertr;
                DateTime dt1_rueckbisreal;
                DateTime dt1_rueckab;

                DateTime.TryParse(mtxt_rueckbisvertr.Text, out dt1_rueckbisvertr);
                DateTime.TryParse(mtxt_rueckbisreal.Text, out dt1_rueckbisreal);
                DateTime.TryParse(mtxt_rueckab.Text, out dt1_rueckab);

                string datRet = "";

                if (Double.TryParse(txt_darlehensbetrag.Text, out Betrag) == false)
                {
                    if (AKK_Helper.is_empty(txt_darlehensbetrag.Text) == true)
                    {
                    }
                    else
                    {
                        AKK_Helper.show_msg("Kein gültiger Betrag!", strip_info, this.Cursor);
                        txt_darlehensbetrag.Focus();
                        txt_darlehensbetrag.SelectAll();
                    }
                    return;
                }
                if (Betrag <= 0.0)
                {

                    if (Betrag == 0.0)
                    {
                        mtxt_rueckbisvertr.Text = "";
                        mtxt_rueckbisreal.Text = "";
                        mtxt_laufzeit.Text = "0";
                        txt_rate.Text = AKK_Helper.FormatBetragOhneKomma("0");
                        txt_kosten.Text = AKK_Helper.FormatBetrag("0");
                        txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                        txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                        //mtxt_geplante_auszahlung.Enabled = false;
                        lst_Monat.Enabled = false;
                        lst_Jahr.Enabled = false;

                        cmd_kontenblatt.Enabled = false;
                        cmd_mahnstatus.Enabled = false;

                    }

                    if (Betrag < 0)
                    {
                        Betrag = Betrag * (-1);
                        txt_darlehensbetrag.Text = Betrag.ToString();

                        AKK_Helper.show_msg("Kein gültiger Betrag!", strip_info, this.Cursor);
                        txt_darlehensbetrag.Focus();
                    }
                    txt_darlehensbetrag.Text = AKK_Helper.FormatBetragOhneKomma(txt_darlehensbetrag.Text);
                    return;
                }
                txt_darlehensbetrag.Text = AKK_Helper.FormatBetragOhneKomma(txt_darlehensbetrag.Text);
                Int32.TryParse(mtxt_laufzeit.Text, out IntLaufzeit);

                if (IntLaufzeit != 0)
                {
                    //sprungmarke
                    if (cbo_verwendungszweck.SelectedValue.ToString() != "29")
                    {
                        DblRate = Betrag / IntLaufzeit;
                        txt_rate.Text = DblRate.ToString();
                    }
                    else
                    {
                        DblRate = Betrag;
                        txt_rate.Text = DblRate.ToString();
                    }

                    //
                    // Berechnen des neuen Vertraglichen Endes der Rückzahlung
                    //
                    if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false)
                    {
                        Double DblKosten;
                        Double.TryParse(txt_kosten.Text, out DblKosten);

                        mtxt_rueckbisvertr.Text = AKK_Helper.Calc_AddMonths(DblKosten,
                                                                             DblRate,
                                                                             IntLaufzeit,
                                                                             mtxt_rueckab.Text);


                        //if (Kosten == 0.0)
                        //{
                        //    mtxt_rueckbisvertr.Text = dt1_rueckab.AddMonths(Laufzeit - 1).ToString();
                        //}
                        //else
                        //{
                        //    if (Rate > Kosten && Kosten != 0)
                        //    {
                        //        mtxt_rueckbisvertr.Text = dt1_rueckab.AddMonths(Laufzeit).ToString();
                        //    }
                        //    else
                        //    {
                        //        Int32 intRTmp = ( Int32 ) Math.Floor(Kosten / Rate);
                        //        if (Kosten % Rate > 0)
                        //            intRTmp = intRTmp + 1;
                        //        intRTmp = intRTmp - 1;
                        //        mtxt_rueckbisvertr.Text = dt1_rueckab.AddMonths(Laufzeit + intRTmp).ToString();

                        //    }
                        //}
                        //
                        // Berechnen des realen Rückzahlungsende
                        //
                        string str_wbd_ikey = "";
                        if (obj_wbd_antrag.DM_wbd_ikey == null)
                        {
                            str_wbd_ikey = "-2";
                        }
                        else
                        {
                            str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
                        }

                        Int32 intLaufzeit;
                        Int32.TryParse(mtxt_laufzeit.Text, out intLaufzeit);

                        Response resp = new Response();
                        DataService.DataServiceClient client = new DataServiceClient();
                        resp = client.Get_DLEnd_Reals(out datRet,
                                                      AKK_Helper.SessionToken,
                                                      mtxt_rueckab.Text,
                                                      mtxt_rueckbisvertr.Text,
                                                      intLaufzeit,
                                                      DblRate,
                                                      DblKosten,
                                                      str_wbd_ikey);
                        if (resp.ResponseCode == 0)
                        {
                            mtxt_rueckbisreal.Text = datRet;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            mtxt_rueckbisreal.Text = "";
                            mtxt_rueckbisvertr.Text = "";
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                        }
                        //
                        // Berechnen des theoretischen Tilgungsstandes,
                        // wenn der Rückzahlungsstart und die ratenhöhe definiert ist.
                        //
                        bool ish = false;
                        if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                        {
                            ish = true;
                        }
                        double dbl_Tilgungsstatus = 0.0;
                        resp = null;
                        resp = new Response();
                        client = null;
                        client = new DataServiceClient();
                        resp = client.Get_Akt_TilgungsST(out dbl_Tilgungsstatus,
                                         AKK_Helper.SessionToken,
                                         obj_wbd_antrag.DM_wbd_ikey,
                                         txt_rate.Text,
                                         mtxt_rueckab.Text,
                                         mtxt_rueckbisreal.Text,
                                         txt_kosten.Text,
                                         txt_darlehensbetrag.Text,
                                         ish);



                        if (resp.ResponseCode == 0)
                        {
                            double dbl_Dahrlehensbetrag;
                            double.TryParse(txt_darlehensbetrag.Text, out dbl_Dahrlehensbetrag);

                            double dbl_Kontosstand;
                            double.TryParse(txt_aktKontostand.Text, out dbl_Kontosstand);

                            if (mtxt_auszahlung_am.Text != "  .  .")
                            {

                                //David Stefitz 10.05.2019 Tilgungsstatus wurde nicht richtig angezeigt, wird jetzt neu berechnet
                                txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                            }
                            else
                            {
                                dbl_Tilgungsstatus = 0;
                                txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                            }
                            double dbl_Tilgstand;
                            double.TryParse(txt_tilg_stand.Text, out dbl_Tilgstand);

                            double dbl_sum = AKK_Helper.Calc_Diff(mtxt_auszahlung_am.Text,
                                                                   mtxt_rueckab.Text,
                                                                   dbl_Dahrlehensbetrag,
                                                                   dbl_Tilgstand,
                                                                   dbl_Kontosstand);

                            //David Stefitz 05.02.2019 Änderung von > auf < als weil das Konto Negativ angegeben wird!
                            //David Stefitz 16.07.2019 Wieder auf > geändert war ein Denkfehler
                            if (dbl_Kontosstand > 0)
                            {
                                txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                            }
                            else
                            {
                                txt_Dif.Text = AKK_Helper.FormatBetragPlus(dbl_sum.ToString());
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                        }


                        resp = new Response();
                        client = new DataServiceClient();
                        string str_Tilgungstext = "";
                        resp = client.Get_Info_Status(out str_Tilgungstext,
                                                      AKK_Helper.SessionToken,
                                                      obj_wbd_antrag.DM_wbd_ikey,
                                                      mtxt_rueckbisreal.Text);
                        if (resp.ResponseCode == 0)
                        {
                            txt_laufzeitstatus.Text = str_Tilgungstext;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            txt_laufzeitstatus.Text = "";
                        }
                        //mtxt_geplante_auszahlung.Enabled = true;
                        lst_Monat.Enabled = true;
                        lst_Jahr.Enabled = true;

                    }
                }
                label21.ForeColor = AKK_Helper.c_lost_focus;
            }   // Check Login
        }
        private void txt_darlehensbetrag_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;

        }
        private void txt_darlehensbetrag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = AKK_Helper.format_input_number(sender, e, txt_darlehensbetrag.Text.ToString());
        }
        //
        // unterfertigt    
        // 
        private void chk_unterfertigt_CheckedChanged(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DataService.DataServiceClient client = new DataServiceClient();
                DC_Columns cols = new DC_Columns();

                if (is_fLoad == false)
                    is_fLoad = false;
                else
                {

                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "URG1", obj_wbd_antrag.DM_wbd_ikey);
                    if (resp.ResponseCode == 0)
                    {   // Urgenz
                        if (cols.Count > 0)
                        {
                            AKK_Helper.show_msg("Es gibt noch offene Urgenzpunkte!", strip_info, this.Cursor);
                            chk_unterfertigt.Checked = false;
                            cmd_urgenz.Focus();
                            return;
                        }
                        // Datum
                        DateTime today = DateTime.Now;
                        DateTime result;
                        DateTime.TryParse(mtxt_rueckab.Text, out result);
                        if (result < today && chk_unterfertigt.Checked == true)
                        {
                            AKK_Helper.show_msg("Das Rückzahlungsdatum muss nach dem Tagesdatum liegen!", strip_info, this.Cursor);
                            chk_unterfertigt.Checked = false;
                            mtxt_rueckab.Focus();
                            return;
                        }
                        // Rate
                        if (AKK_Helper.is_empty_Null(txt_rate.Text) == true && chk_unterfertigt.Checked == true)
                        {
                            AKK_Helper.show_msg("Die Rückzahlungsrate muss definiert sein!", strip_info, this.Cursor);
                            chk_unterfertigt.Checked = false;
                            txt_rate.Focus();
                            return;
                        }
                        if (chk_unterfertigt.Checked == false &&
                            AKK_Helper.is_empty_Null(txt_rate.Text) == false &&
                            AKK_Helper.is_empty_date(mtxt_anweisung_am.Text) == false)
                        {
                            AKK_Helper.show_msg("Sie setzen eine Unterfertigung zurück!", strip_info, this.Cursor);
                        }
                        if (result >= today && chk_unterfertigt.Checked == true)
                        {
                            isBankeinzug = true;
                            mtxt_laufzeit.Enabled = false;
                            txt_darlehensbetrag.Enabled = false;
                            mtxt_rueckab.Enabled = false;
                            //mtxt_geplante_auszahlung.Enabled = false;
                            lst_Monat.Enabled = false;
                            lst_Jahr.Enabled = false;

                            // Antragsstatus
                            AKK_Helper.ChangeBoxSel(cbo_antragsstatus, AKK_Helper.C.strPOS_CODE, 2, dgv_antragsstatus);
                        }

                        //
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }
                }
            }
        }
        private void chk_unterfertigt_Enter(object sender, EventArgs e)
        {
            chk_unterfertigt.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_unterfertigt_Leave(object sender, EventArgs e)
        {
            chk_unterfertigt.ForeColor = AKK_Helper.c_lost_focus;
        }

        //
        // Rate & Kosten
        //
        private void txt_rate_TextChanged(object sender, EventArgs e)
        {
            txt_rate.Text = AKK_Helper.FormatBetragOhneKomma(txt_rate.Text);
        }
        private void txt_kosten_TextChanged(object sender, EventArgs e)
        {
            txt_kosten.Text = AKK_Helper.FormatBetrag(txt_kosten.Text);
        }
        //
        //  laufzeit
        //
        private void mtxt_laufzeit_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_laufzeit_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Int32 intLaufzeit;
                double dblDarlehensbetrag = 0;
                double dblRate = 0;
                double dblKosten = 0;
                double dblAktKontostand;
                //
                double.TryParse(txt_aktKontostand.Text, out dblAktKontostand);



                if (Int32.TryParse(mtxt_laufzeit.Text, out intLaufzeit) == true)
                {
                    if (double.TryParse(txt_darlehensbetrag.Text, out dblDarlehensbetrag) == true)
                    {
                        if ((dblDarlehensbetrag == 0) || (intLaufzeit == 0))
                            return;
                        else
                            dblRate = dblDarlehensbetrag / intLaufzeit;
                        dblKosten = dblDarlehensbetrag - dblRate * intLaufzeit;
                        txt_rate.Text = AKK_Helper.FormatBetragOhneKomma(dblRate.ToString());
                        txt_kosten.Text = AKK_Helper.FormatBetrag(dblKosten.ToString());
                        mtxt_rueckab.Enabled = true;
                    }


                    // else      -->         // Keine Anweisung, wenn der Darlehensbetrag noch nicht erfasst  wurde.
                    DataService.DataServiceClient client = new DataServiceClient();
                    Response resp = new Response();
                    if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false)
                    {
                        //
                        // Berechnung des neuen vertraglichen Endes der Rückzahlung
                        //
                        DateTime DT_rueckab;
                        DateTime.TryParse(mtxt_rueckab.Text, out DT_rueckab);


                        mtxt_rueckbisvertr.Text = AKK_Helper.Calc_AddMonths(dblKosten,
                                                                            dblRate,
                                                                            intLaufzeit,
                                                                            mtxt_rueckab.Text);


                        //if (dblKosten == 0)
                        //{
                        //    mtxt_rueckbisvertr.Text = DT_rueckab.AddMonths(intLaufzeit - 1).ToString(); 
                        //
                        //}
                        //else
                        //{
                        //    if (dblRate > dblKosten && dblKosten != 0)
                        //    {
                        //        mtxt_rueckbisvertr.Text = DT_rueckab.AddMonths(intLaufzeit).ToString(); 
                        //    }
                        //    else
                        //    {
                        //        double intRTmp = dblKosten / dblRate;
                        //        if (dblKosten % dblRate > 0)
                        //        {
                        //            intRTmp = intRTmp + 1;
                        //        }
                        //        intRTmp = intRTmp - 1;
                        //        mtxt_rueckbisvertr.Text = DT_rueckab.AddMonths(intLaufzeit + (Int32) intRTmp).ToString(); ;
                        //    }
                        //}

                        //
                        // Berechnen des realen Rückzahlungsende
                        //
                        string str_wbd_ikey = "";
                        if (obj_wbd_antrag.DM_wbd_ikey == null)
                        {
                            str_wbd_ikey = "-2";
                        }
                        else
                        {
                            str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
                        }
                        string datRet = "";
                        //
                        resp = client.Get_DLEnd_Reals(out datRet,
                                                      AKK_Helper.SessionToken,
                                                      mtxt_rueckab.Text,
                                                      mtxt_rueckbisvertr.Text,
                                                      intLaufzeit,
                                                      dblRate,
                                                      dblKosten,
                                                      str_wbd_ikey);
                        if (resp.ResponseCode == 0)
                        {
                            mtxt_rueckbisreal.Text = datRet;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            mtxt_rueckbisreal.Text = "";
                            mtxt_rueckbisvertr.Text = "";
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                        }
                    }
                    //
                    // Berechnung des theoretischen Tilgungsstandes, wenn der
                    // Rückzahlungsstart und dei Rate definiert sind
                    double dbl_Tilgungsstatus = 0.0;

                    resp = new Response();
                    client = new DataServiceClient();
                    bool ish = false;
                    if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                    {
                        ish = true;
                    }
                    resp = client.Get_Akt_TilgungsST(out dbl_Tilgungsstatus,
                                                     AKK_Helper.SessionToken,
                                                     obj_wbd_antrag.DM_wbd_ikey,
                                                     txt_rate.Text,
                                                     mtxt_rueckab.Text,
                                                     mtxt_rueckbisreal.Text,
                                                     txt_kosten.Text,
                                                     txt_darlehensbetrag.Text,
                                                     ish);
                    if (resp.ResponseCode == 0)
                    {

                        if (mtxt_auszahlung_am.Text != "  .  .")
                        {
                            //David Stefitz 10.05.2019 Tilgungsstatus wurde nicht richtig angezeigt, wird jetzt neu berechnet
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                        }
                        else
                        {
                            dbl_Tilgungsstatus = 0;
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                        }
                        double dbl_sum = AKK_Helper.Calc_Diff(mtxt_auszahlung_am.Text,
                                           mtxt_rueckab.Text,
                                           dblDarlehensbetrag,
                                           dbl_Tilgungsstatus,
                                           dblAktKontostand);

                        //David Stefitz 05.02.2019 Änderung von > auf < als weil das Konto Negativ angegeben wird!
                        //David Stefitz 16.07.2019 Wieder auf > geändert war ein Denkfehler
                        if (dblAktKontostand > 0)
                        {
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                        }
                        else
                        {
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus(dbl_sum.ToString());
                        }
                        //
                        resp = new Response();
                        client = new DataServiceClient();
                        string str_Tilgungstext = "";
                        resp = client.Get_Info_Status(out str_Tilgungstext,
                                                      AKK_Helper.SessionToken,
                                                      obj_wbd_antrag.DM_wbd_ikey,
                                                      mtxt_rueckbisreal.Text);
                        if (resp.ResponseCode == 0)
                        {
                            txt_laufzeitstatus.Text = str_Tilgungstext;
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            txt_laufzeitstatus.Text = "";
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                        // txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                    }


                }
                else
                {
                    AKK_Helper.show_msg("Keine gültige Laufzeit!", strip_info, this.Cursor);
                    mtxt_laufzeit.Focus();
                    mtxt_laufzeit.SelectAll();
                    mtxt_rueckbisvertr.Text = "";
                    mtxt_rueckbisreal.Text = "";
                    txt_rate.Text = AKK_Helper.FormatBetragOhneKomma("0");
                    txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                    txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                }




                label23.ForeColor = AKK_Helper.c_lost_focus;
            }   // login
        }
        private void mtxt_laufzeit_Enter(object sender, EventArgs e)
        {
            label23.ForeColor = AKK_Helper.c_get_focus;
            mtxt_laufzeit.SelectAll();
            Double dbl_DLB;
            if (Double.TryParse(txt_darlehensbetrag.Text, out dbl_DLB) == false)
            {
                AKK_Helper.show_msg("Kann nur gesetzt werden, wenn der Darlehensbetrag gegeben ist", strip_info, this.Cursor);
                mtxt_laufzeit.Focus();
                mtxt_laufzeit.SelectAll();
            }

        }
        //
        // Antragssrtatus
        //
        private void cbo_antragsstatus_Enter(object sender, EventArgs e)
        {
            label24.ForeColor = AKK_Helper.c_get_focus;
            AKK_Helper.str_Old_Status = cbo_antragsstatus.SelectedValue.ToString();
        }
        private void cbo_antragsstatus_Leave(object sender, EventArgs e)
        {
            label24.ForeColor = AKK_Helper.c_lost_focus;


            ////
            //string str_Act_Value = cbo_antragsstatus.SelectedValue.ToString();
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_UG)
            //{
            //    cbo_verwendungszweck.Enabled = true;
            //    cbo_bildungstraeger.Enabled = true;
            //}
            //else
            //{
            //    cbo_verwendungszweck.Enabled = false;
            //    cbo_bildungstraeger.Enabled = false;
            //}
            ////
            //// Changed Stati && Positiv
            ////
            //if (AKK_Helper.str_Old_Status != str_Act_Value)
            //{
            //    is_fAenderung = true;
            //    if (AKK_Helper.str_Old_Status == AKK_Helper.C.strG_SWBD_PO)
            //    {
            //        MessageBox.Show("Händische Änderung Status positiv ist nicht möglich!");
            //        cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
            //        return;
            //    }
            //}
            ////
            //// Positiv
            ////
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_PO &&
            //                     AKK_Helper.is_empty_Null(txt_rate.Text) == true &&
            //                     AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
            //{
            //    MessageBox.Show("Dieser Status ist in dieser Situation nicht möglich!");
            //    cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
            //    return;
            //}
            //double dbl_Kontostand;
            //double.TryParse(txt_aktKontostand.Text, out dbl_Kontostand);
            ////
            //// Tilgung
            ////
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_TL           &&
            //                     ( chk_unterfertigt.Checked == false ||
            //                       dbl_Kontostand  != 0 ))
            //{
            //    MessageBox.Show("Dieser Status ist in dieser Situation nicht möglich!");
            //    cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
            //    return;
            //}
            ////
            //// Überzahlung
            ////
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_UZ           &&
            //                     ( chk_unterfertigt.Checked == false ||
            //                       dbl_Kontostand <= 0 ))
            //{
            //    MessageBox.Show("Dieser Status ist in dieser Situation nicht möglich!");
            //    cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
            //    return;
            //}
            ////
            //// Positiv
            ////
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_PO)
            //{
            //    chk_geklagt.Enabled = true;
            //    chk_unterfertigt.Checked = true;
            //}
            //else
            //{
            //    chk_geklagt.Enabled = false;
            //    chk_unterfertigt.Enabled = false;
            //}
            ////
            //// Urgenz
            ////
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_UG )
            //{
            //    cmd_urgenz.Enabled = true;
            //}
            //else
            //{
            //    cmd_urgenz.Enabled = false;
            //}
            ////
            ////  Negativ
            ////
            //if (str_Act_Value == AKK_Helper.C.strG_SWBD_NG)
            //{
            //    cbo_ablehnung.Enabled = true;
            //    lbl_ablehnung.Enabled = true;
            //}
            //else
            //{
            //    cbo_ablehnung.Enabled =false;
            //    lbl_ablehnung.Enabled = false;
            //    cbo_ablehnung.SelectedValue = "-10";  
            //}
            ////
            //// Old Status
            ////
            //if (AKK_Helper.str_Old_Status == AKK_Helper.C.strG_SWBD_NG &&
            //    str_Act_Value == AKK_Helper.C.strG_SWBD_IB)
            //    {
            //        mtxt_rueckab.Enabled = true;
            //        txt_darlehensbetrag.Enabled = true;
            //        mtxt_laufzeit.Enabled = true;
            //    }
            label24.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_antragsstatus_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_antragsstatus);
        }
        private void cbo_antragsstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AKK_Helper.isG_first == true)
            {
                AKK_Helper.isG_first = false;
                return;
            }

            AKK_Helper.set_actual_index(cbo_antragsstatus.SelectedIndex.ToString(), cbo_antragsstatus.Text);

            //

            string str_Act_Value = cbo_antragsstatus.SelectedValue.ToString();
            if (str_Act_Value == AKK_Helper.C.strG_SWBD_UG || str_Act_Value == AKK_Helper.C.strG_SISH_UG)
            {
                cbo_verwendungszweck.Enabled = true;
                cbo_bildungstraeger.Enabled = false;
            }
            else
            {
                cbo_verwendungszweck.Enabled = false;
                cbo_bildungstraeger.Enabled = false; // 12-05-2011 by KJ
            }

            //
            // Changed Stati && Positiv
            //
            if (cbo_antragsstatus.SelectedIndex != -1 && AKK_Helper.str_Old_Status != str_Act_Value && onLoad == false)
            {
                isBankeinzug = true;
                if (AKK_Helper.str_Old_Status == AKK_Helper.C.strG_SWBD_PO || AKK_Helper.str_Old_Status == AKK_Helper.C.strG_SISH_PO)
                {
                    AKK_Helper.show_msg("Händische Änderung Status positiv ist nicht möglich!", strip_info, this.Cursor);
                    cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
                    return;
                }
            }
            /*else
            {
                if (onLoad) onLoad = false;
            }*/
            //
            // Positiv
            //
            if ((str_Act_Value == AKK_Helper.C.strG_SWBD_PO || str_Act_Value == AKK_Helper.C.strG_SISH_PO) &&
                                 AKK_Helper.is_empty_Null(txt_rate.Text) == true &&
                                 AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
            {
                AKK_Helper.show_msg("Dieser Status ist in dieser Situation nicht möglich!", strip_info, this.Cursor);
                cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
                return;
            }
            double dbl_Kontostand;
            double.TryParse(txt_aktKontostand.Text, out dbl_Kontostand);
            //
            // Tilgung
            //
            if ((str_Act_Value == AKK_Helper.C.strG_SWBD_TL || str_Act_Value == AKK_Helper.C.strG_SISH_TL) &&
                                 (chk_unterfertigt.Checked == false ||
                                   dbl_Kontostand != 0))
            {
                AKK_Helper.show_msg("Dieser Status ist in dieser Situation nicht möglich!", strip_info, this.Cursor);
                cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
                return;
            }
            //
            // Überzahlung
            //
            if ((str_Act_Value == AKK_Helper.C.strG_SWBD_UZ || str_Act_Value == AKK_Helper.C.strG_SISH_UZ) &&
                                 (chk_unterfertigt.Checked == false ||
                                   dbl_Kontostand <= 0))
            {
                AKK_Helper.show_msg("Dieser Status ist in dieser Situation nicht möglich!", strip_info, this.Cursor);
                cbo_antragsstatus.SelectedValue = AKK_Helper.str_Old_Status;
                return;
            }






            //
            // Positiv
            //
            if (str_Act_Value == AKK_Helper.C.strG_SWBD_PO || str_Act_Value == AKK_Helper.C.strG_SISH_PO)
            {
                chk_geklagt.Enabled = true;
                chk_unterfertigt.Checked = true;
            }
            else
            {
                chk_geklagt.Enabled = false;
                chk_unterfertigt.Enabled = false;
            }
            //
            // Urgenz
            //
            if (str_Act_Value == AKK_Helper.C.strG_SWBD_UG || str_Act_Value == AKK_Helper.C.strG_SISH_UG)
            {
                if (AKK_Helper.My_user.CanWrite == true)
                {
                    cmd_urgenz.Enabled = true;
                }
                else
                {
                    cmd_urgenz.Enabled = false;
                    if (AKK_Helper.My_user.CanRead == true)
                    {
                        if (AKK_Helper.C.strG_Antrag_Urgenz == AKK_Helper.c_Yes) cmd_urgenz.Enabled = true;
                    }
                }
            }
            else
            {
                cmd_urgenz.Enabled = false;
            }
            //
            //  Negativ
            //
            if (str_Act_Value == AKK_Helper.C.strG_SWBD_NG || str_Act_Value == AKK_Helper.C.strG_SISH_NG)
            {
                cbo_ablehnung.Enabled = true;
                lbl_ablehnung.Enabled = true;

                DC_Columns cols = new DC_Columns();
                Response resp = null;
                DataService.DataServiceClient client = new DataServiceClient();

                resp = null;
                if (cbo_verwendungszweck.SelectedValue.ToString() == "29") // ISH
                {
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "ABL5ISH", "");
                }
                else // WBD
                {
                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "ABL5", "");
                }

                if (resp.ResponseCode == 0)
                {
                    AKK_Helper.fill_Listbox(cbo_ablehnung, cols);
                    AKK_Helper.fill_dgv(dgv_ablehnung, cols);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }

            }
            else
            {
                cbo_ablehnung.Enabled = false;
                lbl_ablehnung.Enabled = false;
                cbo_ablehnung.SelectedValue = "-10";
            }
            //
            // Old Status
            //
            if ((AKK_Helper.str_Old_Status == AKK_Helper.C.strG_SWBD_NG &&
                str_Act_Value == AKK_Helper.C.strG_SWBD_IB) ||
                 (AKK_Helper.str_Old_Status == AKK_Helper.C.strG_SISH_NG &&
                 str_Act_Value == AKK_Helper.C.strG_SISH_IB)
                )
            {
                mtxt_rueckab.Enabled = true;
                txt_darlehensbetrag.Enabled = true;
                mtxt_laufzeit.Enabled = true;
            }

            set_fields();  // 19-07-2011 by KJ 

        }
        private void cbo_antragsstatus_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        //
        // Ablehnung
        //
        private void cbo_ablehnung_Leave(object sender, EventArgs e)
        {
            lbl_ablehnung.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_ablehnung_Enter(object sender, EventArgs e)
        {
            lbl_ablehnung.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_ablehnung_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void cbo_ablehnung_KeyDown(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_ablehnung);
        }
        private void cbo_ablehnung_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_ablehnung.SelectedIndex.ToString(), cbo_ablehnung.Text);
            //if (cbo_ablehnung.SelectedValue.ToString() != "14")
            //{

            // set_UzTi();
            //}

        }
        //
        // Anmerkung
        //
        private void txt_anmerkung_Leave(object sender, EventArgs e)
        {
            label27.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void txt_anmerkung_Enter(object sender, EventArgs e)
        {
            label27.ForeColor = AKK_Helper.c_get_focus;
        }
        private void txt_anmerkung_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        //
        // CMD URGENZ
        //
        private void cmd_urgenz_Click(object sender, EventArgs e)
        {
            isBankeinzug = true;
            frm_Urgenzen frm_urgenz = new frm_Urgenzen();
            frm_urgenz.str_name = obj_person.DM_nachname + " " + obj_person.DM_vorname;
            frm_urgenz.str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
            frm_urgenz.str_verwendungszweck = cbo_verwendungszweck.GetItemText(cbo_verwendungszweck.SelectedItem);
            switch (cbo_verwendungszweck.GetItemText(cbo_verwendungszweck.SelectedItem))
            {
                case "Alternativenergie":
                    frm_urgenz.str_verwendungszweck_code = "ALT";
                    break;
                case "Aus- und Weiterbildung":
                    frm_urgenz.str_verwendungszweck_code = "BD";
                    break;
                case "Eigentumswohnung":
                    frm_urgenz.str_verwendungszweck_code = "WOH";
                    break;
                case "Genossenschaftswohnung":
                    frm_urgenz.str_verwendungszweck_code = "WOH";
                    break;
                case "Hausbau":
                    frm_urgenz.str_verwendungszweck_code = "EIG";
                    break;
                case "Hauskauf":
                    frm_urgenz.str_verwendungszweck_code = "EIG";
                    break;
                case "Insolvenzsoforthilfe":
                    frm_urgenz.str_verwendungszweck_code = "ISH";
                    break;
                case "Junges Wohnen":
                    frm_urgenz.str_verwendungszweck_code = "JW";
                    break;
                case "Katastrophenhilfe":
                    frm_urgenz.str_verwendungszweck_code = "KAT";
                    break;
                case "Lehrling":
                    frm_urgenz.str_verwendungszweck_code = "JW";
                    break;
                case "Sanierung":
                    frm_urgenz.str_verwendungszweck_code = "SAN";
                    break;
                case "Sanierung - Kanal":
                    frm_urgenz.str_verwendungszweck_code = "SAN";
                    break;
                case "Zu-/Ausbau":
                    frm_urgenz.str_verwendungszweck_code = "EIG";
                    break;
                //TODO ist da noch was zu tun?
                case "Wärmepumpenheizung":
                    frm_urgenz.str_verwendungszweck_code = "EIG";
                    break;
                default:
                    break;

            }



            frm_urgenz.ShowDialog();
            frm_urgenz = null;
        }
        //
        // CMD STATUS ÄNDERN
        //
        private void cmd_status_aendern_Click(object sender, EventArgs e)
        {
            isBankeinzug = true;
            Int32 intLaufZeit = 0;
            double dbl_rate = 0;
            double dbl_kosten = 0;

            Int32.TryParse(mtxt_laufzeit.Text, out intLaufZeit);
            double.TryParse(txt_rate.Text, out dbl_rate);
            double.TryParse(txt_kosten.Text, out dbl_kosten);

            frm_Laufzeitstatus frm_laufzeitstatus = new frm_Laufzeitstatus();
            frm_laufzeitstatus.str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
            frm_laufzeitstatus.rueckbisreal = mtxt_rueckbisreal.Text;
            frm_laufzeitstatus.rueckab = mtxt_rueckab.Text;
            frm_laufzeitstatus.Tilgungstext = txt_laufzeitstatus.Text;

            frm_laufzeitstatus.RueckBisVertr = mtxt_rueckbisvertr.Text;
            frm_laufzeitstatus.Laufzeit = intLaufZeit;
            frm_laufzeitstatus.Rate = dbl_rate;
            frm_laufzeitstatus.Kosten = dbl_kosten;
            frm_laufzeitstatus.Tilgstand = txt_tilg_stand.Text;
            frm_laufzeitstatus.Betrag = txt_darlehensbetrag.Text;

            if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
            {
                frm_laufzeitstatus.ish = true;
            }
            else
            {
                frm_laufzeitstatus.ish = false;
            }

            frm_laufzeitstatus.ShowDialog();

            txt_laufzeitstatus.Text = frm_laufzeitstatus.Tilgungstext;
            mtxt_rueckbisreal.Text = frm_laufzeitstatus.rueckbisreal;
            txt_tilg_stand.Text = AKK_Helper.FormatBetrag(frm_laufzeitstatus.Tilgstand);
            frm_laufzeitstatus = null;
            //
            // Show txt_Dif
            //
            double dbl_Dahrlehensbetrag = 0;
            double.TryParse(txt_darlehensbetrag.Text, out dbl_Dahrlehensbetrag);
            double dbl_Tilgstand = 0;
            double.TryParse(txt_tilg_stand.Text, out dbl_Tilgstand);
            double dbl_Kontosstand = 0;
            double.TryParse(txt_aktKontostand.Text, out dbl_Kontosstand);

            double dbl_sum = AKK_Helper.Calc_Diff(mtxt_auszahlung_am.Text,
                               mtxt_rueckab.Text,
                               dbl_Dahrlehensbetrag,
                               dbl_Tilgstand,
                               dbl_Kontosstand);
            //David Stefitz 05.02.2019 Änderung von > auf < als weil das Konto Negativ angegeben wird!
            //David Stefitz 16.07.2019 Wieder auf > geändert war ein Denkfehler
            if (dbl_Kontosstand > 0)
            {
                txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
            }
            else
            {
                txt_Dif.Text = AKK_Helper.FormatBetragPlus(dbl_sum.ToString());
            }
            this.Refresh();
        }
        //
        // CMD Mitschuldner
        //
        private void cmd_mitschuldner_Click(object sender, EventArgs e)
        {
            isBankeinzug = true;
            frm_mitschuldner frm_Mitschuldner = new frm_mitschuldner();
            if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
            {
                frm_Mitschuldner.ish = true;
                frm_Mitschuldner.Text = "Firma zum aktuellen Antrag";
            }
            else
            {
                frm_Mitschuldner.ish = false;
                frm_Mitschuldner.Text = "Mitschuldner zum aktuellen Antrag";
            }
            frm_Mitschuldner.MS[0] = obj_wbd_antrag.DM_wbd_mts1;
            frm_Mitschuldner.MS[1] = obj_wbd_antrag.DM_wbd_mts2;
            frm_Mitschuldner.MS[2] = obj_wbd_antrag.DM_wbd_mts3;
            frm_Mitschuldner.str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
            frm_Mitschuldner.cur_wbd_antrag = obj_wbd_antrag;

            frm_Mitschuldner.ShowDialog();

            obj_wbd_antrag.DM_wbd_mts1 = frm_Mitschuldner.MS_Org[0];
            obj_wbd_antrag.DM_wbd_mts2 = frm_Mitschuldner.MS_Org[1];
            obj_wbd_antrag.DM_wbd_mts3 = frm_Mitschuldner.MS_Org[2];

            frm_Mitschuldner = null;
            // 
            // actualize Window 
            //
            read_mitschuldner();
            //
        }
        //
        // CMD Bankverbindung
        //
        private void cmd_bankverbindung_Click(object sender, EventArgs e)
        {
            isBankeinzug = true;
            frm_Bank frm_bank = new frm_Bank(this);
            frm_bank.str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
            frm_bank.Bank_Aus = obj_wbd_antrag.DM_wbd_ueber_fkey;
            frm_bank.Bank_Ein = obj_wbd_antrag.DM_wbd_ein_fkey;
            frm_bank.is_Einzug = chk_Bankeinzug.Checked;
            frm_bank.wbd_ezdt = obj_wbd_antrag.DM_wbd_ezdt;
            frm_bank.wbd_ein_idx = obj_wbd_antrag.DM_wbd_ein_idx;
            frm_bank.person_id = obj_person.DM_person_id;
            frm_bank.cur_wbd_antrag = obj_wbd_antrag;



            frm_bank.ShowDialog();

            obj_wbd_antrag.DM_wbd_ueber_fkey = frm_bank.Bank_Aus;
            obj_wbd_antrag.DM_wbd_ein_fkey = frm_bank.Bank_Ein;
            obj_wbd_antrag.DM_wbd_ezdt = frm_bank.wbd_ezdt;
            obj_wbd_antrag.DM_wbd_ein_idx = frm_bank.wbd_ein_idx;





            frm_bank = null;
        }
        //
        private void frm_wbd_antrag_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        /*private void frm_wbd_antrag_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
        }*/
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
        //
        // Bankeinzug
        //
        private void chk_Bankeinzug_CheckedChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void chk_Bankeinzug_Enter(object sender, EventArgs e)
        {
            chk_Bankeinzug.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_Bankeinzug_Leave(object sender, EventArgs e)
        {
            chk_Bankeinzug.ForeColor = AKK_Helper.c_lost_focus;
        }

        //
        // Rüeck Ab
        //
        private void mtxt_rueckab_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_get_focus;
            mtxt_rueckab.SelectAll();
        }
        private void mtxt_rueckab_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.Default;
                Int32 IntLaufzeit = 0;
                Double DblKosten = 0;
                Double DblRate = 0;
                Double DblKtoStand = 0;
                Double DblTilgStand = 0;
                Double DblDahrlehen = 0;
                DateTime DT_rueckab;

                Int32.TryParse(mtxt_laufzeit.Text, out IntLaufzeit);
                Double.TryParse(txt_kosten.Text, out DblKosten);
                Double.TryParse(txt_rate.Text, out DblRate);
                Double.TryParse(txt_aktKontostand.Text, out DblKtoStand);
                Double.TryParse(txt_tilg_stand.Text, out DblTilgStand);
                Double.TryParse(txt_darlehensbetrag.Text, out DblDahrlehen);
                DateTime.TryParse(mtxt_rueckab.Text, out DT_rueckab);


                if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) &&
                     (AKK_Helper.is_empty_date(mtxt_eingang_am.Text) == false) &&
                     (IntLaufzeit != 0))
                {

                    if (AKK_Helper.is_date(mtxt_rueckab.Text) == false)
                    {
                        AKK_Helper.show_msg("Kein gültigen Datum erfasst!", strip_info, this.Cursor);
                        mtxt_rueckab.Focus();
                        mtxt_rueckab.SelectAll();
                        return;
                    }

                    if (AKK_Helper.is_date(mtxt_rueckab.Text) == false)
                    {
                        AKK_Helper.show_msg("Es wurde kein gültiges Datum eingegeben", strip_info, this.Cursor);
                        mtxt_rueckbisvertr.Text = "";
                        mtxt_rueckbisreal.Text = "";
                        txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                        txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                        mtxt_rueckab.Focus();
                        mtxt_rueckab.SelectAll();
                    }
                    else
                    {
                        if ((AKK_Helper.String_to_Number(mtxt_rueckab.Text, "DD.MM.YYYY")) <=
                            (AKK_Helper.String_to_Number(mtxt_eingang_am.Text, "DD.MM.YYYY")))
                        {
                            AKK_Helper.show_msg("Die Rückzahlung kann erst nach dem Eingang des Darlehens beginnen", strip_info, this.Cursor);
                            mtxt_rueckbisvertr.Text = "";
                            mtxt_rueckbisreal.Text = "";
                            txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                            txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                            mtxt_rueckab.Focus();
                            mtxt_rueckab.SelectAll();
                        }
                        else
                        {
                            //
                            // Vertragliche Rückzahlung bis
                            //
                            mtxt_rueckbisvertr.Text = AKK_Helper.Calc_AddMonths(DblKosten,
                                                                                 DblRate,
                                                                                 IntLaufzeit,
                                                                                 mtxt_rueckab.Text);

                            //
                            //Berechnen des Realen Rückzahlungsende
                            //
                            string datRet = "";
                            Response resp = new Response();
                            DataService.DataServiceClient client = new DataServiceClient();
                            resp = client.Get_DLEnd_Reals(out datRet,
                                                           AKK_Helper.SessionToken,
                                                           mtxt_rueckab.Text,
                                                           mtxt_rueckbisvertr.Text,
                                                           IntLaufzeit,
                                                           DblRate,
                                                           DblKosten,
                                                           obj_wbd_antrag.DM_wbd_ikey);
                            if (resp.ResponseCode == 0)
                            {
                                mtxt_rueckbisreal.Text = datRet;
                                //
                                // Berechnung des Theoretischen Tilgungsstandes
                                //
                                double dbl_Tilgungsstatus = 0.0;
                                resp = null;
                                resp = new Response();
                                client = null;
                                client = new DataServiceClient();
                                bool ish = false;
                                if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
                                {
                                    ish = true;
                                }
                                resp = client.Get_Akt_TilgungsST(out dbl_Tilgungsstatus,
                                                 AKK_Helper.SessionToken,
                                                 obj_wbd_antrag.DM_wbd_ikey,
                                                 txt_rate.Text,
                                                 mtxt_rueckab.Text,
                                                 mtxt_rueckbisreal.Text,
                                                 txt_kosten.Text,
                                                 txt_darlehensbetrag.Text,
                                                 ish);

                                if (resp.ResponseCode == 0)
                                {
                                    if (mtxt_auszahlung_am.Text != "  .  .")
                                    {
                                        //David Stefitz 10.05.2019 Tilgungsstatus wurde nicht richtig angezeigt, wird jetzt neu berechnet
                                        txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                                    }
                                    else
                                    {
                                        dbl_Tilgungsstatus = 0;
                                        txt_tilg_stand.Text = AKK_Helper.FormatBetrag(dbl_Tilgungsstatus.ToString());
                                    }

                                    double dbl_sum = AKK_Helper.Calc_Diff(mtxt_auszahlung_am.Text,
                                                         mtxt_rueckab.Text,
                                                         DblDahrlehen,
                                                         DblTilgStand,
                                                         DblKtoStand);
                                    //David Stefitz 05.02.2019 Änderung von > auf < als weil das Konto Negativ angegeben wird!
                                    //David Stefitz 16.07.2019 Wieder auf > geändert war ein Denkfehler
                                    if (DblKtoStand > 0)
                                    {
                                        txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                                    }
                                    else
                                    {
                                        txt_Dif.Text = AKK_Helper.FormatBetragPlus(dbl_sum.ToString());
                                    }


                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    AKK_Helper.handleServiceError(resp);

                                }
                                //
                                // Aktueller Laufzeitstatus  
                                //
                                string str_Tilgungstext = "";
                                resp = client.Get_Info_Status(out str_Tilgungstext,
                                                              AKK_Helper.SessionToken,
                                                              obj_wbd_antrag.DM_wbd_ikey,
                                                              mtxt_rueckbisreal.Text);
                                if (resp.ResponseCode == 0)
                                {
                                    txt_laufzeitstatus.Text = str_Tilgungstext;
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    AKK_Helper.handleServiceError(resp);
                                    txt_laufzeitstatus.Text = "";
                                }


                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                AKK_Helper.handleServiceError(resp);
                                mtxt_rueckbisreal.Text = "";
                                mtxt_rueckbisvertr.Text = "";
                                txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                                txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                            }

                        }
                    }

                }
                else
                {
                    mtxt_rueckbisvertr.Text = "";
                    mtxt_rueckbisreal.Text = "";
                    txt_tilg_stand.Text = AKK_Helper.FormatBetrag("0");
                    txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                    cmd_status_aendern.Enabled = false;
                    cmd_kontenblatt.Enabled = false;
                    cmd_mahnstatus.Enabled = false;
                }
                if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true) && (DblDahrlehen != 0))
                {
                    //mtxt_geplante_auszahlung.Enabled = true;
                    lst_Monat.Enabled = true;
                    lst_Jahr.Enabled = true;

                }
                else
                {
                    //mtxt_geplante_auszahlung.Enabled = false;
                    lst_Monat.Enabled = false;
                    lst_Jahr.Enabled = false;

                }
                label1.ForeColor = AKK_Helper.c_lost_focus;
            }   // Check login
        }
        private void mtxt_rueckab_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        private void mtxt_rueckab_MouseDown(object sender, MouseEventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_get_focus;
            mtxt_rueckab.SelectAll();
        }
        //
        // Geplante Auszahlung
        //
        private void mtxt_geplante_auszahlung_Enter(object sender, EventArgs e)
        {

            if (AKK_Helper.is_empty_YYMM(mtxt_geplante_auszahlung.Text) == true)
            {
                Int32 intJ = System.DateTime.Now.Year;
                Int32 intM = System.DateTime.Now.Month;

                intJ = 16 - (System.DateTime.Now.Year - (intJ));
                // lst_Jahr.SelectedIndex = intJ;
                // lst_Monat.SelectedIndex = intM;
            }
            else
            {
                lst_Jahr.SelectedIndex = 0;
                lst_Monat.SelectedIndex = 0;
            }
            //label13.ForeColor = AKK_Helper.c_get_focus;
            //mtxt_rueckab.SelectAll();

            //if ( is_Fehler == true )
            //{
            //    is_Fehler = false;
            //    return;
            //}
            //strAusGeplOld = "";
            //intAusGeplOld = 0;
            //if (AKK_Helper.is_empty_YYMM (mtxt_geplante_auszahlung .Text ) == false )
            //  {
            //    strAusGeplOld =  mtxt_geplante_auszahlung.Text.Substring(0, 2) + mtxt_geplante_auszahlung.Text.Substring(3, 2);
            //    Int32.TryParse(strAusGeplOld, out intAusGeplOld);
            //  }
        }
        private void mtxt_geplante_auszahlung_Leave(object sender, EventArgs e)
        {
            //Int32 intOldJJ = 0;
            //Int32 intOldMM = 0;
            //string str_X = "";
            //string strT1 = "";
            //string strT2 = "";
            //string strString = "";
            //double dblDarlehensbetrag;

            //Int32 int_azg_ikey = 0;
            //double dbl_azg_geplsum = 0;
            //double dbl_azg_zugsum = 0;

            //Double.TryParse(txt_darlehensbetrag.Text, out dblDarlehensbetrag);

            //if (AKK_Helper.is_empty( strAusGeplOld) == false)
            //{
            //    this.Cursor = Cursors.Default;
            //    if ( intAusGeplOld < 100 )
            //    {
            //        intOldJJ = 0;
            //    }    
            //    else
            //    {
            //        str_X = mtxt_geplante_auszahlung.Text.Substring(0, 2);
            //        Int32 .TryParse (str_X, out intOldJJ );
            //    }
            //    str_X = mtxt_geplante_auszahlung.Text.Substring(3, 2);
            //    Int32 .TryParse (str_X, out intOldMM );
            //}
            //strT1 = mtxt_geplante_auszahlung.Text.Substring(0, 2);
            //strT2 = mtxt_geplante_auszahlung.Text.Substring(3, 2);

            //if ((AKK_Helper.is_empty_YYMM (mtxt_geplante_auszahlung .Text )) == false )
            //{
            //    if ( strT1 == "__" || strT2 == "__" )
            //    { 
            //        MessageBox.Show ("Kein gültige Eingabe!");
            //        mtxt_geplante_auszahlung.Focus();
            //        is_Fehler = true;
            //        return;
            //    } 
            //} 
            //if ((AKK_Helper.is_empty_YYMM (mtxt_geplante_auszahlung .Text )) == false )
            //{
            //    strString = mtxt_geplante_auszahlung.Text.Substring(0, 2) + mtxt_geplante_auszahlung.Text.Substring(3, 2);
            //    if (strString != strAusGeplOld)
            //    { 
            //        is_AusGepl = true;
            //        if (AKK_Helper.is_empty (  strAusGeplOld) == false)
            //        {
            //            Boolean is_Ueberzogen = false;
            //            DC_Columns cols = new DC_Columns();
            //            Response resp = null;
            //            DataService.DataServiceClient client = new DataServiceClient();
            //            resp = client.Read_Auszahlung_Geplant(out cols,
            //                                                    out is_Ueberzogen, 
            //                                                    AKK_Helper.SessionToken, 
            //                                                    intOldJJ, 
            //                                                    intOldMM, 
            //                                                    txt_darlehensbetrag .Text,
            //                                                    "A");
            //            if (resp.ResponseCode == 0)
            //            {
            //                Int32 int_col_count = cols.Count;
            //                if ( int_col_count > 0 )
            //                { 
            //                    for (int i = 0; i < int_col_count; i++)
            //                    {
            //                        Int32 .TryParse(cols[i].DM_col_01, out int_azg_ikey    ) ;
            //                        double.TryParse(cols[i].DM_col_02, out dbl_azg_geplsum );
            //                        double.TryParse(cols[i].DM_col_03, out dbl_azg_zugsum  );
            //                    }
            //                }
            //                else
            //                { 
            //                    MessageBox .Show ("Kein Budget für diesen Monat gefunden!");
            //                    mtxt_geplante_auszahlung.Focus();
            //                    is_Fehler = true;
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                AKK_Helper.handleServiceError(resp);
            //            }

            //        }  

            //        Int32 intString = 0;
            //        if (( Int32.TryParse (strString , out intString )) == true )
            //        {
            //            Int32 intJJ = 0;
            //            Int32 intMM = 0;
            //            Int32.TryParse(mtxt_geplante_auszahlung.Text.Substring(0, 2), out intJJ);
            //            Int32.TryParse(mtxt_geplante_auszahlung.Text.Substring(3, 2), out intMM);
            //            if (intMM > 12 )
            //            {
            //                MessageBox.Show("Kein gültiger Eintrag!");
            //            }
            //            else
            //            {
            //                Boolean is_Ueberzogen = false;
            //                DC_Columns cols = new DC_Columns();
            //                Response resp = null;
            //                DataService.DataServiceClient client = new DataServiceClient();
            //                resp = client.Read_Auszahlung_Geplant(out cols,
            //                                                        out is_Ueberzogen, 
            //                                                        AKK_Helper.SessionToken, 
            //                                                        intOldJJ, 
            //                                                        intOldMM, 
            //                                                        txt_darlehensbetrag .Text,
            //                                                        "B");
            //                if (resp.ResponseCode == 0)
            //                {
            //                    if ( is_Ueberzogen == true )
            //                    {
            //                        MessageBox.Show("Der zugewiesene Betrag übersteigt das Budget!");
            //                        mtxt_geplante_auszahlung.Focus();
            //                        is_Fehler = true;
            //                        return;
            //                    }
            //                    Int32 int_col_count = cols.Count;
            //                    if ( int_col_count > 0 )
            //                        { 
            //                            for (int i = 0; i < int_col_count; i++)
            //                            {
            //                                Int32 .TryParse(cols[i].DM_col_01, out int_azg_ikey    ) ;
            //                                double.TryParse(cols[i].DM_col_02, out dbl_azg_geplsum );
            //                                double.TryParse(cols[i].DM_col_03, out dbl_azg_zugsum  );
            //                            }
            //                        }
            //                    else
            //                    { 
            //                        MessageBox .Show ("Kein Budget für diesen Monat gefunden!");
            //                        mtxt_geplante_auszahlung.Focus();
            //                        is_Fehler = true;
            //                        return;
            //                    }
            //                }
            //            }
            //        }  
            //    } 
            //    else
            //     {
            //        if ( AKK_Helper.is_empty (strAusGeplOld) == true )
            //        {
            //            Boolean is_Ueberzogen = false;
            //            DC_Columns cols = new DC_Columns();
            //            Response resp = null;
            //            DataService.DataServiceClient client = new DataServiceClient();
            //            resp = client.Read_Auszahlung_Geplant(out cols,
            //                                                    out is_Ueberzogen,
            //                                                    AKK_Helper.SessionToken,
            //                                                    intOldJJ,
            //                                                    intOldMM,
            //                                                    txt_darlehensbetrag.Text,
            //                                                    "A");
            //            if (resp.ResponseCode == 0)
            //            {
            //                Int32 int_col_count = cols.Count;
            //                if (int_col_count > 0)
            //                {
            //                    for (int i = 0; i < int_col_count; i++)
            //                    {
            //                        Int32.TryParse(cols[i].DM_col_01, out int_azg_ikey);
            //                        double.TryParse(cols[i].DM_col_02, out dbl_azg_geplsum);
            //                        double.TryParse(cols[i].DM_col_03, out dbl_azg_zugsum);
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Kein Budget für diesen Monat gefunden!");
            //                    mtxt_geplante_auszahlung.Focus();
            //                    is_Fehler = true;
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                AKK_Helper.handleServiceError(resp);
            //            }
            //        }
            //    }
            //}

            //if ( AKK_Helper .is_empty (mtxt_geplante_auszahlung .Text ) == false )
            //{
            //    strAusGeplOld = mtxt_geplante_auszahlung.Text.Substring(0, 2) + mtxt_geplante_auszahlung.Text.Substring(3, 2);
            //}
            //else
            //{
            //    strAusGeplOld = "";
            //} 

            //label13.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_geplante_auszahlung_TextChanged(object sender, EventArgs e)
        {
            isBankeinzug = true;
        }
        //
        // Geplante Auszahlung NEU
        //
        private void lst_Monat_Leave(object sender, EventArgs e)
        {
            label13.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void lst_Monat_Enter(object sender, EventArgs e)
        {
            label13.ForeColor = AKK_Helper.c_get_focus;
            if (lst_Monat.SelectedIndex <= 0)
            {
                lst_Monat.SelectedIndex = System.DateTime.Now.Month;
            }

        }
        private void lst_Monat_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, lst_Monat);
        }
        private void lst_Monat_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(lst_Monat.SelectedIndex.ToString(), lst_Monat.Text);
        }

        private void lst_Jahr_Leave(object sender, EventArgs e)
        {
            label13.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void lst_Jahr_Enter(object sender, EventArgs e)
        {
            label13.ForeColor = AKK_Helper.c_get_focus;
            if (lst_Jahr.SelectedIndex <= 0)
            {
                // 02-10-2015 by KJ Changed from 16 to 31 ...
                //lst_Jahr.SelectedIndex = 16;
                lst_Jahr.SelectedIndex = 31;
            }
        }
        private void lst_Jahr_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, lst_Jahr);
        }
        private void lst_Jahr_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(lst_Jahr.SelectedIndex.ToString(), lst_Jahr.Text);
        }
        //
        // CMD Speichen
        //
        private void cmd_speichern_Click(object sender, EventArgs e)
        {





            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.Default;
                // only unlock if not already locked at openening form
                if (is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                    this.Close();
                }


                if (onLoad)
                {
                    onLoad = false;
                }

                if (is_Neu == true)
                {
                    // cbo_antragsstatus.SelectedIndex = 0; // IBE
                    mtxt_rueckab_Leave(sender, e);
                    //
                    if ((cbo_antragsstatus.SelectedIndex.ToString() != "4" || cbo_antragsstatus.SelectedIndex.ToString() != "14" ||
                        cbo_antragsstatus.SelectedIndex.ToString() != "2" || cbo_antragsstatus.SelectedIndex.ToString() != "12") &&
                        (!AKK_Helper.is_empty_date(mtxt_rueckab.Text) && !AKK_Helper.is_empty(lst_Monat.Text) && !AKK_Helper.is_empty(lst_Jahr.Text))
                        )
                    {
                        if ((cbo_antragsstatus.SelectedIndex < 0) ||
                                                (cbo_antragsstatus.SelectedValue.ToString() == "-10") ||
                                                (AKK_Helper.is_empty_date(mtxt_eingang_am.Text) == true) ||
                                                (cbo_verwendungszweck.SelectedIndex < 0) ||
                                                (cbo_verwendungszweck.SelectedValue.ToString() == "19") ||
                                                (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true))
                        {
                            AKK_Helper.show_msg("Das Eingangsdatum, der Verwendungszweck, der Status und das Rückzahlungsdatum müssen erfasst sein!", strip_info, this.Cursor);
                            if (AKK_Helper.is_empty_date(mtxt_eingang_am.Text) == true)
                            {
                                mtxt_eingang_am.Focus();
                                mtxt_eingang_am.SelectAll();
                                return;
                            }
                            if ((cbo_antragsstatus.SelectedIndex < 0) ||
                               (cbo_antragsstatus.SelectedValue.ToString() == "-10"))
                            {
                                //cbo_antragsstatus.Focus();
                                return;
                            }

                            if ((cbo_verwendungszweck.SelectedIndex < 0) ||
                                (cbo_verwendungszweck.SelectedValue.ToString() == "19"))
                            {
                                cbo_verwendungszweck.Focus();
                                return;
                            }
                            if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
                            {
                                mtxt_rueckab.Focus();
                                mtxt_rueckab.SelectAll();
                                return;
                            }

                        }
                    }
                    else
                    {
                        //David Stefitz 01.02.2019 auskommentiert
                        //mtxt_rueckab.Text = mtxt_eingang_am.Text;
                        //mtxt_rueckbisvertr.Text = mtxt_eingang_am.Text;
                        //mtxt_rueckbisreal.Text = mtxt_eingang_am.Text;
                        //lst_Monat.SelectedIndex = System.DateTime.Now.Month;
                        //lst_Jahr.SelectedIndex = 31;
                    }

                    //
                    // bis hier alles OK 
                    //
                    //
                    // read generated Auftrags ID - PL/SQL Package
                    //

                    string str_aid = "";
                    string str_darl_nr = "";
                    if (AKK_Helper.checkLogin() == true)
                    {
                        try
                        {
                            this.Cursor = Cursors.Default;

                            //string str_code, Int32 int_col, DataGridView dgv 

                            string str_code = cbo_verwendungszweck.SelectedValue.ToString();
                            string str_verwendungszweck = AKK_Helper.ChangeDGVSel(str_code, 4, dgv_verwendungszweck);
                            string str_vwz_text = AKK_Helper.ChangeDGVSel(str_code, 3, dgv_verwendungszweck);

                            string str_vwz_ikey_neu_c = cbo_verwendungszweck.SelectedValue.ToString();
                            string str_vwz_ikey_c = AKK_Helper.ChangeDGVSel(str_code, 6, dgv_verwendungszweck);
                            string str_ast_text = cbo_antragsstatus.Text;
                            string str_bzs_ikey_c = cbo_bezirksstelle.SelectedValue.ToString();
                            string str_ast_ikey_c = cbo_antragsstatus.SelectedValue.ToString();
                            if (cbo_verwendungszweck.SelectedValue.ToString() == "29")//ish
                            {
                                switch (str_ast_ikey_c)
                                {
                                    case "1":
                                        str_ast_ikey_c = "11";
                                        break;
                                    case "2":
                                        str_ast_ikey_c = "12";
                                        break;
                                    case "3":
                                        str_ast_ikey_c = "13";
                                        break;
                                    case "4":
                                        str_ast_ikey_c = "14";
                                        break;
                                    case "5":
                                        str_ast_ikey_c = "15";
                                        break;
                                    case "6":
                                        str_ast_ikey_c = "16";
                                        break;
                                    case "7":
                                        str_ast_ikey_c = "17";
                                        break;
                                }

                            }
                            // str_ast_ikey_c_return = str_ast_ikey_c;    27-09-2011
                            // str_ast_word_return = cbo_antragsstatus.Text.ToString();  27-09-2011
                            string str_ant_ein = mtxt_eingang_am.Text;
                            string str_wbd_d_betr = AKK_Helper.FormatBetragOhneKomma(txt_darlehensbetrag.Text);
                            string str_klage_am = "";
                            if (AKK_Helper.is_empty_date(mtxt_geklagt_am.Text) == false)
                            {
                                str_klage_am = mtxt_geklagt_am.Text;
                            }

                            Double Dbl_out;
                            Double Dbl_Betrag;
                            Double Dbl_Kontostand;

                            Int32 Int_Laufzeit;
                            Int32.TryParse(mtxt_laufzeit.Text, out Int_Laufzeit);
                            string str_laufzeit = Int_Laufzeit.ToString();

                            Double.TryParse(txt_darlehensbetrag.Text, out Dbl_Betrag);
                            Double.TryParse(txt_aktKontostand.Text, out Dbl_Kontostand);

                            Double.TryParse(txt_rate.Text, out Dbl_out);
                            string str_rate = AKK_Helper.FormatBetrag(Dbl_out.ToString());

                            Double.TryParse(txt_kosten.Text, out Dbl_out);
                            string str_kosten = AKK_Helper.FormatBetrag(Dbl_out.ToString());
                            string str_abl_ikey = "-10";
                            if (cbo_antragsstatus.SelectedValue.ToString() == "2" || cbo_antragsstatus.SelectedValue.ToString() == "12")
                            {
                                str_abl_ikey = cbo_ablehnung.SelectedValue.ToString();
                            }

                            string str_anmerkung = txt_anmerkung.Text;


                            string str_rz_beg = "";
                            string str_rz_bis = "";
                            string str_rz_bis_real = "";

                            if (cbo_verwendungszweck.SelectedValue.ToString() == "29")//ish
                            {
                                if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) &&
                                                                (AKK_Helper.is_date(mtxt_rueckab.Text) == true))
                                {
                                    str_rz_beg = mtxt_rueckab.Text;
                                    str_rz_bis = str_rz_beg;
                                    str_rz_bis_real = str_rz_beg;
                                }
                            }
                            else
                            {
                                if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) &&
                                                                (AKK_Helper.is_date(mtxt_rueckab.Text) == true))
                                {
                                    str_rz_beg = mtxt_rueckab.Text;
                                    if ((Int_Laufzeit != 0) &&
                                        (Dbl_Betrag != 0))
                                    {
                                        str_rz_beg = mtxt_rueckab.Text;

                                        if ((AKK_Helper.is_empty_date(mtxt_rueckbisvertr.Text) == false) &&
                                            (AKK_Helper.is_date(mtxt_rueckbisvertr.Text) == true))
                                        {
                                            str_rz_bis = mtxt_rueckbisvertr.Text;
                                        }

                                        if ((AKK_Helper.is_empty_date(mtxt_rueckbisreal.Text) == false) &&
                                            (AKK_Helper.is_date(mtxt_rueckbisreal.Text) == true))
                                        {
                                            str_rz_bis_real = mtxt_rueckbisreal.Text;
                                        }
                                    }
                                }
                            }

                            string str_ausz_gepl = "__.__";
                            if (AKK_Helper.is_empty_YYMM(mtxt_geplante_auszahlung.Text) == false)
                            {
                                str_ausz_gepl = mtxt_geplante_auszahlung.Text;
                            }


                            string str_klage = "";
                            if (chk_geklagt.Checked == true)
                            {
                                str_klage = "-1";
                            }
                            else
                            {
                                str_klage = "0";
                            }

                            string str_unter = "";
                            if (chk_unterfertigt.Checked == true)
                            {
                                str_unter = "-1";
                            }
                            else
                            {
                                str_unter = "0";
                            }


                            string str_einzug = "";
                            if (chk_Bankeinzug.Checked == true)
                            {
                                str_einzug = "-1";
                            }
                            else
                            {
                                str_einzug = "0";
                            }
                            string str_mahnstufe = "0";           // Mahnstufe ist am Anfang 0
                            string str_kstand = AKK_Helper.FormatBetrag(Dbl_Kontostand.ToString());

                            string str_AntragsIkey = lng_AntragsIkey.ToString();
                            string str_WBDIkey = lng_WBDikey.ToString();


                            //MiRo                      
                            string ibanOut = this.BankInf.IbanOut;
                            string ibanIn = this.BankInf.IbanIn;
                            string ownerOut = this.BankInf.OwnerOut;
                            string ownerIn = this.BankInf.OwnerIn;
                            string coopPartner = this.IsCoopPartner ? "1" : "0";
                            string referenz = this.referenzBox.Text;
                            string straße = this.BankInf.Street;
                            string ort = this.BankInf.Place;


                            string betrag = Regex.Replace(str_wbd_d_betr, @"\s+", "");
                            string rate = Regex.Replace(str_rate, @"\s+", "");

                            this.Cursor = Cursors.WaitCursor;
                            DataService.DataServiceClient client = new DataServiceClient();
                            Addit.AK.WBD.AK_Suche.DataService.Response resp = client.Get_AID(out str_aid,
                                                                                              out str_darl_nr,
                                                                                              AKK_Helper.SessionToken,
                                                                                              AKK_Helper.UserId,
                                                                                              str_verwendungszweck,
                                                                                              str_AntragsIkey,
                                                                                              str_WBDIkey,
                                                                                              str_vwz_ikey_c,
                                                                                              str_vwz_ikey_neu_c,
                                                                                              str_bzs_ikey_c,
                                                                                              str_ast_ikey_c,
                                                                                              str_ant_ein,
                                                                                              betrag,
                                                                                              str_klage_am,
                                                                                              str_laufzeit,
                                                                                              rate,
                                                                                              str_kosten,
                                                                                              str_abl_ikey,
                                                                                              str_anmerkung,
                                                                                              str_rz_beg,
                                                                                              str_rz_bis,
                                                                                              str_rz_bis_real,
                                                                                              str_ausz_gepl,
                                                                                              str_klage,
                                                                                              str_unter,
                                                                                              str_einzug,
                                                                                              str_mahnstufe,
                                                                                              str_kstand,
                                                                                              obj_antrag.DM_std_fkey,
                                                                                              obj_antrag.DM_ant_svnr,
                                                                                              cbo_bildungstraeger.SelectedValue.ToString()
                                                                                              , ibanIn, ownerIn, ibanOut, ownerOut, coopPartner, referenz //MiRo
                                                                                              , straße, ort
                                                                                              );


                            this.Cursor = Cursors.Default;

                            if (resp.ResponseCode == 0)
                            {
                                if ((str_aid == "null") || (str_darl_nr == "null"))
                                {
                                    AKK_Helper.show_msg("Fehler Beim Anlegen des Darlehens im Service Get_AID!", strip_info, this.Cursor);
                                }
                                else
                                {


                                    obj_antrag.DM_ant_eing_dat = str_ant_ein;
                                    obj_antrag.DM_ant_betrag = str_wbd_d_betr;
                                    obj_antrag.DM_vwz_code_c = str_vwz_text;
                                    obj_antrag.DM_ast_typ_c = str_ast_text;
                                    // obj_antrag.DM_ant_status = str_ast_ikey_c;
                                    //
                                    // ab jetzt ist er nicht mehr NEU
                                    //
                                    txt_antrags_id.Text = str_aid;
                                    txt_darlehensnummer.Text = str_darl_nr;

                                    isBankeinzug = false;
                                    is_Neu = false;
                                    is_my_lock = true;    // is locked in DB
                                    is_locked = false;

                                    // URI Error, when no PVS
                                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                                    {
                                        this.Cursor = Cursors.WaitCursor;
                                        string str_where = "";
                                        string str_Type = "";

                                        str_where = " key = '" + obj_person.DM_PVS_ID + "'";

                                        str_Type = obj_person.DM_PVS_ID.Substring(3, 2);
                                        Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                        if (pvs_col.Count > 0)
                                        {
                                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                            {
                                                pvs_do.AddExtRef();
                                            }
                                        }
                                        this.Cursor = Cursors.Default;
                                    }
                                    //
                                    // generate new ANTRAGSOBJECT 
                                    //


                                    DC_ak_suche obj_suche = new DC_ak_suche();
                                    obj_suche.DM_ant_ikey = str_AntragsIkey;   // ant_ID
                                    //
                                    DataService.DataServiceClient client1 = new DataServiceClient();
                                    DC_wbd_antrag obj_wbd_antrag1 = new DC_wbd_antrag();
                                    client1 = new DataServiceClient();

                                    obj_wbd_antrag1 = null;
                                    this.Cursor = Cursors.WaitCursor;
                                    Addit.AK.WBD.AK_Suche.DataService.Response resp1 = client1.Get_Wbd_Antrag(out obj_wbd_antrag1, obj_suche, AKK_Helper.SessionToken);
                                    this.Cursor = Cursors.Default;
                                    if (resp1.ResponseCode == 0)
                                    {
                                        obj_wbd_antrag = obj_wbd_antrag1;  // save new Object for  return value

                                        DC_get_person_antrag cgpa = new DC_get_person_antrag();
                                        obj_suche.DM_ant_ikey = null;
                                        obj_suche.DM_DarlNr = str_darl_nr;   // Darlehensnummer 
                                        resp1 = client1.Get_Person_List(out cgpa, obj_suche, AKK_Helper.SessionToken);
                                        if (resp1.ResponseCode == 0)
                                        {
                                            if (cgpa != null)
                                            {
                                                obj_person = cgpa.obj_lst_ak_person[0];
                                                obj_antrag = cgpa.obj_lst_ak_antraege[0];

                                                if (AKK_Helper.My_user.CanWrite == true)     // 10-12-2012 by KJ
                                                {
                                                    //
                                                    // Set Contorls
                                                    //
                                                    cmd_drucken.Enabled = true;
                                                    if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == false))
                                                    {
                                                        cmd_status_aendern.Enabled = true;  // ok
                                                        cmd_kontenblatt.Enabled = true;
                                                        cmd_mahnstatus.Enabled = true;
                                                        cmd_mitschuldner.Enabled = true;
                                                        cmd_bankverbindung.Enabled = true;
                                                    }
                                                    else
                                                    {
                                                        if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == false))
                                                        {
                                                            cmd_status_aendern.Enabled = true;  // ok
                                                            cmd_kontenblatt.Enabled = true;
                                                            cmd_mahnstatus.Enabled = false;
                                                            cmd_mitschuldner.Enabled = true;
                                                            cmd_bankverbindung.Enabled = true;
                                                        }
                                                        else
                                                        {
                                                            if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
                                                            {
                                                                cmd_status_aendern.Enabled = false;   // ok
                                                                cmd_kontenblatt.Enabled = false;
                                                                cmd_mahnstatus.Enabled = false;
                                                                cmd_mitschuldner.Enabled = true;
                                                                cmd_bankverbindung.Enabled = true;
                                                            }

                                                        }

                                                    }
                                                }

                                                else
                                                {
                                                    cmd_status_aendern.Enabled = false;  // ok
                                                    cmd_kontenblatt.Enabled = false;
                                                    cmd_mahnstatus.Enabled = false;
                                                    cmd_mitschuldner.Enabled = false;
                                                    cmd_bankverbindung.Enabled = false;
                                                    cmd_drucken.Enabled = false;

                                                    if (AKK_Helper.My_user.CanRead == true)     // 10-12-2012 by KJ
                                                    {
                                                        //
                                                        // Set Contorls
                                                        //
                                                        if (AKK_Helper.C.strG_Antrag_Drucken == AKK_Helper.c_Yes) cmd_drucken.Enabled = true;
                                                        if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == false))
                                                        {
                                                            if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = true;  // ok
                                                            if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = true;
                                                            if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = true;
                                                            if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                                            if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                                        }
                                                        else
                                                        {
                                                            if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == false))
                                                            {
                                                                if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = true;  // ok
                                                                if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = true;
                                                                if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = false;
                                                                if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                                                if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                                            }
                                                            else
                                                            {
                                                                if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
                                                                {
                                                                    if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = false;   // ok
                                                                    if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = false;
                                                                    if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = false;
                                                                    if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                                                    if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                                                }

                                                            }

                                                        }
                                                    }
                                                } // 10-12-2012 by KJ


                                                strip_info.Text = "Darlehen " + str_darl_nr + " für " + obj_person.DM_vorname + " " + obj_person.DM_nachname + " wurde erfolgreich angelegt";
                                                is_saved = true;

                                                //Protokollierung Stefitz David 29.08.2018
                                                DataService.DataServiceClient clientProt = new DataServiceClient();
                                                clientProt.Insert_WBD_Protocol(Int32.Parse(AKK_Helper.UserId.ToString()), "INSERT", "WBD_ANTRAG/" + obj_antrag.DM_ant_code_c, obj_wbd_antrag.DM_wbd_ant_id, Int32.Parse(obj_wbd_antrag.DM_ant_ikey), "Status: " + cbo_antragsstatus.Text + ", Auszahlungsbetrag: " + AKK_Helper.FormatBetragOhneKomma(obj_wbd_antrag.DM_wbd_d_betr), AKK_Helper.SessionToken);

                                            }
                                        }
                                        else
                                        {
                                            this.Cursor = Cursors.Default;
                                            AKK_Helper.handleServiceError(resp1);
                                        }

                                    }

                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        AKK_Helper.handleServiceError(resp1);
                                    }
                                } // new ID is NULL
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
                    }
                }
                else  // NICHT neu sondern bereits bestehenden <Speichern>
                {
                    if (AKK_Helper.checkLogin() == true)
                    {
                        if ((cbo_antragsstatus.SelectedIndex < 0) ||
                          (cbo_antragsstatus.SelectedValue.ToString() == "-10") ||
                          (cbo_verwendungszweck.SelectedIndex < 0) ||
                          (cbo_verwendungszweck.SelectedValue.ToString() == "19"))
                        {
                            AKK_Helper.show_msg("Der Verwendungszweck und der Status müssen erfasst sein!", strip_info, this.Cursor);
                            //
                            if ((cbo_antragsstatus.SelectedIndex < 0) ||
                               (cbo_antragsstatus.SelectedValue.ToString() == "-10"))
                            {
                                cbo_antragsstatus.Focus();
                                return;
                            }

                            if ((cbo_verwendungszweck.SelectedIndex < 0) ||
                                (cbo_verwendungszweck.SelectedValue.ToString() == "19"))
                            {
                                cbo_verwendungszweck.Focus();
                                return;
                            }

                        }

                        string str_code = cbo_verwendungszweck.SelectedValue.ToString();
                        string str_vwz_text = AKK_Helper.ChangeDGVSel(str_code, 3, dgv_verwendungszweck);
                        string str_verwendungszweck = AKK_Helper.ChangeDGVSel(str_code, 4, dgv_verwendungszweck);

                        string str_vwz_ikey_neu_c = cbo_verwendungszweck.SelectedValue.ToString();
                        string str_vwz_ikey_c = AKK_Helper.ChangeDGVSel(str_code, 6, dgv_verwendungszweck);
                        string str_bzs_ikey_c = cbo_bezirksstelle.SelectedValue.ToString();
                        string str_ast_ikey_c = cbo_antragsstatus.SelectedValue.ToString();
                        if (cbo_verwendungszweck.SelectedValue.ToString() == "29")//ish
                        {
                            switch (str_ast_ikey_c)
                            {
                                case "1":
                                    str_ast_ikey_c = "11";
                                    break;
                                case "2":
                                    str_ast_ikey_c = "12";
                                    break;
                                case "3":
                                    str_ast_ikey_c = "13";
                                    break;
                                case "4":
                                    str_ast_ikey_c = "14";
                                    break;
                                case "5":
                                    str_ast_ikey_c = "15";
                                    break;
                                case "6":
                                    str_ast_ikey_c = "16";
                                    break;
                                case "7":
                                    str_ast_ikey_c = "17";
                                    break;

                            }
                        }
                        string str_ast_text = cbo_antragsstatus.Text;
                        // str_ast_ikey_c_return = str_ast_ikey_c; 27-09-2011
                        // str_ast_word_return = cbo_antragsstatus.Text.ToString(); 27-09-2011
                        string str_wbd_d_betr = AKK_Helper.FormatBetragOhneKomma(txt_darlehensbetrag.Text);

                        Double Dbl_out;

                        Double Dbl_Betrag;
                        Double.TryParse(txt_darlehensbetrag.Text, out Dbl_Betrag);

                        Int32 Int_Laufzeit;
                        Int32.TryParse(mtxt_laufzeit.Text, out Int_Laufzeit);
                        string str_laufzeit = Int_Laufzeit.ToString();

                        string str_rate = "0";
                        string str_kosten = "0";
                        if ((Dbl_Betrag == 0) || (Int_Laufzeit == 0))
                        {
                        }
                        else
                        {
                            Double.TryParse(txt_rate.Text, out Dbl_out);
                            str_rate = AKK_Helper.FormatBetrag(Dbl_out.ToString());

                            Double.TryParse(txt_kosten.Text, out Dbl_out);
                            str_kosten = AKK_Helper.FormatBetrag(Dbl_out.ToString());

                        }
                        string str_abl_ikey = "";
                        //David Stefitz 04.02.2019
                        if (cbo_ablehnung.SelectedValue != null)
                        {
                            str_abl_ikey = cbo_ablehnung.SelectedValue.ToString();
                        }
                        else
                        {

                            cbo_ablehnung.SelectedValue = "-10";

                        }
                        string str_anmerkung = txt_anmerkung.Text;

                        string str_klage_am = "";
                        if (AKK_Helper.is_empty_date(mtxt_geklagt_am.Text) == false)
                        {
                            str_klage_am = mtxt_geklagt_am.Text;
                        }
                        //
                        string str_rz_beg = "";
                        string str_rz_bis = "";
                        string str_rz_bis_real = "";

                        if (cbo_verwendungszweck.SelectedValue.ToString() == "29")//ish
                        {
                            //David Stefitz 04.02.2019
                            //str_rz_beg = mtxt_rueckab.Text;
                            //str_rz_bis = mtxt_rueckbisvertr.Text; //str_rz_beg;
                            //str_rz_bis_real = mtxt_rueckbisreal.Text; //str_rz_beg;
                            if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) &&
                           (AKK_Helper.is_date(mtxt_rueckab.Text) == true))
                            {
                                str_rz_beg = mtxt_rueckab.Text;
                                if ((AKK_Helper.is_empty_date(mtxt_rueckbisvertr.Text) == false) &&
                                    (AKK_Helper.is_date(mtxt_rueckbisvertr.Text) == true))
                                {
                                    str_rz_bis = mtxt_rueckbisvertr.Text;
                                }
                                if ((AKK_Helper.is_empty_date(mtxt_rueckbisreal.Text) == false) &&
                                    (AKK_Helper.is_date(mtxt_rueckbisreal.Text) == true))
                                {
                                    str_rz_bis_real = mtxt_rueckbisreal.Text;
                                }
                            }
                        }
                        else
                        {
                            if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) &&
                            (AKK_Helper.is_date(mtxt_rueckab.Text) == true))
                            {
                                str_rz_beg = mtxt_rueckab.Text;
                                if ((AKK_Helper.is_empty_date(mtxt_rueckbisvertr.Text) == false) &&
                                    (AKK_Helper.is_date(mtxt_rueckbisvertr.Text) == true))
                                {
                                    str_rz_bis = mtxt_rueckbisvertr.Text;
                                }
                                if ((AKK_Helper.is_empty_date(mtxt_rueckbisreal.Text) == false) &&
                                    (AKK_Helper.is_date(mtxt_rueckbisreal.Text) == true))
                                {
                                    str_rz_bis_real = mtxt_rueckbisreal.Text;
                                }
                            }
                        }


                        //
                        string str_ausz_gepl = "__.__";
                        if (AKK_Helper.is_empty_YYMM(mtxt_geplante_auszahlung.Text) == false)
                        {
                            str_ausz_gepl = mtxt_geplante_auszahlung.Text;
                        }
                        //
                        string str_klage = "";
                        if (chk_geklagt.Checked == true)
                        {
                            str_klage = "-1";
                        }
                        else
                        {
                            str_klage = "0";
                        }
                        //
                        string str_unter = "";
                        if (chk_unterfertigt.Checked == true)
                        {
                            str_unter = "-1";
                        }
                        else
                        {
                            str_unter = "0";
                        }
                        //
                        string str_einzug = "";
                        if (chk_Bankeinzug.Checked == true)
                        {
                            str_einzug = "-1";
                        }
                        else
                        {
                            str_einzug = "0";
                        }
                        //
                        string str_scheidung = "N";
                        if (chk_scheidung.Checked == true)
                        {
                            str_scheidung = "J";
                            txt_antragsteller.ForeColor = Color.Red;
                        }
                        else
                        {
                            str_scheidung = "N";
                            txt_antragsteller.ForeColor = Color.Black;
                        }

                        this.Cursor = Cursors.WaitCursor;

                        //David Stefitz 16.07.2019 Null Reference Exception beim Speichern
                        string bt = "";
                        if (cbo_bildungstraeger.SelectedValue == null)
                        {
                            bt = "0";
                        }
                        else
                        {
                            bt = cbo_bildungstraeger.SelectedValue.ToString();
                        }

                        //MiRo
                        string ibanOut = this.BankInf.IbanOut;
                        string ibanIn = this.BankInf.IbanIn;
                        string ownerOut = this.BankInf.OwnerOut;
                        string ownerIn = this.BankInf.OwnerIn;
                        string coopPartner = (this.IsCoopPartner ? "1" : "0");
                        string referenz = referenzBox.Text;
                        string straße = this.BankInf.Street;
                        string ort = this.BankInf.Place;



                        string betrag = Regex.Replace(str_wbd_d_betr, @"\s+", "");
                        string rate = Regex.Replace(str_rate, @"\s+", "");


                        DataService.DataServiceClient client = new DataServiceClient();
                        Addit.AK.WBD.AK_Suche.DataService.Response resp = client.Update_Antrag(AKK_Helper.SessionToken,
                                                                                                AKK_Helper.UserId,
                                                                                                obj_wbd_antrag.DM_ant_ikey,
                                                                                                obj_wbd_antrag.DM_wbd_ikey,
                                                                                                str_vwz_ikey_c,
                                                                                                str_vwz_ikey_neu_c,
                                                                                                str_bzs_ikey_c,
                                                                                                str_ast_ikey_c,
                                                                                                betrag,
                                                                                                str_laufzeit,
                                                                                                rate,
                                                                                                str_kosten,
                                                                                                str_abl_ikey,
                                                                                                str_anmerkung,
                                                                                                str_klage_am,
                                                                                                str_rz_beg,
                                                                                                str_rz_bis,
                                                                                                str_rz_bis_real,
                                                                                                str_ausz_gepl,
                                                                                                str_klage,
                                                                                                str_unter,
                                                                                                str_einzug,
                                                                                                str_scheidung,
                                                                                                bt,
                                                                                                         ibanIn,
                     ownerIn,
                     ibanOut,
                     ownerOut,
                     coopPartner,
                     referenz,
                     straße,
                     ort);


                        this.Cursor = Cursors.Default;
                        obj_antrag.DM_wbd_ueber_fkey = obj_wbd_antrag.DM_wbd_ueber_fkey;

                        if (resp.ResponseCode == 0)
                        {
                            //Miro
                            obj_wbd_antrag.DM_wbd_ibanIn = ibanIn;
                            obj_wbd_antrag.DM_wbd_ownerIn = ownerIn;
                            obj_wbd_antrag.DM_wbd_ibanOut = ibanOut;
                            obj_wbd_antrag.DM_wbd_ownerOut = ownerOut;
                            obj_wbd_antrag.DM_wbd_strasse = straße;
                            obj_wbd_antrag.DM_wbd_ort = ort;
                            obj_wbd_antrag.DM_wbd_referenz = referenz;
                            obj_wbd_antrag.DM_wbd_coopPartner = coopPartner;





                            obj_antrag.DM_ant_betrag = str_wbd_d_betr;
                            obj_antrag.DM_vwz_code_c = str_vwz_text;
                            obj_antrag.DM_ast_typ_c = str_ast_text;
                            // obj_antrag.DM_ant_status = str_ast_ikey_c;
                            //
                            // folgende CMDs werden nur benötigt nachdem der Antrag angelegt wurde
                            if (AKK_Helper.My_user.CanWrite == true)    // 10-12-2012 by KJ
                            {
                                cmd_drucken.Enabled = true;
                                if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == false))
                                {
                                    cmd_kontenblatt.Enabled = true;
                                    cmd_mahnstatus.Enabled = true;
                                    cmd_mitschuldner.Enabled = true;
                                    cmd_bankverbindung.Enabled = true;
                                    cbo_antragsstatus.Enabled = true;
                                }
                                else
                                {
                                    if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == true))
                                    {
                                        cmd_status_aendern.Enabled = false;  // ok
                                        cmd_kontenblatt.Enabled = true;
                                        cmd_mahnstatus.Enabled = false;
                                        cmd_mitschuldner.Enabled = true;
                                        cmd_bankverbindung.Enabled = true;
                                    }
                                    else
                                    {
                                        if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
                                        {
                                            cmd_kontenblatt.Enabled = false;
                                            cmd_mahnstatus.Enabled = false;
                                            cmd_mitschuldner.Enabled = true;
                                            cmd_bankverbindung.Enabled = true;
                                        }
                                    }

                                }
                            }

                            else
                            {
                                cmd_kontenblatt.Enabled = false;
                                cmd_mahnstatus.Enabled = false;
                                cmd_mitschuldner.Enabled = false;
                                cmd_bankverbindung.Enabled = false;
                                cbo_antragsstatus.Enabled = false;
                                cmd_drucken.Enabled = false;

                                if (AKK_Helper.My_user.CanRead == true)
                                {
                                    if (AKK_Helper.C.strG_Antrag_Drucken == AKK_Helper.c_Yes) cmd_drucken.Enabled = true;
                                    //
                                    if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == false))
                                    {
                                        if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = true;
                                        if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = true;
                                        if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                        if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                        cbo_antragsstatus.Enabled = true;
                                    }
                                    else
                                    {
                                        if ((AKK_Helper.is_empty_date(mtxt_rueckab.Text) == false) && (chk_geklagt.Checked == true))
                                        {
                                            if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = false;  // ok
                                            if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = true;
                                            if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = false;
                                            if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                            if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                        }
                                        else
                                        {
                                            if (AKK_Helper.is_empty_date(mtxt_rueckab.Text) == true)
                                            {
                                                if (AKK_Helper.C.strG_Antrag_Kontenblatt == AKK_Helper.c_Yes) cmd_kontenblatt.Enabled = false;
                                                if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = false;
                                                if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                                                if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                                            }
                                        }
                                    }
                                }
                            }    // 10-12-2012 by KJ



                            //Write Nachzahlungsbetrag, can only be added in existing Antrag

                            var nachzahlungsbetragString = nachzahlungsBetragTextBox.Text;

                            if (String.IsNullOrWhiteSpace(nachzahlungsbetragString))
                            {
                                nachzahlungsbetragString = "0";
                            }

                            var nachzahlungsbetrag = Double.Parse(nachzahlungsbetragString);
                            var nachzahlungsdatum = nachzahlungsDatumTextBox.Text;

                            if (nachzahlungsbetrag > 0 && String.IsNullOrEmpty(nachzahlungsdatum)) //Only update it if it has not been payed out yet.
                            {

                                var gesamtdarlehensbetrag = nachzahlungsbetrag + Double.Parse(obj_wbd_antrag.DM_wbd_d_betr);
                                int laufzeit = (int)(gesamtdarlehensbetrag / Int32.Parse(obj_wbd_antrag.DM_wbd_rate));

                                var rueckzahlungbisVertraglich = AKK_Helper.Calc_AddMonths(Double.Parse(obj_wbd_antrag.DM_wbd_kosten),
                                                                            Double.Parse(obj_wbd_antrag.DM_wbd_rate),
                                                                            laufzeit,
                                                                            obj_wbd_antrag.DM_wbd_rz_beg);


                                resp = client.Get_DLEnd_Reals(out string rueckzahlungbisReal,
                                                AKK_Helper.SessionToken,
                                                 obj_wbd_antrag.DM_wbd_rz_beg,
                                                rueckzahlungbisVertraglich,
                                                 laufzeit,
                                                 Double.Parse(obj_wbd_antrag.DM_wbd_rate),
                                                  Double.Parse(obj_wbd_antrag.DM_wbd_kosten),
                                                 obj_wbd_antrag.DM_wbd_ikey);

                                if (resp.ResponseCode != 0)
                                {
                                    AKK_Helper.handleServiceError(resp);
                                    return;
                                }

                                var rueckzahlungbisVertraglichDT = DateTime.Parse(rueckzahlungbisVertraglich);
                                var rueckzahlungbisRealDT = DateTime.Parse(rueckzahlungbisReal);

                                resp = client.CreateNachzahlungTemp(obj_wbd_antrag.DM_wbd_ant_id, nachzahlungsbetrag, gesamtdarlehensbetrag, rueckzahlungbisVertraglichDT, rueckzahlungbisRealDT, laufzeit);

                                if (resp.ResponseCode != 0)
                                {
                                    AKK_Helper.handleServiceError(resp);
                                    return;
                                }

                                AKK_Helper.show_msg($"Zusätzlicher Betrag: {nachzahlungsbetrag} wurde gespeichert! Änderungen werden erst nach Buchen sichtbar. \n Betrag kann bis dahin noch geändert werden.", strip_info, this.Cursor);
                            }

                            //
                            // Es gibt jetzt keine Änderungen
                            //
                            isBankeinzug = false;
                            //
                            strip_info.Text = "Darlehen " + obj_wbd_antrag.DM_wbd_darl_nr + " für " + obj_person.DM_vorname + " " + obj_person.DM_nachname + " wurde erfolgreich gespeichert";
                            is_saved = true;

                            //Protokollierung Stefitz David 29.08.2018
                            DataService.DataServiceClient clientProt = new DataServiceClient();
                            clientProt.Insert_WBD_Protocol(Int32.Parse(AKK_Helper.UserId.ToString()), "UPDATE", "WBD_ANTRAG/" + obj_antrag.DM_ant_code_c, obj_wbd_antrag.DM_wbd_ant_id, Int32.Parse(obj_wbd_antrag.DM_ant_ikey), "Status: " + cbo_antragsstatus.Text + ", Auszahlungsbetrag: " + AKK_Helper.FormatBetragOhneKomma(obj_wbd_antrag.DM_wbd_d_betr), AKK_Helper.SessionToken);

                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                    }

                }
                // Bank, Bankeinzug und Mitschuldner sind erst nach Speichern verfügbar
                if (!cmd_bankverbindung.Enabled)
                {
                    cmd_bankverbindung.Enabled = true;
                    this.IsCoopPartner = this.IsCoopPartner;
                }
                if (!cmd_mitschuldner.Enabled)
                {
                    cmd_mitschuldner.Enabled = true;
                }
                if (!chk_Bankeinzug.Enabled)
                {
                    chk_Bankeinzug.Enabled = true;
                }
            }
        }
        private void set_aus_gepl(object sender, EventArgs e)
        {
            isBankeinzug = true;
            if ((lst_Jahr.Items.Count > 0) && (lst_Monat.Items.Count > 0))
            {
                string str_jar = "__";
                string str_mon = "__";
                if (lst_Monat.SelectedValue != null)
                {
                    str_mon = lst_Monat.SelectedValue.ToString().Trim();

                    if (str_mon == "0")
                    {
                        str_mon = "  ";
                    }
                    else
                    {
                        if (str_mon.Length == 1)
                        {
                            str_mon = "0" + str_mon;
                        }
                    }
                }
                if (lst_Jahr.SelectedValue != null)
                {
                    str_jar = lst_Jahr.SelectedValue.ToString().Trim();
                    if (str_jar == "0")
                    {
                        str_jar = "  ";
                    }
                    else
                    {
                        str_jar = lst_Jahr.Text.ToString().Substring(2, 2);
                    }
                }
                else
                {

                }
                mtxt_geplante_auszahlung.Text = str_jar + "." + str_mon;
            }

        }

        private void cmd_mahnstatus_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                isBankeinzug = true;
                frm_Mahnstatus frm_mahnstatus = new frm_Mahnstatus();
                frm_mahnstatus.str_wbd_ikey = obj_wbd_antrag.DM_wbd_ikey;
                frm_mahnstatus.str_mahnstufe = mtxt_mahnstufe.Text;

                frm_mahnstatus.ShowDialog();
                mtxt_mahnstufe.Text = frm_mahnstatus.str_mahnstufe;

                frm_mahnstatus = null;
            }
        }
        private void cmd_kontenblatt_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Double dbl_D_Betr = 0;
                Double.TryParse(txt_darlehensbetrag.Text, out dbl_D_Betr);

                Double dbl_Tilg_Stand = 0;
                Double.TryParse(txt_tilg_stand.Text, out dbl_Tilg_Stand);

    
                isBankeinzug = true;
                frm_Konto frm_konto = new frm_Konto();
                frm_konto.str_antragsteller = txt_antragsteller.Text;
                frm_konto.str_darlehensnr = txt_darlehensnummer.Text;
                frm_konto.str_d_betr = txt_darlehensbetrag.Text;
                frm_konto.str_anzahl = mtxt_laufzeit.Text;
                frm_konto.str_rate = txt_rate.Text;
                frm_konto.str_rueck_ab = mtxt_rueckab.Text;
                frm_konto.str_rueck_bis_real = mtxt_rueckbisreal.Text;
                frm_konto.str_rueck_bis_vertr = mtxt_rueckbisreal.Text;
                frm_konto.str_WBDIkey = obj_wbd_antrag.DM_wbd_ikey;
                frm_konto.AntId = this.AntId;
                frm_konto.str_konto_real = txt_aktKontostand.Text;
                frm_konto.antrag = this.obj_wbd_antrag;
                //David Stefitz 05.02.2019 Änderung bei ISH
                if (cbo_verwendungszweck.SelectedValue.ToString() == "29")//ish
                {
                    frm_konto.bool_ish = true;
                }
                else
                {

                    frm_konto.bool_ish = false;

                }

                if (AKK_Helper.is_empty_date(mtxt_auszahlung_am.Text) == false)
                {
                    frm_konto.str_konto_vert = (dbl_D_Betr * (-1) + dbl_Tilg_Stand).ToString();
                }
                else
                {
                    frm_konto.str_konto_vert = txt_tilg_stand.Text;
                }

                frm_konto.ShowDialog();
                // aktuellen Kontostand setzten und doublen
                txt_aktKontostand.Text = AKK_Helper.FormatBetragPlus(frm_konto.str_konto_real);
                Double dbl_Konto = 0;
                Double.TryParse(txt_aktKontostand.Text, out dbl_Konto);


                double dbl_sum = AKK_Helper.Calc_Diff(mtxt_auszahlung_am.Text,
                                                      mtxt_rueckab.Text,
                                                      dbl_D_Betr,
                                                      dbl_Tilg_Stand,
                                                      dbl_Konto);
                //David Stefitz 05.02.2019 Änderung von > auf < als weil das Konto Negativ angegeben wird!
                //David Stefitz 16.07.2019 Wieder auf > geändert war ein Denkfehler
                if (dbl_Konto > 0)
                {
                    txt_Dif.Text = AKK_Helper.FormatBetragPlus("0");
                }
                else
                {
                    txt_Dif.Text = AKK_Helper.FormatBetragPlus(dbl_sum.ToString());
                }

                frm_konto = null;


                DC_wbd_antrag obj_Wbd_Antrag = new DC_wbd_antrag();
                DataService.DataServiceClient client = new DataServiceClient();
                DC_ak_suche obj_suche = new DC_ak_suche();
                obj_suche.DM_ant_ikey = this.obj_wbd_antrag.DM_ant_ikey;
                DataService.Response resp = client.Get_Wbd_Antrag(out obj_Wbd_Antrag, obj_suche, AKK_Helper.SessionToken);
                this.obj_wbd_antrag = obj_Wbd_Antrag;

                this.frm_wbd_antrag_Load(null, null);
             

            }

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbo_bezirksstelle_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_bezirksstelle);
        }

        private void cbo_bezirksstelle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_bezirksstelle.SelectedIndex.ToString(), cbo_bezirksstelle.Text);
        }

        private void set_fields()
        {
            //
            //
            // Änderungen 11-07-2011 lt Info Frau Schmautz
            //            18-07-2011 lt Info Frau Schmautz
            //
            if ((cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_IB) ||
                (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_UG) ||
                (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_NG) ||
                (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_IB) ||
                (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_UG) ||
                (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_NG))
            {
                set_IbUgNg();
            }
            else
            {
                if (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_PO || cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_PO)
                {
                    set_po();
                }
                else
                {
                    if ((cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_UZ) ||
                        (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_TL) ||
                        (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_UZ) ||
                        (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_TL))
                    {
                        set_UzTi();
                    }
                    else
                    {
                        if (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_VZ ||
                            cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_VZ)
                        {
                            set_VZ();
                        }
                    }
                }
            }
            if (is_locked == true)
            {
                mtxt_eingang_am.Enabled = false;
                cmd_speichern.Enabled = false;
                // 12-05-2011 by KJ
                cmd_status_aendern.Enabled = false;    // ok
                cmd_kontenblatt.Enabled = false;
                cmd_mahnstatus.Enabled = false;
            }
            //
            // 30-08-2011 Anfrage Fr. Kerth
            //
            if (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_NG ||
                cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_NG)
            {
                cbo_ablehnung.Enabled = true;
                lbl_ablehnung.Enabled = true;
            }
            else
            {
                cbo_ablehnung.Enabled = false;
                lbl_ablehnung.Enabled = false;
                cbo_ablehnung.SelectedValue = "-10";
            }

        }

        private void set_VZ()   // Verzicht
        {
            cbo_verwendungszweck.Enabled = false;
            cbo_bildungstraeger.Enabled = false;
            txt_darlehensbetrag.Enabled = false;
            mtxt_laufzeit.Enabled = false;
            cbo_antragsstatus.Enabled = false;
            cbo_ablehnung.Enabled = false;
            lbl_ablehnung.Enabled = false;
            cbo_bezirksstelle.Enabled = false;
            lst_Monat.Enabled = false;
            lst_Jahr.Enabled = false;
            chk_Bankeinzug.Enabled = false;
            mtxt_rueckab.Enabled = false;
            txt_rate.Enabled = false;
            chk_scheidung.Enabled = false;
            mtxt_mahnstufe.Enabled = false;
            txt_laufzeitstatus.Enabled = false;
            chk_geklagt.Enabled = false;
            chk_scheidung.Enabled = false;
            txt_Dif.Enabled = false;
            mtxt_eingang_am.Enabled = false;
            chk_unterfertigt.Enabled = false;

            cmd_bankverbindung.Enabled = false;
            cmd_mitschuldner.Enabled = false;
            cmd_mahnstatus.Enabled = false;
            cmd_status_aendern.Enabled = false;

        }

        private void set_IbUgNg()   // InBearbeitung Urgenz Negativ
        {
            chk_scheidung.Enabled = false;
            txt_Dif.Enabled = false;
            if (!is_Neu)
            {
                mtxt_eingang_am.Enabled = false;
            }
            chk_unterfertigt.Enabled = false;

            cbo_verwendungszweck.Enabled = true;
            if (cbo_verwendungszweck.SelectedValue.ToString() == "20" || cbo_verwendungszweck.SelectedValue.ToString() == "29")
            {
                cbo_bildungstraeger.Enabled = true;
            }
            else
            {
                cbo_bildungstraeger.Enabled = false;
            }
            txt_darlehensbetrag.Enabled = true;
            if (cbo_verwendungszweck.SelectedValue.ToString() == "29")
            {
                mtxt_laufzeit.Enabled = false;
            }
            else
            {
                mtxt_laufzeit.Enabled = true;
            }

            cbo_antragsstatus.Enabled = true;
            cbo_ablehnung.Enabled = true;
            lbl_ablehnung.Enabled = true;
            cbo_bezirksstelle.Enabled = true;
            lst_Monat.Enabled = true;
            lst_Jahr.Enabled = true;
            chk_Bankeinzug.Enabled = true;
            mtxt_rueckab.Enabled = true;
            txt_rate.Enabled = false;
            chk_scheidung.Enabled = false;
            mtxt_mahnstufe.Enabled = false;
            txt_laufzeitstatus.Enabled = false;
            chk_geklagt.Enabled = false;
            if (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_NG || cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_NG)
            {
                cbo_ablehnung.Enabled = true;    // 15-07-2011
            }
            if ((cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SWBD_IB) || (cbo_antragsstatus.SelectedValue.ToString() == AKK_Helper.C.strG_SISH_IB))
            {
                //cbo_antragsstatus.Focus();
                //cbo_antragsstatus.Select();
            }
            // 10-12-2012 by KJ
            if (AKK_Helper.My_user.CanWrite == true)
            {
                //cmd_bankverbindung.Enabled = true;
                //cmd_mitschuldner.Enabled = true;
                cmd_mahnstatus.Enabled = false;
                cmd_status_aendern.Enabled = false;
            }
            else
            {
                //cmd_bankverbindung.Enabled = false;
                //cmd_mitschuldner.Enabled = false;
                cmd_mahnstatus.Enabled = false;
                cmd_status_aendern.Enabled = false;

                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = false;
                    if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = false;
                }
            }

        }

        private void set_po()   // Positiv
        {
            chk_scheidung.Enabled = false;
            txt_Dif.Enabled = false;
            mtxt_eingang_am.Enabled = false;
            chk_unterfertigt.Enabled = false;
            cbo_verwendungszweck.Enabled = false;
            cbo_bildungstraeger.Enabled = false;
            txt_darlehensbetrag.Enabled = false;
            txt_rate.Enabled = false;
            mtxt_laufzeit.Enabled = false;
            txt_laufzeitstatus.Enabled = false;
            cbo_ablehnung.Enabled = false;
            lbl_ablehnung.Enabled = false;
            cbo_bezirksstelle.Enabled = false;
            lst_Monat.Enabled = false;
            lst_Jahr.Enabled = false;
            mtxt_rueckab.Enabled = false;
            cbo_antragsstatus.Enabled = false; // 15-07-2011
            chk_scheidung.Enabled = true;
            mtxt_mahnstufe.Enabled = true;
            chk_Bankeinzug.Enabled = true;
            chk_geklagt.Enabled = true;
            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_status_aendern.Enabled = true;
                cmd_mitschuldner.Enabled = false;
                cmd_mahnstatus.Enabled = true;
                cmd_bankverbindung.Enabled = true;
            }
            else
            {
                cmd_status_aendern.Enabled = false;
                cmd_mitschuldner.Enabled = false;
                cmd_mahnstatus.Enabled = false;
                cmd_bankverbindung.Enabled = false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = false;
                    if (AKK_Helper.C.strG_Antrag_Mahnstatus == AKK_Helper.c_Yes) cmd_mahnstatus.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                }
            }   // 12-10-2012 by KJ


        }


        private void set_UzTi()   // Überzahlung Tilgung
        {
            chk_scheidung.Enabled = false;
            txt_Dif.Enabled = false;
            mtxt_eingang_am.Enabled = false;

            chk_unterfertigt.Enabled = false;
            cbo_verwendungszweck.Enabled = false;
            cbo_bildungstraeger.Enabled = false;
            txt_darlehensbetrag.Enabled = false;
            txt_rate.Enabled = false;
            mtxt_laufzeit.Enabled = false;
            txt_laufzeitstatus.Enabled = false;
            cbo_antragsstatus.Enabled = false;
            cbo_ablehnung.Enabled = false;
            lbl_ablehnung.Enabled = false;
            cbo_bezirksstelle.Enabled = false;
            chk_scheidung.Enabled = false;
            lst_Monat.Enabled = false;
            lst_Jahr.Enabled = false;
            mtxt_mahnstufe.Enabled = false;
            chk_Bankeinzug.Enabled = true;
            txt_laufzeitstatus.Enabled = false;
            mtxt_rueckab.Enabled = false;
            chk_geklagt.Enabled = false;

            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_status_aendern.Enabled = false;
                cmd_bankverbindung.Enabled = true;
                cmd_mitschuldner.Enabled = false;
            }
            else
            {
                cmd_status_aendern.Enabled = false;
                cmd_bankverbindung.Enabled = false;
                cmd_mitschuldner.Enabled = false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Antrag_Status_ändern == AKK_Helper.c_Yes) cmd_status_aendern.Enabled = false;
                    if (AKK_Helper.C.strG_Antrag_Bankverbindung == AKK_Helper.c_Yes) cmd_bankverbindung.Enabled = true;
                    if (AKK_Helper.C.strG_Antrag_Mitschuldner == AKK_Helper.c_Yes) cmd_mitschuldner.Enabled = false;
                }
            }
        }

        private void mtxt_eingang_am_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void chkBKoordinationspartner_CheckedChanged(object sender, EventArgs e)
        {
            IsCoopPartner = chkBKoordinationspartner.Checked ? true : false;
            //  cmd_bankverbindung.Enabled = IsCoopPartner;
        }

        private void mtxt_verstaendigt_am_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void referenzBox_TextChanged(object sender, EventArgs e)
        {

            this.referenceChanged = true;

        }

        private void referenzBox_Leave(object sender, EventArgs e)
        {
            this.Referenz = (sender as TextBox).Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void mtxt_auszahlung_am_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }  // Class

}   // Namspace





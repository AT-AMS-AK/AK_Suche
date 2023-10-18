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
using Addit.AK.WBD.AK_Suche.DocumentGeneration;
using Miracle.MPP.WebPCI;
using System.Configuration;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Einzeldruck : Form
    {
        public String str_Status { set; get; }
        public String str_ablehnung { set; get; }
        public String str_AntIkey { set; get; }
        public String str_urgenz_am { set; get; }
        public String str_genehmigt_am { set; get; }
        public String str_verstaendigt_am { set; get; }
        public String str_tilgung_am { set; get; }
        public Boolean ish { set; get; }


        public frm_Einzeldruck()
        {
            InitializeComponent();
        }
        #region strip
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
        private void frm_Einzeldruck_Activated(object sender, EventArgs e)
        {
           AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
        }
        private void frm_Einzeldruck_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }      
        #endregion
        private void chk_sort_Enter(object sender, EventArgs e)
        {
            chk_sort.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_sort_Leave(object sender, EventArgs e)
        {
            chk_sort.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_Vorlage_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_Vorlage_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_Einzeldruck_Load(object sender, EventArgs e)
        {
            mtxt_ConfirmationPrintDate.Mask = @"00\.00\.0000";

            AKK_Helper.Templates = ConfigurationManager.AppSettings["TemplatesConfirmationPrinting"].Split(':').ToList();

            this.Size = new System.Drawing.Size(this.Size.Width, 233);
            cmd_Druck.Location = new System.Drawing.Point(cmd_Druck.Location.X, 112);
            cmd_schliessen.Location = new System.Drawing.Point(cmd_schliessen.Location.X, 112);
            grp_Einzeldruck.Size = new System.Drawing.Size(grp_Einzeldruck.Size.Width, 151);
            grp_bestätigungstermin.Visible = false;

            mtxt_ConfirmationPrintDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
            mtxt_ConfirmationStartTime.Text = ConfigurationManager.AppSettings["StartTimeOfConfirmationPrinting"];
            
            AKK_Helper.FindControls(this);

            dgv_Status.Visible   = false;
            dgv_Vorlage.Visible  = false;
            txt_Output.Visible   = false;
            cmd_Sichtbar.Visible = false;
            fill_Listboxen();
            Int32 xxx = dgv_Status.RowCount;
            // string xx1 = dgv_Status[1, 9].Value.ToString()     ;
            /*if (ish)
            {
                AKK_Helper.ChangeBoxSel(cbo_Status, str_Status, 11, dgv_Status);
                AKK_Helper.ChangeBoxSel(cbo_Vorlage, str_ablehnung, 13, dgv_Vorlage);
            }
            else
            {
                AKK_Helper.ChangeBoxSel(cbo_Status, str_Status, 1, dgv_Status);
                AKK_Helper.ChangeBoxSel(cbo_Vorlage, str_ablehnung, 3, dgv_Vorlage);
            }*/

            AKK_Helper.ChangeBoxSel(cbo_Status, str_Status, 1, dgv_Status);
            AKK_Helper.ChangeBoxSel(cbo_Vorlage, str_ablehnung, 3, dgv_Vorlage);


        }
        private void cmd_Druck_Click(object sender, EventArgs e)
        {

            if (AKK_Helper.checkLogin() == true)
            {
                string startDatum = string.Empty;
                string startZeit = string.Empty;
                string startDauer = "00";
                if (mtxt_ConfirmationPrintDate.Text != "__.__.____")
                {
                    startDatum = string.Format("{0:00}{1:00}{2:0000}", Int32.Parse(mtxt_ConfirmationPrintDate.Text.Substring(0, 2)),
                                                                       Int32.Parse(mtxt_ConfirmationPrintDate.Text.Substring(3, 2)),
                                                                       Int32.Parse(mtxt_ConfirmationPrintDate.Text.Substring(6, 4)));
                }
                if (mtxt_ConfirmationStartTime.Text != ":")
                {
                    startZeit = string.Format("{0:00}{1:00}", Int32.Parse(mtxt_ConfirmationStartTime.Text.Substring(0, 2)),
                                                              Int32.Parse(mtxt_ConfirmationStartTime.Text.Substring(3, 2)));
                }

                Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
                DataService.DataServiceClient client = new DataServiceClient();
                resp = client.WriteDB_Serientermin(
                              AKK_Helper.SessionToken,
                              startDatum,
                              startZeit,
                              startDauer);

                if (resp.ResponseCode != 0)
                {
                    AKK_Helper.show_msg("Fehler beim Schreiben der Serientermine", strip_info, this.Cursor);
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                //
                // 23-02-2016 by KJ
                //




                this.Cursor = Cursors.WaitCursor;
                cmd_Druck.Enabled = false;
                cmd_schliessen.Enabled = false;

                string str_Drucker = AKK_Helper.my_printer;
                string str_User = AKK_Helper.UserId;
                string str_Bereich = AKK_Helper.C.strBereichKey;     // 2 für WBD, 18 für ISH
                string str_Bezirk = "-1";                             // nicht relevant für Einzeldruck
                // string str_Status = str_Status;                    // Public Property vom frm_Einzeldruck
                string str_Template = "-1";
                string str_Ablehnung = "-1";
                string str_Sort = null;
                string str_Datumvon = "0";
                string str_Datumbis = "0";
                // string str_AntIkey = str_AntIkey;                  // Public Property vom frm_Einzeldruck  

                AKK_Helper.ChangeBoxSel(cbo_Vorlage, cbo_Vorlage.SelectedValue.ToString(), 1, dgv_Vorlage);
                str_Template = AKK_Helper.ChangeDGVSel(cbo_Vorlage.SelectedValue.ToString(), 2, dgv_Vorlage);       // PRV_Ikey_C     --> 1
                string str_Code = AKK_Helper.ChangeDGVSel(cbo_Vorlage.SelectedValue.ToString(), 3, dgv_Vorlage).Trim();   // PRV_Code_C     --> 01
                str_Ablehnung = AKK_Helper.ChangeDGVSel(cbo_Vorlage.SelectedValue.ToString(), 4, dgv_Vorlage);     // PRV_CONTROL_C Ablehnungsgrund
                // Sortierung
                if (chk_sort.Checked == true)
                    str_Sort = "0";
                else
                    str_Sort = "1";

                do_Print(str_Drucker, str_User, str_Bereich, str_Bezirk, str_Status, str_Template,
                           str_Ablehnung, str_Sort, str_Datumvon, str_Datumbis, str_AntIkey, -1);

                //  Drucker		         ( aus wbd_setting )
                //  User		2	     ( aus wbd_user )
                //  Bereich		2        ( akf_antragstyp_c )
                //  Bezirk		-1       ( akf_bezirksstellen_c )
                //  Status		3	     ( wbd_antragsstatus_c )
                //  Template	05	     ( wbd_printvorlage_c )
                //  Ablehnungsgrund ""	 ( 5 von wbd_printvorlage_c – prv_control )
                //  Sortierung	1 	     ( 0 AntrasgID )
                //                       ( 1 Name )
                //  DatumVon	0	     im Format ddmmyyyy
                //  DatumBis	0	     im Format ddmmyyyy
                //  Ant_Ikey 405319      Einzeldruck
                //


                client = new DataServiceClient();




                if (str_Status == AKK_Helper.C.strG_SWBD_UG || str_Status == AKK_Helper.C.strG_SISH_UG)
                {
                    str_urgenz_am = DateTime.Now.Date.ToString("dd.MM.yyyy");

                    //DataService.Response resp = client.set_Datum(AKK_Helper.SessionToken, "URG", str_AntIkey);
                    //if (resp.ResponseCode != 0)
                    //{
                    //    this.Cursor = Cursors.Default;
                    //    AKK_Helper.handleServiceError(resp);
                    //}

                }
                if (str_Status == AKK_Helper.C.strG_SWBD_IB || str_Status == AKK_Helper.C.strG_SISH_IB)
                {
                    if ((str_Code == AKK_Helper.C.strGEN_CODE) ||
                        (str_Code == AKK_Helper.C.strGEN_ALL_CODE) ||
                        (str_Code == AKK_Helper.C.strKLGEN_CODE) ||
                        (str_Code == AKK_Helper.C.strKLGENGES_CODE) ||
                        (str_Code == AKK_Helper.C.strVIGEN_CODE) ||
                        (str_Code == AKK_Helper.C.strVIGENGES_CODE) ||
                        (str_Code == AKK_Helper.C.strGEN_ISH_CODE))
                    {

                        str_genehmigt_am = DateTime.Now.Date.ToString("dd.MM.yyyy");

                        //DataService.Response resp = client.set_Datum(AKK_Helper.SessionToken, "GEN",str_AntIkey);
                        //if (resp.ResponseCode != 0)
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    AKK_Helper.handleServiceError(resp);
                        //}
                    }
                }

                if ((str_Status == AKK_Helper.C.strG_SWBD_NG) || (str_Status == AKK_Helper.C.strG_SWBD_PO
                    || str_Status == AKK_Helper.C.strG_SISH_NG || str_Status == AKK_Helper.C.strG_SISH_PO))
                {
                    if ((str_Code == AKK_Helper.C.strG_WBD_MN1) ||
                        (str_Code == AKK_Helper.C.strG_WBD_MN2) ||
                        (str_Code == AKK_Helper.C.strG_WBD_MN3) ||
                        (str_Code == AKK_Helper.C.strG_WBD_MN4) ||
                        (str_Code == AKK_Helper.C.strG_WBD_GEKL ))
                         // str_Code == AKK_Helper.C.strG_WBD_RZ05))
                    { 
                        // do nothing !!
                    }
                    else
                    {
                        str_verstaendigt_am = DateTime.Now.Date.ToString("dd.MM.yyyy");

                        //DataService.Response resp = client.set_Datum(AKK_Helper.SessionToken, "VER", str_AntIkey);
                        //if (resp.ResponseCode != 0)
                        //{
                        //    this.Cursor = Cursors.Default;
                        //    AKK_Helper.handleServiceError(resp);
                        //}

                    }
                }

                if (str_Status == AKK_Helper.C.strG_SWBD_TL || str_Status == AKK_Helper.C.strG_SISH_TL)
                {
                    str_tilgung_am = DateTime.Now.Date.ToString("dd.MM.yyyy");

                    //DataService.Response resp = client.set_Datum(AKK_Helper.SessionToken, "TIL", str_AntIkey);
                    //if (resp.ResponseCode != 0)
                    //{
                    //    this.Cursor = Cursors.Default;
                    //    AKK_Helper.handleServiceError(resp);
                    //}

                }

            }
        }
        private void do_Print( String str_Drucker,
                               String str_User,
                               String str_Bereich,
                               String str_Bezirk,
                               String str_Status,
                               String str_Template,
                               String str_Ablehnung,
                               String str_Sort,
                               String str_Datumvon,
                               String str_Datumbis,
                               String str_AntIkey,
                               Int32  int_wbd_bdl)
        { 
        
            if (AKK_Helper.checkLogin() == true)
            {
             
               DocumentGeneration .DocumentGenerationClient client = new DocumentGeneration .DocumentGenerationClient();
               client.doPrintCompleted += doPrintCompleted;
               client.doPrintAsync(AKK_Helper.SessionToken,
                                   str_User,
                                   str_Template,
                                   str_Drucker,
                                   str_Bereich,
                                   str_Bezirk,
                                   str_Status,
                                   str_Ablehnung,
                                   str_Sort,
                                   str_Datumvon,
                                   str_Datumbis,
                                   str_AntIkey,
                                   int_wbd_bdl);
             }
        }

        private void doPrintCompleted(object sender, DocumentGeneration.doPrintCompletedEventArgs args)
        {
            this.Cursor = Cursors.Default; 
            cmd_Druck.Enabled   = true;
            cmd_schliessen.Enabled = true;

            if (args.Result.ResponseCode == 0)
            {
                AKK_Helper.show_msg("Druck erfolgreich", strip_info, this.Cursor);
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                    AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("Druck fehlerhaft! - " + args.Result.ResponseCode + " " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }


        }
        private void fill_Listboxen()
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DC_Columns cols = new DC_Columns();
                    DataServiceClient client = new DataServiceClient();
                    DataService.Response resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST4", "");

                    if (resp.ResponseCode == 0)
                    {
                        DC_Columns c = new DC_Columns();
                        if (ish)
                        {
                            for (int i = 0; i < cols.Count - 1; i++)
                            {
                                if (int.Parse(cols[i].DM_col_02) > 10)
                                {
                                    c.Add(cols[i]);
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < cols.Count - 1; i++)
                            {
                                if (int.Parse(cols[i].DM_col_02) < 10)
                                {
                                    c.Add(cols[i]);
                                }
                            }
                        }
                        AKK_Helper.fill_Listbox(cbo_Status, c);
                        AKK_Helper.fill_dgv(dgv_Status, c);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                    cbo_Status.Enabled = false;

                    resp = null;

                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4P", str_Status);

                    if (resp.ResponseCode == 0)
                    {
                        AKK_Helper.fill_Listbox(cbo_Vorlage, cols);
                        AKK_Helper.fill_dgv(dgv_Vorlage, cols);
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
        private void cmd_Sichtbar_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                dgv_Status.Visible = !(dgv_Status.Visible);
                dgv_Vorlage.Visible = !(dgv_Vorlage.Visible);
                txt_Output.Visible = !(txt_Output.Visible);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbo_Vorlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AKK_Helper.Templates.FirstOrDefault(x => x.Contains(cbo_Vorlage.SelectedValue.ToString())) != null)
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 333);
                cmd_Druck.Location = new System.Drawing.Point(cmd_Druck.Location.X, 212);
                cmd_schliessen.Location = new System.Drawing.Point(cmd_schliessen.Location.X, 212);
                grp_Einzeldruck.Size = new System.Drawing.Size(grp_Einzeldruck.Size.Width, 251);
                grp_bestätigungstermin.Visible = true;
            }
            else
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 233);
                cmd_Druck.Location = new System.Drawing.Point(cmd_Druck.Location.X, 112);
                cmd_schliessen.Location = new System.Drawing.Point(cmd_schliessen.Location.X, 112);
                grp_Einzeldruck.Size = new System.Drawing.Size(grp_Einzeldruck.Size.Width, 151);
                grp_bestätigungstermin.Visible = false;
            }
        }

        private void mtxt_ConfirmationPrintDate_TextChanged(object sender, EventArgs e)
        {
            if (mtxt_ConfirmationPrintDate.Text != "  .  .")
            {
                try
                {
                    lbl_Tag.Text = AKK_Helper.days[(int)DateTime.Parse(mtxt_ConfirmationPrintDate.Text).DayOfWeek];
                }
                catch
                {
                    lbl_Tag.Text = string.Empty;
                }
            }
        }

        private void mtxt_ConfirmationStartTime_TextChanged(object sender, EventArgs e)
        {
            Boolean is_ok = false;
            if (mtxt_ConfirmationStartTime.Text != "  :")
            {
                if (mtxt_ConfirmationStartTime != null)
                {
                    try
                    {
                        string[] time = mtxt_ConfirmationStartTime.Text.Split(':');
                        Int32 hour = 0;
                        Int32 minute = 0;
                        Int32.TryParse(time[0], out hour);
                        Int32.TryParse(time[1], out minute);
                        is_ok = (hour >= 0 && hour < 24) ?
                            ((minute >= 0 && minute < 60) ? true : false) : false;
                        if (!is_ok)
                        {
                            AKK_Helper.show_msg("Falsche Zeitangabe z.B. 10:30", strip_info, this.Cursor);
                        }
                    }
                    catch
                    {
                        AKK_Helper.show_msg("Falsche Zeitangabe z.B. 10:30", strip_info, this.Cursor);

                    }
                }
            }
        }
    }

}
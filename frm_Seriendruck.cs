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
    public partial class frm_Seriendruck : Form
    {
        private string str_Status = "";
        private Boolean isFirst;
        public frm_Seriendruck()
        {
            InitializeComponent();
        }
        private void frm_Seriendruck_Load(object sender, EventArgs e)
        {
            isFirst = true; 
            AKK_Helper.FindControls(this);

            mtxt_von.Mask = @"00\.00\.0000";
            mtxt_bis.Mask = @"00\.00\.0000";

            mtxt_ConfirmationPrintDate.Mask = @"00\.00\.0000";

            AKK_Helper.Templates = ConfigurationManager.AppSettings["TemplatesConfirmationPrinting"].Split(':').ToList();

            /*this.Size = new System.Drawing.Size(this.Size.Width,442);
            cmd_drucken.Location = new System.Drawing.Point(cmd_drucken.Location.X,344);
            cmd_schliesen.Location = new System.Drawing.Point(cmd_schliesen.Location.X,344);
            grp_Seriendruck.Size = new System.Drawing.Size(grp_Seriendruck.Size.Width, 320);*/

            mtxt_ConfirmationPrintDate.Text = DateTime.Now.AddDays(Int32.Parse(ConfigurationManager.AppSettings["AddDaysConfirmationPrinting"])).ToString();
            mtxt_ConfirmationStartTime.Text = ConfigurationManager.AppSettings["StartTimeOfConfirmationPrinting"];
            AKK_Helper.fill_Minutes(lst_Minutes,ConfigurationManager.AppSettings["StepBetweenConfirmationPrinting"]);
            //
            dgv_bezirksstelle.Visible = false;
            dgv_Status.Visible = false;
            dgv_Vorlage.Visible = false;

            chk_isa.Enabled = false;
            chk_akv.Enabled = false;
            chk_ra.Enabled = false;
            chk_sonstige.Enabled = false;
            //
            if (AKK_Helper.checkLogin() == true)
            {
                try
                {
                    DC_Columns cols = new DC_Columns();
                    DataService.DataServiceClient client = new DataService.DataServiceClient();
                    Addit.AK.WBD.AK_Suche.DataService.Response resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "ANT3", "");

                    if (resp.ResponseCode == 0)
                    {
                        Int32 int_col_count = cols.Count;
                        DC_Columns c = new DC_Columns();
                        for (int i = 0; i < cols.Count; i++)
                        {
                            if (cols[i].DM_col_02 == "2" || cols[i].DM_col_02 == "18")
                            {
                                c.Add(cols[i]);
                            }
                        }
                        AKK_Helper.fill_Listbox(cob_Bereich, c);
                        //
                        // Antragsstatus
                        //
                        cols = new DC_Columns();
                        client = new DataServiceClient();
                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST3", "");

                        if (resp.ResponseCode == 0)
                        {
                            c = new DC_Columns();
                            for (int i = 0; i < cols.Count; i++)
                            {
                                if (int.Parse(cols[i].DM_col_02) < 10)
                                {
                                    c.Add(cols[i]);
                                }
                            }

                            AKK_Helper.fill_Listbox(cob_Status, c);
                            AKK_Helper.fill_dgv(dgv_Status, c);
                            //
                            // Bezirksstellen
                            //
                            resp = null;
                            resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BZS5", "");
                            if (resp.ResponseCode == 0)
                            {
                                AKK_Helper.fill_Listbox(cob_Bezirksstelle, cols);
                                AKK_Helper.fill_dgv(dgv_bezirksstelle, cols);
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                AKK_Helper.handleServiceError(resp);
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                        // load Listbox
                        chk_wbd.Checked = true;
                        opt_wbd.Checked = true;
                        chk_bdl.Checked = true;
                        opt_bdl.Checked = true;
                        fill_Vorlagen();
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
                }
            }
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
        private void frm_Seriendruck_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Seriendruck_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
            if (cob_Bereich.SelectedIndex == 0) //WBD
            {
                chk_wbd.Checked = true;
                chk_bdl.Checked = true;
                opt_bdl.Checked = true;
                opt_wbd.Checked = true;
                grp_bestätigungstermin.Visible = true;
            }
            else if (cob_Bereich.SelectedIndex == 1)
            {
                chk_isa.Checked = true;
                grp_bestätigungstermin.Visible = false;
            }
            
            chk_sort.Checked = false;   // Nach name sortiert
            cob_Bereich.Enabled = true;
            cob_Status.SelectAll();
            cob_Status.Focus();
            //
        }
        # endregion
        private void mtxt_von_Enter(object sender, EventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_von_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_von.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_von.Text) == false)
                {
                    mtxt_von.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_von.Text, strip_info, this.Cursor);
                    mtxt_von.SelectAll();
                }
            }
            label4.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_bis_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_bis_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_bis.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_bis.Text) == false)
                {
                    mtxt_bis.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_bis.Text, strip_info, this.Cursor);                    
                    mtxt_bis.SelectAll();
                }
            }

            label5.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cob_Status_TextChanged(object sender, EventArgs e)
        {
             // fill_Vorlagen();
        }
        private void cob_Status_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cob_Status_Leave(object sender, EventArgs e)
        {
            if (cob_Status.SelectedIndex != -1)
            {
                Int32 int_stat = 0;
                Int32.TryParse(cob_Status.SelectedValue.ToString(), out int_stat);

                label2.ForeColor = AKK_Helper.c_lost_focus;
                if (int_stat > 0)
                {

                    cmd_drucken.Enabled = true;
                }
                else
                {
                    cmd_drucken.Enabled = false;
                }
            }
            //fill_Vorlagen();
        }
        /*private void cob_Status_KeyUp(object sender, KeyEventArgs e)
        {
            isFirst = false;
            AKK_Helper.set_lst_entry(sender, e, cob_Status);
            fill_Vorlagen();
            isFirst = true;
        }*/
        private void cob_Status_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isFirst == true)
            {
                AKK_Helper.set_actual_index(cob_Status.SelectedIndex.ToString(), cob_Status.Text);
                fill_Vorlagen();
            }
        }

        private void cob_Bereich_Enter(object sender, EventArgs e)
        {
            Bereich.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cob_Bereich_Leave(object sender, EventArgs e)
        {
            Bereich.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void chk_sort_Enter(object sender, EventArgs e)
        {
            chk_sort.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_sort_Leave(object sender, EventArgs e)
        {
            chk_sort.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cob_Bezirksstelle_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cob_Bezirksstelle_Leave(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cob_Bezirksstelle_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cob_Bezirksstelle);

        }
        private void cob_Bezirksstelle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cob_Bezirksstelle.SelectedIndex.ToString(), cob_Bezirksstelle.Text);
        }

        private void cob_Vorlage_Enter(object sender, EventArgs e)
        {

            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cob_Vorlage_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_lost_focus;
            Int32 int_stat = -1;
            if (cob_Vorlage.SelectedValue != null)
                Int32.TryParse(cob_Vorlage.SelectedValue.ToString(), out int_stat);


            if (int_stat > 0)
            {
                cmd_drucken.Enabled = true;
            }
            else
            {
                cmd_drucken.Enabled = false;
            }
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cob_Vorlage_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cob_Vorlage);
        }
        private void cob_Vorlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cob_Vorlage.SelectedIndex.ToString(), cob_Vorlage.Text);

            /*if (AKK_Helper.Templates.FirstOrDefault(x => x.Contains(cob_Vorlage.SelectedValue.ToString())) != null)
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 542);
                cmd_drucken.Location = new System.Drawing.Point(cmd_drucken.Location.X, 444);
                cmd_schliesen.Location = new System.Drawing.Point(cmd_schliesen.Location.X, 444);
                grp_Seriendruck.Size = new System.Drawing.Size(grp_Seriendruck.Size.Width, 414);
            }
            else
            {
                this.Size = new System.Drawing.Size(this.Size.Width, 442);
                cmd_drucken.Location = new System.Drawing.Point(cmd_drucken.Location.X, 344);
                cmd_schliesen.Location = new System.Drawing.Point(cmd_schliesen.Location.X, 344);
                grp_Seriendruck.Size = new System.Drawing.Size(grp_Seriendruck.Size.Width, 320);
            }*/
        }

        private void chk_wbd_Enter(object sender, EventArgs e)
        {
            chk_wbd.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_wbd_Leave(object sender, EventArgs e)
        {
            chk_wbd.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_wbd_CheckedChanged(object sender, EventArgs e)
        {
            fill_Vorlagen();
            if (chk_wbd.Checked == false)
            {
                opt_wbd.Checked = false;
                opt_wbd.Enabled = false;
                opt_bdl.Enabled = false;

                if (chk_bdl.Checked == false)
                {
                    opt_bdl.Checked = false;
                }
                else
                {
                    opt_bdl.Checked = true;
                }
            }
            else
            {
                if (chk_wbd.Checked == true)
                {
                    opt_wbd.Checked = true;
                    if (chk_bdl.Checked == false)
                    {
                        opt_wbd.Enabled = false;
                        opt_bdl.Checked = false;
                        opt_bdl.Enabled = false;
                    }
                    else
                    {
                        opt_bdl.Enabled = true;
                        opt_bdl.Checked = true;
                        opt_wbd.Enabled = true;
                    }
                }
            }
        }

        private void chk_bdl_Enter(object sender, EventArgs e)
        {
            chk_bdl.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_bdl_Leave(object sender, EventArgs e)
        {
            chk_bdl.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_bdl_CheckedChanged(object sender, EventArgs e)
        {
            fill_Vorlagen();
            if (chk_bdl.Checked == false)
            {
                opt_bdl.Checked = false;
                opt_bdl.Enabled = false;
                if (chk_wbd.Checked == false)
                {
                    opt_wbd.Checked = false;
                    opt_wbd.Enabled = false;
                }
                else
                {
                    opt_wbd.Checked = true;
                    opt_wbd.Enabled = false;
                }

            }
            else
            {
                if (chk_bdl.Checked == true)
                {
                    opt_bdl.Checked = true;
                    if (chk_wbd.Checked == false)
                    {
                        opt_bdl.Enabled = false;
                        opt_wbd.Checked = false;
                        opt_wbd.Enabled = false;
                    }
                    else
                    {
                        opt_bdl.Enabled = true;
                        opt_wbd.Checked = true;
                        opt_wbd.Enabled = true;
                    }
                }
            }
        }
        private void opt_wbd_Enter(object sender, EventArgs e)
        {
            opt_wbd.ForeColor = AKK_Helper.c_get_focus;
        }
        private void opt_wbd_Leave(object sender, EventArgs e)
        {
            opt_wbd.ForeColor = AKK_Helper.c_lost_focus;
            if ((opt_bdl.Checked == false) && (opt_wbd.Checked == false))
            {
                AKK_Helper.show_msg("Eine Checkbox muss selektiert werden!", strip_info, this.Cursor);
            }

        }
        private void opt_bdl_Enter(object sender, EventArgs e)
        {
            opt_bdl.ForeColor = AKK_Helper.c_get_focus;
        }
        private void opt_bdl_Leave(object sender, EventArgs e)
        {
            opt_bdl.ForeColor = AKK_Helper.c_lost_focus;
            if ((opt_bdl.Checked == false) && (opt_wbd.Checked == false))
            {
                AKK_Helper.show_msg("Eine Checkbox muss selektiert werden!", strip_info, this.Cursor);
            }
        }

        private void cmd_schliesen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmd_drucken_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                //
                // 23-02-2016 by KJ
                //
                string startDatum = string.Empty;
                string startZeit = string.Empty;
                string startDauer = string.Empty;
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
                if (lst_Minutes.SelectedIndex > 0)
                {
                    startDauer= lst_Minutes.SelectedValue.ToString();
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




                Int32 int_stat = 0;
                Int32.TryParse(cob_Status.SelectedValue.ToString(), out int_stat);
                Int32 int_wbd_bdl = 0;
                // Check Status
                if (int_stat >= 0)
                {   // Check Template 
                    if (cob_Vorlage.SelectedValue.ToString() != "0")
                    {
                        strip_info.Text = cob_Vorlage.Text + " am " +
                                          DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                          DateTime.Now.Hour.ToString("00") + " Uhr " +
                                          DateTime.Now.Minute.ToString("00") + " gestartet ...";

                        string str_Drucker = AKK_Helper.my_printer;                      // Printer
                        string str_User = AKK_Helper.UserId;                             // User ID    
                        string str_Bereich = AKK_Helper.C.strBereichKey;                 // 2 für WBD, 18 für ISH
                        str_Status = cob_Status.SelectedValue.ToString();                // von Status Combobox
                        if (cob_Bereich.SelectedIndex == 1) //ISH
                        {
                            str_Bereich = "18";
                            switch (cob_Status.SelectedValue.ToString())
                            {
                                case "1":
                                    this.str_Status = "11";
                                    break;
                                case "2":
                                    this.str_Status = "12";
                                    break;
                                case "3":
                                    this.str_Status = "13";
                                    break;
                                case "4":
                                    this.str_Status = "14";
                                    break;
                                case "5":
                                    this.str_Status = "15";
                                    break;
                                case "6":
                                    this.str_Status = "16";
                                    break;
                                case "7":
                                    this.str_Status = "17";
                                    break;
                            }
                        }else //WBD
                            {
                                switch (cob_Status.SelectedValue.ToString())
                                {
                                    case "11":
                                        this.str_Status = "1";
                                        break;
                                    case "12":
                                        this.str_Status = "2";
                                        break;
                                    case "13":
                                        this.str_Status = "3";
                                        break;
                                    case "14":
                                        this.str_Status = "4";
                                        break;
                                    case "15":
                                        this.str_Status = "5";
                                        break;
                                    case "16":
                                        this.str_Status = "6";
                                        break;
                                    case "17":
                                        this.str_Status = "7";
                                        break;
                                }
                                str_Bereich = "2";
                                str_Status = cob_Status.SelectedValue.ToString();
                            }
                        string str_Bezirk = cob_Bezirksstelle.SelectedValue.ToString();  // nicht relevant für Einzeldruck -schon für Seriendruck!
                        
                        string str_Template = "-1";                                      // PRV_Ikey_C
                        string str_Ablehnung = "-1";                                     // PRV_Control_C
                        AKK_Helper.ChangeBoxSel(cob_Vorlage, cob_Vorlage.SelectedValue.ToString(), 1, dgv_Vorlage);
                        str_Template = AKK_Helper.ChangeDGVSel(cob_Vorlage.SelectedValue.ToString(), 2, dgv_Vorlage);             // PRV_Ikey_C     --> 1
                        string str_Code = AKK_Helper.ChangeDGVSel(cob_Vorlage.SelectedValue.ToString(), 3, dgv_Vorlage).Trim();   // PRV_Code_C     --> 01
                        str_Ablehnung = AKK_Helper.ChangeDGVSel(cob_Vorlage.SelectedValue.ToString(), 4, dgv_Vorlage);            // PRV_CONTROL_C Ablehnungsgrund
                        string str_Sort = "0";                                             // sort nach Antrags ID (0) oder Name (1)
                        string str_Datumvon = "0";                                         // 0 - no Date selection else ddmmyyyy
                        if (AKK_Helper.is_empty_date(mtxt_von.Text) == false)
                            str_Datumvon = mtxt_von.Text.Substring(0, 2) +
                                           mtxt_von.Text.Substring(3, 2) +
                                           mtxt_von.Text.Substring(6, 4);
                        string str_Datumbis = "0";                                        // 0 - no Date selection else ddmmyyyy
                        if (AKK_Helper.is_empty_date(mtxt_bis.Text) == false)
                            str_Datumbis = mtxt_bis.Text.Substring(0, 2) +
                                           mtxt_bis.Text.Substring(3, 2) +
                                           mtxt_bis.Text.Substring(6, 4);
                        //
                        string str_AntIkey = "-1";                                        // Indicated Seriendruck 
                        // Sort 
                        // 3 if sort on Bezirksstelle for SerienTermin
                        
                        //

                        // 23-02-2016 by KJ
                        //
                        if (AKK_Helper.Templates.FirstOrDefault(x => x.Contains(cob_Vorlage.SelectedValue.ToString())) != null)
                        {
                            if (chk_sort.Checked == true)
                            { str_Sort = "2"; }   // BZS &  AntragsID
                            else
                            { str_Sort = "3"; }   // BZS & Name
                        }
                        else
                        {
                            if (chk_sort.Checked == true)
                            { str_Sort = "0"; }  // AntragsID
                            else
                            { str_Sort = "1"; }  // Name
                            //
                        }


                        this.Cursor = Cursors.WaitCursor;
                        cmd_drucken.Enabled = false;
                        cmd_schliesen.Enabled = false;
                        if (opt_wbd.Checked == true)
                        {
                            int_wbd_bdl = 1;
                        }
                        else
                        {
                            int_wbd_bdl = 0;
                        }
                        if (opt_bdl.Checked == true)
                        {
                            int_wbd_bdl = int_wbd_bdl + 2;
                        }
                        // -1 ... Einzeldruck
                        //  1 ... WBD
                        //  2 ... BDL
                        //  3 ... WBD & BDL

                        //neu für ISH:
                        // bis hierhin ist (bei ISH) int_wbd_bdl = 0
                        if (chk_isa.Checked)
                        {
                            int_wbd_bdl = 4;
                        }
                        if (chk_akv.Checked)
                        {
                            int_wbd_bdl = 5;
                        }
                        if (chk_ra.Checked)
                        {
                            int_wbd_bdl = 6;
                        }
                        if (chk_sonstige.Checked)
                        {
                            int_wbd_bdl = 7;
                        }
                        if (chk_isa.Checked && chk_akv.Checked)
                        {
                            int_wbd_bdl = 8;
                        }
                        if (chk_isa.Checked && chk_ra.Checked)
                        {
                            int_wbd_bdl = 9;
                        }
                        if (chk_isa.Checked && chk_sonstige.Checked)
                        {
                            int_wbd_bdl = 10;
                        }
                        if (chk_akv.Checked && chk_ra.Checked)
                        {
                            int_wbd_bdl = 11;
                        }
                        if (chk_akv.Checked && chk_sonstige.Checked)
                        {
                            int_wbd_bdl = 12;
                        }
                        if (chk_ra.Checked && chk_sonstige.Checked)
                        {
                            int_wbd_bdl = 13;
                        }
                        if (chk_isa.Checked && chk_akv.Checked && chk_ra.Checked && chk_sonstige.Checked)
                        {
                            int_wbd_bdl = 14;
                        }
                        //  4 ... ISA
                        //  5 ... AKV
                        //  6 ... RA
                        //  7 ... Sonstige
                        //  8 ... ISA + AKV
                        //  9 ... ISA + RA
                        //  10 ... ISA + Sonstige
                        //  11 ... AKV + RA
                        //  12 ... AKV + Sonstige
                        //  13 ... RA + Sonstige
                        //  14 ... ISA + AKV + RA + Sonstige

                        do_Print(str_Drucker, str_User, str_Bereich, str_Bezirk, str_Status, str_Template,
                                   str_Ablehnung, str_Sort, str_Datumvon, str_Datumbis, str_AntIkey, int_wbd_bdl);    // Seriendruck
                        //
                        //  Drucker		         ( aus wbd_setting )
                        //  User		2	     ( aus wbd_user )
                        //  Bereich		2        ( akf_antragstyp_c )
                        //  Bezirk		-1       ( akf_bezirksstellen_c )
                        //  Status		3	     ( wbd_antragsstatus_c )
                        //  Template	5 	     ( wbd_printvorlage_c -> prv_ikey_c )
                        //  Ablehnungsgrund ""	 ( 5 von wbd_printvorlage_c – prv_control )
                        //  Sortierung	1 	     ( 0 AntrasgID )
                        //                       ( 1 Name )
                        //  DatumVon	0	     im Format ddmmyyyy
                        //  DatumBis	0	     im Format ddmmyyyy
                        //  Ant_Ikey    -1       Seriendruck
                    }
                    else
                    {
                        AKK_Helper.show_msg("Keine gültige Vorlage selektiert", strip_info, this.Cursor);
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Keinen gültigen Status selektiert", strip_info, this.Cursor);
                }
            }
        }
        public void do_Print(String str_Drucker,
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
                             Int32  int_wbd_bdl )
        {

            if (AKK_Helper.checkLogin() == true)
            {
                
                DocumentGeneration.DocumentGenerationClient client = new DocumentGeneration.DocumentGenerationClient();
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
            cmd_drucken.Enabled = true;
            cmd_schliesen.Enabled=true;

            if (args.Result.ResponseCode == 0)
            {
                AKK_Helper.show_msg(string.Format("Seriendruck erfolgreich - {0} Darlehen verarbeitet", args.Result.ResponseMsg), strip_info, this.Cursor);
               
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                   
                    AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("Seriendruck fehlerhaft! - " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }
        }
        public void fill_Vorlagen()
        {
            Int32 save_int_index = AKK_Helper.int_index;
            if (cob_Status.SelectedIndex != -1)
            {
                if (AKK_Helper.checkLogin() == true)
                {
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        DC_Columns cols = new DC_Columns();
                        DataService.DataServiceClient client = new DataService.DataServiceClient();
                        Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
                        cmd_drucken.Enabled = true;
                        //
                        // Load templates 
                        //
                        str_Status = cob_Status.SelectedValue.ToString();
                        if (cob_Bereich.SelectedIndex == 1)//ISH
                        {
                            switch (str_Status)
                            {
                                case "1":
                                    str_Status = "11";
                                    break;
                                case "2":
                                    str_Status = "12";
                                    break;
                                case "3":
                                    str_Status = "13";
                                    break;
                                case "4":
                                    str_Status = "14";
                                    break;
                                case "5":
                                    str_Status = "15";
                                    break;
                                case "6":
                                    str_Status = "16";
                                    break;
                                case "7":
                                    str_Status = "17";
                                    break;
                            }
                        }
                        resp = null;
                        if (cob_Bereich.SelectedIndex == 0) //Wohnbaudarlehen
                        {
                            if (chk_wbd.Checked == false && chk_bdl.Checked == false) // Alle
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4P", str_Status);
                                cmd_drucken.Enabled = false;
                            }
                            else
                            {
                                if (chk_wbd.Checked == false && chk_bdl.Checked == true)   // BDL = B
                                {
                                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4B", str_Status);

                                }
                                else
                                {
                                    if (chk_wbd.Checked == true && chk_bdl.Checked == false)   // WBD  = W
                                    {
                                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4W", str_Status);

                                    }
                                    else                                                           // BDL & WBD = 2
                                    {
                                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV42", str_Status);
                                    }
                                }
                            }
                        }
                        else if (cob_Bereich.SelectedIndex == 1) //Insolvenzsoforthilfe
                        {
                            if (chk_akv.Checked == false && chk_isa.Checked == false && chk_sonstige.Checked == false && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH", str_Status);
                                cmd_drucken.Enabled = false;
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == true && chk_sonstige.Checked == false && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_I", str_Status);
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == false && chk_sonstige.Checked == true && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_S", str_Status);
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == true && chk_sonstige.Checked == true && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_IS", str_Status);
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == false && chk_sonstige.Checked == false && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_R", str_Status);
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == true && chk_sonstige.Checked == false && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_IR", str_Status);
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == false && chk_sonstige.Checked == true && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_SR", str_Status);
                            }
                            else if (chk_akv.Checked == false && chk_isa.Checked == true && chk_sonstige.Checked == true && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_ISR", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == false && chk_sonstige.Checked == false && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_A", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == true && chk_sonstige.Checked == false && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_AI", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == false && chk_sonstige.Checked == true && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_AS", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == true && chk_sonstige.Checked == true && chk_ra.Checked == false)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_AIS", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == false && chk_sonstige.Checked == false && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_AR", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == true && chk_sonstige.Checked == false && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_AIR", str_Status);
                            }
                            else if (chk_akv.Checked == true && chk_isa.Checked == false && chk_sonstige.Checked == true && chk_ra.Checked == true)
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH_ASR", str_Status);
                            }
                            else // Alle ausgewählt
                            {
                                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "PRV4ISH", str_Status);
                            }


                        }
                        if (resp.ResponseCode == 0)
                        {
                            AKK_Helper.fill_Listbox(cob_Vorlage, cols);
                            AKK_Helper.fill_dgv(dgv_Vorlage, cols);
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                        //
                        // Disable if 0 -> no valid template found
                        //
                        if (cob_Vorlage.Items.Count == 1)
                        {
                            if (cob_Vorlage.SelectedValue.ToString() == "0")
                            {
                                cmd_drucken.Enabled = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                    }
                    this.Cursor = Cursors.Default;
                }
            }
            AKK_Helper.int_index = save_int_index;
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
            if ( mtxt_ConfirmationStartTime.Text != "  :" )
            {
                if ( mtxt_ConfirmationStartTime != null)
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

        private void cob_Bereich_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cob_Bereich.SelectedIndex == 1)//ISH
            {
                chk_bdl.Checked = false;
                chk_wbd.Checked = false;
                opt_bdl.Checked = false;
                opt_wbd.Checked = false;

                chk_bdl.Enabled = false;
                chk_wbd.Enabled = false;
                opt_bdl.Enabled = false;
                opt_wbd.Enabled = false;

                chk_isa.Enabled = true;
                chk_akv.Enabled = true;
                chk_sonstige.Enabled = true;
                chk_ra.Enabled = true;

                chk_isa.Checked = true;
                chk_akv.Checked = true;
                chk_sonstige.Checked = true;
                chk_ra.Checked = true;

                mtxt_ConfirmationPrintDate.Enabled = false;
                mtxt_ConfirmationStartTime.Enabled = false;
                lst_Minutes.Enabled = false;
                mtxt_von.Enabled = false;
                mtxt_bis.Enabled = false;
                grp_bestätigungstermin.Visible = false;

                //David Stefitz 01.02.2019
                DC_Columns cols = new DC_Columns();
                DataServiceClient client = new DataServiceClient();
                Addit.AK.WBD.AK_Suche.DataService.Response resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST4P", "VRZ");

                if (resp.ResponseCode == 0)
                {
                    DC_Columns c = new DC_Columns();
                    for (int i = 0; i < cols.Count; i++)
                    {
                        if (int.Parse(cols[i].DM_col_02) > 10)
                        {
                            c.Add(cols[i]);
                        }
                    }

                    AKK_Helper.fill_Listbox(cob_Status, c);
                }
            }
            else
            {
                chk_bdl.Checked = true;
                chk_wbd.Checked = true;
                opt_bdl.Checked = true;
                opt_wbd.Checked = true;

                chk_bdl.Enabled = true;
                chk_wbd.Enabled = true;
                opt_bdl.Enabled = true;
                opt_wbd.Enabled = true;
                chk_sort.Enabled = true;

                chk_isa.Checked = false;
                chk_akv.Enabled = false;
                chk_sonstige.Checked = false;
                chk_ra.Enabled = false;

                chk_isa.Enabled = false;
                chk_akv.Enabled = false;
                chk_sonstige.Enabled = false;

                chk_isa.Checked = false;

                mtxt_ConfirmationPrintDate.Enabled = true;
                mtxt_ConfirmationStartTime.Enabled = true;
                lst_Minutes.Enabled = true;
                grp_bestätigungstermin.Visible = true;

                //David Stefitz 01.02.2019
                DC_Columns cols = new DC_Columns();
                DataServiceClient client = new DataServiceClient();
                Addit.AK.WBD.AK_Suche.DataService.Response resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "AST3", "");

                if (resp.ResponseCode == 0)
                {
                    DC_Columns c = new DC_Columns();
                    for (int i = 0; i < cols.Count; i++)
                    {
                        if (int.Parse(cols[i].DM_col_02) < 10)
                        {
                            c.Add(cols[i]);
                        }
                    }

                    AKK_Helper.fill_Listbox(cob_Status, c);
                }
            }
            fill_Vorlagen();
        }
        private void chk_isa_CheckedChanged(object sender, EventArgs e)
        {
            fill_Vorlagen();
        }

        private void chk_akv_CheckedChanged(object sender, EventArgs e)
        {
            fill_Vorlagen();
        }

        private void chk_ra_CheckedChanged(object sender, EventArgs e)
        {
            fill_Vorlagen();
        }

        private void chk_sonstige_CheckedChanged(object sender, EventArgs e)
        {
            fill_Vorlagen();
        }

       

     
    }  // Class
}      // Namespace

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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Addit.AK.WBD.AK_Suche
{
   
    public partial class frm_Auswertung : Form
    {
        private Int32 selectet_year = 31; //Derzeitiges Jahr
        private Int32 selected_month = (Int32)DateTime.Now.Month - 1;
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
        private void frm_Auswertung_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Auswertung_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }
        
        
        #endregion



        ReportDocument cryRpt;
        
        public frm_Auswertung()
        {
            InitializeComponent();
        }

        private void frm_Auswertung_Load(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                grp_1.Visible = false;
                lst_info_aw.Visible = false;
                //09.11.2018 David Stefitz
                cb_gbv.Visible = false;
                lbl_gbv.Visible = false;
                
                //
                AKK_Helper.FindControls(this);
                //
                // Fill comboboxes
                //
                AKK_Helper.fill_Monate(cbo_mon_v, AKK_Helper.c_ohne_leer);
                AKK_Helper.fill_Jahre(cbo_jahr_v, AKK_Helper.c_ohne_leer);
                AKK_Helper.fill_Tage(cbo_tag_v, 1, AKK_Helper.c_ohne_leer);

                AKK_Helper.fill_Monate(cbo_mon_b, AKK_Helper.c_ohne_leer);
                AKK_Helper.fill_Jahre(cbo_jahr_b, AKK_Helper.c_ohne_leer);
                AKK_Helper.fill_Tage(cbo_tag_b, 1, AKK_Helper.c_ohne_leer);

                //06.03.2019 DS Von und Bis Datum auf heutiges Datum setzen
                cbo_jahr_v.SelectedValue = selectet_year;
                cbo_mon_v.SelectedValue = DateTime.Now.Month.ToString();
                cbo_tag_v.SelectedValue = DateTime.Now.Day.ToString();

                cbo_jahr_b.SelectedValue = selectet_year;
                cbo_mon_b.SelectedValue = DateTime.Now.Month.ToString();
                cbo_tag_b.SelectedValue = DateTime.Now.Day.ToString();

                /*cbo_jahr_v.SelectedIndex = selectet_year;
                cbo_mon_v.SelectedIndex = selected_month;
                cbo_tag_v.SelectedIndex = 0;

                cbo_jahr_b.SelectedIndex = 16;
                cbo_mon_b.SelectedIndex = selected_month;
                cbo_tag_b.SelectedIndex = 0;
                 * */
                //
                // Disable Bereich - nur WBD
                //
                cbo_Bereich.Enabled = true;
                //
                // Load Comboboxes
                //
                DC_Columns cols = new DC_Columns();
                Response resp = new Response();
                DataService.DataServiceClient client = new DataService.DataServiceClient();

                if (AKK_Helper.checkLogin() == true)
                {
                    try
                    {
                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "ANT3", "");

                        if (resp.ResponseCode == 0)
                        {
                            Int32 int_col_count = cols.Count;

                            DC_Columns c = new DC_Columns();
                            for (int i = 0; i < cols.Count; i++)
                            {
                                if (cols[i].DM_col_03 == "WBD" || cols[i].DM_col_03 == "ISH")
                                {
                                    c.Add(cols[i]);
                                }
                            }

                            AKK_Helper.fill_Listbox(cbo_Bereich, c);

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
                    //
                    try
                    {
                        resp = null;
                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "BZS5", "");
                        if (resp.ResponseCode == 0)
                        {
                            AKK_Helper.fill_Listbox(cbo_bezirksstelle, cols);
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

                    try
                    {
                        resp = null;
                        resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "VOR", "2");
                        if (resp.ResponseCode == 0)
                        {
                            AKK_Helper.fill_Listbox(cbo_vorlage, cols);
                            AKK_Helper.fill_dgv(dgv_vorlage, cols);
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
                    chk_50.Checked = false;
                    chk_100.Checked = true;
                    cb_gbv.SelectedIndex = 0;
                    cbo_vorlage.Focus();
                }
            }
        }
            
        private void cbo_vorlage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_vorlage.SelectedIndex.ToString(), cbo_vorlage.Text);

            //06.03.2019 DS Von und Bis Datum auf heutiges Datum setzen
            cbo_jahr_v.SelectedValue = selectet_year;
            cbo_mon_v.SelectedValue = DateTime.Now.Month.ToString();
            cbo_tag_v.SelectedValue = DateTime.Now.Day.ToString();

            cbo_jahr_b.SelectedValue = selectet_year;
            cbo_mon_b.SelectedValue = DateTime.Now.Month.ToString();
            cbo_tag_b.SelectedValue = DateTime.Now.Day.ToString();

            /*cbo_jahr_v.SelectedIndex = selectet_year;
            cbo_mon_v.SelectedIndex = selected_month;
            cbo_tag_v.SelectedIndex = 0;

            cbo_jahr_b.SelectedIndex = selectet_year;
            cbo_mon_b.SelectedIndex = selected_month;
            cbo_tag_b.SelectedIndex = 0;*/


            if (cbo_vorlage.SelectedValue.ToString() == "66"  ||
                cbo_vorlage.SelectedValue.ToString() == "87"  || 
                cbo_vorlage.SelectedValue.ToString() == "100" ||
                cbo_vorlage.SelectedValue.ToString() == "101")
            {
                cbo_tag_v.Visible = false;
                cbo_mon_v.Visible = true;
                cbo_jahr_v.Visible = true;
                //
                cbo_tag_b.Visible  = false;
                cbo_mon_b.Visible  = false;
                cbo_jahr_b.Visible = false;
                lbl_bis.Visible    = false;
                //
                lbl_tag.Visible  = false;
                lbl_mon.Visible  = true;
                lbl_jahr.Visible = true;
            }

            else
            {
                if (cbo_vorlage.SelectedValue.ToString() == "67"  ||
                    cbo_vorlage.SelectedValue.ToString() == "88"  ||
                    cbo_vorlage.SelectedValue.ToString() == "102" ||
                    cbo_vorlage.SelectedValue.ToString() == "103")
                {
                    cbo_tag_v.Visible = false;
                    cbo_mon_v.Visible = false;
                    cbo_jahr_v.Visible = true;
                    //
                    cbo_tag_b.Visible = false;
                    cbo_mon_b.Visible = false;
                    cbo_jahr_b.Visible = false;
                    lbl_bis.Visible = false;
                    //
                    lbl_tag.Visible = false;
                    lbl_mon.Visible = false;
                    lbl_jahr.Visible = true;
                }
                else
                {
                    if (cbo_vorlage.SelectedValue.ToString() == "37" || cbo_vorlage.SelectedValue.ToString() == "38" ||
                        cbo_vorlage.SelectedValue.ToString() == "40" || cbo_vorlage.SelectedValue.ToString() == "41" ||
                        cbo_vorlage.SelectedValue.ToString() == "32" || cbo_vorlage.SelectedValue.ToString() == "58" ||
                        cbo_vorlage.SelectedValue.ToString() == "75" || cbo_vorlage.SelectedValue.ToString() == "33")
                    {
                        cbo_tag_v.Visible = false;
                        cbo_mon_v.Visible = false;
                        cbo_jahr_v.Visible = false;

                        cbo_tag_b.Visible = false;
                        cbo_mon_b.Visible = false;
                        cbo_jahr_b.Visible = false;
                        
                        lbl_von.Visible = false;
                        lbl_bis.Visible = false;
                        lbl_mon.Visible = false;
                        lbl_tag.Visible = false;
                        lbl_jahr.Visible = false;
                    }
                    else
                    {
                        cbo_tag_v.Visible = true;
                        cbo_mon_v.Visible = true;
                        cbo_jahr_v.Visible = true;

                        cbo_tag_b.Visible = true;
                        cbo_mon_b.Visible = true;
                        cbo_jahr_b.Visible = true;

                        lbl_von.Visible = true;
                        lbl_bis.Visible = true;
                        lbl_mon.Visible = true;
                        lbl_tag.Visible = true;
                        lbl_jahr.Visible = true;
                    }


                }

            }
        }
        private void cbo_vorlage_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_vorlage_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_vorlage_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_vorlage);
        }
        private void cbo_Bereich_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_Bereich_Leave(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_bezirksstelle_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_bezirksstelle_Leave(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_bezirksstelle_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_bezirksstelle);
        }
        private void cbo_bezirksstelle_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_bezirksstelle.SelectedIndex.ToString(), cbo_bezirksstelle.Text);
        }
       
        private void cbo_mon_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.fill_Tage(cbo_tag_v, (Int32)cbo_mon_v.SelectedValue, AKK_Helper.c_ohne_leer);
            AKK_Helper.set_actual_index(cbo_mon_v.SelectedIndex.ToString(), cbo_mon_v.Text);
        }
        private void cbo_mon_v_Enter(object sender, EventArgs e)
        {
            lbl_von.ForeColor = AKK_Helper.c_get_focus;
            lbl_mon.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_mon_v_Leave(object sender, EventArgs e)
        {
            lbl_von.ForeColor = AKK_Helper.c_lost_focus;
            lbl_mon.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_mon_v_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_mon_v);
        }
        private void cbo_jahr_v_Enter(object sender, EventArgs e)
        {
            lbl_von.ForeColor = AKK_Helper.c_get_focus;
            lbl_jahr.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_jahr_v_Leave(object sender, EventArgs e)
        {
            lbl_von.ForeColor = AKK_Helper.c_lost_focus;
            lbl_jahr.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_jahr_v_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_jahr_v);
        }
        private void cbo_jahr_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_jahr_v.SelectedIndex.ToString(), cbo_jahr_v.Text);
        }
        private void cbo_tag_v_Enter(object sender, EventArgs e)
        {
            lbl_von.ForeColor = AKK_Helper.c_get_focus;
            lbl_tag.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_tag_v_Leave(object sender, EventArgs e)
        {
            lbl_von.ForeColor = AKK_Helper.c_lost_focus;
            lbl_tag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_tag_v_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_tag_v);
        }
        private void cbo_tag_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_tag_v.SelectedIndex.ToString(), cbo_tag_v.Text);
        }
       
        private void cbo_jahr_b_Enter(object sender, EventArgs e)
        {
            lbl_bis.ForeColor = AKK_Helper.c_get_focus;
            lbl_jahr.ForeColor = AKK_Helper.c_get_focus;
        }
        private void cbo_jahr_b_Leave(object sender, EventArgs e)
        {
            lbl_bis.ForeColor = AKK_Helper.c_lost_focus;
            lbl_jahr.ForeColor = AKK_Helper.c_lost_focus;

        }
        private void cbo_jahr_b_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_jahr_b);
        }
        private void cbo_jahr_b_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_jahr_b.SelectedIndex.ToString(), cbo_jahr_b.Text);
        }
        private void cbo_mon_b_Enter(object sender, EventArgs e)
        {
            lbl_bis.ForeColor = AKK_Helper.c_get_focus;
            lbl_mon.ForeColor = AKK_Helper.c_get_focus;

        }
        private void cbo_mon_b_Leave(object sender, EventArgs e)
        {
            lbl_bis.ForeColor = AKK_Helper.c_lost_focus;
            lbl_mon.ForeColor = AKK_Helper.c_lost_focus;

        }
        private void cbo_mon_b_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_mon_b);
        }
        private void cbo_mon_b_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.fill_Tage(cbo_tag_b, (Int32)cbo_mon_b.SelectedValue, AKK_Helper.c_ohne_leer);
            AKK_Helper.set_actual_index(cbo_mon_b.SelectedIndex.ToString(), cbo_mon_b.Text);

        }
        private void cbo_tag_b_Enter(object sender, EventArgs e)
        {
            lbl_bis.ForeColor = AKK_Helper.c_get_focus;
            lbl_tag.ForeColor = AKK_Helper.c_get_focus;

        }
        private void cbo_tag_b_Leave(object sender, EventArgs e)
        {
            lbl_bis.ForeColor = AKK_Helper.c_lost_focus;
            lbl_tag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cbo_tag_b_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.set_lst_entry(sender, e, cbo_tag_b);
        }
        private void cbo_tag_b_SelectedIndexChanged(object sender, EventArgs e)
        {
            AKK_Helper.set_actual_index(cbo_tag_b.SelectedIndex.ToString(), cbo_tag_b.Text);
        }


        public Boolean Check_auswertung(string str_vorlage_id)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                DC_Columns cols = new DC_Columns();
                Response resp = new Response();
                DataService.DataServiceClient client = new DataService.DataServiceClient();

                if (AKK_Helper.checkLogin() == true)
                {
                    try
                    {
                        if (Int32.Parse(str_vorlage_id) > 200)
                        {
                            resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "CR1ISH", str_vorlage_id);
                        }
                        else
                        {
                            resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "CR1", str_vorlage_id);
                        }
                        

                        if (resp.ResponseCode == 0)
                        {   // 27-09-2011 by KJ --> Keine Abfrage auf einene report
                            //                      sondern auf alle Reports!
                            //if (cols.Count == 0)
                            //{
                            //    return false;
                            //}
                            //else
                            //{
                            //    return true;
                            //}
                            if (cols.Count > 0)
                            { 
                                String str_value = cols[0].DM_col_01.ToString ();
                                Int16 int_value = 0;
                                Int16.TryParse(str_value, out int_value);
                                if (int_value > 0)
                                {
                                    return true;
                                }
                                else 
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            return true ;    // Eintrag in akf_auswertung immer löschen!!
                        }

                    }
                    catch (Exception ex)
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                        return false;
                    }
                }
                return false;
            }
            return false;
        }
        public Boolean Delete_Auswertung(string str_vorlage_id)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DataService.DataServiceClient ClientBase = new DataServiceClient();

                resp = ClientBase.Delete_Auswertung(AKK_Helper.SessionToken, str_vorlage_id);
                if (resp.ResponseCode != 0)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                    return false;
                }
                return true;
            }
            return false;
        }
        public Boolean WriteDB_Auswertung(string str_name, string str_vorlage_id, string str_von, string str_bis, string str_bzs)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DataService.DataServiceClient ClientBase = new DataServiceClient();
                resp = ClientBase.WriteDB_Auswertung(AKK_Helper.SessionToken, str_name, str_vorlage_id, str_von, str_bis, str_bzs);
                if (resp.ResponseCode != 0)
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                    return false;
                }

                return true;
            }
            return false;
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmd_start_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                string str_von = "";
                string str_bis = "";
                //
                // Format : DDMMYYYY
                //
                str_von = cbo_tag_v.SelectedValue.ToString().PadLeft(2, '0') +
                          cbo_mon_v.SelectedValue.ToString().PadLeft(2, '0') +
                          cbo_jahr_v.Text.ToString().PadLeft(4, '0');

                str_bis = cbo_tag_b.SelectedValue.ToString().PadLeft(2, '0') +
                          cbo_mon_b.SelectedValue.ToString().PadLeft(2, '0') +
                          cbo_jahr_b.Text.ToString().PadLeft(4, '0');

                string str_name = AKK_Helper.ChangeDGVSel(cbo_vorlage.SelectedValue.ToString(), 1, dgv_vorlage);
                string str_vorlage_id = AKK_Helper.ChangeDGVSel(cbo_vorlage.SelectedValue.ToString(), 2, dgv_vorlage);
                string str_vorlage = AKK_Helper.ChangeDGVSel(cbo_vorlage.SelectedValue.ToString(), 3, dgv_vorlage);
                string str_pfad = AKK_Helper.ChangeDGVSel(cbo_vorlage.SelectedValue.ToString(), 4, dgv_vorlage);
                string str_pfad1 = str_pfad;
                if (str_pfad.Substring(str_pfad.Length - 1, 1) != @"\")
                {
                    str_pfad1 = str_pfad + @"\";
                }
                //
                string str_bzs = cbo_bezirksstelle.SelectedValue.ToString();
                //
                // Check if any report is allready running
                //
                if (Check_auswertung(str_vorlage_id) == true)
                {
                    //if (MessageBox.Show("Auswertung <" + str_name + "> bereits gestartet! Wollen sie trotzdem drucken?", "Auswertungen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (MessageBox.Show("Es läuft bereits eine Auswertung! Wollen sie trotzdem drucken?", "Auswertungen", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Delete_Auswertung(str_vorlage_id) == true)
                        {
                            // Print CR Report
                            Print_Auswertung(str_name, str_vorlage_id, str_pfad1, str_vorlage, str_von, str_bis, str_bzs);
                        }
                    }
                }
                else
                {   // Print CR Report
                    Print_Auswertung(str_name, str_vorlage_id, str_pfad1, str_vorlage, str_von, str_bis, str_bzs);
                }
                //
            }
        }

        private void cmd_print_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (AKK_Helper.Print_LST_Box(lst_info_aw, 10, 22, 0, -1, -1) == true)
                {
                    AKK_Helper.show_msg("Druck erfolgreich  beendet!", strip_info, this.Cursor);
                }
            }
        }
        public void Print_Auswertung(string str_name, string str_vorlage_id, string str_pfad1, string str_vorlage, string str_von, string str_bis, string str_bzs)
        {
            //
            // Calculate Values for MONATS und Jahresstatistik
            //


            if (this.cryRpt != null)
            {
                this.cryRpt.Close();
                this.cryRpt.Dispose();
            }


            
            this.strip_info.Text = "WriteDB_Auswertung gestartet ...";
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();
            if (WriteDB_Auswertung(str_name, str_vorlage_id, str_von, str_bis, str_bzs) == true)
            {
                //MessageBox.Show("nach writedb auswertung");
                // 
                // Check physical File ( Vorlage )
                //
                string file = str_pfad1 + str_vorlage;
                if (System.IO.File.Exists(file))
                {
                    //MessageBox.Show("file existiert");

                    cryRpt = new ReportDocument();
                    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                    ConnectionInfo crConnectionInfo = new ConnectionInfo();
                    ConnectionInfo crConnectionInfoPVS = new ConnectionInfo();
                    Tables CrTables;
                    //cryRpt.Load(@"C:\Juergen\NWDB\CR_2008\Test\WBD_MON_BER_subrep.rpt");
                    try
                    {
                        strip_info.Text = str_name + " wird erstellt ...";
                        cryRpt.Load(str_pfad1 + str_vorlage);

                        //MessageBox.Show(str_pfad1+str_vorlage +" wurde geladen");
                        //
                        crConnectionInfo.ServerName = AKK_Helper.C.strG_CR_Ora_Instanc;
                        crConnectionInfo.DatabaseName = "";
                        crConnectionInfo.UserID = AKK_Helper.CrUser;
                        if (AKK_Helper.CrPW == null)
                        {
                            AKK_Helper.CrPW = "";
                        }

                        crConnectionInfo.Password = AKK_Helper.CrPW;
                        crConnectionInfo.AllowCustomConnection = false;
                        crConnectionInfo.IntegratedSecurity = false;

                        //MessageBox.Show(String.Format("ConnectionInfo: {0}; \n {1};\n {2}; \n{3};\n ", crConnectionInfo.UserID, crConnectionInfo.ServerName, crConnectionInfo.LogonProperties, crConnectionInfo.DatabaseName));

                        crConnectionInfoPVS.ServerName = AKK_Helper.C.strG_CRPVS_Ora_Instanc;
                        crConnectionInfoPVS.DatabaseName = "";
                        crConnectionInfoPVS.UserID   =  AKK_Helper.CrPVSUser;                      
                        crConnectionInfoPVS.Password =  AKK_Helper.CrPVSPW;
                        crConnectionInfoPVS.AllowCustomConnection = false;
                        crConnectionInfoPVS.IntegratedSecurity = false;
                        //
                        //MessageBox.Show(String.Format("ConnectionInfo PVS: {0}; \n{1}; \n{2};\n {3};\n ", crConnectionInfoPVS.UserID, crConnectionInfoPVS.ServerName, crConnectionInfoPVS.LogonProperties, crConnectionInfoPVS.DatabaseName));
                        CrTables = cryRpt.Database.Tables;
                        //MessageBox.Show(String.Format("nach Cr Tables: {0}; \n{1}; \n{2};\n {3};\n ",cryRpt.ToString(), cryRpt.ParameterFields, cryRpt.Name, cryRpt.Database.ToString()));
                       
                        cryRpt.ReportOptions.EnableSaveDataWithReport = false;
                        //MessageBox.Show(String.Format("nach reportoptions"));
                       

                        //
                        // Set Logon to all SubReports
                        //
                        foreach (ReportDocument subreport in cryRpt.Subreports)
                        {
                            //MessageBox.Show(String.Format("SubReport: {0}; \n{1}; \n{2};\n {3};\n ", subreport.Name, subreport.Database.ToString(), subreport.ParameterFields.ToArray(), subreport.IsLoaded.ToString()));
                            //MessageBox.Show("blaa");
                            foreach (Table table in subreport.Database.Tables)
                            {
                                //MessageBox.Show(String.Format("Table: {0}; \n{1}; \n{2};\n {3};\n ", table.Name, table.LogOnInfo, table.Location,table.Fields));
                                TableLogOnInfo logOnInfo = table.LogOnInfo;
                                crtableLogoninfo = table.LogOnInfo;
                                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                                table.ApplyLogOnInfo(logOnInfo);
                                //MessageBox.Show(String.Format("CR Table Logon Info: {0}; \n{1}; \n{2};\n  ",crtableLogoninfo.TableName,crtableLogoninfo.ReportName,crtableLogoninfo.ConnectionInfo));
                            }
                        }
                        //
                        // Logon to Mainreport
                        //

                        foreach (Table table in cryRpt.Database.Tables)
                        {
                            //MessageBox.Show(String.Format("Table: {0}; \n{1}; \n{2};\n {3};\n ", table.Name, table.LogOnInfo, table.Location, table.Fields));

                            TableLogOnInfo logOnInfo = table.LogOnInfo;
                            crtableLogoninfo = table.LogOnInfo;

                            if (table.Name == "PSI_EXTREFS" ||
                                table.Name == "EXTREFERENCES" ||
                                table.Name == "PSI_PERSONEN" ||
                                table.Name == "PERSONEN")
                            {

                                crtableLogoninfo.ConnectionInfo = crConnectionInfoPVS;
                            }
                            else
                            {
                                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                            }
                            //txt_out.Text = txt_out.Text + "\r\n" + table.Name + "   " +
                            //    crtableLogoninfo.ConnectionInfo.ServerName + " " +
                            //    crtableLogoninfo.ConnectionInfo.UserID + " " +
                            //    crtableLogoninfo.ConnectionInfo.Password;

                            table.ApplyLogOnInfo(crtableLogoninfo);


                           
                             //MessageBox.Show(String.Format("CR Table Logon Info: {0}; \n{1}; \n{2};\n  ", crtableLogoninfo.TableName, crtableLogoninfo.ReportName, crtableLogoninfo.ConnectionInfo));
                           
                        }


                        //Sections crSections = cryRpt.ReportDefinition.Sections;
                        //foreach (Section crSection in crSections)
                        //{
                        //    ReportObjects crReportObjects = crSection.ReportObjects;
                        //    foreach (ReportObject crReportObject in crReportObjects)
                        //    {
                        //        if (crReportObject.Kind == ReportObjectKind.SubreportObject)
                        //        {
                        //            SubreportObject crSubreportObject = (SubreportObject)crReportObject;
                        //            ReportDocument crSubreport = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);
                        //            Database crDatabase = crSubreport.Database;
                        //            Tables crTables = crDatabase.Tables;

                        //            foreach (Table table in cryRpt.Database.Tables)
                        //            {
                        //                TableLogOnInfo logOnInfo = table.LogOnInfo;
                        //                crtableLogoninfo = table.LogOnInfo;
                        //                if (table.Name == "PSI_EXTREFS" ||
                        //                    table.Name == "EXTREFERENCES" ||
                        //                    table.Name == "PSI_PERSONEN" ||
                        //                    table.Name == "PERSONEN")
                        //                {

                        //                    crtableLogoninfo.ConnectionInfo = crConnectionInfoPVS;
                        //                }
                        //                else
                        //                {
                        //                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                        //                }
                        //                txt_out.Text = txt_out.Text + "\r\n" + table.Name + "   " +
                        //                    crtableLogoninfo.ConnectionInfo.ServerName + " " +
                        //                    crtableLogoninfo.ConnectionInfo.UserID + " " +
                        //                    crtableLogoninfo.ConnectionInfo.Password;


                        //                table.ApplyLogOnInfo(crtableLogoninfo);
                        //            }
                        //       }
                        //    }
                        //}

                        //
                        // open Crystal report Preview
                        //
                        cryRpt.SetDatabaseLogon(AKK_Helper.CrUser, AKK_Helper.CrPW);

                        // txt_out.Text = txt_out.Text + "\r\n\r\nReport is loaded . . . ";
                        //crystalReportViewer1.InitReportViewer();
                        //crystalReportViewer1.LogOnInfo[0].ConnectionInfo.IntegratedSecurity = true; 
                        

                        crystalReportViewer1.ReportSource = cryRpt;

                        //MessageBox.Show("cryrpt: " + cryRpt.ToString());
                        // txt_out.Text = txt_out.Text + "\r\nReport was loaded . . . ";
                        if (chk_50.Checked == true)
                        {
                            crystalReportViewer1.Zoom(50);
                        }
                        else
                        {
                            crystalReportViewer1.Zoom(100);
                        }
                        // txt_out.Text = txt_out.Text + "\r\nReport is started . . . ";
                        crystalReportViewer1.Refresh();
                        // txt_out.Text = txt_out.Text + "\r\nReport is finished . . . ";

                        strip_info.Text = "<" + str_name + "> wurde erfolgreich erstellt!";
                    }
                    catch (Exception ex)
                    {
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Datei <" + file + "> nicht gefunden!", strip_info, this.Cursor);
                }
                // Delete DB Entry
                //
                Boolean is_ok = Delete_Auswertung(str_vorlage_id);
             //MessageBox.Show("nach writedb delete");
                //
            }
            else
            {
                AKK_Helper.show_msg("Fehler WriteDB_Auswertung", strip_info, this.Cursor);
            }
            this.Cursor = Cursors.Default;
        }
       
       
        private void txt_offset_Leave(object sender, EventArgs e)
        {
            Int32 int_i = 0;
            Int32.TryParse(txt_offset.Text, out int_i);
            if (int_i > 100)
                int_i = 100;
            txt_offset.Text = int_i.ToString();
        }

        private void cmd_Log_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                crystalReportViewer1.Visible = !crystalReportViewer1.Visible;
                grp_1.Visible = !grp_1.Visible;
                lst_info_aw.Visible = !lst_info_aw.Visible;

                strip_info.Text = "";
                txt_offset.Text = "100";
                AKK_Helper.Init_lst_info(lst_info_aw);
                AKK_Helper.set_wbd(lst_info_aw, "LOG1", txt_offset.Text, strip_info, this.Cursor);
            }
        }
        private void chk_wbd_log_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_wbd(lst_info_aw, "LOG1", txt_offset.Text, strip_info, this.Cursor);
        }
        private void chk_CR_Log_Click(object sender, EventArgs e)
        {
             AKK_Helper.set_wbd(lst_info_aw, "AUS1", txt_offset.Text, strip_info, this.Cursor);
            // disabled 06-06-2011 by KJ !
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void lbl_tag_Click(object sender, EventArgs e)
        {

        }

        private void chk_100_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_50_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Error(object source, CrystalDecisions.Windows.Forms.ExceptionEventArgs e)
        {
        if (e.Exception is EngineException)
        {
            EngineException engEx = (EngineException)e.Exception;
            if (engEx.ErrorID == EngineExceptionErrorID.DataSourceError)
            {
                  e.Handled = true;
                AKK_Helper.show_msg("An error has occurred while connecting to the database.", strip_info, this.Cursor);
            }
            else
            {
            if (engEx.ErrorID == EngineExceptionErrorID.LogOnFailed)
                  {
                      e.Handled = true;
                      AKK_Helper.show_msg("Incorrect Logon Parameters. Check your user name and password.", strip_info, this.Cursor);
                }
            }
            AKK_Helper.show_msg(engEx.InnerException.ToString() , strip_info, this.Cursor);
        }    

        }

        private void cbo_Bereich_SelectedIndexChanged(object sender, EventArgs e)
        {
            DC_Columns cols = new DC_Columns();
            Response resp = new Response();
            DataService.DataServiceClient client = new DataService.DataServiceClient();
            string bereich = "";
            if (cbo_Bereich.SelectedIndex == 1) //ISH
            {
                bereich = "18";
                cb_gbv.Visible = true;
                lbl_gbv.Visible = true;
            }
            else if (cbo_Bereich.SelectedIndex == 0)//WBD
            {
                bereich = "2";
                cb_gbv.Visible = false;
                lbl_gbv.Visible = false;
            }

            try
            {
                resp = null;
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "VOR", bereich);
                //David Stefitz 09.11.2018
                if (resp.ResponseCode == 0)
                {
                    if (bereich == "18")
                    {

                        for (int i = 0; i < cols.Count; i++)
                        {
                            //cols[i].DM_col_01.Contains("Alle") || cols[i].DM_col_01.Contains(cb_gbv.SelectedItem.ToString())
                            if (cols[i].DM_col_01.ToString().Contains(cb_gbv.SelectedItem.ToString()) || cols[i].DM_col_01.ToString().Contains("Mahnung"))
                            {

                                

                            }
                            else if (cols[i].DM_col_02.ToString() == "216" || cols[i].DM_col_02.ToString() == "217" || cols[i].DM_col_02.ToString() == "218" || cols[i].DM_col_02.ToString() == "219")
                            {
                            }
                            else
                            {
                                cols.RemoveAt(i);
                                i--;
                            }

                        }
                    }
                    AKK_Helper.fill_Listbox(cbo_vorlage, cols);
                    AKK_Helper.fill_dgv(dgv_vorlage, cols);
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
                AKK_Helper.show_msg(AKK_Helper.str_error["CJ001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
            }

        }

        private void cb_gbv_Enter(object sender, EventArgs e)
        {
            lbl_gbv.ForeColor = AKK_Helper.c_get_focus;
        }

        private void cb_gbv_Leave(object sender, EventArgs e)
        {
            lbl_gbv.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cb_gbv_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_Bereich_SelectedIndexChanged(cbo_Bereich, EventArgs.Empty);
        }

        private void frm_Auswertung_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.cryRpt != null)
            {
                this.cryRpt.Close();
                this.cryRpt.Dispose();
            }
        }

        
       
        
    }  // Form
}      // Namespace

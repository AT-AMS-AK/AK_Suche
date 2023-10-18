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
    public partial class frm_Mahnlauf : Form
    {
        private string str_file = "";
        public bool ish;
        private Int32 int_reset;
        public frm_Mahnlauf()
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
        private void frm_Mahnlauf_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }
        private void frm_Mahnlauf_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        # endregion
        private void Mahnlauf_Load(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                AKK_Helper.FindControls(this);
                //
                // Disable textboxes
                //
                txt_M1.Enabled = false;
                txt_M2.Enabled = false;
                txt_M3.Enabled = false;
                txt_M4.Enabled = false;
                txt_RA.Enabled = false;
                txt_Tilg.Enabled = false;
                txt_Uber.Enabled = false;

                grp_1.Visible = false;
                grp_2.Visible = false;
                lst_info.Visible = false;

                Int32 intCRA = 0;
                Int32 intCTilg = 0;
                Int32 intCUber = 0;
                Int32 intCMST1 = 0;
                Int32 intCMST2 = 0;
                Int32 intCMST3 = 0;
                Int32 intCMST4 = 0;

                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();

                if (ish)
                {
                    resp = client.Read_MahnlaufISH(out intCRA,
                                               out intCTilg,
                                               out intCUber,
                                               out intCMST1,
                                               out intCMST2,
                                               out intCMST3,
                                               out intCMST4,
                                               out str_file,
                                               AKK_Helper.SessionToken,
                                               AKK_Helper.C.strG_Print_Temp);
                }
                else
                {
                    resp = client.Read_Mahnlauf(out intCRA,
                                               out intCTilg,
                                               out intCUber,
                                               out intCMST1,
                                               out intCMST2,
                                               out intCMST3,
                                               out intCMST4,
                                               out str_file,
                                               AKK_Helper.SessionToken,
                                               AKK_Helper.C.strG_Print_Temp);
                }

                
                if (resp.ResponseCode == 0)
                {
                    txt_M1.Text = intCMST1.ToString();
                    txt_M2.Text = intCMST2.ToString();
                    txt_M3.Text = intCMST3.ToString();
                    txt_M4.Text = intCMST4.ToString();
                    txt_RA.Text = intCRA.ToString();
                    txt_Tilg.Text = intCTilg.ToString();
                    txt_Uber.Text = intCUber.ToString();

                    strip_info.Text = "Daten vom letzten Mahnlauf gelesen";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    //AKK_Helper.handleServiceError(resp);
                    strip_info.Text = "Keine Einträge vom letzten Mahnlauf gefunden";
                    txt_M1.Text = "0";
                    txt_M2.Text = "0";
                    txt_M3.Text = "0";
                    txt_M4.Text = "0";
                    txt_RA.Text = "0";
                    txt_Tilg.Text = "0";
                    txt_Uber.Text = "0";
                }

                string str_info = "";
                resp = null;
                resp = client.Select_Mahnlauf(out str_info,
                                              AKK_Helper.SessionToken);
                if (resp.ResponseCode == 0)
                {
                    //strip_info.Text = str_info;
                    if (str_info != "")
                    {
                        strip_info.Text = str_info;
                        cmd_ML.Enabled = false;
                    }
                    else
                        cmd_ML.Enabled = true;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }

                int_reset = 0;
                this.Refresh();
                this.Cursor = Cursors.Default;
            }
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();

                resp = client.Delete_Mahnlauf(AKK_Helper.SessionToken,
                                               AKK_Helper.C.strMLPfad,
                                               str_file);
                if (resp.ResponseCode == 0)
                { }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                this.Cursor = Cursors.Default;

                this.Close();
            }
        }
        private void cmd_Liste_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                DocumentGeneration.Response resp = new DocumentGeneration.Response();
                DC_Columns cols = new DC_Columns();
                //DataService.DataServiceClient client = new DataServiceClient();
                DocumentGeneration.DocumentGenerationClient client = new DocumentGeneration.DocumentGenerationClient();
                resp = client.doSimplePrint(AKK_Helper.SessionToken, AKK_Helper.my_printer, str_file);
                //resp = client.Print_File(AKK_Helper.SessionToken, AKK_Helper.my_printer, str_file, AKK_Helper.C.strG_Print_Temp);

                if (resp.ResponseCode == 0)
                { }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                this.Cursor = Cursors.Default;
            }

        }
        private void cmd_ML_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                // 25-04-2012 by KJ 
                // Problem than Mahnlauf was called twice a day ( 25-04-2012 )
                //
                if (ish)
                {
                    if (MessageBox.Show("Wollen sie den ISH-Mahnlauf wirklich starten?", "ISH-Mahnlauf starten", MessageBoxButtons.YesNo) == DialogResult.Yes){
                        strip_info.Text = "ISH-Mahnlauf am " + DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                                       DateTime.Now.Hour.ToString("00") + " Uhr " +
                                                       DateTime.Now.Minute.ToString("00") + " gestartet ...";
                    do_Mahnlauf(AKK_Helper.UserId, true);
                    }
                    
                }else if (MessageBox.Show("Wollen sie den Mahnlauf wirklich starten?", "Mahnlauf starten", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    strip_info.Text = "Mahnlauf am " + DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                                       DateTime.Now.Hour.ToString("00") + " Uhr " +
                                                       DateTime.Now.Minute.ToString("00") + " gestartet ...";
                    do_Mahnlauf(AKK_Helper.UserId, false);
                }
            }
        }
        public  void do_Mahnlauf(String str_usernr, bool ish)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                cmd_Liste.Enabled = false;
                cmd_log.Enabled = false;
                cmd_ML.Enabled = false;
                cmd_schliessen.Enabled = false;

                if (AKK_Helper.checkLogin() == true)
                {
                    DataService.DataServiceClient client = new DataServiceClient();
                    if (ish)
                    {
                        client.ISHMahnlaufCompleted += ISHMahnlaufCompleted;
                        client.ISHMahnlaufAsync(AKK_Helper.SessionToken,
                                             str_usernr);
                    }
                    else
                    {
                        client.MahnlaufCompleted += MahnlaufCompleted;
                        client.MahnlaufAsync(AKK_Helper.SessionToken,
                                             str_usernr);
                    }
                }
            }
        }
        private void MahnlaufCompleted(object sender,DataService.MahnlaufCompletedEventArgs args)
        {

            this.Cursor = Cursors.Default;
            cmd_Liste.Enabled = true;
            cmd_log.Enabled = true;
            cmd_ML.Enabled = true;
            cmd_schliessen.Enabled = true;

            if (args.Result.ResponseCode == 0)
            {
                AKK_Helper.show_msg("Mahnlauf erfolgreich durchgeführt!", strip_info, this.Cursor);
                EventArgs e = new EventArgs();
                Mahnlauf_Load(sender, e);
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                   AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("Mahnlauf fehlerhaft! - " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }
        }

        private void ISHMahnlaufCompleted(object sender, DataService.ISHMahnlaufCompletedEventArgs args)
        {

            this.Cursor = Cursors.Default;
            cmd_Liste.Enabled = true;
            cmd_log.Enabled = true;
            cmd_ML.Enabled = true;
            cmd_schliessen.Enabled = true;

            if (args.Result.ResponseCode == 0)
            {
                AKK_Helper.show_msg("ISH-Mahnlauf erfolgreich durchgeführt!", strip_info, this.Cursor);
                EventArgs e = new EventArgs();
                Mahnlauf_Load(sender, e);
            }
            else
            {
                if (args.Result.ResponseCode >= 500 && args.Result.ResponseCode < 600)
                {
                    //Deaktiviert von David Stefitz
                    //AKK_Helper.SessionToken = null;
                }
                AKK_Helper.show_msg("ISH-Mahnlauf fehlerhaft! - " + args.Result.ResponseMsg, strip_info, this.Cursor);
            }
        }

        private void cmd_log_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                chk_wbd_log.Checked = false;
                chk_ML_Log.Checked = false;

                grp_2.Enabled = false;

                txt_offset.Text = "100";
                lst_info.Visible = !lst_info.Visible;
                grp_1.Visible = !grp_1.Visible;
                grp_2.Visible = !grp_2.Visible;

                lst_info.View = View.Details;
                lst_info.Font = new Font(lst_info.Font.FontFamily, AKK_Helper.FontSize);
                lst_info.GridLines = true;
                lst_info.LabelEdit = true;
                lst_info.AllowColumnReorder = true;
                lst_info.CheckBoxes = false;
                lst_info.FullRowSelect = true;

                if (grp_1.Visible == false)
                    strip_info.Text = "";

            }
        }
        private void chk_ML_Log_Click(object sender, EventArgs e)
        
        {
            set_ML();
            grp_2.Enabled = true;
            chk_ML1.Checked = false;
            chk_ML2.Checked = false;
            chk_ML3.Checked = false;
            chk_ML4.Checked = false;
            chk_ML5.Checked = false;
        }
        private void fill_ListInfo(string str_SQL, string str_Para)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                lst_info.Items.Clear();

                this.Cursor = Cursors.WaitCursor;
                strip_info.Text = "";
                resp = null;
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, str_SQL, str_Para);
                if (resp.ResponseCode == 0)
                {
                    Int32 int_ant_count = cols.Count;
                    for (Int32 i = 0; i < int_ant_count; i++)
                    {
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                        LVI_ORA.SubItems.Add(cols[i].DM_col_01.ToString());                     // 1
                        LVI_ORA.SubItems.Add(cols[i].DM_col_02.ToString());                      // 2
                        LVI_ORA.SubItems.Add(cols[i].DM_col_03.ToString());                      // 3
                        LVI_ORA.SubItems.Add(cols[i].DM_col_04.ToString());                      // 4
                        LVI_ORA.SubItems.Add(cols[i].DM_col_05.ToString());                      // 5

                        lst_info.Items.Add(LVI_ORA);
                        LVI_ORA = null;
                    }
                    strip_info.Text = int_ant_count.ToString() + " Datensätze gelesen";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                    strip_info.Text = "Fehler beim Lesen der Daten";
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void set_wbd()
        {
            lst_info.Clear();  // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 
            lst_info.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
            lst_info.Columns.Add("Key", 50, HorizontalAlignment.Left);                    // 01
            lst_info.Columns.Add("Timestamp", 140, HorizontalAlignment.Left);             // 02
            lst_info.Columns.Add("Programm", 150, HorizontalAlignment.Left);              // 03
            lst_info.Columns.Add("Fehlerbeschreibung", 300, HorizontalAlignment.Left);    // 04
            lst_info.Columns.Add("Statement", 900, HorizontalAlignment.Left);             // 05
        }
        private void set_ML()  //mal_key, mal_ts, mal_tc, mal_text
        {
            lst_info.Clear();  // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 
            lst_info.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
            lst_info.Columns.Add("Key", 50, HorizontalAlignment.Left);                    // 01
            lst_info.Columns.Add("Timestamp", 140, HorizontalAlignment.Left);             // 02
            lst_info.Columns.Add("TC", 100, HorizontalAlignment.Left);                    // 03
            lst_info.Columns.Add("Fehlerbeschreibung", 600, HorizontalAlignment.Left);    // 04
        }

        private void chk_wbd_log_Click(object sender, EventArgs e)
        {
            chk_ML1.Checked = false;
            chk_ML2.Checked = false;
            chk_ML3.Checked = false;
            chk_ML4.Checked = false;
            chk_ML5.Checked = false;

            set_wbd();
            grp_2.Enabled = false;
            fill_ListInfo("LOG1", txt_offset.Text);
        }
        private void chk_ML1_Click(object sender, EventArgs e)
        {
            fill_ListInfo("ML1", AKK_Helper.UserId);
        }
        private void chk_ML2_Click(object sender, EventArgs e)
        {
            fill_ListInfo("ML2", AKK_Helper.UserId);
        }
        private void chk_ML3_Click(object sender, EventArgs e)
        {

            string str_para = AKK_Helper.UserId + " and mal_key > (( select max(mal_key) from wbd_mahnlauf_log ) - " + txt_offset.Text + ")" ;
            fill_ListInfo("ML3", str_para);
        }
        private void chk_ML4_Click(object sender, EventArgs e)
        {
            fill_ListInfo("ML4", AKK_Helper.UserId);
        }
        private void chk_ML5_Click(object sender, EventArgs e)
        {
            fill_ListInfo("ML5", AKK_Helper.UserId);
        }

        private void txt_offset_Leave(object sender, EventArgs e)
        {
            Int32 int_i = 0;
            Int32.TryParse(txt_offset.Text, out int_i);
            if (int_i > 100)
                int_i = 100;
            txt_offset.Text = int_i.ToString();
        }
        private void chk_reset_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();

                if (int_reset == 0)
                {
                    string str_info = "";
                    resp = null;
                    resp = client.Select_Mahnlauf(out str_info,
                                                  AKK_Helper.SessionToken);
                    if (resp.ResponseCode == 0)
                    {
                        strip_info.Text = str_info;
                        if (str_info != "")
                        {
                            chk_reset.ForeColor = Color.Red;
                            int_reset = 1;
                        }
                        else
                        {
                            chk_reset.ForeColor = Color.Green;
                            int_reset = 0;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }


                }
                else
                {
                    resp = client.Reset_Mahnlauf(AKK_Helper.SessionToken);

                    if (resp.ResponseCode == 0)
                    {
                        strip_info.Text = "Mahnlauf zurückgesetzt";
                        cmd_ML.Enabled = true;
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }
                    int_reset = 0;
                    chk_reset.ForeColor = Color.Gray;
                }
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


        
      

    }                // Form
}                    // Namespace

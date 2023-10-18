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
    public partial class frm_Mahnstatus : Form
    {
        
        public string str_wbd_ikey;
        public string str_mahnstufe;

        public frm_Mahnstatus()

        {
            InitializeComponent();
        }

        private void frm_Mahnstatus_Load(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                AKK_Helper.FindControls(this);
                // labelDayDate.Text = System.DateTime.Today.DayOfWeek + ", " + System.DateTime.Today.Day + "-" + System.DateTime.Today.Month + "-" + System.DateTime.Today.Year;
                // read the current status of the specified keys
                lst_Mahnstatus.Clear();
                lst_Mahnstatus.Columns.Add("Index", -1, HorizontalAlignment.Left);                        // 00
                lst_Mahnstatus.Columns.Add("Mahnstufe", 100, HorizontalAlignment.Left);                   // 01
                lst_Mahnstatus.Columns.Add("Mahnung vom", 150, HorizontalAlignment.Left);                 // 02
                lst_Mahnstatus.Columns.Add("Mahnungsdurchläufe", 150, HorizontalAlignment.Left);          // 03
                lst_Mahnstatus.Columns.Add("Name", -1, HorizontalAlignment.Left);                          // 04

                lst_Mahnstatus.View = View.Details;
                lst_Mahnstatus.Font = new Font(lst_Mahnstatus.Font.FontFamily, AKK_Helper.FontSize);
                lst_Mahnstatus.GridLines = true;
                lst_Mahnstatus.LabelEdit = true;
                lst_Mahnstatus.AllowColumnReorder = true;
                lst_Mahnstatus.CheckBoxes = false;
                lst_Mahnstatus.FullRowSelect = true;

                DC_Columns cols = new DC_Columns();
                Response resp = null;
                DataService.DataServiceClient client = new DataServiceClient();
                Int32 int_col_count = 0;
                //
                // Fill Mahnstatus
                //
                resp = null;
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "MST1", str_mahnstufe);
                if (resp.ResponseCode == 0)
                {
                    AKK_Helper.fill_Listbox(cbo_Mahnstatus, cols);
                    AKK_Helper.fill_dgv(dgv_Mahnstatus, cols);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                //
                // Mahnungen
                //
                resp = null;
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "MST2", str_wbd_ikey);
                if (resp.ResponseCode == 0)
                {
                    int_col_count = cols.Count;
                    for (int i = 0; i < int_col_count; i++)
                    {

                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                        LVI_ORA.SubItems.Add(cols[i].DM_col_01);                                // 1 MST_TYP
                        LVI_ORA.SubItems.Add(AKK_Helper.set_date(cols[i].DM_col_02));           // 2 MST_DATUM
                        LVI_ORA.SubItems.Add(cols[i].DM_col_03);                                // 3 MST_ITERA

                        lst_Mahnstatus.Items.Add(LVI_ORA);
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
        private void frm_Mahnstatus_KeyUp(object sender, KeyEventArgs e)
        {
             AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Mahnstatus_Activated(object sender, EventArgs e)
        {
             AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
        }

        private void cmd_setzen_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                    this.Close();
                }
                else
                {
                    string str_date = DateTime.Now.Date.ToString("dd.MM.yyyy");
                    string str_D = str_date.Replace(".", "");
                    string str_itera = "1";

                    string str_code = cbo_Mahnstatus.SelectedValue.ToString();
                    string str_Text = AKK_Helper.ChangeDGVSel(str_code, 1, dgv_Mahnstatus);
                    string str_mst_ikey = AKK_Helper.ChangeDGVSel(str_code, 2, dgv_Mahnstatus);
                    string str_mst_code = AKK_Helper.ChangeDGVSel(str_code, 3, dgv_Mahnstatus).Trim();


                    Int32 lng_MSTikey = AKK_Helper.get_ID(11102);


                    //pDescs[0] = str_usernr;
                    //pDescs[1] = str_WBDIkey;
                    //pDescs[2] = str_MSTIkey;
                    //pDescs[3] = str_mst_ikey_c;
                    //pDescs[4] = str_mst_datum;
                    //pDescs[5] = str_mst_itera;
                    //pDescs[6] = str_mst_code_c;

                    this.Cursor = Cursors.WaitCursor;
                    DataService.DataServiceClient client = new DataServiceClient();
                    Addit.AK.WBD.AK_Suche.DataService.Response resp = client.Insert_Mahnstatus(AKK_Helper.SessionToken,
                                                                                             AKK_Helper.UserId,
                                                                                             str_wbd_ikey,
                                                                                             lng_MSTikey.ToString(),
                                                                                             str_mst_ikey,
                                                                                             str_D,
                                                                                             str_itera,
                                                                                             str_mst_code);

                    this.Cursor = Cursors.Default;
                    if (resp.ResponseCode == 0)
                    {
                        str_mahnstufe = str_mst_code;
                        this.Close();
                    }

                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }


                }
            }
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
      



    }    // Form
}        // Namespace



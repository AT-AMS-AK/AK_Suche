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
    public partial class frm_Urgenzen : Form
    {   // public values
        public string str_name;
        public string str_verwendungszweck;
        public string str_wbd_ikey;
        public string str_verwendungszweck_code;
        // private values
        private bool is_changed = false;
        private CheckBox[] CBx = new CheckBox[55];  // actual
        private DC_Columns cols = new DC_Columns();
        private Int32 int_count_urg = 0;

        public frm_Urgenzen()
        {
            InitializeComponent();
        }
        private void frm_Urgenzen_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);

            label1.Font = new Font(label1.Font.FontFamily, AKK_Helper.FontSizeFrm);
            label1.Height = (Int16)AKK_Helper.FontSizeFrm * 2;

            // checkBox42.Visible = false;

            txt_name.Text = str_name;
            txt_name.Enabled = false;
            txt_verwendungszweck.Text = str_verwendungszweck;
            txt_verwendungszweck.Enabled = false;
            # region checkboxes
            CBx[0] = checkBox0;
            CBx[1] = checkBox1;
            CBx[2] = checkBox2;
            CBx[3] = checkBox3;
            CBx[4] = checkBox4;
            CBx[5] = checkBox5;
            CBx[6] = checkBox6;
            CBx[7] = checkBox7;
            CBx[8] = checkBox8;
            CBx[9] = checkBox9;

            CBx[10] = checkBox10;
            CBx[11] = checkBox11;
            CBx[12] = checkBox12;
            CBx[13] = checkBox13;
            CBx[14] = checkBox14;
            CBx[15] = checkBox15;
            CBx[16] = checkBox16;
            CBx[17] = checkBox17;
            CBx[18] = checkBox18;
            CBx[19] = checkBox19;

            CBx[20] = checkBox20;
            CBx[21] = checkBox21;
            CBx[22] = checkBox22;
            CBx[23] = checkBox23;
            CBx[24] = checkBox24;
            CBx[25] = checkBox25;
            CBx[26] = checkBox26;
            CBx[27] = checkBox27;
            CBx[28] = checkBox28;
            CBx[29] = checkBox29;

            CBx[30] = checkBox30;
            CBx[31] = checkBox31;
            CBx[32] = checkBox32;
            CBx[33] = checkBox33;
            CBx[34] = checkBox34;
            CBx[35] = checkBox35;
            CBx[36] = checkBox36;
            CBx[37] = checkBox37;
            CBx[38] = checkBox38;
            CBx[39] = checkBox39;

            CBx[40] = checkBox40;
            CBx[41] = checkBox41;
            CBx[42] = checkBox42;
            CBx[46] = checkBox46;
            CBx[47] = checkBox47;
            CBx[48] = checkBox48;
            CBx[49] = checkBox49;

            #endregion

            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_speichern.Enabled = true;
            }
            else
            {
                cmd_speichern.Enabled =false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Urgenz_Urgenz_Speichern == AKK_Helper.c_Yes ) cmd_speichern.Enabled = true;
                }
            }

            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DataService.DataServiceClient client = new DataServiceClient();
                //
                // Fill Antragsstatus
                //
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "URG3", "");
                if (resp.ResponseCode == 0)
                {
                    Int32 int_index;
                    string str_Bezeichnung;
                    if (cols.Count > 0)
                    {
                        // code
                        // anz_bez
                        // akt
                        // index
                        // ikey
                        for (Int32 index = 0; index <= cols.Count - 1; index++)
                        {

                            //if (cols[index].DM_col_01 == str_verwendungszweck_code || cols[index].DM_col_01 == "ALL")

                           // {
                                Int32.TryParse(cols[index].DM_col_04, out int_index);
                                str_Bezeichnung = cols[index].DM_col_02;

                                CBx[int_index].Checked = false;
                                if (cols[index].DM_col_03 == "1")
                                {
                                    CBx[int_index].Visible = true;
                                    CBx[int_index].Text = str_Bezeichnung;
                                }
                                else
                                {
                                    CBx[int_index].Visible = false;
                                    CBx[int_index].Text = str_Bezeichnung;
                                }
                                if (AKK_Helper.is_empty(cols[index].DM_col_01.Trim()) == true)
                                {
                                    CBx[int_index].Enabled = false;
                                }
                            //}
                            //else
                            //{
                            //    Int32.TryParse(cols[index].DM_col_04, out int_index);
                            //    CBx[int_index].Enabled = false;
                            //    CBx[int_index].Visible = false;
                            //}
                        }
                        // 
                        DC_Columns cols1 = new DC_Columns();
                        client = new DataServiceClient();
                        resp = client.get_SQL_Data(out cols1, AKK_Helper.SessionToken, "URG4", str_wbd_ikey);
                        if (resp.ResponseCode == 0)
                        {
                            if (cols1.Count > 0)
                            {
                                // index
                                // flag
                                for (Int32 index = 0; index <= cols1.Count - 1; index++)
                                {
                                    Int32.TryParse(cols1[index].DM_col_01, out int_index);
                                    CBx[int_index].Checked = true;
                                }
                            }
                        }
                        else
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                        }
                        int_count_urg = cols1.Count;
                        strip_info.Text = int_count_urg.ToString() + " Urgenzen wurden gefunden!";
                    }
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
                is_changed = false;    // if <schliessen>
            }
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            if (is_changed == true)
                if (MessageBox.Show("Wollen sie die Änderungen speichern?", "Änderungen speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    cmd_speichern_Click(sender, e);
                }
            this.Close();
        }
        private void cmd_speichern_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                    return;
                }
                else
                {
                    Response resp = new Response();
                    DataService.DataServiceClient ClientBase = new DataServiceClient();
                    if (cols.Count > 0)
                    {
                        strip_info.Text = "Urgenzen werden gesichert";
                        this.Cursor = Cursors.WaitCursor;
                        //
                        // Delete actual Urgenzen
                        //
                        resp = ClientBase.Delete_Urgenz(AKK_Helper.SessionToken, str_wbd_ikey);
                        if (resp.ResponseCode != 0)
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.handleServiceError(resp);
                            return;
                        }
                        for (Int32 index = 0; index <= cols.Count - 1; index++)
                        {
                            // 
                            // Insert Urgenzen with upt_ikey
                            //
                            Int32 int_index = 0;
                            Int32.TryParse(cols[index].DM_col_04, out int_index);

                            if (CBx[int_index].Checked == true)
                            {
                                resp = ClientBase.Insert_Urgenz(AKK_Helper.SessionToken, str_wbd_ikey, cols[index].DM_col_05, cols[index].DM_col_04);
                                if (resp.ResponseCode != 0)
                                {
                                    this.Cursor = Cursors.Default;
                                    AKK_Helper.handleServiceError(resp);
                                }
                            }
                        }
                        this.Cursor = Cursors.Default;
                    }
                    this.Close();
                }
            }
        }
        private void CBx_changed(object sender, EventArgs e)
        {
            // Check CheckBoxX has changed
            is_changed = true;
            CheckBox c = (CheckBox) sender;
            if ( c.Checked == true )
                int_count_urg ++;
            else 
                int_count_urg --;

            strip_info.Text = int_count_urg.ToString() + " Urgenzen wurden selektiert!";
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
        private void frm_Urgenzen_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Urgenzen_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate,0);
        }

       


       
    }
}

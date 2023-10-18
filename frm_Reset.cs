using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Addit.AK.WBD.AK_Suche.DataService;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Reset : Form
    {
        // private AKK_Helper h = new AKK_Helper();
        private DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
        public frm_Reset()
        {
            InitializeComponent();
            
        }
/// <summary>
///  cmd_schliessen
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
    private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
/// <summary>
/// frm_Reset_Load
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void frm_Reset_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);

            

            if (AKK_Helper.checkLogin() == true)
            {
                load_Antrag(sender, e);
                
                opt_print.Checked = false;
                opt_user.Checked = true;

                cmd_load_Click(sender, e);
            }
            
        }

        private void cmd_load_Click(object sender, EventArgs e)
        {
            
            if (opt_user.Checked == true )
            {
                set_user_display();
                load_records("ANT3P");
               
            }
            else
            {
                set_printer_display();
                load_records("ANT3D");
            };
            this.Cursor = Cursors.Default;
        }
        private void cmd_update_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                    ListViewItem li = null;
                    txt_Output.Text = string.Empty;

                    strip_info.Text = lst_Output.SelectedItems.Count.ToString() + " Einträge wurden entsperrt";

                    for (int i = lst_Output.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        li = lst_Output.SelectedItems[i];
                        lst_Output.SelectedItems[i].Remove();
                        txt_Output.Text = txt_Output.Text + li.SubItems[3].Text.ToString() + "\r\n";
                        if (opt_user.Checked == true)
                        {
                            DataService.DataServiceClient client = new DataServiceClient();
                            Response resp = client.Unlock(AKK_Helper.SessionToken, "akf_antraege", li.SubItems[3].Text.ToString());

                            if (resp.ResponseCode != 0)
                            {
                                this.Cursor = Cursors.Default;
                                AKK_Helper.handleServiceError(resp);
                            }
                        }
                        else
                        {

                            string str_vorlage_id;
                            str_vorlage_id = li.SubItems[1].Text.ToString();
                            DataService.DataServiceClient ClientBase = new DataServiceClient();
                            Response resp = ClientBase.Delete_Auswertung(AKK_Helper.SessionToken, str_vorlage_id);
                            if (resp.ResponseCode != 0)
                            {
                                this.Cursor = Cursors.Default;
                               AKK_Helper.handleServiceError(resp);
                            }
                        }
                    }

            
               
            }
            lst_Output.Refresh();
        }

        private void load_records(string user_print)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.WaitCursor;
                // Int32 index = cbo_Bereich.SelectedIndex;            // --> Get Index
                // string X1 = cbo_Bereich.SelectedValue.ToString ();  // --> Get ValueMember
                // string x2 = cbo_Bereich.Text.ToString();            // --> Get DisplayMember

                try
                {

                    DC_Columns cols = new DC_Columns();
                    DataService.DataServiceClient client = new DataServiceClient();
                    Response resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, user_print, cbo_Bereich.SelectedValue.ToString());

                    if (resp.ResponseCode == 0)
                    {

                        Int32 int_col_count = cols.Count;
                        // txt_Output.Text = String.Empty;
                        lst_Output.Items.Clear();

                        strip_info.Text = int_col_count.ToString() + " gesperrte Einträge gefunden";

                        if (int_col_count > 0)
                        {

                            for (int i = 0; i < int_col_count; i++)
                            {
                                // txt_Output.Text = txt_Output.Text + cols[i].DM_col_01 + " " + cols[i].DM_col_02 + " " + cols[i].DM_col_03 + "\r\n";

                                ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                                LVI_ORA.SubItems.Add(cols[i].DM_col_01);           // 1
                                LVI_ORA.SubItems.Add(cols[i].DM_col_02);           // 2
                                if (user_print == "ANT3P")
                                {
                                    LVI_ORA.SubItems.Add(cols[i].DM_col_03);           // 3
                                    LVI_ORA.SubItems.Add(cols[i].DM_col_04);           // 4
                                }
                                else
                                {
                                    if ((cols[i].DM_col_03 != "") &&
                                       (cols[i].DM_col_03.Length > 10))
                                    {
                                        LVI_ORA.SubItems.Add(cols[i].DM_col_03.Substring(0,10));           // 3
                                    }

                                    if ((cols[i].DM_col_04 != "") &&
                                        (cols[i].DM_col_04.Length > 10))
                                    {
                                        LVI_ORA.SubItems.Add(cols[i].DM_col_04.Substring(0, 10));           // 3
                                    }
                                }
                                lst_Output.Items.Add(LVI_ORA);
                                LVI_ORA = null;
                            }
                        }
                        else
                        {
                            AKK_Helper.show_msg(AKK_Helper.str_error["FC002"], strip_info, this.Cursor);
                        }
                        statusStrip1.Text = int_col_count.ToString() + " gesperrte Datensätzer wurden gefunden!";
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
        private void load_Antrag(object sender, EventArgs e)
        {

            try
            {
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataService.DataServiceClient();
                Response resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "ANT3", "");

                if (resp.ResponseCode == 0)
                {
                    Int32 int_col_count = cols.Count;
                    AKK_Helper.fill_Listbox(cbo_Bereich, cols);
                    // load Listbox
                    //cmd_load_Click(sender, e);
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
        
        private void set_user_display()
        {
        lst_Output.Clear();
            lst_Output.Columns.Add("Index", -1, HorizontalAlignment.Left);                     // 00
            lst_Output.Columns.Add("ID", 150, HorizontalAlignment.Left);                      // 01
            lst_Output.Columns.Add("Lock", 150, HorizontalAlignment.Left);                    // 02
            lst_Output.Columns.Add("Key", 150, HorizontalAlignment.Left);                     // 03
            lst_Output.Columns.Add("Darlehensnummer", 150, HorizontalAlignment.Left);         // 04

            lst_Output.View = View.Details;
            lst_Output.Font = new Font(lst_Output.Font.FontFamily, AKK_Helper.FontSize);
            lst_Output.GridLines = true;
            lst_Output.LabelEdit = true;
            lst_Output.AllowColumnReorder = true;
            lst_Output.CheckBoxes = false;
            lst_Output.FullRowSelect = true;
            lst_Output.MultiSelect = true;
        }
        private void set_printer_display()
        {
            lst_Output.Clear();
            lst_Output.Columns.Add("Index", -1, HorizontalAlignment.Left);                     // 00
            lst_Output.Columns.Add("ID", 40, HorizontalAlignment.Left);                      // 01
            lst_Output.Columns.Add("Name der Auswertung", 500, HorizontalAlignment.Left);                    // 02
            lst_Output.Columns.Add("Von Datum", 87, HorizontalAlignment.Left);                     // 03
            lst_Output.Columns.Add("Bis Datum", 87, HorizontalAlignment.Left);         // 04

            lst_Output.View = View.Details;
            lst_Output.Font = new Font(lst_Output.Font.FontFamily, AKK_Helper.FontSize);
            lst_Output.GridLines = true;
            lst_Output.LabelEdit = true;
            lst_Output.AllowColumnReorder = true;
            lst_Output.CheckBoxes = false;
            lst_Output.FullRowSelect = true;
            lst_Output.MultiSelect = true;
        }
        private void opt_user_Enter(object sender, EventArgs e)
        {

            if (opt_user.Checked == false)
            {
                opt_print.Checked = false;
                opt_user.Checked = true;
                cmd_load_Click(sender, e);

            }
        }
        private void opt_print_Enter(object sender, EventArgs e)
        {
            if (opt_print.Checked == false)
            {
                opt_print.Checked = true;
                opt_user.Checked = false;
                cmd_load_Click(sender, e);
            }
        }



        private void frm_Reset_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate,1);
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
        private void frm_Reset_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }

        



       

      
       
           
    }  // Class
}      // Namespace

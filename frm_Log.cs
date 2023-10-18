using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Log : Form
    {
        public frm_Log()
        {
            InitializeComponent();
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
        private void frm_Log_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }
        private void frm_Log_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void frm_Log_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);
            txt_offset.Text = "100";
            AKK_Helper.Init_lst_info(lst_info);
        }
        //private void set_wbd()
        //{
        //    lst_info.Clear();  // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 
        //    lst_info.Columns.Add("Index", 00, HorizontalAlignment.Left);                  // 00
        //    lst_info.Columns.Add("Key", 40, HorizontalAlignment.Left);                    // 01
        //    lst_info.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);             // 02
        //    lst_info.Columns.Add("Programm", 170, HorizontalAlignment.Left);              // 03
        //    lst_info.Columns.Add("Fehlerbeschreibung", 300, HorizontalAlignment.Left);    // 04
        //    lst_info.Columns.Add("Statement", 900, HorizontalAlignment.Left);             // 05
        //}
        //private void set_ML()  //mal_key, mal_ts, mal_tc, mal_text
        //{
        //    lst_info.Clear();  // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 
        //    lst_info.Columns.Add("Index", 00, HorizontalAlignment.Left);                  // 00
        //    lst_info.Columns.Add("Key", 40, HorizontalAlignment.Left);                    // 01
        //    lst_info.Columns.Add("Timestamp", 300, HorizontalAlignment.Left);             // 02
        //    lst_info.Columns.Add("TC", 100, HorizontalAlignment.Left);                    // 03
        //    lst_info.Columns.Add("Fehlerbeschreibung", 600, HorizontalAlignment.Left);    // 04
        //}

       
        private void opt_DG_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_wbd(lst_info, "DG1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void txt_offset_Leave(object sender, EventArgs e)
        {
            Int32 int_i = 0;
            Int32.TryParse(txt_offset.Text, out int_i);
            if (int_i > 100)
                int_i = 100;
            txt_offset.Text = int_i.ToString();
        }

        private void opt_DA_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "DT1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_BC_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "BC1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_DE_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "DT2", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_AU_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "AUS1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_EX_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "EX1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_AD_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "DT3", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_AP_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_not_wbd(lst_info, "AP1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void opt_Error_Click(object sender, EventArgs e)
        {
            AKK_Helper.set_wbd(lst_info, "LOG1", txt_offset.Text, strip_info, this.Cursor);
        }

        private void cmd_print_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (AKK_Helper.Print_LST_Box(lst_info, -1, 10, 22, 0, 0) == true)
                {
                    AKK_Helper.show_msg("Druck erfolgreich  beendet!", strip_info, this.Cursor);
                }
            }
        }

        
    }
}

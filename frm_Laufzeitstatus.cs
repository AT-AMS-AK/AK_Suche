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
    public partial class frm_Laufzeitstatus : Form
    {
        // public values
        public string str_wbd_ikey;          // WBD _ Ikey
        public string rueckbisreal;          // Rueck Bis real 
        public string rueckab;               // Rückzahlungsdatum des DL
        public string Tilgungstext;          // neue Tilgungstext
        public string RueckBisVertr;         // Real Vetraglich
        public Int32  Laufzeit;              // Laufzeit
        public Double Rate;                  // Rate
        public Double Kosten;                // Kosten 
        public string Tilgstand;             // Tilgungsstand
        public string Betrag;                // Betrag
        public Boolean ish;                  // ISH oder WBD
        //     
        // private values
        private string str_AusCode;    // selected Status in Ccbo_Aussetzungen
        private string str_AusKey;
        private Boolean is_changed = false;
        public frm_Laufzeitstatus()
        {
            InitializeComponent();
        }
        //
        //
        // Methods
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
        private void frm_Laufzeitstatus_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Laufzeitstatus_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate,0);
           
        }

        private void Laufzeitstatus_Load(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                AKK_Helper.FindControls(this);

                label1.Font = new Font(label1.Font.FontFamily, AKK_Helper.FontSizeFrm);

                txt_output.Visible = false;
                mtxt_RAB.Visible = false;

                mtxt_von.Mask = @"00\.00\.0000";
                mtxt_bis.Mask = @"00\.00\.0000";
                mtxt_Rueckbis.Mask = @"00\.00\.0000";
                mtxt_RAB.Mask = @"00\.00\.0000";
                dgv_Aussetzungen.Visible = false;

                mtxt_RAB.Enabled = false;
                mtxt_RAB.Text = rueckab;

                txt_betrag.Text = AKK_Helper.FormatBetrag("0");

                lst_output.Clear();
                lst_output.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
                lst_output.Columns.Add("Status", 300, HorizontalAlignment.Left);               // 01
                lst_output.Columns.Add("von", 85, HorizontalAlignment.Left);                   // 02
                lst_output.Columns.Add("bis", 85, HorizontalAlignment.Left);                   // 03

                lst_output.View = View.Details;
                lst_output.Font = new Font(lst_output.Font.FontFamily, AKK_Helper.FontSize);
                lst_output.GridLines = true;
                lst_output.LabelEdit = true;
                lst_output.AllowColumnReorder = true;
                lst_output.CheckBoxes = false;
                lst_output.FullRowSelect = true;
                //
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                //
                this.Cursor = Cursors.WaitCursor;
                //
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "TIL2", "");
                if (resp.ResponseCode == 0)
                {
                    if (ish)
                    {
                        DC_Columns c = new DC_Columns();
                        for (int i = 0; i < cols.Count; i++)
                        {
                            if (cols[i].DM_col_03.ToString().Contains("AMV"))
                            {
                                c.Add(cols[i]);
                            }
                        }
                        cols = c;
                    }
                    AKK_Helper.fill_Listbox(cbo_Aussetzungen, cols);
                    AKK_Helper.fill_dgv(dgv_Aussetzungen, cols);

                    resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "TIL3", str_wbd_ikey);
                    if (resp.ResponseCode == 0)
                    {
                        Int32 i = 0;
                        for (Int32 index = 0; index < cols.Count; index++)
                        {
                            ListViewItem LVI_ORA = new ListViewItem(i.ToString());
                            //
                            LVI_ORA.SubItems.Add(cols[index].DM_col_01);                                         // 1 
                            LVI_ORA.SubItems.Add(cols[index].DM_col_02.ToString().Substring(0, 10));             // 2 
                            LVI_ORA.SubItems.Add(cols[index].DM_col_03.ToString().Substring(0, 10));             // 3 
                            //                      
                            lst_output.Items.Add(LVI_ORA);
                            i++;
                            LVI_ORA = null;
                        }
                        strip_info.Text = "Es wurden " + cols.Count.ToString().Trim() + " Einträge gefunden";
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

                this.Cursor = Cursors.Default;
            }
        }
        //
        // Betrag
        //
        private void txt_betrag_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = AKK_Helper.format_input_number(sender, e, txt_betrag.Text.ToString());
        }
        private void txt_betrag_Leave(object sender, EventArgs e)
        {  //{ }
            double Betrag;
            if (Double.TryParse(txt_betrag.Text, out Betrag) == true )
            {
                txt_betrag.Text = AKK_Helper.FormatBetrag(txt_betrag.Text);
                label4.ForeColor = AKK_Helper.c_lost_focus;
            }
            else
            {
                AKK_Helper.show_msg("Kein gültiger Betrag!", strip_info, this.Cursor);
                txt_betrag.Focus();
                txt_betrag.SelectAll();
                return;
            }
        }
        private void txt_betrag_Enter(object sender, EventArgs e)
        {
            label4.ForeColor = AKK_Helper.c_get_focus;
            txt_betrag.SelectAll();
        }
        //
        // RückBis
        //
        private void mtxt_Rueckbis_Leave(object sender, EventArgs e)
        {//{ }
            if ( AKK_Helper .is_empty_date ( mtxt_Rueckbis.Text ) == false )
            { 
                if (AKK_Helper.is_date(mtxt_Rueckbis.Text) == true)
                { 
                if ( AKK_Helper.is_empty_date(mtxt_bis.Text) == false)
                    {
                        DateTime dt_rbis;
                        DateTime dt_bis;
                        DateTime.TryParse(mtxt_Rueckbis.Text, out dt_rbis);     // rueckab vom DL als Parameter
                        DateTime.TryParse(mtxt_von.Text, out dt_bis);
                        System.TimeSpan diffResult = dt_rbis.Subtract(dt_bis);
                        // Int32 intAnzahlTage = diffResult.Days;    // in Tagen !!!                            
                        if (diffResult.Days <= 0)
                        {
                            AKK_Helper.show_msg("Die Rückzahlung muss nach der Verlängerung sein! " + mtxt_Rueckbis.Text, strip_info, this.Cursor);
                            mtxt_Rueckbis.Focus();
                            mtxt_Rueckbis.SelectAll();
                            return;
                        }
                }

                if (AKK_Helper.is_empty_date(rueckab) == false)
                {
                    DateTime dt_rab;
                    DateTime dt_rbis;
                    DateTime.TryParse(rueckab, out dt_rab);     // rueckab vom DL als Parameter
                    DateTime.TryParse(mtxt_Rueckbis.Text, out dt_rbis);
                    System.TimeSpan diffResult = dt_rbis.Subtract(dt_rab);
                    // Int32 intAnzahlTage = diffResult.Days;    // in Tagen !!!                            
                    if (diffResult.Days <= 0)
                    {
                        AKK_Helper.show_msg("Die Rückzahlung der Aussetzung muss nach dem Rückzahlunsgbeginn für das Darlehen liegen! " + mtxt_Rueckbis.Text, strip_info, this.Cursor);
                        mtxt_von.Focus();
                        mtxt_von.SelectAll();
                        return;
                    }
                }
                }
                else
                {
                    AKK_Helper.show_msg("Es wurde kein gültiges Datum eingegeben! " + mtxt_Rueckbis.Text, strip_info, this.Cursor);
                    mtxt_Rueckbis.Focus();
                    mtxt_Rueckbis.SelectAll();
                    return;
                }
            }



            label5.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_Rueckbis_Enter(object sender, EventArgs e)
        {
            label5.ForeColor = AKK_Helper.c_get_focus;
        }
        //
        // Von
        //
        private void mtxt_von_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_von.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_von.Text) == true)
                //{ }
                {
                    Int32 int_day;
                    Int32.TryParse(mtxt_von.Text.Substring(0, 2), out int_day);
                    if (int_day != 1 && !ish)
                    {
                        AKK_Helper.show_msg("Es wird nur der Erste eines Monats akzeptiert! " + mtxt_von.Text, strip_info, this.Cursor);
                        mtxt_von.Focus();
                        mtxt_von.Text =  "01" + (mtxt_von.Text.Substring(3, 7));
                        mtxt_von.SelectAll();
                        return;
                    }
                    else
                    {
                        if (AKK_Helper.is_empty_date(mtxt_bis.Text) == false)
                        {
                            DateTime dt_von;
                            DateTime dt_bis;
                            DateTime.TryParse(mtxt_von.Text, out dt_von);     // rueckab vom DL als Parameter
                            DateTime.TryParse(mtxt_bis.Text, out dt_bis);
                            System.TimeSpan diffResult = dt_bis.Subtract(dt_von);
                            // Int32 intAnzahlTage = diffResult.Days;    // in Tagen !!!                            
                            if (diffResult.Days <= 0)
                            {
                                AKK_Helper.show_msg("Von-Datum muss kleiner sein als das Bis-Datum " + mtxt_von.Text, strip_info, this.Cursor);
                                mtxt_von.Focus();
                                mtxt_von.SelectAll();
                                return;
                            }
                        }
                    }
                    if (AKK_Helper.is_empty_date(rueckab) == false)
                    {
                        DateTime dt_rab;
                        DateTime dt_ab;
                        DateTime.TryParse(rueckab, out dt_rab);     // rueckab vom DL als Parameter
                        DateTime.TryParse(mtxt_von.Text, out dt_ab);
                        System.TimeSpan diffResult = dt_ab.Subtract(dt_rab);
                        // Int32 intAnzahlTage = diffResult.Days;    // in Tagen !!!                            
                        if (diffResult.Days <= 0)
                        {
                            AKK_Helper.show_msg("Der Anfang der Aussetzung muss nach dem Rückzahlungsbeginn für das Darlehen liegen! " + mtxt_von.Text, strip_info, this.Cursor);
                            mtxt_von.Focus();
                            mtxt_von.SelectAll();
                            return;
                        }
                    }
                }
                else
                {
                    AKK_Helper.show_msg("Es wurde kein gültiges Datum eingegeben! " + mtxt_von.Text, strip_info, this.Cursor);
                    mtxt_von.Focus();
                    mtxt_von.SelectAll();
                    return;
                }
            }

            label2.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_von_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
        }
        //
        // Bis
        //
        private void mtxt_bis_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
        }
        private void mtxt_bis_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_bis.Text) == false)
            {
            if ( AKK_Helper.is_date(mtxt_bis.Text) == true)
                //{ }
                {
                    Int32 int_day;
                    Int32.TryParse(mtxt_bis.Text.Substring(0, 2), out int_day);
                    if ( int_day != 1 && !ish )
                    {
                        AKK_Helper.show_msg("Es wird nur der Erste eines Monats akzeptiert! " + mtxt_bis.Text, strip_info, this.Cursor);
                        mtxt_bis.Focus();
                        mtxt_bis.Text =  "01" + (mtxt_bis.Text.Substring(3, 7));
                        mtxt_bis.SelectAll();

                        return;
                    }
                    else
                    {
                        if (AKK_Helper.is_empty_date(mtxt_von.Text) == false)
                        { 
                            DateTime dt_von;
                            DateTime dt_bis;
                            DateTime.TryParse(mtxt_von.Text, out dt_von);     // rueckab vom DL als Parameter
                            DateTime.TryParse(mtxt_bis.Text, out dt_bis);
                            System.TimeSpan diffResult = dt_bis.Subtract(dt_von);
                            // Int32 intAnzahlTage = diffResult.Days;    // in Tagen !!!                            
                            if (diffResult.Days <= 0)
                            {
                                AKK_Helper.show_msg("Von-Datum muss kleiner sein als das Bis-Datum " + mtxt_bis.Text, strip_info, this.Cursor);
                                mtxt_bis.Focus();
                                mtxt_bis.SelectAll();
                                return;
                            }
                        }
                    }
                    if (AKK_Helper.is_empty_date(rueckab) == false)
                    { 
                        DateTime  dt_rab;
                        DateTime  dt_bis;
                        DateTime.TryParse(rueckab, out dt_rab);     // rueckab vom DL als Parameter
                        DateTime.TryParse(mtxt_bis .Text, out dt_bis);
                        System.TimeSpan diffResult = dt_bis.Subtract(dt_rab);
                        // Int32 intAnzahlTage = diffResult.Days;    // in Tagen !!!                            
                        if ( diffResult.Days <= 0 )
                        {
                            AKK_Helper.show_msg("Das Ende der Aussetzung muss nach dem Rückzahlungsbeginn für das Darlehen liegen! " + mtxt_bis.Text, strip_info, this.Cursor);
                            mtxt_bis.Focus();
                            mtxt_bis.SelectAll();
                            return; 
                        }
                   }     
                }
            else
                {
                    AKK_Helper.show_msg("Es wurde kein gültiges Datum eingegeben! " + mtxt_bis.Text, strip_info, this.Cursor);
                    mtxt_bis.Focus();
                    mtxt_bis.SelectAll();
                    return;
                }
            }
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            if (frm_wbd_antrag.is_locked == false)
            {
                if (is_changed == true)
                    if (MessageBox.Show("Wollen sie die Änderungen speichern?", "Änderungen speichern", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        cmd_speichern_Click(sender, e);
                    }
            }
            this.Close();
        }
        private void cmd_speichern_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DataServiceClient client = new DataServiceClient();

                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                    return;
                }
                else
                {
                    if ((AKK_Helper.is_empty_date(mtxt_von.Text) == false) && (AKK_Helper.is_empty_date(mtxt_bis.Text) == false))
                    {
                        Double dbl_Betrag = 0;
                        str_AusCode = AKK_Helper.ChangeDGVSel(cbo_Aussetzungen.SelectedValue.ToString(), 3, dgv_Aussetzungen);
                        str_AusKey = cbo_Aussetzungen.SelectedValue.ToString();
                        Double.TryParse(txt_betrag.Text, out dbl_Betrag);


                        if ((str_AusCode == AKK_Helper.C.strTILG_O_LZV) && (AKK_Helper.is_empty_date(mtxt_Rueckbis.Text) == true))
                        {
                            this.Cursor = Cursors.Default;
                            AKK_Helper.show_msg("Auch das Datum für die Rückzahlung muss eingegeben werden!", strip_info, this.Cursor);
                            return;
                        }
                        else
                        {
                            if ((str_AusCode == AKK_Helper.C.strSENK_O_LZV) && (AKK_Helper.is_empty_date(mtxt_Rueckbis.Text) == true || dbl_Betrag == 0))
                            {
                                this.Cursor = Cursors.Default;
                                AKK_Helper.show_msg("Es muss auch das Datum für die Rückzahlung sowie die gesenkte Rate eingegeben werden!", strip_info, this.Cursor);
                                if (AKK_Helper.is_empty_date(mtxt_Rueckbis.Text) == true)
                                {
                                    mtxt_Rueckbis.Focus();
                                }
                                else
                                {
                                    if (dbl_Betrag == 0)
                                        txt_betrag.Focus();
                                }
                                return;
                            }
                            else
                            {
                                if ((str_AusCode == AKK_Helper.C.strSENK_M_LZV) && (dbl_Betrag == 0))
                                {
                                    this.Cursor = Cursors.Default;
                                    AKK_Helper.show_msg("Es muss der Betrag für die gesenkte Rate eingegeben werden!", strip_info, this.Cursor);
                                    txt_betrag.Focus();
                                    return;
                                }
                                else
                                {
                                    //Insert_Tilgungsstatus(string sessionToken,
                                    //            string str_tgs_ikey,
                                    //            string str_wbd_ikey,
                                    //            string str_lzs_ikey_c,
                                    //            string str_von,
                                    //            string str_bis,
                                    //            string str_rst_bis,
                                    //            string tgs_betrag,
                                    //            string str_user);
                                    // Insert record  
                                    resp = new Response();
                                    client = new DataServiceClient();
                                    resp = client.Insert_Tilgungsstatus(AKK_Helper.SessionToken,
                                                                        str_wbd_ikey,
                                                                        str_AusKey,
                                                                        mtxt_von.Text,
                                                                        mtxt_bis.Text,
                                                                        mtxt_Rueckbis.Text,
                                                                        txt_betrag.Text,
                                                                        AKK_Helper.UserId);
                                    if (resp.ResponseCode == 0)
                                    {
                                        //
                                        // Calculate Real Darlehen Ende
                                        //
                                        string Get_DLEnd_Real;
                                        resp = client.Get_DLEnd_Reals(out Get_DLEnd_Real,
                                                                      AKK_Helper.SessionToken,
                                                                      rueckab,
                                                                      RueckBisVertr,
                                                                      Laufzeit,
                                                                      Rate,
                                                                      Kosten,
                                                                      str_wbd_ikey);

                                        if (Get_DLEnd_Real.Length > 10)
                                            Get_DLEnd_Real = Get_DLEnd_Real.Substring(0, 10);

                                        if (resp.ResponseCode == 0)
                                        {
                                            resp = new Response();
                                            resp = client.Get_Info_Status(out Tilgungstext,
                                                                           AKK_Helper.SessionToken,
                                                                           str_wbd_ikey,
                                                                           Get_DLEnd_Real);
                                            if (resp.ResponseCode == 0)
                                            {
                                                //
                                                // Update WBD_Data Bis real
                                                //

                                                resp = new Response();
                                                resp = client.Update_WBD_Data_Bis_Real(AKK_Helper.SessionToken,
                                                                                        str_wbd_ikey,
                                                                                        Get_DLEnd_Real);
                                                if (resp.ResponseCode == 0)
                                                {
                                                    Double Tilgungs_status;
                                                    resp = new Response();
                                                    resp = client.Get_Akt_TilgungsST(out Tilgungs_status,
                                                                                     AKK_Helper.SessionToken,
                                                                                     str_wbd_ikey,
                                                                                     Rate.ToString(),
                                                                                     rueckab,
                                                                                     rueckbisreal,
                                                                                     Kosten.ToString(),
                                                                                     Betrag,
                                                                                     ish);

                                                    rueckbisreal = Get_DLEnd_Real;
                                                    Tilgstand = Tilgungs_status.ToString();


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
                                                Tilgungstext = "";
                                            }
                                        }
                                        else
                                        {
                                            this.Cursor = Cursors.Default;
                                            AKK_Helper.handleServiceError(resp);
                                            Get_DLEnd_Real = "";
                                        }

                                    }
                                    else
                                    {
                                        this.Cursor = Cursors.Default;
                                        AKK_Helper.handleServiceError(resp);
                                    }



                                }
                            }

                        }

                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.show_msg("Zumindest das Von und Bis-Datum einer Laufzeitaussetzung müssen angegeben werden!", strip_info, this.Cursor);
                        return;
                    }




                    this.Close();
                }
            }
        }
        private void Content_Changed(object sender, EventArgs e)
        {
            is_changed = true;
            
        }
       

        private void cbo_Aussetzungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Text
            // str_code = cbo_Aussetzungen.GetItemText(cbo_Aussetzungen.SelectedItem);            
            // Value
            // str_code = cbo_Aussetzungen.SelectedValue.ToString()
            //
            is_changed = true;
            str_AusCode = AKK_Helper.ChangeDGVSel (cbo_Aussetzungen.SelectedValue.ToString(), 3, dgv_Aussetzungen);
            //
            mtxt_Rueckbis.Enabled = false;
            txt_betrag.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;

            if (str_AusCode == AKK_Helper.C.strTILG_O_LZV)
            {
                mtxt_Rueckbis.Enabled = true;
                label5.Enabled = true;
            
            }
            if (str_AusCode == AKK_Helper.C.strSENK_O_LZV)
            {
                mtxt_Rueckbis.Enabled = true;
                label5.Enabled = true;
                txt_betrag.Enabled = true;
                label4.Enabled = true;
            }
            if (str_AusCode == AKK_Helper.C.strSENK_M_LZV)
            {
                txt_betrag.Enabled = true;
                label4.Enabled = true;
            }

            txt_output.Text = str_AusCode + "   " + rueckab;
            this.Refresh();
        }

        private void mtxt_bis_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }


       


    


      


    }   // Class
}       // Namespace

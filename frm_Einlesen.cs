using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Einlesen : Form
    {
        private string str_now;
        private string str_now_minus1;
        private string[] str_Copyfiles;
        public frm_Einlesen()
        {
            InitializeComponent();
        }

        private void frm_Einlesen_Load(object sender, EventArgs e)
        {

            AKK_Helper.FindControls(this);

            lst_files.View = View.Details;
            lst_files.Font = new Font(lst_files.Font.FontFamily, AKK_Helper.FontSize);
            lst_files.GridLines = true;
            lst_files.LabelEdit = true;
            lst_files.AllowColumnReorder = true;
            lst_files.CheckBoxes = false;
            lst_files.FullRowSelect = true;
            lst_files.MultiSelect = false;
            lst_files.Items.Clear();
            lst_files.Clear();          // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 

            lst_files.Columns.Add("Index", 30,  HorizontalAlignment.Left);                     // 00
            lst_files.Columns.Add("Files", 400, HorizontalAlignment.Left);                     // 01

            mtxt_buch_dat.Mask = @"00\.00\.0000";

            //lbl_dtt_dir_ori.Text = ""; //- reserviert für Pfanangabe
            //lbl_dtt_dir_sav.Text = ""; //- reserviert für Pfanangabe
            //lbl_dtt_dir_pro.Text = ""; //- reserviert für Pfanangabe

            chk_dauerauftrag.Checked = true;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_get_focus;
            txt_file.Enabled = false;
            cmd_einlesen.Enabled = false;

            DateTime dat_now = DateTime.Now.Date;
            DateTime dat_now_minus1 = dat_now.AddDays(-1);
            str_now = dat_now.ToString("dd.MM.yyyy");
            str_now_minus1 = dat_now_minus1.ToString("dd.MM.yyyy");

            Boolean is_true = true;
            string str_pFile = "PROT_" + str_now;
            string str_cFile = "SAVE_" + str_now;
            Int16 i = 1;
            while (is_true == true)
            {
                if (System.IO.File.Exists(str_pFile + ".txt"))
                {
                    str_pFile = str_pFile + i.ToString();
                }
                else
                {
                    str_pFile = str_pFile + ".txt";
                    is_true = false;
                }
                i++;
            }
            txt_file.Text = str_pFile;
            txt_kopie.Text = str_cFile;
            mtxt_buch_dat.Text = str_now_minus1;
            //
            // Einlesen der Files
            // Methode mit list []
            // data dir
            // save dir
            // prot dir
        


            // cmd_bearbeiten.Enabled = false;
            // cmd_schliessen.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            if (AKK_Helper.checkLogin() == true)
            {

                Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response resp = new Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response();
                BankRecordCarrier.BankRecordCarrierClient client = new BankRecordCarrier.BankRecordCarrierClient();
                string[] str_files;

                resp = client.getBankRecordCarriers(out str_files, AKK_Helper.SessionToken);

                strip_info.Text = "Datenträgerfiles einlesen" +
                                  DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                                  DateTime.Now.Hour.ToString("00") + " Uhr " +
                                  DateTime.Now.Minute.ToString("00") + " gestartet ...";

                i = 0;
                if (resp.ResponseCode == 0)
                {

                    foreach (string str_file in str_files)
                    {
                        i++;
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                        LVI_ORA.SubItems.Add(str_file);                      // 1
                        lst_files.Items.Add(LVI_ORA);
                        LVI_ORA = null;
                    }
                    strip_info.Text = string.Format("{0} Dateien gefunden ", i);
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }

                this.Cursor = Cursors.Default;

                
                Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response resp1 = new Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response();
                BankRecordCarrier.BankRecordCarrierClient client1 = new BankRecordCarrier.BankRecordCarrierClient();
                

                resp = client.getCopyfiles(out str_Copyfiles, AKK_Helper.SessionToken);


                //i = 0;
                //DirectoryInfo di = new DirectoryInfo(@"C:\Juergen\NWDB\Daten");
                //FileInfo[] rgFiles = di.GetFiles("*.*");
                //foreach (FileInfo fi in rgFiles)
                //{
                //    i++;
                //    ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                //    LVI_ORA.SubItems.Add(fi.Name);                      // 1
                //    lst_files.Items.Add(LVI_ORA);
                //    LVI_ORA = null;
                // }
                //
                // Ende Files einlesen
                //

                //string[] str_list = new string[3] { "*.*", "*.wbd", "*.doc" };

                //i = 0;
                //foreach (string str in str_list)
                //{
                //    i++;
                //    ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                //    LVI_ORA.SubItems.Add(str);                      // 1
                //    lst_type.Items.Add(LVI_ORA);
                //    LVI_ORA = null;
                //}

            }
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region strip and Keyboard

        private void frm_Einlesen_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }
        private void frm_Einlesen_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
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
        # endregion

        # region color
        private void chk_dauerauftrag_Enter(object sender, EventArgs e)
        {
            chk_dauerauftrag.ForeColor = AKK_Helper.c_get_focus;
        }
        private void chk_dauerauftrag_Leave(object sender, EventArgs e)
        {
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void chk_rueckholung_Enter(object sender, EventArgs e)
        {
            chk_rueckholung.ForeColor = AKK_Helper.c_get_focus;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void chk_rueckholung_Leave(object sender, EventArgs e)
        {
            chk_rueckholung.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void txt_file_Enter(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_get_focus;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void txt_file_Leave(object sender, EventArgs e)
        {
            label1.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void txt_kopie_Enter(object sender, EventArgs e)
        {
            label2.ForeColor = AKK_Helper.c_get_focus;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void txt_kopie_Leave(object sender, EventArgs e)
        {
            foreach (   string fileX in str_Copyfiles)
            {
                if (fileX.ToUpper() == txt_kopie.Text.ToUpper () + txt_extension.Text.ToUpper ())
                {
                    AKK_Helper.show_msg("Datei bereits vorhanden!", strip_info, this.Cursor);
                    txt_kopie.Focus();
                    txt_kopie.SelectAll();
                }
            }
            
            //if (str_Copyfiles.ToList<string>().Exists(a => a == txt_kopie.Text + txt_extension.Text )) 
            label2.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cmd_plus_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cmd_plus_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }

        private void cmd_minus_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void cmd_minus_Leave(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_lost_focus;
        }


        private void mtxt_buch_dat_Enter(object sender, EventArgs e)
        {
            label3.ForeColor = AKK_Helper.c_get_focus;
            chk_dauerauftrag.ForeColor = AKK_Helper.c_lost_focus;
        }
        private void mtxt_buch_dat_Leave(object sender, EventArgs e)
        {
            if (AKK_Helper.is_empty_date(mtxt_buch_dat.Text) == false)
            {
                if (AKK_Helper.is_date(mtxt_buch_dat.Text) == false)
                {
                    mtxt_buch_dat.Focus();
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC009"] + " " + mtxt_buch_dat.Text, strip_info, this.Cursor);
                }
            }

            else
            {
                mtxt_buch_dat.Focus();
                AKK_Helper.show_msg("Buchungsdatum kann nicht leer sein!", strip_info, this.Cursor);
                mtxt_buch_dat.Text = str_now_minus1;
            }

            label3.ForeColor = AKK_Helper.c_lost_focus;
        }
        # endregion

        private void cmd_plus_Click(object sender, EventArgs e)
        {
            DateTime dat_plus;
            if (DateTime.TryParse(mtxt_buch_dat.Text, out dat_plus) == true)
            {
                mtxt_buch_dat.Text = dat_plus.AddDays(1).ToString();
            }

        }
        private void cmd_minus_Click(object sender, EventArgs e)
        {
            DateTime dat_minus;
            if (DateTime.TryParse(mtxt_buch_dat.Text, out dat_minus) == true)
            {
                mtxt_buch_dat.Text = dat_minus.AddDays(-1).ToString();
            }

        }

        private void chk_rueckholung_Click(object sender, EventArgs e)
        {
          txt_file.Enabled = true;
          txt_extension.Text = ".txt";
        }
        private void chk_dauerauftrag_Click(object sender, EventArgs e)
        {
            txt_file.Enabled = false;
            txt_extension.Text = "";
        }

        private void lst_files_Click(object sender, EventArgs e)
        {
            ListViewItem li = null;
            for (int i = lst_files.SelectedItems.Count - 1; i >= 0; i--)
            {
                li = lst_files.SelectedItems[i];
                i = 0;
            }
       
            txt_dtt.Text = li.SubItems[1].Text.ToString();
            li = null;
            cmd_einlesen.Enabled = true;
        }

        private void cmd_einlesen_Click(object sender, EventArgs e)
        {
            Boolean is_true = true;
            foreach (string fileX in str_Copyfiles)
            {
                if (fileX.ToUpper() == txt_kopie.Text.ToUpper() + txt_extension.Text.ToUpper())
                {
                    AKK_Helper.show_msg("Datei bereits vorhanden!", strip_info, this.Cursor);
                    is_true = false;
                    txt_kopie.Focus();
                    txt_kopie.SelectAll();
                }
            }
            if (is_true == true)
            {
                if (AKK_Helper.checkLogin() == true)
                {
                    // service mit
                    /* Type  Cremul Debmul
                     * Name der Protokolldatei  
                     * Name des Datenträgerfiles             * 
                     * Name des Sicherungsfiles
                     * Buchungsdatum (als date ) 
                     */
                    this.Cursor = Cursors.WaitCursor;

                    Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response resp = new Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response();
                    BankRecordCarrier.BankRecordCarrierClient client = new BankRecordCarrier.BankRecordCarrierClient();

                    DateTime dt;
                    DateTime.TryParse(mtxt_buch_dat.Text, out dt);
                    if (chk_dauerauftrag.Checked == true)
                    {
        
                        resp = client.readV3Carrier(AKK_Helper.SessionToken,
                                                    txt_dtt.Text + txt_extension.Text,
                                                    BankRecordCarrier.V3Type.CREMUL,
                                                    txt_kopie.Text,
                                                    dt);
                        strip_info.Text = "Daueraufträge";
                    }
                    if (chk_rueckholung.Checked == true)
                    {
                        resp = client.readV3Carrier(AKK_Helper.SessionToken,
                                                    txt_dtt.Text,
                                                    BankRecordCarrier.V3Type.DEBMUL,
                                                    txt_kopie.Text  + txt_extension.Text,
                                                    dt);
                        strip_info.Text = "Rückholungen";
                    }

                    strip_info.Text = strip_info.Text + " einlesen am" +
                      DateTime.Now.Date.ToString("dd.MM.yyyy") + " um " +
                      DateTime.Now.Hour.ToString("00") + " Uhr " +
                      DateTime.Now.Minute.ToString("00") + " gestartet ...";

                    if (resp.ResponseCode == 0)
                    {
                        strip_info.Text = string.Format("{0} Dateien gefunden ", resp.ResponseMsg);
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        AKK_Helper.handleServiceError(resp);
                    }

                    this.Cursor = Cursors.Default;


                }

                //private void lst_type_Click(object sender, EventArgs e)
                //{
                //    lst_files.Items.Clear();


                //    ListViewItem li = null;
                //    for (int i = lst_type.SelectedItems.Count - 1; i >= 0; i--)
                //    {
                //        li = lst_type.SelectedItems[i];
                //        i = 0;
                //    }

                //    DirectoryInfo di = new DirectoryInfo(AKK_Helper.C.strG_DTT_DIR_ORI);
                //    FileInfo[] rgFiles = di.GetFiles(li.SubItems[1].Text.ToString());
                //    Int32 ix = 0;
                //    foreach (FileInfo fi in rgFiles)
                //    {
                //        ix++;
                //        ListViewItem LVI_ORA = new ListViewItem(ix.ToString());

                //        LVI_ORA.SubItems.Add(fi.Name);                      // 1
                //        lst_files.Items.Add(LVI_ORA);
                //        LVI_ORA = null;
                //    }
                //    strip_info.Text = string.Format("{0} Dateien gefunden ", ix);
                //}

            }
        }
        

    }   // Form
}       // Namespace

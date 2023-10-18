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
using Addit.AK.WBD.AK_Suche.DataService;
using Miracle.MPP.WebPCI;
using System.Text.RegularExpressions;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Bank : Form
    {
        public string str_wbd_ikey;
        public Boolean is_Einzug;
        public string Bank_Ein;
        public string Bank_Aus;
        public string person_id;
        public string wbd_ezdt;
        public string wbd_ein_idx;
        public DC_wbd_antrag cur_wbd_antrag; //Current WBD Antrag


        //MiRo
        public frm_wbd_antrag wbd_antrag;
        private bool aborted = true;
        public BankInfo bankInfo;
        private string referenz;


        public Boolean is_Aus;

        public Miracle.MPP.WebPCI.DataObject PVS_do_WE;
        public Miracle.MPP.WebPCI.Window PVS_wnd_WE;
        private string Bank_Ein_Temp;
        private string Bank_Aus_Temp;
        private Boolean is_changed_ein;
        private Boolean is_changed_aus;

        private string ibanOhneFormatAus;
        private string ibanOhneFormatEin;

        private frm_wbd_antrag antrag;

        private string ownerIn;
        private string ownerOut;


        private string street = null;
        private string place = null;
private  bool fromPVS_aus;

        public frm_Bank(frm_wbd_antrag antrRef)
        {
            this.antrag = antrRef;
            this.wbd_antrag = antrRef;
            InitializeComponent();
        }

        private void frm_Bank_Load(object sender, EventArgs e)
        {

            //change GUI if addressBox has to be shown.... working with fixed points since no layout was used.....
            //MiRo
            if (this.antrag.IsCoopPartner)
            {

                addressBox.Visible = true;
                addressBox.Enabled = true;

                this.ClientSize = new System.Drawing.Size(624, 474);

                this.GB_Bank_Aus.Size = new System.Drawing.Size(557, 205);

                this.GB_Bank_Ein.Location = new System.Drawing.Point(35, 250);
                this.GB_Bank_Ein.Size = new System.Drawing.Size(557, 147);

                this.addressBox.Location = new System.Drawing.Point(6, 124);
                this.addressBox.Size = new System.Drawing.Size(472, 71);
                this.addressBox.TabIndex = 43;
                this.addressBox.TabStop = false;



                this.addressBox.ResumeLayout(false);
                this.addressBox.PerformLayout();

                this.GB_Bank_Aus.Controls.Add(this.addressBox);

                this.saveBtn.Location = new System.Drawing.Point(430, 405);
                this.closeBtn.Location = new System.Drawing.Point(517, 405);

                txt_iban_aus.Enabled = true;

                txtOwnerOut.Enabled = true;

                this.GB_Bank_Ein.Enabled = true;

            }



            this.streetBox.TextChanged += OnBoxesChanged;
            this.placeBox.TextChanged += OnBoxesChanged;
            this.txt_iban_aus.TextChanged += OnBoxesChanged;
            this.txt_iban_ein.TextChanged += OnBoxesChanged;
            this.txtOwnerIn.TextChanged += OnBoxesChanged;
            this.txtOwnerOut.TextChanged += OnBoxesChanged;


            bool fromPVS_aus=false;
            bool fromPVS_ein=false;


        


            // 10-12-2012 byx KJ          
            if (AKK_Helper.My_user.CanWrite == true)
            {
               
               // cmd_speichern_aus.Enabled = true;
               // cmd_loeschen_aus.Enabled = true;
           
               // cmd_speichern_ein.Enabled = true;
               // cmd_loeschen_ein.Enabled = true;


             

            }
            else
            {
                cmd_Bank_Aus.Enabled = false;
                cmd_speichern_aus.Enabled = false;
                cmd_loeschen_aus.Enabled = false;
                cmd_Bank_Ein.Enabled = false;
                cmd_speichern_ein.Enabled = false;
                cmd_loeschen_ein.Enabled = false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                    //  if (AKK_Helper.C.strG_Bankverbindung_AUS_Bank == AKK_Helper.c_Yes) cmd_Bank_Aus.Enabled = true;
                    if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = true;
                    if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = true;
                    //  if (AKK_Helper.C.strG_Bankverbindung_EIN_Bank == AKK_Helper.c_Yes) cmd_Bank_Ein.Enabled = true;
                    if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = true;
                    if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = true;
                }

            }

            AKK_Helper.FindControls(this);

            lbl_ein_idx.Text = wbd_ein_idx; // 29-11-2011 by KJ

            opt_f.Font = new Font(opt_f.Font.FontFamily, 9);
            opt_r.Font = new Font(opt_f.Font.FontFamily, 9);
            opt_x.Font = new Font(opt_f.Font.FontFamily, 9);
            lbl_ein_idx.Font = new Font(lbl_ein_idx.Font.FontFamily, 9);
            lbl_ein_Index.Font = new Font(lbl_ein_Index.Font.FontFamily, 9);

            gb_status.Font = new Font(gb_status.Font.FontFamily, 9);

            is_changed_ein = false;
            is_changed_aus = false;
            //
            // Disable all textfields
            //
            /**
            txt_Bank_Aus.Enabled         = false;
            txt_Bankleitzahl_Aus.Enabled = false;
            txt_Kontonummer_Aus.Enabled  = false;
            //
            txt_Bank_Ein.Enabled         = false;
            txt_Bankleitzahl_Ein.Enabled = false;
            txt_Kontonummer_Ein.Enabled  = false;
            //
            // Auszahlungsbank
            //
            txt_Bankleitzahl_Aus.Text = "";

            **/
            //txt_Bank_Aus.Text = "";
            // txt_Kontonummer_Aus.Text = "";
            if (AKK_Helper.is_empty(Bank_Aus) == false)
            {
                DC_bankverbindung_data bankVerbindung = AKK_Helper.read_BV(Bank_Aus);
                fromPVS_aus=true;


                // txt_Bankleitzahl_Aus.Text = BV.DM_str_blz;
                //txt_Bank_Aus.Text = BV.DM_str_name;
                //                        = BV.DM_str_anmerkung;
                // txt_Kontonummer_Aus.Text = BV.DM_str_kontonr;
                //  txt_bic_aus.Text = BV.DM_str_bic;
                txt_iban_aus.Text = bankVerbindung.DM_str_iban;
              

                //  string vorname = bankVerbindung.DM_str_vorname;//MiRo
                //string zuname = bankVerbindung.DM_str_zuname;

                // txtOwnerOut.Text = string.Format("{0}  test {1}",vorname,zuname);

                bankVerbindung = null;
                if (AKK_Helper.My_user.CanWrite == true)
                {
                    cmd_loeschen_aus.Enabled = true;
                    cmd_speichern_aus.Enabled = false;
                }
                else
                {
                    cmd_loeschen_aus.Enabled = false;
                    cmd_speichern_aus.Enabled = false;
                    if (AKK_Helper.My_user.CanRead == true)
                    {
                        if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = true;
                        if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = false;
                    }
                }
            }
            else
            {
                if (AKK_Helper.My_user.CanWrite == true)
                {
                    cmd_loeschen_aus.Enabled = false;
                    cmd_speichern_aus.Enabled = true;
                }

                else
                {
                    cmd_loeschen_aus.Enabled = false;
                    cmd_speichern_aus.Enabled = false;
                    if (AKK_Helper.My_user.CanRead == true)
                    {
                        if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = false;
                        if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = true;
                    }
                }
            }
            //
            // Einzugsbank
            //
            /**
            txt_Bankleitzahl_Ein.Text = "";
            txt_Bank_Ein.Text         = "";
            txt_Kontonummer_Ein.Text  = "";
             * */

            if (is_Einzug == true)
            {
                //  panelNoEinzug.Visible = false;
                if (AKK_Helper.is_empty(Bank_Ein) == false)
                {
                    DC_bankverbindung_data bankVerbindung = AKK_Helper.read_BV(Bank_Ein);
                    fromPVS_ein=true;
                    //  txt_Bankleitzahl_Ein.Text = BV.DM_str_blz;
                    // txt_Bank_Ein.Text = BV.DM_str_name;
                    //                        = BV.DM_str_anmerkung;
                    // txt_Kontonummer_Ein.Text = BV.DM_str_kontonr;
                    //  txt_bic_ein.Text = BV.DM_str_bic;
                    txt_iban_ein.Text = bankVerbindung.DM_str_iban;
                    bankVerbindung = null;
                }
                if (AKK_Helper.My_user.CanWrite == true)
                {
                   // cmd_loeschen_ein.Enabled = true;
                    cmd_speichern_ein.Enabled = false;
                    GB_Bank_Ein.Enabled = true;
                }
                else
                {
                    //cmd_loeschen_ein.Enabled = false;
                    cmd_speichern_ein.Enabled = false;
                    //   GB_Bank_Ein.Enabled = false;
                    if (AKK_Helper.My_user.CanRead == true)
                    {
                        if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) //cmd_loeschen_ein.Enabled = true;
                        if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = false;
                        GB_Bank_Ein.Enabled = true;
                    }
                }
            }
            else
            {
                // panelNoEinzug.Visible = true;

                if (AKK_Helper.My_user.CanWrite == true)
                {
                    cmd_loeschen_ein.Enabled = false;
                  //  cmd_speichern_ein.Enabled = true;
                    //  GB_Bank_Ein.Enabled = false;
                }
                else
                {
                    cmd_loeschen_ein.Enabled = false;
                    cmd_speichern_ein.Enabled = false;
                    GB_Bank_Ein.Enabled = false;
                    GB_Bank_Ein.Visible = false;
                    if (AKK_Helper.My_user.CanRead == true)
                    {
                        if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = false;
                        if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = true;
                        //  GB_Bank_Ein.Enabled = false;
                    }
                }
            }






            // Cmd_Uebernahme setzen
            //
            if (AKK_Helper.My_user.CanWrite == true)
            {
                //cmd_uebernehmen.Enabled = is_Einzug;
            }
            else
            {
               // cmd_uebernehmen.Enabled = false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                   // if (AKK_Helper.C.strG_Bankverbindung_AUS_Übernehmen == AKK_Helper.c_Yes)// cmd_uebernehmen.Enabled = is_Einzug;
                }
            }



            //Miro, basically overwrites everything above.... but would have to check before I delete that stuff...
            if (this.antrag.IsCoopPartner && this.is_Einzug)
            {

                txtOwnerOut.Enabled = true;
                txt_iban_aus.Enabled = true;
                cmd_Bank_Aus.Enabled = false;
                cmd_speichern_aus.Enabled = false;
                cmd_loeschen_aus.Enabled = false;


                txtOwnerIn.Enabled = false;
                txt_iban_ein.Enabled = false;
                cmd_Bank_Ein.Enabled = true;
                cmd_speichern_ein.Enabled = false;
                cmd_loeschen_ein.Enabled = false;

                //löschen aktivieren

                //kann person nicht wechseln?? einzug
                //einzug löschen aktivieren.
                //LÖSCHEN IMMER AKTIVIEREN

                cmd_uebernehmen.Enabled = false;

            }
            else if (this.antrag.IsCoopPartner && !this.is_Einzug)
            {

                txtOwnerOut.Enabled = true;
                txt_iban_aus.Enabled = true;
                cmd_Bank_Aus.Enabled = false;
                cmd_speichern_aus.Enabled = false;
                cmd_loeschen_aus.Enabled = false;


                txtOwnerIn.Enabled = false;
                txt_iban_ein.Enabled = false;
                cmd_Bank_Ein.Enabled = false;
                cmd_speichern_ein.Enabled = false;
                cmd_loeschen_ein.Enabled = false;

                cmd_uebernehmen.Enabled = false;




            }

            else   if (!this.antrag.IsCoopPartner && this.is_Einzug)
            {
                txtOwnerOut.Enabled = false;
                txt_iban_aus.Enabled = false;
                cmd_Bank_Aus.Enabled = true;
                cmd_speichern_aus.Enabled = false;
                cmd_loeschen_aus.Enabled = false;


                txtOwnerIn.Enabled = false;
                txt_iban_ein.Enabled = false;
                cmd_Bank_Ein.Enabled = true;
                cmd_speichern_ein.Enabled = false;
                cmd_loeschen_ein.Enabled = false;

                cmd_uebernehmen.Enabled = false;

            }
            else  if (!this.antrag.IsCoopPartner && !this.is_Einzug)
            {

                txtOwnerOut.Enabled = false;
                txt_iban_aus.Enabled = false;
                cmd_Bank_Aus.Enabled = true;
                cmd_speichern_aus.Enabled = false;
                cmd_loeschen_aus.Enabled = false;



                txtOwnerIn.Enabled = false;
                txt_iban_ein.Enabled = false;
                cmd_Bank_Ein.Enabled = false;
                cmd_speichern_ein.Enabled = false;
                cmd_loeschen_ein.Enabled = false;
                
                cmd_uebernehmen.Enabled = false;
            }

            if (AKK_Helper.My_user.CanWrite == false)
            {
                
                cmd_speichern_aus.Enabled = false;
                cmd_speichern_ein.Enabled = false;
            }

            if(!string.IsNullOrEmpty(this.txt_iban_ein.Text)|| !string.IsNullOrEmpty(this.txtOwnerIn.Text)){
                cmd_loeschen_ein.Enabled = true;
            }
            if (!string.IsNullOrEmpty(this.txt_iban_aus.Text) || !string.IsNullOrEmpty(this.txtOwnerOut.Text))
            {
                cmd_loeschen_aus.Enabled = true;
            }



            //if the data in bank frame was already saved and the frame closed, but the user goes back to the bank frame from antrag again.
            if (!this.antrag.BankInf.Equals(default(BankInfo)))
            {
                  this.bankInfo = this.antrag.BankInf;

                if(!fromPVS_ein){
                    this.txtOwnerIn.Text = bankInfo.OwnerIn ?? "";
                this.txt_iban_ein.Text = bankInfo.IbanIn ?? "";
                }


                if(!fromPVS_aus){
                      this.txt_iban_aus.Text = this.antrag.BankInf.IbanOut ?? "";
                this.txtOwnerOut.Text = this.antrag.BankInf.OwnerOut ?? "";
                }

              
                  
                this.streetBox.Text = this.antrag.BankInf.Street ?? "";
                this.placeBox.Text = this.antrag.BankInf.Place ?? "";
            }




            set_ezdt(sender, e);
            this.is_changed_aus = false;
            this.is_changed_ein = false;

        }
        private void set_ezdt(object sender, EventArgs e)
        {
            if (wbd_ezdt == "F")
            {
                opt_f.Checked = true;
                opt_r.Checked = false;
                opt_x.Checked = false;
            }
            else
            {
                if (wbd_ezdt == "R")
                {
                    opt_f.Checked = false;
                    opt_r.Checked = true;
                    opt_x.Checked = false;
                }
                else
                {
                    opt_f.Checked = false;
                    opt_r.Checked = false;
                    opt_x.Checked = true;
                }
            }

        }
        private void cmd_uebernehmen_Click(object sender, EventArgs e)
        {
            if (is_Einzug == true)
            {

                if (!(AKK_Helper.is_empty(txt_iban_aus.Text)) )//(AKK_Helper.is_empty ( txt_Bankleitzahl_Aus.Text ) == false ) && (AKK_Helper.is_empty ( txt_Bank_Aus.Text )         == false ) &&                    
                {

                    if ((AKK_Helper.is_empty(txt_iban_ein.Text))) //  (AKK_Helper.is_empty(txt_Bank_Aus.Text) == false) &&
                    {

                        is_changed_ein = true;
                        //

                        txt_iban_ein.Text = txt_iban_aus.Text;
                        txtOwnerIn.Text = txtOwnerOut.Text;
                        //  txt_Bank_Ein.Text         =  txt_Bank_Aus.Text ; //TODO: was das?
                        //  txt_Kontonummer_Ein.Text  = txt_Kontonummer_Aus.Text ;
                        //txt_bic_ein.Text  = txt_bic_aus.Text;

                        if (txt_iban_aus.Text.Contains("-"))
                        {
                            ibanOhneFormatEin = ibanOhneFormatAus;
                            txt_iban_ein.Text = txt_iban_aus.Text;
                        }
                        else
                        {
                            txt_iban_ein.Text = txt_iban_aus.Text;
                        }


                        Bank_Ein_Temp = Bank_Aus;
                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_ein.Enabled = true;
                            cmd_loeschen_ein.Enabled = false;
                        }
                        else
                        {
                            cmd_speichern_ein.Enabled = false;
                            cmd_loeschen_ein.Enabled = false;
                            if (AKK_Helper.My_user.CanRead == true)
                            {
                          
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = true;
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        AKK_Helper.show_msg("Zum Übernehmen muss eine gültige Bank selektiert werden!", strip_info, this.Cursor);
                    }
                }
                else
                {
                    /**
                 txt_Bankleitzahl_Ein.Text = "";
                 txt_Bank_Ein.Text         = "";
                 txt_Kontonummer_Ein.Text  = "";**/
                }
            }
        }



        private void OnBoxesChanged(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            var name = box.Name;

            if (name.Equals("txtOwnerOut") || name.Equals("txt_iban_aus") || name.Equals("streetBox") || name.Equals("placeBox"))
            {
                this.is_changed_aus = true;

                this.cmd_speichern_aus.Enabled = true;
                this.cmd_loeschen_aus.Enabled = true;
               
                
                if(!this.antrag.IsCoopPartner)this.cmd_uebernehmen.Enabled = true;

            }
                
            else if (name.Equals("txtOwnerIn") || name.Equals("txt_iban_ein"))
            {
                this.is_changed_ein = true;

                this.cmd_speichern_ein.Enabled = true;
                this.cmd_loeschen_ein.Enabled = true;
            }


     
        }



        private void cmd_speichern_aus_Click(object sender, EventArgs e)
        {

            this.ownerOut = this.txtOwnerOut.Text;


            if (AKK_Helper.checkLogin() == true)
            {

                Bank_Aus = Bank_Aus_Temp;


                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }


                //Miro hinzugefügt
                else if (this.antrag.IsCoopPartner)
                {

                    this.ibanOhneFormatAus = Regex.Replace(txt_iban_aus.Text, @"\s+", "");
                    DialogResult? result = null;

                    if (!string.IsNullOrEmpty(ibanOhneFormatAus) && !isIbanValid(ibanOhneFormatAus))
                    {
                        result = MessageBox.Show("Überweisungs Iban ist keine valide IBAN!");
                        return;
                    }


                    bool savedInDb = saveIntoDatabase(Bank_Aus, "A");
                    if (!savedInDb)
                    {
                        AKK_Helper.show_msg("Fehler beim Speichern von Auszahlung in die Datenbank.", strip_info, null);
                        return;
                    }
                    AKK_Helper.show_msg("Erfolgreich in die Datenbank gespeichert.", strip_info, null);



                }
                else
                {




                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {
                        is_changed_aus = false;

                        Response resp = new Response();
                        DataServiceClient client = new DataServiceClient();
                        string str_where = "";
                        string str_Type = "";
                        resp = client.Update_Bank(AKK_Helper.SessionToken,
                                                           AKK_Helper.UserId,
                                                           str_wbd_ikey,
                                                           Bank_Aus,
                                                           "A");   // Auszahlungsbank !!!





                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_aus.Enabled = false;
                            cmd_loeschen_aus.Enabled = true;
                        }
                        else
                        {
                            cmd_speichern_aus.Enabled = false;
                            cmd_loeschen_aus.Enabled = false;
                            if (AKK_Helper.My_user.CanRead == true)
                            {
                                if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = false;
                                if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = true;
                            }

                        }
                        //
                        if (resp.ResponseCode == 0)
                        {
                            if (AKK_Helper.is_empty(Bank_Aus) == true || Bank_Aus == "-1")
                            { }
                            else
                            {
                                try
                                {
                                    str_where = "Key = '" + Bank_Aus + "'";
                                    str_Type = Bank_Aus.Substring(3, 2);
                                    Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                    if (pvs_col.Count > 0)
                                    {
                                        foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                        {
                                            pvs_do.AddExtRef();
                                        }
                                    }

                                    //Protokollierung Stefitz David 29.08.2018
                                    DataService.DataServiceClient clientProt = new DataServiceClient();

                                    clientProt.Insert_WBD_Protocol(Int32.Parse(AKK_Helper.UserId.ToString()), "INSERT", "Auszahlungsbank", cur_wbd_antrag.DM_wbd_ant_id, Int32.Parse(cur_wbd_antrag.DM_ant_ikey), "Auszahlungsbank gespeichert! IBAN:" + txt_iban_aus.Text, AKK_Helper.SessionToken);
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg("Fehler bei Addrefs" + ex.InnerException, strip_info, this.Cursor);
                                }

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
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                    }
                }

                this.Cursor = Cursors.Default;
                // }
            }
        }


        /// <summary>
        /// Saves the Bank Variables into the database and sets the Variables here to those values.
        /// </summary>
        /// <param name="bank">-1 or empty string</param>
        /// <param name="inOut">E or A</param>
        /// <param name="ibanOut"></param>
        /// <param name="ownerOut"></param>
        /// <param name="ibanIn"></param>
        /// <param name="ownerIn"></param>
        /// <param name="place"></param>
        /// <param name="street"></param>
        /// <returns></returns>
        private bool saveIntoDatabase(string bank, string inOut, string ibanOut, string ownerOut, string ibanIn, string ownerIn, string place, string street)
        {
            this.ibanOhneFormatAus = Regex.Replace(ibanOut??"", @"\s+", "");
            this.ibanOhneFormatEin = Regex.Replace(ibanIn??"", @"\s+", "");
            this.ownerIn = ownerIn;
            this.ownerOut = ownerOut;
            this.place = place;
            this.street = street;


            this.referenz = this.antrag.Referenz;
            string coopPartner = this.antrag.IsCoopPartner ? "1" : "0";
            this.bankInfo = new BankInfo(ibanOhneFormatEin, ownerIn, ibanOhneFormatAus, ownerOut, referenz, street, place, coopPartner);
           

            Response resp1 = new Response();
            DataServiceClient client1 = new DataServiceClient();

            // is_changed_aus = false;
            bank = bank ?? "";

            resp1 = client1.update_BankDetails(AKK_Helper.SessionToken,
                              AKK_Helper.UserId,
                              str_wbd_ikey,
                              bank,
                              inOut,
                              this.ibanOhneFormatEin, this.ownerIn, this.ibanOhneFormatAus, this.ownerOut,
                               this.referenz, this.street, this.place, coopPartner);

            if (resp1.ResponseCode == 0)
            {
                this.antrag.BankInf = this.bankInfo;
                return true;
            }

            return false;
        }




        private bool saveIntoDatabase(string bank, string inOut)
        {
            this.ibanOhneFormatAus = Regex.Replace(txt_iban_aus.Text, @"\s+", "");
            this.ibanOhneFormatEin = Regex.Replace(txt_iban_ein.Text, @"\s+", "");

      
            string referenz = this.antrag.Referenz;
            this.referenz = referenz;
            string coopPartner = this.antrag.IsCoopPartner ? "1" : "0";
            this.bankInfo = new BankInfo(this.ibanOhneFormatEin, this.ownerIn, this.ibanOhneFormatAus, this.ownerOut, referenz, this.street, this.place, coopPartner);
           

          
                Response resp1 = new Response();
                DataServiceClient client1 = new DataServiceClient();          

                    resp1 = client1.update_BankDetails(AKK_Helper.SessionToken,
                                      AKK_Helper.UserId,
                                      str_wbd_ikey,
                                      bank,
                                      inOut,
                                      this.ibanOhneFormatEin, this.ownerIn, this.ibanOhneFormatAus, this.ownerOut,
                                       referenz, this.street, this.place, coopPartner);


                    if (resp1.ResponseCode == 0)
                    {
                        this.antrag.BankInf = this.bankInfo;
                        return true;
                    }

            return false;
        }



        private void cmd_loeschen_aus_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }


                else if(this.antrag.IsCoopPartner){
                    bool savedInDb = saveIntoDatabase("-1", "A",null,null,this.txt_iban_ein.Text, txtOwnerIn.Text,null,null);
                    if (!savedInDb)
                    {
                        AKK_Helper.show_msg("Fehler beim Löschen der überweisungsdaten.", strip_info, null);
                        return;
                    }

                    this.txt_iban_aus.Text = "";
                    this.txtOwnerOut.Text = "";                  
                    this.streetBox.Text = "";
                    this.placeBox.Text = "";

                 
                    AKK_Helper.show_msg("Erfolgreich aus Datenbank gelöscht.", strip_info, null);

                }

                else
                {
                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {
                        is_changed_aus = true;
                        Response resp = new Response();
                        DataServiceClient client = new DataServiceClient();
                        string str_where = "";
                        string str_Type = "";
                        resp = client.Update_Bank(AKK_Helper.SessionToken,
                                                           AKK_Helper.UserId,
                                                           str_wbd_ikey,
                                                           "-1",
                                                           "A");   // Ueberweisungsbank !!!





                        Bank_Aus = "";
                        Bank_Aus_Temp = "";


                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_aus.Enabled = true;
                            cmd_loeschen_aus.Enabled = false;
                        }
                        else
                        {
                            cmd_speichern_aus.Enabled = false;
                            cmd_loeschen_aus.Enabled = false;
                            if (AKK_Helper.My_user.CanRead == true)
                            {
                                if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = true;
                                if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = false;
                            }


                        }
                        //
                        // txt_Bankleitzahl_Aus.Text = "";
                        //   txt_Bank_Aus.Text = "";
                        //   txt_Kontonummer_Aus.Text = "";
                        //  txt_bic_aus.Text = "";
                        txt_iban_aus.Text = "";
                        txtOwnerOut.Text = "";
                        if (this.antrag.IsCoopPartner)
                        {
                            this.streetBox.Text = "";
                            this.placeBox.Text = "";
                        }
                        //
                        if (resp.ResponseCode == 0)
                        {
                            if (AKK_Helper.is_empty(Bank_Aus) == true || Bank_Aus == "-1")
                            { }
                            else
                            {
                                str_where = "Key = '" + Bank_Aus + "'";
                                str_Type = Bank_Aus.Substring(3, 2);
                                try
                                {
                                    Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                    if (pvs_col.Count > 0)
                                    {
                                        foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                        {
                                            pvs_do.RemoveExtRef();
                                            Bank_Aus = "";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg("Fehler beim Löschen der Bank" + ex.InnerException, strip_info, this.Cursor);
                                }

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
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void cmd_speichern_ein_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {

                Bank_Ein = Bank_Ein_Temp;

                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }



/**
                          //Miro hinzugefügt
            else if (this.antrag.IsCoopPartner){
                    this.ibanOhneFormatEin = Regex.Replace(txt_iban_ein.Text, @"\s+", "");
                    DialogResult? result = null;

                    if (!string.IsNullOrEmpty(ibanOhneFormatEin) && !isIbanValid(ibanOhneFormatEin))
                    {
                        result = MessageBox.Show("Überweisungs Iban ist keine valide IBAN!");
                       return;
                    }


                    bool savedInDb = saveIntoDatabase(Bank_Ein, "E");
                    if (!savedInDb)
                    {
                        AKK_Helper.show_msg("Fehler beim Speichern von Auszahlung in die Datenbank.", strip_info, null);
                        return;
                    }
                    AKK_Helper.show_msg("Erfolgreich in die Datenbank gespeichert.", strip_info, null);
                
               
                } else {
                **/

                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {

                        is_changed_ein = false;
                        Response resp = new Response();
                        DataServiceClient client = new DataServiceClient();
                        string str_where = "";
                        string str_Type = "";

                        resp = client.Update_Bank(AKK_Helper.SessionToken,
                                                AKK_Helper.UserId,
                                                str_wbd_ikey,
                                                Bank_Ein,
                                                "E");   // Einzugsbank !!!



                        // 13-09-2011 by KJ
                        if (Bank_Ein == "")
                        {
                            wbd_ezdt = "X";
                        }
                        else
                        {
                            int int_ein_idx = 0;
                            int.TryParse(wbd_ein_idx, out int_ein_idx);
                            int_ein_idx++;
                            lbl_ein_idx.Text = int_ein_idx.ToString();
                            wbd_ein_idx = int_ein_idx.ToString();
                            wbd_ezdt = "F";
                        }
                        set_ezdt(sender, e);
                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_ein.Enabled = false;
                            cmd_loeschen_ein.Enabled = true;
                        }
                        else
                        {
                            cmd_speichern_ein.Enabled = false;
                            cmd_loeschen_ein.Enabled = false;

                            if (AKK_Helper.My_user.CanRead == true)
                            {
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = false;
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = true;
                            }
                        }

                        if (resp.ResponseCode == 0)
                        {
                            if (AKK_Helper.is_empty(Bank_Ein) == true || Bank_Ein == "-1")
                            { }
                            else
                            {
                                str_where = "Key = '" + Bank_Ein + "'";
                                str_Type = Bank_Ein.Substring(3, 2);
                                Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                if (pvs_col.Count > 0)
                                {
                                    foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                    {
                                        pvs_do.AddExtRef();
                                    }
                                }

                                //Protokollierung Stefitz David 29.08.2018
                                DataService.DataServiceClient clientProt = new DataServiceClient();
                                clientProt.Insert_WBD_Protocol(Int32.Parse(AKK_Helper.UserId.ToString()), "INSERT", "Einzugsbank", cur_wbd_antrag.DM_wbd_ant_id, Int32.Parse(cur_wbd_antrag.DM_ant_ikey), "Einzugsbank gespeichert! IBAN:" + txt_iban_ein.Text, AKK_Helper.SessionToken);
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
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                    }

                }
                this.Cursor = Cursors.Default;
           // }
        }
        private void cmd_loeschen_ein_Click(object sender, EventArgs e)
        {

            //rückzahlungsschreiben, wegen kooperationspartner, verständigung am wird nicht gesetzt

            if (AKK_Helper.checkLogin() == true)
            {
                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }

/**
                else if (this.antrag.IsCoopPartner)
                {
                    bool savedInDb = saveIntoDatabase("-1", "E",this.txt_iban_aus.Text,this.txtOwnerOut.Text,null, null,this.placeBox.Text, this.streetBox.Text);
                    if (!savedInDb)
                    {
                        AKK_Helper.show_msg("Fehler beim Löschen der Einzugsdaten.", strip_info, null);
                        return;
                    }
                    this.txtOwnerIn.Text = "";
                    this.txt_iban_ein.Text = "";

                    AKK_Helper.show_msg("Erfolgreich aus Datenbank gelöscht.", strip_info, null);
                }
                **/

                else
                {
                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {
                        is_changed_ein = true;
                        //
                        Response resp = new Response();
                        DataServiceClient client = new DataServiceClient();
                        string str_where = "";
                        string str_Type = "";
                        resp = client.Update_Bank(AKK_Helper.SessionToken,
                                                           AKK_Helper.UserId,
                                                           str_wbd_ikey,
                                                           "-1",
                                                           "E");   // Einzugsbank !!!


                        //TODO für die neue methode ebenso?


                        // 13-09-2011 by KJ
                        wbd_ezdt = "X";
                        set_ezdt(sender, e);

                        Bank_Ein = "";
                        Bank_Ein_Temp = "";
                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_ein.Enabled = true;
                            cmd_loeschen_ein.Enabled = false;
                        }
                        else
                        {
                            cmd_speichern_ein.Enabled = true;
                            cmd_loeschen_ein.Enabled = false;

                            if (AKK_Helper.My_user.CanRead == true)
                            {
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = true;
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = false;
                            }
                        }
                  
                        txt_iban_ein.Text = "";
                        txtOwnerIn.Text = "";
                        //
                        if (resp.ResponseCode == 0)
                        {
                            if (AKK_Helper.is_empty(Bank_Ein) == true || Bank_Ein == "-1")
                            { }
                            else
                            {
                                try
                                {
                                    str_where = "Key = '" + Bank_Ein + "'";
                                    str_Type = Bank_Ein.Substring(3, 2);
                                    Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                    if (pvs_col.Count > 0)
                                    {
                                        foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                        {
                                            pvs_do.RemoveExtRef();
                                            Bank_Ein = "";
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg("Fehler beim Löschen der Bank" + ex.InnerException, strip_info, this.Cursor);
                                }
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
                        AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                    }
                }
                this.Cursor = Cursors.Default;
            }
        }
        private void cmd_Bank_Aus_Click(object sender, EventArgs e)
        {
            is_changed_aus = true;

            this.fromPVS_aus=true;

            try
            {
                is_Aus = true;
                this.Cursor = Cursors.WaitCursor;
                strip_info.Text = "Personenverwaltung wird gestartet . . .";
                //
                if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                {
                    if (AKK_Helper.is_empty(Bank_Aus) == true || Bank_Aus == "-1")
                    {
                        //
                        // Neue Bank selektieren
                        //
                        AKK_Helper.PVS_CON.PVS_APP.TraceFile = "C:\\temp\\WebPCI.log";
                        AKK_Helper.PVS_CON.PVS_APP.TraceFileFlush = true;
                        AKK_Helper.PVS_CON.PVS_APP.TrackedSources.Remove("WinHTTP");
                        AKK_Helper.PVS_CON.PVS_APP.TrackedSources.Remove("XMLDB");
                        AKK_Helper.PVS_CON.PVS_APP.TrackedSources.Add("Browser");
                        AKK_Helper.PVS_CON.PVS_APP.TrackingStarted = true;
                        try
                        {
                            string str_where = "PersonID='" + person_id + "'";
                            string str_Type = "PE";
                            Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                            if (pvs_col.Count > 0)
                            {
                                foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                {
                                    PVS_do_WE = pvs_do;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            AKK_Helper.show_msg("Fehler beim Lesen der PVS Person : " + person_id + " : " + ex.InnerException, strip_info, this.Cursor);
                        }
                        try
                        {
                            // MessageBox.Show("1");
                            PVS_wnd_WE = AKK_Helper.PVS_CON.PVS_APP.OpenWindow("BV", "LIST");
                            // MessageBox.Show("2");
                            PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);


                            //PVS_wnd_WE.OnAssign += (PVS_wnd_WE_OnAssign) =>
                            //    {
                            //        throw new ApplicationException();
                            //    };

                            //MessageBox.Show("3");
                            PVS_wnd_WE.SetAssignMode("addIT", false);
                            // MessageBox.Show("4");
                            // PVS_wnd_WE.SetNewMode(); 09-07-2012 by KJ 1
                            // MessageBox.Show("5");
                            PVS_wnd_WE.ClearSearchFields();
                            // MessageBox.Show("6");
                            PVS_wnd_WE.SearchCondition = "PersonID='" + person_id + "'";
                            // MessageBox.Show("7");
                            PVS_wnd_WE.Read();
                            PVS_wnd_WE.Activate();
                            // MessageBox.Show("8");
                        }
                        catch (Exception ex)
                        {
                            AKK_Helper.show_msg("Fehler beim Öffnen der Bankverbindungen - PersonID=" + person_id + " : " + ex.InnerException, strip_info, this.Cursor);
                        }
                        //
                        // init controls
                        //
                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_aus.Enabled = true;
                            cmd_loeschen_aus.Enabled = false;
                            // cmd_Bank_Aus.Enabled = true;
                        }
                        else
                        {
                            cmd_speichern_aus.Enabled = false;
                            cmd_loeschen_aus.Enabled = false;
                            cmd_Bank_Aus.Enabled = false;

                            if (AKK_Helper.My_user.CanRead == true)
                            {
                                if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = true;
                                if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = false;
                                // if (AKK_Helper.C.strG_Bankverbindung_AUS_Bank == AKK_Helper.c_Yes) cmd_Bank_Aus.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        //
                        // Ändern
                        //
                        Miracle.MPP.WebPCI.Collection pvs_col = null;

                        string str_where = "Key = '" + Bank_Aus + "'";
                        pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere("BV", str_where, null, null);

                        if (pvs_col.Count > 0)
                        {
                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                            {
                                try
                                {
                                    PVS_do_WE = pvs_do;             // Create Dataobject
                                    PVS_do_WE.OnUpdate += new Miracle.MPP.WebPCI.DataObject.OnUpdateEventHandler(PVS_do_WE_OnUpdate);
                                    //
                                    PVS_wnd_WE = pvs_do.Edit();    // Create Window
                                    PVS_wnd_WE.SetAssignMode("addIT", false);
                                    PVS_wnd_WE.Activate();         // activate Window 
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg("Fehler beim Öffnen der Bankverbindungen - Key=" + Bank_Aus + " : " + ex.InnerException, strip_info, this.Cursor);
                                }
                            }
                            //
                            // init controle
                            //
                            if (AKK_Helper.My_user.CanWrite == true)
                            {
                                cmd_speichern_aus.Enabled = false;
                                cmd_loeschen_aus.Enabled = true;
                                //  cmd_Bank_Aus.Enabled = true;
                            }
                            else
                            {
                                cmd_speichern_aus.Enabled = false;
                                cmd_loeschen_aus.Enabled = false;
                                cmd_Bank_Aus.Enabled = false;
                                if (AKK_Helper.My_user.CanRead == true)
                                {
                                    if (AKK_Helper.C.strG_Bankverbindung_AUS_Speichern == AKK_Helper.c_Yes) cmd_speichern_aus.Enabled = false;
                                    if (AKK_Helper.C.strG_Bankverbindung_AUS_Löschen == AKK_Helper.c_Yes) cmd_loeschen_aus.Enabled = true;
                                    //  if (AKK_Helper.C.strG_Bankverbindung_AUS_Bank == AKK_Helper.c_Yes) cmd_Bank_Aus.Enabled = true;
                                }

                            }
                        }

                        else
                        {
                            AKK_Helper.show_msg("Bankverbindung in PVS nicht gefunden!", strip_info, this.Cursor);
                        }
                    }
                    this.Cursor = Cursors.WaitCursor;
                    strip_info.Text = "";
                }
                else
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                }
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + ex.InnerException, strip_info, this.Cursor);
            }

            this.Cursor = Cursors.Default;
        }
        private void cmd_Bank_Ein_Click(object sender, EventArgs e)
        {
            is_changed_ein = true;
            try
            {
                is_Aus = false;
                this.Cursor = Cursors.WaitCursor;
                strip_info.Text = "Personenverwaltung wird gestartet . . .";
                //
                if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                {
                    //
                    // Neue Bankverbindung selektiern
                    //
                    if (AKK_Helper.is_empty(Bank_Ein) == true || Bank_Ein == "-1")
                    {
                        try
                        {
                            string str_where = "PersonID='" + person_id + "'";
                            string str_Type = "PE";
                            Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                            if (pvs_col.Count > 0)
                            {
                                foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                {
                                    PVS_do_WE = pvs_do;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            AKK_Helper.show_msg("Fehler beim Lesen der PVS Person : " + person_id + " : " + ex.InnerException, strip_info, this.Cursor);
                        }
                        try
                        {
                            PVS_wnd_WE = AKK_Helper.PVS_CON.PVS_APP.OpenWindow("BV", "LIST");
                            PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                            PVS_wnd_WE.SetAssignMode("addIT", false);
                            // PVS_wnd_WE.SetNewMode();  09-07-2012 by KJ 2

                            PVS_wnd_WE.ClearSearchFields();
                            PVS_wnd_WE.SearchCondition = "PersonID='" + person_id + "'";
                            PVS_wnd_WE.Read();
                        }
                        catch (Exception ex)
                        {
                            AKK_Helper.show_msg("Fehler beim Öffnen der Bankverbindungen - PersonID=" + person_id + " : " + ex.InnerException, strip_info, this.Cursor);
                        }
                        //
                        // init controle
                        //
                        if (AKK_Helper.My_user.CanWrite == true)
                        {
                            cmd_speichern_ein.Enabled = true;
                            cmd_loeschen_ein.Enabled = false;
                            cmd_Bank_Ein.Enabled = true;
                        }
                        else
                        {
                            cmd_speichern_ein.Enabled = false;
                            cmd_loeschen_ein.Enabled = false;
                            cmd_Bank_Ein.Enabled = false;

                            if (AKK_Helper.My_user.CanRead == true)
                            {
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = true;
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = false;
                                if (AKK_Helper.C.strG_Bankverbindung_EIN_Bank == AKK_Helper.c_Yes) cmd_Bank_Ein.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        //
                        // Ändern
                        //
                        Miracle.MPP.WebPCI.Collection pvs_col = null;
                        //
                        string str_where = "Key = '" + Bank_Ein + "'";
                        pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere("BV", str_where, null, null);
                        //
                        if (pvs_col.Count > 0)
                        {
                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                            {
                                try
                                {
                                    PVS_do_WE = pvs_do;             // Create Dataobject
                                    PVS_do_WE.OnUpdate += new Miracle.MPP.WebPCI.DataObject.OnUpdateEventHandler(PVS_do_WE_OnUpdate);
                                    //
                                    PVS_wnd_WE = pvs_do.Edit();    // Create Window
                                    PVS_wnd_WE.SetAssignMode("addIT", false);
                                    PVS_wnd_WE.Activate();         // activate Window 
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg("Fehler beim Öffnen der Bankverbindungen - Key=" + Bank_Aus + " : " + ex.InnerException, strip_info, this.Cursor);
                                }
                            }
                            //
                            // init controle
                            //
                            if (AKK_Helper.My_user.CanWrite == true)
                            {
                                cmd_speichern_ein.Enabled = false;
                               // cmd_loeschen_ein.Enabled = true;
                                // cmd_Bank_Ein.Enabled = true;
                            }
                            else
                            {
                                cmd_speichern_ein.Enabled = false;
                                cmd_loeschen_ein.Enabled = false;
                                cmd_Bank_Ein.Enabled = false;

                                if (AKK_Helper.My_user.CanRead == true)
                                {
                                    if (AKK_Helper.C.strG_Bankverbindung_EIN_Speichern == AKK_Helper.c_Yes) cmd_speichern_ein.Enabled = false;
                                    if (AKK_Helper.C.strG_Bankverbindung_EIN_Löschen == AKK_Helper.c_Yes) cmd_loeschen_ein.Enabled = true;
                                    //    if (AKK_Helper.C.strG_Bankverbindung_EIN_Bank == AKK_Helper.c_Yes) cmd_Bank_Ein.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            AKK_Helper.show_msg("Bankverbindung in PVS nicht gefunden!", strip_info, this.Cursor);
                        }
                    }
                    this.Cursor = Cursors.WaitCursor;
                    strip_info.Text = "";
                }

                else
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                }
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC010"] + ex.InnerException, strip_info, this.Cursor);
            }

            this.Cursor = Cursors.Default;




        }

        void PVS_do_WE_OnUpdate()
        {
            try
            {
                Boolean is_ok = get_PVS_Data(PVS_do_WE);
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
            }

        }



        void PVS_wnd_WE_OnAssign(object rows)
        {
            PVS_wnd_WE.OnAssign -= new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
            Miracle.MPP.WebPCI.Collection pvs_col = (Miracle.MPP.WebPCI.Collection)rows;
            foreach (Miracle.MPP.WebPCI.DataObject pvsdo in pvs_col)
            {

                try
                {
                    Boolean is_ok = get_PVS_Data(pvsdo);
                }
                catch (Exception ex)
                {

                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                }
            }
        }
        public Boolean get_PVS_Data(Miracle.MPP.WebPCI.DataObject PVS_do)
        {
            string str_Bank = "";
            try
            {
                ListViewItem LVI = new ListViewItem();
                LVI = AKK_Helper.get_PVS_Data_LVI(PVS_do);
                //
                string str_where = "BLZ = '" + LVI.SubItems[2].Text.ToString() + "'";
                Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere("BZ", str_where, null, null);
                if (pvs_col.Count > 0)
                {
                    foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                    {
                        // 27-08-2015 by KJ von .Fields.Items.GetValue(4); auf .Fields["Name"];["Name"] geändert
                        //Miracle.MPP.WebPCI.Field f1 = (Miracle.MPP.WebPCI.Field)pvs_do.Fields.Items.GetValue(4);
                        Miracle.MPP.WebPCI.Field f1 = (Miracle.MPP.WebPCI.Field)pvs_do.Fields["Name"];
                        //str_Bank = pvs_do.Fields.Items.GetValue(4).ToString();
                        str_Bank = f1.Value.ToString();
                        // 27-08-2015 by KJ - for testing due to different ObjectModels PVS ( AKK - addIT )
                        //Object OBJ_03 = pvs_do.Fields.Inspect();
                    }
                }
                //
                if (is_Aus == true)
                {
                    // SetText_BLZ_Aus(LVI.SubItems[2].Text.ToString());
                    SetText_KTO_Aus(LVI.SubItems[3].Text.ToString());
                    SetText_Bank_Aus(str_Bank);
                    Bank_Aus_Temp = (LVI.SubItems[13].Text.ToString());
                    SetText_BIC_Aus(LVI.SubItems[5].Text.ToString());
                    SetText_IBAN_Aus(LVI.SubItems[6].Text.ToString());
                }
                else
                {
                    SetText_BLZ_Ein(LVI.SubItems[2].Text.ToString());
                    SetText_KTO_Ein(LVI.SubItems[3].Text.ToString());
                    SetText_Bank_Ein(str_Bank);
                    Bank_Ein_Temp = (LVI.SubItems[13].Text.ToString());
                    SetText_BIC_Ein(LVI.SubItems[5].Text.ToString());
                    SetText_IBAN_Ein(LVI.SubItems[6].Text.ToString());
                }
                return (true);
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg("Fehler Get_PVS_Data " + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                return (false);
            }
        }
        //
        delegate void SetTextCallback(string text);

        private void SetText_Bank_Aus(string text)
        {
            /**
            if (this.txt_Bank_Aus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_Bank_Aus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_Bank_Aus.Text = text;
            }**\
        }
        private void SetText_BLZ_Aus(string text)
        {
            /**
            if (this.txt_Bankleitzahl_Aus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_BLZ_Aus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_Bankleitzahl_Aus.Text = text;
            }**/
        }
        private void SetText_KTO_Aus(string text)
        {
            /**
            if (this.txt_Kontonummer_Aus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_KTO_Aus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_Kontonummer_Aus.Text = text;
            }
             * **/
        }
        private void SetText_Bank_Ein(string text)
        {
            /**
            if (this.txt_Bank_Ein.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_Bank_Ein);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_Bank_Ein.Text = text;
            }**/
        }
        private void SetText_BLZ_Ein(string text)
        {
            /**
            if (this.txt_Bankleitzahl_Ein.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_BLZ_Ein);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_Bankleitzahl_Ein.Text = text;
            }**/
        }
        private void SetText_KTO_Ein(string text)
        {
            /**
            if (this.txt_Kontonummer_Ein.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_KTO_Ein);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_Kontonummer_Ein.Text = text;
            }
             * **/
        }
        private void SetText_BIC_Aus(string text)
        {
            /**
            if (this.txt_bic_aus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_BIC_Aus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_bic_aus.Text = text;
            }**/
        }
        private void SetText_BIC_Ein(string text)
        {/**
            if (this.txt_bic_ein.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_BIC_Ein);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_bic_ein.Text = text;
            }**/
        }
        private void SetText_IBAN_Aus(string text)
        {
            if (this.txt_iban_aus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_IBAN_Aus);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_iban_aus.Text = text;
            }
            //this.formatIban();
        }
        private void SetText_IBAN_Ein(string text)
        {
            if (this.txt_iban_ein.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText_IBAN_Ein);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txt_iban_ein.Text = text;
            }
            //  this.formatIban();
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
        private void frm_Bank_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
        }
        private void frm_Bank_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }

        private void cmd_schliessen_Click(object sender, EventArgs e)
        {
            DialogResult? result = null;
            this.ibanOhneFormatAus = Regex.Replace(txt_iban_aus.Text, @"\s+", "");

            //muss befüllt sein
            if (!(string.IsNullOrWhiteSpace(txtOwnerOut.Text) || !string.IsNullOrWhiteSpace(txt_iban_aus.Text)))
            {
                MessageBox.Show("Ein Feld bei Überweisung wurde nicht ausgefüllt. Eingaben werden nicht gespeichert!");
                return;
            }


            if (!string.IsNullOrEmpty(ibanOhneFormatAus) && !isIbanValid(ibanOhneFormatAus))
            {
                result = MessageBox.Show("Überweisungs Iban ist keine valide IBAN!");
                return;
            }


            string referenz = this.antrag.Referenz;
            this.referenz = referenz;
            string coopPartner = this.antrag.IsCoopPartner ? "1" : "0";
            this.bankInfo = new BankInfo(this.ibanOhneFormatEin, this.ownerIn, this.ibanOhneFormatAus, this.ownerOut, referenz, this.street, this.place, coopPartner);
            this.antrag.BankInf = this.bankInfo;

            //datenbank speichern
            if (this.antrag.IsCoopPartner)
            {
                Response resp = new Response();
                DataServiceClient client = new DataServiceClient();

                //if the Überweisungs Field has been changed
                if (!string.IsNullOrEmpty(ibanOhneFormatAus))
                {

                    // is_changed_aus = false;
                    Bank_Aus = Bank_Aus_Temp;


                    resp = client.update_BankDetails(AKK_Helper.SessionToken,
                                                       AKK_Helper.UserId,
                                                       str_wbd_ikey,
                                                       Bank_Aus,
                                                       "A",
                                                       this.ibanOhneFormatEin, this.ownerIn, this.ibanOhneFormatAus, this.ownerOut,
                                                        referenz, this.street, this.place, coopPartner);   // Überweisung auf !!!

                }


                if (is_changed_ein == true)
                {
                    cmd_speichern_ein_Click(sender, e);
                }
            }

            //wie gehabt mit PVS
            else
            {
                if (is_changed_aus == true)
                {
                    cmd_speichern_aus_Click(sender, e);
                }
                if (is_changed_ein == true)
                {
                    cmd_speichern_ein_Click(sender, e);
                }
            }

            this.aborted = false;
            this.Close();
            

        }

        /// <summary>
        /// Checks if an given iban is valid or not
        /// From: https://www.codeproject.com/Tips/775696/IBAN-Validator
        /// </summary>
        /// <param name="bankAccount"></param>
        /// <returns></returns>
        public static bool isIbanValid(string bankAccount)
        {
            bankAccount = bankAccount.ToUpper().Replace(" ", "").Replace("-", "");
            if (String.IsNullOrEmpty(bankAccount) || bankAccount.Length>34 || bankAccount.Length<5)
                return false;
            else if (Regex.IsMatch(bankAccount, "^[A-Z0-9]+$"))
            {
                string bank =
                bankAccount.Substring(4, bankAccount.Length - 4) + bankAccount.Substring(0, 4);
                int asciiShift = 55;
                StringBuilder sb = new StringBuilder();
                foreach (char c in bank)
                {
                    int v;
                    if (Char.IsLetter(c)) v = c - asciiShift;
                    else v = int.Parse(c.ToString());
                    sb.Append(v);
                }
                string checkSumString = sb.ToString();
                int checksum = int.Parse(checkSumString.Substring(0, 1));
                for (int i = 1; i < checkSumString.Length; i++)
                {
                    int v = int.Parse(checkSumString.Substring(i, 1));
                    checksum *= 10;
                    checksum += v;
                    checksum %= 97;
                }
                return checksum == 1;
            }
            else
                return false;
        }


        /// <summary>
        /// adds an empty string after every four chars of an string
        /// </summary>
        /// <param name="iban"></param>
        /// <returns></returns>
        private string formatIban(string iban)
        {
            iban = Regex.Replace(iban, @"\s+", "");
            iban = Regex.Replace(iban, ".{4}", "$0 ");
            return iban;

        }



        private void txt_iban_aus_TextChanged(object sender, EventArgs e)
        {

            TextBox box = (sender as TextBox);
            box.Text = formatIban(box.Text);
            box.Select(box.Text.Length, 0); //cursor jumps back to the beginning out of some reason...
        }




        private void txtOwnerIn_TextChanged(object sender, EventArgs e)
        {

            this.ownerIn = txtOwnerIn.Text;

        }

        private void txt_iban_ein_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (sender as TextBox);
            box.Text = formatIban(box.Text);
            box.Select(box.Text.Length, 0); //cursor jumps back to the beginning out of some reason...
        }

        private void txtOwnerOut_TextChanged(object sender, EventArgs e)
        {
            this.ownerOut = txtOwnerOut.Text;
        }

        private void placeBox_TextChanged(object sender, EventArgs e)
        {
            this.place = placeBox.Text;
        }

        private void streetBox_TextChanged(object sender, EventArgs e)
        {
            this.street = streetBox.Text;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {

            this.antrag.BankInf = this.bankInfo;
            this.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

       
    }   // Class
}  // Namespace

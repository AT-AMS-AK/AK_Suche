using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Runtime.Serialization;
using Addit.AK.WBD.AK_Suche.DataService;

namespace Addit.AK.WBD.AK_Suche
{
    public partial class frm_Version : Form
    {
        public void read_verion_info(object sender, EventArgs e)
        {
            // http://10.140.4.71/Services/DocumentGenerationService/DocumentGeneration.svc

            // insert into wbd_version values(seq_ver.nextval,'C','AK_Suche','13.10.2011','v 1.0.0.14','Reportüberprüfung, Konto/Rückstand mit Plus, Bildungsträger...') 
             // update wbd_version set ver_date = '13.10.2011', ver_version = 'v 1.0.0.14' where ver_ikey =0 and ver_typ = 'C' 
            AKK_Helper.obj_version.str_version = "3.0";
            AKK_Helper.obj_version.str_version_date = "16-01-2018";
            /*
             * ATTENTION 12-12-2012
             * 
             * Wenn nach dem Compiliern und Einspieln, eine Sicherheitswarnung beim Starten der Applikation
             * am Schirm erscheint - "Der Herausgeber konnte nicht verifiziert werden. Möchten sie die Software ausführen?"
             * dann muss die exe von einem NTFS Drive auf eine FAT(32) Drive kopiert werden. Dadurch werden einige
             * Dateiattribute weggeworfen. Ein erneutes Kopieren von Fat(32) auf NTFS mit den nicht mehr vorhandenen
             * Attributen durchführen und exe starten - der Sicherheitshinweis kommt nun nicht mehr! Problem behoben.
             * 
             * 
             * ATTENTION 12-12-2012
             * */
            /* 1.0.0.0  04-07-2011 KJ  Original Version
             * 1.0.0.1  05-07-2011 KJ  Anzeige "geklaget DL" war nicht in Ordnung - korrigiert
             * 1.0.0.2  06-07-2011 KJ  * Button <Info> in AK Suche wurde implementiert ( Table - wbd_version )
             *                         * Betrag Anzeige bei neuerefasstem DL in Listbox ohne Punkt - korrigiert 
             * 
             * 
             * 1.0.0.4  08-07-2011 KJ * Kleine Änderungen von Fr. Schmautz ( Liste )
             * 1.0.0.5                * Versionsmanagement  
             *                        * Änderungen Fr. Schmautz ( eMail 13-07-2011 ) 
             *                        * Schriftgröße angepasst ( 11 / 9 ) 
             * 1.0.0.6  19-07-2011 KJ * Aktivierung/Deaktivierung der Felder beim DL lt. Fr Schmautz implementiert
             *                        * Änderungen Fr. Schmautz ( eMail 14-07-2011 )  
             * 1.0.0.7  20-07-2011 KJ * Datumsabfrage beim Buchen des Leihgeldes war nicht korrekt
             *                        * Versionsüberpfüfung noch einbauen!!!
             * 1.0.0.8  22.07-2011 KJ * Felder bei DL Erfassung waren gesperrt - korrigiert!    
             * 1.0.0.12 13-09-2011 KJ * Zurücksetzen der Tabelle akf_auswertung wenn ein Druck hängt
             *                          F,R,X wird beim Einzugskonto angezeigt  
             * 1.0.0.13 19-09-2011 KJ * Anmerkung auf 512 Zeichen reduziert
             * 1.0.0.14 27-09-2011 KJ * Wenn gedruckt wird, wird auf alle Reports abgefragt und nicht auf einen
             *                            gelöscht werden alle Einträge ind der akf_auswertung --> RE
             *                          Kontostand & Rückstand sind mit Pluszeichen versehen
             *                          Bildungsträger nur bei Aus und Weiterbildung verfügbar
             *                          Darlehensbetrag in der frm_Antraege ist 0 --> konnte nicht verifiziert werden
             *                          Wenn ein DN schon ein DL hat, gibt es eine Mitteilung ( nicht TG nicht NG )
             *                          Debmul, Cremul haben eine Meldung wenn die Verarbeitung beendet ist ( posetiv und negativ )
             *                          Bei "geklagt" muss die Anmerkung auf "geklagt" überschrieben werden - ist aber editierbar
             *                          Anzahl der bearbeiteten DS bei Auszahlungsdatum setzen wird angezeigt.
             * 1.0.0.15 29-11-2011 KJ * Erweiterung um WBD_EIN_IDX ( WBD_DATA ). Änderungen im Service & PL/SQL                       
             * 1.0.0.16 19-12-2011 KJ * Erweiterung um Rückstand wenn Überzahlung
             * 1.0.0.17 12-01-2012 KJ * Laufzeit von 99 auf 999 ( 3-stellig angepasst )
             *                        * Datumsangabe in StripBar von Donnerstag auf Do. geändert
             * 1.0.0.18 17-04-2012 KJ * Bei CanRead True  = cmd_Auswertung visible                       
             *                          Bei CanRead false = cmd_Auswertung invisible
             * 1.0.0.19 25-04-2012 KJ * Abfrage ob Mahnlauf wirklich gestartet werden soll
             *                          ( Wurde zweimal auf einem Tag aufgerufen )
             * 1.0.0.20 15-05-2012 KJ * Abfragen PVS von Indexes auf Namen geändert ( BZ, BV, AP)
             * 1.0.0.21 30-05-2012 KJ * Traceoptionen für PVS ( 2 und 3 ter Parameter von args[] )
             *                          2 Parameter J or Y
             *                          3 Parameter Name of LogFile ( C:\temp\PVSLOG.log )
             * 1.0.0.22 09-07-2012 KJ * PVS_wnd_WE.SetNewMode() wurde in der Solution auskommentiert                          
             * 1.0.0.23 03-09-2012 KJ * SingleSignOn für die PVS ( WBD_Config 208 Yes/No )
             * 1.0.0.24 24-10-2012 KJ * SingleSignOn für das WBD ( neuer Parameter beim Starten 
             *                          4 Parameter SSO or NOSSO
             * 1.0.0.25 29-10-2012 KJ * FM beim Starten der PVS - Fehler beim Starten der PVS -
             * 1.0.0.26 10-12-2012 KJ * Read Only Right auch für CMD-Controlls implementiert
             *                          ( WBD_Config 209 - 242 )
             * 1.0.0.27 26-08-2015 KJ * pvs_do.Inspect() für BV eingebaut ( TestVersion )
             * 1.0.0.28 27-08-2015 KJ * PVS BZ von Index auf Name umgestellt
             * 1.0.0.29 29-09-2015 KJ * 1.0.0.8 mit neuer PVS ( 3.4.0.0 statt 3.2.0.0 ) getestet
             * 1.0.0.30 02-10-2015 KJ * dat_ausz_gepl lag zu sehr in der Vergangenheit ( mehr als 15 Jahre, wurde von -15 to + 15 auf -30 to + 10 geändert )
             *                          liegt der Ausz_gepl davor - wird er nicht gesetzt ( listindex=0)
             *                          
             * 1.0.0.31  ?? ?? ???? ** * Nachtrag von CJ: Keine Ahnung, habs so übernommen.
             * 2.0.0.0 Okt-Nov 2017 CJ * ISH als Verwendungszweck hinzugefügt, ISH erfassen und bearbeiten, 
             *                           ISH Einzeldruck - hat eigene Vorlagen, ISH Seriendruck - strikte Trennung von WBD und ISH, ISH Auswertung - eigene Reports,
             *                           ISH Datenträger erstellen - wieder strikte Trennung
             *                           
             * 3.0 Dez-April 2017-2018 CJ * ISH Mahnlauf und Fehler ausbessern von vorigen Änderungen
             * 
             * 
             * Nov - Dec 2021 MR * Anpassungen für Wärmepumpe
             */
        }
       
        // public clsA_version obj_version;
        public frm_Version()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_version_Load(object sender, EventArgs e)
        {
            AKK_Helper.FindControls(this);

            lst_Output.Clear();
            lst_Output.Columns.Add("Index", -1, HorizontalAlignment.Left);                    // 00
            lst_Output.Columns.Add("Key", 40, HorizontalAlignment.Left);                      // 01
            lst_Output.Columns.Add("Datum", 90, HorizontalAlignment.Left);                    // 02
            lst_Output.Columns.Add("Programm", 110, HorizontalAlignment.Left);                // 03
            lst_Output.Columns.Add("Version", 100, HorizontalAlignment.Left);                 // 04
            lst_Output.Columns.Add("Changes", 500, HorizontalAlignment.Left);

            lst_Output.View = View.Details;
            lst_Output.Font = new Font(lst_Output.Font.FontFamily, AKK_Helper.FontSize);
            lst_Output.GridLines = true;
            lst_Output.LabelEdit = true;
            lst_Output.AllowColumnReorder = true;
            lst_Output.CheckBoxes = false;
            lst_Output.FullRowSelect = true;

            chk_ak_suche .Checked = true ;
              //DataService.Response resp1 = new DataService.Response();
              //      DC_Columns cols = new DC_Columns();
              //      DataService.DataServiceClient client = new DataServiceClient();
              //      resp1 = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "VERC", "");
              //      DateTime dt_new = DateTime.Now;
              //      DateTime dt_act = DateTime.Now;
              //      string   str_new = "01.01.2000";
              //      if (resp1.ResponseCode == 0)
              //      {
              //         for (Int32 i = 0; i < cols.Count; i++)
              //         {
              //             if (cols[i].DM_col_01.ToString() != null)
              //             {
              //                 txt_act_dat .Text  = cols[i].DM_col_01.ToString();    // Date
              //             }
              //             if (cols[i].DM_col_02.ToString() != null)
              //             {
              //                 txt_act_ver .Text = cols[i].DM_col_02.ToString();    // Version
              //             }
              //         }
              //         DateTime.TryParse(str_new, out dt_new);
              //         DateTime.TryParse(AKK_Helper.obj_version.str_version_date, out dt_act);
              //      }


            txt_version.Text = "Version " + AKK_Helper.obj_version.str_version + " Datum " + AKK_Helper.obj_version.str_version_date;
        }
        public void fill_view(string str_para)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                Response resp = new Response();
                DC_Columns cols = new DC_Columns();
                DataService.DataServiceClient client = new DataServiceClient();
                lst_Output.Items.Clear();

                this.Cursor = Cursors.WaitCursor;
                strip_info.Text = "";
                resp = null;
                resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, "VER", str_para);
                ListViewItem LVI_ORA_First = new ListViewItem("9999999");
                if (resp.ResponseCode == 0)
                {
                    Int32 int_ant_count = cols.Count;
                    for (Int32 i = 0; i < int_ant_count; i++)
                    {
                        ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                        if (cols[i].DM_col_01.ToString() == "0")
                        {
                            // LVI_ORA.ForeColor = Color.Red;
                            // LVI_ORA.UseItemStyleForSubItems = true;
                        }
                        else
                        {
                            LVI_ORA.ForeColor = Color.Black;
                            LVI_ORA.UseItemStyleForSubItems = true;
                            LVI_ORA.SubItems.Add(cols[i].DM_col_01.ToString());                     // 1
                        }
                        if (cols[i].DM_col_02.ToString().Length > 10)
                        {
                            LVI_ORA.SubItems.Add(cols[i].DM_col_02.ToString().Substring(0, 10));
                        }
                        else
                        {
                            LVI_ORA.SubItems.Add(cols[i].DM_col_02.ToString());                    // 2
                        }

                        LVI_ORA.SubItems.Add(cols[i].DM_col_03.ToString());                      // 3
                        LVI_ORA.SubItems.Add(cols[i].DM_col_04.ToString());                      // 4
                        LVI_ORA.SubItems.Add(cols[i].DM_col_05.ToString());                      // 4

                        if (cols[i].DM_col_01.ToString() == "0")
                        {
                            LVI_ORA_First.ForeColor = Color.Red;
                            LVI_ORA_First.UseItemStyleForSubItems = true;

                            LVI_ORA_First.SubItems.Add(" ");
                            if (cols[i].DM_col_02.ToString().Length > 10)
                            {
                                LVI_ORA_First.SubItems.Add(cols[i].DM_col_02.ToString().Substring(0, 10));
                            }
                            else
                            {
                                LVI_ORA.SubItems.Add(cols[i].DM_col_02.ToString());                    // 2
                            }
                            LVI_ORA_First.SubItems.Add(cols[i].DM_col_03.ToString());                      // 3
                            LVI_ORA_First.SubItems.Add(cols[i].DM_col_04.ToString());                      // 4
                            LVI_ORA_First.SubItems.Add(cols[i].DM_col_05.ToString());
                        }

                        else
                        {
                            lst_Output.Items.Add(LVI_ORA);
                        }
                        LVI_ORA = null;
                    }

                    lst_Output.Items.Add(LVI_ORA_First);
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
        private void chk_ak_suche_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ak_suche .Checked == true )
            {
                chk_get_data .Checked = false;
                chk_seriendruck.Checked = false;
                fill_view ("C");
            }

            else
            {
              lst_Output.Items.Clear();
            }
        }
        private void chk_get_data_CheckedChanged(object sender, EventArgs e)
        {

            if (chk_get_data.Checked == true)
            {
                chk_ak_suche.Checked = false;
                chk_seriendruck.Checked = false;
                fill_view("G");
            }

            else
            {
                lst_Output.Items.Clear();
            }
        }
        private void chk_seriendruck_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_seriendruck.Checked == true)
            {
                chk_ak_suche.Checked = false;
                chk_get_data.Checked = false;
                fill_view("S");
            }

            else
            {
                lst_Output.Items.Clear();
            }
        }

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
        private void frm_Version_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        private void frm_Version_Activated(object sender, EventArgs e)
        {
           AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 1);
        }
       # endregion

        

       
        //
    }
}

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
    public partial class frm_mitschuldner : Form
    {
        public Miracle.MPP.WebPCI.DataObject PVS_do_WE;
        public Miracle.MPP.WebPCI.Window PVS_wnd_WE;
        public string[] MS = new string[3];
        public string str_wbd_ikey;
        public Boolean ish;
        public DC_wbd_antrag cur_wbd_antrag; //Current WBD Antrag
       
        public frm_mitschuldner()
        {
            InitializeComponent();
        }
        public string[] MS_Org = new string[3];    // Original Keys

        private void frm_mitschuldner_Load(object sender, EventArgs e)
        {

            // 10-12-2012 by KJ
            if (AKK_Helper.My_user.CanWrite == true)
            {
                cmd_aendern.Enabled = true;
                cmd_Suchen.Enabled = true;
                cmd_aktual.Enabled = true;
                cmd_Speichern.Enabled = true;
                cmd_Loeschen.Enabled = true;
            }
            else
            {
                cmd_aendern.Enabled = false;
                cmd_Suchen.Enabled = false;
                cmd_aktual.Enabled = false;
                cmd_Speichern.Enabled = false;
                cmd_Loeschen.Enabled = false;
                if (AKK_Helper.My_user.CanRead == true)
                {
                    if (AKK_Helper.C.strG_Mitschuldner_Ändern == AKK_Helper.c_Yes )  cmd_aendern.Enabled = true;
                    if (AKK_Helper.C.strG_Mitschuldner_Suchen == AKK_Helper.c_Yes ) cmd_Suchen.Enabled = true;
                    if (AKK_Helper.C.strG_Mitschuldner_Aktualisieren == AKK_Helper.c_Yes ) cmd_aktual.Enabled = true;
                    if (AKK_Helper.C.strG_Mitschuldner_Speichern == AKK_Helper.c_Yes ) cmd_Speichern.Enabled = true;
                    if (AKK_Helper.C.strG_Mitschuldner_Löschen == AKK_Helper.c_Yes ) cmd_Loeschen.Enabled = true;
                }
            }
            if (ish)
            {
                chk_Bankgarantie.Enabled = false;
                chk_Bankgarantie.Visible = false;
                groupBox1.Text = "Firma";
            }
            else
            {
                chk_Bankgarantie.Enabled = true;
                chk_Bankgarantie.Visible = true;
            }
            // 03-09-2012 by KJ
            //AKK_Helper.FindControls(this);

            //if (AKK_Helper.PVS_CON.PVS_APP.Connected == true)
            //    lblCON.Text = "on";
            //else
            //    lblCON.Text = "off";
            // 03-09-2012 by KJ    
            lst_mitschuldner.Clear();
            lst_mitschuldner.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
            lst_mitschuldner.Columns.Add("User", -1, HorizontalAlignment.Left);                   // 01
            lst_mitschuldner.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 02
            lst_mitschuldner.Columns.Add("Typ", -1, HorizontalAlignment.Left);                    // 03
            lst_mitschuldner.Columns.Add("Name", 100, HorizontalAlignment.Left);                 // 04
            lst_mitschuldner.Columns.Add("Vorname/Filiale", 120, HorizontalAlignment.Left);      // 05
            lst_mitschuldner.Columns.Add("SVNr/BLZ", 80, HorizontalAlignment.Left);              // 06
            lst_mitschuldner.Columns.Add("Strasse", 150, HorizontalAlignment.Left);              // 07
            lst_mitschuldner.Columns.Add("Ort", 250, HorizontalAlignment.Left);                  // 08

            lst_mitschuldner.View = View.Details;
            lst_mitschuldner.Font = new Font(lst_mitschuldner.Font.FontFamily, AKK_Helper.FontSize);
            lst_mitschuldner.GridLines = true;
            lst_mitschuldner.LabelEdit = true;
            lst_mitschuldner.AllowColumnReorder = true;
            lst_mitschuldner.CheckBoxes = false;
            lst_mitschuldner.FullRowSelect = true;
            lst_mitschuldner.MultiSelect = false;
            //
            // Save original values for addrefs und removeextrefs
            //
            MS_Org[0] = MS[0];
            MS_Org[1] = MS[1];
            MS_Org[2] = MS[2];
            //
            read_mitschuldner(MS[0], MS[1], MS[2]);     // Show MS
            if (lst_mitschuldner .Items.Count > 0 )
            {
                lst_mitschuldner.Items[0].Selected = true;  // Set First
            }
            lst_mitschuldner.Select();


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
        private void frm_mitschuldner_Activated(object sender, EventArgs e)
        {
            AKK_Helper.UpdateKeys(lblINS, lblNUM, lblCAPS, lblCON, lblLOCK, labelDayDate, 0);
        }
        private void frm_mitschuldner_KeyUp(object sender, KeyEventArgs e)
        {
            AKK_Helper.KeyUp(sender, e, lblINS, lblNUM, lblCAPS, lblCON);
        }
        //
        // Schliessen
        //
        private void cmd_Schliessen_Click(object sender, EventArgs e)
        {
            this.Close();    
        }
        //
        // MSx lesen
        //
        private void read_mitschuldner(string Mitschuldner1, string Mitschuldner2, string Mitschuldner3)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if ((AKK_Helper.is_empty(Mitschuldner1) == true))
                    Mitschuldner1 = "-1";
                if ((AKK_Helper.is_empty(Mitschuldner2) == true))
                    Mitschuldner2 = "-1";
                if ((AKK_Helper.is_empty(Mitschuldner3) == true))
                    Mitschuldner3 = "-1";
                //
                // str_ms2 = @"DO\BZ\$101000001810425";
                // str_ms3 = @"DO\AP\$101000015074344";
                // str_ms3 = @"-1";
                Response resp = new Response();
                DataServiceClient client = new DataServiceClient();
                DC_lst_ak_cursor obj_mitschuldner = new DC_lst_ak_cursor();
                resp = client.Get_Mitschuldner(out obj_mitschuldner, AKK_Helper.SessionToken, AKK_Helper.UserId, Mitschuldner1, Mitschuldner2, Mitschuldner3);
                if (resp.ResponseCode == 0)
                {
                    lst_mitschuldner.Items.Clear();
                    if (obj_mitschuldner != null)
                    {
                        Int32 int_mit_count = obj_mitschuldner.Count;
                        if (int_mit_count > 0)    // Any records found
                        {
                            for (int i = 0; i < int_mit_count; i++)
                            {
                                ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_User);             // 1 
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Index);            // 2
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_01);           // 3 Type
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_02);           // 4 NN & Bank
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_03);           // 5 VN & Filiale
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_04);           // 6 SVNR & BLZ
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_08 + " " +
                                                        obj_mitschuldner[i].DM_Dat_09 + " " +
                                                        obj_mitschuldner[i].DM_Dat_10);           // 7 Str HNR Tur 
                                LVI_ORA.SubItems.Add(obj_mitschuldner[i].DM_Dat_05 + " " +
                                                        obj_mitschuldner[i].DM_Dat_06 + " " +
                                                        obj_mitschuldner[i].DM_Dat_07);           // 8 Nat PLZ Ort

                                lst_mitschuldner.Items.Add(LVI_ORA);
                                LVI_ORA = null;

                            }
                        }
                    }
                    if (lst_mitschuldner.Items.Count > 0)
                    {
                        lst_mitschuldner.Items[0].Selected = true;  // Set First
                    }
                    lst_mitschuldner.Select();
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    AKK_Helper.handleServiceError(resp);
                }
            }
        }
        //
        // PVS Ändern
        //
        private void cmd_aendern_Click(object sender, EventArgs e)
        {
            try
            {
                if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                {
                    if (lst_mitschuldner.SelectedItems.Count > 0)
                    {
                        ListViewItem li = null;
                        string str_Index = "";      //  0,1,2 --> selected Item
                        string str_Type = "";   // AP oder BV
                        string str_personid = "";
                        //
                        for (int i = lst_mitschuldner.SelectedItems.Count - 1; i >= 0; i--)
                        {
                            li = lst_mitschuldner.SelectedItems[i];

                            str_Index = li.SubItems[2].Text.ToString();   // 1,2,3
                            str_Type = li.SubItems[3].Text.ToString();   // AP ode BV
                        }
                        //
                        Int32 int_Type;
                        Int32.TryParse(str_Index, out int_Type);
                        str_personid = MS[int_Type - 1];

                        this.Cursor = Cursors.WaitCursor;

                        if (str_personid != "")
                        {
                            Miracle.MPP.WebPCI.Collection pvs_col = null;
                            strip_info.Text = str_personid + " : Personenverwaltung wird gestartet . . .";
                            if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                            {
                                string str_where = "Key = '" + str_personid + "'";
                                pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);

                                if (pvs_col.Count > 0)
                                {
                                    foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                    {
                                        PVS_do_WE = pvs_do;               // Create Dataobject
                                        PVS_do_WE.OnUpdate += new Miracle.MPP.WebPCI.DataObject.OnUpdateEventHandler(PVS_do_WE_OnUpdate);
                                        try
                                        {
                                            PVS_wnd_WE = pvs_do.Edit();        // Create Window
                                            PVS_wnd_WE.SetAssignMode("addIT", false);
                                            PVS_wnd_WE.Activate();         // activate Window 
                                        }
                                        catch (Exception ex)
                                        {
                                            AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + " FC001 " + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            AKK_Helper.show_msg(AKK_Helper.str_error["FC003"], strip_info, this.Cursor);
                        }
                        strip_info.Text = "";
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        AKK_Helper.show_msg("Es wurde kein Eintrag selektiert", strip_info, this.Cursor);
                        if (lst_mitschuldner.Items.Count > 0)
                        {
                            lst_mitschuldner.Items[0].Selected = true;  // Set First
                        }
                        lst_mitschuldner.Select();
                    }
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
        }
        
        void PVS_do_WE_OnUpdate()
        {
            try
            {
                Boolean is_ok = get_PVS_Data(PVS_do_WE);
            }
            catch (Exception ex)
            {
                AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + " FC002 " + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
            }

        }
        public Boolean get_PVS_Data(Miracle.MPP.WebPCI.DataObject PVS_do)
        {

            ListViewItem LVI = new ListViewItem();       
            LVI = AKK_Helper.get_PVS_Data_LVI(PVS_do );  
            SetListbox(LVI); 
            // read_mitschuldner(MS[0], MS[1], MS[2]);
            //
            return true;
        }
        delegate void SetLstCallback(ListViewItem LVI);
        private void SetListbox(ListViewItem LVI)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lst_mitschuldner.InvokeRequired)
            {
                SetLstCallback d = new SetLstCallback(SetListbox);
                this.Invoke(d, new object[] { LVI });
            }
            else
            {
               
                //
                read_mitschuldner(MS[0], MS[1], MS[2]);
                //
            }
       }
        //
        // Löschen
        //
        private void cmd_Loeschen_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.Default;
                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }
                else
                {
                    ListViewItem li = null;
                    string str_IndexDB = "";
                    string str_Type = "";
                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {
                        if (lst_mitschuldner.SelectedItems.Count > 0)
                        {

                            for (int i = lst_mitschuldner.SelectedItems.Count - 1; i >= 0; i--)
                            {
                                li = lst_mitschuldner.SelectedItems[i];
                                li = lst_mitschuldner.SelectedItems[i];
                                lst_mitschuldner.SelectedItems[i].Remove();

                                str_IndexDB = li.SubItems[2].Text.ToString();  // 1,2,3 --> Index von DB - wenn erster Eintrag gelöscht dann gibts probleme!
                                str_Type = li.SubItems[3].Text.ToString();   // AP ode BV
                            }
                            //
                            Int32 int_Index;
                            Int32.TryParse(str_IndexDB, out int_Index);

                            if ((int_Index > 0) && (int_Index <= 3))
                            {
                                Response resp = new Response();
                                DataServiceClient client = new DataServiceClient();
                                resp = client.Delete_MS(AKK_Helper.SessionToken,
                                                         AKK_Helper.UserId,
                                                         str_wbd_ikey,
                                                         str_IndexDB);
                                if (resp.ResponseCode == 0)
                                {
                                    MS[int_Index - 1] = "";        //     --> indicate empty
                                    MS_Org[int_Index - 1] = "";    // 18-07-2011 -> notwendig für Anzeige frm_wbd_antrag
                                    //
                                    read_mitschuldner(MS[0], MS[1], MS[2]);
                                }
                                else
                                {
                                    this.Cursor = Cursors.Default;
                                    AKK_Helper.handleServiceError(resp);
                                }
                            }
                        }
                        else
                        {
                            AKK_Helper.show_msg("Es wurde kein Eintrag selektiert", strip_info, this.Cursor);
                            if (lst_mitschuldner.Items.Count > 0)
                            {
                                lst_mitschuldner.Items[0].Selected = true;  // Set First
                            }
                            lst_mitschuldner.Select();
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
        //
        // Suchen
        //
        private void cmd_Suchen_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                {
                    if (lst_mitschuldner.Items.Count <= 2)
                    {
                        if (ish && lst_mitschuldner.Items.Count != 0)
                        {
                            AKK_Helper.show_msg("Es ist bereits eine Firma erfasst!", strip_info, this.Cursor);
                            if (lst_mitschuldner.Items.Count > 0)
                            {
                                lst_mitschuldner.Items[0].Selected = true;  // Set First
                            }
                            lst_mitschuldner.Select();
                        }
                        else
                        {
                            this.Cursor = Cursors.WaitCursor;
                            strip_info.Text = "Personenverwaltung wird gestartet . . .";
                            if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                            {
                                try
                                {
                                    //Miracle.MPP.WebPCI.DataObject pvs_do = null;      // Create Dataobject
                                    AKK_Helper.PVS_CON.PVS_APP.TraceFile = "C:\\temp\\WebPCI.log";
                                    AKK_Helper.PVS_CON.PVS_APP.TraceFileFlush = true;
                                    AKK_Helper.PVS_CON.PVS_APP.TrackedSources.Remove("WinHTTP");
                                    AKK_Helper.PVS_CON.PVS_APP.TrackedSources.Remove("XMLDB");
                                    AKK_Helper.PVS_CON.PVS_APP.TrackedSources.Add("Browser");
                                    AKK_Helper.PVS_CON.PVS_APP.TrackingStarted = true;
                                    //PVS_do_WE.OnUpdate += new Miracle.MPP.WebPCI.DataObject.OnUpdateEventHandler(PVS_do_WE_OnUpdate);

                                    //
                                   
                                  
                                    if (ish)
                                    {
                                        PVS_wnd_WE = AKK_Helper.PVS_CON.PVS_APP.OpenWindow("OR", "LIST");
                                        //PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                                    }
                                    else
                                    {
                                        if (chk_Bankgarantie.Checked == true)
                                        {
                                            PVS_wnd_WE = AKK_Helper.PVS_CON.PVS_APP.OpenWindow("BZ", "LIST");
                                            //PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                                        }
                                        else
                                        {
                                            PVS_wnd_WE = AKK_Helper.PVS_CON.PVS_APP.OpenWindow("AP", "LIST");
                                            //PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                                        }
                                    }


                                    try
                                    {
                                        //PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(PVS_wnd_WE_OnAssign);
                                        //PVS_wnd_WE.SetAssignMode("addIT", false);
                                        //  PVS_wnd_WE.SetNewMode(); 09-07-2012 by KJ 3
                                        //
                                        // Clear all search Fields
                                        //
                                        PVS_wnd_WE.ClearSearchFields();
                                       
                                        PVS_wnd_WE.OnAssign += new Window.OnAssignEventHandler(this.PVS_wnd_WE_OnAssign);
                                        //
                                        // if AP then initialize Rolle = Mitschuldner
                                        //
                                        if (chk_Bankgarantie.Checked == false && !ish)
                                        {
                                            PVS_wnd_WE["RolleID"] = "MITSCH";
                                        }
                                        //

                                       
                                        PVS_wnd_WE.SetAssignMode("addIT", false);
                                        PVS_wnd_WE.Activate(); // activate Window 
                                         
                                             
                                    }
                                    catch (Exception ex)
                                    {
                                        AKK_Helper.show_msg("Fehler beim Aktivieren des PVS Fensters :" + ex.InnerException, strip_info, this.Cursor);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    AKK_Helper.show_msg("Fehler beim Öffnen des PVS Fensters :" + ex.InnerException, strip_info, this.Cursor);
                                }

                            }
                        }
                        
                    }
                    else
                    {
                        AKK_Helper.show_msg("Es sind bereits drei Mitschuldner erfasst!", strip_info, this.Cursor);
                        if (lst_mitschuldner.Items.Count > 0)
                        {
                            lst_mitschuldner.Items[0].Selected = true;  // Set First
                        }
                        lst_mitschuldner.Select();
                    }
                    strip_info.Text = "";
                    this.Cursor = Cursors.Default;
                }
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
                    Boolean is_ok = get_PVS_Data_New(pvsdo);
                }

                catch (Exception ex)
                {
                    AKK_Helper.show_msg(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString(), strip_info, this.Cursor);
                }
            }
        }
        public Boolean get_PVS_Data_New(Miracle.MPP.WebPCI.DataObject PVS_do)
        {

            ListViewItem LVI = new ListViewItem();
            LVI = AKK_Helper.get_PVS_Data_LVI(PVS_do);
            SetListboxNew(LVI);

            return true;
        }
        private void SetListboxNew(ListViewItem LIV)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lst_mitschuldner.InvokeRequired)
            {
                SetLstCallback d = new SetLstCallback(SetListboxNew);
                this.Invoke(d, new object[] { LIV });
            }
            else
            {
                if ((AKK_Helper.is_empty(MS[0]) == true) || (MS[0] == "-1"))
                {
                    MS[0] = LIV.SubItems[13].Text. ToString(); 
                }
                else
                {
                    if ((AKK_Helper.is_empty(MS[1]) == true) || (MS[1] == "-1"))
                    {
                        MS[1] = LIV.SubItems[13].Text.ToString(); 
                    }
                    else
                    { 
                        if ((AKK_Helper.is_empty(MS[2]) == true) || (MS[2] == "-1"))
                        {
                            MS[2] = LIV.SubItems[13].Text.ToString();
                        }
                        else
                        {
                            AKK_Helper.show_msg("Es gibt bereits drei Mitschuldner!", strip_info, this.Cursor);
                             if (lst_mitschuldner.Items.Count > 0)
                             {
                                 lst_mitschuldner.Items[0].Selected = true;  // Set First
                             }
                             lst_mitschuldner.Select();
                        }   
                    }
                 }
                 //   
                 read_mitschuldner(MS[0], MS[1], MS[2]);
                 //
            }
        }

        private void cmd_Speichern_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                this.Cursor = Cursors.Default;
                if (frm_wbd_antrag.is_locked == true)
                {
                    AKK_Helper.show_msg(AKK_Helper.c_gesperrt, strip_info, this.Cursor);
                }
                else
                {
                    // PVS_do_WE.AddExtRef();
                    if (AKK_Helper.check_PVS(AKK_Helper.PVS_CON, lblCON) == true)
                    {
                        Response resp = new Response();
                        DataServiceClient client = new DataServiceClient();
                        string str_where = "";
                        string str_Type = "";
                        for (int i = 0; i <= 2; i++)
                        {
                            if (AKK_Helper.is_empty(MS[i]) == true)
                                MS[i] = "-1";

                            resp = client.Update_MS(AKK_Helper.SessionToken,
                                                    AKK_Helper.UserId,
                                                    str_wbd_ikey,
                                                    MS[i],
                                                    (i + 1).ToString());   // --> Index von DB ( 1,2,3 ist der richtige !!!

                            if (resp.ResponseCode == 0)
                            {

                                if (MS_Org[i] != MS[i])
                                {
                                    //
                                    // Remove Old ExtRef
                                    //
                                    if (AKK_Helper.is_empty(MS_Org[i]) == true || MS_Org[i] == "-1")
                                    { }
                                    else
                                    {
                                        str_where = "Key = '" + MS_Org[i] + "'";
                                        str_Type = MS_Org[i].Substring(3, 2);
                                        Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                        if (pvs_col.Count > 0)
                                        {
                                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                            {
                                                pvs_do.RemoveExtRef();
                                            }
                                        }
                                    }
                                    //
                                    // Add New ExtRef
                                    //
                                    if (AKK_Helper.is_empty(MS[i]) == true || MS[i] == "-1")
                                    { }
                                    else
                                    {
                                        str_where = "Key = '" + MS[i] + "'";
                                        str_Type = MS[i].Substring(3, 2);
                                        Miracle.MPP.WebPCI.Collection pvs_col = AKK_Helper.PVS_CON.PVS_APP.SelectWhere(str_Type, str_where, null, null);
                                        if (pvs_col.Count > 0)
                                        {
                                            foreach (Miracle.MPP.WebPCI.DataObject pvs_do in pvs_col)
                                            {
                                                pvs_do.AddExtRef();
                                            }
                                        }
                                    }
                                    //                             
                                    MS_Org[i] = MS[i];  // Set Original Values Back if saved
                                }
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                AKK_Helper.handleServiceError(resp);
                            }

                        }
                        strip_info.Text = "Daten erfolgreich gespeichert!";


                        //Protokollierung Stefitz David 29.08.2018
                        DataService.DataServiceClient clientProt = new DataServiceClient();
                        clientProt.Insert_WBD_Protocol(Int32.Parse(AKK_Helper.UserId.ToString()), "INSERT", "MITSCHULDNER", cur_wbd_antrag.DM_wbd_ant_id, Int32.Parse(cur_wbd_antrag.DM_ant_ikey), "Mitschuldner gespeichert!", AKK_Helper.SessionToken); 

                    }
                }
            }
        }

        private void cmd_aktual_Click(object sender, EventArgs e)
        {
            if (AKK_Helper.checkLogin() == true)
            {
                read_mitschuldner(MS[0], MS[1], MS[2]);
            }
        }




        //
        //
        //
  }  // Class
}    // Namspace



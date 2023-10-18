using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Addit.AK.WBD.AK_Suche.AuthService;
using Addit.AK.WBD.AK_Suche.DataService;
using Addit.AK.Util;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security.Principal;

namespace Addit.AK.WBD.AK_Suche
{

    public class clsA_Config
    {

        public clsA_Config()
        {

        }

        // public string strG_AKApplikation { set; get; }
        public string strG_BEZIRK { set; get; }
        public string strG_CR_Ora_Instanc { set; get; }
        public string strG_CRPVS_Ora_Instanc { set; get; }
        //public string strG_Vorlage { set; get; }
        // public string strG_Kontrolliste { set; get; }
        // public string strG_INET { set; get; }
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT! 
        // public string strG_Titel { set; get; }
        // public string strFileG_MS1 { set; get; }
        // public string strFileG_MS2 { set; get; }
        // public string strFileG_MS3 { set; get; }
        // public string strFileG_MSB { set; get; }
        //public string strG_DSN { set; get; }
        //public string strG_UID { set; get; }
        //public string strG_PWD { set; get; }
        //public string strG_PVS_DSN { set; get; }
        //public string strG_PVS_UID { set; get; }
        //public string strG_PVS_PWD { set; get; }
        public string strTILG_O_LZV { set; get; }      //ja
        public string strSENK_O_LZV { set; get; }      //ja
        public string strTILG_M_LZV { set; get; }      //ja
        public string strSENK_M_LZV { set; get; }      //ja
        public string strSOLL_CODE { set; get; }       //ja
        public string strHABEN_CODE { set; get; }      //ja
        public string strVIGEN_CODE { set; get; }      //ja
        public string strURG_CODE { set; get; }        //ja
        public string strABL_CODE { set; get; }        //ja
        public string strLEER_CODE { set; get; }       //ja 
        public string strBEARBEITEN_CODE { set; get; } // ga
        public string strPOS_CODE { set; get; }        // ja
        public string strGEN_CODE { set; get; }        // ja
        public string strGEN_ISH_CODE { set; get; }     // ish genehmigt
        public string strGEN_ALL_CODE { set; get; }    // ja
        public string strKLGEN_CODE { set; get; }      // ja
        public string strKLGENGES_CODE { set; get; }   // ja
        public string strG_WBD_MN1 { set; get; }       // ja
        public string strG_WBD_MN2 { set; get; }       // ja
        public string strG_WBD_MN3 { set; get; }       // ja
        public string strG_WBD_MN4 { set; get; }       // ja
        // #WERT! 
        public string strG_WBD_GEKL { set; get; }      // ja
        // public string strG_MethodeID { set; get; }
        // public string strG_TemplateID { set; get; }
        public string strRCK_CODE { set; get; }        // ja
        public string strTILG_CODE { set; get; }       // ja
        public string strÜBERZ_CODE { set; get; }      // ja
        public string strRST_CODE { set; get; }        // ja
        public string strZIN_CODE { set; get; }        // ja
        public string strSTORNO_CODE { set; get; }     // ja
        public string strSPLIT_CODE { set; get; }      // ja
        public string strBAR_CODE { set; get; }        // ja
        public string intSPLIT_KEY { set; get; }       // ja
        public string strBereichKey { set; get; }      // ja
        // public string strEIGEN_CODE { set; get; }
        // public string strSANIERUNG_CODE { set; get; }
        // public string strWOHNUNG_CODE { set; get; }
        // public string strALTERNATIV_CODE { set; get; }
        // public string strALLE_CODE { set; get; }
        // public string strG_WW { set; get; }
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // #WERT!
        // public string strG_DDE_Print { set; get; }
        // public string strG_DDE_Print_Ext1 { set; get; }
        // public string strG_DDE_Print_Ext2 { set; get; }
        // public string strG_DDE_Print_Ext { set; get; }
        // public string strG_AnredeMann { set; get; }
        // public string strG_AnredeFrau { set; get; }
        // public string strG_CodeMann { set; get; }
        // public string strG_CodeFrau { set; get; }
        public string strG_PCI_DB { set; get; }
        public string strG_PCI_Creator { set; get; }
        public string strG_PCI_Version { set; get; }
        public string strG_PCI_Node { set; get; }
       // public string strVisible { set; get; }
       // public string strG_AK_Connection { set; get; }

        //public string strG_HOST { set; get; }
        //public string strG_PORT { set; get; }
        //public string strG_USER { set; get; }
        //public string strG_PWRD { set; get; }
        //public string strG_SID { set; get; }


        public string strG_SWBD_IB { set; get; }   // ja
        public string strG_SISH_IB { set; get; }   // ish ib genehmigt
        public string strG_SWBD_NG { set; get; }   // ja
        public string strG_SISH_NG { set; get; }   // ish negativ
        public string strG_SWBD_PO { set; get; }   // ja
        public string strG_SISH_PO { set; get; }   // ish positiv
        public string strG_SWBD_UG { set; get; }   // ja
        public string strG_SISH_UG { set; get; }   // ish urgenz
        public string strG_SWBD_VZ { set; get; }   // ja
        public string strG_SISH_VZ { set; get; }   // ish verzicht
        public string strG_SWBD_TL { set; get; }   // ja
        public string strG_SISH_TL { set; get; }   // ish tilgung
        public string strG_SWBD_UZ { set; get; }   // ja
        public string strG_SISH_UZ { set; get; }   // ish überzahlt
        public string strG_WBD_RZ { set; get; }    // ja
        public string strG_WBD_RZ05 { set; get; }    // ja
        public string strVIGENGES_CODE { set; get; }   // ja
        public string strKontoBlatt    { set; get; }      // ja
        public string strKontoBlattLG  { set; get; }      // ja
        public string strSDAT          { set; get; }      // ja 
        public string strMLPfad        { set; get; }          // ja
        public string strExportPfad    { set; get; }      // ja
        public string strG_Print_Temp { set; get; }     

        // public string strG_DTT_DIR_ORI { set; get; }      // ja
        // public string strG_DTT_DIR_SAV { set; get; }      // ja
        // public string strG_DTT_DIR_PRO { set; get; }      // ja

        public string strG_CR_User { set; get; }      // ja
        public string strG_CR_PW   { set; get; }      // ja
        public string strG_CRPVS_User { set; get; }      // ja
        public string strG_CRPVS_PW { set; get; }      // ja
        public string strG_SSO_PVS { set; get; }           // ja   Single Sign On for PVS 03-09-2012 by KJ 
        public string strG_SSO_WBD { set; get; }           // ja   Single Sign On for WBD 24-10-2012 by KJ 

        public string strG_Suche_Info { set; get; }   
        public string strG_Suche_Log { set; get; }   
        public string strG_Suche_Auswertung { set; get; }   
        public string strG_Suche_Seriendruck { set; get; }   
        public string strG_Suche_Datenträger { set; get; }   
        public string strG_Suche_Leihgeld { set; get; }   
        public string strG_Suche_Reset { set; get; }   
        public string strG_Suche_STD_Bearbeiten { set; get; }   
        public string strG_Suche_STD_Neu { set; get; }   

        public string strG_Antrag_Bankverbindung { set; get; }   
        public string strG_Antrag_Mitschuldner { set; get; }   
        public string strG_Antrag_Status_ändern { set; get; }   
        public string strG_Antrag_Urgenz { set; get; }   
        public string strG_Antrag_Mahnstatus { set; get; }   
        public string strG_Antrag_Kontenblatt { set; get; }   
        public string strG_Antrag_Drucken { set; get; }   
        public string strG_Antrag_Speichern { set; get; }
        public string strG_Urgenz_Urgenz_Speichern { set; get; }

        public string strG_Bankverbindung_AUS_Bank { set; get; }   
        public string strG_Bankverbindung_AUS_Übernehmen { set; get; }   
        public string strG_Bankverbindung_AUS_Speichern { set; get; }   
        public string strG_Bankverbindung_AUS_Löschen { set; get; }   
        public string strG_Bankverbindung_EIN_Bank { set; get; }   
        public string strG_Bankverbindung_EIN_Speichern { set; get; }   
        public string strG_Bankverbindung_EIN_Löschen { set; get; }   

        public string strG_Mitschuldner_Ändern { set; get; }   
        public string strG_Mitschuldner_Suchen { set; get; }   
        public string strG_Mitschuldner_Aktualisieren { set; get; }   
        public string strG_Mitschuldner_Speichern { set; get; }   
        public string strG_Mitschuldner_Löschen { set; get; }   
        
        public string strG_Kontoblatt_Manuell_Buchen { set; get; }
        public string strG_Kontoblatt_Drucken { set; get; }   
        
        public string strG_Info_Antrag_Neu { set; get; }
        public string strG_Info_Stammdaten_Bearbeiten { set; get; }

       

       
    }

    public class clsA_PVS_connection
    {
        public clsA_PVS_connection(string str_application)
        {

            if (str_application == "PVS")
            {
                PVS_APP = new Miracle.MPP.WebPCI.Application();
            }
            else
            {
                MessageBox.Show("!!!!!!");
            }
        }
        public string Version { set; get; }
        public string CreatorName { set; get; }
        public string Nodename { set; get; }
        public string Databasename { set; get; }
        public string User { set; get; }
        public string PW { set; get; }
        public Miracle.MPP.WebPCI.Application PVS_APP;
    }

    public class clsA_version
    {

        public string str_version { set; get; }
        public string str_version_date { set; get; }
       //  public string str_user { set; get; }
    }
        
   
    
    
    class AKK_Helper
    {

        public static User My_user = new User();

        public static Boolean isG_first;

        public static clsA_version obj_version = new clsA_version();
        public static Color c_get_focus = Color.Blue;
        public static Color c_lost_focus = Color.Black;
        public static Color c_lock = Color.LightPink;
        public static Color c_unlock = Color.LightGreen;
        public static Color c_inaktiv = Color.LightGray;
        public static Color c_MS = Color.Red;
        public static Color c_Version = Color.Red;
        public static Color c_Trace = Color.OrangeRed;


        public static float FontSize        = 11f;
        public static float FontSizeCmd     = 9f;
        public static float FontSizeLarge   = 14;
        public static float FontSizeFrm     = 16;

        public static string c_mit_leer = "ML";
        public static string c_ohne_leer = "OL";
        public static string c_Yes = "YES";

        public static clsA_PVS_connection PVS_CON;
        public static string c_gesperrt = "Dieser Datensatz wird von einem anderen Benutzer bearbeitet! - Speichern nicht möglich.";
        public static Int32 int_key = 0;
        public static Int32 int_index = 0;
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(int keyCode);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public static Dictionary<string, string> str_error = new Dictionary<string, string>();
        // public static DC_ak_connect CON = null;
        public static string str_Old_Status;

        public static clsA_Config C = null;
        public static string my_link = "http://localhost:8080/WBD_NEU/nwbd_DService";
        public static string my_printer = null;

        public static List<string> Templates = null; // Confirmation Printing Templtes
        public static string[] days = { "Sonntag", "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag" };

        public static void handleServiceError(Addit.AK.WBD.AK_Suche.AuthService.Response  resp)
        {
            if (resp.ResponseCode >= 500 &&  resp.ResponseCode < 600 )
            {
                
                SessionToken = null;
            }
            Cursor x = Cursors.Default;
            MessageBox.Show(String.Format("Error Nummer: {0}, Error Msg: {1}, Exception: {2} ", resp.ResponseCode, resp.ResponseMsg, resp.ExeptionMsg), String.Format("1CODE: {0}", resp.ResponseCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void handleServiceError(Addit.AK.WBD.AK_Suche.DataService.Response resp)
        {   
            if (resp.ResponseCode >= 500 && resp.ResponseCode < 600)
            {
               
                SessionToken = null;
            }
            Cursor x = Cursors.Default;
            MessageBox.Show(String.Format("Error Nummer: {0}, Error Msg: {1}, Exception: {2} ", resp.ResponseCode, resp.ResponseMsg, resp.ExceptionMsg), String.Format("2CODE: {0}", resp.ResponseCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void handleServiceError(Addit.AK.WBD.AK_Suche.DocumentGeneration.Response resp)
        {
            if (resp.ResponseCode >= 500 && resp.ResponseCode < 600)
            {
                
                SessionToken = null;
            }
            Cursor x = Cursors.Default;
            MessageBox.Show(String.Format("Error Nummer: {0}, Error Msg: {1}, Exception: {2} ", resp.ResponseCode, resp.ResponseMsg, resp.ExeptionMsg), String.Format("3CODE: {0}", resp.ResponseCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void handleServiceError(Addit.AK.WBD.AK_Suche.BankRecordCarrier.Response resp)
        {
            if (resp.ResponseCode >= 500 && resp.ResponseCode < 600)
            {
                
                SessionToken = null;
            }
            Cursor x = Cursors.Default;
            MessageBox.Show(String.Format("Error Nummer: {0}, Error Msg: {1}, Exception: {2} ", resp.ResponseCode, resp.ResponseMsg, resp.ExeptionMsg), String.Format("4CODE: {0}", resp.ResponseCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static string SessionToken { get; set; }
        public static string UserName { get; set; }
        public static string UserId { get; set; }
        public static string PVSUserId { get; set; }
        public static string PVSPW { get; set; }
        public static string CrUser { get; set; }
        public static string CrPW { get; set; }
        public static string CrToken{ get; set; }
        public static string CrPVSUser { get; set; }
        public static string CrPVSPW { get; set; }
        public static string CrPVSToken { get; set; }
        public static string PVSTrace { get; set; }
        public static string PVSTraceFile { get; set; }
       

        public static AuthServiceClient authService { get; set; }
        

        public static bool doLogin(string username, string password, out string token)
        {
           
       

            Addit.AK.WBD.AK_Suche.AuthService.Response resp = authService.doLogin(out token, username, password);
            if (resp.ResponseCode == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public static bool checkLogin()
        {
            //if there is no session token do a loing
            if (SessionToken == "" || SessionToken == null)
            {
                //string s1;
                //Addit.AK.WBD.AK_Suche.AuthService.AuthServiceClient s = new Addit.AK.WBD.AK_Suche.AuthService.AuthServiceClient();
                //s.doLogin(out s1, "kohout", "kohout");
                //SessionToken = s1;
                //
                // 24-10-2012 by KJ implement SSO for WBD
                //
                if (AKK_Helper.C.strG_SSO_WBD == "Y")
                {
                    # region if1
                    string adKey = "Th1515MyGr34t4DK3yt03n(ryptth34DU53rS3cur3!!Th15h45t0b3H4rdc0d3d";
                    String DomainUser = WindowsIdentity.GetCurrent().Name;
                    String Domain = DomainUser.Split('\\')[0];
                    String User = DomainUser.Split('\\')[1];
                    string token = null;

                    Addit.AK.WBD.AK_Suche.AuthService.Response resp = new AuthService.Response();
                    resp = authService.doSSOLogin(out token, Encryptor.EncryptString(DomainUser, adKey));
                    if (resp.ResponseCode == 505 || resp.ResponseCode == 506)
                    {
                        Login l = new Login(doLogin);
                        l.ShowDialog();

                        System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;

                        while (dlgResult != System.Windows.Forms.DialogResult.OK) //retry login
                        {
                            dlgResult = l.DialogResult;
                            
                            AuthService.User usr = null;
                            if (dlgResult == System.Windows.Forms.DialogResult.OK) //logged in
                            {

                               
                                SessionToken = l.sessionToken;
                                return true;
                            }
                            else if (dlgResult == System.Windows.Forms.DialogResult.Retry) //wrong credentials
                            {
                                MessageBox.Show("Login failed!", "Login failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                l.ShowDialog();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return true;
                    }

                    if ((resp.ResponseCode == 0))
                    {
                        
                        SessionToken = token;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(String.Format("Fehler : {0} - {1}", resp.ResponseCode, resp.ResponseMsg), "Login failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    # endregion
                }
                else
                {
                    #region if2
                    Login l = new Login(doLogin);
                    l.ShowDialog();

                    System.Windows.Forms.DialogResult dlgResult = System.Windows.Forms.DialogResult.None;

                    while (dlgResult != System.Windows.Forms.DialogResult.OK) //retry login
                    {
                        dlgResult = l.DialogResult;

                       
                        if (dlgResult == System.Windows.Forms.DialogResult.OK) //logged in
                        {
                            

                            SessionToken = l.sessionToken;
                            return true;
                        }
                        else if (dlgResult == System.Windows.Forms.DialogResult.Retry) //wrong credentials
                        {
                            MessageBox.Show("Login failed!", "Login failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            l.ShowDialog();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    #endregion
                    return true;
                }
            }
            return true;
        }

        public static Boolean is_date(string x_date)
        {
            DateTime value;
            DateTime min_value = new DateTime(1890,01,01,0,0,0);
            DateTime max_value = new DateTime(2300,12,31,0,0,0);
            if (x_date == null)
                return false;
            else
            {
                if (x_date.Trim() != ".  .")
                {
                    if (!DateTime.TryParse(x_date, out value))
                        return false;
                    else
                       { 
                        if ( value >= min_value && value <= max_value )
                            return true;
                        else
                             return false;
                        }
                }
                return true;
            }
        }
        
        public static void fill_Listbox(ComboBox cbo_box, DC_Columns cols)
        {
            Int32 int_col_count = cols.Count;
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Description", typeof(string));
            cbo_box.ValueMember = "Id";
            cbo_box.DisplayMember = "Description";

            for (int i = 0; i < int_col_count; i++)
            {
                //David Stefitz 01.02.2019 Dummy VWZ filtern
                if (cols[i].DM_col_02 != "-10")
                {
                    table.Rows.Add(new object[] { cols[i].DM_col_02, cols[i].DM_col_01 });
                }
            }
            if (int_col_count == 0)
            {
                table.Rows.Add(new object[] { 0, "" });
            }
            cbo_box.DataSource = table;
        }

        public static void fill_dgv(DataGridView dgv, DC_Columns cols)
        {

            Int32 int_col_count = cols.Count;
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("SP1", typeof(string));
            table.Columns.Add("Sp2", typeof(string));
            table.Columns.Add("Sp3", typeof(string));
            table.Columns.Add("Sp4", typeof(string));
            table.Columns.Add("Sp5", typeof(string));

            table.Columns.Add("SP6", typeof(string));
            table.Columns.Add("Sp7", typeof(string));
            table.Columns.Add("Sp8", typeof(string));
            table.Columns.Add("Sp9", typeof(string));
            table.Columns.Add("Sp10", typeof(string));


            for (int i = 0; i < int_col_count; i++)
            {
                table.Rows.Add(new object[] { i,cols[i].DM_col_01, cols[i].DM_col_02, cols[i].DM_col_03, 
                                                cols[i].DM_col_04, cols[i].DM_col_05, cols[i].DM_col_06, 
                                                cols[i].DM_col_07, cols[i].DM_col_08, cols[i].DM_col_09,
                                                cols[i].DM_col_10});
            }
            dgv.DataSource = table;
        }

        public static Boolean is_empty_date(string strX_Date)
        {
        if (strX_Date != null) 
            {

            string str_Date = strX_Date.Trim();
            if ((str_Date == null) || 
                (str_Date == string.Empty) || 
                (str_Date == "") || 
                (str_Date == "__.__.____" ) ||
                (str_Date == ".  .")  
                )
                return (true);
            else
                return (false);
            }
            else return false;
        }

        public static Boolean is_empty_YYMM(string strX_Date)
        {
            if (strX_Date != null)
            {

                string str_Date = strX_Date.Trim();
                if ((str_Date == null) ||
                    (str_Date == string.Empty) ||
                    (str_Date == "") ||
                    (str_Date == "__.__") ||
                    (str_Date == ".")
                    )
                    return (true);
                else
                    return (false);
            }
            else return false;
        }

        public static Boolean is_empty(string strX_Str)
        {
            if (strX_Str != null)
            {
                string str_str = strX_Str.Trim();
                if ((strX_Str == string.Empty) || 
                    (strX_Str == ""))
                    return (true);
                else
                    return (false);
            }
            return true;
        }

        public static Boolean is_empty_Null(string strX_Str)
        {
            if (strX_Str != null)
            {
                string str_str = strX_Str.Trim();
                double dbl_X;
                Double.TryParse(str_str, out dbl_X);
                if (dbl_X == 0.0)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public static Int32 String_to_Number ( String str_DateX, String str_Format )
        {
            Int32  int_Date = 0;
            string str_DD   = "";
            string str_MM   = "";
            string str_YY   = "";
            string str_Date = "";

            if ( str_Format == "DD.MM.YYYY" )
            {
                str_DD = str_DateX.Substring(0, 2);
                str_MM = str_DateX.Substring(3, 2);
                str_YY = str_DateX.Substring(6, 4);
            }
            if (str_Format == "YYYY.MM.DD")
            {
                str_DD = str_DateX.Substring(8, 2);
                str_MM = str_DateX.Substring(5, 2);
                str_YY = str_DateX.Substring(0, 4);
            }
            str_Date = str_YY + str_MM + str_DD ;
            Int32.TryParse(str_Date, out int_Date);
            return int_Date;
        }

        public static void ChangeBoxSel(ComboBox cbo_box, string str_code, Int32 int_col, DataGridView dgv)
        {
           Int32 int_ikey = 0; ;
           for (Int32 i = dgv.RowCount - 1; i >= 0; i--)
            {   
               String  dgvC = dgv[int_col+1,i].Value.ToString();

               String dgvC1 = dgv[1, i].Value.ToString(); 
               String dgvC2 = dgv[2, i].Value.ToString(); 
               String dgvC3 = dgv[3, i].Value.ToString(); 
               String dgvC4 = dgv[4, i].Value.ToString(); 
               String dgvC5 = dgv[5, i].Value.ToString(); 
               String dgvC6 = dgv[6, i].Value.ToString(); 

               if (dgvC == str_code.ToString())
               {    
                   Int32.TryParse(dgv[2, i].Value.ToString (), out int_ikey);
                   cbo_box.SelectedValue = int_ikey;
                   i = -1;
               }
            }


        }

        public static string ChangeDGVSel(string str_code, Int32 int_col, DataGridView dgv)
        {
            String dgvC = null;
            for (Int32 i = dgv.RowCount - 1; i >= 0; i--)
            {

                String dgvC1 = dgv[1, i].Value.ToString();
                String dgvC2 = dgv[2, i].Value.ToString();
                String dgvC3 = dgv[3, i].Value.ToString();
               // String dgvC4 = dgv[4, i].Value.ToString();
               // String dgvC5 = dgv[5, i].Value.ToString();
               // String dgvC6 = dgv[6, i].Value.ToString(); 
                
                
                if (str_code == dgv[2, i].Value.ToString())
                {
                    dgvC = dgv[int_col, i].Value.ToString();  
                }
            }
            return dgvC;
        }

        public static string FormatBetrag ( string str_Wert )
        {
        decimal dbl_Betrag;
        decimal.TryParse(str_Wert, out dbl_Betrag);

        //David Stefitz 09.11.2018
        return dbl_Betrag.ToString("N");
        
        //return string.Format("{0:0,0,0.00#}", dbl_Betrag);
        

        }

        public static string FormatBetragPlus(string str_Wert)
        {
            double dbl_Betrag;
            double.TryParse(str_Wert, out dbl_Betrag);

            string MyString = dbl_Betrag.ToString("+#;#;0");
            if (dbl_Betrag > 0)
            {
                string str = string.Format("{0:#,###0.00}", dbl_Betrag);
                str = "+" + str;
                return str;
            }
            else
            {
                return string.Format("{0:#,###0.00}", dbl_Betrag);
            }

        }
        public static string FormatBetragOhneKomma(string str_Wert)
        {
            double dbl_Betrag;
            double.TryParse(str_Wert, out dbl_Betrag);

            return string.Format("{0:#,###0}", dbl_Betrag);
             

        }

        public static KeyPressEventArgs format_input_number(object sender, KeyPressEventArgs e, string txt_string)
        // KeyPressEventArgs, dessen Property KeyChar die den Wert der gedrückten 
        // Taste zurück gibt (A=65, z=122, 0=48, 9=59, usw.)
        {
           Int32 iKey = e.KeyChar;
           if (iKey == 46)
           {
                string str = txt_string;
                if (str.IndexOf(".", 0) > 0)
                e.Handled = true;
           }
           else
           {
                if (iKey == 44)
                {
                    string str = txt_string;
                    if (str.IndexOf(",", 0) > 0)
                         e.Handled = true;
                }
                else
                {
                    if (((iKey >= 48) && (iKey <= 59)) || (iKey == 8 ))
                    { 
                    }
                    else
                    { 
                        e.Handled = true; 
                    }
                }
            }
           return e;
        }
        public static void UpdateInsert(ToolStripStatusLabel TSSL)
        {
            bool NumLock = (GetKeyState((int)Keys.Insert)) != 0;

            if (NumLock)
            {
                TSSL.Text = "EIN";
            }
            else
            {
                TSSL.Text = "UEB";
            }

            // TSSL.Refresh();
        }
        public static void UpdateNUMLock(ToolStripStatusLabel TSSL)
        {
            bool NumLock = (GetKeyState((int)Keys.NumLock)) != 0;

            if (NumLock)
            {
                TSSL.Text = "NUM";
            }
            else
            {
                TSSL.Text = String.Empty;
            }

            //this.Refresh();
        }
        public static void UpdateCAPSLock(ToolStripStatusLabel TSSL)
        {
            bool CapsLock = (GetKeyState((int)Keys.CapsLock)) != 0;

            if (CapsLock)
            {
                TSSL.Text = "CAPS";
            }
            else
            {
                TSSL.Text = String.Empty;
            }

            // this.Refresh();
        }
        public static void UpdateKeys(ToolStripStatusLabel lblINS,
                                      ToolStripStatusLabel lblNUM,
                                      ToolStripStatusLabel lblCAPS,
                                      ToolStripStatusLabel lblCON,
                                      ToolStripStatusLabel lblLOCK ,
                                      ToolStripStatusLabel lableDayDate,
                                      Int32  int_flag)
                                     
        {

            UpdateInsert(lblINS);
            UpdateNUMLock(lblNUM);
            UpdateCAPSLock(lblCAPS);

            if ( AKK_Helper.C.strG_SSO_PVS == "YES" )
            {
                // PVS_CON YES
                if (AKK_Helper.C.strG_SSO_WBD == "Y")
                    lblCON .BackColor = Color.LemonChiffon;
                else
                    lblCON.BackColor = Color.LightSkyBlue;

            }
                else
            {
                // PVS_CON NO
                if (AKK_Helper.C.strG_SSO_WBD == "Y")
                    lblCON.BackColor = Color.LightGreen;
                else
                    lblCON .BackColor = Color.LightGray;
            }


        if (PVS_CON != null )
            {
                if ( PVS_CON.PVS_APP.Connected == true )
                    lblCON.Text = "on";
                else
                   lblCON.Text = "off";
            }
            else
               lblCON.Text = "off";

            if (int_flag == 1)
                lblLOCK.BackColor = AKK_Helper.c_inaktiv;
            else
            {
                if (frm_wbd_antrag.is_locked == true)
                    lblLOCK.BackColor = AKK_Helper.c_lock;
                else
                    lblLOCK.BackColor = AKK_Helper.c_unlock;
            }
/*            lableDayDate.Text = System.DateTime.Today.ToString ("dddd") + ", " + 
                                System.DateTime.Today.Day + "-" + 
                                System.DateTime.Today.Month + "-" + 
                                System.DateTime.Today.Year;

  */

            lableDayDate.Text = string.Format("   {0}. {1}-{2}-{3}", System.DateTime.Today.ToString("ddd"),
                                System.DateTime.Today.Day, System.DateTime.Today.Month, System.DateTime.Today.Year);
            }
        public static void PressKeyboardButton(Keys keyCode)
       {
           const int KEYEVENTF_EXTENDEDKEY = 0x1;
           const int KEYEVENTF_KEYUP = 0x2;
           keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
           keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
       }
        public static void set_insert ( ToolStripStatusLabel lblINS)
        {
            AKK_Helper.PressKeyboardButton(Keys.Insert);
            AKK_Helper.UpdateInsert(lblINS);
        }
        public static void set_numlock(ToolStripStatusLabel lblNUM)
        {
            AKK_Helper.PressKeyboardButton(Keys.NumLock);
            AKK_Helper.UpdateNUMLock(lblNUM);
        }
        public static void set_capslock(ToolStripStatusLabel lblCAPS)
        {
            AKK_Helper.PressKeyboardButton(Keys.CapsLock);
            AKK_Helper.UpdateCAPSLock(lblCAPS);
        }
        public static void KeyUp(object sender, 
                                 KeyEventArgs e,
                                 ToolStripStatusLabel lblINS,
                                 ToolStripStatusLabel lblNUM,
                                 ToolStripStatusLabel lblCAPS,
                                 ToolStripStatusLabel lblCON)
        {
            if (e.KeyData == Keys.Insert)
            {
                AKK_Helper.UpdateInsert(lblINS);
            }
            else if (e.KeyData == Keys.NumLock)
            {
                AKK_Helper.UpdateNUMLock(lblNUM);
            }
            else if (e.KeyData == Keys.CapsLock)
            {
                AKK_Helper.UpdateCAPSLock(lblCAPS);
            }
        }


        public static Int32 get_ID(Int32 int_ikey)
        {
            string str_get_id = "";
            Int32 int_get_id = 0;
            if (AKK_Helper.checkLogin() == true)
            {
                try
                {
                    DataService.DataServiceClient client = new DataServiceClient();
                    Addit.AK.WBD.AK_Suche.DataService.Response  resp = client.Get_Id(out str_get_id, int_ikey.ToString(), AKK_Helper.SessionToken);

                    if (resp.ResponseCode == 0)
                        Int32.TryParse(str_get_id, out int_get_id);
                    else
                        AKK_Helper.handleServiceError(resp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(AKK_Helper.str_error["FC001"] + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString());
                    //TEST DS 16.10.2018
                    MessageBox.Show(AKK_Helper.str_error["FC001"] + ex.InnerException.ToString());
                }
            }
            return int_get_id;
        }


        public static Boolean check_PVS(clsA_PVS_connection PVS_CON, ToolStripStatusLabel lblCON)
        {


            //MessageBox.Show("Check PVS");
            //MessageBox.Show(string.Format("Version {0} Name {1} Nodename {2} DB {3}", PVS_CON.Version,PVS_CON.CreatorName,PVS_CON.Nodename, PVS_CON.Databasename));
            //MessageBox.Show(string.Format("PVS Track File {0}", PVSTraceFile));
           

            if ((PVS_CON.PVS_APP == null) || (PVS_CON.PVS_APP.Connected == false))
            {
                PVS_CON.PVS_APP.CreatorPCIVersion = PVS_CON.Version;
                PVS_CON.PVS_APP.CreatorName = PVS_CON.CreatorName;
                PVS_CON.PVS_APP.NodeName = PVS_CON.Nodename;
                PVS_CON.PVS_APP.DatabaseName = PVS_CON.Databasename;
                PVS_CON.PVS_APP.Visible = false;
                PVS_CON.PVS_APP.TrackingStarted = false;
                if (PVSTrace == "Y")
                {
                    PVS_CON.PVS_APP.TraceFile = PVSTraceFile;
                    PVS_CON.PVS_APP.TraceFileFlush = true;
                    PVS_CON.PVS_APP.TrackingStarted = true;
                }

                // New
                // if (AKK_Helper.C.strG_SSO_PVS != "NO")
                if (AKK_Helper.C.strG_SSO_PVS == "NO")
                {
                    // USER überprüfen --> db USer der CONEXDBA sein
                    // Admin/pvs_admin
                    // PVS_CON.PVS_APP.Connect(PVS_CON.User, PVS_CON.PW);


                    PVS_CON.PVS_APP.Connect(PVS_CON.User, PVS_CON.PW); //"conexdba", "ak"

                    //PVS_CON.PVS_APP.Connect("conexdba", "ak"); // scc1
                    PVS_CON.PVS_APP.Visible = false;
                }
                else
                {
                    PVS_CON.PVS_APP.Connect("","");
                    PVS_CON.PVS_APP.Visible = false;
                    
                    if (PVS_CON.PVS_APP.Connected == false)
                    {
                        PVS_CON.PVS_APP.Connect(PVS_CON.User, PVS_CON.PW);//"PVS_CON.User", "PVS_CON.PW"
                        if (PVS_CON.PVS_APP.Connected == false)
                        {

                            MessageBox.Show("Sie sind nicht berechtigt dieses Programm zu öffnen", "Zugriff verweigert!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    
                }

                 
            }
            if (AKK_Helper.C.strG_SSO_PVS == "NO")
            {
                lblCON.BackColor = Color.LightGray;
            }
            else
            {
                lblCON.BackColor = Color.LemonChiffon;
            }
            if (PVS_CON.PVS_APP.Connected == true)
            {
                lblCON.Text = "on";
            }
                else
            {
                lblCON.Text = "off";
            }
            //
           // MessageBox.Show(string.Format("PVS Connected : {0}", PVS_CON.PVS_APP.Connected == true ? "OK" : "Nicht OK"));
            //MessageBox.Show("TEST DAVID STEFITZ: " + PVS_CON.PVS_APP.DatabaseName + " " + PVS_CON.PVS_APP.CreatorName + " " + PVS_CON.PVS_APP.URL  + " " + PVS_CON.PVS_APP.CreatorPCIVersion + " " + PVS_CON.PVS_APP.NodeName);
           // PVS_CON.PVS_APP.ShowLastError();
            //
            return PVS_CON.PVS_APP.Connected;
        }


        public static ListViewItem get_PVS_Data_LVI(Miracle.MPP.WebPCI.DataObject PVS_do)
        { 
            //
            // "DO\\BZ\\$101000001810451"
            //

            Miracle.MPP.WebPCI.Field f1 = null;
            Miracle.MPP.WebPCI.Field f2 = null;
            Miracle.MPP.WebPCI.Field f3 = null;

            Miracle.MPP.WebPCI.Field f4 = null;
            Miracle.MPP.WebPCI.Field f5 = null;
            Miracle.MPP.WebPCI.Field f6 = null;

            Miracle.MPP.WebPCI.Field f7 = null;
            Miracle.MPP.WebPCI.Field f8 = null;
            Miracle.MPP.WebPCI.Field f9 = null;

            Miracle.MPP.WebPCI.Field f10 = null;
            Miracle.MPP.WebPCI.Field f11 = null;
            Miracle.MPP.WebPCI.Field f12 = null;
            Miracle.MPP.WebPCI.Field f13 = null;
            Miracle.MPP.WebPCI.Field f14 = null;
           
            ListViewItem LVI = new ListViewItem();
            string str_T = null;
            try
            {
                f13 =(Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(0);
                if (f13.Value != null) str_T = f13.Value.ToString();
                else str_T = "";

                if (str_T.Substring(3, 2) == "BV")
                {
                    // f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(65);     // Bank
                    // Miracle.MPP.WebPCI.DataObject DO_Bank = (Miracle.MPP.WebPCI.DataObject ) PVS_do.Fields.Items.GetValue(0;
                    //f1 = (Miracle.MPP.WebPCI.Field)PVS_do .Fields.Items.GetValue(0);     // Bank 0
                    //f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(66);     // Bankleitzahl 66
                    //f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(67);     // Kontonummer 67
                    //f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(68);     // Anmerkung 68

                    //f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(69);     //   BIC 69
                    //f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(68);     //   IBAN 68

                    f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Bank"];                  // Bank 0
                    f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["BLZ"];                   // Bankleitzahl 66
                    f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Kontonr"];               // Kontonummer 67
                    f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Anmerkung"];             // Anmerkung 68

                    f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["BIC"];                   // BIC 69
                    f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["IBAN"];                  // IBAN 68

                    if (f1.Value != null) LVI.SubItems.Add(f1.Value.ToString());        // 1
                    else LVI.SubItems.Add("");
                    if (f2.Value != null) LVI.SubItems.Add(f2.Value.ToString());        // 2
                    else LVI.SubItems.Add("");
                    if (f3.Value != null) LVI.SubItems.Add(f3.Value.ToString());        // 3
                    else LVI.SubItems.Add("");
                    if (f4.Value != null) LVI.SubItems.Add(f4.Value.ToString());        // 4
                    else LVI.SubItems.Add("");
                    if (f5.Value != null) LVI.SubItems.Add(f5.Value.ToString());        // 5
                    else LVI.SubItems.Add("");
                    if (f6.Value != null) LVI.SubItems.Add(f6.Value.ToString());        // 6
                    else LVI.SubItems.Add("");

                    LVI.SubItems.Add("");                                               // 7
                    LVI.SubItems.Add("");                                               // 8
                    LVI.SubItems.Add("");                                               // 9
                    LVI.SubItems.Add("");                                               // 10
                    LVI.SubItems.Add("");                                               // 11
                    LVI.SubItems.Add("");                                               // 12
                    if (f13.Value != null) LVI.SubItems.Add(f13.Value.ToString());      // 13
                    else LVI.SubItems.Add("");
                    LVI.SubItems.Add("");                                               // 14
                }

                else
                {

                    if (str_T.Substring( 3,2 ) == "BZ")
                    {
                        //f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(4);   // Bankname 4
                        //f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(7);   // Filiale 7
                        //f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(3);   // BLZ 3

                        f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Name"];               // Bankname 4
                        f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Filiale"];            // Filiale 7
                        f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["BLZ"];                // BLZ 3

                        if (f1.Value != null) LVI.SubItems.Add(f1.Value.ToString());        // 1
                        else LVI.SubItems.Add("");
                        if (f2.Value != null) LVI.SubItems.Add(f2.Value.ToString());        // 2
                        else LVI.SubItems.Add("");
                        if (f3.Value != null) LVI.SubItems.Add(f3.Value.ToString());        // 3
                        else LVI.SubItems.Add("");
               
                        LVI.SubItems.Add("");                                               // 4
                        LVI.SubItems.Add("");                                               // 5
                        LVI.SubItems.Add("");                                               // 6
                        LVI.SubItems.Add("");                                               // 7
                        LVI.SubItems.Add("");                                               // 8
                        LVI.SubItems.Add("");                                               // 9
                        LVI.SubItems.Add("");                                               // 10
                        LVI.SubItems.Add("");                                               // 11
                        LVI.SubItems.Add("");                                               // 12
                        if (f13.Value != null) LVI.SubItems.Add(f13.Value.ToString());      // 13
                        else LVI.SubItems.Add("");
                        LVI.SubItems.Add("");                                               // 14


                    }else if(str_T.Substring( 3,2 ) == "OR") {
                        PVS_do.Fields.ToString();
                        f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Betriebsname"];
                        f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Betriebsadresse"];
                        f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Branche"];
                        f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Rechtsform"];
                        f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Gewerkschaft"];
                        f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Ort"];
                        f7 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Strasse"];
                        

                        if (f1.Value != null) LVI.SubItems.Add(f1.Value.ToString());        // 1
                        else LVI.SubItems.Add("");
                        if (f2.Value != null) LVI.SubItems.Add(f2.Value.ToString());        // 2
                        else LVI.SubItems.Add("");
                        if (f3.Value != null) LVI.SubItems.Add(f3.Value.ToString());        // 3
                        else LVI.SubItems.Add("");
                        if (f4.Value != null) LVI.SubItems.Add(f4.Value.ToString());        // 4
                        else LVI.SubItems.Add("");
                        if (f5.Value != null) LVI.SubItems.Add(f5.Value.ToString());        // 5
                        else LVI.SubItems.Add("");
                        if (f6.Value != null) LVI.SubItems.Add(f6.Value.ToString());        // 6
                        else LVI.SubItems.Add("");
                        if (f7.Value != null) LVI.SubItems.Add(f7.Value.ToString());        // 7
                        else LVI.SubItems.Add("");

                        LVI.SubItems.Add("");                                               // 8
                        LVI.SubItems.Add("");                                               // 9
                        LVI.SubItems.Add("");                                               // 10
                        LVI.SubItems.Add("");                                               // 11
                        LVI.SubItems.Add("");                                               // 12
                        if (f13.Value != null) LVI.SubItems.Add(f13.Value.ToString());      // 13
                        else LVI.SubItems.Add("");
                        LVI.SubItems.Add("");                                               // 14
                        
                    }
                    else
                    {
                         //f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(35);     // Nachanem 35
                         //f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(36);     // Vorname 36
                         //f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(37);     // SVNR 37
                         //f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(39);     // Geschlecht  39
                         //f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(38);     // GebDat 38

                         //f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(20);     // PLZ 20
                         //f7 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(14);     // Ortsname 14
                         //f8 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(23);     // Strassenname 23
                         //f9 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(24);     // Hausnummer 24
                         //f10 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(25);    // Tuer 25

                         //f11 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(43);    // akad.Titel 43
                         //f12 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(7);     // NationID 7
                         //f13 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(0);     // PVS_ID 0
                         //f14 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields.Items.GetValue(34);    // PersonID 34 


                         f1 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Nachname"];        // Nachanem 35
                         f2 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Vorname"];         // Vorname 36
                         f3 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["SVNr"];            // SVNR 37
                         f4 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Geschlecht"];      // Geschlecht  39
                         f5 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["GebDat"];          // GebDat 38
                    
                         f6 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["PLZ"];             // PLZ 20
                         f7 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Ortsname"];        // Ortsname 14
                         f8 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Strassenname"];    // Strassenname 23
                         f9 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["HausNr"];          // Hausnummer 24
                         f10 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Tuer"];           // Tuer 25

                         f11 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["AkadTitelID"];    // akad.Titel 43
                         f12 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["NationID"];       // NationID 7
                         f13 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["Key"];            // PVS_ID 0
                         f14 = (Miracle.MPP.WebPCI.Field)PVS_do.Fields["PersonID"];       // PersonID 34

                        if (f1.Value != null) LVI.SubItems.Add(f1.Value.ToString());        // 1
                        else LVI.SubItems.Add("");
                        if (f2.Value != null) LVI.SubItems.Add(f2.Value.ToString());        // 2
                        else LVI.SubItems.Add("");
                        if (f3.Value != null) LVI.SubItems.Add(f3.Value.ToString());        // 3
                        else LVI.SubItems.Add("");
                        if (f4.Value != null) LVI.SubItems.Add(f4.Value.ToString());        // 4
                        else LVI.SubItems.Add("");
                        if (f5.Value != null) LVI.SubItems.Add(f5.Value.ToString());        // 5
                        else LVI.SubItems.Add("");
                        if (f6.Value != null) LVI.SubItems.Add(f6.Value.ToString());        // 6
                        else LVI.SubItems.Add("");
                        if (f7.Value != null) LVI.SubItems.Add(f7.Value.ToString());        // 7
                        else LVI.SubItems.Add("");
                        if (f8.Value != null) LVI.SubItems.Add(f8.Value.ToString());        // 8
                        else LVI.SubItems.Add("");
                        if (f9.Value != null) LVI.SubItems.Add(f9.Value.ToString());        // 9
                        else LVI.SubItems.Add("");
                        if (f10.Value != null) LVI.SubItems.Add(f10.Value.ToString());       // 10
                        else LVI.SubItems.Add("");
                        if (f11.Value != null) LVI.SubItems.Add(f11.Value.ToString());       // 11
                        else LVI.SubItems.Add("");
                        if (f12.Value != null) LVI.SubItems.Add(f12.Value.ToString());       // 12
                        else LVI.SubItems.Add("");
                        if (f13.Value != null) LVI.SubItems.Add(f13.Value.ToString());       // 13
                        else LVI.SubItems.Add("");
                        if (f14.Value != null) LVI.SubItems.Add(f14.Value.ToString());       // 14
                        else LVI.SubItems.Add("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox .Show("Fehler Get_Data_PVS_LVI " + ex.Message.ToString() + "\r\n\r\n" + ex.Data.ToString());
            }

            return LVI;

        }


        public static DC_bankverbindung_data read_BV(string BV_ikey)
        {
            DC_bankverbindung_data obj_BV = new DC_bankverbindung_data();
            if (AKK_Helper.checkLogin() == true)
            {
                DC_ak_suche obj_suche = new DC_ak_suche();
                obj_suche.DM_bv_ikey = BV_ikey;
                //
                DataService.DataServiceClient client = new DataServiceClient();
                Addit.AK.WBD.AK_Suche.DataService.Response resp = client.Get_Bankverbindung(out obj_BV, obj_suche, AKK_Helper.SessionToken);

                if (resp.ResponseCode != 0)
                {
                    AKK_Helper.handleServiceError(resp);
                }
            }
            return obj_BV;
        }

        public static double Calc_Diff  (string auszahlung_am, 
                                         string rueckab,
                                         double dbl_dl,
                                         double dbl_tilg,
                                         double dbl_konto)

                          
         {
                   double dbl_sum = 0.0;
                   if ( AKK_Helper.is_empty_date(auszahlung_am) == false )
                   {

                       if (dbl_konto > 0)   // Überzahlung
                       {
                           dbl_sum = dbl_konto - (dbl_dl * (-1) + dbl_tilg);
                       }
                       else
                       {
                           dbl_sum = (Math.Abs(dbl_dl * (-1) + dbl_tilg)) - Math.Abs(dbl_konto);
                       }
                   }
                   else
                   {
                       dbl_sum = dbl_konto - dbl_tilg;
                   }
                   if (dbl_tilg > dbl_dl)
                   {
                       dbl_sum = dbl_konto - ( dbl_dl * (-1) + dbl_tilg);
                   }
                   if (dbl_konto == 0)
                   {
                       dbl_sum = 0;
                   }
                   if ((AKK_Helper.is_empty_date(rueckab)) == true) 
                   {
                       dbl_sum = dbl_konto;
                   }
                   //
                   // txt_Dif.Text = AKK_Helper.FormatBetrag( dbl_sum.ToString());
                   return dbl_sum;

    }

        public static string Calc_AddMonths ( double DblKosten,
                                              double DblRate,
                                              Int32 IntLaufzeit,
                                              string str_rueckab )  
        {
           string rueckbisvertr = "";
           DateTime rueckab;
            
           //
           if ((DateTime .TryParse ( str_rueckab, out rueckab)) == true )
           {
               if ( DblKosten == 0 )
               {
                   rueckbisvertr = rueckab.AddMonths(IntLaufzeit - 1).ToString();
               }
               else
               {
                  if (( DblRate > DblKosten ) && ( DblKosten != 0 ) )
                  {
                      rueckbisvertr = rueckab.AddMonths(IntLaufzeit).ToString();
                  }
                  else
                  {
                      double dblRTmp = (DblKosten / DblRate);
                      Int32  intRTmp = ( Int32)  Math.Round(dblRTmp );
                      if ((DblKosten % DblRate ) > 0)
                      {
                         intRTmp = intRTmp + 1; 
                      }
                      intRTmp = intRTmp - 1;
                      rueckbisvertr = rueckab.AddMonths(IntLaufzeit + intRTmp).ToString();
                  }
                }
             }
           return rueckbisvertr;
         }    


        public static void fill_Monate (ComboBox cbo_box, string str_wie)
        {
            Int32 int_col_count = 12;
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Description", typeof(string));
            cbo_box.ValueMember = "Id";
            cbo_box.DisplayMember = "Description";
            if (str_wie == AKK_Helper.c_mit_leer)
            {
                table.Rows.Add(new object[] { 0, "" });
            }
            for (int i = 1; i <= int_col_count; i++)
            {
                DateTime dt_dat;
                string str_dat = "01." + i.ToString () + ".2010";
                string str_mm = "";
                DateTime .TryParse (str_dat, out dt_dat);

                str_mm = string.Format("{0:MMM}", dt_dat);
                table.Rows.Add(new object[] { i , str_mm });
            }

            cbo_box.DataSource = table;
        }


        public static void fill_Tage(ComboBox cbo_box, Int32 int_mon, string str_wie)
        {
            Int32 int_col_count = 31;
            if ((int_mon == 4) ||
            (int_mon == 6) ||
            (int_mon == 9) ||
            (int_mon == 11))
            {
                int_col_count = 30;
            }
            else
            {
                if (int_mon == 2) 
                {
                    int_col_count = 29;
                }   
            }

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Description", typeof(string));
            cbo_box.ValueMember = "Id";
            cbo_box.DisplayMember = "Description";
            if (str_wie == AKK_Helper.c_mit_leer)
            {
                table.Rows.Add(new object[] { 0, "" });
            }
            for (int i = 1; i <= int_col_count; i++)
            {
                table.Rows.Add(new object[] { i, i});
            }

            cbo_box.DataSource = table;
        }


        public static void fill_Jahre(ComboBox cbo_box, string str_wie)
        {
            // 02-10-2015 by KJ chanegd from 30 to 40;
            //Int32 int_col_count = 30;
            Int32 int_col_count = 40;
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Description", typeof(string));
            cbo_box.ValueMember = "Id";
            cbo_box.DisplayMember = "Description";

            Int32 int_jahr = System.DateTime.Now.Year;
            // 02-10-2015 by KJ chanegd from -15 to -30 ( 30 years befor, 10 years in future )
            //int_jahr = int_jahr - 15;
            int_jahr = int_jahr - 30;
            if (str_wie == AKK_Helper.c_mit_leer)
            {
                table.Rows.Add(new object[] { 0, "" });
            }
            for (int i = 1; i <= int_col_count; i++)
            {
                table.Rows.Add(new object[] { i, int_jahr.ToString () });
                int_jahr = int_jahr + 1;
            }

            cbo_box.DataSource = table;
        }


        public static void fill_Minutes(ComboBox cbo_box, string StepBetween)
        {
            Int32 int_minutes = 59;

            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Description", typeof(string));
            cbo_box.ValueMember = "Id";
            cbo_box.DisplayMember = "Description";
            for (int i = 0; i <= int_minutes; i++)
            {
                table.Rows.Add(new object[] { i, i });
            }

            cbo_box.DataSource = table;
            cbo_box.SelectedValue = StepBetween;
        }


        public static void set_lst_entry(object sender, KeyEventArgs e, ComboBox cbo_box )
        {
            string cod = e.KeyCode.ToString();
            string DAT = e.KeyData.ToString();
            string VAL = e.KeyValue.ToString();
            Int32 int_col_count = cbo_box.Items.Count;

            Int32 my_key;
            Int32 my_key1;
            Int32.TryParse(e.KeyValue.ToString(), out my_key);

            Int32 my_index;
            Int32.TryParse(cbo_box.SelectedIndex.ToString(), out my_index);

            string str_KeyData = e.KeyData.ToString();

            string str_Box;
            string str_key;
            my_key1 = my_key;

            if (my_key >= 48 && my_key <= 57)
                str_KeyData = e.KeyData.ToString().Substring(1, 1);
            if (((my_key >= 65) && (my_key <= 90))  ||( my_key >= 48 && my_key <= 57 ))      // a - z 
                my_key = -9;
            

            switch (my_key)
            {
                //case 38:    // UP
                //    if (my_index > 1)
                //        cbo_verwendungszweck.SelectedIndex = my_index - 1;
                //    break;
                //case 40:    // Down
                //    if (my_index < int_col_count)
                //        cbo_verwendungszweck.SelectedIndex = my_index + 1;
                //    break;
                case 36:    // POS 1
                    cbo_box.SelectedValue = 1;
                    break;
                case 35:    // Ende
                    cbo_box.SelectedValue = int_col_count;
                    break;
                //case 33:    // Page UP
                //      if (my_index - 5 > 1)
                //          cbo_verwendungszweck.SelectedIndex = 1;
                //      else
                //          cbo_verwendungszweck.SelectedIndex = my_index - 5;
                //      break;
                //case 34:    // Page DOWN
                //      if (my_index + 5 > int_col_count)
                //          cbo_verwendungszweck.SelectedIndex = int_col_count;
                //      else
                //          cbo_verwendungszweck.SelectedIndex = my_index - 5;
                //      break;
                case -9:
                    //
                    // same key
                    //
                    if (int_key == my_key1)
                    {
                        int_key = my_key1;
                        Boolean is_found = false;
                        
                        if (int_index < int_col_count)
                        {
                            for (int i = int_index + 1; i < int_col_count; i++)
                            {
                                cbo_box.SelectedIndex = i;
                                if (cbo_box.Text.ToString() != "")
                                {
                                    str_Box = cbo_box.Text.ToString().Substring(0, 1).ToUpper();
                                    str_key = str_KeyData.ToUpper().Substring(0, 1);

                                    if (str_Box == str_key)
                                    {
                                        cbo_box.SelectedIndex  = i;
                                        i = int_col_count + 1 ;
                                        is_found = true;
                                        Int32.TryParse(cbo_box.SelectedIndex.ToString(), out int_index);
                                    }
                                }
                            }
                        }
                        //
                        // false, if no other record found ( was the last one - start at beginning )
                        //
                        if (is_found == false)
                        {
                            for (int i = 0; i < int_col_count; i++)
                            {
                                cbo_box.SelectedIndex = i;
                                if (cbo_box.Text.ToString() != "")
                                {
                                    str_Box = cbo_box.Text.ToString().Substring(0, 1).ToUpper();
                                    str_key = str_KeyData.ToUpper().Substring(0, 1);

                                    if (str_Box == str_key)
                                    {
                                        cbo_box.SelectedIndex = i;
                                        i = int_col_count + 1;
                                        Int32.TryParse(cbo_box.SelectedIndex.ToString(), out int_index);
                                        is_found = true;
                                    }
                                }
                            }

                        }
                    }
                    else
                    //
                    // new key - find first entry
                    //
                    {
                        int_key = my_key1;
                        for (int i = 0; i < int_col_count; i++)
                        {
                            isG_first = true;
                            cbo_box.SelectedIndex = i;
                            isG_first = false;
                            if (cbo_box.Text.ToString() != "")
                            {
                                str_Box = cbo_box.Text.ToString().Substring(0, 1).ToUpper();
                                str_key = str_KeyData.ToUpper().Substring(0, 1);

                                if (str_Box == str_key)
                                {
                                    isG_first = false;
                                    cbo_box.SelectedIndex = i;
                                    i = int_col_count + 1;
                                    Int32.TryParse(cbo_box.SelectedIndex.ToString(), out int_index);
                                }
                            }
                        }
                       
                    }
                 break;
            }
        }

        public static void set_actual_index (String str_actual_index, string str_actual_text )
        {
            Int32 int_i;
            Int32.TryParse(str_actual_index, out int_i);
            char chr_key = ' ';
            if ((str_actual_text != null) && (str_actual_text != "" ))
           {
                chr_key = str_actual_text[0];
                int_key = Convert.ToInt32(((int)chr_key).ToString());
           }
           int_index = int_i;
        }

        public static string set_date(string xDate)
        {
            if (xDate.Length >= 10)
                return (xDate.Substring(0, 10));
            else
                return (xDate);
        }

        public static void show_msg(string str_msg, ToolStripStatusLabel TSSL, Cursor C)
        {
            TSSL.Text = str_msg;            // Show Message in ToolStripStatusLevel
            C = Cursors .Default ;          // set normal Cursor
            MessageBox.Show (str_msg, "WBD Application");      // Show Message
        }

        public static void set_cmd_fontsize(Button btn)
        {
            btn.Font = new Font(btn.Font.FontFamily, AKK_Helper.FontSizeCmd);
        }

        public static void FindControls(Control ctrl)
        {
            foreach (Control ctl in ctrl.Controls)
            {
                String str_typ = ctl.GetType().FullName;
                switch (str_typ)
                {
                    case "System.Windows.Forms.Label":
                        Label lbl = (Label)ctl;
                        lbl.Font = new Font(lbl.Font.FontFamily, AKK_Helper.FontSize);
                        lbl.Height = (Int16)AKK_Helper.FontSize * 2;
                        lbl.AutoSize = false;
                        break;
                    case "System.Windows.Forms.TextBox":
                        TextBox txt = (TextBox)ctl;
                        txt.Font = new Font(txt.Font.FontFamily, AKK_Helper.FontSize);
                        txt.Height = (Int16) AKK_Helper.FontSize * 2;
                        break;
                    case "System.Windows.Forms.Button":
                        Button cmd = (Button)ctl;
                        cmd.Font = new Font(cmd.Font.FontFamily, AKK_Helper.FontSizeCmd);
                        break;
                    case "System.Windows.Forms.CheckBox":
                        CheckBox chk = (CheckBox)ctl;
                        chk.Font = new Font(chk.Font.FontFamily, AKK_Helper.FontSize);
                        break;
                    case "System.Windows.Forms.RadioButton":
                        RadioButton opt = (RadioButton)ctl;
                        opt.Font = new Font(opt.Font.FontFamily, AKK_Helper.FontSize);
                        break;
                    case "System.Windows.Forms.DataGrid":
                        DataGrid grd = (DataGrid)ctl;
                        grd.Font = new Font(grd.Font.FontFamily, AKK_Helper.FontSize);
                        break;
                    case "System.Windows.Forms.GroupBox":
                        GroupBox frm = (GroupBox)ctl;
                        frm.Font = new Font(frm.Font.FontFamily, AKK_Helper.FontSizeFrm);
                        //
                        FindControls(frm);
                        //                        
                        break;
                    case "System.Windows.Forms.Panel":
                        Panel  pan = (Panel )ctl;
                        // pan.Font = new Font(pan.Font.FontFamily, AKK_Helper.FontSizeFrm);
                        //
                        FindControls(pan);
                        //                        
                        break;
                        

                    default:
                        ctl.Font = new Font(ctl.Font.FontFamily, AKK_Helper.FontSize);
                        break;
                }
                // ctl.ForeColor = AKK_Helper.c_lost_focus;
                //foreach (Control ctl_sub in ctl.Controls)
                //{
                //    FindControls(ctl_sub);
                //}

            }
           
        }

        public static void Init_lst_info(ListView  lst_info)
    {
            lst_info.View = View.Details;
            lst_info.Font = new Font(lst_info.Font.FontFamily, AKK_Helper.FontSize);
            lst_info.GridLines = true;
            lst_info.LabelEdit = true;
            lst_info.AllowColumnReorder = true;
            lst_info.CheckBoxes = false;
            lst_info.FullRowSelect = true;
            lst_info.Items.Clear();
    }
        // AKK_Helper.set_wbd(lst_info,"LOG1", txt_offset.Text, strip_info, this.Cursor);
        public static void set_wbd(ListView lst_info, string str_SQL, string str_Para, ToolStripStatusLabel TSSL, Cursor C)
        {
            lst_info.Clear();          // log_ikey, log_ts, log_prg, log_sqlerrm, log_statement 
            lst_info.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
            lst_info.Columns.Add("Key", 50, HorizontalAlignment.Left);                    // 01
            lst_info.Columns.Add("Timestamp", 150, HorizontalAlignment.Left);             // 02
            lst_info.Columns.Add("Programm", 150, HorizontalAlignment.Left);              // 03
            lst_info.Columns.Add("Fehlerbeschreibung", 300, HorizontalAlignment.Left);    // 04
            lst_info.Columns.Add("Statement", 900, HorizontalAlignment.Left);             // 05

            //TSSL.Text = str_msg;            // Show Messa in ToolStripStatusLevel
            //C = Cursors.Default;          // set normal Cursor
            //MessageBox.Show(str_msg);

            fill_ListInfo(lst_info, str_SQL, str_Para, TSSL, C);

        }
        public static void set_not_wbd(ListView lst_info, string str_SQL, string str_Para, ToolStripStatusLabel TSSL, Cursor C)   
        {
            lst_info.Clear();     //select err_user, err_datum, err_dl, err_text from WBD_ERROR
            lst_info.Columns.Add("Index", -1, HorizontalAlignment.Left);                  // 00
            lst_info.Columns.Add("User", 50, HorizontalAlignment.Left);                   // 01
            lst_info.Columns.Add("Timestamp", 150, HorizontalAlignment.Left);             // 02
            lst_info.Columns.Add("DarlehnsNr.", 100, HorizontalAlignment.Left);           // 03
            lst_info.Columns.Add("Fehlerbeschreibung", 600, HorizontalAlignment.Left);    // 04

            fill_ListInfo(lst_info, str_SQL, str_Para, TSSL, C);
        }


        private static void fill_ListInfo(ListView lst_info, string str_SQL, string str_Para, ToolStripStatusLabel TSSL, Cursor C)
        {
            Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
            DC_Columns cols = new DC_Columns();
            DataService.DataServiceClient client = new DataServiceClient();
            lst_info.Items.Clear();

            C = Cursors.WaitCursor;
            TSSL.Text = "";
            resp = null;
            resp = client.get_SQL_Data(out cols, AKK_Helper.SessionToken, str_SQL, str_Para);
            if (resp.ResponseCode == 0)
            {
                Int32 int_ant_count = cols.Count;
                for (Int32 i = 0; i < int_ant_count; i++)
                {
                    ListViewItem LVI_ORA = new ListViewItem(i.ToString());

                    LVI_ORA.SubItems.Add(cols[i].DM_col_01.ToString());                      // 1
                    LVI_ORA.SubItems.Add(cols[i].DM_col_02.ToString());                      // 2
                    LVI_ORA.SubItems.Add(cols[i].DM_col_03.ToString());                      // 3
                    LVI_ORA.SubItems.Add(cols[i].DM_col_04.ToString());                      // 4
                    LVI_ORA.SubItems.Add(cols[i].DM_col_05.ToString());                      // 5

                    lst_info.Items.Add(LVI_ORA);
                    LVI_ORA = null;
                }
                TSSL.Text = int_ant_count.ToString() + " Datensätze gelesen";
            }
            else
            {
                C = Cursors.Default;
                AKK_Helper.handleServiceError(resp);
                TSSL.Text = "Fehler beim Lesen der Daten";
            }
            C = Cursors.Default;
        }

        public static Boolean Print_LST_Box(ListView lst_info_aw, Int32 a1, Int32 a2, Int32 a3, Int32 a4, Int32 a5)
        {


            //1 .. 99 normal size
            //0       full size
            //-1      skip column
            //
            List<string> lst_lines = new List<string>();
            Int32 int_count = lst_info_aw.Items.Count;

            string str_a1;
            string str_a2;
            string str_a3;
            string str_a4;
            string str_a5;

            for (Int32 i = 0; i < int_count; i++)
            {
                str_a1 = string.Empty;
                str_a2 = string.Empty;
                str_a3 = string.Empty;
                str_a4 = string.Empty;
                str_a5 = string.Empty;
                //
                ListViewItem LVI_ORA = lst_info_aw.Items[i];
                if ( LVI_ORA.SubItems[1].Text.ToString() != null )
                   str_a1 = check_lenght(LVI_ORA.SubItems[1].Text.ToString(), a1);
                if (LVI_ORA.SubItems[2].Text.ToString() != null)
                   str_a2 = check_lenght(LVI_ORA.SubItems[2].Text.ToString(), a2);
                if (LVI_ORA.SubItems[3].Text.ToString() != null)
                   str_a3 = check_lenght(LVI_ORA.SubItems[3].Text.ToString(), a3);
                if (LVI_ORA.SubItems[4].Text.ToString() != null)
                   str_a4 = check_lenght(LVI_ORA.SubItems[4].Text.ToString(), a4);
                if (LVI_ORA.SubItems[5].Text.ToString() != null)
                   str_a5 = check_lenght(LVI_ORA.SubItems[5].Text.ToString(), a5);

                string str_str = str_a1 + str_a2 + str_a3 + str_a4 + str_a5; //  +@"  \par";  --> lt Bruno nicht notwendig!!!
                lst_lines.Add(str_str);
            }

            Addit.AK.WBD.AK_Suche.DataService.Response resp = new Addit.AK.WBD.AK_Suche.DataService.Response();
            DC_Columns cols = new DC_Columns();
            DataService.DataServiceClient client = new DataServiceClient();
            
            resp = client.Print_List_Box( AKK_Helper.SessionToken, AKK_Helper.my_printer, lst_lines.ToArray <string>());
            if (resp.ResponseCode != 0)
            {
                AKK_Helper.handleServiceError(resp);
                return false;
            }

            return true;
         }

         private static string check_lenght(string str_a1, Int32 a)
         {
            string str_return = null;

            switch (a)
            {
                case 0:
                    str_return = str_a1.Trim();
                    break;
                case -1:
                    str_return = string.Empty;
                    break;
                default:
                    str_return = str_a1.PadRight(a, ' ');
                    break;
            }
            return str_return;
        }




    } // Class
}     // Namespace

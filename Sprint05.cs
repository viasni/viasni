using OTIS_One_Framework.Net.IBC_Automation.PageObjects;
using OTIS_One_Framework.Net.IBC_Automation.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace OTIS_One_Framework.Net.IBC_Automation.TestScripts
{

    public class IBC_App_Sprint05 : TestBase
    {
        // ap - Authorized Personnel
        // ca - Customer Admin
        public string AP_Email_Id { get; set; }
        public string CA_Email_Id { get; set; }
        public string AP_Password { get; set; }
        public string CA_Password { get; set; }
        public string AP_URL { get; set; }
        public string AP_SecurityAnswer { get; set; }
        public string CA_SecurityAnswer { get; set; }
        public string AP_Name { get; set; }
        public string CA_Url { get; set; }
        public string Simulator_Link { get; set; }
        public string CA_Name { get; set; }
        public string AP_RegistrationLink { get; set; }
        public string Otis_Email_Id { get; set; }
        public string Otis_Password { get; set; }
        public string Otis_URL { get; set; }
        public string Active_UnitId { get; set; }
        public string Active_BuildingID { get; set; }

        static string active_UnitId;
        static string apUrl;
        static string apEmailId;
        static string caEmailId;
        static string apPassword;
        static string caSecurityAnswer;
        static string apSecurityAnswer;
        static string apRegistrationLink;
        static string apName;
        static string caName;
        static string caPassword;
        static string caUrl;
        static string simulatorLink;
        static string otisUrl;
        static string otisEmailId;
        static string otisPassword;
        static string OtisNotRegisteredEmailId;
        static string active_BuildingID;

        public void setTestData()
        {

            try
            {
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                string path = path1 + Pages._mainPageLocators(driver).path;
                var jsonFile = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint05>>(jsonFile);
                var jsonText = json.First();
                apUrl = jsonText.AP_URL;
                apEmailId = jsonText.AP_Email_Id;
                apPassword = jsonText.AP_Password;
                apSecurityAnswer = jsonText.AP_SecurityAnswer;
                caSecurityAnswer = jsonText.CA_SecurityAnswer;
                apName = jsonText.AP_Name;
                caEmailId = jsonText.CA_Email_Id;
                caPassword = jsonText.CA_Password;
                apRegistrationLink = jsonText.AP_RegistrationLink;
                caName = jsonText.CA_Name;
                caUrl = jsonText.CA_Url;
                simulatorLink = jsonText.Simulator_Link;
                caUrl = jsonText.CA_Url;
                otisUrl = jsonText.Otis_URL;
                otisEmailId = jsonText.Otis_Email_Id;
                otisPassword = jsonText.Otis_Password;
                active_UnitId = jsonText.Active_UnitId;
                active_BuildingID = jsonText.Active_BuildingID;
                Pages._customerLoginPageLocators(driver).readJsonEnglishData();
                Pages._apManageAccountPageLocators(driver).readJsonEnglishData();
                Pages._apOnGoingCallLocators(driver).readJsonEnglishData();
                Pages._APResetPasswordLocators(driver).readJsonEnglishData();
                Pages._customeradminManageAccountPageLocators(driver).readJsonEnglishData();
                Pages._caManageFccdevicePageLocators(driver).readJsonEnglishData();
                Pages._customerAdminPagelocators(driver).readJsonEnglishData();
                Pages._customerLoginPageLocators(driver).readJsonEnglishData();
                Pages._mainPageLocators(driver).readJsonEnglishData();
                Pages._otisAdminFccdevicePageLocators(driver).readJsonEnglishData();
                Pages._otisAdminPageLocators(driver).readJsonEnglishData();
                Pages._apLoginPageLocators(driver).readJsonEnglishData();
                Pages._customerAdminCallLogsLocators(driver).readJsonEnglishData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        [Test]
        public void IBC_001_127420_Manage_Account_option_for_Customer_Admin_verify_the_display_of_manage_account_option_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickonManageAccount();
            Pages._customeradminManageAccountPage(driver).verify_the_display_of_manage_account_option_page();
            Pages._customerAdminPage(driver).ChangeLanguageToFrench();
            Pages._customeradminManageAccountPageLocators(driver).readJsonFrenchData();
            Pages._customeradminManageAccountPage(driver).verify_the_display_of_manage_account_option_page();
        }
        [Test]
        public void IBC_002_127421_Manage_Account_option_for_Customer_Admin_verify_the_display_of_Reset_password_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickonManageAccount();
            Pages._customeradminManageAccountPage(driver).clickOnResetPasswordIcon();
            Pages._caResetPasswordPage(driver).verify_the_display_of_UI_in_forgot_password_page();
        }
        [Test]
        public void IBC_003_127427_Manage_Account_option_for_Customer_Admin_verify_the_functionality_of_cancel_button_on_rest_password_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickonManageAccount();
            Pages._customeradminManageAccountPage(driver).clickOnResetPasswordIcon();
            Pages._caResetPasswordPage(driver).clickOnCancelButton();
            Pages._customerAdminPage(driver).verifyTheDisplayOfCustomerAdminPage();
        }      
        [Test]
        public void IBC_006_127431_Add_Spanish_language_option_verify_the_display_of_language_option_AP_login_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).verify_Language_Option();
           }
        [Test]
        public void IBC_010_127433_Add_Spanish_language_option_verify_the_functionality_of_language_option_AP_login_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);           
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();
        }
        [Test]
        public void IBC_007_130492_Add_Spanish_language_option_verify_the_display_of_language_option_in_reset_password_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).clickOnPasswordEditIcon();
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            Pages._APResetPasswordLocators(driver).readJsonSpnishData();
            Pages._authorizedPersonnelPage(driver).verify_the_display_of_Reset_password_page();
        }
        [Test]
        public void IBC_008_128972_Add_Spanish_language_option_verify_the_display_and_functionality_of_language_option_in_ongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            if (active_UnitId == "")
                Console.WriteLine("Active unit is in offline");
            else
            {
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_IBC(active_UnitId);
            }
        }
        [Test]
        public void IBC_009_130494_Add_Spanish_language_option_verify_error_values_for_login_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).verify_login_error_messaage_for_empty_values();
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword.ToLower());
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).verify_incorrect_popup_Error_Values();

        }
        [Test]
        public void IBC_011_130398_Display_Message_when_Passenger_is_unexpectedly_disconnected_verify_the_display_of_alert_message_when_unexpectedly_call_disconnected()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            string unitId = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).unitOne);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).swithToEelevator();
            Pages._action(driver).refreshPage(driver);
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).verify_unexpectedly_disconnected_window(unitId);
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();

        }
        [Test]
        public void IBC_012_130409_Display_Message_when_Passenger_is_unexpectedly_disconnected_verify_call_is_connected_when_unexpectedly_call_disconnected()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            string unitId = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).unitOne);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).swithToEelevator();
            Pages._action(driver).refreshPage(driver);
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).verify_unexpectedly_disconnected_window(unitId);
            Pages._apOnGoingCall(driver).ClickOnCloseButton();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._apOnGoingCallLocators(driver).readJsonEnglishData();
            if (active_UnitId == "")
                Console.WriteLine("Active unit is in offline");
            else
            {
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_IBC(active_UnitId);
                Pages._apOnGoingCall(driver).verify_display_of_IBC_initiate_call_screen(active_UnitId, active_BuildingID);
                Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            }
        }
        [Test]
        public void IBC_013_128274_Online_and_offline_status_of_AP_verify_the_display_of_offline_or_online_real_time_status_of_APs()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).verify_the_display_of_offline_real_time_status_of_APs();

        }
        [Test]
        public void IBC_014_128704_Manage_Account_option_for_Customer_Admin_verify_the_display_and_functionality_of_language_option_AP_home_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
        }
        [Test]
        public void IBC_015_128970_Manage_Account_option_for_Customer_Admin_verify_the_display_and_functionality_of_language_option_in_AP_Manage_account_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelLoginPage(driver).ChangeLangugeToSpanish();
            Pages._apManageAccountPage(driver).verify_the_display_of_manage_account_option_page(apName,apEmailId);
        }
        [Test]
        public void IBC_004_127006_Call_Logs_UI_for_CA_verify_the_display_the_call_log_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_display_the_call_log_page();
            Pages._customerAdminCallLogsLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_display_the_call_log_page();
        }
        [Test]
        public void IBC_005_144517_Manage_Account_option_for_Customer_admin_verify_the_functionality_of_Reset_password_edit_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickonManageAccount();
            Pages._customeradminManageAccountPage(driver).clickOnResetPasswordIcon();
            Pages._caResetPasswordPage(driver).verify_the_display_of_UI_in_forgot_password_page();
        }
        [Test]
        public void IBC_016_144515_Add_Spanish_language_option_verify_the_display_and_functionality_of_language_option_AP_Manage_account_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(caUrl);
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).verify_display_of_security_questions_page();
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._apPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPageLocators(driver).readJsonSpanishData();
            Pages._apManageAccountPage(driver).verify_the_display_of_manage_account_option_page(apName, apEmailId);
        }
        [Test]
        public void IBC_017_161811_Call_Logs_UI_for_CA_verify_the_functionality_of_sorting_of_unit_ID_in_call_log_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_sorting_of_unit_ID();            
        }
        [Test]
        public void IBC_018_161812_Call_Logs_UI_for_CA_verify_the_functionality_of_sorting_of_APEPName_in_call_log_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_sorting_of_APEPName();
        }
        [Test]
        public void IBC_019_161814_Call_Logs_UI_for_CA_verify_the_functionality_of_sorting_of_call_duration_in_call_log_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_sorting_of_callTime();
        }
        [Test]
        public void IBC_020_163423_Call_Logs_UI_for_CA_verify_the_functionality_of_searchbox()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_Unit_id_searchbox();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).Select_buildingName_in_dropdown();
           Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_bildingName_searchbox();
        }
        [Test]
        public void IBC_021_163428_Call_Logs_UI_for_OA_verify_the_display_the_call_log_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._otisAdminCallLogsPage(driver).verify_display_of_call_log_page();
            Pages._customerAdminCallLogsLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._otisAdminCallLogsPage(driver).verify_display_of_call_log_page();
        }
        [Test]

        public void IBC_022_163429_Call_Logs_UI_for_OA_verify_the_functionality_of_searchbox()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_Unit_id_searchbox();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).Select_buildingName_in_dropdown();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_bildingName_searchbox();
        }
        [Test]
        public void IBC_023_163430_Call_Logs_UI_for_OA_verify_the_display_of_searchbox_No_data_found()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).enterSearchInput(otisEmailId);
            Pages._customerAdminCallLogsPage(driver).clickOnSearch();
            Pages._customerAdminCallLogsPage(driver).verify_the_display_of_searchbox_No_data_found();
            Pages._customerAdminCallLogsLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).Select_buildingName_in_dropdown();
            Pages._customerAdminCallLogsPage(driver).enterSearchInput(otisEmailId);
            Pages._customerAdminCallLogsPage(driver).clickOnSearch();
            Pages._customerAdminCallLogsPage(driver).verify_the_display_of_searchbox_No_data_found();
        }
        [Test]
        public void IBC_024_163431_Call_Logs_UI_for_OA_verify_functionality_of_sorting()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_sorting_of_callTime();
            Pages._customerAdminCallLogsLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_sorting_of_APEPName();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_the_functionality_of_sorting_of_unit_ID();           
        }
        [Test]
        public void IBC_025_163432_Call_Logs_UI_for_CA_verify_the_display_of_searchbox_No_data_found()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).enterSearchInput(otisEmailId);
            Pages._customerAdminCallLogsPage(driver).clickOnSearch();
            Pages._customerAdminCallLogsPage(driver).verify_the_display_of_searchbox_No_data_found();
            Pages._customerAdminCallLogsLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).Select_buildingName_in_dropdown();
            Pages._customerAdminCallLogsPage(driver).enterSearchInput(otisEmailId);
            Pages._customerAdminCallLogsPage(driver).clickOnSearch();
            Pages._customerAdminCallLogsPage(driver).verify_the_display_of_searchbox_No_data_found();
        }
    }
}
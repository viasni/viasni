using NUnit.Framework;
using OTIS_One_AutomationFramework.AutomationBase.Utilities;
using OTIS_One_Framework.Net.IBC_Automation.PageObjects;
using OTIS_One_Framework.Net.IBC_Automation.Hooks;
using OTIS1AutomationFramework.AutomationBase.API;
using OTIS1AutomationFramework.AutomationBase.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace OTIS_One_Framework.Net.IBC_Automation.TestScripts
{

    public class IBC_App_Sprint02 : TestBase
    {
        public string Otis_Email_Id { get; set; }
        public string Active_UnitId { get; set; }
        public string AP_Contact_Number { get; set; }
        public string Otis_Password { get; set; }
        public string Otis_URL { get; set; }
        public string Otis_NotRegisteredEmailId { get; set; }
        public string AP_RegistrationLink { get; set; }
        public string AP_AlreadyRegisteredLink { get; set; }
        public string Simulator_Link { get; set; }
        string path;
        public string AP_Email_Id { get; set; }
        public string CA_Email_Id { get; set; }
        public string AP_Password { get; set; }
        public string CA_Password { get; set; }
        public string AP_URL { get; set; }
        public string AP_SecurityAnswer { get; set; }
        public string CA_SecurityAnswer { get; set; }
        public string AP_Name { get; set; }
        public string CA_Name { get; set; }
        public string CA_Url { get; set; }
        public string Active_BuildingID { get; set; }
        static string apUrl;
        static string apEmailId;
        static string caEmailId;
        static string apPassword;
        static string apRegistrationLink;
        static string caSecurityAnswer;
        static string apSecurityAnswer;
        static string apName;
        static string caName;
        static string caPassword;
        static string otisNotRegisteredEmailId;
        static string caUrl;
        static string simulatorLink;
        static string apAlreadyRegisteredLink;
        static string apContactNumber;
        static string active_UnitId;
        static string active_BuildingID;
        public void setTestData()
        {

            try
            {
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                path = path1 + "IBC_Automation\\TestData\\TestData.json";
                var jsonFile = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint02>>(jsonFile);
                var jsonText = json.First();
                apUrl = jsonText.AP_URL;
                apEmailId = jsonText.AP_Email_Id;
                apPassword = jsonText.AP_Password;
                apSecurityAnswer = jsonText.AP_SecurityAnswer;
                caSecurityAnswer = jsonText.CA_SecurityAnswer;
                apName = jsonText.AP_Name;
                caEmailId = jsonText.CA_Email_Id;
                caPassword = jsonText.CA_Password;
                caName = jsonText.CA_Name;
                otisNotRegisteredEmailId = jsonText.Otis_NotRegisteredEmailId;
                apRegistrationLink = jsonText.AP_RegistrationLink;
                caUrl = jsonText.CA_Url;
                apAlreadyRegisteredLink = jsonText.AP_AlreadyRegisteredLink;
                simulatorLink = jsonText.Simulator_Link;
                apContactNumber = jsonText.AP_Contact_Number;
                active_BuildingID = jsonText.Active_BuildingID;
                active_UnitId = jsonText.Active_UnitId;
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
                Pages._apPageLocators(driver).readJsonEnglishData();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        [Test]
        public void IBC_001_111777_Remember_me_and_Reset_Password_options_at_Login_verify_the_functionality_of_Remember_me_option_after_logout()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnRememberMe();
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._authorizedPersonnelLoginPage(driver).logout();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._authorizedPersonnelLoginPage(driver).verify_the_functionality_of_Remember_me_option(apEmailId);
        }
        [Test]
        public void IBC_002_116288_Remember_me_and_Reset_Password_options_at_Login_verify_the_functionality_of_Remember_me_option_after_logout()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).verify_isCheckBoxIsNotChecked();
            Pages._authorizedPersonnelLoginPage(driver).clickOnRememberMe();
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._authorizedPersonnelLoginPage(driver).logout();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._authorizedPersonnelLoginPage(driver).verify_the_functionality_of_Remember_me_option(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).verify_isCheckBoxChecked();
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnRememberMe();
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).logout();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._authorizedPersonnelLoginPage(driver).verify_the_functionality_of_Remember_me_option();
            Pages._authorizedPersonnelLoginPage(driver).verify_isCheckBoxIsNotChecked();
        }
        [Test]
        public void IBC_003_116314_Remember_me_and_Reset_Password_options_at_Login_verify_the_display_of_Remember_me_option()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).verify_the_display_of_Remember_me_option();
            Pages._authorizedPersonnelLoginPage(driver).verify_isCheckBoxIsNotChecked();
            Pages._authorizedPersonnelLoginPage(driver).clickOnRememberMe();
            Pages._authorizedPersonnelLoginPage(driver).verify_isCheckBoxChecked();
            Pages._authorizedPersonnelLoginPage(driver).clickOnRememberMe();
            Pages._authorizedPersonnelLoginPage(driver).verify_isCheckBoxIsNotChecked();
        }
        [Test]
        public void IBC_004_111778_Remember_me_and_Reset_Password_options_at_Login_verify_the_display_of_forgot_password_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._APResetPasswordPage(driver).verify_the_display_of_forgot_password_option();
            Pages._APResetPasswordPage(driver).EnterEmailId(apEmailId);
            Pages._APResetPasswordPage(driver).clickOnVerificationButton();
            Pages._APResetPasswordPage(driver).verify_the_display_of_verification_code_button(apEmailId);

        }
        [Test]
        public void IBC_005_111781_Remember_me_and_Reset_Password_options_at_Login_verify_the_functionality_of_forgot_password_option_error_values()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._APResetPasswordPage(driver).verify_forgot_password_option_error_values();
            Pages._APResetPasswordPage(driver).clickOnVerificationButton();
        }
        [Test]
        public void IBC_006_111792_Manage_Account_option_for_AP_verify_the_display_of_manage_account_option_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPageLocators(driver).readJsonEnglishData();
            Pages._apManageAccountPage(driver).verify_the_display_of_manage_account_option_page(apName, apEmailId);
        }
        [Test]
        public void IBC_007_109728_Registration_Page_for_AP_users_Verify_the_display_of_Registration_Page_for_AP_users()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apRegistrationLink);
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._apPageLocators(driver).readJsonEnglishData();
            Pages._authorizedPersonnelPage(driver).Verify_the_display_of_Registration_Page_for_AP_users();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apPageLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).Verify_the_display_of_Registration_Page_for_AP_users();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelPage(driver).Verify_the_display_of_Registration_Page_for_AP_users();
        }
        [Test]
        public void IBC_008_109735_Registration_Page_for_AP_users_Verify_the_display_of_Registration_Page_for_AP_users()
        {
            setTestData();
            Pages._authorizedPersonnelPage(driver).goToApRegistrationLink(apRegistrationLink);
            Pages._authorizedPersonnelPage(driver).Verify_the_functionality_of_Registration_Page_for_AP_users();
        }
        [Test]
        public void IBC_009_117258_Registration_Page_for_AP_users_Verify_the_functionality_of_Continue_button_error_values_in_Registration_Page_for_AP_users()
        {
            setTestData();
            Pages._authorizedPersonnelPage(driver).goToApRegistrationLink(apRegistrationLink);
            Pages._authorizedPersonnelPage(driver).Verify_the_functionality_of_Continue_button_error_values_in_Registration_Page_for_AP_users();
        }
        [Test]
        public void IBC_010_115775_Manage_Account_option_for_AP_verify_the_display_of_manage_account_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPageLocators(driver).readJsonSpanishData();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apManageAccountPage(driver).verify_the_display_of_manage_account_option_page(apName, apEmailId);
        }
        [Test]
        public void IBC_011_164465_Manage_Account_option_for_AP_verify_the_functionality_of_manage_account_password_edit_icon()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).clickOnPasswordEditIcon();
            Pages._authorizedPersonnelPage(driver).verify_the_display_of_Reset_password_page();
            Pages._authorizedPersonnelPage(driver).clickOnCancelButton();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
        }
        [Test]
        public void IBC_025_115776_Manage_Account_option_for_AP_verify_the_functionality_contact_number()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).verify_the_functionality_contact_number_error_values(apEmailId);
        }
        [Test]
        public void IBC_012_115771_UI_of_the_IBC_landing_page_verify_the_display_of_IBC_landing_page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(caUrl);
            Pages._mainPage(driver).verify_the_display_of_IBC_landing_page();
            Pages._mainPage(driver).Verify_main_page_footer();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPageLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).verify_the_display_of_IBC_landing_page();
            Pages._mainPage(driver).Verify_main_page_footer();
        }
        [Test]
        public void IBC_013_115772_UI_of_the_IBC_landing_page_verify_the_functionality_of_IBC_landing_page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(caUrl);
            Pages._mainPage(driver).verify_the_functionality_of_IBC_landing_page();
        }
        [Test]
        public void IBC_014_117797_Registration_Page_for_AP_users_Verify_the_functionality_of_Registration_Page_after_completing_the_registration()
        {
            setTestData();
            Pages._authorizedPersonnelPage(driver).goToApRegistrationLink(apAlreadyRegisteredLink);
            Pages._authorizedPersonnelPage(driver).Verify_the_functionality_of_Registration_Page_after_completing_the_registration();
        }
        [Test]
        public void IBC_015_115804_Receive_one_call_at_a_time_verify_the_functionality_of_one_call_at_a_timen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
          //  Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._apOnGoingCall(driver).change_simulator_values_Verify_incomingCall(simulatorLink);
        }
        [Test]
        public void IBC_016_115968_Receive_one_call_at_a_time_verify_ring_for_45_sec_and_hang_up_if_no_AP_answers()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
        }
        [Test]
        public void IBC_017_115970_Receive_one_call_at_a_time_verify_other_calls_will_be_waiting_for_connection_with_other_APs()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_Second_call_from_car(simulatorLink);
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
        }

        [Test]
        public void IBC_020_118335_Receive_one_call_at_a_time_verify_ring_for_45_sec_and_hang_up_if_no_AP_answers_in_ongoing_call_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_Second_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
            Pages._authorizedPersonnelPage(driver).verify_Call_notification_Closed();
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
        }
       
        [Test]
        public void IBC_022_151994_View_the_elevator_unit_information_verify_the_display_of_unit_information()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            if (active_UnitId == "")
                Console.WriteLine("No active units are available to initiate call from IBC");
            else
            {
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_IBC(active_UnitId);
                Pages._apOnGoingCall(driver).verify_display_of_IBC_initiate_call_screen(active_UnitId, active_BuildingID);
                Pages._apOnGoingCall(driver).scrollDown(driver);
                Pages._apOnGoingCall(driver).clickOnCallEndIcon();
                Pages._mainPage(driver).ChangeLanguageToFrench();
                Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_IBC(active_UnitId);
                Pages._apOnGoingCall(driver).verify_display_of_IBC_initiate_call_screen(active_UnitId, active_BuildingID);
                Pages._apOnGoingCall(driver).scrollDown(driver);
                Pages._apOnGoingCall(driver).clickOnCallEndIcon();
                Pages._mainPage(driver).ChangeLanguageToSpanish();
                Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_IBC(active_UnitId);
                Pages._apOnGoingCall(driver).verify_display_of_IBC_initiate_call_screen(active_UnitId, active_BuildingID);
                Pages._apOnGoingCall(driver).scrollDown(driver);
                Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            }
        }
        [Test]
        public void IBC_023_115989_UI_for_an_incoming_call_verify_the_display_of_incoming_call()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).verify_Call_Notification();
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
        }

        [Test]
        public void IBC_027_139526_Connecting_Call_screen_verify_the_functionality_call_disconnect_button()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
        }
        [Test]
        public void IBC_028_122553_UI_screen_of_the_ongoing_calls_between_AP_passenger_verify_the_functionality_of_ongoing_calls_between_AP_passenger()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).verify_display_of_ongoing_call_screen();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_029_115972_UI_screen_of_the_ongoing_calls_between_AP_passenger_verify_the_display_of_ongoing_calls_between_AP_passenger()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._apOnGoingCall(driver).verify_functionality_of_ongoing_call_screen(simulatorLink);
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_019_144512_UI_for_an_incoming_call_verify_the_display_of_incoming_call_shutdown_reason_floor_and_direction_values()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._apOnGoingCall(driver).change_simulator_values(simulatorLink);
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_018_144527_Registration_Page_for_AP_users_Verify_the_functionality_of_contact_number_textbox()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apRegistrationLink);
            Pages._authorizedPersonnelLoginPage(driver).Verify_the_functionality_of_contact_number_textbox();
        }
        [Test]
        public void IBC_030_111793_Manage_Account_option_for_AP_verify_the_functionality_of_contact_number()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).verify_the_functionality_contact_number(apContactNumber);
            Pages._apManageAccountPage(driver).Update_contact_Number(AuthorizedPersonnelManageAccountPageLocators.newContactNumber);
            Pages._authorizedPersonnelLoginPage(driver).logout();
            Pages._authorizedPersonnelLoginPage(driver).loginSecondTime(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).verify_the_functionality_contact_number(AuthorizedPersonnelManageAccountPageLocators.newContactNumber);
            Pages._apManageAccountPage(driver).Update_contact_Number(apContactNumber);
        }
        [Test]
        public void IBC_031_139530_Receive_one_call_at_a_time_verify_functionality_of_initiate_call_after_logout_form_the_application()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car_after_logout(simulatorLink);
        }
        [Test]
        public void IBC_024_139451_Remember_me_and_Reset_Password_options_at_Login_verify_the_functionality_of_forgot_password_option_error_values()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._APResetPasswordPage(driver).EnterEmailId(CustomerAdminPageLocators.emailTextBoxValue);
            Pages._APResetPasswordPage(driver).clickOnVerificationButton();
            Pages._APResetPasswordPage(driver).verify_the_display_of_error_popup();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._APResetPasswordLocators(driver).readJsonFrenchData();
            Pages._APResetPasswordPage(driver).EnterEmailId(CustomerAdminPageLocators.emailTextBoxValue);
            Pages._APResetPasswordPage(driver).clickOnVerificationButton();
            Pages._APResetPasswordPage(driver).verify_the_display_of_error_popup();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._APResetPasswordLocators(driver).readJsonSpnishData();
            Pages._APResetPasswordPage(driver).EnterEmailId(CustomerAdminPageLocators.emailTextBoxValue);
            Pages._APResetPasswordPage(driver).clickOnVerificationButton();
            Pages._APResetPasswordPage(driver).verify_the_display_of_error_popup();
        }
        [Test]
        public void IBC_032_115768_Initiate_the_call_to_elevator_trapped_passenger_verify_the_display_of_ongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            if (active_UnitId == "")
                Console.WriteLine("No active units are available to initiate call from IBC");
            else
            {
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_IBC(active_UnitId);
                Pages._apOnGoingCall(driver).verify_display_of_IBC_initiate_call_screen(active_UnitId, active_BuildingID);
                Pages._apOnGoingCall(driver).scrollDown(driver);
                Pages._apOnGoingCall(driver).clickOnCallEndIcon();
                //Pages._mainPage(driver).verifyFooter();
                //Pages._authorizedPersonnelPage(driver).verify_header();
            }
        }
        [Test]
        public void IBC_033_163433_Manage_Account_option_for_AP_verify_the_display_and_functionality_of_contact_number_cancel_button()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).clickOnContactNumberEditIcon();
            Pages._apManageAccountPage(driver).enterContactNumber("1234");
            Pages._apManageAccountPage(driver).verify_contacctNumber_error_message();
            Pages._apManageAccountPage(driver).clickonCancel();
            Pages._apManageAccountPage(driver).verify_contact_number_alert_popup();
            Pages._apManageAccountPage(driver).clicOnAlertCancel();
            Pages._apManageAccountPage(driver).clickonCancel();
            Pages._apManageAccountPage(driver).clicOnAlertDiscardButton();
            Pages._apManageAccountPage(driver).verify_the_display_of_manage_account_option_page(apName,apEmailId);
        }
    }
}
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
using System.Threading;

namespace OTIS_One_Framework.Net.IBC_Automation.TestScripts
{

    public class IBC_App_Sprint09 : TestBase
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

        public void setTestData()
        {

            try
            {
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                string path = path1 + Pages._mainPageLocators(driver).path;
                var jsonFile = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint09>>(jsonFile);
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        [Test]
        public void IBC_001_149144_Alert_message_before_refreshing_the_browser_verify_functionality_of_logout_option_inongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout(); 
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_002_149145_Alert_message_before_refreshing_the_browser_verify_functionality_of_manage_account_option_inongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_003_149146_Alert_message_before_refreshing_the_browser_verify_functionality_of_click_on_licence_option_inongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._mainPage(driver).clickOnLicense();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).clickOnLicense();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._mainPage(driver).clickOnLicense();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_004_160890_Alert_message_before_refreshing_the_browser_verify_functionality_of_click_on_header_image_inongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._apOnGoingCallLocators(driver).readJsonEnglishData();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._apOnGoingCall(driver).verify_call_disconnect_alret_popup();
            Pages._apOnGoingCall(driver).ClickOnOkButton();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_005_161318_Logout_as_Otis_Admin_through_Profile_icon_Verify_the_display_of_logout_option()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).verify_display_of_profileIcon();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._mainPage(driver).otisChangeLanguageToFrench();
            Pages._otisAdminPageLocators(driver).readJsonFrenchData();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).verify_display_of_profileIcon();
        }
        [Test]
        public void IBC_006_161325_Logout_as_Otis_Admin_through_Profile_icon_verify_the_functionality_of_logout_from_ePAL_option()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnLogoutFromEpal();
            Pages._mainPage(driver).ClickOnOtisAdmin();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnLogoutFromEpal();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
            Pages._mainPage(driver).ClickOnCustomerAdmin();
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSubmitButton();
            Pages._customerLoginPage(driver).AnswerTheSecurityQuestion(caSecurityAnswer);
            Pages._customerLoginPage(driver).clickOnProceedButton();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnLogout();
            Pages._mainPage(driver).ClickOnOtisAdmin();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnLogoutFromEpal();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._mainPage(driver).ClickOnOtisAdmin();
            Pages._otisAdminPage(driver).verify_Otis_admin_page_web_elements();
        }
        [Test]
        public void IBC_007_161326_Logout_as_Otis_Admin_through_Profile_icon_verify_the_functionality_of_logout_from_ADO_option()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            //Pages._otisAdminPage(driver).clickOnLogoutFromADO();
            //Pages._otisAdminPage(driver).verifyOtisAdminEmailId(otisEmailId);
            //Pages._otisAdminPage(driver).clickOnOtisemailId();
        }
        [Test]
        public void IBC_008_161332_Search_Customer_using_Customer_ID_verify_the_functionality_of_partial_data_entry_to_be_able_to_give_related_search_results()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).Search_By_Customer_ID();
            Pages._otisAdminPage(driver).verify_the_functionality_of_partial_data_entry_to_be_able_to_give_related_search_results();
        }
        [Test]
        public void IBC_009_161335_Search_Customer_using_email_ID_verify_the_functionality_of_partial_data_entry_to_be_able_to_give_related_search_results()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).verify_partial_search_functionality(caEmailId);
        }
    }
}
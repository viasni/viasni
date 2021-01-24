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

    public class IBC_App_Sprint03 : TestBase
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
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint03>>(jsonFile);
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
        public void IBC_001_117847_Text_communication_with_the_Elevator_verify_the_functionality_of_send_predefined_text_messages_into_elevator()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).verify_the_functionality_text_communication();
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_002_117848_Text_communication_with_the_Elevator_verify_the_6_steps_provided_by_NAA_team_are_available_in_dropdown_list()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).clickOnDropdown();
            Pages._apOnGoingCall(driver).verify_the_6_steps_provided_by_NAA_team_are_available_in_dropdown_list();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_003_117851_Text_communication_with_the_Elevator_verify_selected_message_is_added_to_the_custom_message_area_and_able_to_edit_and_send_it_to_elevator()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).clickOnDropdown();
            Pages._apOnGoingCall(driver).clickOnDropDownFouthValue();
            Pages._apOnGoingCall(driver).verify_the_functionality_of_custom_message_textbox();
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_004_117855_Text_communication_with_the_Elevator_verify_dropdown_predefined_French_text_messages()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._customerAdminPage(driver).ChangeLanguageToFrench();
            Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
            Pages._apOnGoingCall(driver).clickOnDropdown();
            Pages._apOnGoingCall(driver).verify_the_6_steps_provided_by_NAA_team_are_available_in_dropdown_list();
            Pages._customerAdminPage(driver).ChangeLanguageToSpanish();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._apOnGoingCall(driver).clickOnDropdown();
            Pages._apOnGoingCall(driver).verify_the_6_steps_provided_by_NAA_team_are_available_in_dropdown_list();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_005_117857_Text_communication_with_the_Elevator_verify_the_functionality_of_custom_message_textbox()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).verify_the_functionality_text_communication();
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_006_117860_Text_communication_with_the_Elevator_verify_the_functionality_of_send_text_messages_into_elevator()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).verify_the_functionality_of_send_text_messages_into_elevator();
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
        [Test]
        public void IBC_007_115496_Language_option_on_all_AP_screens_verify_language_option_present_in_Main_landing_page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(caUrl);
            Pages._mainPage(driver).verify_Language_Option();
        }
        [Test]
        public void IBC_008_115488_Language_option_on_all_AP_screens_verify_functionality_of_language_option_in_forgot_password_page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._APResetPasswordLocators(driver).readJsonFrenchData();
            Pages._APResetPasswordPage(driver).verify_the_display_of_forgot_password_option();
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._APResetPasswordLocators(driver).readJsonEnglishData();
            Pages._APResetPasswordPage(driver).verify_the_display_of_forgot_password_option();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._APResetPasswordLocators(driver).readJsonSpnishData();
            Pages._APResetPasswordPage(driver).verify_the_display_of_forgot_password_option();
        }
        [Test]
        public void IBC_009_120436_Language_option_on_all_AP_screens_verify_functionality_of_language_option_in_Main_landing_page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(caUrl);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPageLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).verify_the_display_of_IBC_landing_page();
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._mainPageLocators(driver).readJsonEnglishData();
            Pages._mainPage(driver).verify_the_display_of_IBC_landing_page();
        }
        [Test]
        public void IBC_010_118824_Language_option_on_all_AP_screens_verify_the_display_for_AP_forgot_password_page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._mainPage(driver).verify_Language_Option();
        }
        [Test]
        public void IBC_011_119105_Language_option_on_all_AP_screens_verify_the_display_for_AP_reset_password_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).clickOnPasswordEditIcon();
            Pages._mainPage(driver).verify_Language_Option();

        }
        [Test]
        public void IBC_012_120974_Language_option_on_all_AP_screens_verify_the_functionality_for_AP_reset_password_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._apManageAccountPage(driver).clickOnPasswordEditIcon();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._APResetPasswordLocators(driver).readJsonEnglishData();
            Pages._authorizedPersonnelPage(driver).verify_the_display_of_Reset_password_page();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._APResetPasswordLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).verify_the_display_of_Reset_password_page();

        }
        [Test]
        public void IBC_013_118818_Language_option_on_all_AP_screens_verify_the_display_of_language_option_in_AP_registration()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(apRegistrationLink);
            Pages._mainPage(driver).verify_Language_Option();
        }
        [Test]
        public void IBC_014_120996_Language_option_on_all_AP_screens_verify_the_functionality_of_language_option_in_AP_registration()
        {
            setTestData();
            Pages._authorizedPersonnelPage(driver).goToApRegistrationLink(apRegistrationLink);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apPageLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).Verify_the_display_of_Registration_Page_for_AP_users();
            Pages._authorizedPersonnelPage(driver).Verify_the_functionality_of_Continue_button_error_values_in_Registration_Page_for_AP_users();
            Pages._authorizedPersonnelPage(driver).Verify_the_functionality_of_Registration_Page_for_AP_users();
        }
        [Test]
        public void IBC_015_118821_Language_option_on_all_AP_screens_verify_the_display_of_language_option_in_AP_login_Page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(apUrl);
            Pages._mainPage(driver).verify_Language_Option();
        }

        [Test]
        public void IBC_016_115493_Language_option_on_all_AP_screens_verify_the_functionality_of_language_option_in_AP_login_Page()
        {
            setTestData();
            Pages._mainPage(driver).goToMainPage(apUrl);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apLoginPageLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();           
            Pages._mainPage(driver).ChangeLanguageToEnglish();
            Pages._apLoginPageLocators(driver).readJsonEnglishData();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apLoginPageLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();
        }
        [Test]
        public void IBC_017_117844_UI_of_Text_messages_with_Color_coding_verify_the_display_of_chat_area()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).verify_the_functionality_text_communication();
            Pages._apOnGoingCall(driver).swithToEelevator();
            Pages._apOnGoingCall(driver).send_Yes_from_elevator();
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).verify_Color_coding_of_chat_area();
        }
        [Test]
        public void IBC_018_116055_Adjust_Microphone_speaker_volume_verify_the_display_of_Microphone_and_speaker_volume_buttons()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).verify_the_display_of_Microphone_and_speaker_volume_buttons();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
        }
    }
}
        
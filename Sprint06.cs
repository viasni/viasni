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

    public class IBC_App_Sprint06 : TestBase
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
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint06>>(jsonFile);
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
        public void IBC_001_128202_incoming_call_missed_call_message_displayed_on_AP_screen_verify_the_display_of_second_call_popup_message_in_ongoing_call_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_Second_call_from_car(simulatorLink);
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apOnGoingCallLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelPage(driver).Initiate_Second_call_from_car(simulatorLink);
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._mainPage(driver).ChangeLanguageToSpanish();
            Pages._apOnGoingCallLocators(driver).readJsonSpanishData();
            Pages._authorizedPersonnelPage(driver).Initiate_Second_call_from_car(simulatorLink);
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).clickOnCallReceiveButton();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).clickOnCallEndIcon(); 

        }
        [Test]
        public void IBC_002_137074_incoming_call_missed_call_message_displayed_on_AP_screen_verify_the_functionality_of_second_call_popup_message_close_button()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_Second_call_from_car(simulatorLink);
            Pages._apOnGoingCall(driver).click_on_second_incomming_call_notification_close_button();
            Pages._apOnGoingCall(driver).scrollDown(driver);
            Pages._apOnGoingCall(driver).swithToOngoingCall();
            Pages._apOnGoingCall(driver).clickOnCallEndIcon();
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();            
        }
        [Test]
        public void IBC_003_135296_Device_Authentication_Register_device_with_OTP_verify_the_display_of_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._caManageFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._customerAdminManageFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();
        }

        [Test]
        public void IBC_005_135308_Device_Authentication_Register_device_with_OTP_verify_the_display_of_register_device_button_in_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_the_display_of_register_device_button();

        }
        [Test]
        public void IBC_006_135316_Device_Authentication_Register_device_with_OTP_verify_the_display_of_cancel_button_in_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._caManageFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_cancel_button();
        }
        [Test]
        public void IBC_007_135341_Device_Authentication_Register_device_with_OTP_verify_the_functionality_of_cancel_button_in_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._caManageFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).selectBuildingID();
            Pages._customerAdminManageFccdevicePage(driver).clickOnCancelButton();
            Pages._customerAdminManageFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();
        }
        [Test]
        public void IBC_008_135346_Device_Authentication_Register_device_with_OTP_verify_the_functionality_of_register_device_button_in_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_the_functionality_of_register_device();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._caManageFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._customerAdminManageFccdevicePage(driver).verify_the_functionality_of_register_device();

        }
        [Test]
        public void IBC_009_135415_Device_Authentication_Register_device_with_OTP_verify_the_display_and_functionality_of_language_option_button_in_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._caManageFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._customerAdminManageFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();

        }
        [Test]
        public void IBC_010_137080_Display_list_of_Active_EP_devices_along_with_Delete_Block_option_to_avoid_misuse_verify_the_display_of_delete_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_display_of_delete_popup();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._caManageFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._customerAdminManageFccdevicePage(driver).verify_display_of_delete_popup();
        }

        [Test]
        public void IBC_011_149425_Display_list_of_Active_EP_devices_verify_the_functionality_of_cancel_button_in_delete_popup_message()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_functionality_of_cancel_button_in_delete_popup_message();
        }
        [Test]
        public void IBC_012_163452_Device_Authentication_Register_device_with_OTP_verify_the_functionality_of_sorting_of_building_ID_in_Manage_FCC_device_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
            Pages._customerAdminManageFccdevicePage(driver).verify_functionality_of_of_sorting_of_building_ID();
        }
       
    }
}
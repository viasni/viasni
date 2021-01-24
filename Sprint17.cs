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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OTIS_One_Framework.Net.IBC_Automation.TestScripts
{

    public class IBC_App_Sprint17 : TestBase
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
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint15>>(jsonFile);
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
        public void IBC_01_200070_Verify_the_display_of_the_delete_btn_on_OA()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
        }

        [Test]
        public void IBC_02_206952_Verify_the_delete_button_is_having_popup_with_delete_to_remove_the_EP_Device()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).clickOnDeleteIcon();
            Pages._otisAdminFccdevicePage(driver).clicktheDeleteBtnonPopup();
        }
        [Test]
        public void IBC_03_206949_Verify_the_delete_icon_popup_with_cancel_will_not_remove_the_EP_Device()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).clickOnDeleteIcon();
            Pages._otisAdminFccdevicePage(driver).click_on_CancelBtn_on_Popup();
        }

        [Test]
        public void IBC_04_200042_Verify_the_delete_button_with_pop_up_to_removing_the_EP_Device()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnDeleteIcon();
            Pages._customerAdminPage(driver).verifiyDeleteButton();
        }

        [Test]
        public void IBC_05_201911_verify_the_change_language_option_on_OA_for_manage_FCC_device_screen()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminFccdevicePage(driver).ChangeLanguageToFrench();
            Pages._otisAdminFccdevicePage(driver).ChangeLanguageToEnglish();
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).ChangeLanguageToFrench();
            Pages._otisAdminFccdevicePage(driver).ChangeLanguageToEnglish();
        }

        [Test]
        public void IBC_06_191199_verify_the_list_of_registered_EP_devices_through_search_button_on_OA()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_buildingId_on_Dropdown();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnSearchButton();
        }

        [Test]
        public void IBC_07_207010_verify_the_list_of_registered_EP_devices_through_cancel_button_on_OA()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_buildingId_on_Dropdown();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnCancelButton();
        }
        [Test]
        public void IBC_08_207046_verify_the_list_of_registered_EP_devices_with_cancel_button_on_OA_for_FCC_Page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).EnterTextBox();
            Pages._otisAdminFccdevicePage(driver).clickOnCancelButton();
            
        }

        [Test]
        public void IBC_09_207055_verify_the_list_of_registered_EP_devices_through_search_device_button_on_OA_for_FCC_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).EnterTextBox();
            Pages._otisAdminFccdevicePage(driver).searchdeviceBtn();
        }

        [Test]
        public void IBC_10_201838_verify_the_EP_devices_displayed_on_CA()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnManageDeviceFcc();
        }
        [Test]
        public void IBC_11_207539_verify_the_list_of_registered_EP_devices_for_unit_ID_through_search_button_on_OA()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_UnitID_Dropdown();
            Pages._otisAdminFccdevicePage(driver).enter_UnitID();
            Pages._otisAdminFccdevicePage(driver).clickOnSearchButton();
        }
        [Test]
        public void IBC_12_207542_verify_the_list_of_registered_EP_devices_through_Unit_ID_with_cancel_button_on_OA()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_UnitID_Dropdown();
            Pages._otisAdminFccdevicePage(driver).enter_UnitID();
            Pages._otisAdminFccdevicePage(driver).clickOnCancelButton();
        }
        [Test]
        public void IBC_13_201899_Verify_the_EP_Dashboard_screen_with_Registed_devices()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_buildingId_on_Dropdown();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnSearchButton();
            Pages._otisAdminFccdevicePage(driver).clickon_registerdeviceBtn();
            Pages._otisAdminFccdevicePage(driver).Enter_EmailID();
            Pages._otisAdminFccdevicePage(driver).clickon_registerdevice();
        }

    }
}
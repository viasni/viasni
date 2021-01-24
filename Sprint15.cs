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

    public class IBC_App_Sprint15 : TestBase
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
        public void IBC_01_191808_EP_Devices_registered_successfully()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_buildingId_on_Dropdown();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnSearchButton();
            Pages._otisAdminFccdevicePage(driver).click_on_register_device();
            Pages._otisAdminFccdevicePage(driver).Enter_EmailID();
            Pages._otisAdminFccdevicePage(driver).clickon_registerdevice();

        }

        [Test]
        public void IBC_02_191822_EP_Device_without_email_validation()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnSearchButton();
            Pages._otisAdminFccdevicePage(driver).click_on_register_device();
            Pages._otisAdminFccdevicePage(driver).ClickonCancelBtnonEmailpop_up();

        }
        [Test]
        public void IBC_03_191831_EP_Device_with_email_validation_using_cancel_btn()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnSearchButton();
            Pages._otisAdminFccdevicePage(driver).click_on_register_device();
            Pages._otisAdminFccdevicePage(driver).Enter_EmailID();
            Pages._otisAdminFccdevicePage(driver).ClickonCancelBtnonEmailpop_up();
        }
        [Test]
        public void IBC_04_191815_EP_Device_with_cancel_Btn()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).enter_building_id();
            Pages._otisAdminFccdevicePage(driver).clickOnCancelButton();
          
        }
    }
}
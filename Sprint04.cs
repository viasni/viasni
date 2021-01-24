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
    class IBC_App_Sprint04 : TestBase
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
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint04>>(jsonFile);
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

        // Implementation has been changed
        //[Test]
        //public void IBC_001_122451_Back_option_on_all_screens_verify_the_display_of_Manage_account_back_button()
        //{
        //    setTestData();
        //    Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
        //    Pages._authorizedPersonnelPage(driver).clickOnProfile();
        //    Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
        //    Pages._authorizedPersonnelPage(driver).verify_the_display_of_Back_Button();
        //}
        //[Test]
        //public void IBC_002_122448_Back_option_on_all_screens_verify_the_functionality_of_Manage_account_back_button()
        //{
        //    setTestData();
        //    Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
        //    Pages._authorizedPersonnelPage(driver).clickOnProfile();
        //    Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
        //    Pages._authorizedPersonnelPage(driver).verify_the_functionality_of_Back_Button();
        //}
        //[Test]
        //public void IBC_003_122453_Back_option_on_all_screens_verify_the_display_of_EP_Access_Link_page_back_button()
        //{
        //    setTestData();
        //    Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
        //    Pages._customerAdminPage(driver).clickOnProfile();
        //    Pages._customerAdminPagelocators(driver).readJsonEnglishData();
        //    Pages._customerAdminPage(driver).clickonEPAccessLink();
        //    Pages._customerAdminPage(driver).verify_the_display_of_Back_Button();
        //}
        //[Test]
        //public void IBC_004_122454_Back_option_on_all_screens_verify_the_functionality_of_EP_Access_Link_page_back_button()
        //{
        //    setTestData();
        //    Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
        //    Pages._customerAdminPage(driver).clickOnProfile();
        //    Pages._customerAdminPagelocators(driver).readJsonEnglishData();
        //    Pages._customerAdminPage(driver).clickonEPAccessLink();
        //    Pages._customerAdminPage(driver).verify_the_functionality_of_Back_Button();
        //}
        [Test]
        public void IBC_005_122455_Back_option_on_all_screens_verify_the_display_of_Cancel_button_in_reset_password_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._APResetPasswordPage(driver).verify_the_display_of_Canel_Button();
        }
        [Test]
        public void IBC_006_122456_Back_option_on_all_screens_verify_the_functionality_of_Cancel_button_in_reset_password_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnForgotPassword();
            Pages._APResetPasswordPage(driver).verify_the_functionality_of_Button();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();
        }
       
      
    }
}
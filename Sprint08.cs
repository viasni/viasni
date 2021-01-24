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

    public class IBC_App_Sprint08 : TestBase
    {
        // ap - Authorized Personnel
        // ca - Customer Admin
        public string AP_Email_Id { get; set; }
        public string CA_Email_Id { get; set; }
        public string Second_CA_Email_Id { get; set; }
        public string AP_Password { get; set; }
        public string CA_Password { get; set; }
        public string Second_CA_Password { get; set; }
        public string AP_URL { get; set; }
        public string AP_SecurityAnswer { get; set; }
        public string CA_SecurityAnswer { get; set; }
        public string Second_CA_SecurityAnswer { get; set; }
        public string AP_Name { get; set; }
        public string CA_Url { get; set; }
        public string Simulator_Link { get; set; }
        public string CA_Name { get; set; }
        public string AP_RegistrationLink { get; set; }
        public string Otis_Email_Id { get; set; }
        public string Otis_Password { get; set; }
        public string Otis_URL { get; set; }
        public string Active_UnitId { get; set; }
        public string CA_Twilio_Status { get; set; }
        public string Second_CA_Twilio_Status { get; set; }
        public string CA_SecurityQuestion { get; set; }
        public string AP_SecurityQuestion { get; set; }

        static string ca_securityQuestion;
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
        static string secondcaPassword;
        static string secondcaSecurityAnswer;
        static string secondcaEmailId;
        static string second_CA_Twilio_Status;
        static string ca_Twilio_Status;
        static string apSecurityQuestion;
        public void setTestData()
        {

            try
            {
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                string path = path1 + Pages._mainPageLocators(driver).path;
                var jsonFile = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint08>>(jsonFile);
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
                secondcaPassword = jsonText.Second_CA_Password;
                secondcaSecurityAnswer = jsonText.Second_CA_SecurityAnswer;
                secondcaEmailId = jsonText.Second_CA_Email_Id;
                second_CA_Twilio_Status = jsonText.Second_CA_Twilio_Status;
                ca_Twilio_Status = jsonText.CA_Twilio_Status;
                ca_securityQuestion = jsonText.CA_SecurityQuestion;
                apSecurityQuestion = jsonText.AP_SecurityQuestion;
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
        public void IBC_001_143881_Twilio_Account_for_Customer_Admin_Default_verify_the_display_of_twilio_update_account_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonEnglishData();
            Pages._customerAdminPage(driver).verify_display_of_Twilio_account_page();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).verify_display_of_Twilio_account_page();
        }
        [Test]
        public void IBC_002_143892_Twilio_Screen_activation_verify_the_functionality_of_twilio_update_account_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonEnglishData();
            Pages._customerAdminPage(driver).clickOnUpdateAccount();
            Pages._customerAdminPage(driver).verify_display_of_License_details_page();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).verify_display_of_License_details_page();
        }
        [Test]
        public void IBC_003_143903_Twilio_Screen_activation_verify_the_functionality_of_cancel_button_in_Update_Twilio_License_Details_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).clickOnUpdateAccount();
            Pages._customerAdminPage(driver).clickOnlicenseDetailsCancelButton();
            Pages._customerAdminPage(driver).verify_display_of_Twilio_account_page();           
        }
        [Test]
        public void IBC_004_143929_Twilio_Screen_activation_verify_the_functionality_of_Send_verification_code_button()
        {
             setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonEnglishData();
            Pages._customerAdminPage(driver).clickOnUpdateAccount();
            Pages._customerAdminPage(driver).clickOnSendVerificationCodeButton();
            Pages._customerAdminPage(driver).verify_display_of_verification_code_page();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).verify_display_of_verification_code_page();
        }
        [Test]
        public void IBC_005_143930_Twilio_Screen_activation_verify_the_functionality_of_cancel_button_in_Twilio_verify_Code_Page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).clickOnUpdateAccount();
            Pages._customerAdminPage(driver).clickOnSendVerificationCodeButton();
            Pages._customerAdminPage(driver).clickOnlicenseDetailsCancelButton();
            Pages._customerAdminPage(driver).verify_display_of_Twilio_account_page();          
        }
      
        [Test]
        public void IBC_006_143933_Twilio_Screen_activation_verify_the_error_functionality_of_verify_codee_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonEnglishData();
            Pages._customerAdminPage(driver).clickOnUpdateAccount();
            Pages._customerAdminPage(driver).clickOnSendVerificationCodeButton();
            Pages._customerAdminPage(driver).enterOTP();
            Pages._customerAdminPage(driver).clickOnVerifyCodeButton();
            Pages._customerAdminPage(driver).verifyErrorMessage();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPage(driver).verifyErrorMessage();
        }
        [Test]
        public void IBC_010_145879_Twilio_Account_of_Out_of_contract_customers_Verify_OA_screen_shows_Twilio_Account_column_as_Private()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).Search_By_Email_ID();
            Pages._otisAdminPage(driver).Enter_Serach_input(secondcaEmailId);
            Pages._otisAdminPage(driver).clickOnSearchButton();
            Pages._otisAdminPage(driver).verify_Twilio_Account_status(caEmailId, second_CA_Twilio_Status);
           
          
        }
        [Test]
        public void IBC_008_149143_Twilio_Account_for_Customer_Admin_Verify_we_can_able_to_edit_the_twilio_details()
        {            
            setTestData();
            Pages._customerLoginPage(driver).Login(secondcaEmailId, secondcaPassword, secondcaSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPage(driver).verify_functionality_of_updating_twilio_details();
        }
        [Test]
        public void IBC_013_149142_Twilio_Account_for_Customer_Admin_verify_the_display_of_twilio_update_account_page_after_updating_twilio_details()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(secondcaEmailId, secondcaPassword, secondcaSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPagelocators(driver).readJsonEnglishData();
            Pages._customerAdminPage(driver).verify_display_of_Twilio_account_page_after_updating_twilio_details();
        }
        [Test]
        public void IBC_011_149139_Twilio_Account_for_Customer_Admin_verify_the_display_of_twilio_update_account_page_before_updating_twilio_details()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).Search_By_Email_ID();
            Pages._otisAdminPage(driver).Enter_Serach_input(caEmailId);
            Pages._otisAdminPage(driver).clickOnSearchButton();
            Pages._otisAdminPage(driver).verify_Twilio_Account_status(caEmailId, ca_Twilio_Status);            
        }
        [Test]
        public void IBC_012_149140_Twilio_Account_of_Out_of_contract_customers_Verify_the_functionality_of_cancel_button_in_Twilio_License_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(secondcaEmailId, secondcaPassword, secondcaSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPage(driver).verify_functionality_of_cancel_button_in_update_twilio_details_page();
        }
        [Test]
        public void IBC_007_145876_Twilio_Account_of_Out_of_contract_customers_Verify_the_functionality_of_save_button_in_Twilio_License_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(secondcaEmailId, secondcaPassword, secondcaSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPage(driver).verify_functionality_of_save_button_in_update_twilio_details_page();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).verify_functionality_of_save_button_in_update_twilio_details_page();
        }
        [Test]
        public void IBC_009_145878_Twilio_Account_of_Out_of_contract_customers_Verify_the_error_functionality_of_save_button_in_Twilio_License_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(secondcaEmailId, secondcaPassword, secondcaSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPage(driver).verify_error_functionality_of_save_button_in_update_twilio_details_page();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._customerAdminPagelocators(driver).readJsonFrenchData();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnTwilioAccount();
            Pages._customerAdminPage(driver).verify_error_functionality_of_save_button_in_update_twilio_details_page();
        }
        [Test]
        public void IBC_014_142858_Updates_issues_in_CA_webpages_Verify_default_security_question_selected_during_CA_login()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSubmitButton();
            Pages._customerLoginPage(driver).Verify_default_selected_security_question(ca_securityQuestion);
            Pages._customerLoginPage(driver).clickOnCancelButton();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._customerLoginPage(driver).Verify_AP_default_selected_security_question(apSecurityQuestion);
        }

    }
}
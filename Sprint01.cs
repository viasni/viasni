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
  
    public class IBC_App_Sprint01 : TestBase
    {
        //  ap - Authorized Personnel
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
        public string CA_Name { get; set; }
        static string apUrl;
        static string apEmailId;
        static string caEmailId;
        static string apPassword;
        static string caSecurityAnswer;
        static string apSecurityAnswer;
        static string apName;
        static string caName;
        static string caPassword;
        static string caUrl;

        public void setTestData()
        {

            try
            {  
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");              
                string path = path1 + Pages._mainPageLocators(driver).path;               
                var jsonFile = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint01>>(jsonFile);
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
                caUrl = jsonText.CA_Url;
                Pages._otisAdminPageLocators(driver).readJsonEnglishData();
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
                Pages._customerLoginPageLocators(driver).readJsonEnglishData();
                Pages._apLoginPageLocators(driver).readJsonEnglishData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        [Test]
        public void IBC_001_111771_Login_to_AP_App_with_registered_email_ID_password_verify_the_display_of_login_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._apLoginPageLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelLoginPage(driver).Verify_UI_APLoginPage();

        }
        [Test]
        public void IBC_002_111772_Login_to_AP_App_with_registered_email_ID_password_verify_the_functionality_of_login_button()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId,apPassword, apUrl, apSecurityAnswer);
        }
        [Test]
        public void IBC_003_113364_Login_to_AP_App_with_registered_email_ID_password_verify_the_functionality_of_login_button()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);           
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._authorizedPersonnelLoginPage(driver).loginSecondTime(apEmailId, apPassword, apUrl, apSecurityAnswer);

        }
        [Test]
        public void IBC_004_111773_Login_to_AP_App_with_registered_email_ID_password_verify_the_functionality_of_login_button_error_values()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).verify_login_error_messaage_for_empty_values();
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword.ToLower());
            Pages._authorizedPersonnelLoginPage(driver).verify_login_error_messaage_hiden();
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).verify_incorrect_popup_Error_Values();           
        }
        [Test]
        public void IBC_005_113432_Login_to_AP_App_with_registered_email_ID_password_verify_the_functionality_of_login_button_error_values_for_invalid_Email_id()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).verify_Error_Values_For_Invalid_EmailId(AuthorizedPersonnelPageLoginLocators.inValidEmailId, apPassword, apUrl);
        }
        [Test]
        public void IBC_006_113489_Login_to_AP_App_with_registered_email_ID_password_verify_the_functionality_of_login_button_error_values_for_not_registered_Email_id_and_correct_password()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).verify_Error_Values_For_Not_Registered_EmailId(AuthorizedPersonnelPageLoginLocators.notRegisteredEmailId, apPassword, apUrl);
        }
        [Test]
        public void IBC_007_113490_Login_to_AP_App_with_registered_email_ID_password_verify_the_functionality_of_error_popup()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).verify_the_functionality_of_error_popup(apEmailId, AuthorizedPersonnelPageLoginLocators.notRegisteredEmailId, apPassword, apUrl);
        }
        [Test]
        public void IBC_008_111789_AP_account_Logout_verify_the_display_of_logout_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).verify_the_display_of_profile_icon(apName);       
        }
        [Test]
        public void IBC_009_111790_AP_account_Logout_verify_the_functionality_of_logout()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
        }
        [Test]
        public void IBC_010_113124_AP_account_Logout_verify_the_functionality_of_logout_after_clicking_browser_back_button()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._authorizedPersonnelLoginPage(driver).ClickTheBrowserBackButton();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
        }
        [Test]
        public void IBC_011_113060_AP_account_Logout_verify_the_functionality_of_logout()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);           
            Pages._authorizedPersonnelLoginPage(driver).verify_The_Functionality_Of_Logout();           
        }
        [Test]
        public void IBC_012_110157_Reset_password_for_Customer_Admin_To_verify_the_Functionality_of_Cancel_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).clickOnForgotPassword();
            Pages._caResetPasswordPage(driver).clickOnCancelButton();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
        }
        [Test]
        public void IBC_013_110167_Reset_password_for_Customer_Admin_To_verify_the_display_of_UI_in_forgot_password_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).clickOnForgotPassword();
            Pages._caResetPasswordPage(driver).verify_the_display_of_UI_in_forgot_password_page();            
        }
        [Test]
        public void IBC_014_113495_Reset_password_for_Customer_Admin_To_verify_the_display_Verify_code_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).clickOnForgotPassword();
            Pages._caResetPasswordPage(driver).clickOnSendVerificationCode();
            Pages._caResetPasswordPage(driver).verify_the_display_verify_code_page(caEmailId);
        }
        [Test]
        public void IBC_015_110171_Reset_password_for_Customer_Admin_To_verify_the_Functionality_of_Cancel_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).clickOnForgotPassword();
            Pages._caResetPasswordPage(driver).clickOnSendVerificationCode();
            Pages._caResetPasswordPage(driver).clickOnCancelButton();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
        }
        [Test]
        public void IBC_016_113496_Security_Question_answer_during_AP_login_Verify_the_display_of_security_questions_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);            
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).verify_display_of_security_questions_page();          
        }
        [Test]
        public void IBC_017_113498_Security_Question_answer_during_AP_login_Verify_the_security_question_with_correct_answer()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelLoginPage(driver).verify_AP_Name(apName);
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._mainPage(driver).clickOnAuthorizedPersonnel();
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelLoginPage(driver).verify_AP_Name(apName);
        }
        [Test]
        public void IBC_018_113499_Security_Question_answer_during_AP_login_Verify_the_security_question_error_values()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._authorizedPersonnelLoginPage(driver).verify_security_question_Error_Values();         
         }
       
        [Test]
        public void IBC_020_113501_Security_Question_answer_during_AP_login_Verify_the_security_question_with_incorrect_and_correct_answer()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).gotoAPUrl(apUrl);
            Pages._authorizedPersonnelLoginPage(driver).EnterUsename(apEmailId);
            Pages._authorizedPersonnelLoginPage(driver).EnterPassword(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnLogin();
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._authorizedPersonnelLoginPage(driver).clickOnCloseButton();
            Pages._authorizedPersonnelLoginPage(driver).clearText(apPassword);
            Pages._authorizedPersonnelLoginPage(driver).AnswerTheSecurityQuestion(apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).clickOnContinue();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelLoginPage(driver).verify_AP_Name(apName);
        }
        [Test]
        public void IBC_021_113503_Customer_Admin_login_Security_Question_Validation_Verify_the_display_of_security_questions_page()
        {
            setTestData();          
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);           
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerLoginPage(driver).Verify_the_display_of_security_questions_page();
        }
        [Test]
        public void IBC_022_113504_Customer_Admin_login_Security_Question_Validation_Verify_the_functionality_of_security_questions_proceed_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerLoginPage(driver).AnswerTheSecurityQuestion(caSecurityAnswer);
            Pages._customerLoginPage(driver).clickOnProceedButton();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelLoginPage(driver).verify_AP_Name(caName);
            Pages._customerAdminPage(driver).clickOnLogout();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelLoginPage(driver).verify_AP_Name(caName);
        }
        [Test]
        public void IBC_023_110165_Customer_Admin_login_Security_Question_Validation_Verify_the_functionality_of_security_questions_cancel_button()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerLoginPage(driver).AnswerTheSecurityQuestion(caSecurityAnswer);
            Pages._customerLoginPage(driver).clickOnCancelButton();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
        }
        [Test]
        public void IBC_024_110166_Customer_Admin_login_Security_Question_Validation_Verify_the_functionality_of_back_button_in_security_questions()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerLoginPage(driver).AnswerTheSecurityQuestion(caSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).ClickTheBrowserBackButton();
            Pages._mainPage(driver).Verify_UI_MainLoginPage();
        }       
        [Test]
        public void IBC_026_110164_Customer_Admin_login_Security_Question_Validation_Verify_the_functionality_of_security_questions_proceed_button_First_Time()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerLoginPage(driver).AnswerTheSecurityQuestion(caSecurityAnswer);
            Pages._customerLoginPage(driver).clickOnProceedButton();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelLoginPage(driver).verify_AP_Name(caName);           
        }
        [Test]
        public void IBC_027_113552_Customer_Admin_login_Security_Question_Validation_Verify_the_functionality_of_security_questions_error_values()
        {
            setTestData();
            Pages._customerLoginPage(driver).goToCustomerLoginPage(caUrl);
            Pages._customerLoginPage(driver).EnterUsename(caEmailId);
            Pages._customerLoginPage(driver).EnterPassword(caPassword);
            Pages._customerLoginPage(driver).clickOnSignInButton();
            Pages._customerLoginPage(driver).AnswerTheSecurityQuestion(caPassword);
            Pages._customerLoginPage(driver).clickOnProceedButton();
            Pages._customerLoginPage(driver).Verify_security_question_error_values(caSecurityAnswer);
            Pages._customerAdminPage(driver).clickOnProfile();
        }
        [Test]
        public void IBC_028_111786_AP_homepage_location_filter_display_of_location_filter()
        {
            setTestData();          
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelLoginPage(driver).verify_display_of_location_filter();
            Pages._customerAdminPage(driver).ChangeLanguageToFrench();
            Pages._apLoginPageLocators(driver).readJsonFrenchData();
            Pages._authorizedPersonnelLoginPage(driver).verify_display_of_location_filter();
        }
        [Test]
        public void IBC_029_139433_Login_to_AP_App_with_registered_email_ID_password_Verify_the_functionality_of_login_after_login_as_CA()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._authorizedPersonnelLoginPage(driver).goToAPLoginPage(apUrl);
            Pages._mainPage(driver).verify_Unauthorized_Access_page();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._mainPageLocators(driver).readJsonFrenchData();
            Pages._mainPage(driver).verify_Unauthorized_Access_page();
        }
        [Test]
        public void IBC_030_111787_AP_homepage_location_filter_verify_the_functionality_of_location_filter()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).verify_functionality_of_LocationFilter();           
        }
    }
}
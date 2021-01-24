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

    public class IBC_App_Sprint07 : TestBase
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
        public string CA_FirstName { get; set; }
        public string CA_LastName { get; set; }

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
        static string ca_lastName;
        static string ca_fistName;

        public void setTestData()
        {

            try
            {
                string path1 = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                string path = path1 + Pages._mainPageLocators(driver).path;
                var jsonFile = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<IList<IBC_App_Sprint07>>(jsonFile);
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
                ca_lastName = jsonText.CA_LastName;
                ca_fistName = jsonText.CA_FirstName;
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
        public void IBC_001_136319_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_Otis_admin_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._mainPage(driver).otisChangeLanguageToFrench();
            Pages._mainPage(driver).verifyFrenchFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._mainPage(driver).verifyFrenchFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._mainPage(driver).verifyFrenchFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._mainPage(driver).verifyFrenchFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
        }
        [Test]
        public void IBC_002_136329_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_Otis_admin_call_log_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();

        }
        [Test]
        public void IBC_003_136331_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_customer_admin_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();


        }
        [Test]
        public void IBC_004_136332_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_Customer_admin_call_log_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._mainPage(driver).otisChangeLanguageToFrench();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._mainPage(driver).verifyFrenchFooter();
        }
        [Test]
        public void IBC_005_136339_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_Customer_admin_Manage_device_fcc_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._mainPage(driver).otisChangeLanguageToFrench();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._mainPage(driver).verifyFrenchFooter();
        }
        [Test]
        public void IBC_006_136333_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_Customer_admin_Mange_account_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickonManageAccount();
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._mainPage(driver).otisChangeLanguageToFrench();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._mainPage(driver).verifyFrenchFooter();
        }
        [Test]
        public void IBC_007_136346_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_AP_home_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._mainPage(driver).verifyFooter();
            Pages._mainPage(driver).clickOnLicense();
            Pages._mainPage(driver).VerifyLicenseInformation();
            Pages._mainPage(driver).otisChangeLanguageToFrench();
            Pages._mainPage(driver).VerifyLicenseInformation_French();
            Pages._mainPage(driver).verifyFrenchFooter();
        }
        [Test]
        public void IBC_008_136349_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_back_Button_is_removed_from_Otis_admin()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._otisAdminPage(driver).verify_Otis_admin_page_web_elements();
        }
        [Test]
        public void IBC_009_136350_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_back_Button_is_removed_from_homepage_in_customer_admin_page()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickonManageAccount();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._customerAdminPage(driver).verifyUIofCutomerDasboard();

        }
        [Test]
        public void IBC_010_136352_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_back_Button_is_removed_from_homepage_in_AP_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();

        }
        [Test]
        public void IBC_011_136407_EP_Device_details_for_Otis_Admin_verify_the_display_of_Otis_admin_FCC_Devices_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();
            Pages._mainPage(driver).ChangeLanguageToFrench();
            Pages._otisAdminFccdevicePageLocators(driver).readJsonFrenchData();
            Pages._otisAdminFccdevicePage(driver).verify_Manage_Device_Fcc_Page_elements();
        }
        [Test]
        public void IBC_012_136409_EP_Device_details_for_Otis_Admin_verify_the_functionality_of_Cancel_button_in_Otis_admin_FCC_Devices_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_cancel_button_functionality();
        }
        [Test]
        public void IBC_013_136411_EP_Device_details_for_Otis_Admin_verify_the_functionality_of_search_button_in_Otis_admin_FCC_Devices_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_the_functionality_of_search_button();
        }
        [Test]
        public void IBC_014_139627_Add_AP_associate_units_at_the_same_time_verify_the_functionality_elevator_dashboard_after_creating_new_AP()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).create_new_AP_with_All_unit_allocation();
            Pages._customerAdminPage(driver).verify_functionality_of_dashboard_after_refresh();
            Pages._customerAdminPage(driver).verifyRowIsDeletedWithoutAdding();
        }
        [Test]
        public void IBC_015_139628_Add_AP_associate_units_at_the_same_time_verify_the_functionality_of_Add_new_AP_without_unit_allocation()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).create_new_AP_without_unit_allocation();
            Pages._customerAdminPage(driver).verifyRowIsDeletedWithoutAdding();
        }
        [Test]
        public void IBC_016_139631_Add_AP_associate_units_at_the_same_time_verify_the_functionality_of_Add_new_AP_with_unit_allocation()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).create_new_AP_with_All_unit_allocation();
            Pages._customerAdminPage(driver).verifyRowIsDeletedWithoutAdding();
        }
        [Test]
        public void IBC_017_139632_Add_AP_associate_units_at_the_same_time_verify_the_functionality_of_unit_allocation_after_creating_new_AP()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).create_new_AP_without_unit_allocation();
            Pages._customerAdminPage(driver).verdify_new_row_added();
            Pages._customerAdminPage(driver).clickOnEditIcon();
            Pages._customerAdminPage(driver).Assign_all_units();
            Pages._customerAdminPage(driver).verifyRowIsDeletedWithoutAdding();
        }
        [Test]
        public void IBC_018_139866_Missed_call_in_call_logs_OA_verify_display_of_missed_call_icon_in_call_logs_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnCallLog();
            Pages._otisAdminCallLogsPage(driver).verify_missed_call_icon();
        }
        [Test]
        public void IBC_019_139868_Missed_call_in_call_logs_OA_verify_display_of_missed_call_information()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            if (Pages._apPageLocators(driver).listOfunits.Count > 0)
            {
                string buildingId = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).buildingid);
                string unitId = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).unitOne);
                unitId = Pages._authorizedPersonnelPage(driver).getTheUnitId(unitId);
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
                string breakDownReason = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).breakdownReason);
                breakDownReason = Pages._authorizedPersonnelPage(driver).getBreakDownReason(breakDownReason);
                Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
                Pages._authorizedPersonnelPage(driver).clickOnProfile();
                Pages._authorizedPersonnelPage(driver).clickOnlogout();
                Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
                Pages._customerAdminPage(driver).clickOnProfile();
                Pages._otisAdminPage(driver).clickOnCallLog();
                Pages._otisAdminCallLogsPage(driver).verify_display_of_missed_call_information(ca_fistName, ca_lastName, buildingId, unitId,breakDownReason);
            }
        }
        [Test]
        public void IBC_020_141383_Add_AP_associate_units_at_the_same_time_verify_the_functionality_of_cancel_button_after_assigning_units()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).create_new_AP_without_unit_allocation();
            Pages._customerAdminPage(driver).verdify_new_row_added();
            Pages._customerAdminPage(driver).clickOnEditIcon();
            Pages._customerAdminPage(driver).Assign_all_units();
            Pages._customerAdminPage(driver).verifyRowIsDeletedWithoutAdding();
        }
        [Test]
        public void IBC_021_141384_Add_AP_associate_units_at_the_same_time_verify_the_functionality_of_cancel_button_before_assigning_units()
        {
            setTestData();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
            Pages._customerAdminPage(driver).clickOnAddAP();
            Pages._customerAdminPage(driver).enterFirstName(CustomerAdminPageLocators.firstNameTextBoxValue);
            Pages._customerAdminPage(driver).enterLastName(CustomerAdminPageLocators.lastNameTextBoxText);
            Pages._customerAdminPage(driver).enterEmailId(CustomerAdminPageLocators.emailTextBoxValue);
            Pages._customerAdminPage(driver).clickOnChainIcon();
            Pages._customerAdminPage(driver).Assign_all_units_to_AP();
            Pages._customerAdminPage(driver).clickOnCancelButton();
            Pages._customerAdminPage(driver).clickOnCreateButton();
            Pages._customerAdminPage(driver).verify_successMessage(CustomerAdminPageLocators.firstNameTextBoxValue, CustomerAdminPageLocators.emailTextBoxValue);
            Pages._customerAdminPage(driver).verifyRowIsDeletedWithoutAdding();
        }
        [Test]
        public void IBC_022_141503_Missed_call_in_call_logs_verify_display_of_missed_call_information()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            if (Pages._apPageLocators(driver).listOfunits.Count > 0)
            {
                string buildingId = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).buildingid);
                string unitId = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).unitOne);
                unitId = Pages._authorizedPersonnelPage(driver).getTheUnitId(unitId);
                Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
                string breakDownReason = Pages._action(driver).getText(driver, Pages._apPageLocators(driver).breakdownReason);
                breakDownReason = Pages._authorizedPersonnelPage(driver).getBreakDownReason(breakDownReason);
                Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
                Pages._authorizedPersonnelPage(driver).clickOnProfile();
                Pages._authorizedPersonnelPage(driver).clickOnlogout();
                Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer, caUrl);
                Pages._customerAdminPage(driver).clickOnProfile();
                Pages._customerAdminPage(driver).clickOnCallLog();
                Pages._customerAdminCallLogsPage(driver).verify_display_of_missed_call_information(ca_fistName, ca_lastName, buildingId, unitId, breakDownReason);
            }
        }
        [Test]
        public void IBC_023_155068_Missed_call_in_call_logs_verify_display_of_missed_call_icon_in_call_logs_screen()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._authorizedPersonnelPage(driver).Initiate_call_from_car(simulatorLink);
            Pages._authorizedPersonnelPage(driver).verify_ring_for_45_sec();
            Pages._authorizedPersonnelPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnlogout();
            Pages._customerLoginPage(driver).Login(caEmailId, caPassword, caSecurityAnswer,caUrl);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._customerAdminPage(driver).clickOnCallLog();
            Pages._customerAdminCallLogsPage(driver).verify_missed_call_icon();
        }
        [Test]
        public void IBC_024_141543_Updating_Header_Footer_for_all_the_screens_of_all_the_users_Verify_display_of_header_and_footer_in_AP_Manage_account_page()
        {
            setTestData();
            Pages._authorizedPersonnelLoginPage(driver).login(apEmailId, apPassword, apUrl, apSecurityAnswer);
            Pages._customerAdminPage(driver).clickOnProfile();
            Pages._authorizedPersonnelPage(driver).clickOnMangeAccount();
            Pages._mainPage(driver).clickOnOtisImage();
            Pages._authorizedPersonnelPage(driver).verify_display_of_location_filter();
        }
        [Test]
        public void IBC_025_163468_EP_Device_details_for_Otis_Admin_verify_the_functionality_of_sorting_button_in_Otis_admin_FCC_Devices_page()
        {
            setTestData();
            Pages._otisAdminLoginPage(driver).Login(otisEmailId, otisPassword, otisUrl);
            Pages._otisAdminPage(driver).clickOnProfile();
            Pages._otisAdminPage(driver).clickOnFccDevice();
            Pages._otisAdminFccdevicePage(driver).verify_functionality_of_of_sorting_of_building_ID();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SysPro.Core.Helper.Enum
{
    /// <summary>
    /// All Constants
    /// </summary>
    /// <createdby>KietNQ</createdby>
    /// <modifiedby></modifiedby>
    /// <notes></notes>
    public partial class Constants
    {
        #region phone format
        public const string Mask_Us = "+1(###)###-####";
        public const int Mask_ID_US = 292;
        #endregion
        #region Language Code

        public const string Lang_En = "en";
        public const string Lang_Vi = "vi";

        #endregion

        #region Module Name

        public const string ModuleName_Role = "Role";
        public const string ModuleName_Group = "Group";
        public const string ModuleName_Profile = "Profile";
        public const string ModuleName_User = "User";
        public const string ModuleName_Company = "Company";
        public const string ModuleName_Address = "Address";

        public const string ModuleName_Account = "Account";
        public const string ModuleName_Contact = "Contact";
        public const string ModuleName_ServiceTicket = "ServiceTicket";
        public const string ModuleName_Opportunity = "Opportunity";
        public const string ModuleName_Campaign = "Campaign";
        public const string ModuleName_Report = "Report";
        public const string ModuleName_Calendar = "Calendar";
        public const string ModuleName_Task = "Task";
        public const string ModuleName_Event = "Event";
        #endregion

        #region Module ID

        public const int ModuleIdContact = 1;
        public const int ModuleIdAccount = 2;
        public const int ModuleIdServiceTicket = 3;
        public const int ModuleIdOpportunity = 4;
        public const int ModuleIdCampaign = 5;
        public const int ModuleIdReport = 6;
        public const int ModuleIdDashboard = 7;
        public const int ModuleIdCalendar = 8;
        public const int ModuleIdTask = 9;
        public const int ModuleIdEvent = 10;
        #endregion

        #region Common Message format {module name}

        public const string Message_InsertSuccess = "Message_InsertSuccess";
        public const string Message_UpdateSuccess = "Message_UpdateSuccess";
        public const string Message_DeleteSuccess = "Message_DeleteSuccess";
        public const string Message_InsertUnSuccess = "Message_InsertUnSuccess";
        public const string Message_UpdateUnSuccess = "Message_UpdateUnSuccess";
        public const string Message_DeleteUnSuccess = "Message_DeleteUnSuccess";
        public const string Message_AlreadyExisted = "Message_AlreadyExisted";
        public const string Message_NotExisted = "Message_NotExisted";
        public const string Message_NoData = "Message_NoData";
        public const string Message_PleaseChoose = "Message_PleaseChoose";
        public const string Message_Validate_Required = "Validate_Required";

        #endregion

        #region PickListType

        //public const int PickListType_Address = 6;

        #endregion

        #region Activity Timeline

        public const int ActivityLogACall = 1;
        public const int ActivityLogAnEmail = 2;
        public const int ActivitySendAnEmail = 3;
        public const int ActivityTask = 4;
        public const int ActivityEvent = 5;
        public const int ActivityCampaignDate = 6;
        public const int ActivityContactImport = 7;
        public const int ActivityStep = 8;
        public const int ActivityStepDone = 81;
        public const int ActivityStepUndone = 80;

        #endregion

        #region Avatar default

        public const string AvatarDefault = "/Assets/no-avatar.jpg";

        #endregion

        #region Curency
        public const string DefaultCurency = "Default_Curency";
        public const string CurencyBillion = "Billion";
        public const string CurencyMillion = "Million";
        public const string CurencyThousand = "Thousand";
        public const string CurencyBillions = "Billions";
        public const string CurencyMillions = "Millions";
        public const string CurencyThousands = "Thousands";
        #endregion

        #region Export Title

        public const string TEXT_DATES = "TEXT_DATES";
        public const string TEXT_LABELS = "TEXT_LABELS";
        public const string TEXT_CAMPAIGN_DATES = "TEXT_CAMPAIGN_DATES";
        public const string TEXT_CAMPAIGN_RELATED = "TEXT_CAMPAIGN_RELATED";
        public const string TEXT_NOT_AVAILABLE = "TEXT_NOT_AVAILABLE";
        public const string TEXT_ACCOUNT = "TEXT_ACCOUNT";
        public const string TEXT_ACCOUNTS = "TEXT_ACCOUNTS";
        public const string TEXT_ACCOUNT_NO = "TEXT_ACCOUNT_NO";
        public const string TEXT_ACCOUNT_NAME = "TEXT_ACCOUNT_NAME";
        public const string TEXT_ACCOUNT_TYPE = "TEXT_ACCOUNT_TYPE";
        public const string TEXT_CAMPAIGN_NAME = "TEXT_CAMPAIGN_NAME";
        public const string TEXT_ADDRESS = "TEXT_ADDRESS";
        public const string TEXT_ADDRESSES = "TEXT_ADDRESSES";
        public const string TEXT_PHONE_NUMBER = "TEXT_PHONE_NUMBER";
        public const string TEXT_PHONE_NUMBERS = "TEXT_PHONE_NUMBERS";
        public const string TEXT_WEBSITE = "TEXT_WEBSITE";
        public const string TEXT_STOCK = "TEXT_STOCK";
        public const string TEXT_ANNUAL_REVENUA = "TEXT_ANNUAL_REVENUA";
        public const string TEXT_EMPLOYEES = "TEXT_EMPLOYEES";
        public const string TEXT_DUNS = "TEXT_DUNS";
        public const string TEXT_SIC = "TEXT_SIC";
        public const string TEXT_TYPE = "TEXT_TYPE";
        public const string TEXT_EXTENSION = "TEXT_EXTENSION";
        public const string TEXT_RATING = "TEXT_RATING";
        public const string TEXT_PRIORITY = "TEXT_PRIORITY";
        public const string TEXT_INDUSTRY = "TEXT_INDUSTRY";
        public const string TEXT_DESCRIPTION = "TEXT_DESCRIPTION";
        public const string TEXT_NOTES = "TEXT_NOTES";
        public const string TEXT_DATE = "TEXT_DATE";
        public const string TEXT_NOTE = "TEXT_NOTE";
        public const string TEXT_CREATEDBY = "TEXT_CREATEDBY";
        public const string TEXT_SUBJECT = "TEXT_SUBJECT";
        public const string TEXT_ACTIVITY_TIMELINE = "ActivityTimeLine_Title";
        public const string TEXT_CONTACTS = "TEXT_CONTACTS";
        public const string TEXT_CONTACT = "TEXT_CONTACT";
        public const string TEXT_CONTACT_NAME = "TEXT_CONTACT_NAME";
        public const string TEXT_NAME = "TEXT_NAME";
        public const string TEXT_PRIMARY = "TEXT_PRIMARY";
        public const string TEXT_EMAIL = "TEXT_EMAIL";
        public const string TEXT_PHONE = "TEXT_PHONE";
        public const string TEXT_TITLE = "TEXT_TITLE";
        public const string TEXT_YES = "TEXT_YES";
        public const string TEXT_NO = "TEXT_NO";
        public const string TEXT_OPPORTUNITIES = "TEXT_OPPORTUNITIES";
        public const string TEXT_STAGE = "TEXT_STAGE";
        public const string TEXT_AMOUNT = "TEXT_AMOUNT";
        public const string TEXT_CLOSE_DATE = "TEXT_CLOSE_DATE";
        public const string TEXT_TASK = "TEXT_TASK";
        public const string TEXT_TASKS = "TEXT_TASKS";
        public const string TEXT_EVENT = "TEXT_EVENT";
        public const string TEXT_EVENTS = "TEXT_EVENTS";
        public const string TEXT_RELATED_ACCOUNTS = "TEXT_RELATED_ACCOUNTS";
        public const string TEXT_RELATED_CAMPAIGNS = "TEXT_RELATED_CAMPAIGNS";
        public const string TEXT_RECORD_DETAILS = "TEXT_RECORD_DETAILS";
        public const string TEXT_ACCOUNT_OWNER = "TEXT_ACCOUNT_OWNER";
        public const string TEXT_ACCOUNT_OWNER_HINT = "TEXT_ACCOUNT_OWNER_HINT";
        public const string TEXT_WEBSITE_ADDRESS = "TEXT_WEBSITE_ADDRESS";
        public const string TEXT_ACCOUNT_OWNER_SALESPERSON = "TEXT_ACCOUNT_OWNER_SALESPERSON";
        public const string TEXT_CONTACT_OWNER = "TEXT_CONTACT_OWNER";
        public const string TEXT_OPPORTUNITY_OWNER = "TEXT_OPPORTUNITY_OWNER";
        public const string TEXT_CAMPAIGN_OWNER = "TEXT_CAMPAIGN_OWNER";
        public const string TEXT_LAST_MODIFED_BY = "TEXT_LAST_MODIFED_BY";
        public const string TEXT_ACTIVE = "TEXT_ACTIVE";
        public const string TEXT_BIRTHDAY = "TEXT_BIRTHDAY";
        public const string TEXT_FACEBOOK_LINK = "TEXT_FACEBOOK_LINK";
        public const string TEXT_TWITTER_LINK = "TEXT_TWITTER_LINK";
        public const string TEXT_LINKEDIN_LINK = "TEXT_LINKEDIN_LINK";
        public const string TEXT_GOOGLEPLUS_LINK = "TEXT_GOOGLEPLUS_LINK";
        public const string TEXT_ADDITIONAL = "TEXT_ADDITIONAL";
        public const string TEXT_LEAD_SOURCE = "Contact_ContactSource";
        public const string TEXT_CONTACT_TYPE = "Contact_ContactType";
        public const string TEXT_OPPORTUNITY_NAME = "Opportunity_Name";
        public const string TEXT_OPPORTUNITY_NUMBER = "Opportunity_Number";
        public const string TEXT_OPPORTUNITY_ASSIGNEDUSER = "Opportunity_AssignedUserId";
        public const string TEXT_ASSISTANTS = "TEXT_ASSISTANTS";
        public const string TEXT_RECORD_SECURITY = "TEXT_RECORD_SECURITY";
        public const string TEXT_STREET1 = "TEXT_STREET1";
        public const string TEXT_STREET2 = "TEXT_STREET2";
        public const string TEXT_STREET3 = "TEXT_STREET3";
        public const string TEXT_CITY = "TEXT_CITY";
        public const string TEXT_STATE = "TEXT_STATE";
        public const string TEXT_ZIP = "TEXT_ZIP";
        public const string TEXT_COUNTY = "TEXT_COUNTY";
        public const string TEXT_COUNTRY = "TEXT_COUNTRY";
        public const string TEXT_DUE_DATE = "TEXT_DUE_DATE";
        public const string TEXT_TAGS = "TEXT_TAGS";
        public const string TEXT_PRODUCT = "TEXT_PRODUCT";
        public const string TEXT_STATUS = "TEXT_STATUS";
        public const string TEXT_SERVICE_TICKETS = "TEXT_SERVICE_TICKETS";
        public const string TEXT_SERVICE_TICKET_NAME = "TEXT_SERVICE_TICKET_NAME";
        public const string TEXT_AVATAR = "TEXT_AVATAR";
        public const string TEXT_DEPARTMENT = "TEXT_DEPARTMENT";
        public const string TEXT_REFERENCE = "TEXT_REFERENCE";
        public const string TEXT_SEVERITY = "TEXT_SEVERITY";
        public const string TEXT_TRACKING = "TEXT_TRACKING";
        public const string TEXT_CATEGORIZATION = "TEXT_CATEGORIZATION";
        public const string TEXT_DATETIME_OPENED = "TEXT_DATETIME_OPENED";
        public const string TEXT_DATETIME_CLOSED = "TEXT_DATETIME_CLOSED";
        public const string TEXT_RESPONSE_BY = "TEXT_RESPONSE_BY";
        public const string TEXT_TIME_SPENT = "TEXT_TIME_SPENT";
        public const string TEXT_CATEGORY = "TEXT_CATEGORY";
        public const string TEXT_PROBLEM = "TEXT_PROBLEM";
        public const string TEXT_START_DATE = "TEXT_START_DATE";
        public const string TEXT_END_DATE = "TEXT_END_DATE";
        public const string TEXT_CAMPAIGNS = "TEXT_CAMPAIGNS";
        public const string TEXT_CAMPAIGN = "TEXT_CAMPAIGN";
        public const string TEXT_BUDGETED_COST = "TEXT_BUDGETED_COST";
        public const string TEXT_ACTUAL_COST = "TEXT_ACTUAL_COST";
        public const string TEXT_EXPECTED_REVENUE = "TEXT_EXPECTED_REVENUE";
        public const string TEXT_EXPECTED_RESPONSE = "TEXT_EXPECTED_RESPONSE";
        public const string TEXT_PROBABILITY = "TEXT_PROBABILITY";
        public const string TEXT_SECONDARY = "TEXT_SECONDARY";
        public const string TEXT_CLOSED_LOST = "TEXT_CLOSED_LOST";
        public const string TEXT_STEP = "TEXT_STEP";
        public const string TEXT_CONTACT_IMPORTED_LOG = "TEXT_CONTACT_IMPORTED_LOG";
        public const string TEXT_SKIPPED = "TEXT_SKIPPED";
        public const string TEXT_JOB_TITLE = "TEXT_JOB_TITLE";
        public const string TEXT_EMAIL_ADDRESS = "TEXT_EMAIL_ADDRESS";
        public const string TEXT_OPPORTUNITY_TYPE = "TEXT_OPPORTUNITY_TYPE";
        public const string TEXT_CREATED_DATE = "TEXT_CREATED_DATE";
        public const string TEXT_CHANCE_TO_CLOSE = "TEXT_CHANCE_TO_CLOSE";
        public const string TEXT_TOTAL_VALUE = "TEXT_TOTAL_VALUE";
        public const string TEXT_CAMPAIGN_TYPE = "TEXT_CAMPAIGN_TYPE";
        public const string TEXT_CAMPAIGN_MANAGER = "TEXT_CAMPAIGN_MANAGER";
        public const string TEXT_TICKET_NUMBER = "TEXT_TICKET_NUMBER";
        public const string TEXT_TICKET_TYPE = "TEXT_TICKET_TYPE";
        public const string TEXT_ASSIGNED_TO = "TEXT_ASSIGNED_TO";
        public const string TEXT_SERIAL_LOT = "TEXT_SERIAL_LOT";
        public const string TEXT_RELATED_ACCOUNT = "TEXT_RELATED_ACCOUNT";
        public const string TEXT_CONTRACT_NO = "TEXT_CONTRACT_NO";
        public const string TEXT_REPORTED_TYPE = "TEXT_REPORTED_TYPE";
        public const string TEXT_PROBLEM_DESCRIPTION = "TEXT_PROBLEM_DESCRIPTION";
        public const string TEXT_RESOLUTION_DESCRIPTION = "TEXT_RESOLUTION_DESCRIPTION";
        public const string TEXT_RESPOND_ON = "TEXT_RESPOND_ON";
        public const string TEXT_SERVICE_TICKET_TYPE = "TEXT_SERVICE_TICKET_TYPE";
        public const string TEXT_PROBLEM_CLASS = "TEXT_PROBLEM_CLASS";
        public const string TEXT_PROBLEM_TYPE = "TEXT_PROBLEM_TYPE";
        public const string TEXT_PROBLEM_SUBTYPE = "TEXT_PROBLEM_SUBTYPE";
        public const string TEXT_RESOLUTION = "TEXT_RESOLUTION";
        public const string TEXT_RESOLUTION_TYPE = "TEXT_RESOLUTION_TYPE";
        public const string TEXT_CUSTOMER_FEEDBACK = "TEXT_CUSTOMER_FEEDBACK";
        public const string TEXT_RMA_NUMBER = "TEXT_RMA_NUMBER";
        public const string TEXT_TICKET = "TEXT_TICKET";
        public const string TEXT_CREATED_TIME = "ActivityTimeLine_Col_CreatedTime";
        public const string TEXT_INVOICE_TERM = "Invoice Term";
        public const string TEXT_PRIMARY_INFORMATION = "Primary Information";
        public const string TEXT_SYSPRO = "Syspro";
        public const string TEXT_HIGHEST_BALANCE = "Highest Balance";
        public const string TEXT_DATE_LAST_SALE = "Date of Last Sale";
        public const string TEXT_SPECIAL_INSTRUCTIONS = "Special Instructions";
        public const string TEXT_DATE_CREATE = "Date Create";
        public const string TEXT_STATE_CODE = "State Code";
        public const string TEXT_PRICE_CODE = "Price Code";
        public const string TEXT_UDF_10 = "UDF 10";
        public const string TEXT_HIGHESTST_OVERDUE_INVOICE = "Highestst Overdue Invoice";
        public const string TEXT_OUTSTANDING_ORDER_VALUE = "Outstanding Order Value";
        public const string TEXT_RELEASED_ORDER_VALUE = "Released Order Value";
        public const string TEXT_UDF_1 = "UDF 1";
        public const string TEXT_UDF_2 = "UDF 2";
        public const string TEXT_EXPEMPTION_NUMBER = "Expemption Number";
        public const string TEXT_RESALE_NUMBER = "Resale Number";
        public const string TEXT_INVOICE_TERMS = "TEXT_INVOICE_TERMS";
        public const string TEXT_PRIMARY_INFO = "TEXT_PRIMARY_INFO";
        public const string TEXT_ACCOUNT_NUMBER = "TEXT_ACCOUNT_NUMBER";
        

        public const string ACTIVITYTIMELINE_TASK = "ActivityTimeLine_Task";
        public const string ACTIVITYTIMELINE_EVENT = "ActivityTimeLine_Event";
        public const string ACTIVITYTIMELINE_LOGACALL = "ActivityTimeLine_LogACall";
        public const string ACTIVITYTIMELINE_LOGANEMAIL = "ActivityTimeLine_LogAnEmail";
        public const string ACTIVITYTIMELINE_SENDANEMAIL = "ActivityTimeLine_SendAnEmail";
        public const string ACTIVITYTIMELINE_CAMPAIGNDATE = "ActivityTimeLine_CampaignDate";
        public const string ACTIVITYTIMELINE_CONTACTIMPORT = "ActivityTimeLine_ContactImport";
        public const string ACTIVITYTIMELINE_STEP = "ActivityTimeLine_Step";
        public const string ACTIVITYTIMELINE_STEP_UNDONE = "ActivityTimeLine_Step_Undone";

        public const string SORT_DIRECTION_ASC = "Asc";
        public const string SORT_DIRECTION_DESC = "Desc";
        public const string EXPORT_PDF = "EXPORT_PDF";
        public const string EXPORT_EXCEL = "EXPORT_EXCEL";
        public const string EXPORT_PRINTER = "EXPORT_PRINTER";

        public const string BTN_EDIT = "Btn_Edit";
        public const string BTN_ADD = "Btn_Add";
        public const string BTN_DELETE = "Btn_Delete";
        public const string BTN_MORE = "Btn_More";
        public const string BTN_CANCEL = "Btn_Cancel";
        public const string BTN_SAVE = "Btn_Save";
        public const string BTN_SAVE_AND_NEW = "Btn_SaveAndNew";
        public const string BTN_SAVE_AND_OPEN = "Btn_SaveAndOpen";
        public const string BTN_DUPLICATE = "Btn_Duplicate";
        public const string BTN_SEARCH = "Btn_Search";
        public const string BTN_SEE_MORE = "Btn_SeeMore";


        public const string CONTACT_ADDITIONAL = "Contact_Additional";
        public const string CONTACT_CONTACTSOURCE = "Contact_ContactSource";
        public const string CONTACT_CONTACTTYPE = "Contact_ContactType";
        
        
        #endregion

        #region DATE FORMAT
        public const string FORMAT_MMDDYYYY = "MM/dd/yyyy";
        public const string FORMAT_MMDDYYYY_HHMM = "MM/dd/yyyy HH:mm";
        public const string FORMAT_MMDDYYYY_HHMM_TT = "MM/dd/yyyy h:mm tt";

        #endregion

        #region Define default string

        public const string DEFAULT_EMPTY = " ";// "N/A";
        #endregion

        #region reminder
        public const int Years = 7;
        public const int Months = 6;
        public const int Days = 1;
        public const int Hours = 3;
        public const int Minutes = 4;
        public const int Second = 5;
        public const int Weeks = 2;

        public const int ReminderModuleTask = 1;
        public const int ReminderModuleEvent = 2;

        public const int ReminderViewed = 1;
        public const int ReminderPending = 2;
        #endregion


        #region

        public const int CampaignRelationship_Parent = 1;
        public const int CampaignRelationship_Childrent = 2;

        #endregion

        #region Language Code

        public const string LABEL_CURRENT_PASSWORD = "Label_CurrentPassword";

        public const string LABEL_NEW_PASSWORD = "Label_NewPassword";

        public const string LABEL_CONFIRM_PASSWORD = "Label_ConfirmPassword";

        public const string LABEL_CURRENT_PASS_NOT_EXACT = "Label_CurrentPassNotMatch";

        public const string PASS_NOT_MATCH = "Label_PassNotMatch";

        public const string PASS_AT_LEAST = "Label_PasswordAtLeast";

        public const string LABEL_CANCEL = "Label_Cancel";

        public const string LABEL_SAVE = "Label_Save";

        public const string LABEL_REQUIRED = "Validate_Required";

        public const string LABEL_PASSWORD = "Label_Password";

        public const string LABEL_PASSWORD_CHANGE_SUCCESS = "Label_PasswordChangeSucess";

        public const string LABEL_PASSWORD_CHANGE_UNSUCCESS = "Label_PasswordChangeUnSucess";

        #endregion

        #region Grid Key Name

        public const string GridAccountList = "Account_List";
        public const string GridContactList = "Contact_List";
        public const string GridServiceTicketList = "ServiceTicket_List";
        public const string GridOpportunityList = "Opportunity_List";
        public const string GridCampaignList = "Campaign_List";

        #endregion

        #region event
        public const int EventAllFollowing = 1;
        public const int EventAllSeries = 2;
        public const int RepeatDaily = 1;
        public const int RepeatWeekly = 2;
        public const int RepeatMonthly = 3;
        public const int RepeatYearly = 4;
        #endregion

    }
}
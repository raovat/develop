using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysPro.Core.Helper.Enum
{
	public enum PickListTypeEnum
	{
		
		//Contact
		ContactAddressType = 9,
		ContactPhoneType = 10,
		ContactPriority = 11,
		ContactStatus = 12,
		ContactPrefix = 31,
		ContactSuffix = 32,
		ContactResult = 33,
        ContactSource = 44,
        ContactType = 45,
        ContactDepartment = 46,
        ContactTitle = 47,
		//Account
		AccountType = 1,
		AccountRating = 2,
		AccountPriority = 3,
		AccountIndustry = 4,
		AccountStatus = 5,
		AccountAddressType = 6,
		AccountPhoneType = 7,
		AccountRelatedType = 8,
		AccountResult = 34,


		//Service ticket
        ServiceTicketType = 15,
		ServiceTicketStatus = 13,
        ServiceTicketReportedType = 38,
		ServiceTicketPrioriry = 14,
		ServiceTicketSeverity = 16,
        ServiceTicketProblemClass = 39,
        ServiceTicketProblemType = 40,
        ServiceTicketProblemSubType = 41,
        ServiceTicketResolutionType = 42,
        ServiceTicketCustomerFeedback = 43,
		ServiceTicketAddressType = 17,
		ServiceTicketPhoneType = 18,
		ServiceTicketTrackingUnit = 19,
		ServiceTicketResult = 35,

		 // Opportunity
		OpportunityType = 20,
		OpportunityLeadSource = 21,
		OpportunityPhoneType = 26,
		OpportunityAddressType = 27,
		OpportunityStatus = 28,
		OpportunityPrioriry = 29,
		OpportunityResult = 36,

		// Campaign
		CampaignType = 22,
		CampaignStatus = 23,
		CampaignPhoneType = 24,
		CampaignAddressType = 25,
		CampaignPrioriry = 30,
		CampaignResult = 37,
        // Calendar
        CalendarType = 48,
        CalendarLocation = 49,
		CalendarPrioriry = 50,
		CalendarShowas = 51,

        // Task
        TaskPriority = 52
	}

	public enum RelatedRelationAccountEnum
	{
		Parent = 1,
		Subsidiary = 2,
	}

	public enum RelatedCampaignType
	{
		Parent = 1,
		Child = 2
	}

	public enum OpportunityCampaignType
	{
		Primary = 1,
		Secondary = 2
	}
}

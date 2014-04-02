namespace LibCore.Helper.Session
{
    public class UserSession
    {
        /// <summary>
        /// User ID in Tenant
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User ID in CRM
        /// </summary>
        public int SSOId { get; set; }

        /// <summary>
        /// User Display Name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// User Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Current Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Current Company Schema
        /// </summary>
        public string CurrentSchema { get; set; }

        /// <summary>
        /// Current Company ID
        /// </summary>
        public int CurrentCompanyId { get; set; }

        /// <summary>
        /// Current User Avatar 
        /// </summary>
        public string Avartar { get; set; }
    }
}

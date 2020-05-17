using SammakEnterprise.Core.Persistence.Util;

namespace SammakEnterprise.JobSearch.Middle.Common
{
    public class Utilities
    {
        public static string DateFormat = "MM/dd/yyyy";

        public static string DefaultUser()
        {
            return Config.GetDefaultUser();
        }

    }
}

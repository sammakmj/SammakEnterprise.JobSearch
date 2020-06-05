using SammakEnterprise.Core.Common.EnumDefinitions;

namespace SammakEnterprise.JobSearch.Middle.Services.Shared.Impl
{
    /// <summary>
    /// The service for enumerations
    /// </summary>
    public class EnumService : EnumProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string PlatformName()
        {
            return "JobSearch";
        }
    }

    /// <summary>
    /// Settings class (static)
    /// </summary>
    public static class EnumLinkSettings
    {
        /// <summary>
        /// 
        /// </summary>
        public const bool IncludeNestedEnumTypesInLinks = true;
    }
}

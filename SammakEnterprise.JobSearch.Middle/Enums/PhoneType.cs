using System.ComponentModel.DataAnnotations;

namespace SammakEnterprise.JobSearch.Middle.Enums
{
    /// <summary>
    /// Enum define for PhoneType
    /// </summary>
    public enum PhoneType
    {
        [Display(Name = "Home", Description = "Home Phone")]
        Home,

        [Display(Name = "Office", Description = "Office Phone")]
        Office,

        [Display(Name = "Mobile", Description = "Mobile Phone")]
        Mobile,

    }
}

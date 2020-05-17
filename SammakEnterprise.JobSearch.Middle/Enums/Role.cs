using System.ComponentModel.DataAnnotations;

namespace SammakEnterprise.JobSearch.Middle.Enums
{
    /// <summary>
    /// Enum define for employee role
    /// </summary>
    public enum Role
    {
        [Display(Name = "ItManager", Description = "TBD")]
        ItManager,

        [Display(Name = "HiringManager", Description = "TBD")]
        HiringManager,

        [Display(Name = "PrincipalDeveloper", Description = "TBD")]
        PrincipalDeveloper,

        [Display(Name = "PrincipalEngineer", Description = "TBD")]
        PrincipalEngineer,

        [Display(Name = "SeniorDeveloper", Description = "TBD")]
        SeniorDeveloper,

        [Display(Name = "Developer", Description = "TBD")]
        Developer,

        [Display(Name = "ScrumMaster", Description = "TBD")]
        ScrumMaster,

        [Display(Name = "Recruiter", Description = "TBD")]
        Recruiter,

        [Display(Name = "ProgramManager", Description = "TBD")]
        ProgramManager,

        //[Display(Name = "", Description = "TBD")]
        //,

        //[Display(Name = "", Description = "TBD")]
        //,

    }
}

using System.ComponentModel.DataAnnotations;

namespace SammakEnterprise.JobSearch.Middle.Enums
{
    /// <summary>
    /// Enum define for employee role
    /// </summary>
    public enum CompanyType
    {
        [Display(Name = "IT", Description = "TBD")]
        IT,

        [Display(Name = "EmploymentAgency", Description = "TBD")]
        EmploymentAgency,

        [Display(Name = "ContractingFirm", Description = "TBD")]
        ContractingFirm,

        [Display(Name = "ConsultingFirm", Description = "TBD")]
        ConsultingFirm,

        [Display(Name = "Financial", Description = "TBD")]
        Financial,

        [Display(Name = "Pharmaceutical", Description = "TBD")]
        Pharmaceutical,

        [Display(Name = "HealthCare", Description = "TBD")]
        HealthCare,

        [Display(Name = "Medical", Description = "TBD")]
        Medical,

        [Display(Name = "", Description = "TBD")]
        Marketing,

        [Display(Name = "Clinical", Description = "TBD")]
        Clinical,

    }
}

using System.ComponentModel.DataAnnotations;

namespace SammakEnterprise.JobSearch.Middle.JobSearchAccess.Enums
{
    public enum ApproachType
    {
        [Display(Name = "Un-Specified", Description = "Un-Specified Approach")]
        UnSpecified,

        [Display(Name = "Approached", Description = "Direct Approach by Recruiter/HR/Manager")]
        Approached,

        [Display(Name = "CarrierBuilder", Description = "TBD")]
        CarrierBuilder,

        [Display(Name = "TPNG", Description = "TBD")]
        Tpng,

        [Display(Name = "JobCircle", Description = "TBD")]
        JobCircle,

        [Display(Name = "Dice", Description = "TBD")]
        Dice,

        [Display(Name = "Monster", Description = "TBD")]
        Monster,

        [Display(Name = "MyApproach", Description = "My Approach")]
        MyApproach,

        [Display(Name = "ViaRecruiter", Description = "Via Recruiter")]
        ViaRecruiter,

        [Display(Name = "LinkedIn", Description = "TBD")]
        LinkedIn,

    }
}



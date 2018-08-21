using System;





namespace SamProject.Models
{





    public enum Specialty
    {
        Developer = 0,
        Architect = 1,
        HtmlCoder = 2,
        Pm = 3,
        Smd = 4
    }





    public static class SpecialtyExtensions
    {
        public static string String(this Specialty specialty)
        {
            switch (specialty)
            {
                case Specialty.Developer:
                    return "Developer";
                case Specialty.Architect:
                    return "Architect";
                case Specialty.HtmlCoder:
                    return "HTML Coder";
                case Specialty.Pm:
                    return "Project Manager";
                case Specialty.Smd:
                    return "Senior Manager Delivery";
                default:
                    throw new ArgumentOutOfRangeException(nameof(specialty), specialty, null);
            }
        }
    }





}
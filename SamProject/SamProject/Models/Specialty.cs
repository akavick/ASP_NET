using System;





namespace SamProject.Models
{





    public enum Specialty
    {
        Unset = 0,
        Developer = 1,
        Architect = 2,
        HtmlCoder = 3,
        Pm = 4,
        Smd = 5
    }





    public static class SpecialtyExtensions
    {
        public static string SamString(this Specialty specialty)
        {
            switch (specialty)
            {
                case Specialty.Unset:
                    return "";
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
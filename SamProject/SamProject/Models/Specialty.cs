using System;





namespace SamProject.Models
{





    public enum Specialty
    {
        Developer = 0,
        Architect = 1,
        HtmlCoder = 2,
    }





    public static class SpecialtyExtensions
    {
        public static string String(this Specialty specialty)
        {
            switch (specialty)
            {
                case Specialty.Developer: return "Developer";
                case Specialty.Architect: return "Architect";
                case Specialty.HtmlCoder: return "HTML Coder";
                default: throw new ArgumentOutOfRangeException(nameof(specialty), specialty, null);
            }
        }
    }





}
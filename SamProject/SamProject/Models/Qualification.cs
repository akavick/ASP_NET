using System;





namespace SamProject.Models
{





    public enum Qualification
    {
        Junior = 0,
        Staff = 1,
        Middle = 2,
        Senior = 3,
    }





    public static class QualificationExtensions
    {
        public static string String(this Qualification qualification)
        {
            switch (qualification)
            {
                case Qualification.Junior: return "Junior";
                case Qualification.Staff: return "Staff";
                case Qualification.Middle: return "Middle";
                case Qualification.Senior: return "Senior";
                default: throw new ArgumentOutOfRangeException(nameof(qualification), qualification, null);
            }
        }
    }





}
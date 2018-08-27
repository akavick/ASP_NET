using System;





namespace SamProject.Models
{





    public enum Qualification
    {
        Unset = 0,
        Junior = 1,
        Staff = 2,
        Middle = 3,
        Senior = 4,
    }





    public static class QualificationExtensions
    {
        public static string SamString(this Qualification qualification)
        {
            switch (qualification)
            {
                case Qualification.Unset:
                    return "";
                case Qualification.Junior:
                    return "Junior";
                case Qualification.Staff:
                    return "Staff";
                case Qualification.Middle:
                    return "Middle";
                case Qualification.Senior:
                    return "Senior";
                default:
                    throw new ArgumentOutOfRangeException(nameof(qualification), qualification, null);
            }
        }
    }





}
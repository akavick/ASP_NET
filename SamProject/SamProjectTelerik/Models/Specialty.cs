using System;





namespace SamProjectTelerik.Models
{





    public class Specialty
    {
        public SpecialtyType Type { get; set; } = SpecialtyType.Unset;
        public string Name => ToString();





        public override string ToString()
        {
            switch (Type)
            {
                case SpecialtyType.Unset:
                    return "";
                case SpecialtyType.Developer:
                    return "Developer";
                case SpecialtyType.Architect:
                    return "Architect";
                case SpecialtyType.HtmlCoder:
                    return "HTML Coder";
                case SpecialtyType.Pm:
                    return "Project Manager";
                case SpecialtyType.Smd:
                    return "Senior Manager Delivery";
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
            }
        }

    }





}
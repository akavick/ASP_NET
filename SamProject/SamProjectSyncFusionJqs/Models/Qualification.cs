using System;





namespace SamProjectSyncFusionJqs.Models
{





    public class Qualification
    {
        public QualificationType Type { get; set; } = QualificationType.Unset;
        public string Name => ToString();





        public override string ToString()
        {
            switch (Type)
            {
                case QualificationType.Unset:
                    return "";
                case QualificationType.Junior:
                    return "Junior";
                case QualificationType.Staff:
                    return "Staff";
                case QualificationType.Middle:
                    return "Middle";
                case QualificationType.Senior:
                    return "Senior";
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
            }
        }

    }





}
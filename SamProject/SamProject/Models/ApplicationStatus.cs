using System;





namespace SamProject.Models
{





    public class ApplicationStatus
    {
        public ApplicationStatusType Type { get; set; } = ApplicationStatusType.New;
        public string Name => ToString();





        public override string ToString()
        {
            switch (Type)
            {
                case ApplicationStatusType.New:
                    return "Создание запроса";
                case ApplicationStatusType.Approved:
                    return "Утверждена";
                case ApplicationStatusType.Revoked:
                    return "Отозвана";
                case ApplicationStatusType.OnApproval:
                    return "На утверждении RM";
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
            }
        }

    }





}
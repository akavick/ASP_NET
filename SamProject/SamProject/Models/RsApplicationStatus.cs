using System;





namespace SamProject.Models
{





    public class RsApplicationStatus
    {
        public RsApplicationStatusType Type { get; set; } = RsApplicationStatusType.New;
        public string Name => ToString();





        public override string ToString()
        {
            switch (Type)
            {
                case RsApplicationStatusType.New:
                    return "Создание запроса";
                case RsApplicationStatusType.Approved:
                    return "Утверждена";
                case RsApplicationStatusType.Revoked:
                    return "Отозвана";
                case RsApplicationStatusType.OnApproval:
                    return "На утверждении RM";
                default:
                    throw new ArgumentOutOfRangeException(nameof(Type), Type, null);
            }
        }

    }





}
using System;





namespace SamProject.Models
{





    public enum ApplicationStatus
    {
        New = 0,
        OnApproval = 1,
        Approved = 2,
        Revoked = 4,
    }





    public static class ApplicationStatusExtensions
    {
        public static string String(this ApplicationStatus applicationStatus)
        {
            switch (applicationStatus)
            {
                case ApplicationStatus.New:
                    return "Создание запроса";
                case ApplicationStatus.Approved:
                    return "Утверждена";
                case ApplicationStatus.Revoked:
                    return "Отозвана";
                case ApplicationStatus.OnApproval:
                    return "На утверждении RM";
                default:
                    throw new ArgumentOutOfRangeException(nameof(applicationStatus), applicationStatus, null);
            }
        }
    }





}
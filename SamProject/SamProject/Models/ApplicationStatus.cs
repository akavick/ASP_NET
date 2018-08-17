using System;





namespace SamProject.Models
{





    public enum ApplicationStatus
    {
        New = 0,
        Approved = 1,
        Revoked = 2,
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(applicationStatus), applicationStatus, null);
            }
        }
    }





}
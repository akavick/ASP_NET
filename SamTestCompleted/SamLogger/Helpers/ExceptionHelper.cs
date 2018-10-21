using System;
using System.Diagnostics;





namespace SamLogger.Helpers
{





    public static class ExceptionHelper
    {
        public static string DemystifyException(Exception exception)
        {
            return exception.Demystify().ToString();
        }


    }





}
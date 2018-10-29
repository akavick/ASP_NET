using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ErrorHandler.Helpers
{
    public static class ErrorHelper
    {
        public static string GetBeautifiedErrorMessage(Exception exception)
        {
            return exception.Demystify().ToString();
        }
    }
}

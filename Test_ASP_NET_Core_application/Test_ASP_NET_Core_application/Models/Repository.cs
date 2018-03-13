using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_NET_Core_application.Models
{
    public static class Repository
    {
        public static List<GuestResponse> Responses { get; } = new List<GuestResponse>();

        public static void AddResponse(GuestResponse guestResponse) => Responses.Add(guestResponse);
    }
}

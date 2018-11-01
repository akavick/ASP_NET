using System.Collections.Generic;

using Permissions.Models;



namespace Permissions.DAL
{

    public static class Repository
    {
        static Repository()
        {

        }



        public static IEnumerable<Permission> Permissions { get; } = new List<Permission>();

        public static IEnumerable<Principal> Principals { get; } = new List<Principal>();

        public static IEnumerable<Request> Requests { get; } = new List<Request>();
    }

}
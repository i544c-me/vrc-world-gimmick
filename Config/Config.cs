
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c
{
    public class Config : UdonSharpBehaviour
    {
        public string[] admin_usernames;

        public bool IsAdmin(string username)
        {
            foreach (string admin_username in admin_usernames)
            {
                if (admin_username == username) return true;
            }
            return false;
        }
    }
}
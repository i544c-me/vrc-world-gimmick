
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c
{
    public class Config : UdonSharpBehaviour
    {
        public string[] adminUsernames;

        public bool IsAdmin(string username)
        {
            foreach (string adminUsername in adminUsernames)
            {
                if (adminUsername == username) return true;
            }
            return false;
        }
    }
}
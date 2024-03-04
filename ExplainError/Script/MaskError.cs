using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using UnityEngine;

namespace i544c.ExplainError
{
    public class MaskError : MonoBehaviour
    {
        private string homePath {
            get {
                return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }
        }
        private string homeRegex {
            get {
                string[] pathComponents = homePath.Split('/', '\\');
                int count = 0;
                foreach (string pathComponent in pathComponents)
                {
                    pathComponents[count] = Regex.Escape(pathComponent);
                    count++;
                }
                return string.Join("[\\\\/]", pathComponents);
            }
        }

        public string RemoveCredential(string str)
        {
            return Regex.Replace(str, homeRegex, "[HOMEDIR]");
        }

        // Start is called before the first frame update
        public void Start()
        {
            //string home = homeRegex; 
            Tools.Log("homePath: " + homePath);
        }
    }
}

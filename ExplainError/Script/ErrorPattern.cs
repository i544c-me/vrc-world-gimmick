using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace i544c.ExplainError
{
    [System.Serializable]
    public class ErrorPatterns
    {
        public ErrorPattern[] result;
    }

    [System.Serializable]
    public class ErrorPattern
    {
        public int id;
        public string title;
        public string solution;
        public string created_at;
        public string updated_at;
        public string url;
    
        public static ErrorPatterns CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<ErrorPatterns>(jsonString);
        }
    }
}

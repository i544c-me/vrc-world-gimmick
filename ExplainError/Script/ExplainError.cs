using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace i544c.ExplainError
{
    public class ExplainError : MonoBehaviour
    {
        void Start()
        {
            OnEnable();
        }
    
        void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }
    
        void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }
    
        void HandleLog(string logString, string stackTrace, LogType type)
        {
            if (type != LogType.Error) return;

            logString = logString.Split('\n')[0];

            var maskerr = new MaskError();
            string search = maskerr.RemoveCredential(logString);

            StartCoroutine(GetRequest($"http://localhost:3000/search.json?q={search}"));
        }

        IEnumerator GetRequest(string uri)
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
            {
                // Request and wait for the desired page.
                yield return webRequest.SendWebRequest();

                string[] pages = uri.Split('/');
                int page = pages.Length - 1;

                if (webRequest.isNetworkError)
                {
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                }
                else
                {
                    //Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    var json = ErrorPattern.CreateFromJSON(webRequest.downloadHandler.text);

                    foreach (var pattern in json.result)
                    {
                        Tools.Log("title!! " + pattern.title);
                        Tools.Log("solution!! " + pattern.solution);
                    }
                }
            }
        }
    }
} 

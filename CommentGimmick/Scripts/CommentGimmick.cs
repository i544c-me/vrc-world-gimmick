
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.SDK3.Components;

using TMPro;
using VRC.SDK3.StringLoading;
using VRC.SDK3.Data; // VRCJson

public class Messages
{
    public string message;
}

public class CommentGimmick : UdonSharpBehaviour
{
    [SerializeField] private VRCUrl url;
    [SerializeField] private float span = 10f;
    [SerializeField] private VRCUrlInputField urlInput;

    public TextMeshProUGUI[] resultText;
    private UdonBehaviour downloadString;
    private float currentTime = 0f;

    void Start()
    {
        downloadString = (UdonBehaviour) this.GetComponents(typeof(UdonBehaviour))[1];
        VRCStringDownloader.LoadUrl(url, downloadString);
    }

    void FixedUpdate()
    {
        currentTime += Time.deltaTime;

        if (currentTime > span)
        {
            VRCStringDownloader.LoadUrl(url, downloadString);
            currentTime = 0f;
        }
    }

    public override void OnStringLoadSuccess(IVRCStringDownload result)
    {
        if (VRCJson.TryDeserializeFromJson(result.Result, out DataToken json))
        {
            DataDictionary data = (DataDictionary) json;
            if (data.TryGetValue("notes", out DataToken notes))
            {
                DataList notesList = (DataList) notes;
                for (int i = 0; i < notesList.Count; i++)
                {
                    if (notesList.TryGetValue(i, out DataToken note))
                    {
                        DataDictionary noteDic = (DataDictionary) note;
                        if (noteDic.TryGetValue("text", out DataToken text))
                        {
                            string text_str = (string) text;
                            resultText[i].text = text_str;
                            //Debug.Log(text_str);
                        }
                    }
                }
            }
        }
    }

    public override void OnStringLoadError(IVRCStringDownload result)
    {
        Debug.Log("StringLoadError");
    }

    public void OnURLChanged()
    {
        url = urlInput.GetUrl();
        Debug.Log(url);
    }
}

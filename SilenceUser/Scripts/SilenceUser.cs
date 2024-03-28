
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class SilenceUser : UdonSharpBehaviour
{
    void Start()
    {
        Debug.Log("[Silence User] Start!");
    }

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        Debug.Log("OnPlayerTriggerEnter(): " + player.displayName);
        player.SetVoiceGain(0);
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        Debug.Log("OnPlayerTriggerExit(): " + player.displayName);
        player.SetVoiceGain(15);
    }
}

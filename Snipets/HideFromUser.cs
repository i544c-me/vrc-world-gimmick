
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c
{
    public class HideFromUser : UdonSharpBehaviour
    {
        [Header("設定オブジェクト")]
        [SerializeField] private Config config;

        [Header("非活性とするオブジェクトを指定")]
        [SerializeField] private GameObject[] deactiveObjects;

        [Header("メッシュを隠したいオブジェクトを指定")]
        [SerializeField] private GameObject[] hideObjects;

        void Start()
        {
            if (config.IsAdmin(Networking.LocalPlayer.displayName)) return;

            foreach (GameObject deactivateObject in deactiveObjects)
            {
                deactivateObject.SetActive(false);
            }

            foreach (GameObject hideObject in hideObjects)
            {
                hideObject.GetComponent<MeshFilter>().mesh = null;
                hideObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
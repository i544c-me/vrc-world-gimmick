
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c.ConnectWithKintone
{
    public class Kintone : UdonSharpBehaviour
    {
        [SerializeField] private VRCUrl LambdaEndpointUrl;

        private UdonBehaviour downloadString;

        void Start()
        {
            downloadString = (UdonBehaviour) this.GetComponent(typeof(UdonBehaviour));
        }

        public static void Post(string str)
        {
            //
        }
    }
}
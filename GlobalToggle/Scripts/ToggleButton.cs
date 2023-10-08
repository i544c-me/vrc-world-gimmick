
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class ToggleButton : UdonSharpBehaviour
    {
        [Header("[任意] 設定オブジェクトを入れると押せるユーザーを制限できます")]
        [SerializeField] private Config config;

        [Header("初期状態を設定")]
        private bool _isActive = false;
        private bool isActive {
            get => _isActive;
            set {
                _isActive = value;
                ToggleObjects();
            }
        }

        [Header("ここに表示/非表示を切り替えたいオブジェクトを設定")]
        [SerializeField] private GameObject[] objects;

        [Header("Element 0 に Off 状態のボタン, 1 に On 状態のボタンを設定")]
        [SerializeField] private GameObject[] switches = new GameObject[2];

        private GameObject switchOff, switchOn;

        void Start()
        {
            switchOff = switches[0];
            switchOn  = switches[1];

            // 初期状態の反映のため
            if (isActive) ToggleObjects();
        }

        public override void Interact()
        {
            if (config && !config.IsAdmin(Networking.LocalPlayer.displayName)) return;

            Networking.SetOwner(Networking.LocalPlayer, gameObject); // 同期変数変更のため
            isActive = !isActive;
            RequestSerialization();
        }

        private void ToggleObjects()
        {
            switchOff.SetActive(!isActive);
            switchOn.SetActive(isActive);

            foreach (GameObject obj in objects)
            {
                if (obj == null) continue;
                obj.SetActive(!obj.activeSelf);
            }
        }

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (Networking.LocalPlayer == player) RequestSerialization();
        }
    }
}
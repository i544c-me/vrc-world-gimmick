
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class ToggleButton : UdonSharpBehaviour
    {
        [Header("初期状態を設定")]
        [UdonSynced, FieldChangeCallback(nameof(isActive))] public bool _isActive = false;
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
            ToggleObjects(); // 初期状態の反映のため
        }

        public override void Interact()
        {
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
                if (obj != null) obj.SetActive(isActive);
            }
        }

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (Networking.LocalPlayer == player) RequestSerialization();
        }
    }
}
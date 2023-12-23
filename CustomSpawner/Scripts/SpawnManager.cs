using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace i544c
{
    public class SpawnManager : UdonSharpBehaviour
    {
        [SerializeField] private SpawnPosition[] positions;

        private void CustomSpawn(VRCPlayerApi player)
        {
            foreach (SpawnPosition position in positions)
            {
                if (position == null || position.username != player.displayName) continue;
                player.TeleportTo(position.transform.position, position.transform.rotation);
            }
        }

        public override void OnPlayerJoined(VRCPlayerApi player)
        {
            if (Networking.LocalPlayer == player) CustomSpawn(player);
        }

        public override void OnPlayerRespawn(VRCPlayerApi player)
        {
            if (Networking.LocalPlayer == player) CustomSpawn(player);
        }
    }
}
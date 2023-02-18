using UnityEngine;
using UnboundLib.GameModes;
using System.Collections;

/*
 * All of this code was taken and modified from BKPatt's chaotic classes mod https://github.com/BKPatt/SP/blob/main/SeniorProject
 */

namespace BoopsBussinbMod.MonoBehaviours
{
    class RangerPointAndCard : MonoBehaviour
    {
        // Get player data and stats
        private Player player;
        private Gun gun;
        private GunAmmo gunAmmo;

        // Number of rounds a player has won
        private int point;

        // Number of class cards this.player has
        public int numCards = 0;

        // Locks some stats into the arrow
        public int bounce = 1;
        public int max_ammo = 1;
        public float minReload = 5;
        public float proj_speed = 5;
        public float atk_speed = 5;
        public float damage = 5;
        public float player_size = 0.5f;

        public void Awake()
        {
            player = this.gameObject.GetComponentInParent<Player>();
            gun = this.player.GetComponent<Holding>().holdable.GetComponent<Gun>();
            gunAmmo = GetComponent<Holding>().holdable.GetComponentInChildren<GunAmmo>();

            GameModeManager.AddHook(GameModeHooks.HookPickEnd, OnPickEnd);
        }

        public void Start()
        {
            point = GameModeManager.CurrentHandler.GetTeamScore(player.teamID).rounds;

            setStats();
        }

        // Runs when card pick ends
        public IEnumerator OnPickEnd(IGameModeHandler gm)
        {
            point = GameModeManager.CurrentHandler.GetTeamScore(player.teamID).rounds;
            setStats();
            yield break;
        }

        private void setStats()
        {
            gun.reflects = bounce;
            gunAmmo.maxAmmo = max_ammo;
            gun.projectileColor = Color.green;

            if (gun.projectileSize > 0.5f)
                gun.projectileSize = 0.5f;
            if (gun.damage < damage)
                gun.damage = damage;
            if (gun.projectileSpeed < proj_speed)
                gun.projectileSpeed = proj_speed;
            if (gun.attackSpeed < atk_speed)
                gun.attackSpeed = atk_speed;
            if (gunAmmo.reloadTime < minReload)
                gunAmmo.reloadTime = minReload;
        }
    }
}
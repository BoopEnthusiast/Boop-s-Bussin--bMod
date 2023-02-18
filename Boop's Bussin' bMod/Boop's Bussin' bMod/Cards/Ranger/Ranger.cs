using BoopsBussinbMod.MonoBehaviours;
using Photon.Pun.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using static CardInfoStat;
using static UnityEngine.Random;


namespace BoopsBussinbMod.Cards.Ranger
{
    class Ranger : CustomCard
    {

        public static CardInfo Card = null;

        private const bool debug_l = false; // debug this card 

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`

            //Modifiers
            cardInfo.allowMultiple = false;

            //Debugging
            if (debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a) 
                UnityEngine.Debug.Log($"[{BoopsBussinbMod.ModInitials}][Card] {GetTitle()} has been setup."); 
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected

            //Modifiers

            // Mono(s) and adjustments
            player.gameObject.AddComponent<RangerPointAndCard>();
            player.transform.gameObject.GetComponent<RangerPointAndCard>().numCards++;

            //Debugging
            if (debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a)
                UnityEngine.Debug.Log($"[{BoopsBussinbMod.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}."); 
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player

            //Modifiers e.g automatic reload

            // Mono(s) and adjustments e.g removing self damage
            GameObject.Destroy(player.gameObject.GetOrAddComponent<RangerPointAndCard>());

            //Debugging
            if (debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a)
                UnityEngine.Debug.Log($"[{BoopsBussinbMod.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}."); 
        }

        
        protected override string GetTitle() {return "Ranger";}
        protected override string GetDescription() {return "Become the one-shot long-range ranger of your dreams";}
        protected override GameObject GetCardArt() {return null;}
        protected override CardInfo.Rarity GetRarity() {return CardInfo.Rarity.Common;}
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Max bounce",
                    amount = "1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Max ammo",
                    amount = "1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Min attack speed",
                    amount = "5s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Min reload speed",
                    amount = "5s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Max bullet size",
                    amount = "50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Min bullet speed",
                    amount = "500%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Min damage",
                    amount = "500%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }

            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return "BBB";
        }
    }
}

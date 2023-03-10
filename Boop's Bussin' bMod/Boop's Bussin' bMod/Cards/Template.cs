using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;


namespace BoopsBussinbMod.Cards
{
    class Template : CustomCard
    {
        private const bool debug_l = false; // debug this card 

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`

            //Modifiers e.g damage

            //Debugging
            if (debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a) 
                UnityEngine.Debug.Log($"[{BoopsBussinbMod.ModInitials}][Card] {GetTitle()} has been setup."); 
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected

            //Modifiers e.g automatic reload

            // Mono(s) and adjustments e.g removing self damage

            //Debugging
            if (debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a)
                UnityEngine.Debug.Log($"[{BoopsBussinbMod.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}."); 
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player

            //Modifiers e.g automatic reload

            // Mono(s) and adjustments e.g removing self damage

            //Debugging
            if (debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a)
                UnityEngine.Debug.Log($"[{BoopsBussinbMod.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}."); 
        }


        protected override string GetTitle() {return "CardName";}
        protected override string GetDescription() {return "CardDescription";}
        protected override GameObject GetCardArt() {return null;}
        protected override CardInfo.Rarity GetRarity() {return CardInfo.Rarity.Common;}
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Effect",
                    amount = "No",
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

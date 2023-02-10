﻿using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using BoopsBussinbMod.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


namespace BoopsBussinbMod
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class BoopsBussinbMod: BaseUnityPlugin
    {
        private const string ModId = "com.boop.rounds.BoopsBussinbMod";
        private const string ModName = "Boop's Bussin' bMod";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "Boop";

        public static BoopsBussinbMod instance { get; private set; }

        public const bool debug_g = true; // Debug cards
        public const bool debug_a = true; // Debug all
        public const bool debug_am = true; // Debug Mono

        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            CustomCard.BuildCard<EvasiveManeuvers>();
            instance = this;
        }
    }
}

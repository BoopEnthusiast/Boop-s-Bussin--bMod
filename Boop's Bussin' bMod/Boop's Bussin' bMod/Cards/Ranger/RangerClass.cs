using ClassesManagerReborn;
using System.Collections;

/*
 * All of this code was taken and modified from BKPatt's chaotic classes mod https://github.com/BKPatt/SP/blob/main/SeniorProject
 */

namespace BoopsBussinbMod.Cards.Ranger
{
    class RangerClass : ClassHandler
    {
        private const bool debug_l = false; // debug this card 

        public static string name = "Ranger";

        public override IEnumerator Init()
        {
            //Debugging
            if(debug_l || BoopsBussinbMod.debug_g || BoopsBussinbMod.debug_a) 
            {
                UnityEngine.Debug.Log("Regestering: " + name);
            }

            //Register Class
            while (!(Ranger.Card || FasterBullet.Card)) yield return null;
            ClassesRegistry.Register(Ranger.Card, CardType.Entry); //Ranger entry card
            ClassesRegistry.Register(FasterBullet.Card, CardType.Card, 4); // 4 max
        }
    }
}

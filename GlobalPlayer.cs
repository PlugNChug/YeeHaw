using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw
{
	public class GlobalPlayer : ModPlayer
	{

		public bool profitCheck = false;

        public override void PostUpdate()
        {
            if (profitCheck) {
                Random rand = new Random();
                if (rand.Next(15) == 0) {
                    // 1 in 15 chance each tick to spawn gold coin dust if the Sword of Profit is held
                    int profitDust = Dust.NewDust(Player.position, Player.width, Player.height, DustID.GoldCoin, 0f, 0f, 150, default, 1f); 
                    // Dust should not move
                    Main.dust[profitDust].velocity *= 0f;
                }
            }
        }


        public bool iedCheck = false;
        public override void ResetEffects()
        {
            profitCheck = false;
            iedCheck = false;
        }



    }
}
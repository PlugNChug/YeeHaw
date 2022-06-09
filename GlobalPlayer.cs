using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw
{
	public class GlobalPlayer : ModPlayer
	{

		public bool profitCheck = false;

        /*public override void PostUpdate()
        {
           if (Player.velocity.X != 0 && profitCheck) Dust.NewDust(Player.position, Player.width, Player.height, DustID.GoldCoin, 0f, 1f, 0);
        }
        */

        public bool iedCheck = false;
        public override void ResetEffects()
        {
            profitCheck = false;
            iedCheck = false;
        }



    }
}
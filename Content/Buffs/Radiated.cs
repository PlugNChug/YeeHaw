using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace YeeHaw.Content.Buffs
{
    // This class serves as an example of a debuff that causes constant loss of life
    // See ExampleLifeRegenDebuffPlayer.UpdateBadLifeRegen at the end of the file for more information
    public class Radiated : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Radiated"); // Buff display name
            // Description.SetDefault("Defense is reduced by 12"); // Buff description
            Main.debuff[Type] = true;  // Is it a debuff?
                                       // Main.pvpBuff[Type] = true; // Players can give other players buffs, which are listed as pvpBuff
                                       // Main.buffNoSave[Type] = true; // Causes this buff not to persist when exiting and rejoining the world
                                       // BuffID.Sets.LongerExpertDebuff[Type] = true; // If this buff is a debuff, setting this to true will make this buff last twice as long on players in expert mode
        }

        // Allows you to make this buff give certain effects to the given player
        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 12;

            if (Main.rand.NextBool(20))
            {
                int dust = Dust.NewDust(player.position, player.Hitbox.Width, player.Hitbox.Height, DustID.YellowTorch, 0f, 0f, 50, default, 1f);
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].noLightEmittence = true;
            }
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.defDefense -= 12;

            if (Main.rand.NextBool(20))
            {
                int dust = Dust.NewDust(npc.position, npc.Hitbox.Width, npc.Hitbox.Height, DustID.YellowTorch, 0f, 0f, 50, default, 1f);
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].noLightEmittence = true;
            }
        }
    }
}

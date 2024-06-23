using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw.Content.Items.Weapons
{
    public class SuperExtendoHand : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 78;
            Item.height = 80;
            Item.damage = 70;
            Item.crit = 25;
            Item.DamageType = DamageClass.Melee;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useTurn = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 25f;
            Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            // Item.scale = 1f;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.Item175, player.position); // Slap Hand Sound
            if (target.boss) {
                target.knockBackResist = 1.25f;
            } else {
                target.knockBackResist = 1.5f;
            }   
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            SoundEngine.PlaySound(SoundID.Item175, player.position); // Slap Hand Sound
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ExtendoHand>());
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
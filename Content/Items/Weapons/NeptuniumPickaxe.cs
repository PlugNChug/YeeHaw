using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using YeeHaw.Content.Buffs;
using YeeHaw.Content.Items.Materials;
using Microsoft.Xna.Framework;

namespace YeeHaw.Content.Items.Weapons
{
    public class NeptuniumPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Neptunium Pickaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("Reduces your defense when held");
        }

        public override void SetDefaults()
        {
            Item.damage = 18;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1.5f;
            Item.value = 80000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.pick = 100;
            Item.useTurn = true;
            Item.scale = 1.0f;
            Item.tileBoost = 2;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiated>(), 300);
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Radiated>(), 600);
        }

        public override void OnHitPvp(Player player, Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(ModContent.BuffType<Radiated>(), 300);
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(10))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowTorch, 0f, 0f, 0, default, 1f);
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MoltenPickaxe, 1);
            recipe.AddIngredient(ModContent.ItemType<NeptuniumRod>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
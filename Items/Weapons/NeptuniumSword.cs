using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using YeeHaw.Buffs;
using YeeHaw.Items.Materials;
using Microsoft.Xna.Framework;

namespace YeeHaw.Items.Weapons
{
    public class NeptuniumSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Neptunium Longblade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Reduces the target's defense, but reduces your defense when held");
        }

        public override void SetDefaults()
        {
            Item.damage = 48;
            Item.DamageType = DamageClass.Melee;
            Item.width = 44;
            Item.height = 56;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6.5f;
            Item.value = 100000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.scale = 1.0f;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiated>(), 300);
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Radiated>(), 600);
        }

        public override void OnHitPvp(Player player, Player target, int damage, bool crit)
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
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(ItemID.Ruby, 1);
            recipe.AddIngredient(ModContent.ItemType<NeptuniumRod>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
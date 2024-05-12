using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace YeeHaw.Content.Items.Weapons
{
    public class RoyalBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Royal Bow"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("Automatically fires when you hold"+ "\nYou feel like Terrarian royalty holding this");
        }

        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1.2f;
            Item.value = 20000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
        }

        /*
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(72, 600);
        }
        */
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("YeeHaw:EvilBows");
            recipe.AddRecipeGroup("YeeHaw:GoldBows");
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6f, 4f);
        }
    }
}
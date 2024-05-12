using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace YeeHaw.Content.Items.Weapons
{
    public class NeptuniumYoyo : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Silver Spinner"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("Reduces the target's defense, but reduces your defense when held");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 24;
            Item.height = 24;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.NeptuniumYoyo>();
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 15f;
            Item.knockBack = 3.5f;
            Item.damage = 38;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.LightRed;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Buffs.Radiated>(), 300);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodYoyo);
            recipe.AddIngredient(ModContent.ItemType<Materials.NeptuniumRod>(), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        /*        public override Vector2? HoldoutOffset()
                {
                    Vector2 offset = new Vector2(6,4);

                    return offset;
                }*/
    }
}
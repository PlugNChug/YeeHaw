using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace YeeHaw.Items.Weapons
{
    public class Motorpuncher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Motorpuncher");
            Tooltip.SetDefault("\"Line 'em up, punch 'em out!\"");
        }

        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 26;
            Item.height = 78;
            Item.useTime = 7;
            Item.useAnimation = 25;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 25f;
            Item.value = Item.buyPrice(0, 8, 20, 0);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item23;
            Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.Motorpuncher>();
            Item.shootSpeed = 46f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteJackhammer, 1);
            recipe.AddIngredient(ItemID.MechanicalGlove, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        /*public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(30, -2);

            return offset;
        }*/
    }
}

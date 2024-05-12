using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace YeeHaw.Content.Items.Weapons
{
    public class WoodGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wooden Gun");
            // Tooltip.SetDefault("It's not the best, but it's functional" + "\n[c/FFA0A0:Bullets are highly affected by gravity]");
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 70;
            Item.useAnimation = 70;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item11;
            Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.WoodenBullet>();
            Item.shootSpeed = 12f;
            Item.useAmmo = ModContent.ItemType<Consumables.WoodenBullet>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood", 200);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .01f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(20));
            velocity.X = perturbedSpeed.X;
            velocity.Y = perturbedSpeed.Y;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(6f, 2f);
        }
    }
}

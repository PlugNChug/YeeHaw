﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YeeHaw.Items.Materials;

namespace YeeHaw.Items.Consumables
{
    public class NeptuniumArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reduces the target's defense");
        }

        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 14;
            Item.height = 32;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 2.1f;
            Item.value = Item.sellPrice(0, 0, 0, 6);
            Item.rare = 3;
            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<Projectiles.Weapons.NeptuniumArrow>();
            Item.shootSpeed = 3f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WoodenArrow, 100);
            recipe.AddIngredient(ModContent.ItemType<NeptuniumRod>(), 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
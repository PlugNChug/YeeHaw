﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw.Content.Items.Consumables
{
    public class WoodenBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("A weak bullet that at least gets the job done. Used by the Wooden Gun");
        }

        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.knockBack = 1.1f;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = ItemRarityID.White;
            Item.ammo = Item.type; // The first item in an ammo class sets the AmmoID to its type
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("Wood");
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
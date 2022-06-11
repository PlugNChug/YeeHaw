using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace YeeHaw.Currencies
{
    public class TradeToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Trade Token");
            Tooltip.SetDefault("Used for trading with the Supplier");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 999;
            Item.value = 0;
            Item.rare = ItemRarityID.Blue;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SilverCoin, 10);
            recipe.AddRecipeGroup("YeeHaw:EvilBars", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}

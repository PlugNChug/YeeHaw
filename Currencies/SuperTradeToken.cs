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
    public class SuperTradeToken : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Trade Token");
            Tooltip.SetDefault("A rare, more valuable variant of Trade Token that can be used for trading with the Supplier");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 999;
            Item.value = 0;
            Item.rare = ItemRarityID.Cyan;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemType<TradeToken>(), 10);
            recipe.AddIngredient(ItemID.HallowedBar, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}

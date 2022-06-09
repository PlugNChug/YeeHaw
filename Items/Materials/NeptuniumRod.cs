using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using YeeHaw.Items.Tiles;
using YeeHaw.Buffs;

namespace YeeHaw.Items.Materials
{
    public class NeptuniumRod : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 99;
            Item.value = Item.buyPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Orange;
            // Item.consumable = true;
            // Item.useTime = 12;
            // Item.useAnimation = 12;
            // Item.useStyle = ItemUseStyleID.Swing;
            // Item.useTurn = true;
            // Item.autoReuse = true;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiated>(), 1);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NeptuniumOre>(), 4);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
}

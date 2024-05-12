using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using YeeHaw.Content.Tiles;
using YeeHaw.Content.Buffs;

namespace YeeHaw.Content.Items.Tiles
{
    public class NeptuniumOre : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.Orange;
            Item.consumable = true;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.createTile = ModContent.TileType<NeptuniumOreTile>();
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiated>(), 1);
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using YeeHaw.Content.NPCs.Enemies;

namespace YeeHaw.Content.Items.Furniture.Banners
{
    public class Banners : ModTile
    {
        public override void SetStaticDefaults()
        {
            DustType = -1;

            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = [16, 16, 16];
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile | AnchorType.SolidSide | AnchorType.SolidBottom | AnchorType.PlanterBox, TileObjectData.newTile.Width, 0);
            // TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.newTile.DrawYOffset = -2;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.AnchorTop = new AnchorData(AnchorType.Platform, TileObjectData.newTile.Width, 0);
            TileObjectData.newAlternate.DrawYOffset = -10;
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
        }

        // For when a banner is placed on a platform, etc.
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            if ((tileFrameY == 0 && Main.tileSolidTop[Main.tile[i, j - 1].TileType]) || (tileFrameY == 18 && Main.tileSolidTop[Main.tile[i, j - 2].TileType]) || (tileFrameY == 36 && Main.tileSolidTop[Main.tile[i, j - 3].TileType]))
            {
                offsetY -= 8;
            }
            base.SetDrawPositions(i, j, ref width, ref offsetY, ref height, ref tileFrameX, ref tileFrameY);
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].TileFrameX / 18;
                int type = -1;
                switch (style)
                {
                    case 0:
                        type = ModContent.NPCType<TriangleSlime>();
                        break;

                    default:
                        return;
                }

                // Code that gives the player buffs near the banner
                if (type != -1)
                {
                    Main.SceneMetrics.NPCBannerBuff[type] = true;
                    Main.SceneMetrics.hasBanner = true;
                }
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1) spriteEffects = SpriteEffects.FlipHorizontally;
        }
    }
}

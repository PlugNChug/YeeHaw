﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace YeeHaw.Content.Tiles
{
    public class NeptuniumOreTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileMerge[TileID.Mud][Type] = true;
            Main.tileMerge[Type][TileID.Mud] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileOreFinderPriority[Type] = 510;
            Main.tileShine[Type] = 975;
            Main.tileShine2[Type] = true;

            DustType = DustID.Silver;

            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Neptunium");
            AddMapEntry(new Color(70, 70, 70), name);

            HitSound = SoundID.Tink;
            MineResist = 3f;
            MinPick = 65;
        }
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.IO;
using Terraria.IO;
using System;

using Terraria.UI;
using YeeHaw.UI;

namespace YeeHaw
{
    public class YeeHawWorld : ModSystem
    {

        #region GENERATION

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if(shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("Neptunium Ore Spawn", GenerateNeptuniumOre));
            }    
        }

        private void GenerateNeptuniumOre(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing Neptunium Ore";
            for(var i = 0; i < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); i++)
            {
                int x = WorldGen.genRand.Next(200, Main.maxTilesX - 200);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY - 50);

                Tile tile = Main.tile[x, y];
                if (tile.TileType == TileID.Sandstone)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(10, 16), WorldGen.genRand.Next(3, 6), ModContent.TileType<Tiles.NeptuniumOreTile>());
                }
                else
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 6), ModContent.TileType<Tiles.NeptuniumOreTile>());
                }
                
            }
        }

        #endregion
    }
}

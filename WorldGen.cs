using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Terraria.IO;
using YeeHaw.Content.Tiles;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace YeeHaw
{
    public class YeeHawWorld : ModSystem
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int shiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if(shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new NeptuniumOreSpawn("Neptunium Ore Spawn", 100f));
            }    
        }

        // -------------------DEBUG ZONE-------------------
        /*public static bool JustPressed(Keys key)
        {
            return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
        }

        public override void PostUpdateWorld()
        {
            if (JustPressed(Keys.D1))
                TestMethod((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
        }

        private void TestMethod(int x, int y)
        {
            Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

            // Code to test placed here:
            Tile tile = Framing.GetTileSafely(x, y);
            int steps = WorldGen.genRand.Next(3, 6);
            Main.NewText(TileID.Sets.CanBeClearedDuringGeneration[0]);
            //if (tile.TileType == TileID.Sandstone || tile.TileType == TileID.HardenedSand || tile.TileType == TileID.Sand)
            //{
            //    strength = WorldGen.genRand.Next(10, 13);
            //    WorldGen.TileRunner(x, y, strength, steps, ModContent.TileType<NeptuniumOreTile>());
            //    Main.NewText("Test1");
            //    Main.NewText("Strength: " + strength);
            //    Main.NewText("Steps: " + steps);
            //}
            //else
            //{
            //    strength = WorldGen.genRand.Next(4, 7);
            //    WorldGen.TileRunner(x, y, strength, steps, ModContent.TileType<NeptuniumOreTile>());
            //    Main.NewText("Test2");
            //    Main.NewText("Strength: " + strength);
            //    Main.NewText("Steps: " + steps);
            //}
        }*/
    }

    public class NeptuniumOreSpawn : GenPass
    {
        public NeptuniumOreSpawn(string name, float loadWeight) : base(name, loadWeight)
        {
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Placing Neptunium Ore";

            for (int index = 0; index < (int)(Main.maxTilesX * Main.maxTilesY * 0.00010); ++index)
            {
                WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)(Main.maxTilesY / 2), Main.maxTilesY - 50), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), ModContent.TileType<NeptuniumOreTile>());
            }
        }
    }
}

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw.Content.Items.Consumables
{
    public class LunarManipulator : ModItem
    {
        string[] moonList = new string[8] { "Full Moon", "Waning Gibbous", "Third Quarter", "Waning Crescent", "New Moon", "Waxing Crescent", "First Quarter", "Waxing Gibbous" };

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Cycles through the moon phases" + "\nRight click to cycle through different moon styles!");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.useAnimation = 120;
            Item.useTime = 120;
            Item.consumable = false;
            Item.value = Item.sellPrice(0, 80, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Zombie103; // It's just one of the sounds made by Moon Lord
            for (int i = 0; i < moonList.Length; i++)
            {
                moonList[i] = "[c/FFF014:" + moonList[i] + "]";
            }
        }

    public override bool? UseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                if (Main.moonType > 7)
                {
                    Main.moonType = 0;
                }
/*                else if (Main.moonType == 11)
                {
                    Main.moonType = 0;
                }*/
                else Main.moonType += 1;
                Main.NewText("[c/FFF014:Moon style changed!]");
                return true;
            }
            else
            {
                if (Main.moonPhase > 6)
                {
                    Main.moonPhase = 0;
                }
                else Main.moonPhase += 1;
                Main.NewText("Moon Phase: " + moonList[Main.moonPhase]);
                return true;
            }
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FragmentSolar, 20);
            recipe.AddIngredient(ItemID.FragmentNebula, 20);
            recipe.AddIngredient(ItemID.FragmentVortex, 20);
            recipe.AddIngredient(ItemID.FragmentStardust, 20);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ItemID.LunarCraftingStation);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
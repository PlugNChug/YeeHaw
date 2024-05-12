using YeeHaw.Common;
using YeeHaw.Content.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace YeeHaw.Content
{
    public class Recipes : ModSystem
    {
        public override void AddRecipeGroups()/* tModPorter Note: Removed. Use ModSystem.AddRecipeGroups */
        {
            RecipeGroup group1 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold Broadsword", new int[]
            {
                ItemID.GoldBroadsword,
                ItemID.PlatinumBroadsword
            });
            RecipeGroup.RegisterGroup("YeeHaw:GoldBroadswords", group1);

            RecipeGroup group2 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bow", new int[]
            {
                ItemID.DemonBow,
                ItemID.TendonBow
            });
            RecipeGroup.RegisterGroup("YeeHaw:EvilBows", group2);

            RecipeGroup group3 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold Bow", new int[]
            {
                ItemID.GoldBow,
                ItemID.PlatinumBow
            });
            RecipeGroup.RegisterGroup("YeeHaw:GoldBows", group3);

            RecipeGroup group4 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Night's Edge ingredient", new int[]
            {
                ItemID.Muramasa,
                ItemID.FieryGreatsword,
                ItemID.BladeofGrass,
                ItemID.LightsBane,
                ItemID.BloodButcherer
            });
            RecipeGroup.RegisterGroup("YeeHaw:NightsEdgeIngredients", group4);

            RecipeGroup group5 = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Evil Bar", new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar,
            });
            RecipeGroup.RegisterGroup("YeeHaw:EvilBars", group5);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using YeeHaw.UI;
using YeeHaw.Currencies;


namespace YeeHaw
{
	public class YeeHaw : Mod
	{

        public static int TradeTokenID; // This is for the Supplier's custom currency
        public static int SuperTradeTokenID;

        public override void Load()
        {
            TradeTokenID = CustomCurrencyManager.RegisterCurrency(new TradeTokenCurrency(ModContent.ItemType<TradeToken>(), 999L));
            SuperTradeTokenID = CustomCurrencyManager.RegisterCurrency(new SuperTradeTokenCurrency(ModContent.ItemType<SuperTradeToken>(), 999L));
        }

        public override void AddRecipeGroups()
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

        /*public class YeeHawUI : ModSystem
        {
            internal MoonPhaseSelector MoonPhaseSelector;

            private UserInterface _moonPhaseSelector;

            public override void Load()
            {
                // The Moon Phase Selection UI
                MoonPhaseSelector = new MoonPhaseSelector();
                MoonPhaseSelector.Activate();
                _moonPhaseSelector = new UserInterface();
                _moonPhaseSelector.SetState(MoonPhaseSelector);

            }
            public override void UpdateUI(GameTime gameTime)
            {
                _moonPhaseSelector?.Update(gameTime);
            }
            public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
            {
                int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
                if (mouseTextIndex != -1)
                {
                    layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                        "YourMod: A Description",
                        delegate
                        {
                            _moonPhaseSelector.Draw(Main.spriteBatch, new GameTime());
                            return true;
                        },
                        InterfaceScaleType.UI)
                    );
                }

            }
        }*/

    }
}
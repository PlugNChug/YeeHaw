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
using YeeHaw.Content.Currencies;


namespace YeeHaw
{
	public class YeeHaw : Mod
	{

        public static int TradeTokenID; // This is for the Supplier's custom currency
        public static int SuperTradeTokenID;

        public override void Load()
        {
            TradeTokenID = CustomCurrencyManager.RegisterCurrency(new TradeTokenCurrency(ModContent.ItemType<TradeToken>(), 999L, "Mods.YeeHaw.Currencies.TradeToken"));
            SuperTradeTokenID = CustomCurrencyManager.RegisterCurrency(new SuperTradeTokenCurrency(ModContent.ItemType<SuperTradeToken>(), 999L, "Mods.YeeHaw.Currencies.SuperTradeToken"));
        }

        internal class Content
        {
        }
    }
}
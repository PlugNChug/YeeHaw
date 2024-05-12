using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace YeeHaw.Content.Currencies
{
    public class SuperTradeTokenCurrency : CustomCurrencySingleCoin
    {
        public SuperTradeTokenCurrency(int coinItemID, long currencyCap, string CurrencyTextKey) : base(coinItemID, currencyCap)
        {
            this.CurrencyTextKey = CurrencyTextKey;
			
        }

        /* public override void GetPriceText(string[] lines, ref int currentLine, int price)
		{
			Color color = Color.AntiqueWhite * (Main.mouseTextColor / 255f);
			lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]",
					color.R,
					color.G,
					color.B,
					Language.GetTextValue("LegacyTooltip.50"),
					price,
					price > 1 ? "Super Trade Tokens" : "Super Trade Token"
				);
		} */
    }
}
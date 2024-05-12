using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YeeHaw.Content.Items.Weapons
{
    public class ExtendoHand : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Extendo Hand"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("The wrath of the Slap Hand and the range of the Extendo Grip combined results in this monstrosity");
        }

        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 15;
            Item.width = 66;
            Item.height = 68;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 22f;
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.scale = 1.1f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ExtendoGrip, 1);
            recipe.AddIngredient(ItemID.SlapHand, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}
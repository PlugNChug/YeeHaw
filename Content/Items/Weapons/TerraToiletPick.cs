using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace YeeHaw.Content.Items.Weapons
{
    public class TerraToiletPick : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Terra Toilet Pickaxe"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            // Tooltip.SetDefault("[c/FFA0A0:This tool is extremely cumbersome]" + "\nYou somehow found a way to put your \"wasted\" Broken Hero Sword to use");
        }

        public override void SetDefaults()
        {
            Item.damage = 2;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 69;
            Item.useAnimation = 69;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.6f;
            Item.value = 69000;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.pick = 10;
            Item.useTurn = true;
            Item.scale = 1.0f;
        }

        public override void HoldItem(Player player)
        {
            player.AddBuff(BuffID.Slow, 1);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TerraToilet, 1);
            recipe.AddRecipeGroup("Wood", 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
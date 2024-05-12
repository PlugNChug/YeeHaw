using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using YeeHaw.Content.Buffs;
using YeeHaw.Content.Items.Materials;

namespace YeeHaw.Content.Items.Armor
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class NeptuniumBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("Neptunium Breastplate");
            /* Tooltip.SetDefault("Reduces your defense if the full set isn't worn"
				+ "\n6% increased damage"
				+ "\nIncreased fall speed"); */

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
            Item.rare = ItemRarityID.LightRed; // The rarity of the item
            Item.defense = 9; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.AddBuff(ModContent.BuffType<Radiated>(), 1);
            player.GetDamage(DamageClass.Generic) += 0.06f;
            player.maxFallSpeed += 10f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NeptuniumRod>(), 15);
            recipe.AddIngredient(ItemID.MoltenBreastplate);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}

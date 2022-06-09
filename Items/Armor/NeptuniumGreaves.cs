using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using YeeHaw.Buffs;
using YeeHaw.Items.Materials;

namespace YeeHaw.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class NeptuniumGreaves : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Reduces your defense if the full set isn't worn"
				+ "\n6% increased speed"
				+ "\nIncreased jumping power");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.LightRed; // The rarity of the item
			Item.defense = 8; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) {
			player.AddBuff(ModContent.BuffType<Radiated>(), 1);
			player.jumpSpeedBoost += 1.5f;
			player.moveSpeed += 0.06f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<NeptuniumRod>(), 12);
			recipe.AddIngredient(ItemID.MoltenGreaves);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}

using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YeeHaw.Projectiles.Weapons;
using Terraria.Audio;
using YeeHaw.Items.Materials;

namespace YeeHaw.Items.Consumables                 //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    public class IED : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("IED");
            Tooltip.SetDefault("Massive explosion. Plays a familiar tune when thrown"
                + "\nJust run.");
        }
        public override void SetDefaults()
        {
            Item.damage = 0;     //The damage stat for the Weapon.                   
            Item.width = 10;    //sprite width
            Item.height = 12;   //sprite height
            Item.maxStack = 3;   //This defines the items max stack
            Item.consumable = true;  //Tells the game that this should be used up once fired
            Item.useStyle = ItemUseStyleID.Swing;   //The way your item will be used, 1 is the regular sword swing for example
            Item.rare = 4;     //The color the title of your item when hovering over it ingame
            Item.UseSound = SoundID.Item1; //The sound played when using this item
            Item.useAnimation = 20;  //How long the item is used for.
            Item.useTime = 20;     //How fast the item is used.
            Item.value = 50000;
            Item.noUseGraphic = true;
            Item.noMelee = true;      //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damage
            Item.shoot = ModContent.ProjectileType<IEDProjectile>();
            Item.shootSpeed = 5f; //This defines the projectile speed when shot
        }

        public override void OnConsumeItem(Player player)
        {
            SoundStyle iedSound = new SoundStyle("YeeHaw/Sounds/Item/NokiaArabic");
            SoundEngine.PlaySound(iedSound);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Dynamite, 15);    
            recipe.AddIngredient(ItemID.Bomb, 20); 
            recipe.AddIngredient(ItemID.Wire, 2);
            recipe.AddIngredient(ModContent.ItemType<NeptuniumRod>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;

namespace YeeHaw.Content.Items.Weapons
{
    public class Profit : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4.2f;
            Item.value = 100000;
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }

        public override void HoldItem(Player player)
        {
            player.GetModPlayer<GlobalPlayer>().profitCheck = true;
        }
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Midas, 600);
            
            Random rand = new Random();

            if (target.life <= 0) {
                return; // Coin drops are calculated before a potential "killing blow multiplier", we don't want misleading double/triple popups
            } else if (target.boss) {
                target.value += 50f;
                return;
            } else if (target.value >= 100000) {
                target.value += 10f;
            } else {
                // Target's value increases randomly each time it is struck. Only applies if target is not a boss/max value cap is not reached
                AdvancedPopupRequest doubleValue = new AdvancedPopupRequest
                {
                    Text = "Value Doubled!",
                    Color = Color.Gold,
                    DurationInFrames = 120,
                    Velocity = new Vector2(0f, -12f)
                };
                AdvancedPopupRequest tripleValue = new AdvancedPopupRequest
                {
                    Text = "Value Tripled!",
                    Color = Color.Gold,
                    DurationInFrames = 120,
                    Velocity = new Vector2(0f, -12f)
                };
                switch (rand.Next(100))
                {
                    
                    case 0:
                        target.value *= 2f;
                        PopupText.NewText(doubleValue, target.position);
                        SoundEngine.PlaySound(SoundID.Item144, player.position);
                        break;
                    case 1:
                        target.value *= 2f;
                        PopupText.NewText(doubleValue, target.position);
                        SoundEngine.PlaySound(SoundID.Item144, player.position);
                        break;
                    case 2:
                        target.value *= 2f;
                        PopupText.NewText(doubleValue, target.position);
                        SoundEngine.PlaySound(SoundID.Item144, player.position);
                        break;
                    case 3:
                        target.value *= 2f;
                        PopupText.NewText(doubleValue, target.position);
                        SoundEngine.PlaySound(SoundID.Item144, player.position);
                        break;
                    case 4:
                        target.value *= 3f;
                        PopupText.NewText(tripleValue, target.position);
                        SoundEngine.PlaySound(SoundID.Item145, player.position);
                        break;
                    default:
                        target.value += 10f;
                        break;
                }
                // Debug purposes
                // Main.NewText(target.value);
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GoldCoin, 0f, 0f, 0, default, 1f);
            Main.dust[dust].velocity *= 0f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("YeeHaw:GoldBroadswords");
            recipe.AddIngredient(ItemID.GoldCoin, 50);
            recipe.AddIngredient(ItemID.LuckyCoin, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
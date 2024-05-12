using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;


namespace YeeHaw.Content.Projectiles.Weapons
{
    internal class IEDProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            // DisplayName.SetDefault("an IED");     //The English name of the Projectile
        }

        public override void SetDefaults()
        {
            // while the sprite is actually bigger than 15x15, we use 15x15 since it lets the Projectile clip into tiles as it bounces. It looks better.
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 16;
            Projectile.damage = 512;
            Projectile.friendly = true;
            Projectile.hostile = true;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;

            // 23 second fuse, for 23 times 60 frames is 1380.
            Projectile.timeLeft = 1380;

            // These 2 help the Projectile hitbox be centered on the Projectile sprite.
            DrawOffsetX = 0;
            DrawOriginOffsetY = 0;
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            // Vanilla explosions do less damage to Eater of Worlds in expert mode, so we will too.
            if (Main.expertMode)
            {
                if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
                {
                    modifiers.FinalDamage /= 500;
                }
            }
        }

        public override void AI()
        {
            {
                // Smoke and fuse dust spawn.
                if (Main.rand.NextBool(2))
                {
                    int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[dustIndex].scale = 0.1f + Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].fadeIn = 1.5f + Main.rand.Next(5) * 0.1f;
                    Main.dust[dustIndex].noGravity = true;
                    Main.dust[dustIndex].position = Projectile.Center + new Vector2(0f, -0.25f).RotatedBy((double)Projectile.rotation, default) * 1.1f;
                }
            }
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] > 5f)
            {
                Projectile.ai[0] = 10f;
                // Roll speed dampening.
                if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
                {
                    Projectile.velocity.X = Projectile.velocity.X * 0.97f;
                    if (Projectile.type == 29 || Projectile.type == 470 || Projectile.type == 637)
                    {
                        Projectile.velocity.X = Projectile.velocity.X * 0.99f;
                    }
                    if (Projectile.velocity.X > -0.01 && Projectile.velocity.X < 0.01)
                    {
                        Projectile.velocity.X = 0f;
                        Projectile.netUpdate = true;
                    }
                }
                Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
            }
            // Rotation increased by velocity.X 
            Projectile.rotation += Projectile.velocity.X * 0.1f;
            return;
        }

        public override void OnKill(int timeLeft)
        {

            Vector2 position = Projectile.Center;
            SoundEngine.PlaySound(SoundID.Item14, new Vector2(Projectile.position.X, Projectile.position.Y));
            int radius = 20;     //this is the explosion radius, the highter is the value the bigger the explosion

            for (int x = -radius; x <= radius; x++)
            {
                for (int y = -radius; y <= radius; y++)
                {
                    int xPosition = (int)(x + position.X / 16.0f);
                    int yPosition = (int)(y + position.Y / 16.0f);

                    if (Math.Sqrt(x * x + y * y) <= radius + 0.5)   //this make so the explosion radius is a circle
                    {
                        WorldGen.KillTile(xPosition, yPosition, false, false, false);  //this make the explosion destroy tiles  
                        WorldGen.KillWall(xPosition, yPosition, false);
                        Dust.NewDust(position, 22, 22, DustID.Smoke, 0.0f, 0.0f, 120, new Color(), 1f);  //this is the dust that will spawn after the explosion
                    }
                }
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace YeeHaw.Content.Projectiles.Weapons
{
    public class Motorpuncher : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Motorpuncher");     //The English name of the Projectile
            Main.projFrames[Type] = 4;  // 4 frame animation
        }

        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.aiStyle = 20;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1.1f;
            DrawOriginOffsetY -= 18;
        }

        public override void AI()
        {
            // Loop through the 4 animation frames, spending 3 ticks on each
            // Projectile.frame — index of current frame
            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;

                // Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }
        }
        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            // Main.NewText(Projectile.rotation.ToString());
            if (Projectile.rotation >= MathHelper.Pi / 4 && Projectile.rotation <= MathHelper.Pi * 3 / 4)
            {
                hitbox.X += 16;
            }
            else if (Projectile.rotation <= MathHelper.Pi / 4 && Projectile.rotation >= -MathHelper.Pi / 4)
            {
                hitbox.Y -= 12;
            }
            else if (Projectile.rotation >= -MathHelper.Pi / 2 && Projectile.rotation <= -MathHelper.Pi / 4 || Projectile.rotation >= MathHelper.Pi * 5 / 4)
            {
                hitbox.X -= 16;
            }
            else // if (Projectile.rotation <= MathHelper.Pi * 5 / 4 && Projectile.rotation >= MathHelper.Pi * 3 / 4)
            {
                hitbox.Y += 12;
            }
        }
    }
}

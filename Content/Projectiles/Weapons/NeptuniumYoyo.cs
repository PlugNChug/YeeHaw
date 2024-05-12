using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace YeeHaw.Content.Projectiles.Weapons
{
    public class NeptuniumYoyo : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Silver Spinner");     //The English name of the Projectile
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 8.5f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 190f;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.Code1);
            Projectile.damage = 38;
            Projectile.extraUpdates = 0;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 99;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Radiated>(), 600);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<Buffs.Radiated>(), 300);
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            if (Main.rand.NextBool(10))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.YellowTorch, 0f, 0f, 0, default, 1f);
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
            }
        }
    }
}

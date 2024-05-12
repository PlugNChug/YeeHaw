using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace YeeHaw.Content.Projectiles.Weapons
{
    public class WoodenBullet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wooden Bullet");     //The English name of the Projectile
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;    //The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;        //The recording mode
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;               //The width of Projectile hitbox
            Projectile.height = 8;              //The height of Projectile hitbox
            Projectile.friendly = true;         //Can the Projectile deal damage to enemies?
            Projectile.hostile = false;         //Can the Projectile deal damage to the player?
            Projectile.DamageType = DamageClass.Ranged;           //Is the Projectile shot by a ranged weapon?
            Projectile.penetrate = 1;           //How many monsters the Projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 120;          //The live time for the Projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 20;             //The transparency of the Projectile, 255 for completely transparent. (aiStyle 1 quickly fades the Projectile in)
            Projectile.light = 0.1f;            //How much light emit around the Projectile
            Projectile.ignoreWater = false;          //Does the Projectile's speed be influenced by water?
            Projectile.tileCollide = true;          //Can the Projectile collide with tiles?
            Projectile.extraUpdates = 3;            //Set to above 0 if you want the Projectile to update multiple time in a frame
            Projectile.aiStyle = ProjectileID.Bullet;           //Act exactly like default Bullet
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            //If collide with tile, reduce the penetrate.
            //So the Projectile can reflect at most 5 times
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                SoundEngine.PlaySound(SoundID.Item17, new Vector2(Projectile.position.X, Projectile.position.Y));
            }
            return false;
        }

        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the Projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.ProjectileTexture[Projectile.type].Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(Main.ProjectileTexture[Projectile.type], drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }*/
    }
}

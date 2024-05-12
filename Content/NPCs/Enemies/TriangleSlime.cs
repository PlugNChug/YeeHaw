using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;

namespace YeeHaw.Content.NPCs.Enemies
{
    public class TriangleSlime : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Triangular Slime");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
        }

        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 24;
            
            if (Main.hardMode && Main.masterMode) {
                NPC.damage = 100;
                NPC.defense = 10;
                NPC.lifeMax = 152;
                NPC.value = 150f;
            } else if (Main.hardMode && Main.expertMode) {
                NPC.damage = 50;
                NPC.defense = 5;
                NPC.lifeMax = 152;
                NPC.value = 100f;
            } else {
                NPC.damage = 10;
                NPC.defense = 4;
                NPC.lifeMax = 27;
                NPC.value = 10f;
            }

            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = NPCID.BlueSlime;
            AnimationType = NPCID.GreenSlime;
            Banner = Item.NPCtoBanner(NPCID.GreenSlime);
            BannerItem = Item.BannerToItem(NPCID.GreenSlime);
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("Mutations cause some slimes to become triangular. These pointy slimes can be found on the Surface day and night."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
			});
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // Causes dust to spawn when the NPC takes damage.
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.t_Slime, 0f, 0f, 0, Color.Magenta);
            }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (spawnInfo.Player.ZoneForest && !Main.hardMode)
            {
                return 0.15f;
            }
            else if (spawnInfo.Player.ZoneForest)  // Half as likely to spawn in Hardmode.
            {
                return 0.075f;
            }
            return 0f;
        }

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter++;
            if (NPC.frameCounter >= 20)
            {
                NPC.frameCounter = 0;
            }
            NPC.spriteDirection = NPC.direction;
            NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 3, 3));  // Drop a minimum of 3 gel and a maximum of 3 gel at a 100% (1/1) rate.
            npcLoot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 9500));  // Slightly more common Slime Staff drop than normal (compare to 1/10000)
            npcLoot.Add(ItemDropRule.Common(ItemID.PinkGel, 4, 1, 2));
        }
    }
}

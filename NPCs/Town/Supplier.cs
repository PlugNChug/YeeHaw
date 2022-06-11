using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;

namespace YeeHaw.NPCs.Town
{
	// [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Supplier : ModNPC
	{
		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from localization files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Supplier");
			Main.npcFrameCount[Type] = 26; // The amount of frames the NPC has

			NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 250; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 1;
			NPCID.Sets.AttackTime[Type] = 16; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 10;
			NPCID.Sets.HatOffsetY[Type] = -2; // For when a party is active, the party hat spawns at a Y offset.

			// Influences how the NPC looks in the Bestiary
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0) {
				Velocity = -1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = -1 // -1 is left and 1 is right.
							   // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							   // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

			NPC.Happiness
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<OceanBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<DesertBiome>(AffectionLevel.Like)
				.SetBiomeAffection<MushroomBiome>(AffectionLevel.Like)
				.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love)
				.SetNPCAffection(NPCID.ArmsDealer, AffectionLevel.Love)
				.SetNPCAffection(NPCID.WitchDoctor, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Angler, AffectionLevel.Hate)
			; // < Mind the semicolon!
		}

		public override void SetDefaults() {
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.TravellingMerchant;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("This sketchy dude will gladly sell you shady items... at a hefty price, of course."),
			});
		}

		public override void HitEffect(int hitDirection, double damage) {
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++) {
				Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Smoke);
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) { // Requirements for the town NPC to spawn.
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}

				// 50 gold coins needed to spawn
				if (money >= 500000) {
					return true;
				}
			}

			return false;
		}

		// Example Person needs a house built out of ExampleMod tiles. You can delete this whole method in your townNPC for the regular house conditions.
		/*public override bool CheckConditions(int left, int right, int top, int bottom) {
			int score = 0;
			for (int x = left; x <= right; x++) {
				for (int y = top; y <= bottom; y++) {
					int type = Main.tile[x, y].TileType;
					if (type == ModContent.TileType<ExampleBlock>() || type == ModContent.TileType<ExampleChair>() || type == ModContent.TileType<ExampleWorkbench>() || type == ModContent.TileType<ExampleBed>() || type == ModContent.TileType<ExampleDoorOpen>() || type == ModContent.TileType<ExampleDoorClosed>()) {
						score++;
					}

					if (Main.tile[x, y].WallType == ModContent.WallType<ExampleWall>()) {
						score++;
					}
				}
			}

			return score >= ((right - left) * (bottom - top)) / 2;
		}*/

		public override ITownNPCProfile TownNPCProfile() {
			return new SupplierProfile();
		}

		public override List<string> SetNPCNameList() {
			return new List<string>() {
				"****",
				"***",
				"******",
				"*****"
			};
		}

		public override void FindFrame(int frameHeight) {
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat() {
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int demolitionist = NPC.FindFirstNPC(NPCID.Demolitionist);
			if (demolitionist >= 0 && Main.rand.NextBool(20))
			{
				chat.Add("C'mere, closer to me. Word on the street is that " + Main.npc[demolitionist].GivenName + " has a stash of illegal explosives hidden within his house.");
			}
			if (NPC.homeless && Main.rand.NextBool(3))
			{
				chat.Add("Woah, you can't just leave me out here doing my businesses for all to see!");
			}
			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add("You don't see my drug ring when you're out and about, but I assure you, they're hard at work behind the scenes.");
			chat.Add("Shhh, don't reveal me.");
			chat.Add("In about 6 days my shipments will finally arrive. What do they contain? I'm not sure... my partner in crime told me about this.");
			chat.Add("Psst...");
			chat.Add("Hey you, c'mere. I have stuff you'll definitely be interested in.");
			chat.Add("Welcome to my shop of *totally* legal goods!");
			return chat; // chat is implicitly cast to a string.
		}

		public override void SetChatButtons(ref string button, ref string button2) { // What the chat buttons are when you open up the chat UI
			button = "Illegal Trades";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				shop = true;
			}
		}

		// Shop setup
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			
			Item item = shop.item[nextSlot++];
			TradeList(item, ItemID.HeartStatue, 1);
			item = shop.item[nextSlot++];
			TradeList(item, ItemID.StarStatue, 1);
			item = shop.item[nextSlot++];
			TradeList(item, ItemID.BombStatue, 1);
			item = shop.item[nextSlot++];
			TradeList(item, ItemID.IllegalGunParts, 100);
			if (NPC.downedBoss3)   // If Skeletron has been killed, sell these
			{
				item = shop.item[nextSlot++];
				TradeList(item, ItemID.GuideVoodooDoll, 8);
				item = shop.item[nextSlot++];
				TradeList(item, ItemID.ClothierVoodooDoll, 6);
			}
			if (NPC.downedAncientCultist)
			{
				item = shop.item[nextSlot++];
				SuperTradeList(item, ItemID.LastPrism, 50);
				item = shop.item[nextSlot++];
				SuperTradeList(item, ItemID.Meowmere, 50);
				shop.item[nextSlot].prefix = PrefixID.Legendary;
				item = shop.item[nextSlot++];
				SuperTradeList(item, ItemID.SDMG, 50);
			}
			if (NPC.downedMoonlord)
			{
				item = shop.item[nextSlot++];
				SuperTradeList(item, ItemID.DrillContainmentUnit, 100);
			}

			if (Main.moonPhase == 1)
			{
				shop.item[nextSlot].SetDefaults(ItemID.ShadowDye);
			}

			if (Main.rand.NextBool(5))
			{
				shop.item[nextSlot].SetDefaults(ItemID.Toilet);
			}
		}

		private static void TradeList(Item item, int type, int price = 10)
        {
			item.SetDefaults(type);
			item.shopSpecialCurrency = YeeHaw.TradeTokenID;
			item.shopCustomPrice = price;
		}

		private static void SuperTradeList(Item item, int type, int price = 10)
		{
			item.SetDefaults(type);
			item.shopSpecialCurrency = YeeHaw.SuperTradeTokenID;
			item.shopCustomPrice = price;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Consumables.IED>(), 2));
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toKingStatue) => true;

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		/*		public override void OnGoToStatue(bool toKingStatue) {
					if (Main.netMode == NetmodeID.Server) {
						ModPacket packet = Mod.GetPacket();
						packet.Write((byte)YeeHaw.MessageType.ExampleTeleportToStatue);
						packet.Write((byte)NPC.whoAmI);
						packet.Send();
					}
					else {
						StatueTeleport();
					}
				}*/

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}

				Dust.NewDustPerfect(NPC.Center + position, DustID.Smoke, Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			if (!Main.hardMode)
			{
				damage = 15;
				knockback = 4f;
			}
			else
			{
				damage = 30;
				knockback = 4f;
			}
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
			item = ItemID.Handgun;
			scale = 0.85f;
			closeness = 1;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
			projType = ProjectileID.Bullet;
			attackDelay = 3;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
			if (!Main.hardMode)
			{
				multiplier = 10f;
				randomOffset = 0.5f;
			}

			else
			{
				multiplier = 12f;
				randomOffset = 0f;
			}
		}

        public class SupplierProfile : ITownNPCProfile
		{
			public int RollVariation() => 0;
			public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

			public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc) {
				if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
					return ModContent.Request<Texture2D>("YeeHaw/NPCs/Town/Supplier");

				if (npc.altTexture == 1)
					return ModContent.Request<Texture2D>("YeeHaw/NPCs/Town/Supplier_Party");

				return ModContent.Request<Texture2D>("YeeHaw/NPCs/Town/Supplier");
			}

			public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("YeeHaw/NPCs/Town/Supplier_Head");
		}
	} 
}
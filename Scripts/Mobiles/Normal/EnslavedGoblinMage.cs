using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("an goblin corpse")]
    public class EnslavedGoblinMage : BaseCreature
    {
        [Constructable]
        public EnslavedGoblinMage()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            this.Name = "Enslaved Goblin Mage";
            this.Body = 334;
            this.BaseSoundID = 0x45A;

            this.SetStr(297, 297);
            this.SetDex(94, 94);
            this.SetInt(510, 510);

            this.SetHits(174, 174);
            this.SetStam(94, 94);
            this.SetMana(510, 510);

            this.SetDamage(5, 7);

            this.SetDamageType(ResistanceType.Physical, 100);

            this.SetResistance(ResistanceType.Physical, 22, 22);
            this.SetResistance(ResistanceType.Fire, 36, 37);
            this.SetResistance(ResistanceType.Cold, 39, 39);
            this.SetResistance(ResistanceType.Poison, 43, 43);
            this.SetResistance(ResistanceType.Energy, 14, 14);

            this.SetSkill(SkillName.MagicResist, 121.6, 149.7);
            this.SetSkill(SkillName.Tactics, 80.0, 85.2);
            this.SetSkill(SkillName.Anatomy, 82.0, 86.6);
            this.SetSkill(SkillName.Wrestling, 99.2, 106.4);

            this.Fame = 1500;
            this.Karma = -1500;

            this.VirtualArmor = 28;

            // Loot - 30-40gold, magicitem,gem,goblin blood, essence control
            switch ( Utility.Random(20) )
            {
                case 0:
                    this.PackItem(new Scimitar());
                    break;
                case 1:
                    this.PackItem(new Katana());
                    break;
                case 2:
                    this.PackItem(new WarMace());
                    break;
                case 3:
                    this.PackItem(new WarHammer());
                    break;
                case 4:
                    this.PackItem(new Kryss());
                    break;
                case 5:
                    this.PackItem(new Pitchfork());
                    break;
            }

            this.PackItem(new ThighBoots());

            switch ( Utility.Random(3) )
            {
                case 0:
                    this.PackItem(new Ribs());
                    break;
                case 1:
                    this.PackItem(new Shaft());
                    break;
                case 2:
                    this.PackItem(new Candle());
                    break;
            }

            if (0.2 > Utility.RandomDouble())
                this.PackItem(new BolaBall());
        }

        public EnslavedGoblinMage(Serial serial)
            : base(serial)
        {
        }

        public override bool CanRummageCorpses
        {
            get
            {
                return true;
            }
        }
        public override int TreasureMapLevel
        {
            get
            {
                return 1;
            }
        }
        public override int Meat
        {
            get
            {
                return 1;
            }
        }
        public override OppositionGroup OppositionGroup
        {
            get
            {
                return OppositionGroup.SavagesAndOrcs;
            }
        }

        public override void GenerateLoot()
        {
            this.AddLoot(LootPack.Meager);
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
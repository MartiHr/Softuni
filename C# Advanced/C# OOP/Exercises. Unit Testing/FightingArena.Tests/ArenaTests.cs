using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Gosho", 50, 50);
        }

        [Test]
        public void Ctor_ProperInitialization()
        {
            Assert.AreEqual(arena.Count, 0);
            Assert.That(arena, Is.Not.EqualTo(null));
        }

        [Test]
        public void Enroll_UniqueWarrior()
        {
            arena.Enroll(warrior);
            Assert.That(arena.Count, Is.EqualTo(1));
        }

        [Test]
        public void Enroll_ExistingWarrior()
        {
            arena.Enroll(warrior);
            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(null, "Gosho")]
        [TestCase("Gosho", null)]
        public void Fight_MissingWarriors(string attackerName, string defenderName)
        {
            arena.Enroll(new Warrior("Gosho", 50, 50));
            Assert.That(() => arena.Fight(attackerName, defenderName), Throws.InvalidOperationException);
        }

        [Test]
        public void Fight_Executes()
        {
            Warrior attacker = new Warrior("Gosho", 100, 50);
            Warrior defender = new Warrior("Tosho", 50, 50);
            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight(attacker.Name, defender.Name);

            Assert.That(defender.HP, Is.EqualTo(0));
            Assert.That(attacker.HP, Is.LessThan(50));
        }
    }
}

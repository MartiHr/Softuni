using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Gosho", 20, 50);
        }

        [Test]
        public void Ctor_ProperInitialization()
        {
            Assert.AreEqual(warrior.Name, "Gosho");
            Assert.AreEqual(warrior.Damage, 20);
            Assert.AreEqual(warrior.HP, 50);
        }

        [Test]
        [TestCase("", 20, 50)]
        [TestCase(null, 20, 50)]
        [TestCase("Gosho", -5, 50)]
        [TestCase("Gosho", 20, -5)]
        public void Ctor_ImproperInitialization(string name, int damage, int HP)
        {
            Assert.That(() => new Warrior(name, damage, HP), Throws.ArgumentException);
        }

        [Test]
        [TestCase("Gosho", 20, 20, "Pesho", 20, 40)]
        [TestCase("Gosho", 20, 40, "Pesho", 20, 20)]
        [TestCase("Gosho", 20, 50, "Pesho", 60, 40)]
        public void Attack_NotAbleTo(string name1, int damage1, int HP1, string name2, int damage2, int HP2)
        {
            Warrior warrior1 = new Warrior(name1, damage1, HP1);
            Warrior warrior2 = new Warrior(name2, damage2, HP2);
            Assert.That(() => warrior1.Attack(warrior2), Throws.InvalidOperationException);
        }

        [Test]
        public void Attack_MoreDamageThanEnemyHP()
        {
            warrior = new Warrior("Gosho", 1000, 1000);
            var enemyWarrior = new Warrior("Tosho", 100, 100);

            warrior.Attack(enemyWarrior);
            Assert.AreEqual(warrior.HP, 900);
            Assert.AreEqual(enemyWarrior.HP, 0);
        }
        
        [Test]
        public void Attack_LessDamageThanEnemyHP()
        {
            warrior = new Warrior("Gosho", 60, 150);
            var enemyWarrior = new Warrior("Tosho", 40, 150);

            warrior.Attack(enemyWarrior);
            warrior.Attack(enemyWarrior);
            Assert.AreEqual(warrior.HP, 70);
            Assert.AreEqual(enemyWarrior.HP, 30);
        }
    }
}
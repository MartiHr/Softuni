using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase database;

        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void Ctor_ProperInitialization()
        {
            var people = new ExtendedDatabase.Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new ExtendedDatabase.Person(i, i.ToString());
            }

            database = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.AreEqual(database.Count, people.Length);
        }


        [Test]
        public void Ctor_ImproperInitialization()
        {
            var people = new ExtendedDatabase.Person[17];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new ExtendedDatabase.Person(i, i.ToString());
            }

            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(people), Throws.ArgumentException);
        }

        [Test]
        public void Add_UniqueUser()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(123, "123"));

            Assert.AreEqual(database.Count, 1);
        }

        [Test]
        public void Add_ExceedingUser()
        {
            var people = new ExtendedDatabase.Person[16];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new ExtendedDatabase.Person(i, i.ToString());
            }

            database = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(() => database.Add(new ExtendedDatabase.Person(100, "100")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_UserWithExistingUsername()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(1, "123"));
            Assert.That(() => database.Add(new ExtendedDatabase.Person(2, "123")), Throws.InvalidOperationException);
        }

        [Test]
        public void Add_UserWithExistingId()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            database.Add(new ExtendedDatabase.Person(1, "1"));
            Assert.That(() => database.Add(new ExtendedDatabase.Person(1, "2")), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_FromEmptyDatabase()
        {
            database = new ExtendedDatabase.ExtendedDatabase();
            
            Assert.That(() => database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_FromNotEmptyDatabase()
        {
            database = new ExtendedDatabase.ExtendedDatabase(new ExtendedDatabase.Person(1, "123"));
            database.Remove();
            Assert.AreEqual(database.Count, 0);
        }

        [Test]
        public void FindByUsername_EmptyUserParameter()
        {
            Assert.That(() => database.FindByUsername(string.Empty), Throws.ArgumentNullException);
            Assert.That(() => database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsername_NoUserIsPresent()
        {
            database.Add(new ExtendedDatabase.Person(1, "1"));
            Assert.That(() => database.FindByUsername("Gosho"), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsername_UserIsPresent()
        {
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(1, "1");
            database.Add(person);
            Assert.AreEqual(database.FindByUsername(person.UserName), person);
        }

        [Test]
        public void FindById_UserIsPresent()
        {
            ExtendedDatabase.Person person = new ExtendedDatabase.Person(1, "1");
            database.Add(person);
            Assert.AreEqual(database.FindById(person.Id), person);
        }
       
        [Test]
        public void FindById_NoUserIsPresent()
        {
            database.Add(new ExtendedDatabase.Person(1, "1"));
            Assert.That(() => database.FindById(5), Throws.InvalidOperationException);
        }

        [Test]
        public void FindById_IdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }

    }
}
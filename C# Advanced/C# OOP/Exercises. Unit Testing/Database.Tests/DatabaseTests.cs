using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database dataBase;

        [SetUp]
        public void Initialize()
        {
            dataBase = new Database.Database();
        }

        [Test]
        public void SizeOfTheArrayIs16IntegersLong()
        {
            int[] dataArr = new int[16];

            for (int i = 0; i < 15; i++)
            {
                dataArr[i] = 0;
            }

            dataBase = new Database.Database(dataArr);
            Assert.AreEqual(dataBase.Count, 16);
        }

        [Test]
        public void SizeOfTheArrayIsNot16IntegersLong()
        {
            int[] dataArr = new int[17];

            for (int i = 0; i < 16; i++)
            {
                dataArr[i] = 0;
            }

            Assert.That(() => dataBase = new Database.Database(dataArr), Throws.InvalidOperationException);
        }

        [Test]
        public void AddAnElementAtTheNextFreeCell()
        {
            dataBase.Add(0);

            Assert.AreEqual(dataBase.Count, 1);
        }

        [Test]
        public void CannotAddAnElementAtTheNextFreeCell()
        {
            int[] dataArr = new int[16];

            for (int i = 0; i < 15; i++)
            {
                dataArr[i] = 0;
            }

            dataBase = new Database.Database(dataArr);
            Assert.That(() => dataBase.Add(0), Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveElementAtLastIndex()
        {
            dataBase = new Database.Database(1);
            dataBase.Remove();
            Assert.That(dataBase.Count, Is.EqualTo(0));
        }

        [Test]
        public void CannotRemoveElementAtLastIndex()
        {
            Assert.That(() => dataBase.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void FetchReturnsArray()
        {
            dataBase = new Database.Database(1);
            Assert.AreEqual(dataBase.Fetch(), new int[] { 1 });
        }
    }
}
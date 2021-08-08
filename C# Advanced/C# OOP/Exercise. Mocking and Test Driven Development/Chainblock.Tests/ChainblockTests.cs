using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chainblock.Tests
{
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void SetUp()
        {
            //1
            this.chainblock = new Chainblock();
        }

        [TearDown]
        public void Clear()
        {
            //3
            this.chainblock = null;
        }

        [TestCaseSource(nameof(GetTransactionsForAdd))]
        public void AddMethodShouldAddOnlyUniqueValues(
            List<ITransaction> transactions, int expetedCount)
        {
            foreach (var transaction in transactions)
            {
                this.chainblock.Add(transaction);
            }

            Assert.AreEqual(this.chainblock.Count, expetedCount);
        }

        [TestCaseSource(nameof(GetTransactionForContainsMethod))]
        public void ContainsShouldReturnTrueIfTransactionExists(
            List<ITransaction> transactions, 
            ITransaction targetTransaction,
            bool exist)
        {
            //2
            foreach (var transaction in transactions)
            {
                this.chainblock.Add(transaction);
            }

            bool doesExist = this.chainblock.Contains(targetTransaction);

            Assert.IsTrue(doesExist == exist);
        }

        [TestCaseSource(nameof(GetTransactionForChangeTransactionStatus))]
        public void ChangeTransactionStatusShouldChangeStatusForValidId(
            List<ITransaction> transactions,
            int id,
            TransactionStatus newStatus)
        {
            // Arrange
            foreach (var transaction in transactions)
            {
                this.chainblock.Add(transaction);
            }

            //Act
            this.chainblock.ChangeTransactionStatus(id, newStatus);

            //Assert
            ITransaction myTransaction = this.chainblock.GetById(id);
            Assert.AreEqual(myTransaction.Status, newStatus);
        }
        
        //Empty Collection -> id = 1 -> get exception
        //Collection with 2 records -> id = 240 -> get exception
        [TestCaseSource(nameof(GetTransactionInvalidId))]
        public void ChangeTransactionStatusShouldThrowExceptionForInvalidId(
            IEnumerable<ITransaction> transactions,
            int id)
        {
            foreach (var transaction in transactions)
            {
                this.chainblock.Add(transaction);
            }

            Assert.Throws<ArgumentException>(() => this.chainblock
                .ChangeTransactionStatus(id, TransactionStatus.Aborted));
        }

        private static IEnumerable<TestCaseData> GetTransactionInvalidId()
        {
            yield return new TestCaseData(
                new List<ITransaction>
                {

                },
                25);

            yield return new TestCaseData(
                new List<ITransaction>
                {
                    new Transaction
                    {
                        Id = 5,
                        Status = TransactionStatus.Aborted,
                        From = "Kiro",
                        To = "Stoyan",
                        Amount = 300
                    }
                },
                124)
                .SetName("Transaction5");
        }

        private static IEnumerable<TestCaseData> GetTransactionForChangeTransactionStatus()
        {
            yield return new TestCaseData(
                new List<ITransaction>
                {
                    new Transaction
                    {
                        Id = 1,
                        Status = TransactionStatus.Aborted,
                        From = "Gosho",
                        To = "Pesho",
                        Amount = 500,
                    },
                    new Transaction
                    {
                        Id = 2,
                        Status = TransactionStatus.Failed,
                        From = "Kiro",
                        To = "Nasko",
                        Amount = 2500,
                    }
                },
                2,
                TransactionStatus.Successfull);
        }

        private static IEnumerable<TestCaseData> GetTransactionForContainsMethod()
        {
            // EmptyCollection -> false
            yield return new TestCaseData(
                new List<ITransaction>
                {

                },
                new Transaction
                {
                    Id = 14,
                    Status = TransactionStatus.Aborted,
                    From = "test",
                    To = "new test",
                    Amount = 304
                }, 
                false);

            // Add 2 records -> 1 exists -> true
            yield return new TestCaseData(
                new List<ITransaction>
                {
                    new Transaction
                    {
                        Id = 5,
                        Status = TransactionStatus.Successfull,
                        From = "dasda",
                        To = "aaaa",
                        Amount = 10
                    },
                    new Transaction
                    {
                        Id = 1,
                        Status = TransactionStatus.Aborted,
                        From = "gghgdd",
                        To = "aafdsfsaa",
                        Amount = 105
                    }
                },
                new Transaction
                {
                    Id = 5,
                    Status = TransactionStatus.Successfull,
                    From = "dasda",
                    To = "aaaa",
                    Amount = 10
                },
                true);
        }

        private static IEnumerable<TestCaseData> GetTransactionsForAdd()
        {
            yield return new TestCaseData(
                new List<ITransaction>
                {
                    new Transaction
                    {
                        Id = 1,
                        Status = TransactionStatus.Successfull,
                        From = "FromTest",
                        To = "ToTest",
                        Amount = 250
                    },
                    new Transaction
                    {
                        Id = 2,
                        Status = TransactionStatus.Aborted,
                        From = "BgTest",
                        To = "EnTest",
                        Amount = 50
                    },
                    new Transaction
                    {
                        Id = 1,
                        Status = TransactionStatus.Unauthorized,
                        From = "Niki",
                        To = "Stoyan",
                        Amount = 1550
                    }
                }, 
                2)
                .SetName("Test1");
        }
    }
}


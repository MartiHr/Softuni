// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

	[TestFixture]
	public class StageTests
	{
		private Stage stage;

		[SetUp]
		public void SetUp()
        {
			stage = new Stage();
        }

		[Test]
	    public void Ctor_ProperInitialization()
	    {
			stage = new Stage();

			Assert.AreNotEqual(stage.Performers, null);
		}

		[Test]
		public void Performers_GetterMethod()
		{
			Assert.AreNotEqual(stage.Performers, null);
		}

		[Test]
		public void AddPerformer_PerformerIsNull()
		{
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}

		[Test]
		public void AddPerformer_PerformerAgeIsBellow18()
		{
			Performer performer = new Performer("Gosho", "Petkov", 10);
			Assert.That(() => stage.AddPerformer(performer), Throws.ArgumentException);
		}

		[Test]
		public void AddPerformer_ValidPerformer()
		{
			Performer performer = new Performer("Gosho", "Chuka", 21);
			stage.AddPerformer(performer);

			Assert.AreEqual(stage.Performers.Count, 1);
		}

		[Test]
		public void AddSong_SongIsNull()
		{
			Assert.That(() => stage.AddSong(null), Throws.ArgumentNullException);
		}

		[Test]
		public void AddSong_DurationIsLessThanAMinute()
		{
			TimeSpan timeSpan = new TimeSpan(0, 0, 1);
			Song song = new Song("Rickroll", timeSpan);
			Assert.That(() => stage.AddSong(song), Throws.ArgumentException);
		}

		[Test]
		public void AddSong_Valid()
		{
			TimeSpan timeSpan = new TimeSpan(0, 2, 1);
			Song song = new Song("Unravel", timeSpan);
			stage.AddSong(song);
			Performer performer = new Performer("Gosho", "Chuka", 21);

			stage.AddSongToPerformer(song.Name, performer.FullName);
		}

		[Test]
		public void AddSongToPerformer_HasNullParameters()
        {
			Assert.That(() => stage.AddSong(null), Throws.ArgumentNullException);
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}

		[Test]
		public void AddSongToPerformer_GetsCorrectPerformer()
		{
			Assert.That(() => stage.AddSong(null), Throws.ArgumentNullException);
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}
	}
}
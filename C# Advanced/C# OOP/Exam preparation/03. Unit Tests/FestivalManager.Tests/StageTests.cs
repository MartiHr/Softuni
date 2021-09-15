// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		private Stage stage;

		[Test]
	    public void Ctor_ProperInit()
	    {
			Stage stage = new Stage();
			Assert.AreNotEqual(null, stage.Performers);
			Assert.DoesNotThrow(() => stage.AddSong(new Song("Gosho", new TimeSpan(1, 0, 0))));
		}

		[Test]
		public void Ctor_ImproperInit()
        {
			Assert.Throws<NullReferenceException>(() => stage.Performers.GetEnumerator());
        }

		[Test]
		public void AddPerformer_Properly()
        {
			Stage stage = new Stage();
			stage.AddPerformer(new Performer("Gosho", "Petkov", 20));

			Assert.AreEqual(1, stage.Performers.Count);
		}

		[Test]
		public void AddPerformer_Null()
		{
			Stage stage = new Stage();
			Assert.That(() => stage.AddPerformer(null), Throws.ArgumentNullException);
		}

		[Test]
		public void AddPerformer_SmallerThan18()
		{
			Stage stage = new Stage();
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Gosho", "Petkov", 15)));
		}

		[Test]
		public void AddSong_Null()
        {
			Stage stage = new Stage();

			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }

		[Test]
		public void AddSong_SmallSong()
		{
			Stage stage = new Stage();
			Song song = new Song("RickRoll", new TimeSpan(0, 0, 30));

			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}

		[Test]
		public void AddSong_Properply()
		{
			Stage stage = new Stage();
			Song song = new Song("RickRoll", new TimeSpan(0, 1, 30));
			stage.AddSong(song);
			Performer performer = new Performer("Gosho", "Petkov", 20);
			stage.AddPerformer(performer);

			stage.AddSongToPerformer(song.Name, performer.FullName);

			Performer performerToCheck = stage.Performers.FirstOrDefault(x => x.FullName == performer.FullName);

			Assert.AreEqual(1, performerToCheck.SongList.Count);
		}

		[Test]
		public void AddSongToPerformer_Properly()
        {
			Stage stage = new Stage();
			Song song = new Song("RickRoll", new TimeSpan(0, 1, 30));
			stage.AddSong(song);
			Performer performer = new Performer("Gosho", "Petkov", 20);
			stage.AddPerformer(performer);

			stage.AddSongToPerformer(song.Name, performer.FullName);

			Performer performerToCheck = stage.Performers.FirstOrDefault(x => x.FullName == performer.FullName);

			Assert.AreNotEqual(null, performerToCheck);
		}

		[Test]
		public void AddSongToPerformer_SongIsNull()
		{
			Stage stage = new Stage();
			
			Performer performer = new Performer("Gosho", "Petkov", 20);
			stage.AddPerformer(performer);

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, performer.FullName));
		}

		[Test]
		public void AddSongToPerformer_PerformerIsNull()
		{
			Stage stage = new Stage();

			Song song = new Song("RickRoll", new TimeSpan(0, 1, 30));
			stage.AddSong(song);

			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(song.Name, null));
		}

		[Test]
		public void Play_Properly()
		{
			Stage stage = new Stage();

			Song song = new Song("RickRoll", new TimeSpan(0, 1, 30));
			stage.AddSong(song);
			Performer performer = new Performer("Gosho", "Petkov", 20);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer(song.Name, performer.FullName);

			string expectedMessage = "1 performers played 1 songs";
			Assert.AreEqual(expectedMessage, stage.Play());
		}
		
	}
}
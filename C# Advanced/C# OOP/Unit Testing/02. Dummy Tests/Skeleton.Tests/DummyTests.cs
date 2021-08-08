using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void InitializeAxe()
    {
        dummy = new Dummy(20, 10);
    }

    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        dummy.TakeAttack(10);

        Assert.AreEqual(dummy.Health, 10);
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        dummy.TakeAttack(20);

        Assert.That(() => dummy.TakeAttack(10), Throws.InvalidOperationException.With
            .Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        dummy.TakeAttack(20);

        Assert.AreEqual(dummy.GiveExperience(), 10);
    }

    [Test]
    public void AliveDummyCannotGiveXP()
    {
        Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With
            .Message.EqualTo("Target is not dead."));
    }
}

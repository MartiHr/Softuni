using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void InitializeAxe()
    {
        axe = new Axe(10, 2);
        dummy = new Dummy(20, 10);
    }

    [Test]
    public void CheckAxeForLossOfDurabilityAfterAttack()
    {
        axe.Attack(dummy);
        Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe durabillity doesn't change after attack.");
    }

    [Test]
    public void TestForBrokenAxe()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.
            Message.EqualTo("Axe is broken."));
    }
}
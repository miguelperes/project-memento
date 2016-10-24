using System;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class Test_InputManager{

    [TearDown]
    public void tearDown()
    {
        InputWrapper.clearSimulatedInputs();
    }

    [Test]
    public void testAddOneSimulatedKeyOnList()
    {
        string key = "Fire1";

        InputWrapper.addSimulatedKey(key);

        Assert.IsTrue(InputWrapper.getActiveSimulatedKeys().Contains(key));
    }

    [Test]
    public void testRemoveKeyFromEmptyHash()
    {
        InputWrapper.getButtonDown("Fire1");
    }
}
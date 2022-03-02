using System.Collections;
using System.Collections.Generic;
using Assets.Game.Core.Pathfinding;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BinaryHeapTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void BinaryHeapTestsSimplePasses()
    {

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BinaryHeapTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}

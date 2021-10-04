using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using A1;

namespace A2UnitTests
{
    [TestClass]
    public class ParticleMoverTest
    {

        [TestMethod]
        public void TestBaseMovement()
        {
            ParticleMovement p = new ParticleMovement(6);

            p.GravitationalField = false;
            p.MagneticField = 1M;

            // Base movement of 3 + movement range of 6 = 9
            Assert.AreEqual(9, p.DistanceMoved);

        }

        [TestMethod]
        public void TestGravitationalFieldMovement()
        {
            ParticleMovement p = new ParticleMovement(6);

            p.MagneticField = 1M;
            p.GravitationalField = true;

            // Base movement of 3 + movement range of 6 + gravity movement of 2 = 11
            Assert.AreEqual(11, p.DistanceMoved);

        }

        [TestMethod]
        public void TestMagneticFieldMovement()
        {
            ParticleMovement p = new ParticleMovement(6);

            p.GravitationalField = false;
            p.MagneticField = 1.75M;

            // Base movement of 3 + movement range of (6 * 1.75M = 10.5 rounded to 10) = 13
            Assert.AreEqual(13, p.DistanceMoved);

        }

        [TestMethod]
        public void TestMagneticAndGravitationalFieldMovement()
        {
            ParticleMovement p = new ParticleMovement(6);

            p.GravitationalField = true;
            p.MagneticField = 1.75M;

            // Base movement of 3 + movement range of (6 * 1.75M = 10.5 rounded to 10) + gravity movement of 2 = 15 
            Assert.AreEqual(15, p.DistanceMoved);

        }
    }
}
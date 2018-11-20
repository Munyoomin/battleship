using System;
using NUnit.Framework;
namespace BattleShips
{
	public class UnitTest
	{
		[Test ()]
		public void TestOrientation ()
		{
			Ship sub = new Ship (ShipName.Submarine);
			Direction _currentdirection = new Direction ();
			_currentdirection = Direction.LeftRight;
			sub.Deployed (Direction.LeftRight, 5, 5);
			Assert.IsTrue (sub.Direction == _currentdirection);
			//Assert.IsTrue (sub.Column == 6);		 }

		[Test ()]
		public void HitTest ()
		{
			Ship testShip = new Ship (ShipName.AircraftCarrier);

			testShip.Hit ();
			testShip.Hit ();

			Assert.IsTrue (testShip.Hits == 2);		 }

		[Test ()]
		public void IsDestroyedTest ()
		{
			Ship testShip = new Ship (ShipName.AircraftCarrier);
			for (int i = 0; i < 5; i++) { testShip.Hit (); }
			bool expected = true;
			bool actual = testShip.IsDestroyed;
			Assert.AreEqual (expected, actual);		 }

		[Test ()]
		public void TestAI ()
		{
			GameController.SetDifficulty (AIOption.Hard);
			GameController.StartGame ();
			Assert.IsNotInstanceOf<AIMediumPlayer> (GameController.ComputerPlayer);
			Assert.IsInstanceOf<AIHardPlayer> (GameController.ComputerPlayer);
		}

        [Test ()]
        public void TestSetDifficulty ()
        {
            GameController.SetDifficulty (AIOption.Easy);
            Assert.AreEqual (AIOption.Easy, GameController.DifficultyOption ());

            GameController.SetDifficulty (AIOption.Medium);
            Assert.AreEqual (AIOption.Medium, GameController.DifficultyOption ());
        }

        [Test ()]
        public void TestShipColour ()
        {
            ShipColour newShip = new ShipColour ();
            newShip = ShipColour.Red;
            Assert.AreEqual (ShipColour.Red, newShip);

        }

        [Test ()]
        public void TestTile ()
        {
            Ship myShip = new Ship (ShipName.Battleship);
            Tile mytile = new Tile (3, 3, myShip);

            mytile.Shot = true;
            Assert.IsTrue (mytile.Shot);
        }
	}
}

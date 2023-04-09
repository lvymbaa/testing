using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MazeGame;

namespace MazeGameTests
{
    [TestClass]
    public class GetMapValueTest
    {
        [TestMethod]
        public void GetMapValueFilled()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[1, 2] = 2;

            int result = game.GetMapValue(game.data.map, new MapLocation(1, 2));
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void GetMapValueEmpty()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[1, 2] = 2;

            int result = game.GetMapValue(game.data.map, new MapLocation(1, 1));
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void GetMapValueOutsideBounds()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[1, 2] = 2;

            int result = game.GetMapValue(game.data.map, new MapLocation(10, 10));
            Assert.AreEqual(-1, result);
        }
    }


    [TestClass]
    public class SetMapValueTest
    {
        [TestMethod]
        public void SetMapValueInsideBounds()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            bool res = game.SetMapValue(game.data.map, new MapLocation(1, 2), 2);

            int result = game.data.map.gridArray[1, 2];
            Assert.AreEqual(2, result);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void SetMapValueOutsideBounds()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            bool res = game.SetMapValue(game.data.map, new MapLocation(100, 100), 2);

            Assert.AreEqual(false, res);
        }
    }



    [TestClass]
    public class GetPathTest
    {
        [TestMethod]
        public void GetPathAny()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[0, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;

            List<Node> path = game.GetPath(new MapLocation(0, 0), new MapLocation(0, 2), game.data);
            List<MapLocation> result = new List<MapLocation>();
            foreach (Node p in path)
            {
                result.Add(p.pos);
            }
            List<MapLocation> expectedPath = new List<MapLocation>();
            expectedPath.Add(new MapLocation(0, 2));
            expectedPath.Add(new MapLocation(1, 2));
            expectedPath.Add(new MapLocation(2, 2));
            expectedPath.Add(new MapLocation(2, 1));
            expectedPath.Add(new MapLocation(2, 0));
            expectedPath.Add(new MapLocation(1, 0));
            expectedPath.Add(new MapLocation(0, 0));

            bool listsEqual = expectedPath.SequenceEqual(result);
            Assert.AreEqual(listsEqual, true);
        }
        [TestMethod]
        public void GetPathShortest()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 5;
            game.data.width = 5;
            game.data.map = new Map(5, 5);
            game.data.map.gridArray[1, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 2] = (int)CellType.wall;
            game.data.map.gridArray[1, 3] = (int)CellType.wall;
            game.data.map.gridArray[3, 1] = (int)CellType.wall;
            game.data.map.gridArray[3, 2] = (int)CellType.wall;
            game.data.map.gridArray[3, 3] = (int)CellType.wall;

            List<Node> path = game.GetPath(new MapLocation(0, 1), new MapLocation(4, 1), game.data);
            List<MapLocation> result = new List<MapLocation>();
            foreach (Node p in path)
            {
                result.Add(p.pos);
            }
            List<MapLocation> expectedPath = new List<MapLocation>();
            expectedPath.Add(new MapLocation(4, 1));
            expectedPath.Add(new MapLocation(4, 0));
            expectedPath.Add(new MapLocation(3, 0));
            expectedPath.Add(new MapLocation(2, 0));
            expectedPath.Add(new MapLocation(1, 0));
            expectedPath.Add(new MapLocation(0, 0));
            expectedPath.Add(new MapLocation(0, 1));

            bool listsEqual = expectedPath.SequenceEqual(result);
            Assert.AreEqual(listsEqual, true);
        }
    }



    [TestClass]
    public class CalculateShortestDistanceBetweenTest
    {
        [TestMethod]
        public void CalculateShortestDistanceBetween1()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[0, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;

            int result = game.CalculateShortestDistanceBetween(new MapLocation(0, 0), new MapLocation(0, 2));

            Assert.AreEqual(6, result);
        }
        [TestMethod]
        public void CalculateShortestDistanceBetween2()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 5;
            game.data.width = 5;
            game.data.map = new Map(5, 5);
            game.data.map.gridArray[1, 0] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 2] = (int)CellType.wall;
            game.data.map.gridArray[1, 3] = (int)CellType.wall;
            game.data.map.gridArray[3, 4] = (int)CellType.wall;
            game.data.map.gridArray[3, 1] = (int)CellType.wall;
            game.data.map.gridArray[3, 2] = (int)CellType.wall;
            game.data.map.gridArray[3, 3] = (int)CellType.wall;

            int result = game.CalculateShortestDistanceBetween(new MapLocation(0, 0), new MapLocation(4, 4));

            Assert.AreEqual(16, result);
        }
    }
   


    [TestClass]
    public class ChangePlayerPositionTest
    {
        [TestMethod]
        public void ChangePlayerPositionToEmptyCell()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.data.turnAmount = 1;
            bool res = game.ChangePlayerPosition(new MapLocation(1, 0), game.data);
            int oldPosCell = game.data.map.gridArray[1, 1];
            int newPosCell = game.data.map.gridArray[1, 0];

            Assert.AreEqual((int)CellType.empty, oldPosCell);
            Assert.AreEqual((int)CellType.player, newPosCell);
            Assert.AreEqual(true, res);
            Assert.AreEqual(0, game.data.turnAmount);
        }
        [TestMethod]
        public void ChangePlayerPositionToWallCell()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.data.turnAmount = 1;
            game.data.map.gridArray[1, 0] = (int)CellType.wall;
            bool res = game.ChangePlayerPosition(new MapLocation(1, 0), game.data);
            int oldPosCell = game.data.map.gridArray[1, 1];
            int newPosCell = game.data.map.gridArray[1, 0];

            Assert.AreEqual((int)CellType.player, oldPosCell);
            Assert.AreEqual((int)CellType.wall, newPosCell);
            Assert.AreEqual(false, res);
            Assert.AreEqual(1, game.data.turnAmount);
        }
        [TestMethod]
        public void ChangePlayerPositionFromExitCell()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.playerPos = new MapLocation(1, 1);
            game.data.map.gridArray[1, 1] = (int)CellType.player;
            game.data.turnAmount = 1;
            game.data.exitPos = new MapLocation(1, 1);
            bool res = game.ChangePlayerPosition(new MapLocation(1, 0), game.data);
            int oldPosCell = game.data.map.gridArray[1, 1];
            int newPosCell = game.data.map.gridArray[1, 0];

            Assert.AreEqual((int)CellType.exit, oldPosCell);
            Assert.AreEqual((int)CellType.player, newPosCell);
            Assert.AreEqual(true, res);
            Assert.AreEqual(0, game.data.turnAmount);
        }
    }




    [TestClass]
    public class SearchTest
    {
        [TestMethod]
        public void SearchIteration()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);
            game.data.map.gridArray[0, 1] = (int)CellType.wall;
            game.data.map.gridArray[1, 1] = (int)CellType.wall;
            game.data.startNode = new Node(new MapLocation(0, 0), 0, 0, 0, null);
            game.data.goalNode = new Node(new MapLocation(0, 2), 0, 0, 0, null);
            game.data.open.Add(game.data.startNode);
            game.data.lastPos = game.data.startNode;

            game.Search(game.data.lastPos, game.data);

            List<MapLocation> expectedOpen = new List<MapLocation>();
            List<MapLocation> actualOpen = new List<MapLocation>();
            foreach (Node n in game.data.open)
            {
                actualOpen.Add(n.pos);
            }
            List<MapLocation> expectedClosed = new List<MapLocation>();
            List<MapLocation> actualClosed = new List<MapLocation>();
            foreach (Node n in game.data.closed)
            {
                actualClosed.Add(n.pos);
            }
            expectedClosed.Add(new MapLocation(0, 0));
            expectedOpen.Add(new MapLocation(1, 0));

            bool closedListsEqual = expectedClosed.SequenceEqual(actualClosed);
            bool openListsEqual = expectedOpen.SequenceEqual(actualOpen);
            Assert.AreEqual(closedListsEqual, true);
            Assert.AreEqual(openListsEqual, true);
        }
    }



    [TestClass]
    public class IsClosedTest
    {
        [TestMethod]
        public void ClosedNodeExists()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);

            game.data.closed.Add(new Node(new MapLocation(0, 0), 0, 0, 0, null));
            game.data.closed.Add(new Node(new MapLocation(2, 3), 0, 0, 0, null));
            game.data.closed.Add(new Node(new MapLocation(4, 6), 0, 0, 0, null));
            game.data.closed.Add(new Node(new MapLocation(3, 1), 0, 0, 0, null));


            Assert.AreEqual(game.IsClosed(new MapLocation(2, 3), game.data), true);

        }
        [TestMethod]
        public void ClosedNodeNotExists()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.height = 3;
            game.data.width = 3;
            game.data.map = new Map(3, 3);

            game.data.closed.Add(new Node(new MapLocation(0, 0), 0, 0, 0, null));
            game.data.closed.Add(new Node(new MapLocation(2, 3), 0, 0, 0, null));
            game.data.closed.Add(new Node(new MapLocation(4, 6), 0, 0, 0, null));
            game.data.closed.Add(new Node(new MapLocation(3, 1), 0, 0, 0, null));


            Assert.AreEqual(game.IsClosed(new MapLocation(5, 3), game.data), false);

        }
    }



    [TestClass]
    public class SetMapSizeTest
    {
        [TestMethod]
        public void SetMapSize1()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.turnAmount = 0;
            game.data.bonusTurnAmount = 1;
            game.data.level = 4;
            game.SetMapSize(game.data, game.data.level);

            Assert.AreEqual(15, game.data.height);
            Assert.AreEqual(15, game.data.width);
        }
        [TestMethod]
        public void SetMapSize2()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.turnAmount = 0;
            game.data.bonusTurnAmount = 1;
            game.data.level = 9;
            game.SetMapSize(game.data, game.data.level);

            Assert.AreEqual(25, game.data.height);
            Assert.AreEqual(25, game.data.width);
        }
    }



    [TestClass]
    public class CheckGameOverTest
    {
        [TestMethod]
        public void NotGameOverBoth()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.turnAmount = 2;
            game.data.bonusTurnAmount = 1;
            bool result = game.CheckGameOver(game.data);

            Assert.AreEqual(false, result);
        }
        public void NotGameOverBonus()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.turnAmount = 0;
            game.data.bonusTurnAmount = 1;
            bool result = game.CheckGameOver(game.data);

            Assert.AreEqual(false, result);
        }
        public void NotGameOverBase()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.turnAmount = 2;
            game.data.bonusTurnAmount = 0;
            bool result = game.CheckGameOver(game.data);

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void GameOver()
        {
            GameData data = new GameData();
            Game game = new Game(data);
            game.data.turnAmount = 0;
            game.data.bonusTurnAmount = 0;
            bool result = game.CheckGameOver(game.data);

            Assert.AreEqual(true, result);
        }
    }
}
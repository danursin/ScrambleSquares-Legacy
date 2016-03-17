using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MilitaryPuzzle.App;
using MilitaryPuzzle.App.Model;
using Newtonsoft.Json;

namespace MilitaryPuzzle.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PermutationWorks()
        {
            // Arrange
            var permutation = new[] {5, 4, 2, 7, 6, 0, 1, 3, 8};

            // Act
            var rearranged = AppMain.RearrrangeObjects(AppMain.Cards, permutation);

            // Assert
            for (var i = 0; i < 9; i++)
            {
                // Ids match permutation
                Assert.AreEqual(rearranged[i].CardId, (permutation[i] + 1));
            }
        }

        [TestMethod]
        public void IsValidWorks()
        {
            // Arrange
            var permutation = new[] { 5, 4, 2, 7, 6, 0, 1, 3, 8 };
            var rearranged = AppMain.RearrrangeObjects(AppMain.Cards, permutation);


            // Act
            rearranged[0] = AppMain.RotateRight(rearranged[0], 2);
            rearranged[1] = AppMain.RotateRight(rearranged[1], 0);
            rearranged[2] = AppMain.RotateRight(rearranged[2], 3);
            rearranged[3] = AppMain.RotateRight(rearranged[3], 2);
            rearranged[4] = AppMain.RotateRight(rearranged[4], 0);
            rearranged[5] = AppMain.RotateRight(rearranged[5], 2);
            rearranged[6] = AppMain.RotateRight(rearranged[6], 3);
            rearranged[7] = AppMain.RotateRight(rearranged[7], 0);
            rearranged[8] = AppMain.RotateRight(rearranged[8], 3);

            // Assert
            Assert.IsTrue(AppMain.IsSolved(rearranged));
        }

        [TestMethod]
        public void CanValidateSolution2()
        {
            var grid = JsonConvert.DeserializeObject<Card[]>("[{\"CardId\":3,\"Top\":{\"Direction\":1,\"MilitaryType\":1},\"Right\":{\"Direction\":1,\"MilitaryType\":3},\"Bottom\":{\"Direction\":1,\"MilitaryType\":2},\"Left\":{\"Direction\":0,\"MilitaryType\":3}},{\"CardId\":1,\"Top\":{\"Direction\":1,\"MilitaryType\":2},\"Right\":{\"Direction\":1,\"MilitaryType\":1},\"Bottom\":{\"Direction\":1,\"MilitaryType\":0},\"Left\":{\"Direction\":0,\"MilitaryType\":3}},{\"CardId\":9,\"Top\":{\"Direction\":1,\"MilitaryType\":2},\"Right\":{\"Direction\":1,\"MilitaryType\":3},\"Bottom\":{\"Direction\":0,\"MilitaryType\":0},\"Left\":{\"Direction\":0,\"MilitaryType\":1}},{\"CardId\":5,\"Top\":{\"Direction\":0,\"MilitaryType\":2},\"Right\":{\"Direction\":1,\"MilitaryType\":1},\"Bottom\":{\"Direction\":0,\"MilitaryType\":0},\"Left\":{\"Direction\":1,\"MilitaryType\":2}},{\"CardId\":7,\"Top\":{\"Direction\":0,\"MilitaryType\":0},\"Right\":{\"Direction\":1,\"MilitaryType\":3},\"Bottom\":{\"Direction\":0,\"MilitaryType\":2},\"Left\":{\"Direction\":0,\"MilitaryType\":1}},{\"CardId\":8,\"Top\":{\"Direction\":1,\"MilitaryType\":0},\"Right\":{\"Direction\":1,\"MilitaryType\":1},\"Bottom\":{\"Direction\":1,\"MilitaryType\":2},\"Left\":{\"Direction\":0,\"MilitaryType\":3}},{\"CardId\":6,\"Top\":{\"Direction\":1,\"MilitaryType\":0},\"Right\":{\"Direction\":0,\"MilitaryType\":1},\"Bottom\":{\"Direction\":0,\"MilitaryType\":3},\"Left\":{\"Direction\":1,\"MilitaryType\":0}},{\"CardId\":4,\"Top\":{\"Direction\":1,\"MilitaryType\":2},\"Right\":{\"Direction\":0,\"MilitaryType\":3},\"Bottom\":{\"Direction\":1,\"MilitaryType\":0},\"Left\":{\"Direction\":1,\"MilitaryType\":1}},{\"CardId\":2,\"Top\":{\"Direction\":0,\"MilitaryType\":2},\"Right\":{\"Direction\":0,\"MilitaryType\":0},\"Bottom\":{\"Direction\":1,\"MilitaryType\":1},\"Left\":{\"Direction\":1,\"MilitaryType\":3}}]");
            Assert.IsTrue(AppMain.IsSolved(grid));
        }

        [TestMethod]
        public void CanValidateSolution()
        {
            var grid = JsonConvert.DeserializeObject<Card[]>("[{\"CardId\":3,\"Top\":{\"Direction\":1,\"MilitaryType\":2},\"Right\":{\"Direction\":0,\"MilitaryType\":3},\"Bottom\":{\"Direction\":1,\"MilitaryType\":1},\"Left\":{\"Direction\":1,\"MilitaryType\":3}},{\"CardId\":1,\"Top\":{\"Direction\":1,\"MilitaryType\":1},\"Right\":{\"Direction\":1,\"MilitaryType\":0},\"Bottom\":{\"Direction\":0,\"MilitaryType\":3},\"Left\":{\"Direction\":1,\"MilitaryType\":2}},{\"CardId\":9,\"Top\":{\"Direction\":0,\"MilitaryType\":0},\"Right\":{\"Direction\":0,\"MilitaryType\":1},\"Bottom\":{\"Direction\":1,\"MilitaryType\":2},\"Left\":{\"Direction\":1,\"MilitaryType\":3}},{\"CardId\":5,\"Top\":{\"Direction\":1,\"MilitaryType\":2},\"Right\":{\"Direction\":0,\"MilitaryType\":2},\"Bottom\":{\"Direction\":1,\"MilitaryType\":1},\"Left\":{\"Direction\":0,\"MilitaryType\":0}},{\"CardId\":7,\"Top\":{\"Direction\":0,\"MilitaryType\":1},\"Right\":{\"Direction\":0,\"MilitaryType\":0},\"Bottom\":{\"Direction\":1,\"MilitaryType\":3},\"Left\":{\"Direction\":0,\"MilitaryType\":2}},{\"CardId\":8,\"Top\":{\"Direction\":0,\"MilitaryType\":3},\"Right\":{\"Direction\":1,\"MilitaryType\":0},\"Bottom\":{\"Direction\":1,\"MilitaryType\":1},\"Left\":{\"Direction\":1,\"MilitaryType\":2}},{\"CardId\":6,\"Top\":{\"Direction\":0,\"MilitaryType\":1},\"Right\":{\"Direction\":0,\"MilitaryType\":3},\"Bottom\":{\"Direction\":1,\"MilitaryType\":0},\"Left\":{\"Direction\":1,\"MilitaryType\":0}},{\"CardId\":4,\"Top\":{\"Direction\":0,\"MilitaryType\":3},\"Right\":{\"Direction\":1,\"MilitaryType\":0},\"Bottom\":{\"Direction\":1,\"MilitaryType\":1},\"Left\":{\"Direction\":1,\"MilitaryType\":2}},{\"CardId\":2,\"Top\":{\"Direction\":1,\"MilitaryType\":1},\"Right\":{\"Direction\":1,\"MilitaryType\":3},\"Bottom\":{\"Direction\":0,\"MilitaryType\":2},\"Left\":{\"Direction\":0,\"MilitaryType\":0}}]");
            var numberOfIterations = (int)Math.Pow(4, 9);
            var solutions = new List<string>();
            for (var it = 0; it < numberOfIterations; it++)
            {
                AppMain.ApplyCardSpins(grid, it);
                if (AppMain.IsSolved(grid))
                {
                    solutions.Add(JsonConvert.SerializeObject(grid));
                    break;
                }
            }

            Assert.IsTrue(AppMain.IsSolved(grid));
        }
    }
}

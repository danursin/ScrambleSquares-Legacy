using System;
using System.Collections.Generic;
using System.Diagnostics;
using MilitaryPuzzle.App.Logic;
using MilitaryPuzzle.App.Model;
using Newtonsoft.Json;

namespace MilitaryPuzzle.App
{
    public class AppMain
    {
        /// <summary>
        /// Cards are IDs 1-9 from 
        /// |1|2|3|
        /// |4|5|6|
        /// |7|8|9|
        /// </summary>
        public static readonly Card[] Cards = {
            // 1
            new Card
            {
                CardId = 1,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Bottom
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Bottom
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Top
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Bottom
                }
            },
            // 2
            new Card
            {
                CardId = 2,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Bottom
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Bottom
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Top
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Top
                }
            },
            // 3
            new Card
            {
                CardId = 3,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Bottom
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Top
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Bottom
                }
            },
            // 4
            new Card
            {
                CardId = 4,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Top
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Bottom
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Bottom
                }
            },
            // 5
            new Card
            {
                CardId = 5,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Bottom
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Top
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Top
                }
            },
            // 6
            new Card
            {
                CardId = 6,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Top
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Top
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Bottom
                }
            },
            // 7
            new Card
            {
                CardId = 7,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Top
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Top
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                     MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Top
                }
            },
            // 8
            new Card
            {
                CardId = 8,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Top
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Bottom
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Bottom
                }
            },
            // 9
            new Card
            {
                CardId = 9,
                Top = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern1,
                    Direction = DirectionType.Top
                },
                Right = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern2,
                    Direction = DirectionType.Top
                },
                Bottom = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern3,
                    Direction = DirectionType.Bottom
                },
                Left = new CardSideModel
                {
                    MilitaryType = PatternType.Pattern4,
                    Direction = DirectionType.Bottom
                }
            }
        };


        public static void Main(string[] args)
        {
            var test = JsonConvert.SerializeObject(Cards);
            var solutions = new List<string>();

            var numberOfIterations = (int)Math.Pow(4, 9);
            var permutedIndices = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var initialCards = Cards;
            long count = 0;
            var sw = new Stopwatch();
            sw.Start();
            while (permutedIndices != null)
            {
                var grid = RearrrangeObjects(initialCards, permutedIndices);
                for (var it = 0; it < numberOfIterations; it++)
                {
                    ApplyCardSpins(grid, it);
                    if (IsSolved(grid))
                    {
                        solutions.Add(JsonConvert.SerializeObject(grid, new JsonSerializerSettings
                        {
                            Formatting = Formatting.Indented,
                            
                        }));
                    }
                    count++;
                }

                permutedIndices = ListHelpers<int>.NextPermutation(permutedIndices);
            }
            sw.Stop();

            Console.WriteLine("Crunched {0} combinations in {1} minutes", count, sw.Elapsed.TotalMinutes);
            for (var i = 0; i < solutions.Count; i++)
            {
                Console.WriteLine("Solution {0}: {1}", (i+1), solutions[i]);
            }
            

            Console.WriteLine("Press enter to finish");
            Console.ReadLine();
        }

        public static bool SidesMatch(CardSideModel s1, CardSideModel s2)
        {
            return s1.MilitaryType == s2.MilitaryType && 
                   s1.Direction != s2.Direction;
        }

        public static bool IsSolved(Card[] grid)
        {
            /*   ___________
                |_0_|_1_|_2_|
                |_3_|_4_|_5_|
                |_6_|_7_|_8_|
            */
            return SidesMatch(grid[0].Right, grid[1].Left) &&
                   SidesMatch(grid[0].Bottom, grid[3].Top) &&
                   SidesMatch(grid[1].Bottom, grid[4].Top) && 
                   SidesMatch(grid[1].Right, grid[2].Left) &&
                   SidesMatch(grid[2].Bottom, grid[5].Top) &&
                   SidesMatch(grid[3].Right, grid[4].Left) &&
                   SidesMatch(grid[3].Bottom, grid[6].Top) &&
                   SidesMatch(grid[4].Bottom, grid[7].Top) &&
                   SidesMatch(grid[4].Right, grid[5].Left) &&
                   SidesMatch(grid[5].Bottom, grid[8].Top) &&
                   SidesMatch(grid[6].Right, grid[7].Left) && 
                   SidesMatch(grid[7].Right, grid[8].Left);
        }

        public const int Four2 = 16;
        public const int Four3 = 4 * 4 * 4;
        public const int Four4 = 4 * 4 * 4 * 4;
        public const int Four5 = 4 * 4 * 4 * 4 * 4;
        public const int Four6 = 4 * 4 * 4 * 4 * 4 * 4;
        public const int Four7 = 4 * 4 * 4 * 4 * 4 * 4 * 4;
        public const int Four8 = 4 * 4 * 4 * 4 * 4 * 4 * 4 * 4;
        public static void ApplyCardSpins(Card[] grid, int n)
        {
            grid[0] = RotateRight(grid[0], n % 4);
            grid[1] = RotateRight(grid[1], (n / 4) % 4);
            grid[2] = RotateRight(grid[2], (n / Four2) % 4);
            grid[3] = RotateRight(grid[3], (n / Four3) % 4);
            grid[4] = RotateRight(grid[4], (n / Four4) % 4);
            grid[5] = RotateRight(grid[5], (n / Four5) % 4);
            grid[6] = RotateRight(grid[6], (n / Four6) % 4);
            grid[7] = RotateRight(grid[7], (n / Four7) % 4);
            grid[8] = RotateRight(grid[8], (n / Four8) % 4);
        }

        public static Card[] RearrrangeObjects(Card[] initialCards, int[] permutedIndices)
        {
            var cards = new Card[initialCards.Length];
            for (var i = 0; i < initialCards.Length; i++)
            {
                cards[i] = initialCards[permutedIndices[i]];
            }
            return cards;
        }

        public static Card RotateRight(Card card, int n)
        {
            switch (n)
            {
                case 0:
                    return card;
                case 1:
                    return new Card
                    {
                        CardId = card.CardId,
                        Top = card.Left,
                        Right = card.Top,
                        Bottom = card.Right,
                        Left = card.Bottom
                    };
                case 2:
                    return new Card
                    {
                        CardId = card.CardId,
                        Top = card.Bottom,
                        Right = card.Left,
                        Bottom = card.Top,
                        Left = card.Right
                    };
                case 3:
                    return new Card
                    {
                        CardId = card.CardId,
                        Top = card.Right,
                        Right = card.Bottom,
                        Bottom = card.Left,
                        Left = card.Top
                    };
                default: throw new Exception("Expecting 0-3");
            }
        }
    }
}

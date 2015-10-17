using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RockPaperScissorsASP.Models;

namespace RockPaperScissorsASP
{
    public enum Winner { Player1, Player2, Both }

    public class GameSolver
    {
        public Winner Solve(Player player1, Player player2)
        {
            if (player1.Symbol == Symbol.Rock)
            {
                if (player2.Symbol == Symbol.Rock)
                {
                    return Winner.Both;
                }
                if (player2.Symbol == Symbol.Paper)
                {
                    return Winner.Player2;
                }
                if (player2.Symbol == Symbol.Scissors)
                {
                    return Winner.Player1;
                }
            }
            if (player1.Symbol == Symbol.Paper)
            {
                if (player2.Symbol == Symbol.Rock)
                {
                    return Winner.Player1;
                }
                if (player2.Symbol == Symbol.Paper)
                {
                    return Winner.Both;
                }
                if (player2.Symbol == Symbol.Scissors)
                {
                    return Winner.Player2;
                }
            }
            if (player1.Symbol == Symbol.Scissors)
            {
                if (player2.Symbol == Symbol.Rock)
                {
                    return Winner.Player2;
                }
                if (player2.Symbol == Symbol.Paper)
                {
                    return Winner.Player1;
                }
                if (player2.Symbol == Symbol.Scissors)
                {
                    return Winner.Both;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
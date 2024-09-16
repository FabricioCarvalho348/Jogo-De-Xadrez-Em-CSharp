﻿using xadrez_console.board;

namespace xadrez_console;

public class Screen
{
    public static void PrintBoard(Board board)
    {
        for (int i = 0; i < board.Lines; i++)
        {
            for (int j = 0; j < board.Columns; j++)
            {
                if (board.Piece(i, j) == null)
                {
                    Console.Write("- ");
                }
                else
                {
                    Console.WriteLine(board.Piece(i, j) + " ");
                }
            }
            Console.WriteLine();
        }
    } 
}
namespace TicTacToeGame;

public class TicTacToeGame
{
	public static readonly string X = "X";
	public static readonly string O = "O";

	private string[] board;

	public static void Main(string[] args)
	{
		TicTacToeGame game = new TicTacToeGame();
	}

	public TicTacToeGame()
	{
		int input;

		Init();

		ShowGameStartScreen();

		do
		{
			ShowBoard();

			do
			{
				ShowInputOptions();
				input = GetInput();
			}
			while (!IsValidInput(input));

			ProcessInput(input);

			UpdateGameState();
		}
		while (!IsGameOver());

		ShowGameOverScreen();
	}

	public void Init()
	{
		board = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" };
	}

	public void ShowGameStartScreen()
	{
		Console.WriteLine("Welcome to Tic-Tac-Toe!");
	}

	public void ShowBoard()
	{
		string s = "";

		s += $"{board[0]} | {board[1]} | {board[2]}\n";
		s += $"---------\n";
		s += $"{board[3]} | {board[4]} | {board[5]}\n";
		s += $"---------\n";
		s += $"{board[6]} | {board[7]} | {board[8]}\n";

		Console.WriteLine();
		Console.WriteLine(s);
	}

	public void ShowInputOptions()
	{
		Console.Write("Input any number from 0 to 8: ");
	}

	public int GetInput()
	{
		return (int.TryParse(Console.ReadLine(), out int input)) ? input : -1;
	}

	public bool IsValidInput(int input)
	{
		if (input < 0 || input > 8)
		{
			Console.WriteLine("Invalid input.");

			return false;
		}
		else if (!IsSlotEmpty(input))
		{
			Console.WriteLine("That slot has already been played.");

			return false;
		}
		else
		{
			return true;
		}
	}

	public void ProcessInput(int input)
	{
		board[input] = X;
	}

	public void UpdateGameState()
	{
		if (!IsGameOver())
		{
			Random rnd = new Random();

			int move;

			do
			{
				move = rnd.Next(board.Length);
			}
			while (!IsSlotEmpty(move));

			board[move] = O;
		}
	}

	public bool IsGameOver()
	{
		return CheckWin(X) || CheckWin(O) || CheckDraw();
	}

	public void ShowGameOverScreen()
	{
		ShowBoard();

		if (CheckWin(X))
		{
			Console.WriteLine("You won!");
		}
		else if (CheckWin(O))
		{
			Console.WriteLine("You lost!");
		}
		else
		{
			Console.WriteLine("Draw!");
		}
	}

	private bool IsSlotEmpty(int input)
	{
		return board[input] != X && board[input] != O;
	}

	private bool CheckLine(string m, int a, int b, int c)
	{
		return (board[a] == m && board[b] == m && board[c] == m);
	}

	private bool CheckWin(string m)
	{
		return
			CheckLine(m, 0, 1, 2) ||
			CheckLine(m, 3, 4, 5) ||
			CheckLine(m, 6, 7, 8) ||
			CheckLine(m, 0, 3, 6) ||
			CheckLine(m, 1, 4, 7) ||
			CheckLine(m, 2, 5, 8) ||
			CheckLine(m, 0, 4, 8) ||
			CheckLine(m, 2, 4, 6);
	}

	private bool CheckDraw()
	{
		for (int i = 0; i < board.Length; i++)
		{
			if (IsSlotEmpty(i))
			{
				return false;
			}
		}

		return true;
	}
}

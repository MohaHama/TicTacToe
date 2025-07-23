namespace TicTacToe;

public class Board
{
    private int[,] _board =
    {
        { -1, -1, -1 },
        { -1, -1, -1 },
        { -1, -1, -1 }
    };

    private bool _current = false;
    int _counter = 0;

    public int Get(int i, int j)
    {
        return _board[i, j];
    }

    public bool setMove(int row, int column)
    {
        if (_board[row, column] == -1)
        {
            _board[row, column] = Convert.ToInt32(_current);
            _current = !_current;
            _counter++;
            return true;
        }
        return false;
    }

    public bool CheckRow(int row, int val)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_board[row, i] != val)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckColumn(int column, int val)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_board[i, column] != val)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckDiagonalPrimary(int val)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_board[i, i] != val)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckDiagonalSecondary(int val)
    {
        for (int i = 0; i < 3; i++)
        {
            if (_board[i, 2-i] != val)
            {
                return false;
            }
        }
        return true;
    }

    public int CheckWinner(int i, int j)
    {
        int val = Convert.ToInt32(!_current); // The one who just played
        if (CheckRow(i, val) || CheckColumn(j, val) || CheckDiagonalPrimary(val) || CheckDiagonalSecondary(val))
        {
            return val;
        }
        return _counter == 9 ? 2 : -1;
    }


    public void Reset()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                _board[i, j] = -1;
            }
        }
        
        _current = false;
        _counter = 0;
    }
}
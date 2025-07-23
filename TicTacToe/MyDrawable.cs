namespace TicTacToe;

public class MyDrawable : IDrawable
{
    Board _board = new Board();

    public MyDrawable(Board board)
    {
        _board = board;
    }
    public void DrawO(ICanvas canvas, int i, int j)
    {
        canvas.StrokeColor = Colors.Red;
        canvas.StrokeSize = 10;
        canvas.DrawCircle(i*100+50, j*100+50, 30);
    }
    
    public void DrawX(ICanvas canvas, int i, int j)
    {
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 10;

        float x = i * 100;
        float y = j * 100;

        canvas.DrawLine(x + 20, y + 20, x + 80, y + 80); // \
        canvas.DrawLine(x + 80, y + 20, x + 20, y + 80); // /
    }

    
    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.StrokeColor = Colors.Black;
        canvas.StrokeSize = 1;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                canvas.DrawRectangle(i * 100, j * 100, 100, 100);
            }
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (_board.Get(i, j) == 0)
                {
                    DrawO(canvas, i, j);
                }
                else if (_board.Get(i, j) == 1)
                {
                    DrawX(canvas, i, j);
                }
            }
        }
    }
    
}
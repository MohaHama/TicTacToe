namespace TicTacToe;

public partial class MainPage : ContentPage
{
    Board board;
    public MainPage()
    {
        InitializeComponent();
        board = new Board(); // Initialize the board first
        graphicsView.Drawable = new MyDrawable(board);
    }

    private async void graphicView_StartInteraction(object? sender, TouchEventArgs e)
    {
        if (e.Touches.Count() > 0)
        {
            var touch = e.Touches[0];
            int x = (int)touch.X / 100;
            int y = (int)touch.Y / 100;

            if (board.setMove(x,y))
            {
                graphicsView.Invalidate();
                int winner = board.CheckWinner(x, y);
                bool reset = false;
                if (winner == 0)
                {
                    await DisplayAlert("You win!", "O is the winner!", "OK");
                    reset = true;
                }
                else if (winner == 1)
                {
                    await DisplayAlert("You win!", "X is the winner!", "OK");
                    reset = true;
                }
                else if (winner == 2)
                {
                    await DisplayAlert("Draw!", "Its a DRAW!", "OK");
                    reset = true;
                }

                if (reset)
                {
                    board.Reset();
                    graphicsView.Invalidate();
                }
            }
        }
    }
}
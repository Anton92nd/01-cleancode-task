namespace CleanCode
{
    public class Chess
    {
        private readonly Board _board;

        public Chess(Board board)
        {
            this._board = board;
        }

        public string GetWhiteStatus()
        {
            bool checkForWhite = CheckForWhite();
            bool haveMove = WhiteHaveMove();
            if (checkForWhite)
                return haveMove ? "check" : "mate";
            return haveMove ? "ok" : "stalemate";
        }

        private bool WhiteHaveMove()
        {
            bool haveMove = false;
            foreach (Loc loc in _board.Figures(Cell.White))
            {
                foreach (Loc to in _board.Get(loc).Figure.Moves(loc, _board))
                {
                    Cell performedMove = _board.PerformMove(loc, to);
                    if (!CheckForWhite())
                        haveMove = true;
                    _board.PerformUndoMove(loc, to, performedMove);
                }
            }
            return haveMove;
        }

        private bool CheckForWhite()
        {
            foreach (Loc loc in _board.Figures(Cell.Black))
            {
                var cell = _board.Get(loc);
                var moves = cell.Figure.Moves(loc, _board);
                foreach (Loc to in moves)
                {
                    if (_board.Get(to).IsWhiteKing)
                        return true;
                }
            }
            return false;
        }
    }
}
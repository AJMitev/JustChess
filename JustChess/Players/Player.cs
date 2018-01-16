namespace JustChess.Players
{
    using System;
    using System.Collections.Generic;

    using JustChess.Board;
    using JustChess.Figures.Contracts;
    using JustChess.Players.Contracts;
    using JustChess.Common;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string playerName, ChessColor color)
        {
            //TODO: Validate name length
            this.Name = playerName;
            this.figures = new List<IFigure>();
            this.Color = color;
        }

        public string Name { get; private set; }
        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure,GlobalErrorMessages.NullFigureErrorMessage);
            //TODO: check figure and player color.
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsNull(figure, GlobalErrorMessages.NullFigureErrorMessage);
            //TODO: check figure and player color.
            this.CheckIfFigureDoesNotExit(figure);
            this.figures.Remove(figure);

        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This Player already owns this figure!");
            }
        }

        private void CheckIfFigureDoesNotExit(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException("This Player does not own this figure!");
            }
        }
    }
}

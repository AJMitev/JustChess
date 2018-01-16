namespace JustChess.Renderers.Contracts
{
    using Board.Contracts;

    public interface IRenderer
    {
        void RenderMainManu();
        void RenderBoard(IBoard board);
        void PrintErrorMessage(string errorMessage);
    }
}

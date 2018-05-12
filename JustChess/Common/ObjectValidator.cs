namespace JustChess.Common
{
    using System;

    using JustChess.Board;

    public static class ObjectValidator
    {
        public static void CheckIfObjectIsNull(object obj, string error = GlobalConstants.EmptyString)
        {
            if (obj == null)
            {
                throw new NullReferenceException(GlobalErrorMessages.NullFigureErrorMessage);
            }
        }
    }
}

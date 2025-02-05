namespace QuickQuiz.QuizLogic.Exceptions
{
    public class QuizNotCompleteException : Exception
    {
        public QuizNotCompleteException(string msg)
            : base(msg) { }
    }
}

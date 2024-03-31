namespace QuickQuiz.QuizLogic.Exceptions
{
    public class ActiveQuestionNotAnsweredException : Exception
    {
        public ActiveQuestionNotAnsweredException(string msg)
            : base(msg) { }
    }
}

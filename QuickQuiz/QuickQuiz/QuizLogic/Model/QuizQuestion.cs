using QuickQuiz.QuestionLogic.Model;

namespace QuickQuiz.QuizLogic.Model
{
    public class QuizQuestion
    {
        public QuizQuestion(
            Quiz quiz,
            Question originalQuestion)
        {
            Quiz = quiz;
            OriginalQuestion = originalQuestion;
        }

        public Quiz Quiz { get; }

        public QuestionLogic.Model.Question OriginalQuestion { get; }

        public QuestionLogic.Model.Answer? PlayersAnswer { get; private set; }

        public void AnswerQuestion(
            Answer answer)
        {
            this.PlayersAnswer = answer;
        }
    }
}

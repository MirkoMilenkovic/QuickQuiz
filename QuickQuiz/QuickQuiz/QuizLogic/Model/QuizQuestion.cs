using QuickQuiz.QuestionLogic.Model;

namespace QuickQuiz.QuizLogic.Model
{
    public class QuizQuestion
    {
        public QuizQuestion(
            Quiz quiz,
            Question originalQuestion)
        {
            QuizQuestionId = Guid.NewGuid().ToString();
            Quiz = quiz;
            OriginalQuestion = originalQuestion;
        }

        public string QuizQuestionId { get; }

        public Quiz Quiz { get; }

        public QuestionLogic.Model.Question OriginalQuestion { get; }

        public QuestionLogic.Model.Answer? PlayersAnswer { get; private set; }

        public Answer AnswerQuestion(
            string answerId)
        {
            Answer? playersAnswer = null;

            // find Answer by AnswerId in OriginalQuestion
            foreach (Answer answer in OriginalQuestion.Answers)
            {
                if (answer.AnswerId == answerId)
                {
                    playersAnswer = answer;
                    break;
                }
            }

            if (playersAnswer == null)
            {
                throw new Exception($"Can not find answerId: {answerId} in question: {QuizQuestionId}");
            }

            // everything OK
            PlayersAnswer = playersAnswer;

            return PlayersAnswer;
        }
    }
}

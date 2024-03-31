using QuickQuiz.QuizLogic.Commands.GetAllQuestions.DTO;

namespace QuickQuiz.QuizLogic.Commands.GetAllQuestions
{
    public class GetAllQuestionsResponse
    {
        public GetAllQuestionsResponse(
            string quizId)
        {
            QuizId = quizId;
        }

        public string QuizId { get; }

        public List<QuestionDTO> Questions { get; } = new List<QuestionDTO>();
    }
}

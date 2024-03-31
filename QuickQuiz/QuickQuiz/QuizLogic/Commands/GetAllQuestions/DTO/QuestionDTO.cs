namespace QuickQuiz.QuizLogic.Commands.GetAllQuestions.DTO
{
    public class QuestionDTO
    {
        public QuestionDTO()
        {}

        public required string QuizQuestionId { get; init; }

        public required string Text { get; init; }

        public required AnswerDTO? PlayersAnswer { get; init; }
    }
}

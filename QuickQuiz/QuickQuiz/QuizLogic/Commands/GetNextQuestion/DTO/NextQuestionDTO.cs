namespace QuickQuiz.QuizLogic.Commands.GetNextQuestion.DTO
{
    public class NextQuestionDTO
    {
        public NextQuestionDTO()
        {}

        public required string QuizQuestionId { get; init; }

        public required string Text { get; init; }
    }
}

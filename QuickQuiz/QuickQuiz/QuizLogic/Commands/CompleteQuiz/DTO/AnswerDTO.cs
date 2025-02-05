namespace QuickQuiz.QuizLogic.Commands.CompleteQuiz.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO()
        { }

        public required string AnswerId { get; init; }

        public required string Text { get; init; }

        public required bool IsCorrect { get; init; }
    }
}

namespace QuickQuiz.QuizLogic.Commands.AnswerQuestion.DTO
{
    public class PlayersAnswerDTO
    {
        public required string AnswerId { get; init; }

        public required string Text { get; init; }

        public bool IsCorrect { get; init; }
    }
}

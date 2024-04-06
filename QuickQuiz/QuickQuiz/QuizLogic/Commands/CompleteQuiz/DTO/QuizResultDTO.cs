namespace QuickQuiz.QuizLogic.Commands.CompleteQuiz.DTO
{
    public class QuizResultDTO
    {
        public List<QuizResultItemDTO> Items { get; init; } = new();

        public required decimal ScorePercentage { get; init; }
    }
}

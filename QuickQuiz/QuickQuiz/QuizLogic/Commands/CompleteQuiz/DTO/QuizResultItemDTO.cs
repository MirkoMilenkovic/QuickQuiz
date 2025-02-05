namespace QuickQuiz.QuizLogic.Commands.CompleteQuiz.DTO
{
    public class QuizResultItemDTO
    {
        public required string QuestionText { get; init; }

        public required AnswerDTO PlayersAnswer { get; init; }

        public required AnswerDTO CorrectAnswer { get; init; }
    }
}

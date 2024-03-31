namespace QuickQuiz.QuizLogic.Commands.AnswerQuestion
{
    public class AnswerQuestionCommand
    {
        public string? QuizId { get; set; }

        public string? QuizQuestionId { get; set; }

        public string? AnswerId { get; set; }
    }
}

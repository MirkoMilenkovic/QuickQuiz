namespace QuickQuiz.QuizLogic.Commands.GetNextQuestion.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO()
        { }

        public required string AnswerId { get; init; }

        public required string Text { get; init; }
    }
}

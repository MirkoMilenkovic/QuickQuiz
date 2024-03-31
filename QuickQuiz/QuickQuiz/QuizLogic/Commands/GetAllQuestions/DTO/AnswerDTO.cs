namespace QuickQuiz.QuizLogic.Commands.GetAllQuestions.DTO
{
    public class AnswerDTO
    {
        public AnswerDTO()
        { }

        public required string AnswerId { get; init; }

        public required string Text { get; init; }
    }
}

namespace QuickQuiz.QuestionLogic.Model
{
    public class Answer
    {
        public Answer(
            string text,
            bool isCorrect)
        {
            AnswerId = Guid.NewGuid().ToString();
            Text = text;
            IsCorrect = isCorrect;
        }

        public string AnswerId { get; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}

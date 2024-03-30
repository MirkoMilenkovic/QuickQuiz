namespace QuickQuiz.QuestionLogic.Model
{
    public class Answer
    {
        public Answer(
            string text,
            bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}

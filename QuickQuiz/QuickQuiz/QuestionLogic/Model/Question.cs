namespace QuickQuiz.QuestionLogic.Model
{
    public class Question
    {
        public Question(string text)
        {
            QuestionId = Guid.NewGuid().ToString();
            Text = text;
        }

        public string QuestionId { get; }

        public string Text { get; set; }

        public List<Answer> Answers { get; private set; } = new List<Answer>();

        public void AddAnswer(
            Answer answer)
        {
            // TODO
            // Validate that only one is correct
            Answers.Add(answer);
        }

        public void Validate()
        {
            // TODO
        }
    }
}

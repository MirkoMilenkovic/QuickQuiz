namespace QuickQuiz.QuizLogic.Model
{
    public class RunningQuizes
    {
        private Dictionary<string, Quiz> QuizzesDict { get; set; } = new();

        public void AddQuiz(Quiz quiz)
        {
            this.QuizzesDict.Add(
                quiz.Id, 
                quiz);
        }
    }
}

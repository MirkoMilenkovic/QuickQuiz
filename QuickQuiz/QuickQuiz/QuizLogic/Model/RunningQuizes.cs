namespace QuickQuiz.QuizLogic.Model
{
    public class RunningQuizes
    {
        private Dictionary<string, Quiz> _quizzesDict { get; set; } = new();

        public void AddQuiz(Quiz quiz)
        {
            this._quizzesDict.Add(
                quiz.QuizId, 
                quiz);
        }

        public Quiz GetQuiz(string quizId)
        {
            _quizzesDict.TryGetValue(quizId, out var quiz);

            if(quiz == null)
            {
                throw new Exception($"Quiz {quizId} not found");
            }

            return quiz;
        }
    }
}

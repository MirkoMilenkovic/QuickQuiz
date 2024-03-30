using QuickQuiz.QuestionLogic.Model;

namespace QuickQuiz.QuizLogic.Model
{
    public class Quiz
    {
        public Quiz(string playerName)
        {
            PlayerName = playerName;

            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        public string PlayerName { get; private set; }

        public List<QuizQuestion> QuestionList { get; } = new List<QuizQuestion>();

        public static Quiz Create(
            string playerName,
            IEnumerable<Question> allQuestion)
        {
            Quiz runningQuiz = new Quiz(playerName);

            // TODO
            // Daki Random logic to choose N questions

            foreach (Question question in allQuestion)
            {
                int ms = DateTime.Now.Millisecond;
                if (IsEven(ms))
                {
                    QuizQuestion qq = new QuizQuestion(
                        runningQuiz,
                        question);

                    runningQuiz.QuestionList.Add(qq);
                }

                Random rnd = new Random();
                Thread.Sleep(rnd.Next(10));
            }

            return runningQuiz;
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
    }
}

using QuickQuiz.QuestionLogic.Model;
using QuickQuiz.QuizLogic.Exceptions;

namespace QuickQuiz.QuizLogic.Model
{
    public class Quiz
    {
        public Quiz(
            string playerName)
        {
            QuizId = Guid.NewGuid().ToString();

            PlayerName = playerName;
        }

        public string QuizId { get; private set; }

        public string PlayerName { get; private set; }

        private List<QuizQuestion> _questionList { get; } = new List<QuizQuestion>();

        public IEnumerable<QuizQuestion> QuestionListReadOnly
        {
            get
            {
                return _questionList;
            }
        }

        private QuizQuestion? _activeQuestion { get; set; }

        public static Quiz Create(
            string playerName,
            IEnumerable<Question> allQuestions)
        {
            Quiz runningQuiz = new Quiz(playerName);

            // TODO
            // Daki Random logic to choose N questions

            foreach (Question question in allQuestions)
            {
                int ms = DateTime.Now.Millisecond;
                if (IsEven(ms))
                {
                    QuizQuestion qq = new QuizQuestion(
                        runningQuiz,
                        question);

                    runningQuiz._questionList.Add(qq);
                }

                Random rnd = new Random();
                Thread.Sleep(rnd.Next(10));
            }

            return runningQuiz;
        }

        private static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        /// <summary>
        /// Get next question. If it returns null, there are no more active questions (quiz is complete).
        /// </summary>
        public QuizQuestion? GetNextQuestion()
        {
            // force player to answer question
            if (_activeQuestion != null)
            {
                // there is _activeQuestion
                if (_activeQuestion.PlayersAnswer == null)
                {
                    // it is not answered
                    throw new ActiveQuestionNotAnsweredException(
                        $"You have not answered {_activeQuestion.OriginalQuestion.Text}");
                }
            }

            //reset _activeQuestion
            _activeQuestion = null;

            // set first question that is not answered as _activeQuestion
            foreach (var qq in _questionList)
            {
                if (qq.PlayersAnswer == null)
                {
                    _activeQuestion = qq;

                    // found
                    break;
                }
            }

            // if _activeQuestion is still null, quiz is completed.
            return _activeQuestion;
        }

        /// <summary>
        /// Returns PlayersAnswer
        /// </summary>
        public Answer AnswerQuestion(
            string quizQuestionId,
            string answerId)
        {
            // validation
            if (_activeQuestion == null)
            {
                throw new Exception("There is no Active Question");
            }

            if (_activeQuestion.QuizQuestionId != quizQuestionId)
            {
                throw new Exception("You are not answering Active Question");
            }

            // END validation

            Answer playersAnswer = _activeQuestion.AnswerQuestion(
                answerId);

            return playersAnswer;
        }
    }
}

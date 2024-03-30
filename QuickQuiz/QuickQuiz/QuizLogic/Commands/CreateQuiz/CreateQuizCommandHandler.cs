using QuickQuiz.DB;
using QuickQuiz.QuizLogic.Model;

namespace QuickQuiz.QuizLogic.Commands.CreateQuiz
{
    public class CreateQuizCommandHandler
    {
        private QuizDB _quizDB;

        private RunningQuizes _runningQuizes;

        public CreateQuizCommandHandler(
            QuizDB quizDB, 
            RunningQuizes runningQuizes)
        {
            _quizDB = quizDB;
            _runningQuizes = runningQuizes;
        }

        public Quiz Create(CreateQuizCommand command)
        {
            if (String.IsNullOrWhiteSpace(command.PlayerName))
            {
                throw new Exception("Name is empty");
            }

            Quiz q = Quiz.Create(
                command.PlayerName,
                _quizDB.QuestionList);

            _runningQuizes.AddQuiz(q);

            return q;
        }
    }
}

using QuickQuiz.QuestionLogic.Model;
using QuickQuiz.QuizLogic.Model;

namespace QuickQuiz.QuizLogic.Commands.AnswerQuestion
{
    public class AnswerQuestionCommandHandler
    {
        private RunningQuizes _runningQuizes;

        public AnswerQuestionCommandHandler(
            RunningQuizes runningQuizes)
        {
            _runningQuizes = runningQuizes;
        }

        public Answer Answer(AnswerQuestionCommand command)
        {
            Quiz quiz = _runningQuizes.GetQuiz(
                command.QuizId);

            Answer playersAnswer = quiz.AnswerQuestion(
                command.QuizQuestionId,
                command.AnswerId);

            return playersAnswer;
        }
    }
}

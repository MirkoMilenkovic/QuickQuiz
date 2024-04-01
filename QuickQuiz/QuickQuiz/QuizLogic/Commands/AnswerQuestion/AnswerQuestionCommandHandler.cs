using QuickQuiz.QuestionLogic.Model;
using QuickQuiz.QuizLogic.Commands.AnswerQuestion.DTO;
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

        public PlayersAnswerDTO Answer(AnswerQuestionCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.AnswerId)
                || string.IsNullOrWhiteSpace(command.QuizQuestionId)
                || string.IsNullOrWhiteSpace(command.QuizId))
            {
                throw new Exception("stativa...");
            }

            Quiz quiz = _runningQuizes.GetQuiz(
                command.QuizId);

            Answer playersAnswer = quiz.AnswerQuestion(
                command.QuizQuestionId,
                command.AnswerId);

            PlayersAnswerDTO playersAnswerDTO = new PlayersAnswerDTO()
            {
                AnswerId = playersAnswer.AnswerId,
                Text = playersAnswer.Text,
                IsCorrect = playersAnswer.IsCorrect
            };

            return playersAnswerDTO;
        }
    }
}

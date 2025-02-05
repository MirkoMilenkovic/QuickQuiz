using QuickQuiz.QuizLogic.Commands.CompleteQuiz.DTO;
using QuickQuiz.QuizLogic.Commands.GetNextQuestion;
using QuickQuiz.QuizLogic.Exceptions;
using QuickQuiz.QuizLogic.Model;

namespace QuickQuiz.QuizLogic.Commands.CompleteQuiz
{
    public class CompleteQuizCommandHandler
    {
        private RunningQuizes _runningQuizes;

        public CompleteQuizCommandHandler(RunningQuizes runningQuizes)
        {
            _runningQuizes = runningQuizes;
        }

        public QuizResultDTO Complete(CompleteQuizCommand command)
        {
            if (String.IsNullOrWhiteSpace(command.QuizId))
            {
                throw new Exception("stativa...");
            }

            Quiz quiz = _runningQuizes.GetQuiz(
                command.QuizId);

            IEnumerable<QuizQuestion> questionList = quiz.Complete();

            QuizResultDTO quizResultDTO = new QuizResultDTO()
            {
                // dumb compiler does not see that Complete has set quiz.ScorePercentage
                ScorePercentage = quiz.ScorePercentage!.Value 
            };

            foreach (QuizQuestion quizQuestion in questionList)
            {
                AnswerDTO playersAnswerDTO = new AnswerDTO()
                {
                    // quizQuestion.PlayersAnswer can not be null,
                    // because we have validated that in Complete method.
                    // compiler is too dumb to figure it out.

                    AnswerId = quizQuestion.PlayersAnswer!.AnswerId,
                    IsCorrect = quizQuestion.PlayersAnswer!.IsCorrect,
                    Text = quizQuestion.PlayersAnswer!.Text
                };

                // find correct answer

                QuestionLogic.Model.Answer? correctAnswer = null;
                foreach (QuestionLogic.Model.Answer answer in quizQuestion.OriginalQuestion.Answers)
                {
                    if (answer.IsCorrect)
                    {
                        correctAnswer = answer;
                        break;
                    }
                }


                AnswerDTO correctAnswerDTO = new AnswerDTO()
                {
                    // assume that all questions have exactly one correct answer.
                    // this is the logic of question creation.
                    // so, correctAnswer can not be null
                    AnswerId = correctAnswer!.AnswerId,
                    IsCorrect = correctAnswer!.IsCorrect,
                    Text = correctAnswer!.Text
                };

                QuizResultItemDTO itemDTO = new QuizResultItemDTO()
                {
                    QuestionText = quizQuestion.OriginalQuestion.Text,
                    PlayersAnswer = playersAnswerDTO,
                    CorrectAnswer = correctAnswerDTO
                };

                quizResultDTO.Items.Add(
                    itemDTO);
            }

            return quizResultDTO;
        }
    }
}

using QuickQuiz.QuizLogic.Commands.GetAllQuestions.DTO;
using QuickQuiz.QuizLogic.Model;

namespace QuickQuiz.QuizLogic.Commands.GetAllQuestions
{
    public class GetAllQuestionsCommandHandler
    {
        private RunningQuizes _runningQuizes;

        public GetAllQuestionsCommandHandler(
            RunningQuizes runningQuizes)
        {
            _runningQuizes = runningQuizes;
        }

        public GetAllQuestionsResponse GetAll(GetAllQuestionsCommand command)
        {
            if (String.IsNullOrWhiteSpace(command.QuizId))
            {
                throw new Exception("stativa...");
            }

            Quiz quiz = _runningQuizes.GetQuiz(
                command.QuizId);

            IEnumerable<QuizQuestion> questionList = quiz.QuestionListReadOnly;

            GetAllQuestionsResponse response = new GetAllQuestionsResponse(
                quiz.QuizId);

            foreach (var q in questionList)
            {
                AnswerDTO answerDTO = null;
                if (q.PlayersAnswer != null)
                {
                    answerDTO = new AnswerDTO()
                    {
                        AnswerId = q.PlayersAnswer.AnswerId,
                        Text = q.PlayersAnswer.Text
                    };
                }
                QuestionDTO questionDTO = new QuestionDTO()
                {
                    QuizQuestionId = q.QuizQuestionId,
                    Text = q.OriginalQuestion.Text,
                    PlayersAnswer = answerDTO
                };

                response.Questions.Add(questionDTO);
            }

            return response;
        }
    }
}

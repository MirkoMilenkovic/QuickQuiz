using Microsoft.AspNetCore.Mvc;
using QuickQuiz.QuestionLogic.Model;
using QuickQuiz.QuizLogic.Commands.AnswerQuestion;
using QuickQuiz.QuizLogic.Commands.CreateQuiz;
using QuickQuiz.QuizLogic.Commands.GetNextQuestion;

namespace QuickQuiz.QuizLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private CreateQuizCommandHandler _createQuizCommandHandler;

        private GetNextQuestionCommandHandler _getNextQuestionCommandHandler;

        private AnswerQuestionCommandHandler _answerQuestionCommandHandler;

        public QuizController(
            CreateQuizCommandHandler createQuizCommandHandler,
            GetNextQuestionCommandHandler getNextQuestionCommandHandler,
            AnswerQuestionCommandHandler answerQuestionCommandHandler)
        {
            _createQuizCommandHandler = createQuizCommandHandler;
            _getNextQuestionCommandHandler = getNextQuestionCommandHandler;
            _answerQuestionCommandHandler = answerQuestionCommandHandler;
        }

        [HttpPost(nameof(Create))]
        public IActionResult Create([FromBody] CreateQuizCommand createQuizCommand)
        {
            if (createQuizCommand == null
                || String.IsNullOrWhiteSpace(createQuizCommand.PlayerName))
            {
                return BadRequest("stativa...");
            }

            Model.Quiz quiz = _createQuizCommandHandler.Create(createQuizCommand);

            return Ok(quiz.QuizId);
        }

        [HttpGet("GetNextQuestion/{quizId}")]
        public IActionResult GetNextQuestion(string quizId)
        {
            if (String.IsNullOrWhiteSpace(quizId))
            {
                return BadRequest("stativa...");
            }

            GetNextQuestionCommand cmd = new();
            cmd.QuizId = quizId;

            var nextQuestion = _getNextQuestionCommandHandler.GetNext(
                cmd);

            return Ok(nextQuestion);
        }

        [HttpPost(nameof(Answer))]
        public IActionResult Answer([FromBody] AnswerQuestionCommand answerQuestionCommand)
        {
            if (answerQuestionCommand == null
                || String.IsNullOrWhiteSpace(answerQuestionCommand.AnswerId)
                || String.IsNullOrWhiteSpace(answerQuestionCommand.QuizQuestionId)
                || String.IsNullOrWhiteSpace(answerQuestionCommand.QuizId))
            {
                return BadRequest("stativa...");
            }

            Answer answer = _answerQuestionCommandHandler.Answer(answerQuestionCommand);

            return Ok(answer);
        }
    }
}

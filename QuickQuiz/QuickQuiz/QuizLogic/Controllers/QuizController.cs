using Microsoft.AspNetCore.Mvc;
using QuickQuiz.QuestionLogic.Model;
using QuickQuiz.QuizLogic.Commands.AnswerQuestion;
using QuickQuiz.QuizLogic.Commands.CreateQuiz;
using QuickQuiz.QuizLogic.Commands.GetAllQuestions;
using QuickQuiz.QuizLogic.Commands.GetNextQuestion;
using QuickQuiz.QuizLogic.Commands.GetNextQuestion.DTO;

namespace QuickQuiz.QuizLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private CreateQuizCommandHandler _createQuizCommandHandler;

        private GetNextQuestionCommandHandler _getNextQuestionCommandHandler;

        private AnswerQuestionCommandHandler _answerQuestionCommandHandler;

        private GetAllQuestionsCommandHandler _getAllQuestionsCommandHandler;

        public QuizController(
            CreateQuizCommandHandler createQuizCommandHandler,
            GetNextQuestionCommandHandler getNextQuestionCommandHandler,
            AnswerQuestionCommandHandler answerQuestionCommandHandler,
            GetAllQuestionsCommandHandler getAllQuestionsCommandHandler)
        {
            _createQuizCommandHandler = createQuizCommandHandler;
            _getNextQuestionCommandHandler = getNextQuestionCommandHandler;
            _answerQuestionCommandHandler = answerQuestionCommandHandler;
            _getAllQuestionsCommandHandler = getAllQuestionsCommandHandler;
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

            NextQuestionDTO? nextQuestionDTO = _getNextQuestionCommandHandler.GetNext(
                cmd);

            if (nextQuestionDTO == null)
            {
                // no nextQuestion, quiz is completed
                return NotFound();
            }

            return Ok(nextQuestionDTO);
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

            Commands.AnswerQuestion.DTO.PlayersAnswerDTO playersAnswerDTO = _answerQuestionCommandHandler.Answer(answerQuestionCommand);

            return Ok(playersAnswerDTO);
        }

        [HttpGet("GetAllQuestions/{quizId}")]
        public IActionResult GetAllQuestions(string quizId)
        {
            if (String.IsNullOrWhiteSpace(quizId))
            {
                return BadRequest("stativa...");
            }

            GetAllQuestionsCommand cmd = new();
            cmd.QuizId = quizId;

            GetAllQuestionsResponse allQuestions = _getAllQuestionsCommandHandler.GetAll(
                cmd);

            return Ok(allQuestions);
        }
    }
}

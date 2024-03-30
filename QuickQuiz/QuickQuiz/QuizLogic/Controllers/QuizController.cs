using Microsoft.AspNetCore.Mvc;
using QuickQuiz.QuizLogic.Commands.CreateQuiz;

namespace QuickQuiz.QuizLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private CreateQuizCommandHandler _createQuizCommandHandler;

        public QuizController(CreateQuizCommandHandler createQuizCommandHandler)
        {
            _createQuizCommandHandler = createQuizCommandHandler;
        }

        [HttpPost("create")]

        public IActionResult Create([FromBody] CreateQuizCommand createQuizCommand)
        {
            if (createQuizCommand == null
                || String.IsNullOrWhiteSpace(createQuizCommand.PlayerName))
            {
                return BadRequest("stativa...");
            }

            Model.Quiz quiz = _createQuizCommandHandler.Create(createQuizCommand);

            return Ok(quiz.Id);
        }
    }
}

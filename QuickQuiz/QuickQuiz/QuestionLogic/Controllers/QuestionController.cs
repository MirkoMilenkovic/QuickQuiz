using Microsoft.AspNetCore.Mvc;
using QuickQuiz.DB;
using QuickQuiz.QuestionLogic.Model;

namespace QuickQuiz.QuestionLogic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private QuizDB _quizDB;

        public QuestionController(QuizDB quizDB)
        {
            _quizDB = quizDB;
        }

        [HttpGet("all")]
        public IEnumerable<Question> GetAll()
        {
            return _quizDB.QuestionList;
        }
    }
}

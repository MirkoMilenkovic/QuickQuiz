using QuickQuiz.QuestionLogic.Model;

namespace QuickQuiz.DB
{
    public class QuizDB
    {
        public List<Question> QuestionList { get; set; } = new List<Question>();
        public QuizDB()
        {

        }

        public void Init()
        {
            Question q = new Question("Da li je Daki som");
            q.AddAnswer(new Answer("Ne", true));
            q.AddAnswer(new Answer("Da", false));
            QuestionList.Add(q);

            q = new Question("Da li je Mis zloca");
            q.AddAnswer(new Answer("Da", true));
            q.AddAnswer(new Answer("Ne", false));
            QuestionList.Add(q);

            q = new Question("Da li je tata som");
            q.AddAnswer(new Answer("Da", true));
            q.AddAnswer(new Answer("Ne", false));
            QuestionList.Add(q);

            q = new Question("Da li je Mama bila u Beogradu");
            q.AddAnswer(new Answer("Da", true));
            q.AddAnswer(new Answer("Ne", false));
            QuestionList.Add(q);

            q = new Question("Kad je bila Kosovska bitka");
            q.AddAnswer(new Answer("1389", true));
            q.AddAnswer(new Answer("1371", false));
            q.AddAnswer(new Answer("1453", false));
            q.AddAnswer(new Answer("1345", false));
            QuestionList.Add(q);

            q = new Question("Kad je pao Carigrad");
            q.AddAnswer(new Answer("1389", false));
            q.AddAnswer(new Answer("1204", false));
            q.AddAnswer(new Answer("1453", true));
            q.AddAnswer(new Answer("1459", false));
            QuestionList.Add(q);
        }
    }
}

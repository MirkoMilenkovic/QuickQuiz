
using QuickQuiz.DB;
using QuickQuiz.QuizLogic.Commands.AnswerQuestion;
using QuickQuiz.QuizLogic.Commands.CompleteQuiz;
using QuickQuiz.QuizLogic.Commands.CreateQuiz;
using QuickQuiz.QuizLogic.Commands.GetAllQuestions;
using QuickQuiz.QuizLogic.Commands.GetNextQuestion;
using QuickQuiz.QuizLogic.Model;

namespace QuickQuiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            QuizDB dbInstance = new QuizDB();
            builder.Services.AddSingleton<QuizDB>(dbInstance);

            builder.Services.AddSingleton<CreateQuizCommandHandler>();
            builder.Services.AddSingleton<GetNextQuestionCommandHandler>();
            builder.Services.AddSingleton<AnswerQuestionCommandHandler>();
            builder.Services.AddSingleton<GetAllQuestionsCommandHandler>();
            builder.Services.AddSingleton<CompleteQuizCommandHandler>();

            builder.Services.AddSingleton<RunningQuizes>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            var quizDB = app.Services.GetRequiredService<QuizDB>();

            quizDB.Init();

            app.Run();
        }
    }
}

﻿using QuickQuiz.QuizLogic.Commands.GetAllQuestions.DTO;
using QuickQuiz.QuizLogic.Commands.GetNextQuestion.DTO;
using QuickQuiz.QuizLogic.Model;

namespace QuickQuiz.QuizLogic.Commands.GetNextQuestion
{
    public class GetNextQuestionCommandHandler
    {
        private RunningQuizes _runningQuizes;

        public GetNextQuestionCommandHandler(RunningQuizes runningQuizes)
        {
            _runningQuizes = runningQuizes;
        }

        public NextQuestionDTO? GetNext(
            GetNextQuestionCommand getNextQuestionCommand)
        {
            if(String.IsNullOrWhiteSpace(getNextQuestionCommand.QuizId))
            {
                throw new Exception("QuizId is empty");
            }

            Quiz quiz = _runningQuizes.GetQuiz(
                getNextQuestionCommand.QuizId);

            QuizQuestion? nextQuestion = quiz.GetNextQuestion();

            return nextQuestion;
        }
    }
}

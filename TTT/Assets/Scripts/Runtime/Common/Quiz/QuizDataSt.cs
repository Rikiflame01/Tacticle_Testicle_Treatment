using System;
using UnityEngine;

namespace Common
{
    [Serializable]
    public struct QuizDataSt
    {
        private QuizQuestionSO[] Questions;
        private int QuestionIndex;

        public void SetQuestionIndex(int index) => QuestionIndex = index;

        public int GetQuestionIndex() => QuestionIndex;

        public void ResetQuestionIndex() => QuestionIndex = 0;

        public void IncrementQuestionIndex() => QuestionIndex++;
        public void AddQuestion(QuizQuestionSO question) => Questions[QuestionIndex] = question;
        public void ClearQuizQuestionArray()
        {
            Questions = new QuizQuestionSO[0];
        }
        public QuizQuestionSO[] GetQuestionArray() => Questions;

        public QuizQuestionSO[] GetQuestionsInLevel(int Level)
        {
            int count = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
                if (TempQuiz.GetQuestionLevel() == Level)
                    count++;
            QuizQuestionSO[] QuestionsInLevel = new QuizQuestionSO[count];
            count = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
            {
                if (TempQuiz.GetQuestionLevel() == Level)
                {
                    QuestionsInLevel[count] = TempQuiz;
                    count++;
                }
            }
            return QuestionsInLevel;
        }
    }
}
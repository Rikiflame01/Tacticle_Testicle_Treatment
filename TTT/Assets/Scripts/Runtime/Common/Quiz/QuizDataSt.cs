using System;
using UnityEngine;

namespace Common
{
    [Serializable]
    public struct QuizDataSt
    {
        #region FIELDS
        public QuizQuestionSO[] Questions;
        public int QuestionIndex;
        #endregion FIELDS

        public void SetQuestionIndex(int index) => QuestionIndex = index;

        public int GetQuestionIndex() => QuestionIndex;

        public void ResetQuestionIndex() => QuestionIndex = 0;

        public void IncrementQuestionIndex() => QuestionIndex++;
        public void AddQuestion(QuizQuestionSO question) => Questions[QuestionIndex] = question;
        public void ClearQuizQuestionArray() => Questions = new QuizQuestionSO[100];
        public QuizQuestionSO[] GetQuestionArray() => Questions;

        public QuizQuestionSO[] GetQuestionsInLevel(int Level)
        {
            int count = 0;
            int index = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
            {
                if (TempQuiz.GetQuestionLevel() == Level)
                    count++;
                index++;
                if (Questions[index] == null)
                    break;
            }
            QuizQuestionSO[] QuestionsInLevel = new QuizQuestionSO[count];
            count = 0;
            index = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
            {
                if (TempQuiz.GetQuestionLevel() == Level)
                {
                    QuestionsInLevel[count] = TempQuiz;
                    count++;
                }
                index++;
                if (Questions[index] == null)
                    break;
            }
            return QuestionsInLevel;
        }
    }
}
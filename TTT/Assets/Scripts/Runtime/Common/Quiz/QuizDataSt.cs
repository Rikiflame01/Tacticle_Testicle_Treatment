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

        public void AddQuestionArray(QuizQuestionSO[] questions)
        {
            Questions = new QuizQuestionSO[questions.Length];
            int index = 0;
            QuestionIndex = index;
            foreach (QuizQuestionSO TempQuiz in questions)
            {
                if (questions[index] == null)
                    break;
                AddQuestion(TempQuiz);
                index++;
                QuestionIndex = index;
            }
        }

        public void ClearQuizQuestionArray() => Questions = new QuizQuestionSO[100];

        public QuizQuestionSO[] GetQuestionArray() => Questions;

        public QuizQuestionSO[] GetQuestionsInLevel(int level)
        {
            int count = 0;
            int index = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
            {
                if (TempQuiz.GetQuestionLevel() == level)
                    count++;
                index++;
            }
            QuizQuestionSO[] QuestionsInLevel = new QuizQuestionSO[count];
            index = count = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
            {
                if (Questions[index] == null)
                    break;
                if (TempQuiz.GetQuestionLevel() == level)
                {
                    QuestionsInLevel[count] = TempQuiz;
                    count++;
                }
                index++;
            }
            return QuestionsInLevel;
        }

        //For testing
        private void PrintQuestions()
        {
            int index = 0;
            foreach (QuizQuestionSO TempQuiz in Questions)
            {
                if (Questions[index] == null)
                    break;
                Debug.Log("Question: " + TempQuiz.GetQuestionText());
                index++;
            }
        }
    }
}
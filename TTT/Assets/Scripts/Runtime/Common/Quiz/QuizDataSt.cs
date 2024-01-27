using System;
using System.Collections.Generic;
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
        public void IncrementQuestionIndex()
        {
            if (QuestionIndex < Questions.Length - 1)
                QuestionIndex++;
        }

        public void AddQuestion(QuizQuestionSO question)
        {
            if (QuestionIndex < Questions.Length)
                Questions[QuestionIndex] = question;
            else
                Debug.LogError("QuestionIndex out of range.");
        }

        public void ReplaceQuestionArray(QuizQuestionSO[] questions)
        {
            Questions = new QuizQuestionSO[questions.Length];
            for (int i = 0; i < questions.Length; i++)
            {
                Questions[i] = questions[i];
            }
            QuestionIndex = 0;
        }

        public void ClearQuizQuestionArray(int size = 100) => Questions = new QuizQuestionSO[size];

        public QuizQuestionSO[] GetQuestionArray() => Questions;

        public QuizQuestionSO[] GetQuestionsInLevel(int level)
        {
            var questionsInLevel = new List<QuizQuestionSO>();
            foreach (var question in Questions)
            {
                if (question != null && question.GetQuestionLevel() == level)
                    questionsInLevel.Add(question);
            }
            return questionsInLevel.ToArray();
        }

        //For testing
        private void PrintQuestions()
        {
            foreach (var question in Questions)
            {
                if (question != null)
                    Debug.Log("Question: " + question.GetQuestionText());
            }
        }
    }
}

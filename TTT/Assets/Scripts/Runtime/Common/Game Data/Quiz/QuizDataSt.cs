using System;
using UnityEngine;

namespace Common.GameData
{
    [Serializable]
    public struct QuizDataSt
    {
        private int QuestionIndex;

        public void SetQuestionIndex(int index) => QuestionIndex = index;

        public int GetQuestionIndex() => QuestionIndex;

        public void ResetQuestionIndex() => QuestionIndex = 0;

        public void IncrementQuestionIndex() => QuestionIndex++;
    }
}
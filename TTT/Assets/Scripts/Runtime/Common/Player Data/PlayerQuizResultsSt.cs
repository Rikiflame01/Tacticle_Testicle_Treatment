using System;
using System.Collections.Generic;
using UnityEngine;

namespace TTT.Common.PlayerData
{
    [Serializable]
    public struct PlayerQuizResultsSt
    {
        #region FIELDS

        public QuizQuestionSO[] QuestionsAnswered {  get; set; }
        private int QuestionIndex;
        public int[] QuestionsAnswers {  get; set; }
        #endregion

        #region METHODS

        public void resetQuizResults()
        {
            QuestionIndex = 0;
            QuestionsAnswered = new QuizQuestionSO[0];
            QuestionsAnswers = new int[0];
        }

        public void AnswereQuestion(QuizQuestionSO Quest, int Answer)
        {
            AddQuestion(Quest);
            AddAnswer(Answer);
        }

        private void AddQuestion(QuizQuestionSO quest) => QuestionsAnswered[QuestionIndex] = quest;
        private void AddAnswer(int Ans) => QuestionsAnswers[QuestionIndex] = Ans;

        public int GetNumQuestionsAnswered() => QuestionIndex;







        #endregion
    }
}
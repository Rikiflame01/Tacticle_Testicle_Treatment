using Common;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameDataSO", menuName = "ScriptableObjects/GameDataSO", order = 90)]
    public class GameDataSO : ScriptableObject
    {
        public QuizDataSt quizDataSt;

        public void SetQuestionIndex(int index) => quizDataSt.SetQuestionIndex(index);
        public int GetQuestionIndex() => quizDataSt.GetQuestionIndex();

        public void ResetQuestions()
        {
            quizDataSt.ClearQuizQuestionArray();
            quizDataSt.ResetQuestionIndex();
        }

        public void IncrementQuestionIndex() => quizDataSt.IncrementQuestionIndex();

        public void AddQuestionToArray(QuizQuestionSO question) => quizDataSt.AddQuestion(question);

        public void AddQuestionArray(QuizQuestionSO[] questions) => quizDataSt.ReplaceQuestionArray(questions);

        public QuizQuestionSO[] GetQuizQuestionArray() => quizDataSt.GetQuestionArray();

        public QuizQuestionSO GetRandomQuestion()
        {
            QuizQuestionSO[] allQuestions = quizDataSt.GetQuestionArray();
            if (allQuestions == null || allQuestions.Length == 0)
                return null;

            int randomIndex = Random.Range(0, allQuestions.Length);
            return allQuestions[randomIndex];
        }
    }
}

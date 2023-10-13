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

        public void ResetQuestionIndex() => quizDataSt.ResetQuestionIndex();

        public void IncrementQuestionIndex() => quizDataSt.IncrementQuestionIndex();
    }
}
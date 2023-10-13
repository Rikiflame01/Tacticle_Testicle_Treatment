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
        public void AddQusetionToArray(QuizQuestionSO Quest) => quizDataSt.AddQuestion(Quest);
        public QuizQuestionSO[] GetQuizQuestionArray() => quizDataSt.GetQuestionArray();
        public QuizQuestionSO GetRandomQuestionInLevel(int level)
        {
            QuizQuestionSO[] questionSOs = quizDataSt.GetQuestionsInLevel(level);
            int tmpRnd = UnityEngine.Random.Range(0, questionSOs.Length);
            return questionSOs[tmpRnd];
        }
    }
}
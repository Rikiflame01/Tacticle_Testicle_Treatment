using UnityEngine;
[CreateAssetMenu(fileName = "GamDataSO", menuName = "ScriptableObjects/GamDataSO", order = 90)]
public class GameDataSO : ScriptableObject
{
    public QuizDataSt quizDataSt;
    
    public static void SetQuestionIndex(int index)
    {
        quizDataSt.SetQuestionIndex(index);
    }
    public static int GetQuestionIndex()
    {
        return quizDataSt.GetQuestionIndex();
    }
    public static void ResetQuestionIndex()
    {
        quizDataSt.ResetQuestionIndex();
    }
    public static void IncrementQuestionIndex()
    {
        quizDataSt.IncrementQuestionIndex();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct QuizDataSt
{
    [SerializeField] private int QuestionIndex;
    
    public static void SetQuestionIndex(int index)
    {
        QuestionIndex = index;
    }
    public static int GetQuestionIndex()
    {
        return QuestionIndex;
    }

    public static void ResetQuestionIndex()
    {
        QuestionIndex = 0;
    }
    public static void IncrementQuestionIndex()
    {
        QuestionIndex++;
    }
}

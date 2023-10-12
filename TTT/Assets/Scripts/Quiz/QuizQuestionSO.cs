using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuizQuestionSO", menuName = "ScriptableObjects/QuizQuestionSO", order = 90)]
public class QuizQuestionSO : ScriptableObject
{
    [SerializeField][TextArea] private string QuestionText;
    [SerializeField] private QuestionAnswerSt[] QuestionAnswers;
    
    public string GetQuestionText()
    {
        return QuestionText;
    }
    public QuestionAnswerSt[] GetQuestionAnswers()
    {
        return QuestionAnswers;
    }
    
    public bool IsCorrectAnswer(int index)
    {
        return QuestionAnswers[index].GetIsCorrect();
    }

}

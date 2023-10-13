using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionAnswerSt
{
    #region FIELDS

    [SerializeField] private string AnswerText;
    [SerializeField] private bool IsCorrect;

    #endregion FIELDS

    #region METHODS

    public QuestionAnswerSt(string answerText, bool isCorrect)
    {
        AnswerText = answerText;
        IsCorrect = isCorrect;
    }


    public string GetAnswerText() => AnswerText;

    public bool GetIsCorrect() => IsCorrect;

    #endregion METHODS
}
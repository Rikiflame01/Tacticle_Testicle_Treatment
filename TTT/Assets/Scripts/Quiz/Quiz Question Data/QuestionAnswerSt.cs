using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionAnswerSt
{
    #region FIELDS
        
    [SerializeField] private string AnswerText;
    [SerializeField] private bool IsCorrect;
        
    #endregion

    #region UNITY METHODS
    #endregion

    #region METHODS
        
    public string GetAnswerText()
    {
        return AnswerText;
    }
    public bool GetIsCorrect()
    {
        return IsCorrect;
    }
        
    #endregion
}
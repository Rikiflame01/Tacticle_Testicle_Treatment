using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizQuestionSO", menuName = "ScriptableObjects/QuizQuestionSO", order = 90)]
[System.Serializable]
public class QuizQuestionSO : ScriptableObject
{
    public enum QuestionType
    {
        MultipleChoice,
        TrueFalse
        // Add other types as needed
    }

    [SerializeField][TextArea] private string QuestionText;
    [SerializeField] private QuestionAnswerSt[] QuestionAnswers = new QuestionAnswerSt[4];
    [SerializeField] private QuestionType questionType;
    public int QuestionIndex;
    public int QuestionLevel;

    public string GetQuestionText() => QuestionText;

    public void SetQuestionText(string text) => QuestionText = text;

    public QuestionAnswerSt[] GetQuestionAnswers() => QuestionAnswers;

    public void SetQuestionAnswers(QuestionAnswerSt[] answers) => QuestionAnswers = answers;

    public string[] GetAnswerText()
    {
        string[] tmp = new string[QuestionAnswers.Length];
        for (int i = 0; i < QuestionAnswers.Length; i++)
        {
            tmp[i] = QuestionAnswers[i].GetAnswerText();
        }
        return tmp;
    }

    public bool IsCorrectAnswer(int index) => QuestionAnswers[index].GetIsCorrect();

    public QuestionType GetQuestionType() => questionType;

    public int GetQuestionIndex() => QuestionIndex;

    public void SetQuestionIndex(int index) => QuestionIndex = index;

    public int GetQuestionLevel() => QuestionLevel;

    public void SetQuestionLevel(int level) => QuestionLevel = level;
}

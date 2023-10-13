using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizQuestionSO : ScriptableObject
{
    [SerializeField][TextArea] private string QuestionText;
    [SerializeField] private QuestionAnswerSt[] QuestionAnswers = new QuestionAnswerSt[4];
    private int QuestionIndex;
    private int QuestionLevel;

    public string GetQuestionText() => QuestionText;

    public void SetQuestionText(string text) => QuestionText = text;

    public QuestionAnswerSt[] GetQuestionAnswers() => QuestionAnswers;

    public void SetQuestionAnswers(QuestionAnswerSt[] answers) => QuestionAnswers = answers;
    public string[] GetAnswerText()
    {
        string[] tmp = new string[4];
        tmp[0] = QuestionAnswers[0].GetAnswerText();
        tmp[1] = QuestionAnswers[1].GetAnswerText();
        tmp[2] = QuestionAnswers[2].GetAnswerText();
        tmp[3] = QuestionAnswers[3].GetAnswerText();
        return tmp;
    }

    public bool IsCorrectAnswer(int index) => QuestionAnswers[index].GetIsCorrect();

    public int GetQuestionIndex() => QuestionIndex;

    public void SetQuestionIndex(int index) => QuestionIndex = index;

    public int GetQuestionLevel() => QuestionLevel;

    public void SetQuestionLevel(int level) => QuestionLevel = level;
}
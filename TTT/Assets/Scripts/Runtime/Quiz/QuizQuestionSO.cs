using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizQuestionSO", menuName = "ScriptableObjects/QuizQuestionSO", order = 90)]
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

    public bool IsCorrectAnswer(int index) => QuestionAnswers[index].GetIsCorrect();

    public int GetQuestionIndex() => QuestionIndex;

    public void SetQuestionIndex(int index) => QuestionIndex = index;

    public int GetQuestionLevel() => QuestionLevel;

    public void SetQuestionLevel(int level) => QuestionLevel = level;
}
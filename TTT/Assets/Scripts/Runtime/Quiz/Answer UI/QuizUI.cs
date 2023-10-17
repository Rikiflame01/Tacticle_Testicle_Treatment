using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace TTT
{
    public class QuizUI : MonoBehaviour
    {
        #region FIELDS

        private TextMeshProUGUI _QuestionTestBox;
        private Button[] _AnswerButtons = new Button[4];
        private TextMeshProUGUI[] _AnswerButtonTexts = new TextMeshProUGUI[4];
        public PlayerData PlayerData;
        public GameDataSO GameData;
        public int QuestionLevel;
        private QuizQuestionSO RandomQuestion;
        private GameObject _QuizUIPanel;
        private GameObject _AnswerButtonsPanel;

        #endregion FIELDS

        #region UNITY METHODS

        private void Start()
        {
            PlayerData.Reset();
            _QuizUIPanel = GameObject.FindGameObjectWithTag("QuizPanel");
            _AnswerButtonsPanel = GameObject.FindGameObjectWithTag("AnswerButtons");
            _QuestionTestBox = _QuizUIPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            for (int i = 0; i < 4; i++)
            {
                _AnswerButtons[i] = _AnswerButtonsPanel.transform.GetChild(i).GetComponent<Button>();
                _AnswerButtonTexts[i] = _AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            }
            /*float tmpScreenHeight = Screen.height;
            float tmpScreenWidth = Screen.width;
            print(tmpScreenWidth + ", " + tmpScreenHeight);
            _AnswerButtonsPanel.GetComponent<GridLayout>() = new Vector2(tmpScreenWidth * 0.4f, tmpScreenHeight * 0.1f);
            _QuizUIPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(_QuizUIPanel.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta.x * 0.99f, tmpScreenHeight * 0.99f);
            _AnswerButtonsPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(_AnswerButtonsPanel.GetComponent<RectTransform>().sizeDelta.x, tmpScreenHeight * 0.4f);*/

            for (int i = 0; i < 4; i++)
                _AnswerButtonTexts[i] = _AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            RandomQuestion = GameData.GetRandomQuestionInLevel(QuestionLevel);
            _QuestionTestBox.text = RandomQuestion.GetQuestionText();
            string[] answers = RandomQuestion.GetAnswerText();
            for (int i = 0; i < 4; i++)
                _AnswerButtonTexts[i].text = answers[i];
        }

        #endregion UNITY METHODS

        #region METHODS

        public void AnswerButtonClicked(int index)
        {
            PlayerData.AnswereQuestion(RandomQuestion, index);
            if (RandomQuestion.IsCorrectAnswer(index))
            {
                //Add code for player buffs
                print("Correct");
            }
            else
                print("Wrong");
            /*RandomQuestion = GameData.GetRandomQuestionInLevel(QuestionLevel);
            _QuestionTestBox.text = RandomQuestion.GetQuestionText();
            string[] answers = RandomQuestion.GetAnswerText();
            for (int i = 0; i < 4; i++)
                _AnswerButtonTexts[i].text = answers[i];*/
        }

        #endregion METHODS
    }
}
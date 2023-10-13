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
        public TextMeshProUGUI QuestionTestBox;
        public Button[] AnswerButtons = new Button[4];
        private TextMeshProUGUI[] AnswerButtonTexts = new TextMeshProUGUI[4];
        public PlayerData PlayerData;
        public GameDataSO GameData;
        public int QuestionLevel;
        private QuizQuestionSO RandomQuestion;

        #endregion

        #region UNITY METHODS

        private void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                AnswerButtonTexts[i] = AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            }

            RandomQuestion = GameData.GetRandomQuestionInLevel(QuestionLevel);
            QuestionTestBox.text = RandomQuestion.GetQuestionText();
            string[] answers = RandomQuestion.GetAnswerText();
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                AnswerButtonTexts[count].text = answers[count];
                AnswerButtons[count].onClick.AddListener(() => { OnResponceClicked(responce); });

            }
        }
        #endregion

        #region METHODS




        #endregion
    }
}
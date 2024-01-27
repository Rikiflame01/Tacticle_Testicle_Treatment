using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TTT
{
    public class QuizUI : MonoBehaviour
    {
        #region FIELDS

        private TextMeshProUGUI _QuestionTestBox;
        private Button[] _AnswerButtons = new Button[4];
        private TextMeshProUGUI[] _AnswerButtonTexts = new TextMeshProUGUI[4];
        public Canvas UpgradeCanvas;
        public Button UpgradeChoice_1;
        public Button UpgradeChoice_2;
        private TextMeshProUGUI UpgradeChoice_1_Text;
        private TextMeshProUGUI UpgradeChoice_2_Text;
        public PlayerData PlayerData;
        public GameDataSO GameData;
        public AmmoSO PlayerAmmo;
        private QuizQuestionSO RandomQuestion;
        private GameObject _QuizUIPanel;
        private GameObject _AnswerButtonsPanel;
        private Scene CurrentScene;

        #endregion FIELDS

        #region UNITY METHODS
        private void Start()
        {
            CurrentScene = SceneManager.GetActiveScene();
            Debug.Log(CurrentScene.name);

            // Initialization Code
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            UpgradeChoice_1_Text = UpgradeChoice_1.GetComponentInChildren<TextMeshProUGUI>();
            UpgradeChoice_2_Text = UpgradeChoice_2.GetComponentInChildren<TextMeshProUGUI>();
            UpgradeCanvas.enabled = false;
            _QuizUIPanel = GameObject.FindGameObjectWithTag("QuizPanel");
            _AnswerButtonsPanel = GameObject.FindGameObjectWithTag("AnswerButtons");
            _QuestionTestBox = _QuizUIPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            for (int i = 0; i < _AnswerButtons.Length; i++)
            {
                _AnswerButtons[i] = _AnswerButtonsPanel.transform.GetChild(i).GetComponent<Button>();
                _AnswerButtonTexts[i] = _AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            }

            RandomQuestion = GameData.GetRandomQuestion();
            _QuestionTestBox.text = RandomQuestion.GetQuestionText();
            string[] answers = RandomQuestion.GetAnswerText();

            // Adjust UI based on question type
            int buttonCount = RandomQuestion.GetQuestionType() == QuizQuestionSO.QuestionType.TrueFalse ? 2 : 4;
            for (int i = 0; i < buttonCount; i++)
            {
                _AnswerButtonTexts[i].text = answers[i];
                _AnswerButtons[i].gameObject.SetActive(true);
            }
            for (int i = buttonCount; i < 4; i++)
            {
                _AnswerButtons[i].gameObject.SetActive(false);
            }
        }

        #endregion UNITY METHODS

        #region METHODS

        public void AnswerButtonClicked(int index)
        {
            PlayerData.AnswereQuestion(RandomQuestion, index);

            if (RandomQuestion.IsCorrectAnswer(index))
            {
                //PlayerData.IncreaseQuestionLevel();
                UpgradeCanvas.enabled = true;
                _QuizUIPanel.SetActive(false);
                BulletTypeSO choice_1;
                BulletTypeSO choice_2;
                if (PlayerAmmo.GetUniqueRandomBulletType(out BulletTypeSO tmpBullet))
                    choice_1 = tmpBullet;
                else
                    choice_1 = null;

                if (PlayerAmmo.GetUniqueRandomBulletType(out BulletTypeSO tmpBullet2))
                    choice_2 = tmpBullet2;
                else
                    choice_2 = null;

                if (choice_1 == null && choice_2 == null)
                {
                    if (CurrentScene.ToString() == "Level1")
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));
                        PlayerData.SetQuizStarted(false);
                        SceneManager.UnloadSceneAsync("quiz");
                    }
                    else if (CurrentScene.ToString() == "TesticleBossMap")
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("TesticleBossMap"));
                        PlayerData.SetQuizStarted(false);
                        SceneManager.UnloadSceneAsync("quiz");
                    }

                }

                if (choice_1 != null)
                {
                    UpgradeChoice_1_Text.text = choice_1.getBulletName();
                    UpgradeChoice_1.interactable = true;
                    UpgradeChoice_1.onClick.AddListener(() => OnBtnClicked(choice_1));
                }
                else
                {
                    UpgradeChoice_1_Text.text = "No more upgrades";
                    UpgradeChoice_1.interactable = false;
                }

                if (choice_2 != null)
                {
                    UpgradeChoice_2_Text.text = choice_2.getBulletName();
                    UpgradeChoice_2.interactable = true;
                    UpgradeChoice_2.onClick.AddListener(() => OnBtnClicked(choice_2));
                }
                else
                {
                    UpgradeChoice_2_Text.text = "No more upgrades";
                    UpgradeChoice_2.interactable = false;
                }
            }
            else
            {
                if (CurrentScene.ToString() == "Level1")
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("Level1"));
                    PlayerData.SetQuizStarted(false);
                    SceneManager.UnloadSceneAsync("quiz");
                }
                else
                    if (CurrentScene.ToString() == "TesticleBossMap")
                {
                    SceneManager.SetActiveScene(SceneManager.GetSceneByName("TesticleBossMap"));
                    PlayerData.SetQuizStarted(false);
                    SceneManager.UnloadSceneAsync("quiz");
                }

                }
            }

        private void OnBtnClicked(BulletTypeSO Choice)
        {
            PlayerAmmo.AddBulletType(Choice);
            PlayerData.InitializeAmmoSO();
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(CurrentScene.name));
            PlayerData.SetQuizStarted(false);
            SceneManager.UnloadSceneAsync("Quiz");
        }

        #endregion METHODS
    }
}
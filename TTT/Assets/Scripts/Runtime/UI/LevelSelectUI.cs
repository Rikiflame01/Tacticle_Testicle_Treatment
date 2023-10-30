using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace TTT
{
    public class LevelSelectUI : MonoBehaviour
    {
        #region FIELDS

        public PlayerData PlayerData;
        public GameObject CommingSoonPanel;
        public GameObject ChoicePanel;

        #endregion FIELDS

        #region UNITY METHODS

        private void Start()
        {
            CommingSoonPanel.SetActive(false);
            ChoicePanel.SetActive(true);
            LoadQuestions();
        }

        #endregion UNITY METHODS

        #region METHODS

        public void OnBtnClick(int level)
        {
            switch (level)
            {
                case 1:
                    PlayerData.SetCurrentLevel(1);
                    SceneManager.LoadScene("Briefing");
                    break;

                case 2:
                    PlayerData.SetCurrentLevel(2);
                    SceneManager.LoadScene("Briefing");
                    break;

                case 3:
                    StartCoroutine(ShowCommingSoonPanel());
                    break;
            }
        }

        private IEnumerator ShowCommingSoonPanel()
        {
            ChoicePanel.SetActive(false);
            CommingSoonPanel.SetActive(true);
            yield return new WaitForSeconds(2f);
            CommingSoonPanel.SetActive(false);
            ChoicePanel.SetActive(true);
        }

        private void LoadQuestions()
        {
            string path = "Assets/Scriptable Objects/Questions";
            string filter = "t:QuizQuestionSO";
            //Debug.Log("Finding assets");
            string[] guides = AssetDatabase.FindAssets(filter, new[] { path });
            //Debug.Log("Found assets of length: " + (guides.Length > 0 ? guides.Length : "No assets found"));
            QuizQuestionSO[] quizQuestionSOs = new QuizQuestionSO[guides.Length];
            int index = 0;
            foreach (string guide in guides)
            {
                var tmp = AssetDatabase.GUIDToAssetPath(guide);
                if (tmp.Contains("QuizQuestion_"))
                {
                    //Debug.Log("Found question: " + tmp);
                    quizQuestionSOs[index] = AssetDatabase.LoadAssetAtPath<QuizQuestionSO>(tmp);
                    index++;
                }
                else
                    Debug.Log("Not a question: " + tmp);
            }
            //Debug.Log("Sorting Array");
            for (int i = 0; i < quizQuestionSOs.Length; i++)
            {
                for (int j = 0; j < quizQuestionSOs.Length - 1; j++)
                {
                    if (quizQuestionSOs[j].GetQuestionIndex() > quizQuestionSOs[j + 1].GetQuestionIndex())
                    {
                        QuizQuestionSO tmp = quizQuestionSOs[j];
                        quizQuestionSOs[j] = quizQuestionSOs[j + 1];
                        quizQuestionSOs[j + 1] = tmp;
                    }
                }
            }

            #endregion METHODS
        }
    }
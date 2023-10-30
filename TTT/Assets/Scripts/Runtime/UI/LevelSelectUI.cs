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
        }

        #endregion UNITY METHODS

        #region METHODS

        public void OnBtnClick(int level)
        {
            switch (level)
            {
                case 1:
                    PlayerData.SetCurrentLevel(1);
                    SceneManager.LoadScene("Level1");
                    break;

                case 2:
                    PlayerData.SetCurrentLevel(2);
                    SceneManager.LoadScene("Level1");
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

        #endregion METHODS
    }
}
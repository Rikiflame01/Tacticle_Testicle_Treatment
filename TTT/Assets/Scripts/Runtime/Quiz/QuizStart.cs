using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UIElements.UxmlAttributeDescription;

namespace TTT
{
    public class QuizStart : MonoBehaviour
    {
        public int QuestionLevel;
        public Canvas canvas;
        public TextMeshProUGUI text;
        public PlayerData PlayerData;
        private PauseMenu pauseMenu;
        private AudioListener audioListener;
        private bool startQuiz;
        private bool used;

        private void Awake()
        {
            pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
            audioListener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
            canvas.enabled = false;
            startQuiz = false;
            used = false;
            QuestionLevel = Random.Range(1, 5);
        }

        private void Update()
        {
            if (used && !PlayerData.GetQuizStarted())
            {
                audioListener.enabled = true;
                Destroy(this);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //SceneManager.LoadSceneAsync("Quiz", LoadSceneMode.Additive);
                StartCoroutine(FadeInText());
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!startQuiz)
                    {
                        startQuiz = true;
                        PlayerData.SetQuestionLevel(QuestionLevel);
                        StartQuiz();
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //SceneManager.UnloadSceneAsync("Quiz");
                StartCoroutine(FadeOutText());
            }
        }

        public void StartQuiz()
        {
            audioListener.enabled = false;
            pauseMenu.Pause();
            PlayerData.SetQuizStarted(true);
            used = true;
            SceneManager.LoadSceneAsync("Quiz", LoadSceneMode.Additive);
        }

        public IEnumerator FadeInText()
        {
            canvas.enabled = true;
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            while (text.color.a < 1.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2));
                yield return null;
            }
        }

        public IEnumerator FadeOutText()
        {
            while (text.color.a > 0.0f)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2));
                yield return null;
            }
            canvas.enabled = false;
        }
    }
}
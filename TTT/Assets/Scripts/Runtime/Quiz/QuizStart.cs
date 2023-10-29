using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TTT
{
    public class QuizStart : MonoBehaviour
    {
        public int QuestionLevel;
        public Canvas canvas;
        public TextMeshProUGUI text;
        public PlayerData PlayerData;
        private PauseMenu pauseMenu;

        private void Awake()
        { canvas.enabled = false; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadSceneAsync("Quiz", LoadSceneMode.Additive);
                StartCoroutine(FadeInText());
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    PlayerData.SetQuestionLevel(QuestionLevel);
                    StartQuiz();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.UnloadSceneAsync("Quiz");
                StartCoroutine(FadeOutText());
            }
        }

        public void StartQuiz()
        {
            pauseMenu.Pause();
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Quiz"));
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
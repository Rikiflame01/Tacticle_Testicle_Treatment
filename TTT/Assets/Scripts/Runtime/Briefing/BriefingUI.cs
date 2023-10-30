using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TTT
{
    public class BriefingUI : MonoBehaviour
    {
        #region FIELDS

        public PlayerData PlayerData;

        private string[] Brief1 = { "Alright Chemoforce, your patient today is Greg Wilkinson, aged 19.",
            "He’s been diagnosed with stage II testicular cancer.",
            "That means it’s metastasized and is getting ready to spread all over the body.",
            "Your job today is to go into his bloodstream, locate any runaway cancer cells, neutralise them and then get to his testes.",
            "And as always, Kill Cancer." };

        private string[] Brief2 = { "Alright Chemoforce, your patient today is Phillip Kietly, aged 67.",
            "The diagnosis is grim, stage IV lung cancer.",
            "It is up to you to go inside, locate and destroy any loose cancer cells, then make your way to the lungs.",
            "It won’t be pretty but this is what Chemoforce is all about so get in there and do what needs to be done!",
            "And as always, Kill Cancer." };

        private TextMeshProUGUI BriefingText;
        private bool skip;
        private bool FinishedBriefing;

        #endregion FIELDS

        #region UNITY METHODS

        private void Start()
        {
            BriefingText = GetComponentInChildren<TextMeshProUGUI>();
            skip = false;
            FinishedBriefing = false;
            switch (PlayerData.GetCurrentLevel())
            {
                case 1:
                    StartCoroutine(TypeWriter(Brief1));
                    break;

                case 2:
                    StartCoroutine(TypeWriter(Brief2));
                    break;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                skip = true;
            }
            if (FinishedBriefing)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene("Level1");
                }
            }
        }

        #endregion UNITY METHODS

        #region METHODS

        private IEnumerator TypeWriter(string[] text)
        {
            foreach (string line in text)
            {
                foreach (char letter in line.ToCharArray())
                {
                    if (skip)
                    {
                        BriefingText.text += line;
                        //skip = false;
                        break;
                    }
                    BriefingText.text += letter;
                    yield return new WaitForSeconds(0.05f);
                }
                if (!skip)
                    yield return new WaitForSeconds(0.75f);
                BriefingText.text += "\n\n";
            }
            FinishedBriefing = true;
            yield return null;
        }

        #endregion METHODS
    }
}
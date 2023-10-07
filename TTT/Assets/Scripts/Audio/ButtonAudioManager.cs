using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundPlayer : MonoBehaviour
{
    public AudioClip buttonSound;

    public void PlayButtonSound()
    {
        if (buttonSound != null)
        {
            SFXManager.Instance.PlaySFX(buttonSound);
        }
        else
        {
            Debug.LogWarning("Button sound is not assigned!");
        }
    }
}

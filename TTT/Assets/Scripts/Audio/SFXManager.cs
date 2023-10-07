using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip buttonClick;
    public AudioClip pause;
    public AudioClip shooting;
    public AudioClip bossDamage;
    public AudioClip itemPickup;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}

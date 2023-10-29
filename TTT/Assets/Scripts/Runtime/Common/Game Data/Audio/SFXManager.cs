using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public AudioClip buttonClick;
    public AudioClip pause;
    public AudioClip playerDamageReceived;
    public AudioClip playerDeath;
    public AudioClip enemyGrunt;
    //public AudioClip playerFootstep;
    public AudioClip shooting;
    public AudioClip bossDamage;
    public AudioClip itemPickup;
    public AudioClip projectileCollision;
    public AudioClip shootingRocket;
    public AudioClip shootingExplosive;

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

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        audioSource.PlayOneShot(clip, volume);
    }
}

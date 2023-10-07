using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public AudioClip mainMenuMusic;
    public AudioClip gameSceneMusic;
    public AudioClip bossMusic;
    public AudioClip deathMusic;
    public AudioClip victoryMusic;
    public AudioClip[] organLevelsMusic; // An array to hold music for each organ level

    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Ensure the music manager persists across scenes
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MainMenu":
                PlayMusic(mainMenuMusic);
                break;
            case "GameScene":
                PlayMusic(gameSceneMusic);
                break;
            default:
                if (scene.name.StartsWith("Level"))
                {
                    int levelIndex = int.Parse(scene.name.Substring(5)) - 1; // Extract the level number
                    if (levelIndex < organLevelsMusic.Length)
                    {
                        PlayMusic(organLevelsMusic[levelIndex]);
                    }
                }
                break;
        }
    }

    public void PlayBossMusic()
    {
        PlayMusic(bossMusic);
    }

    public void PlayDeathMusic()
    {
        PlayMusic(deathMusic);
    }

    public void PlayVictoryMusic()
    {
        PlayMusic(victoryMusic);
    }

    private void PlayMusic(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from the sceneLoaded event
    }
}

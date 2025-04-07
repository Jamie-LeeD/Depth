using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip Background;
    public AudioClip[] footsteps;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayFootsteps();
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayFootsteps()
    {
        PlaySFX(RandomizeSound(footsteps));
    }

    public AudioClip RandomizeSound(AudioClip[] audioClips)
    {
        AudioClip selectedaudioClip = null;
        int selectSFX = 0;
        selectSFX = Random.Range(0, audioClips.Length);
        selectedaudioClip = audioClips[selectSFX];
        return selectedaudioClip;
    }
}

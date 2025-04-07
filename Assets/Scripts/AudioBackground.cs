using UnityEngine;

public class AudioBackground : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip Background;
    public AudioClip ButtonSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicSource.clip = Background;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayButton()
    {
        sfxSource.PlayOneShot(ButtonSound);
    }
}

using UnityEngine.Audio;
using System; 
using UnityEngine;

public class AudioManager : MonoBehaviour 

 
   
{
    public static AudioManager Instance;
    public AudioClip background; 
    public AudioClip walkingSound; 
    public AudioClip shootingSound; 
    public AudioClip jumpingSound;
    public Vector3 cameraPosition; 
    public float volume = 0.5f;

    public AudioSource MusicAudio;
    public AudioSource GameplayAudio;

    private float _musicVolume = 1f;
    public float MusicVolume 
    {
        get
        {
            return MusicAudio.volume;
        }
        set 
        {
            MusicAudio.volume = value;
        }
    }

    void Awake()
    {
        Instance = this; 
        cameraPosition = Camera.main.transform.position;
    }

     private void Playsound(AudioClip clip)
    {
      AudioSource.PlayClipAtPoint(clip,cameraPosition);
    }

    public void PlayBackground(AudioClip overrideAudio = null)
    {
        if (overrideAudio == null)
            MusicAudio.clip = background;
        else
            MusicAudio.clip = overrideAudio;
        MusicAudio.Play();
    }

    public void PlayWalkSound()
    {
         Playsound(walkingSound);
    } 

    public void PlayShootingSound()
    {
        Playsound(shootingSound);
    }
     
    public void PlayJumpingSound()
    {
        Playsound(jumpingSound);
    }
  
     
}

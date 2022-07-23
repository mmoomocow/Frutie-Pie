using UnityEngine.Audio;
using System; 
using UnityEngine;

public class AudioManager : MonoBehaviour 
{
    public static AudioManager Instance;
    public AudioClip background; 
    public AudioClip walkingSound; 
    public AudioClip shootingSound; 
    public Vector3 cameraPosition; 
   
    void Awake()
    {
        Instance = this; 
        cameraPosition = Camera.main.transform.position; 
       
    }
     private void Playsound(AudioClip clip)
    {
      AudioSource.PlayClipAtPoint(clip,cameraPosition);
    }
     
    public void PlayBackground()
    {
        Playsound(background); 
    }
    public void PlayWalkSound()
    {
         Playsound(walkingSound);
    } 

    public void PlayShootingSound()
    {
        Playsound(shootingSound);
    }
}

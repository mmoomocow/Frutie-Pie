using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCoolDown;
    public AudioClip footStep;
    [Range(0,1)]
    public float volume;

    // Update is called once per frame
    void Update()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        stepCoolDown -= Time.deltaTime;
        if (Input.GetAxisRaw("Horizontal")!=0 && stepCoolDown <0)
        {
            audio.volume = volume;
            audio.PlayOneShot(footStep);
            stepCoolDown = stepRate;
        }
    }
}

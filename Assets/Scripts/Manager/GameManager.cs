using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    

    private void Awake()
    {
        StartCoroutine(LoadUI());
    }

    private IEnumerator LoadUI()
    {
        yield return SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
        
        AudioManager.Instance.MusicVolume = 0.5f;
        AudioManager.Instance.PlayBackground();
        
        
        Debug.Log("Audiomanager should be ready");
    }


}

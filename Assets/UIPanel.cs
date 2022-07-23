using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
    public static UIPanel Instance;

    public TMPro.TextMeshProUGUI ScoreText;
    public TMPro.TextMeshProUGUI Timer;
    public float count;
    public bool isCounting;

    private int _score;

    private void Awake()
    {
        Debug.Log("UI Panel woke up");
        Instance = this;
        ScoreText.text = "0";
        Timer.text = "0";
        count = 60;
        isCounting = true;
    }
    void Start()
    {
        CountTime();
    }
    public void AddScore(int score)
    {
        _score += score;
        ScoreText.text = _score.ToString();
    }

    public void CountTime()
    {
        StartCoroutine(Counter());
    }
    private IEnumerator Counter()
    {

        while (count > 0 && isCounting)
        {
            isCounting = false;
            count -= Time.deltaTime;
            count = (int)count;
            Timer.text = count.ToString();
            yield return new WaitForSeconds(1f);
            isCounting = true;
        }
    }
}

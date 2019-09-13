using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] int minutes;
    [SerializeField] float seconds;
    private Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        minutes = 2;
        seconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            if (minutes <= 0)
            {
                SceneManager.LoadScene("ResultTest");
            }
            minutes--;
            seconds += 59;
        }
            timerText.text = minutes.ToString("00") + ":" + ((int)seconds).ToString("00");
    }
}

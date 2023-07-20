using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Time_hard : MonoBehaviour
{




    public Text text_time;


    public Text text_strat_time;
    public GameObject back;
    public GameObject End;
    public GameObject Pause;
    public Text text_end_point;
    public Text text_end_hihg_point;
    public Text text_pause_high;

    float time_start;

    bool check_start;

    float time_now;




    void Start()
    {
        Time.timeScale = 1;
        End.SetActive(false);
        Pause.SetActive(false);
        check_start = false;
        back.SetActive(true);
        text_pause_high.text = "최고 시간: " + Scenemove.Hhh.high_time_hard.ToString("F2");
        time_start = Time.time;
        text_strat_time.text = "3";
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        text_strat_time.text = "2";
        yield return new WaitForSeconds(1);
        text_strat_time.text = "1";
        yield return new WaitForSeconds(1);
        back.SetActive(false);
        time_start = Time.time;
        check_start = true;
    }


    public void Exit()
    {
        SceneManager.LoadScene("Choice");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Time(Hard)");
    }

    IEnumerator ReWait()
    {
        Time.timeScale = 1;
        check_start = false;
        back.SetActive(true);
        text_strat_time.text = "3";
        yield return new WaitForSeconds(1);
        text_strat_time.text = "2";
        yield return new WaitForSeconds(1);
        text_strat_time.text = "1";
        yield return new WaitForSeconds(1);
        back.SetActive(false);
        check_start = true;
        time_start += 3;
    }
    public void Resume()
    {
        Pause.SetActive(false);
        StartCoroutine(ReWait());
    }

    public void Time_out()
    {
        check_start = false;
        if (time_now > 7) time_now = 7;
        text_time.text = time_now.ToString("F2");
        text_time.gameObject.SetActive(true);
        text_end_point.text = "시간: " + time_now.ToString("F2");
        if (time_now > Scenemove.Hhh.high_time_hard) Scenemove.Hhh.high_time_hard = time_now;
        text_end_hihg_point.text = "최고시간: " + Scenemove.Hhh.high_time_hard.ToString();
        Scenemove.Hhh.Save();
        End.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!check_start) return;
        time_now = (Time.time - time_start);
        if (time_now > 2 && text_time.gameObject.activeSelf) text_time.gameObject.SetActive(false);
        if (time_now < 7) text_time.text = time_now.ToString("F2");
        else
        {
            check_start = false;
            text_time.text = "7.00";
            text_time.gameObject.SetActive(true);
            text_end_point.text = "시간: 0";
            text_end_hihg_point.text = "최고시간: " + Scenemove.Hhh.high_time_hard.ToString("F2");
            Scenemove.Hhh.Save();
            End.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                if (Pause.activeSelf) Resume();
                else
                {
                    Time.timeScale = 0;
                    Pause.SetActive(true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause.activeSelf) Resume();
            else
            {
                Time.timeScale = 0;
                Pause.SetActive(true);
            }
        }

    }
}

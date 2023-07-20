using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Click_hard : MonoBehaviour
{




    public Text text_time;

    public Text text_point;

    public Text text_stop;
    public SpriteRenderer background;

    float stop_time;
    bool stop_go;

    public Text text_strat_time;
    public GameObject back;
    public GameObject End;
    public GameObject Pause;
    public Text text_end_point;
    public Text text_end_hihg_point;
    public Text text_pause_high;

    float time_start;
    int point = 0;

    bool check_start;




    void Start()
    {
        background.color = new Color(166 / 255f, 166 / 255f, 166 / 255f);
        stop_go = true;
        stop_time = Random.Range(2f, 8f);
        text_stop.text = "CLICK";
        Time.timeScale = 1;
        End.SetActive(false);
        Pause.SetActive(false);
        check_start = false;
        back.SetActive(true);
        text_pause_high.text = "최고 점수: " + Scenemove.Hhh.high_click_hard.ToString();
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


    public void pointupdown(int up)
    {
        point += up;
        text_point.text = point.ToString();
    }


    public void Exit()
    {
        SceneManager.LoadScene("Choice");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Click(Hard)");
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

    IEnumerator Stop()
    {
        background.color = new Color(1, 166 / 255f, 166 / 255f);
        yield return new WaitForSeconds(2);
        background.color = new Color(166 / 255f, 166 / 255f, 166 / 255f);
        time_start += 2;
        stop_go = true;
        text_stop.text = "CLICK";
    }
    public void Resume()
    {
        Pause.SetActive(false);
        StartCoroutine(ReWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (!check_start) return;
        float time_now = 10 - (Time.time - time_start);
        if (time_now < stop_time) 
        {
            stop_go = false;
            text_stop.text = "STOP";
            stop_time = -10;
            StartCoroutine(Stop());
        }
        if (stop_go)
        {
            if (time_now > 0) text_time.text = time_now.ToString("F2");
            else
            {
                check_start = false;
                text_time.text = "0.00";
                text_end_point.text = "점수: " + point.ToString();
                if (point > Scenemove.Hhh.high_click_hard) Scenemove.Hhh.high_click_hard = point;
                text_end_hihg_point.text = "최고점수: " + Scenemove.Hhh.high_click_hard.ToString();
                Scenemove.Hhh.Save();
                End.SetActive(true);
            }
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
        if (Input.anyKeyDown)
        {
            pointupdown(1);
        }
        if (Input.touchCount >= 1)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (stop_go) pointupdown(1);
                    else pointupdown(-1);
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

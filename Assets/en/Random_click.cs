using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Random_click : MonoBehaviour
{




    public Text text_point;

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
        Time.timeScale = 1;
        End.SetActive(false);
        Pause.SetActive(false);
        check_start = false;
        back.SetActive(true);
        text_pause_high.text = "최고 점수: " + Scenemove.Hhh.high_random.ToString();
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
        SceneManager.LoadScene("Random");
    }

    public void Rclick(int i)
    {
        int rnum = Random.Range(0, 2);
        if (rnum == i) pointupdown(1);
        else Game_End();
    }
    void Game_End()
    {
        check_start = false;
        text_end_point.text = "점수: " + point.ToString();
        if (point > Scenemove.Hhh.high_random) Scenemove.Hhh.high_random = point;
        text_end_hihg_point.text = "최고점수: " + Scenemove.Hhh.high_random.ToString();
        Scenemove.Hhh.Save();
        End.SetActive(true);
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

    // Update is called once per frame
    void Update()
    {
        if (!check_start) return;
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

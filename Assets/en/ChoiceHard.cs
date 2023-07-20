using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoiceHard : MonoBehaviour
{
    List<Color> colors = new List<Color>{new Color(0, 0, 0), //검정
                      new Color(1, 0, 0), //빨강
                      new Color(0, 1, 0), //초록
                      new Color(0, 0, 1), //파랑
                      new Color(1, 1, 1), //하양
                      new Color(1, 1, 0), //노랑
                      new Color(1, 0, 1), //핑크
                      new Color(0, 1, 1), //하늘
    };

    Color[] usecolor;

    List<int> tii = new List<int>();

    public SpriteRenderer[] tiles;
    public SpriteRenderer[] hint;

    public Text text_time;

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
        text_pause_high.text = "최고 점수: "+Scenemove.Hhh.high_choice_hard.ToString();
        time_start = Time.time;
        usecolor = new Color[6];
        for(int i = 0; i < 6; i++)
        {
            int num = Random.Range(0, colors.Count);
            usecolor[i] = colors[num];
            hint[i].color = colors[num];
            colors.RemoveAt(num);
        }
        
        for(int i = 0; i < 6; i++)
        {
            tii.Add(Random.Range(0, usecolor.Length));
            tiles[i].color = usecolor[tii[i]];
        }
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
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

    IEnumerator ReWait()
    {
        Time.timeScale = 1;
        back.SetActive(true);
        text_strat_time.text = "3";
        yield return new WaitForSeconds(1);
        text_strat_time.text = "2";
        yield return new WaitForSeconds(1);
        text_strat_time.text = "1";
        yield return new WaitForSeconds(1);
        back.SetActive(false);
        time_start += 3;
    }

    void clear()
    {
        tii.RemoveAt(0);
        tii.Add(Random.Range(0, usecolor.Length));
        for (int i = 0; i < 6; i++)
        {
            tiles[i].color = usecolor[tii[i]];
        }
        pointupdown(1);
    }

    void pointupdown(int up)
    {
        point += up;
        text_point.text = point.ToString();
    }

    public void Rigthdown()
    {
        if (tii[0] % 2 == 1) clear();
        else pointupdown(-2);

    }

    public void Leftdown()
    {
        if (tii[0] % 2 == 0) clear();
        else pointupdown(-2);

    }

    public void Exit()
    {
        SceneManager.LoadScene("Choice");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Tile(Hard)");
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
        float time_now = 30 - (Time.time - time_start);
        if (time_now > 0) text_time.text = time_now.ToString("F2");
        else 
        {
            check_start = false;
            text_time.text = "0.00";
            text_end_point.text = "점수: " + point.ToString();
            if (point > Scenemove.Hhh.high_choice_hard) Scenemove.Hhh.high_choice_hard = point;
            text_end_hihg_point.text = "최고점수: " + Scenemove.Hhh.high_choice_hard.ToString();
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
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Leftdown();
        if (Input.GetKeyDown(KeyCode.RightArrow)) Rigthdown();
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

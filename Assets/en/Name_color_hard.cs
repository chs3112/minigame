using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Name_color_hard : MonoBehaviour
{
    List<int> color_name_index = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

    List<Color> colors = new List<Color>{new Color(0, 0, 0), //검정
                      new Color(1, 0, 0), //빨강
                      new Color(0, 1, 0), //초록
                      new Color(0, 0, 1), //파랑
                      new Color(1, 1, 1), //하양
                      new Color(1, 1, 0), //노랑
                      new Color(1, 0, 1), //핑크
                      new Color(0, 1, 1), //하늘
                      new Color(144/255f, 87/255f, 57/255f), //갈색
                      new Color(168/255f, 76/255f, 1), //보라
                      new Color(1, 150/255f, 0), //주황
                      new Color(42/255f, 203/255f, 151/255f), //청록
    };

    string[] color_name = new string[] { "검정", "빨강", "초록", "파랑", "하양", "노랑", "분홍", "하늘", "갈색", "보라", "주황", "청록" };


    int[] game_go;
    int turn = 0;
    float time_now;

    public Transform game_color_name_parant;
    Text[] game_color_names;

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




    void Start()
    {
        Time.timeScale = 1;
        End.SetActive(false);
        Pause.SetActive(false);
        check_start = false;
        back.SetActive(true);
        text_pause_high.text = "최고 시간: " + Scenemove.Hhh.high_name_hard.ToString("F2");
        game_go = new int[game_color_name_parant.childCount];
        game_color_names = new Text[game_color_name_parant.childCount];
        for (int i = 0; i < game_color_name_parant.childCount; i++)
        {
            game_color_names[i] = game_color_name_parant.GetChild(i).GetComponent<Text>();
            List<int> copy_color_name = color_name_index.ToList();
            int num = copy_color_name[Random.Range(0, copy_color_name.Count)];
            game_color_names[i].text = color_name[num];
            copy_color_name.RemoveAt(num);
            if (i != 0) if (num != game_go[i - 1]) copy_color_name.Remove(game_go[i - 1]);
            num = copy_color_name[Random.Range(0, copy_color_name.Count)];
            game_go[i] = num;
            game_color_names[i].color = colors[game_go[i]];
        }
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


    void pointupdown(int up)
    {
        time_start += up;
    }

    void clear()
    {
        game_color_names[turn].gameObject.SetActive(false);
        turn += 1;
        if (turn == game_color_names.Length)
        {
            check_start = false;
            Game_End();
        }
    }

    public void Game_click(int click_num)
    {
        if (game_go[turn] == click_num) clear();
        else pointupdown(-2);
    }

    public void Exit()
    {
        SceneManager.LoadScene("Choice");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Name(Hard)");
    }

    void Game_End()
    {
        check_start = false;
        text_end_point.text = "시간: " + time_now.ToString("F2");
        if (time_now < Scenemove.Hhh.high_name_hard) Scenemove.Hhh.high_name_hard = time_now;
        else if (Scenemove.Hhh.high_name_hard == 0f) Scenemove.Hhh.high_name_hard = time_now;
        text_end_hihg_point.text = "최고시간: " + Scenemove.Hhh.high_name_hard.ToString("F2");
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
        time_now = Time.time - time_start;
        text_time.text = time_now.ToString("F2");
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

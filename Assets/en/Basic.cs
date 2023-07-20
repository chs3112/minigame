using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Basic : MonoBehaviour
{

    public Text text_point;

    public Text text_strat_time;
    public GameObject back;
    public GameObject End;
    public GameObject Pause;
    public Text text_end_point;
    public Text text_end_hihg_point;
    public Text text_pause_high;

    protected float time_start;
    protected int point = 0;

    protected bool check_start;
    
    protected string sceneName;

    protected virtual int score{
        get {return 1; }
        set {score = value; }
    }




    protected virtual void Start()
    {
        Time.timeScale = 1;
        End.SetActive(false);
        Pause.SetActive(false);
        check_start = false;
        back.SetActive(true);
        text_pause_high.text = "최고 점수: " + score.ToString();
        time_start = Time.time;
        text_strat_time.text = "3";
        text_point.text = "0";
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
        SceneManager.LoadScene(sceneName);
    }


    public void stop(){
        Time.timeScale = 0;
        Pause.SetActive(true);
        check_start = false;

    }

    
    protected virtual void Game_End()
    {
        check_start = false;
        text_end_point.text = "점수: " + point.ToString();
        if (point > score) score = point;
        text_end_hihg_point.text = "최고점수: " + score.ToString();
        Scenemove.Hhh.Save();
        End.SetActive(true);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!check_start) return;
        else
        {
            check_start = false;
            text_end_point.text = "점수: " + point.ToString();
            if (point > score) score = point;
            text_end_hihg_point.text = "최고점수: " + score.ToString();
            Scenemove.Hhh.Save();
            End.SetActive(true);
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                if (!Pause.activeSelf){
                    stop();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Pause.activeSelf){
                stop();
            }
        }

    }
}

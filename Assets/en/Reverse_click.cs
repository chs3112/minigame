using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reverse_click : Basic
{






    public Text Arrow;
    public Text text_time;
    int direct = -1;



    protected override int score{
        get { return Scenemove.Hhh.high_reverse; }
        set { Scenemove.Hhh.high_reverse = value; }
    }


    protected override void Start()
    {
        base.Start();
        sceneName = "Reverse";
        ArrowRandom();

    }

    void ArrowRandom(){
        direct = Random.Range(0, 4);
        int cnum = Random.Range(0, 2); // 0 blue same 1 red reverse
        if (direct == 0){
            if (cnum == 0){
                Arrow.text = "→";
                Arrow.color = Color.blue;
            }
            else{
                Arrow.text = "←";
                Arrow.color = Color.red;
            }
        }
        else if (direct == 1){
            if (cnum == 0){
                Arrow.text = "↓";
                Arrow.color = Color.blue;
            }
            else{
                Arrow.text = "↑";
                Arrow.color = Color.red;
            }
        }
        else if (direct == 2){
            if (cnum == 0){
                Arrow.text = "←";
                Arrow.color = Color.blue;
            }
            else{
                Arrow.text = "→";
                Arrow.color = Color.red;
            }
        }
        else{
            if (cnum == 0){
                Arrow.text = "↑";
                Arrow.color = Color.blue;
            }
            else{
                Arrow.text = "↓";
                Arrow.color = Color.red;
            }
        }
    }


    protected override void Game_End()
    {
        text_time.text = "0.00";
        base.Game_End(); 
    }


    void Keydown(int i){
        if (direct == i){
            pointupdown(1);
            ArrowRandom();
        }
        else{
            pointupdown(-2);
            ArrowRandom();
        }
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        float time_now = 30 - (Time.time - time_start);
        if (time_now > 0) text_time.text = time_now.ToString("F2");
        else 
        {
            Game_End();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) Keydown(2);
        if (Input.GetKeyDown(KeyCode.RightArrow)) Keydown(0);
        if (Input.GetKeyDown(KeyCode.UpArrow)) Keydown(3);
        if (Input.GetKeyDown(KeyCode.DownArrow)) Keydown(1);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choice : Basic
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

    protected override int score{
        get { return Scenemove.Hhh.high_choice; }
        set { Scenemove.Hhh.high_choice = value; }
    }




    protected override void Start()
    {
        base.Start();
        usecolor = new Color[2];
        for(int i = 0; i < 2; i++)
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
        if (Input.GetKeyDown(KeyCode.LeftArrow)) Leftdown();
        if (Input.GetKeyDown(KeyCode.RightArrow)) Rigthdown();

    }
}

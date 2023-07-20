using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoManager : MonoBehaviour
{

    public Button button_tile_hard;
    public Text text_tile_hard;
    public Button button_color_hard;
    public Text text_color_hard;
    public Button button_name_hard;
    public Text text_name_hard;
    public Button button_many_hard;
    public Text text_many_hard;
    public Button button_time_hard;
    public Text text_time_hard;
    public Button button_random_hard;
    public Text text_random_hard;
    public Button button_reverse_hard;
    public Text text_reverse_hard;

    private void Start()
    {
        if(Scenemove.Hhh.high_choice >= 150)
        {
            text_tile_hard.text = "빨리 누르기(HARD)";
            button_tile_hard.interactable = true;
        }
        else
        {
            text_tile_hard.text = "해금 조건: 빨리누르기\n 점수 150 이상";
            button_tile_hard.interactable = false;
        }
        //***************************************************************************
        if (Scenemove.Hhh.high_color <= 20 && Scenemove.Hhh.high_color != 0)
        {
            text_color_hard.text = "색깔 누르기(HARD)";
            button_color_hard.interactable = true;
        }
        else
        {
            text_color_hard.text = "해금 조건: 색깔누르기\n시간 20초 이하";
            button_color_hard.interactable = false;
        }
        //***************************************************************************
        if (Scenemove.Hhh.high_name <= 20 && Scenemove.Hhh.high_name != 0)
        {
            text_name_hard.text = "색깔 이름 누르기(HARD)";
            button_name_hard.interactable = true;
            text_name_hard.fontSize = 70;
        }
        else
        {
            text_name_hard.text = "해금 조건: 색깔 이름 누르기\n시간 20초 이하";
            button_name_hard.interactable = false;
            text_name_hard.fontSize = 50;
        }
        //***************************************************************************
        if (Scenemove.Hhh.high_click >= 280)
        {
            text_many_hard.text = "여러 번 누르기(HARD)";
            button_many_hard.interactable = true;
            text_many_hard.fontSize = 55;
        }
        else
        {
            text_many_hard.text = "해금 조건: 여러 번 누르기\n점수 280 이상";
            button_many_hard.interactable = false;
            text_many_hard.fontSize = 50;
        }
        //***************************************************************************
        if (Scenemove.Hhh.high_time >= 4.8f)
        {
            text_time_hard.text = "시간 맞추기(HARD)";
            button_time_hard.interactable = true;
            text_random_hard.fontSize = 60;
        }
        else
        {
            text_time_hard.text = "해금 조건: 시간 맞추기\n시간 4.8초 이상";
            button_time_hard.interactable = false;
            text_random_hard.fontSize = 50;
        }
        //***************************************************************************
        if (Scenemove.Hhh.high_random >= 6)
        {
            text_random_hard.text = "랜덤 누르기(HARD)";
            button_random_hard.interactable = true;
            text_random_hard.fontSize = 60;
        }
        else
        {
            text_random_hard.text = "해금 조건: 랜덤 누르기\n점수 6 이상";
            button_random_hard.interactable = false;
            text_random_hard.fontSize = 50;
        }
        //***************************************************************************
        if (Scenemove.Hhh.high_reverse >= 50)
        {
            text_reverse_hard.text = "반대로 누르기(HARD)";
            button_reverse_hard.interactable = true;
            text_reverse_hard.fontSize = 60;
        }
        else
        {
            text_reverse_hard.text = "해금 조건: 반대로 누르기\n점수 50 이상";
            button_reverse_hard.interactable = false;
            text_reverse_hard.fontSize = 50;
        }
    }


    public void GoTile()
    {
        SceneManager.LoadScene("Tile");
    }

    public void GoTilehard()
    {
        SceneManager.LoadScene("Tile(Hard)");
    }
    public void GoColor()
    {
        SceneManager.LoadScene("Color");
    }
    public void GoName()
    {
        SceneManager.LoadScene("Name");
    }
    public void GoColorhard()
    {
        SceneManager.LoadScene("Color(Hard)");
    }
    public void GoNamehard()
    {
        SceneManager.LoadScene("Name(Hard)");
    }
    public void GoClick()
    {
        SceneManager.LoadScene("Click");
    }
    public void GoClickhard()
    {
        SceneManager.LoadScene("Click(Hard)");
    }
    public void GoTime()
    {
        SceneManager.LoadScene("Time");
    }
    public void GoTimehard()
    {
        SceneManager.LoadScene("Time(Hard)");
    }
    public void GoRandom()
    {
        SceneManager.LoadScene("Random");
    }
    public void GoRandomhard()
    {
        SceneManager.LoadScene("Random(Hard)");
    }

    public void GoReverse()
    {
        SceneManager.LoadScene("Reverse");
    }
    public void GoReversehard()
    {
        SceneManager.LoadScene("Reverse(Hard)");
    }

    private void Update()
    {

        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}

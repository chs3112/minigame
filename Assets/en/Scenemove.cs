using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemove : MonoBehaviour
{
    private static Scenemove it = null;

    public int high_choice;
    public int high_choice_hard;
    public float high_color;
    public float high_color_hard;
    public float high_name;
    public float high_name_hard;
    public int high_click;
    public int high_click_hard;
    public float high_time;
    public float high_time_hard;
    public int high_random;
    public int high_random_hard;
    public int high_reverse;
    public int high_reverse_hard;

    void Awake()
    {
        if (null == it)
        {
            it = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        Load();
    }

    public static Scenemove Hhh
    {
        get
        {
            if (null == it)
            {
                return null;
            }
            return it;
        }
    }


    public void Load()
    {
        if (!PlayerPrefs.HasKey("High_choice"))
        {
            high_choice = 0;
        }
        else
        {
            high_choice = PlayerPrefs.GetInt("High_choice");
        }

        if (!PlayerPrefs.HasKey("High_choice_hard"))
        {
            high_choice_hard = 0;
        }
        else
        {
            high_choice_hard = PlayerPrefs.GetInt("High_choice_hard");
        }

        if (!PlayerPrefs.HasKey("High_color_name"))
        {
            high_color = 0;
        }
        else
        {
            high_color = PlayerPrefs.GetFloat("High_color_name");
        }

        if (!PlayerPrefs.HasKey("High_name_color"))
        {
            high_name = 0;
        }
        else
        {
            high_name = PlayerPrefs.GetFloat("High_name_color");
        }

        if (!PlayerPrefs.HasKey("High_color_name_hard"))
        {
            high_color_hard = 0;
        }
        else
        {
            high_color_hard = PlayerPrefs.GetFloat("High_color_name_hard");
        }

        if (!PlayerPrefs.HasKey("High_name_color_hard"))
        {
            high_name_hard = 0;
        }
        else
        {
            high_name_hard = PlayerPrefs.GetFloat("High_name_color_hard");
        }

        if (!PlayerPrefs.HasKey("High_click"))
        {
            high_click = 0;
        }
        else
        {
            high_click = PlayerPrefs.GetInt("High_click");
        }

        if (!PlayerPrefs.HasKey("High_click_hard"))
        {
            high_click_hard = 0;
        }
        else
        {
            high_click_hard = PlayerPrefs.GetInt("High_click_hard");
        }

        if (!PlayerPrefs.HasKey("High_time"))
        {
            high_time = 0;
        }
        else
        {
            high_time = PlayerPrefs.GetFloat("High_time");
        }

        if (!PlayerPrefs.HasKey("High_time_hard"))
        {
            high_time_hard = 0;
        }
        else
        {
            high_time_hard = PlayerPrefs.GetFloat("High_time_hard");
        }

        if (!PlayerPrefs.HasKey("High_random"))
        {
            high_random = 0;
        }
        else
        {
            high_random = PlayerPrefs.GetInt("High_random");
        }

        if (!PlayerPrefs.HasKey("High_random_hard"))
        {
            high_random_hard = 0;
        }
        else
        {
            high_random_hard = PlayerPrefs.GetInt("High_radom_hard");
        }

        
        if (!PlayerPrefs.HasKey("High_reverse"))
        {
            high_reverse = 0;
        }
        else
        {
            high_reverse = PlayerPrefs.GetInt("High_reverse");
        }

        if (!PlayerPrefs.HasKey("High_reverse_hard"))
        {
            high_reverse_hard = 0;
        }
        else
        {
            high_reverse_hard = PlayerPrefs.GetInt("High_reverse_hard");
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("High_choice", high_choice);
        PlayerPrefs.SetInt("High_choice_hard", high_choice_hard);
        PlayerPrefs.SetFloat("High_color_name", high_color);
        PlayerPrefs.SetFloat("High_name_color", high_name);
        PlayerPrefs.SetFloat("High_color_name_hard", high_color_hard);
        PlayerPrefs.SetFloat("High_name_color_hard", high_name_hard);
        PlayerPrefs.SetInt("High_click", high_click);
        PlayerPrefs.SetInt("High_clcik_hard", high_click_hard);
        PlayerPrefs.SetFloat("High_time", high_time);
        PlayerPrefs.SetFloat("High_time_hard", high_time_hard);
        PlayerPrefs.SetInt("High_random", high_random);
        PlayerPrefs.SetInt("High_random_hard", high_random_hard);
        PlayerPrefs.SetInt("High_reverse", high_reverse);
        PlayerPrefs.SetInt("High_reverse_hard", high_reverse_hard);
    }

}

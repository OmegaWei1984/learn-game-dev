using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    Vector2 backgroud_pos = new Vector2(16, 16);

    Vector2 backgroud_scale = new Vector2(674, 674);

    static readonly int[,] win = new int[8,3] {
        {0, 1, 2},
        {3, 4, 5},
        {6, 7, 8},
        {0, 3, 6},
        {1, 4, 7},
        {2, 5, 8},
        {0, 4, 8},
        {2, 4, 6}
    };

    int[] colors = new int[9];

    bool is_player_b = false;

    int win_flag = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (win_flag == 0)
        {
            win_flag = CheckWin();
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(
            backgroud_pos.x,
            backgroud_pos.y,
            backgroud_scale.x,
            backgroud_scale.y
        ), "TicTacToe");
            string text = "no winner";
        if (win_flag != 0)
        {
            if (win_flag == 1)
            {
                text = "A is winner";
            } else if (win_flag == 2)
            {
                text = "B is winner";
            }

            if (GUI.Button(
                new Rect(
                    backgroud_pos.x + (backgroud_scale.x / 4),
                    backgroud_pos.y + (backgroud_scale.y / 4),
                    backgroud_scale.x / 2,
                    backgroud_scale.y / 4
                 ), $"{text}\nclick for reset"))
            {
                System.Array.Clear(colors, 0, colors.Length);
                is_player_b = false;
                win_flag = 0;
            }
            return;
        }

        int count = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                ++count;
                int idx = count - 1;
                if (colors[idx] != 0)
                {
                    //Debug.Log($"colors[{idx}]={colors[idx]}");
                    GUI.backgroundColor = colors[idx] == 1 ? Color.red : Color.blue;
                }
                if (
                    GUI.Button(
                        new Rect(64 + 202 * j, 64 + 202 * i, 170, 170), "button")
                    && colors[idx] == 0
                ) {
                    //Debug.Log($"{count}");
                    colors[idx] = !is_player_b ? 1 : 2;
                    is_player_b = !is_player_b;
                }
                GUI.backgroundColor = Color.white;
            }
        }
    }

    int CheckWin()
    {
        int count = 0;
        for (int i = 0; i < 9; ++i)
        {
            if (colors[i] != 0)
            {
                count++;
            }
        }
        if (count == 9)
        {
            return 3;
        }
        for (int i = 0; i < 8; i++)
        {
            if (
                colors[win[i,0]] != 0
                && colors[win[i,0]] == colors[win[i,1]]
                && colors[win[i,1]] == colors[win[i,2]]
            )
            {
                return colors[win[i,0]];
            }
        }
        return 0;
    }
}

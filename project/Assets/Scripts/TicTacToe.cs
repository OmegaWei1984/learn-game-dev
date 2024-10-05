using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    Vector2 backgroud_pos = new (16, 16);

    Vector2 backgroud_scale = new(674, 674);

    const int TTT_SIZE = 9;

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

    int[] colors = new int[TTT_SIZE];

    bool is_player_b = false;

    enum GameState
    { 
        Playing,
        PlayerRedWin,
        PlayerBlueWin,
        NoneWin
    };

    GameState game_state;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (game_state == GameState.Playing)
        {
            game_state = CheckWin();
        }
    }

    void OnGUI()
    {
        DrawBackgroud();
        if (game_state != GameState.Playing)
        {
            DrawGameOver();
            return;
        }
        DrawButton();
    }

    GameState CheckWin()
    {
        int count = 0;
        for (int i = 0; i < TTT_SIZE; ++i)
        {
            if (colors[i] != 0)
            {
                count++;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            if (
                colors[win[i,0]] != 0
                && colors[win[i,0]] == colors[win[i,1]]
                && colors[win[i,1]] == colors[win[i,2]]
            )
            {
                return (GameState)colors[win[i,0]];
            }
        }

        if (count == TTT_SIZE)
        {
            return GameState.NoneWin;
        }

        return GameState.Playing;
    }

    void DrawBackgroud()
    {
        GUI.Box(new Rect(
            backgroud_pos.x,
            backgroud_pos.y,
            backgroud_scale.x,
            backgroud_scale.y
        ), "TicTacToe");
    }

    void DrawGameOver()
    {
        string text = "no winner";
        if (game_state == GameState.PlayerRedWin)
        {
            text = "A is winner";
        }
        else if (game_state == GameState.PlayerBlueWin)
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
            game_state = 0;
        }
    }

    void DrawButton()
    {
        for (int i = 0, idx = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (colors[idx] != 0)
                {
                    GUI.backgroundColor = colors[idx] == 1 ? Color.red : Color.blue;
                }
                if (
                    GUI.Button(
                        new Rect(64 + 202 * j, 64 + 202 * i, 170, 170), "button")
                    && colors[idx] == 0
                )
                {
                    colors[idx] = !is_player_b ? 1 : 2;
                    is_player_b = !is_player_b;
                }
                GUI.backgroundColor = Color.white;
                idx++;
            }
        }
    }
}

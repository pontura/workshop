using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Game game;

    void Update()
    {
        int id = 0;
        if(Input.GetKey(KeyCode.RightArrow))
            game.GetCharacterById(id).move_x = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            game.GetCharacterById(id).move_x = -1;
        else
            game.GetCharacterById(id).move_x = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            game.GetCharacterById(id).move_y = 1;
        else if (Input.GetKey(KeyCode.DownArrow))
            game.GetCharacterById(id).move_y = -1;
        else
            game.GetCharacterById(id).move_y = 0;

        id = 1;
        if (game.characters.Count <= id)
            return;
        if (Input.GetKey(KeyCode.D))
            game.GetCharacterById(id).move_x = 1;
        else if (Input.GetKey(KeyCode.A))
            game.GetCharacterById(id).move_x = -1;
        else
            game.GetCharacterById(id).move_x = 0;

        if (Input.GetKey(KeyCode.W))
            game.GetCharacterById(id).move_y = 1;
        else if (Input.GetKey(KeyCode.S))
            game.GetCharacterById(id).move_y = -1;
        else
            game.GetCharacterById(id).move_y = 0;

        id = 2;
        if (game.characters.Count <= id)
            return;
        if (Input.GetKey(KeyCode.H))
            game.GetCharacterById(id).move_x = 1;
        else if (Input.GetKey(KeyCode.F))
            game.GetCharacterById(id).move_x = -1;
        else
            game.GetCharacterById(id).move_x = 0;

        if (Input.GetKey(KeyCode.T))
            game.GetCharacterById(id).move_y = 1;
        else if (Input.GetKey(KeyCode.G))
            game.GetCharacterById(id).move_y = -1;
        else
            game.GetCharacterById(id).move_y = 0;

        id = 3;
        if (game.characters.Count <= id)
            return;
        if (Input.GetKey(KeyCode.L))
            game.GetCharacterById(id).move_x = 1;
        else if (Input.GetKey(KeyCode.J))
            game.GetCharacterById(id).move_x = -1;
        else
            game.GetCharacterById(id).move_x = 0;

        if (Input.GetKey(KeyCode.I))
            game.GetCharacterById(id).move_y = 1;
        else if (Input.GetKey(KeyCode.K))
            game.GetCharacterById(id).move_y = -1;
        else
            game.GetCharacterById(id).move_y = 0;
    }
}

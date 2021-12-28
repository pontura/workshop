using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public List<int> scores;
    public List<Text> fields;
    public Game game;
    public Winscreen winscreen;
    bool ended;
    public Image flash;
    private void Start()
    {
        Events.CharacterLoseCoin += CharacterLoseCoin;
    }
    private void OnDestroy()
    {
        Events.CharacterLoseCoin -= CharacterLoseCoin;
    }
    void CharacterLoseCoin(int playerID)
    {
        scores[playerID]--;
        fields[playerID].text = scores[playerID].ToString();
    }
    public void Init(Game game)
    {
        flash.enabled = false;
        this.game = game;
        for (int a = 0; a < game.characters.Count; a++)
            fields[a].color = game.colors[a];
    }
    public void AddScore(int playerID)
    {
        if (ended)
            return;
        flash.enabled = true;
        flash.color = game.colors[playerID];
        Invoke("ResetFlash", 0.05f);
        scores[playerID]++;
        fields[playerID].text = scores[playerID].ToString();
        int id = 0;
        foreach (int score in scores)
        {
            if (score >= game.totalScore)
            {
                ended = true;
                winscreen.Init(game.colors[id]);
                Events.Win(id);
                return;
            }
            id++;
        }
    }
    void ResetFlash()
    {
        flash.enabled = false;
    }
}

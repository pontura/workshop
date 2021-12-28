using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public UI ui;
    int totalTime = 20;
    public Text field;
    int sec;
    bool playing;
    void Start()
    {
        sec = totalTime;
        Init();
        Loop();
        Events.Win += Win;
        Events.Wintime += Wintime;
    }
    private void Init()
    {
        playing = true;
    }
    private void OnDestroy()
    {
        Events.Wintime -= Wintime;
        Events.Win -=  Win;
    }
    void Wintime(int secs)
    {
        sec += secs;
    }
    void Loop()
    {
        if (!playing)
            sec = totalTime;
        else
            sec--;
        if(sec < 1)
        {
            ui.winscreen.Init(ui.game.colors[2]);
            Events.Win(2);
            return;
        }
        field.text = sec.ToString();
        Invoke("Loop", 1);
    }
    void Win(int playerID)
    {
        playing = false;
    }
}

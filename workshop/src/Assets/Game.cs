using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<Transform> walls;
    public List<Character> characters;
    public List<Coin> coins;
    public List<Color> colors;
    public List<EnemyWalk> walks;

    public UI ui;
    public Home home;

    public int totalScore = 5;
    public float limit_X;
    public float limit_Y;
    public float speed;
    public AudioSource audiosSource;
    public AudioClip soundFXCoin;
    public AudioClip soundFXDead;
    public AudioClip soundFXCharacterCollision;
    public AudioClip win0;
    public AudioClip win1;
    public AudioClip win2;
    public AudioClip win3;
    

    private void Start()
    {
        int id = 0;
        foreach (Character character in characters)
        {
            character.Init(this, speed, id, colors[id]);
            Home h = Instantiate(home);
            h.Init(character);
            id++;
        }
        foreach (Coin coin in coins)
            coin.Init(this);
        foreach (EnemyWalk ew in walks)
            ew.Init(this);

        limit_X = walls[0].transform.localPosition.x - 0.25f;
        limit_Y = walls[1].transform.localPosition.y - 0.25f;

        ui.Init(this);

        Events.OnSoundFX += OnSoundFX;
        Events.Win += Win;
    }
    void Win(int id)
    {
        Events.OnSoundFX -= OnSoundFX;
        Events.Win -= Win;

        if (id == 0)
            audiosSource.PlayOneShot(win0);
        if (id == 1)
            audiosSource.PlayOneShot(win1);
        if (id == 2)
            audiosSource.PlayOneShot(win2);
        if (id == 3)
            audiosSource.PlayOneShot(win3);

    }
    void OnSoundFX(string name)
    {
        if (name == "coin")
            audiosSource.PlayOneShot(soundFXCoin);
        if (name == "dead")
            audiosSource.PlayOneShot(soundFXDead);
       // if(name == "characterCollision")
          //  audiosSource.PlayOneShot(soundFXCharacterCollision);
    }
    public Character GetCharacterById(int id)
    {
        if (id < characters.Count)
            return characters[id];
        else
            return null;
    }
    public void SoundFX(string name)
    {
        print("suena " + name);
    }
}

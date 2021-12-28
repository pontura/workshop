using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Vector3 originalPos;
    public int move_x;
    public int move_y;
    float speed;
    public Game game;
    Rigidbody rb;
    public int id;
    public Color color;

    private void Start()
    {
        Events.CharacterGetCoin += CharacterGetCoin;
        rb = GetComponent<Rigidbody>();
        originalPos = transform.localPosition;
    }
    private void OnDestroy()
    {
        Events.CharacterGetCoin -= CharacterGetCoin;
    }
    void CharacterGetCoin(int _id)
    {
        if (id == 1 || id == 2 || id == 3)
            return;

        if (_id == id)
        {
            Vector3 scale = transform.localScale;          
            scale *= 0.95f;
            transform.localScale = scale;
          //  speed /= 1.25f;
        }
    }
    public void Init(Game game, float speed, int id, Color color)
    {
        this.color = color;
        this.id = id;
        
        this.speed = speed;
        this.game = game;
        foreach (MeshRenderer render in GetComponentsInChildren<MeshRenderer>())
            render.material.color = color;
    }

    void Update()
    {
        rb.velocity = Vector3.zero;
        Vector2 pos = transform.localPosition;
        pos.x += move_x * Time.deltaTime * speed;
        pos.y += move_y * Time.deltaTime * speed;

        if (pos.x < -game.limit_X)
            pos.x = -game.limit_X;
        else if (pos.x > game.limit_X)
            pos.x = game.limit_X;

        if (pos.y < -game.limit_Y)
            pos.y = -game.limit_Y;
        else if (pos.y > game.limit_Y)
            pos.y = game.limit_Y;

        transform.localPosition = pos;
    }
    public void Dead()
    {
        if (id == 0)
            Events.CharacterLoseCoin(0);
        Events.OnSoundFX("dead");
        transform.localPosition = originalPos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Events.OnSoundFX("characterCollision");
    }
}

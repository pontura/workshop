using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{
    public float speed;
    public float interval;
    public float angle;
    float nextAngle;
    Game game;

    public void Init(Game game)
    {
        this.game = game;
        Loop();
    }
    void Loop()
    {
        nextAngle += Random.Range(-angle, angle);
        Invoke("Loop", 0.75f);
    }
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Vector3 pos = transform.localPosition;
        if (pos.x > game.limit_X)
            pos.x = -game.limit_X;
        else if (pos.x < -game.limit_X)
            pos.x = game.limit_X;

        if (pos.y > game.limit_Y)
            pos.y = -game.limit_Y;
        else if (pos.y < -game.limit_Y)
            pos.y = game.limit_Y;

        transform.localPosition = pos;
        Vector3 rot = transform.localEulerAngles;
        rot.z += Random.Range(-angle, angle);
        transform.localEulerAngles = rot;
    }
}

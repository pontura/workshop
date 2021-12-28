using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    Game game;
    float timer;
    public GameObject asset;

    public void Init(Game game)
    {
        this.game = game;
    }
    private void LateUpdate()
    {
        timer += Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector2 pos = new Vector2(Random.Range(-game.limit_X, game.limit_X), Random.Range(-game.limit_Y, game.limit_Y));
        ChangePosition(pos);

        Character character = collision.gameObject.GetComponent<Character>();
        if (character == null)
            return;
        if (character.id == 2 || character.id == 3)
            return;

        if (timer > 0.07f)
        {
            Events.Wintime(2);
            Events.CharacterGetCoin(0);
            game.ui.AddScore(0);
        }
        timer = 0;

        CancelInvoke();
        asset.SetActive(false);
        Invoke("Reset", 1);
        Events.OnSoundFX("coin");
    }
    private void Reset()
    {
        asset.SetActive(true);
    }
    void ChangePosition(Vector2 pos)
    {
        transform.localPosition = pos;
    }
}

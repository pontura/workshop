using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winscreen : MonoBehaviour
{
    public GameObject panel;
    public Image image;

    private void Start()
    {
        panel.SetActive(false);
    }
    
    public void Init(Color color)
    {
        panel.SetActive(true);
        image.color = color;
        Invoke("Done", 4);
    }
    void Done()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}

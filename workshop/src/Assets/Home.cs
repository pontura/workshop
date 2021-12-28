using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public void Init(Character character)
    {
        transform.localPosition = character.transform.localPosition;
        foreach (MeshRenderer render in GetComponentsInChildren<MeshRenderer>())
            render.material.color = character.color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;

public class Hover_reaction : MonoBehaviour
{
    // Start is called before the first frame update
    void.start()
    {
        Renderer.material.color = Color.black;
    }

    void OnMouseEnter()
    {
        Renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        Renderer.material.color = Color.black;
    }
    }
}
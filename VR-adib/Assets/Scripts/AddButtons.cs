using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    //addings for the Gameobject script
    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    void Awake() {
        for( int i=0; i < 5; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "Puzzlecard " + i; //name of the Puzzle buttons
            button.transform.SetParent(puzzleField, false);
        }
 }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Card", menuName = "Card_Game_Objects/Card")]
public class CardSO : ScriptableObject
{
    public string cardName;
    public string pairName;
    public Sprite cardImage;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game_controller : MonoBehaviour
{

    [SerializeField]
    private Sprite bgImage; //background image for the buttons

    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    //variables to controll the game
    private bool firstGuess;
    private bool secoundGuess;

    private int countGousses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex;
    private int secoundGuessIndex; 

    private string firstGuessPuzzle, secondGuessPuzzle;

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePuzzles();
    }
    
     void GetButtons()
     {
            GameObject[] objects = GameObject.FindGameObjectsWithTag ("PuzzleButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>()); //adding buttons
            btns[i].image.sprite = bgImage; // accessing the image of the buttons
        }
    }
    //add gamePuzzle: Make a loop (=looper) for the cards, to they are twice in the game.
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if(index == looper / 2)
            {
                index = 0;
            }

            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }
    //function of the button: executing when touching the button
    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle()) ;
        }
    }

    public void PickAPuzzle()
    {
        //string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        // Debug.Log("You Are Clicking a Button" + name); //using the names of the buttons as index in order to access the arrays

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
        } 
        else if (!secoundGuess)
        {
            secoundGuess = true;
            secoundGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

            btns[secoundGuessIndex].image.sprite = gamePuzzles[secoundGuessIndex]; 
        }
    }


}

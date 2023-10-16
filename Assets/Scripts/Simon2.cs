using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simon2 : MonoBehaviour
{
    [SerializeField] private List<int> sequence = new List<int>();
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private int attempts;

    [SerializeField] private int sequenceIndex = 0;
    [SerializeField] private bool isPlayerTurn = false;

    [SerializeField] public int maxScore; // Settable maximum score needed to win
    [SerializeField] private bool isGameOver = false; //Used to detirmine if the player has won or lost
    [SerializeField] private int numButtons; //Int that records the number of items for order generation

    //LockedDoor that will be destroyed apon completion
    [SerializeField] private GameObject simonDoor1;
    [SerializeField] private GameObject simonDoor2;

    //Soundeffects
    [SerializeField] private AudioSource incorrectSoundeffect; //Soundeffect of guessing wrong
    [SerializeField] private AudioSource correctSoundeffect; //Soundeffect of guessing all right
    [SerializeField] private AudioSource buttonSoundeffect; //Soundeffect of the button in a sequence

    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn = true;
        isGameOver = true;
        attempts = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartNewGame()
    {
        if (isPlayerTurn == true)
        {
            isGameOver = false;
            GenerateSequence();
            sequenceIndex = 0;
            StartCoroutine(PlaySequence());
        }
    }
    
    // Generate a random sequence of colours
    private void GenerateSequence()
    {
        sequence.Clear(); //Clear any previous Games
        sequenceIndex = 0;

        for (int i = 0; i < maxScore; i++)
        {
            int randomColour = Random.Range(0, numButtons);    //0 = Blue, 1 = Red, 2 = Green, 3 = Yellow
            sequence.Add(randomColour);
        }
    }

    private IEnumerator PlaySequence()
    {
        isPlayerTurn = false;
        buttonSoundeffect.pitch = 1.0f;

        foreach (int colourIndex in sequence)
        {
            buttons[colourIndex].GetComponent<MemoryButton>().Highlight(); 
            buttonSoundeffect.Play(); //Play button sequence sound effect
            buttonSoundeffect.pitch += 0.04f;
            yield return new WaitForSeconds(1f); 
            buttons[colourIndex].GetComponent<MemoryButton>().DeHighlight();
            yield return new WaitForSeconds(1f);
        }

        isPlayerTurn = true;
        buttonSoundeffect.pitch = 1.0f;
    }


    //Called when a simon button is pressed
    private IEnumerator OnColourButtonClicked(int colourIndex)
    {

        if (isPlayerTurn == true && !isGameOver)
        {
            // Correct colour clicked
            if (colourIndex == sequence[sequenceIndex])
            {
                //-----Show the button being pressed-------
                isPlayerTurn = false;

                buttons[colourIndex].GetComponent<MemoryButton>().Highlight();
                buttonSoundeffect.Play(); //Play button sequence sound effect
                buttonSoundeffect.pitch += 0.04f;
                yield return new WaitForSeconds(1f); // Adjust the delay as needed
                buttons[colourIndex].GetComponent<MemoryButton>().DeHighlight();

                isPlayerTurn = true;
                //------------------------------------------

                sequenceIndex++; //Increment the sequenceIndex

                // Player successfully repeated the sequence
                if (sequenceIndex == sequence.Count)
                {
                    // Player wins
                    correctSoundeffect.Play();
                    yield return new WaitForSeconds(1f); // Adjust the delay as needed
                    Destroy(simonDoor1);
                    Destroy(simonDoor2);
                    isGameOver = true;
                    sequenceIndex = 0;
                }
            }

            // Incorrect colour clicked
            else
            {
                isPlayerTurn = false;

                //----------------Flash red to show that the player inputted incorrect sequence-------------
                for (int i = 0; i < numButtons; i++)
                {
                    buttons[i].GetComponent<MemoryButton>().Incorrect();
                }

                incorrectSoundeffect.Play(); //Play incorrect sound effect
                yield return new WaitForSeconds(1f); // Adjust the delay as needed

                for (int i = 0; i < numButtons; i++)
                {
                    buttons[i].GetComponent<MemoryButton>().DeHighlight();
                }
                
                isPlayerTurn = true;
                isGameOver = true;
                sequenceIndex = 0;
                attempts++;

                //If the player has ran out of attempts, clear the puzzle automatically (Also as a fail safe incase code goes wrong!)
                if (attempts == 7)
                {
                    yield return new WaitForSeconds(1f); // Adjust the delay as needed
                    Destroy(simonDoor1);
                    Destroy(simonDoor2);
                    isGameOver = true;
                }
            }
        }
    }

    public void PressButton(int cIndex)
    {
        StartCoroutine(OnColourButtonClicked(cIndex));
    }
}

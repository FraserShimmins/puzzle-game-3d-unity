using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Attributes for puzzle 1
    public int coinTotal; //Coins collected 
    [SerializeField] private TextMeshProUGUI coinTaskText;
    
    //Attributes for puzzle 2
    Queue queue;
    public GameObject buttonSequence;

    public int buttonsPressed; //Total buttons pressed
    public GameObject[] objects; 
    public bool buttonPassed;

    //LockedDoor that will be destroyed apon COIN COLLECT completion
    [SerializeField] private GameObject forestDoor1;
    [SerializeField] private GameObject forestDoor2;

    //LockedDoor that will be destroyed apon Riddle PUZZLE completion
    [SerializeField] private GameObject caveDoor1;
    [SerializeField] private GameObject caveDoor2;

    //LockedDoor that will be destroyed apon LAVA PUZZLE completion
    [SerializeField] private GameObject lavaDoor1;
    [SerializeField] private GameObject lavaDoor2;

    //UI collection which is activated when player wins
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject ui; //Game UI

    //Used for sound effects
    [SerializeField] private AudioSource coinSoundeffect;
    [SerializeField] private AudioSource successSoundeffect;
    [SerializeField] private AudioSource incorrectSoundeffect; //Soundeffect of guessing wrong
    [SerializeField] private AudioSource buttonSoundeffect;
    [SerializeField] private AudioSource closeBook; //Soundeffect of closing a Note
    [SerializeField] private AudioSource rotateNode;

    // Start is called before the first frame update
    void Start()
    {
        coinTotal = 0;
        buttonsPressed = 0;
        buttonPassed = false;

        //Brining the methods of the Queue Script into the program
        buttonSequence = GameObject.FindWithTag("ButtonSequence");
        queue = buttonSequence.GetComponent<Queue>();
    }

    // Update is called once per frame
    void Update()
    {
        //All the buttons have been pressed
        if (buttonsPressed == queue.maxSize && buttonPassed == false && Input.GetKey(KeyCode.Q) )
        {
            Debug.Log("Max Size reached");
            CheckAnswer();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    //Sound effects
    public void CloseNote()
    {
        closeBook.Play();
    }

    public void PlayRotate()
    {
        rotateNode.Play();
    }


    //Puzzle 1 COINS ------------------------------------------------------------------------------------------------
    
    //Coin is collected
    public void CollectCoin()
    {
        Debug.Log("Coin Collected!");
        coinTotal += 1;
        coinSoundeffect.Play(); //Play the sound effect of picking up a coin

        coinTaskText.text = "- Collect Coins " + coinTotal.ToString() + " / 25";



        //If all coins are collected
        if (coinTotal == 25) 
        {
            Destroy(forestDoor1);
            Destroy(forestDoor2);
            coinTaskText.text = "<s>- Collect Coins 25 / 25</s>";
        }
    }

    
    //Puzzle 2 BUTTONS ----------------------------------------------------------------------------------------------

    //Button Pressed down
    public void ButtonPress(string order)
    {
        buttonSoundeffect.Play();
        queue.EnQueue(order);
        buttonsPressed += 1;
    }

    //Check if the button combination entered is the solution
    public void CheckAnswer() 
    {
        //Check if the order attempted == correct order
        if (queue.queueData.SequenceEqual(queue.solution))
        {
            successSoundeffect.Play();
            Destroy(caveDoor1);
            Destroy(caveDoor2);
            buttonPassed = true;
        }

        else
        {
            incorrectSoundeffect.Play();

            
            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();
            queue.DeQueue();

            //Resets the buttons
            objects = GameObject.FindGameObjectsWithTag("Button"); //Fills an array with all the buttons

            //Calls the reset method on all the buttons
            foreach (GameObject obj in objects)
            {
                obj.GetComponent<ButtonPress>().Reset();
            }
            
            buttonsPressed = 0;
            Debug.Log("Reset");
        }
    }

    //Puzzle 4 LAVA ----------------------------------------------------------------------------------------------
    public void LavaCleared()
    {
        Destroy(lavaDoor1);
        Destroy(lavaDoor2);
    }

    //WIN SCREEN -------------------------------------------------------------------------------------------------

    public void WinGame()
    {
        ui.SetActive(false);
        winScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        //Load Main Menu Screen
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

}

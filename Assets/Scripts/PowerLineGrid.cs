using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineGrid : MonoBehaviour
{
    [SerializeField] private GameObject a0;
    [SerializeField] private GameObject a1;
    [SerializeField] private GameObject a2;
    [SerializeField] private GameObject a3;
    [SerializeField] private GameObject a4;
    [SerializeField] private GameObject a5;
    [SerializeField] private GameObject b0;
    [SerializeField] private GameObject b1;
    [SerializeField] private GameObject b2;
    [SerializeField] private GameObject b3;
    [SerializeField] private GameObject b4;
    [SerializeField] private GameObject b5;
    [SerializeField] private GameObject c0;
    [SerializeField] private GameObject c1;
    [SerializeField] private GameObject c2;
    [SerializeField] private GameObject c3;
    [SerializeField] private GameObject c4;
    [SerializeField] private GameObject c5;
    [SerializeField] private GameObject d0;
    [SerializeField] private GameObject d1;
    [SerializeField] private GameObject d2;
    [SerializeField] private GameObject d3;
    [SerializeField] private GameObject d4;
    [SerializeField] private GameObject d5;
    [SerializeField] private GameObject e0;
    [SerializeField] private GameObject e1;
    [SerializeField] private GameObject e2;
    [SerializeField] private GameObject e3;
    [SerializeField] private GameObject e4;
    [SerializeField] private GameObject e5;
    [SerializeField] private GameObject f0;
    [SerializeField] private GameObject f1;
    [SerializeField] private GameObject f2;
    [SerializeField] private GameObject f3;
    [SerializeField] private GameObject f4;
    [SerializeField] private GameObject f5;
    [SerializeField] private GameObject g0;
    [SerializeField] private GameObject g1;
    [SerializeField] private GameObject g2;
    [SerializeField] private GameObject g3;
    [SerializeField] private GameObject g4;
    [SerializeField] private GameObject g5;
    [SerializeField] private GameObject h0;
    [SerializeField] private GameObject h1;
    [SerializeField] private GameObject h2;
    [SerializeField] private GameObject h3;
    [SerializeField] private GameObject h4;
    [SerializeField] private GameObject h5;
    [SerializeField] private GameObject[,] gameGrid;

    //Used to start & check if the puzzle has been cleared
    [SerializeField] private GameObject startNode;
    [SerializeField] private GameObject endNode;
    [SerializeField] private GameObject[] checkPower;

    //LockedDoor that will be destroyed apon completion
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;

    //Soundeffects
    [SerializeField] private AudioSource successSoundeffect; //Soundeffect of connecting power
    [SerializeField] private AudioSource failSoundeffect; //Soundeffect of losing power
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameGrid =  new GameObject[,] { 
                                        {a0, b0, c0, d0, e0, f0, g0, h0}, 
                                        {a1, b1, c1, d1, e1, f1, g1, h1},
                                        {a2, b2, c2, d2, e2, f2, g2, h2},
                                        {a3, b3, c3, d3, e3, f3, g3, h3},
                                        {a4, b4, c4, d4, e4, f4, g4, h4},
                                        {a5, b5, c5, d5, e5, f5, g5, h5},
                                       };
    }

    public bool checkSurrondings(int row, int column, bool n, bool e, bool s, bool w)
    {
        bool powerConnected = false;

        //Check Up
        if (row-1 > -1)
        {
            if (gameGrid[row-1, column].GetComponent<PowerLineManager>().GetSouth() == true && n == true && gameGrid[row-1, column].GetComponent<PowerLineManager>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        //Check Right
        if (column+1 < 8)
        {
            if (gameGrid[row, column+1].GetComponent<PowerLineManager>().GetWest() == true && e == true && gameGrid[row, column+1].GetComponent<PowerLineManager>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        //Check Down
        if (row+1 < 6)
        {
            if (gameGrid[row+1, column].GetComponent<PowerLineManager>().GetNorth() == true && s == true && gameGrid[row+1, column].GetComponent<PowerLineManager>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        //Check left
        if (column-1 > -1)
        {
            if (gameGrid[row, column-1].GetComponent<PowerLineManager>().GetEast() == true && w == true && gameGrid[row, column-1].GetComponent<PowerLineManager>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        return powerConnected;  //Returns true if a power connection is found
    }

    public void ShowConnection()
    {
        StartCoroutine(UpdatePowerOfAll());
    }

    //Used to check the state of the game when the blue Start button is pressed
    public IEnumerator UpdatePowerOfAll()
    {
        startNode.GetComponent<StartNode>().StartPowerUp();

        //Repeat 46 times to allow power to flow around
        for (int count = 0; count < 46; count++)
        {
            for (int row = 0; row < gameGrid.GetLength(0); row++)
            {
                for (int column = 0; column < gameGrid.GetLength(1); column++)
                {
                    gameGrid[row, column].GetComponent<PowerLineManager>().PowerUpdate();
                }
            }
        }

        yield return new WaitForSeconds(2f); 

        //If the power has flowed to the end of the puzzle
        if (endNode.GetComponent<PowerLineManager>().GetPowered() == true)
        {
            successSoundeffect.Play();
            Destroy(door1);
            Destroy(door2);

            //Deactiveate the piplines
            for (int row = 0; row < gameGrid.GetLength(0); row++)
            {
                for (int column = 0; column < gameGrid.GetLength(1); column++)
                {
                    gameGrid[row, column].GetComponent<PowerLineManager>().DeActivate();
                }
            }

            for (int i = 0; i < checkPower.Length; i++)
            {
                checkPower[i].GetComponent<CheckPower>().DeActivate();
            }
        }

        //Power has not flowed to the end of the puzzle
        else
        {
            failSoundeffect.Play();

            //Depower the piplines
            for (int row = 0; row < gameGrid.GetLength(0); row++)
            {
                for (int column = 0; column < gameGrid.GetLength(1); column++)
                {
                    gameGrid[row, column].GetComponent<PowerLineManager>().PowerDown();
                }
            }

            startNode.GetComponent<StartNode>().PowerDown();
        }

    }
}

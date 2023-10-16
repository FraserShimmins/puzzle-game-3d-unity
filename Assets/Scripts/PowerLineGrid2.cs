using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLineGrid2 : MonoBehaviour
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
    [SerializeField] private GameObject i0;
    [SerializeField] private GameObject i1;
    [SerializeField] private GameObject i2;
    [SerializeField] private GameObject i3;
    [SerializeField] private GameObject i4;
    [SerializeField] private GameObject i5;
    [SerializeField] private GameObject j0;
    [SerializeField] private GameObject j1;
    [SerializeField] private GameObject j2;
    [SerializeField] private GameObject j3;
    [SerializeField] private GameObject j4;
    [SerializeField] private GameObject j5;
    [SerializeField] private GameObject k0;
    [SerializeField] private GameObject k1;
    [SerializeField] private GameObject k2;
    [SerializeField] private GameObject k3;
    [SerializeField] private GameObject k4;
    [SerializeField] private GameObject k5;
    [SerializeField] private GameObject l0;
    [SerializeField] private GameObject l1;
    [SerializeField] private GameObject l2;
    [SerializeField] private GameObject l3;
    [SerializeField] private GameObject l4;
    [SerializeField] private GameObject l5;
    [SerializeField] private GameObject m0;
    [SerializeField] private GameObject m1;
    [SerializeField] private GameObject m2;
    [SerializeField] private GameObject m3;
    [SerializeField] private GameObject m4;
    [SerializeField] private GameObject m5;
    [SerializeField] private GameObject n0;
    [SerializeField] private GameObject n1;
    [SerializeField] private GameObject n2;
    [SerializeField] private GameObject n3;
    [SerializeField] private GameObject n4;
    [SerializeField] private GameObject n5;
    [SerializeField] private GameObject o0;
    [SerializeField] private GameObject o1;
    [SerializeField] private GameObject o2;
    [SerializeField] private GameObject o3;
    [SerializeField] private GameObject o4;
    [SerializeField] private GameObject o5;
    [SerializeField] private GameObject p0;
    [SerializeField] private GameObject p1;
    [SerializeField] private GameObject p2;
    [SerializeField] private GameObject p3;
    [SerializeField] private GameObject p4;
    [SerializeField] private GameObject p5;
    [SerializeField] private GameObject q0;
    [SerializeField] private GameObject q1;
    [SerializeField] private GameObject q2;
    [SerializeField] private GameObject q3;
    [SerializeField] private GameObject q4;
    [SerializeField] private GameObject q5;
    [SerializeField] private GameObject r0;
    [SerializeField] private GameObject r1;
    [SerializeField] private GameObject r2;
    [SerializeField] private GameObject r3;
    [SerializeField] private GameObject r4;
    [SerializeField] private GameObject r5;
    [SerializeField] private GameObject s0;
    [SerializeField] private GameObject s1;
    [SerializeField] private GameObject s2;
    [SerializeField] private GameObject s3;
    [SerializeField] private GameObject s4;
    [SerializeField] private GameObject s5;
    [SerializeField] private GameObject t0;
    [SerializeField] private GameObject t1;
    [SerializeField] private GameObject t2;
    [SerializeField] private GameObject t3;
    [SerializeField] private GameObject t4;
    [SerializeField] private GameObject t5;

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
                                        {a0, b0, c0, d0, e0, f0, g0, h0, i0, j0, k0, l0, m0, n0, o0, p0, q0, r0, s0, t0}, 
                                        {a1, b1, c1, d1, e1, f1, g1, h1, i1, j1, k1, l1, m1, n1, o1, p1, q1, r1, s1, t1},
                                        {a2, b2, c2, d2, e2, f2, g2, h2, i2, j2, k2, l2, m2, n2, o2, p2, q2, r2, s2, t2},
                                        {a3, b3, c3, d3, e3, f3, g3, h3, i3, j3, k3, l3, m3, n3, o3, p3, q3, r3, s3, t3},
                                        {a4, b4, c4, d4, e4, f4, g4, h4, i4, j4, k4, l4, m4, n4, o4, p4, q4, r4, s4, t4},
                                        {a5, b5, c5, d5, e5, f5, g5, h5, i5, j5, k5, l5, m5, n5, o5, p5, q5, r5, s5, t5},
                                       };
    }

    public bool checkSurrondings(int row, int column, bool n, bool e, bool s, bool w)
    {
        bool powerConnected = false;

        //Check Up
        if (row-1 > -1)
        {
            if (gameGrid[row-1, column].GetComponent<PowerLineManager2>().GetSouth() == true && n == true && gameGrid[row-1, column].GetComponent<PowerLineManager2>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        //Check Right
        if (column+1 < 20)
        {
            if (gameGrid[row, column+1].GetComponent<PowerLineManager2>().GetWest() == true && e == true && gameGrid[row, column+1].GetComponent<PowerLineManager2>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        //Check Down
        if (row+1 < 6)
        {
            if (gameGrid[row+1, column].GetComponent<PowerLineManager2>().GetNorth() == true && s == true && gameGrid[row+1, column].GetComponent<PowerLineManager2>().GetPowered() == true)
            {
                powerConnected = true;
                
            }
        }

        //Check left
        if (column-1 > -1)
        {
            if (gameGrid[row, column-1].GetComponent<PowerLineManager2>().GetEast() == true && w == true && gameGrid[row, column-1].GetComponent<PowerLineManager2>().GetPowered() == true)
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
        startNode.GetComponent<StartNode2>().StartPowerUp();

        //Repeat 46 times to allow power to flow around
        for (int count = 0; count < 92; count++)
        {
            for (int row = 0; row < gameGrid.GetLength(0); row++)
            {
                for (int column = 0; column < gameGrid.GetLength(1); column++)
                {
                    gameGrid[row, column].GetComponent<PowerLineManager2>().PowerUpdate();
                }
            }
        }

        yield return new WaitForSeconds(2f); 

        //If the power has flowed to the end of the puzzle
        if (endNode.GetComponent<PowerLineManager2>().GetPowered() == true)
        {
            successSoundeffect.Play();
            Destroy(door1);
            Destroy(door2);

            //Deactiveate the piplines
            for (int row = 0; row < gameGrid.GetLength(0); row++)
            {
                for (int column = 0; column < gameGrid.GetLength(1); column++)
                {
                    gameGrid[row, column].GetComponent<PowerLineManager2>().DeActivate();
                }
            }

            for (int i = 0; i < checkPower.Length; i++)
            {
                checkPower[i].GetComponent<CheckPower2>().DeActivate();
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
                    gameGrid[row, column].GetComponent<PowerLineManager2>().PowerDown();
                }
            }

            startNode.GetComponent<StartNode2>().PowerDown();
        }

    }
}

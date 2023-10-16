using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
  //Defining the attributes
  public int maxSize = 6; //MaxSize the queue can reach
  private int frontPointer = 0; //Index of current front of queue
  private int rearPointer = 0; //Index of current back of queue 
  public string[] queueData = new string[]{"", "", "", "", "", ""}; //Creating the queue array
  public string[] solution = new string[]{"1","2","3","4","5","6"};

  
  //Add an item to the front of the queue
  public void EnQueue(string newItem)
  {
    if (IsFull())
    {
      Debug.Log("The Queue is full");
    }

    else
    {
      queueData[rearPointer] = newItem; //Adds item to the back of the queue
      rearPointer += 1; //Increments the back pointer
    }
  }

  //Remove Item from the back of the queue 
  public void DeQueue()
  {
    if (IsEmpty())
    {
      Debug.Log("The Queue is empty");
    }

    else
    {
      queueData[frontPointer] = ""; //Deletes the front item

      for (int index = 1; index < rearPointer; index++)
      {
        queueData[index-1] = queueData[index];  //Moves the item at Index 'index' to the Index infront of it
        queueData[index] = ""; //Deletes the duplicate index left behind from the move
      }

      rearPointer -= 1; //Moves the back pointer forwards
    }
  }

  public bool IsEmpty()
  {
    //Is the rearPointer at the beginning of the list?
    if (rearPointer == 0)
    {
      return true;
    }

    else
    {
      return false;
    }
  }

  public bool IsFull()
  {
    //Is the rearPointer at the end of the list?
    if (rearPointer == maxSize)
    {
      return true;
    }

    else
    {
      return false;
    }
  }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour {

    public string location;
    
    public static UIController uiController;

    //public int [] events;
    public int roomNumber = 0;
    public int totalRoomsNumber;
    public string currentRoom;
    public int currentCons;
    public int currentPros;
    public int totalProAndCons;
    public int totalActiveCheckMarks;

    public List<Rooms> RoomList = new List<Rooms>();

    public void loadRoomData()
    {
        RoomList[roomNumber].AddCheckMarks();
        Debug.Log("Room Infor was loaded into Menu");
    }

    private void Start()
    {
        loadRoomData();
        totalRoomsNumber = RoomList.Count;
        currentRoom = RoomList[roomNumber].roomName;
        currentCons = RoomList[roomNumber].con.Count;
        currentPros = RoomList[roomNumber].pro.Count;
        totalProAndCons = currentCons + currentPros;
        totalActiveCheckMarks = RoomList[roomNumber].activeCheckMark;
    }
   
    
}

[Serializable]
public class Rooms
{
    public string roomName;
    public int pros;
    public int cons;
    public int activeCheckMark;
    public List<Pro> pro = new List<Pro>();
    public List<Con> con = new List<Con>();

    public void AddCheckMarks()
    {
        foreach(var checkMarks in pro)
        {
            if (checkMarks.chekMark == true)
                activeCheckMark++; 
        }
        foreach (var checkMarks in con)
        {
            if (checkMarks.chekMark == true)
                activeCheckMark++;
        }
        //   cons = con.Count;
    }
  
}

[Serializable]
public class Pro
{
    public string description;
    public bool chekMark;
    public int valueToTheCost;
}
[Serializable]
public class Con
{
    public string description;
    public bool chekMark;
    public int valueToTheCost;
}
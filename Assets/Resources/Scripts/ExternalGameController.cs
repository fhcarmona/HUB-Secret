using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ExternalGameController : MonoBehaviour
{
    const string path = "C:/Users/Romanus/Desktop/";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartProgram("CLT");
        }
    }

    private void StartProgram(string programName)
    {
        try
        {
            Process game = new Process();
            game.StartInfo.FileName = path + programName + ".exe";
            game.StartInfo.WorkingDirectory = path;
            game.Start();
        }
        catch (Exception error)
        {
            UnityEngine.Debug.Log(error.Message);
        }        
    }
}

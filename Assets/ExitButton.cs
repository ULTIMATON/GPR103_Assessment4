using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update

    public void Exit() //public void for exit button
    {
        Application.Quit(); //closes the application 
        Debug.Log("Exiting Game"); 
    }
}

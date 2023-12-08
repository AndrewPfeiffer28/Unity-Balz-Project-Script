using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Scene : MonoBehaviour
{
    //public int SceneNumber;

    public void MoveToScene(int sceneID) {

        SceneManager.LoadScene(sceneID);
    }
   
}

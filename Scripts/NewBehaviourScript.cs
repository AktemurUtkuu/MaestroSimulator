using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("AG_scence_theatre");
    }
}

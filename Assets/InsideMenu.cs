using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InsideMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }
    public void SetGame()
    {

        gameObject.SetActive(true);
    }
    public void Retry()
    {
        SceneManager.LoadScene("MayBay");
    }

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}

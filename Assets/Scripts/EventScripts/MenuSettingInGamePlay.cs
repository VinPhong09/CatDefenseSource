using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSettingInGamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject _Tower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        this.gameObject.SetActive(false);
    }

    public void Replay()
    {
        _Tower.gameObject.GetComponent<TowerScripts>().ReplayGame();
        this.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitButton(GameObject gameObject)
    {
        this.gameObject.SetActive(false);
        gameObject.GetComponent<Button>().interactable = true;
    }
    public void QuitButton2(GameObject gameObject)
   {
     gameObject.GetComponent<Button>().interactable = true;
   }
    public void QuitButton3(GameObject gameObject)
   {
     gameObject.GetComponent<Button>().interactable = true;
   }
}

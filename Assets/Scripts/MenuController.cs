using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
     [Header("Menu Screens")]
     [SerializeField] private GameObject loadingScreen;
     [SerializeField] private GameObject mainMenu;

     [Header("Slider")]
     [SerializeField] private Slider loadingSlider;

     [Header("Volume Setting")]
     [SerializeField] private TMP_Text volumeTextValue = null;
     [SerializeField] private Slider volumeSlider = null;
     [SerializeField] private float defaultVolume = 1.0f;

     [Header("Confirmation")]
     [SerializeField] private GameObject ConfirmationPrompt = null;

     [Header("Level To Load")]
     public string _newGameLevel;
     private string levelToLoad;
     [SerializeField] private GameObject noSavedGameDialog = null;

     public void NewGameDialogYes() 
     {
          SceneManager.LoadScene(_newGameLevel);
     }

     public void LoadGameDialogYes() {
          if(PlayerPrefs.HasKey("SavedLevel"))
          {
               levelToLoad = PlayerPrefs.GetString("SavedLevel");
               //SceneManager.LoadScene(levelToLoad);
               mainMenu.SetActive(false);
               loadingScreen.SetActive(true);

               StartCoroutine(LoadLevelAsync(levelToLoad));
          }
          else
          {
               noSavedGameDialog.SetActive(true);
          }
     }

     IEnumerator LoadLevelAsync(string levelToLoad) 
     {
          AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);

          while(!loadOperation.isDone)
          {
               float propressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
               loadingSlider.value = propressValue;
               yield return null;
          }
     }

     public void ExitButton() {
          Application.Quit();
     }

     public void SetVolume(float volume) 
     {
          AudioListener.volume = volume;
          volumeTextValue.text = volume.ToString("0.0");
     }

     public void VolumeApply() 
     {
          PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
          StartCoroutine(ConfirmationBox());
     }

     public void ResetButton(string MenuType)
     {
          if(MenuType == "Audio") {
               AudioListener.volume = defaultVolume;
               volumeSlider.value = defaultVolume;
               volumeTextValue.text = defaultVolume.ToString("0.0");
               VolumeApply();
          }
     }

     public IEnumerator ConfirmationBox() 
     {
          ConfirmationPrompt.SetActive(true);
          yield return new WaitForSeconds(2);
          ConfirmationPrompt.SetActive(false);
     }
}



   

   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject _GuideUI;
    [SerializeField] protected GameObject _MenuUI;

    [Header("Loading Progress")]
    [SerializeField] protected Slider _LoadingBarSlider;
    [SerializeField] protected Text _LoadingText;
    [SerializeField] [Range(0, 1)] private float progressAnimationMultiplier = 0.25f;

    private AsyncOperation loadOperation;

    private float currentValue;
    private float targetValue;

    bool _isloadbar = false;


    void Start()
    {
        _LoadingBarSlider.value = currentValue = targetValue = 0;
        var currentScene = SceneManager.GetActiveScene();
        loadOperation = SceneManager.LoadSceneAsync("GamePlay");
        loadOperation.allowSceneActivation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isloadbar)
            LoadBarProgress();
    }

    public void newGame(GameObject _btn)
    {
        _isloadbar = true;
        _MenuUI.gameObject.SetActive(false);
        _LoadingBarSlider.gameObject.SetActive(true);
        _GuideUI.gameObject.SetActive(false);
        _btn.gameObject.GetComponent<AudioSource>().Play();
        //StartCoroutine(LoadScene());
    }
    IEnumerator LoadScene()
    {
        _MenuUI.gameObject.SetActive(false);
        _LoadingBarSlider.gameObject.SetActive(true);
        AsyncOperation Oper = SceneManager.LoadSceneAsync("GamePlay");

        while(!Oper.isDone)
        {
            float progressValue = Mathf.Clamp01(Oper.progress / 0.9f);

            _LoadingText.text = "Loading... " +progressValue * 100 + "%";
            _LoadingBarSlider.value = progressValue;
            Debug.Log("Progress" + progressValue * 100);

            yield return null;
        }
    }

    public void Guide(GameObject _btn)
    {
        _GuideUI.gameObject.SetActive(true);
        _MenuUI.gameObject.SetActive(false);
        _btn.gameObject.GetComponent<AudioSource>().Play();
    }

    public void Quit(GameObject _btn)
    {
        _btn.gameObject.GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void OpenGuide()
    {
        _GuideUI.gameObject.SetActive(true);
    }
    public void CloseGuide()
    {
        _GuideUI.gameObject.SetActive(false);
        _MenuUI.gameObject.SetActive(true);
    }

    void LoadBarProgress()
    {
        targetValue = loadOperation.progress/0.9f;
        currentValue = Mathf.MoveTowards(currentValue, targetValue, progressAnimationMultiplier * Time.deltaTime);
        _LoadingBarSlider.value = currentValue;
        _LoadingText.text = "Loading... " + Mathf.RoundToInt(currentValue * 100)+ "%";
        if (Mathf.Approximately(currentValue, 1))
        {
            StartCoroutine(ActiveScene());
        }
    }
    IEnumerator ActiveScene()
    {
        yield return new WaitForSeconds(1f);
        loadOperation.allowSceneActivation = true;
    }
}

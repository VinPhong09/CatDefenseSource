using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManageScriptInGamePlay : MonoBehaviour
{

    [SerializeField] protected GameObject _MenuSetting;
    [SerializeField] protected GameObject _TowerScript;

    bool _isclickAudio = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_TowerScript.gameObject.GetComponent<TowerScripts>().getHealth()<=0)
        {
            _MenuSetting.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Setting(GameObject gameObject)
    {
         _MenuSetting.gameObject.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void Setting1(GameObject gameObject)
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void Setting2(GameObject gameObject)
    {
        gameObject.GetComponent<Button>().interactable = false;
    }
    public void AudioSetting()
    {
        _isclickAudio = !_isclickAudio;
        if(_isclickAudio)
        {
            AudioListener.volume = 0;
        }else if (!_isclickAudio)
        {
             AudioListener.volume = 1;
        }

    }
}

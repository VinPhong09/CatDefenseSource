using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePage : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Page Object")]
    [SerializeField] protected List<GameObject> _pageGameObject;

    private int i;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void NextPage(GameObject _btn)
    {
        i++;
        _btn.GetComponent<AudioSource>().Play();
        if(i <= _pageGameObject.Count - 1)
        {
            _pageGameObject[i].gameObject.SetActive(true);
            _pageGameObject[i-1].gameObject.SetActive(false);
        }else if(i >= _pageGameObject.Count - 1)
        {
            _pageGameObject[i-1].gameObject.SetActive(false);
            i = 0;
            _pageGameObject[i].gameObject.SetActive(true);
        }
    }

    public void PreviousePage(GameObject _btn)
    {
        _btn.GetComponent<AudioSource>().Play();
        i--;
        if(i >=0)
        {
            _pageGameObject[i].gameObject.SetActive(true);
            _pageGameObject[i+1].gameObject.SetActive(false);
        }else if(i <0)
        {
            _pageGameObject[i+1].gameObject.SetActive(false);
            i = _pageGameObject.Count - 1;
            _pageGameObject[i].gameObject.SetActive(true);
        }
    }

    public void DiscordOpen()
    {
        Application.OpenURL("https://discord.gg/AM6xW5NW");
    }

    public void FacebookOpen()
    {
        Application.OpenURL("https://www.facebook.com/vin.dongphong");
    }

    public void InstragramOpen()
    {
        Application.OpenURL("https://www.instagram.com/callmezin.n/");
    }

    public void GithubOpen()
    {
        Application.OpenURL("https://github.com/VinPhong09");
    }
}

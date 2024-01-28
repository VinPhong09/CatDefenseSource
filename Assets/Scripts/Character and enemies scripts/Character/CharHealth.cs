using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharHealth : MonoBehaviour
{

    //Health Variable
    Character _CharacterScripts;
    public float _MaxHealth;
    float _CurrentHealth;
    [SerializeField]  protected GameObject _PopUpDamage;

    [SerializeField]  protected GameObject _PopUpHealth;
    [SerializeField] protected Slider _HealthBarSlider;

    public bool _isDead = false;

    //Get Component
    Animator _Anim,_AnimFixed;

    float _CurrenVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        _CharacterScripts = this.gameObject.GetComponent<Character>();
          // Set Begin Health
        _MaxHealth = _CharacterScripts._MaxHealth;
        _PopUpDamage = _CharacterScripts._PopUpDamage;
        _PopUpHealth = _CharacterScripts._PopUpHealth;
        _HealthBarSlider = _CharacterScripts._HealthBarSlider;

        //
        _CurrentHealth = _MaxHealth;
        _HealthBarSlider.maxValue = _CurrentHealth;
        _HealthBarSlider.value = _CurrentHealth;


        // Getcomponent
        _Anim = gameObject.GetComponent<Animator>();
        _AnimFixed = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SmoothHealthSlider();
    }

#region HealthPlayerManagement
    public void addDamage(float _Damage)
    {
        _CurrentHealth -= _Damage;
        ShowDamagePopUp(_Damage);
        if(_CurrentHealth <= 0 )
        {
            //fixed Murad Anim
            if(gameObject.name =="CatMurad Fixed")
                _AnimFixed.SetBool("Die",true);
            else
                _Anim.SetBool("Die",true);
            Invoke("charDeath",3f);
            foreach(Collider2D c in GetComponents<Collider2D>())
                c.enabled = false;
        }
    }

    public void charDeath()
    {
        this.gameObject.SetActive(false);
        _isDead = true;
    }

    public void charReborn()
    {
        _CurrentHealth = _MaxHealth;
        this.gameObject.SetActive(true);
        foreach(Collider2D c in GetComponents<Collider2D>())
                c.enabled = true;
    }

    public bool getDead()
    {
        return _isDead;
    }

    public void setDead(bool _var)
    {
        _isDead = _var;
    }
    public void addHealth(float _Health)
    {
        _CurrentHealth += _Health;
        ShowHealthRestonePopUp(_Health);
    }

    void SmoothHealthSlider()
    {
        float _CurrentValue = Mathf.SmoothDamp(_HealthBarSlider.value,_CurrentHealth, ref _CurrenVelocity, 20*Time.deltaTime); //  Smooth Slider
        _HealthBarSlider.value = _CurrentValue;
    }
    public float getHealthPlayer()
    {
        return _CurrentHealth;
    }


    public void SetMaxHealth(float UpHealth)
    {
        _MaxHealth += UpHealth;
        _HealthBarSlider.maxValue = _MaxHealth;
        _CurrentHealth = _MaxHealth;
        _CharacterScripts._MaxHealth = (int)_MaxHealth;
    }

    public int GetTextMaxHealth()
    {
        return (int)_MaxHealth;
    }
    void ShowDamagePopUp(float _Damage)
    {
        GameObject TextDamage = Instantiate(_PopUpDamage,new Vector2(gameObject.transform.position.x + Random.Range(-0.1f,0.2f) ,gameObject.transform.position.y + Random.Range(1.4f,1.7f)),Quaternion.identity); 
        TextDamage.GetComponent<TextMesh>().text = " " + _Damage.ToString();
    }

    void ShowHealthRestonePopUp(float _Damage)
    {
        GameObject TextDamage = Instantiate(_PopUpHealth,new Vector2(gameObject.transform.position.x + Random.Range(-0.1f,0.2f) ,gameObject.transform.position.y + Random.Range(1.4f,1.7f)),Quaternion.identity); 
        TextDamage.GetComponent<TextMesh>().text = " " + _Damage.ToString();
    }
#endregion
}

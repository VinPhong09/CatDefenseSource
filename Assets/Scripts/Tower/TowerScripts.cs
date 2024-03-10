using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScripts : MonoBehaviour
{

    // Health Variable
    [SerializeField] protected float _TowerHealth;
    float _TowerCurrentHealth,_CurrenValue;
    float _CurrenVelocity = 0;
    [SerializeField] protected Slider _TowerHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        _TowerCurrentHealth = _TowerHealth;
        _TowerHealthBar.maxValue = _TowerHealth;
        _TowerHealthBar.value = _TowerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        SmoothSlider();
        
    }

    public void addDamage(float Damage)
    {
        _TowerCurrentHealth -= Damage;
    }

    public float getHealth()
    {
        return _TowerCurrentHealth;
    }

    public void ReplayGame()
    {
        _TowerCurrentHealth = _TowerHealth;
        Time.timeScale = 1;
    }
    void SmoothSlider()
    {
        _CurrenValue = Mathf.SmoothDamp(_TowerHealthBar.value,_TowerCurrentHealth, ref _CurrenVelocity, 20*Time.deltaTime);
        _TowerHealthBar.value = _CurrenValue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    //Health Variable
    [SerializeField] protected float _Health;
    float _CurrentHealth;
    [SerializeField]  protected GameObject _PopUpDamage;
    [SerializeField] protected Slider _HealthBarSlider;


    //GetComponent
    EnemyScripts EScripts;

    // Start is called before the first frame update
    void Start()
    {
        //Sett Health Begin
        _HealthBarSlider.maxValue = _Health;
        _HealthBarSlider.value = _CurrentHealth = _Health;

        //GetComponent
        EScripts = gameObject.GetComponent<EnemyScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        _HealthBarSlider.value = _CurrentHealth;
    }

#region HealthManagement
   public void addDamage(int Damage, string _Crit)
   {
      ShowDamagePopUp(Damage,_Crit);
      _CurrentHealth -= Damage;
      _HealthBarSlider.value = _CurrentHealth;
      if(_CurrentHealth <= 0 )
      {
         EScripts.IsDead();
         Destroy(EScripts);
         Destroy(gameObject,1.5f);
         _HealthBarSlider.gameObject.SetActive(false);
         foreach (Collider2D c in GetComponents<Collider2D>())
            c.enabled = false;
      }
   }

   void ShowDamagePopUp(float _Damage, string _Crit)
   {
      GameObject TextDamage = Instantiate(_PopUpDamage,new Vector2(gameObject.transform.position.x + Random.Range(-0.2f,0f),gameObject.transform.position.y + Random.Range(1f,1.25f)),Quaternion.identity); 
      if(_Crit =="Crit")
      {
         TextDamage.GetComponent<TextMesh>().color = Color.red;
         TextDamage.GetComponent<TextMesh>().text = " " + _Damage.ToString();
      }
      else
      {
         TextDamage.GetComponent<TextMesh>().color = Color.white;
         TextDamage.GetComponent<TextMesh>().text = " " + _Damage.ToString();
      }

   }
    public float getHealthEnemy()
   {
      return _CurrentHealth;
   }

   public void SetHealthEnemy(float _Health)
   {
      this._Health += _Health;
      _HealthBarSlider.maxValue = _Health;
      _HealthBarSlider.value = _CurrentHealth = _Health;
   }
#endregion

}

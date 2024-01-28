
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    [Header("Player GameObject")]
    [SerializeField] protected GameObject _BoxerGameobject;
    [SerializeField] protected GameObject _FoloGameobject;
    [SerializeField] protected GameObject _MuradGameobject;
    [SerializeField] protected GameObject _VampireGameobject;

    

    [SerializeField] protected List<GameObject> _EnemyPrefabs;

    [SerializeField] protected Text _TextLevelGame;
    public GameObject _EnemySpawnPosition;
    
    

    List<GameObject> _EnemiesSpawnerList;

    [SerializeField] protected int _EnemyAmount ;

    [SerializeField] protected float _NexttimeSpawn = 5f;


    //Button 
    [SerializeField] protected GameObject _AttackBtn;

    int _countEnemy = 0;
    GameObject [] _AllEnemies;
    int _EnemyLevel = 1;
    float _DamageLv = 0;
    float _currenttime = 0;
    
    float _CountTimeRebornBoxer;
    float _CountTimeRebornFolo;
    float _CountTimeRebornMurad;
    float _CountTimeRebornVampire;

    int _HealthLV;


    // Start is called before the first frame update

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        EnemySpawnManage();
        TimeRebornManage();
        EnemyLevelUp();
        _TextLevelGame.text = "Level: " + _EnemyLevel;
    }

#region  Enemy
    void EnemySpawnManage()
    {
        _AllEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(_AllEnemies.Length == _EnemyAmount)
            return;
        SpawnerEnemy();
    }

    public void SpawnerEnemy()
    {
        if(_currenttime < Time.time)
        {
            _currenttime = Time.time + _NexttimeSpawn;
            _countEnemy++;   
            GameObject EnemyGO = Instantiate(_EnemyPrefabs[0],new Vector2(_EnemySpawnPosition.transform.position.x,_EnemySpawnPosition.transform.position.y + Random.Range(0f,-3f)) , Quaternion.identity) as GameObject;
            EnemyGO.GetComponent<EnemyHealth>().SetHealthEnemy(_HealthLV);
            EnemyGO.GetComponentInChildren<HitBoxE>().setDamageEnemy(_DamageLv);
        }
    }

    public void Replay()
    {

        _AttackBtn.SetActive(true);
        foreach(var clone in _AllEnemies)
        {
            Destroy(clone);
        }
        this.gameObject.SetActive(false);
    }
    void EnemyLevelUp()
    {
        if(_countEnemy >= 10)
        {
            _EnemyLevel++;
            _EnemyAmount += 2;
            _countEnemy = 0;
            _HealthLV += 50;
            _DamageLv +=5;
        }
        
    }
    public List<GameObject> GetEnemySpawnerList()
    {
        return _EnemiesSpawnerList;
    }

    void DelaytimeRebornBoxer()
    {
        _CountTimeRebornBoxer += Time.deltaTime;
        if(_CountTimeRebornBoxer >= 15)
        {
            _BoxerGameobject.gameObject.SetActive(true);
            _CountTimeRebornBoxer = 0;
        }
    }
    void DelaytimeRebornFolo()
    {
        _CountTimeRebornFolo += Time.deltaTime;
        if(_CountTimeRebornFolo >= 15)
        {
            _FoloGameobject.gameObject.SetActive(true);
            _CountTimeRebornFolo = 0;
        }
    }
    void DelaytimeRebornMurad()
    {
        _CountTimeRebornMurad += Time.deltaTime;
        if(_CountTimeRebornMurad >= 15)
        {
            _MuradGameobject.gameObject.SetActive(true);
            _CountTimeRebornMurad = 0;
        }
    }
    void DelaytimeRebornVampire()
    {
        _CountTimeRebornVampire += Time.deltaTime;
        if(_CountTimeRebornVampire >= 15)
        {
            _VampireGameobject.gameObject.SetActive(true);
            _CountTimeRebornVampire = 0;
        }
    }
    void TimeRebornManage()
    {
        if(!_BoxerGameobject.activeInHierarchy)
            DelaytimeRebornBoxer();

        if(!_FoloGameobject.activeInHierarchy)
            DelaytimeRebornFolo();

        if(!_MuradGameobject.activeInHierarchy)
            DelaytimeRebornMurad();

        if(!_VampireGameobject.activeInHierarchy)
            DelaytimeRebornVampire();
    }
#endregion
}

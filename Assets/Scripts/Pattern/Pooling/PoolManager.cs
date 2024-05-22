using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.VinExtension;

public class PoolManager : Singleton<PoolManager>
{
    private List<GameObject> _enemyGameObjects;
    private List<IController> _enemyControllers;
    private List<Dictionary<GameObject, IController>> _enemyPool;
    private PoolFactory _poolFactory;
    private int _poolSize;
    private Transform _enemySpawnPoint;
    
    public void Initialize()
    {
        _enemyGameObjects = CharacterManager.Instance.GetEnemyGameObjectList();
        _enemySpawnPoint = SpawnManager.Instance.EnemySpawnPoint.transform;
        _poolFactory = this.gameObject.AddComponent<PoolFactory>();
        _enemyPool = new List<Dictionary<GameObject, IController>>();
        _poolSize = 5;
        InitializePool();
    }

    private void InitializePool()
    {
        foreach (var enemy in _enemyGameObjects)
        {
            for (int i = 0; i < _poolSize; i++)
            {
                var newDict = _poolFactory.CreatePool(enemy, _enemySpawnPoint);
                _enemyPool.Add(newDict);
            }
        }
    }
    
    public void OnPoolEnable()
    {
        foreach (var x in _enemyPool)
        {
            foreach (var enemy in x)
            {
                if (!enemy.Key.activeInHierarchy)
                {
                    enemy.Key.transform.position = _enemySpawnPoint.position + RandomPosition();
                    enemy.Key.SetActive(true);
                }
            }
        }
    }

    private Vector3 RandomPosition()
    {
        var positionX = Random.Range(1.2f,2.0f);
        var positionY = Random.Range(-4, 0);
        return new Vector3(positionX, positionY,0);
    }

    public void ReturnObjectToPool(GameObject gameObject)
    {
        foreach (var x in _enemyPool)
        {
            foreach (var enemy in x)
            {
                if(gameObject == enemy.Key)
                    enemy.Key.SetActive(false);
            }
        }
        
    } 

    public void Handle()
    {
        HandlePool();
    }

    private void HandlePool()
    {
        foreach (var x in _enemyPool)
        {
            foreach (var enemy in x)
            {
                enemy.Value.Handle();
            }
        }
    }
}

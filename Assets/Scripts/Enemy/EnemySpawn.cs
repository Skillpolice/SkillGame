using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPref;
    [SerializeField] private int _enemyCount;

    private List<Enemy> _enemyPool;

    private void Awake()
    {
        _enemyPool = new List<Enemy>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

        foreach (var item in _enemyPool)
        {
            if (!item.gameObject.activeSelf)
            {
                item.gameObject.SetActive(true);
                item.transform.position = transform.position;
            }
        }
    }


    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);

            if (_enemyPool.Count - 1 < _enemyCount)
            {
                GameObject enemy = Instantiate(_enemyPref, transform.position, Quaternion.identity);
                _enemyPool.Add(enemy.GetComponent<Enemy>());
            }

        }
    }
}

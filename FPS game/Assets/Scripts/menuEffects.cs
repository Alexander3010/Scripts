using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuEffects : MonoBehaviour
{
    [SerializeField] private GameObject showflakePrefab;

    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnDelay;

    private void Start() {
        StartCoroutine(showflakesSpawner());
    }

    private void OnEnable() {
        StartCoroutine(showflakesSpawner());
    }

    private IEnumerator showflakesSpawner(){
        while(true){
            yield return new WaitForSeconds(spawnDelay);
            for(int i = 0; i<spawnPoints.Length; i++){
                Instantiate(showflakePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}

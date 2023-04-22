using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeEnemyBehaviour : enemyBehaviour
{
    [SerializeField] private AudioSource shootingSound;

    [SerializeField] private float enemyAttackSpeed;

    [SerializeField] private GameObject enemyBulletPrefab;

    [SerializeField] private Transform enemyShootingPoint;

    void Start()
    {
        base.playerHP = GameObject.FindGameObjectWithTag("player").GetComponent<playerHelth>();

        base.playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        base.enemyTransform = GetComponent<Transform>();

        StartCoroutine(enemyShoot());
    }
   private void FixedUpdate() {
        base.enemyTransform.LookAt(base.playerTransform);
   }
    private IEnumerator enemyShoot(){
        //making delay before shooting to randomize shoot time
        yield return new WaitForSeconds(Random.Range(2,5));

        while(true){
            shootingSound.Play();

            GameObject bullet = Instantiate(enemyBulletPrefab, enemyShootingPoint.position, Quaternion.identity) as GameObject;
            bullet.transform.LookAt(base.playerTransform);

            yield return new WaitForSeconds(enemyAttackSpeed);
        }
    }
}

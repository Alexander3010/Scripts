using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class playerAttack : MonoBehaviour
{
    private playerHelth playerHP;

    [SerializeField] private GameObject [] bulletPrefabArray;

    [SerializeField] private Animator attackAnimation;

    [SerializeField] private AudioSource shootingSound;

    [SerializeField] private Transform shootingPoint;

    [SerializeField]  private float delayBeforeShooting;
    private bool reloadShooting = false;

    public bool ReloadShooting{
        get{
            return reloadShooting;
        }
        set{
            reloadShooting = value;
        }
    }

    private void Start() {
        playerHP = GameObject.FindGameObjectWithTag("player").GetComponent<playerHelth>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !ReloadShooting){
            StartCoroutine(shoot());
        }
    }
    private IEnumerator shoot(){
        ReloadShooting = true;
        attackAnimation.SetTrigger("attackTrigger");
        shootingSound.Play();
        
        yield return new WaitForSeconds(delayBeforeShooting);

        switch (playerHP.PlayerDamage){
            case 2:{
                playerHP.PlayerHP -= playerHP.BulletCost;
                Instantiate(bulletPrefabArray[0], shootingPoint.position, shootingPoint.rotation);
            }
            break;
            case 3:{
                playerHP.PlayerHP -= playerHP.BulletCost;
                Instantiate(bulletPrefabArray[1], shootingPoint.position, shootingPoint.rotation);
            }
            break;
            case 4:{
                playerHP.PlayerHP -= playerHP.BulletCost;
                Instantiate(bulletPrefabArray[2], shootingPoint.position, shootingPoint.rotation);
            }
            break;
            case 5:{
                playerHP.PlayerHP -= playerHP.BulletCost;
                Instantiate(bulletPrefabArray[3], shootingPoint.position, shootingPoint.rotation);
            }
            break;
            case 8:{
                playerHP.PlayerHP -= playerHP.BulletCost;
                Instantiate(bulletPrefabArray[4], shootingPoint.position, shootingPoint.rotation);
            }
            break;
            case 10:{
                playerHP.PlayerHP -= playerHP.BulletCost;
                Instantiate(bulletPrefabArray[5], shootingPoint.position, shootingPoint.rotation);
            }
            break;
        }

        ReloadShooting = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCollusion : MonoBehaviour
{
    //enemy damage values
    [SerializeField] private int enemyBulletDamage; 
    [SerializeField] private int enemyMeeleAttackDamage; 
    [SerializeField] private int trapDamage;


    // properties of getting damage
    [SerializeField] private Image damagePanel;
    [SerializeField] private Color getDamageColor;
    [SerializeField] private Color baseColor;
    [SerializeField] private AudioSource getDamageSound;

    private playerHelth playerHP;

    private void Start() {
        playerHP = GetComponent<playerHelth>();
    }

    private IEnumerator getDamageEffect(){
        getDamageSound.Play();
        damagePanel.color = getDamageColor;
        yield return new WaitForSeconds(0.15f);
        damagePanel.color = baseColor;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("enemyBullet1")){
            StartCoroutine(getDamageEffect());
            playerHP.PlayerHP -= enemyBulletDamage;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("enemyAttack")){
            StartCoroutine(getDamageEffect());
            playerHP.PlayerHP -= enemyMeeleAttackDamage;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("trap")){
            StartCoroutine(getDamageEffect());
            playerHP.PlayerHP -= trapDamage;
        }
    }
}

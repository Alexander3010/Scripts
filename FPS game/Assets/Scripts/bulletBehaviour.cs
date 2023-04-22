using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Transform transformBullet;

    private void Start(){
        transformBullet = GetComponent<Transform>();

        StartCoroutine(autoDelete());
    }

    private void FixedUpdate() {
        transformBullet.localPosition += transform.forward*bulletSpeed*Time.fixedDeltaTime;
    }

    private IEnumerator autoDelete(){
        yield return new WaitForSeconds(5f);   
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("wall")){
            Destroy(gameObject);
        }    
    }
}

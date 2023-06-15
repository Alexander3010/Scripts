using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    public float axeSpeed;
    private Transform axeTransform;

    private void Start() {
        axeTransform = GetComponent<Transform>();
        
        StartCoroutine(autoDelete());
    }
    private void Update() {
        axeTransform.localPosition += transform.forward*axeSpeed*Time.deltaTime;
    }
    private IEnumerator autoDelete(){
        yield return new WaitForSeconds(5f);
    }
}

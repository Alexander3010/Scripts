using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    private int indexColor;
    [SerializeField] private Color [] meshColor, emissionColor;
    [SerializeField] private Renderer rendererObject;

    private void OnMouseDown() {
        indexColor = Random.Range(0,5);
        rendererObject.material.color = meshColor[indexColor];
        rendererObject.material.SetColor("_EmissionColor", emissionColor[indexColor]);
    }
}

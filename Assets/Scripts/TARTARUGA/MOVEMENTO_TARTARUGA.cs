using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENTO_TARTARUGA : MonoBehaviour
{

    public float Velocidade = 1;

    // Start is called before the first frame update
    void Start()
    {
        Velocidade = Random.Range(Velocidade/2, Velocidade*2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Velocidade);
    }

}

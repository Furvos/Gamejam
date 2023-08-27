using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Tortuguita;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) 
        {
            Tortuguita.SetActive(true);
        }
        //var o = Instantiate(Tortuguita);
        //o.transform.Translate(Random.Range(-20, 20), Random.Range(-20, 20), 0);

    }
}

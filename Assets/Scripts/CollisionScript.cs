using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    private Collider2D _useInteractive;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Portal") || other.tag.Equals("Tartaruga") || other.tag.Equals("Peixe"))
        {
            _useInteractive = other;
        }
    }

    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Portal") || other.tag.Equals("Tartaruga") || other.tag.Equals("Peixe"))
        {
            _useInteractive = null;
        } 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_useInteractive != null)
                _useInteractive.GetComponent<PortalChangeScene>().loadNextScene();
        }
    }
}

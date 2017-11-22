using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DeleteGameObjectManager is attached to a block under the screen, 
/// and it deletes all objects that collides with it
/// </summary>

public class DeleteGameObjectManager : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

    }
}

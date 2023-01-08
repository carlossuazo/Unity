using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    float maxLifeTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // OnBecameInvisible() is a function that is called when a game object becomes invisible to any camera in the scene. 
    // This means that the object is no longer being rendered or displayed on the screen.
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

}

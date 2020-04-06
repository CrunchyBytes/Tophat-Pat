using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    public References prefabReferences;    
    //public Rigidbody2D rb;
    GameObject player, tophatSpawner;//, generatedTophat;
    public int stackedTophats = 0;

    Rigidbody2D rigidBody;
    
    // Apparently .GetComponent<Component>() assignation must go within an Awake() or Start() method.
    void Awake() 
    {
        //Debug.Log("I HAVE AWOKEN!!");
        player = prefabReferences/*.GetComponent<References>()*/.player;
        tophatSpawner = prefabReferences/*.GetComponent<References>()*/.tophatSpawner;
        //stackedTophats = tophatSpawner.GetComponent<Spawner>().stackedTophats;
        //generatedTophat = tophatSpawner.GetComponent<Spawner>().Spawn();
        //stackedTophats = prefabReferences.counter.stackedTophats;
        rigidBody = GetComponent<Rigidbody2D>();//prefabReferences.playControl.GetComponent<Rigidbody2D>();
    }
    
    /*void Update() 
    {
        stackedTophats = prefabReferences.counter.stackedTophats;
        
    }*/
    
    void OnCollisionEnter2D(Collision2D other) 
    {
        // Only recovers its original value. Does not update.
        //generatedTophat = tophatSpawner.GetComponent<Spawner>().generatedTophat;

        // If a Tophat collides with the Player:
        if (other.gameObject.tag == "Player" && tag == "Tophat")
        {
            /* Its tag changes from "Tophat" to "Player"
             * i.e. It becomes part of the player.
             */
            /*gameObject.*/tag = "Player";

            // Its position follows that of the Player, but with a slight sway, depending on its order of stack.
            //transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.12f);
            rigidBody = prefabReferences.playControl.GetComponent<Rigidbody2D>();
            //transform.position.y = other.collider.gameObject.transform.position.y + 0.12f;                      

            // Counter for stacked tophats increases.
            stackedTophats++;

            // 
        /*generatedTophat.*/GetComponent<SpriteRenderer>().sortingOrder = stackedTophats;
            Debug.Log("Sorting Order: " + /*generatedTophat.*/GetComponent<SpriteRenderer>().sortingOrder);
        }   
    }
}

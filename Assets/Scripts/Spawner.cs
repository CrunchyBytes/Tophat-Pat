using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    /* If interested into the Script attached to a GameObject moreso than the GameObject (and its Components) in itself,
       it's much better to declare a public reference to an Object of type <Script Name> rather than the GameObject which
       the Script is attached to.
     */
    public References prefabReferences;//, generatedTophat = null;
    public float spawnTime = 5.0f, repeatRateTime = 5.0f;
    Vector3 position;
    float randomFloat;
    Color randomColor;
    //public int stackedTophats = 0;
    GameObject tophat, generatedTophat = null, morale;

    // Apparently .GetComponent<Component>() assignation must go within an Awake() or Start() method.    
    void Start()
    {
        tophat = prefabReferences/*.GetComponent<References>()*/.tophat;
        morale = prefabReferences/*.GetComponent<References>()*/.morale;

        InvokeRepeating("Spawn", spawnTime, repeatRateTime);        
    }
    
    void Update() 
    {
        randomFloat = Random.Range(-2.26f, 2.26f);
        position = new Vector3(randomFloat/*-0.96f*/, 5.23f, 0.0f);
        randomColor = Random.ColorHSV();

        if (generatedTophat != null)
        {
            if (generatedTophat.transform.position.y <= -5.32)
            {
                /* If not for the public reference to the Script, rather than the GameObject it's attached to, accessing
                   its variables fields wouldn't have been possible.
                 */
                //Debug.Log("Morale's Children: " + morale.transform.childCount);//Child(2).GetComponent<Image>().source = null;
                //morale.transform.getChild(2).GetComponent<Image>().source = null;
                //Debug.Log("Morale's tag: " + morale.tag);
                Destroy(generatedTophat);
            }
        }
        
    }

    void Spawn()
    {
        Debug.Log("Random: " + randomFloat);

        generatedTophat = Instantiate(tophat, position, Quaternion.identity);
        generatedTophat.GetComponent<SpriteRenderer>().color = randomColor;        
    }
}

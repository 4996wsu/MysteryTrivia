using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open : MonoBehaviour

{
    public GameObject thisChest;
    public Animation chestOpen;
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collide");
        if(collision.gameObject.tag=="Player"){
        Debug.Log("opening chest");
        chestOpen.Play();
        }
    }
    public void DelayedDestroy(){
        Destroy(thisChest);
    }
    
    
        
        
        
    

}

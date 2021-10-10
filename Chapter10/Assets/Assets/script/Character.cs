using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character: MonoBehaviour {
   private Rigidbody2D rb;
   private float dirX, dirY, moveSpeed;
   float spawnTimer = 5f;

   [SerializeField]
   private GameObject pumpkin;

   // Start is called before the first frame update 
   void Start() 
   {
      rb = GetComponent < Rigidbody2D >();
      moveSpeed = 5f;
      SpawnPumpkin();
      
   }
   // Update is called once per frame 
   void Update() 
   {
      dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
      dirY = Input.GetAxisRaw("Vertical") * moveSpeed;
   }
   private void FixedUpdate() 
   {
      rb.velocity = new Vector2(dirX, dirY);
   }

   private void SpawnPumpkin() 
   {
      spawnTimer = Random.Range(5f,5f);
      bool pumpkinSpawned = false;
      while (!pumpkinSpawned) 
      {
         Vector3 pumpkinPosition = new Vector3(Random.Range(-7f, 7f), Random.Range(-4, 4f), 0f);
         if ((pumpkinPosition - transform.position).magnitude < 3) 
         {
            spawnTimer = Random.Range(5f,5f);
         } 
         else 
         {
            Instantiate(pumpkin, pumpkinPosition, Quaternion.identity);
            pumpkinSpawned = true;
            
            
         }
      }
      
   }


   private void OnTriggerEnter2D(Collider2D collision) 
   {   
        Nilai.scoreAmount += 10;
        SpawnPumpkin();
        Destroy(collision.gameObject);

   }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour {

	
	 private void OnCollisionEnter(Collision col)
     {
         if (col.collider.name == "projectile") {
             Destroy(gameObject);
         }
     }
	 
	 void update() {
		 Destroy(gameObject);
	 }
}

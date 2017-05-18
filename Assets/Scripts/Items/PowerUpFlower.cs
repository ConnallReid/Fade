using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFlower : Collectable {

	public int itemID = 1;
	public GameObject projectlePrefab;

	override protected void OnCollect(GameObject target){
		var equipBehavior = target.GetComponent<Equip> ();
		if (equipBehavior != null) {
			equipBehavior.currentItem = itemID;
		
		}
		var shootBehavior = target.GetComponent<FireProjectile> ();
		if (projectlePrefab != null) {
			shootBehavior.ProjectlePrefab = projectlePrefab;
		}
	}
}

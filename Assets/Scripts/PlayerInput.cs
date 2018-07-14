using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	// Use this for initialization
	public float moveSpeed;
	Vector2 target;
	public int leftMouse;
	public int rightMouse;
	public float clickLifetime;
	public GameObject clickObj;
	public Rigidbody2D projectile;
	public float projectileLifetime;
	public int projectileLimit;
	public int clickLimit;
	public int projectileTotal;
	public int clickTotal;
	public float projectileSpeed;
	public GameObject temp;
	public bool autoFlag;
	
	void Start () {
		moveSpeed = 5.0f;
		clickLifetime = 0.1f;
		projectileLifetime = 3.0f;
		leftMouse = 0;
		rightMouse = 1;
		target = transform.position;
		projectileLimit = 5;
		clickLimit = 5;
		projectileTotal = 0;
		clickTotal = 0;
		projectileSpeed = 200f;
		autoFlag = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (Input.GetMouseButton(rightMouse)) {
			target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			clickObj = (GameObject)Instantiate(Resources.Load("Prefabs/Click"), target, Quaternion.identity);
			clickTotal++;
			checkLimit(clickLimit, ref clickTotal, GameObject.Find("clickObj"));
			Destroy (clickObj, clickLifetime);
		}
		
		if (Input.GetKey(KeyCode.A)) {
			autoFlag = !autoFlag;
		}
		
		if (Input.GetMouseButton(leftMouse)) {
			if (autoFlag == true) {
				autoAttack();
			}
		}
		
		if (Input.GetKey(KeyCode.Q)) {
			keyboardInputQ();
		}
		
		if (Input.GetKey(KeyCode.W)) {

		}
		
		if (Input.GetKey(KeyCode.E)) {

		}
		
		if (Input.GetKey(KeyCode.R)) {

		}
		
		transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
	}
	
	/*void checkLimit(int limit, ref int total, string name) {
		if (limit == total && total > 0) {
			Destroy(GameObject.Find(name));
			total--;
		}
	}*/
	
	void checkLimit(int limit, ref int total, GameObject go) {
		if (limit <= total && total > 0) {
			Destroy(go);
			total--;
		}
	}
	
	void checkLimit(int limit, ref int total, Component comp) {
		if (limit <= total && total > 0) {
			Destroy(comp);
			total--;
		}
	}
	
	void autoAttack() {
	}
	
	void keyboardInputQ() {
		temp = (GameObject)Instantiate(Resources.Load("Prefabs/Projectile"), transform.position, Quaternion.identity);
		projectile = temp.GetComponent<Rigidbody2D>();
		projectile.AddForce(Camera.main.ScreenToWorldPoint(Input.mousePosition) * projectileSpeed);
		projectileTotal++;
		checkLimit(projectileLimit, ref projectileTotal, projectile.GetComponent<Rigidbody>());
		Destroy (projectile, projectileLifetime);
	}
}

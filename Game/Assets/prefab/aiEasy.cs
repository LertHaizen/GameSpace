using UnityEngine;
using System.Collections;

public class aiEasy : MonoBehaviour {

	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float enemyMovementSpeed;
	public float damping;
	//bool Un = false;
	//float speed;
	public GameObject Player;
	Rigidbody theRigidbody;
	Renderer myRender;

	void Start () {
		myRender = GetComponent<Renderer>();
		//speed = enemyMovementSpeed;
		theRigidbody = GetComponent<Rigidbody>();
		Player = GameObject.FindWithTag("Player");
	}
	void Awake()
	{
		
	}
	void FixedUpdate () {
		//fpsTarget = Vector3.Transform(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z);
		fpsTargetDistance = Vector3.Distance(Player.transform.position,transform.position);
		if (fpsTargetDistance<enemyLookDistance){
			myRender.material.color=Color.yellow;
			lookAtPlayer ();
		}
		if (fpsTargetDistance < attackDistance) {
			myRender.material.color = Color.red;
			
			attackPlease ();
		} else {
			myRender.material.color = Color.blue;
		}
		//if (Un = true)
        //{
		//	enemyMovementSpeed = speed;
       // }
	}
	
	void lookAtPlayer(){
		Quaternion rotation = Quaternion.LookRotation(Player.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime*damping);
		
	}

	void attackPlease(){
		theRigidbody.AddForce(transform.forward*enemyMovementSpeed);
	}
	//public void UnSec()
	//{
	//	Un = false;
	//}
	//private void OnTriggerStay(Collider other)
	//{

	//	if (other.gameObject.tag == "Player" && Un == false)
	//	{
		
	//	}
	//}
}

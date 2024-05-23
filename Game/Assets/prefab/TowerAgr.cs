using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAgr : MonoBehaviour
{
	public float fpsTargetDistance;
	public float enemyLookDistance;
	public float attackDistance;
	public float damping;
	private float TimeShoot = 0;
	public GameObject Enemy;
	Rigidbody theRigidbody;
	Renderer myRender;
	// Поле для хранения позиции спавна
	public Transform Bullet_Spawn;
	// Поле, хранящая префаб снаряда
	public GameObject Bullet;
	void Start()
	{
		myRender = GetComponent<Renderer>();
		theRigidbody = GetComponent<Rigidbody>();
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
	}
	void FixedUpdate()
	{
		Debug.Log(TimeShoot);
		Debug.DrawRay(Bullet_Spawn.position, Bullet_Spawn.forward * 100, Color.red);
		fpsTargetDistance = Vector3.Distance(Enemy.transform.position, transform.position);
		if (fpsTargetDistance < enemyLookDistance)
		{
			lookAtPlayer();
			
		}
		if (TimeShoot >= 1)
		{
			Debug.Log("Цель порожена");
			// Создаем объект на основе префаба без вращений
			GameObject Shoot = Instantiate(Bullet, Bullet_Spawn.position, Quaternion.identity);
			Vector3 direction = Bullet_Spawn.forward;
			Debug.Log(direction);
			TimeShoot = 0;
			Shoot.GetComponent<Rigidbody>().velocity = direction * 50;
		}
        
	}
	void lookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation(Enemy.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        TimeShoot = TimeShoot + Time.deltaTime;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrpPlayer : MonoBehaviour {

	//A public float for speed.
	public float speed = 1.0f;
	public GameObject m_BulletPrefab = null;
	public int bulletCount = 0;

	// Use this for initialization
	void Awake ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log(bulletCount);

		Vector3 pos;
		pos.x = transform.position.x;

		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
			
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}


		if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(0, Time.deltaTime * 200.0f, 0);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(0, Time.deltaTime * -200.0f, 0);
		}

		if (Input.GetMouseButton(0))
		{
			GameObject copy = Instantiate(m_BulletPrefab);
			copy.transform.position = transform.position + transform.forward;

			Rigidbody rb = copy.GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 1000, ForceMode.Acceleration);
			++bulletCount;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
	// 鏡面反射するための機能
	ReflectionProbe probe;

	// Start is called before the first frame update
	void Start()
	{
		this.probe = GetComponent<ReflectionProbe>();
	}

	// Update is called once per frame
	void Update()
	{
		// y に -1 を掛けて地面の反対側へ
		this.probe.transform.position =
			new Vector3(Camera.main.transform.position.x,
			Camera.main.transform.position.y * -1,
			Camera.main.transform.position.z);
		probe.RenderProbe();
	}
}

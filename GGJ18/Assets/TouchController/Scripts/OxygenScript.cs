using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProgressBar;

public class OxygenScript : MonoBehaviour {

	ProgressBarBehaviour BarBehaviour;
	[SerializeField] float UpdateDelay = 2f;

//	void Awake()
//	{
//		BarBehaviour = GetComponent<ProgressBarBehaviour>();
//		BarBehaviour.Value = 100;
//		print("Value from awake:" + BarBehaviour.Value);
//	}
	IEnumerator Start ()
	{
		//print("Value from start:" + BarBehaviour.Value);
		BarBehaviour = GetComponent<ProgressBarBehaviour>();
		BarBehaviour.Value = 100;
		while (true)
		{
			yield return new WaitForSeconds(UpdateDelay);
			BarBehaviour.Value -= 5;
			print("new value: " + BarBehaviour.Value);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

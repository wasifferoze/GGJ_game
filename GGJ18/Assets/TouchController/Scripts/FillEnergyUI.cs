using ProgressBar;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillEnergyUI : MonoBehaviour {

	public GameObject EnergyUI;
	ProgressBarBehaviour BarBehaviour;
	SimpleTouchController TouchControl;
	[SerializeField] float UpdateDelay = 2f;
	// Use this for initialization
	IEnumerator Start ()
	{
//		BarBehaviour = EnergyUI.GetComponent<ProgressBarBehaviour>();
//		TouchControl = GetComponent<SimpleTouchController> ();
//		while (TouchControl.touchPresent == true)
//		{
//			print (TouchControl.touchPresent);
//			//if (TouchControl.touchPresent == true) {
				yield return new WaitForSeconds (UpdateDelay);
//				BarBehaviour.Value += 20;
//				print ("new value: " + BarBehaviour.Value);
//			//} else {
//			//	print ("fuck touch");
//			//}
//		}
	}
	void Update()
	{
		BarBehaviour = EnergyUI.GetComponent<ProgressBarBehaviour>();
		TouchControl = GetComponent<SimpleTouchController> ();

			print (TouchControl.touchPresent);
			if (TouchControl.touchPresent == true) {
				//yield return new WaitForSeconds (UpdateDelay);
				BarBehaviour.Value += 1;
				//print ("new value: " + BarBehaviour.Value);
			} else {
				//print ("new value: " + BarBehaviour.Value);
			}

	}
}

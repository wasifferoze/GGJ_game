using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Clickable : MonoBehaviour , IPointerClickHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
//	void Update () {
//		if (Input.GetButtonDown("Fire1"))
//		{
//			Debug.Log(Input.mousePosition);
//		}
//	}
	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log(Input.mousePosition);
	}
}

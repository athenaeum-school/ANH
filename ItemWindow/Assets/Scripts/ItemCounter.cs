using UnityEngine;
using System.Collections;

public class ItemCounter : MonoBehaviour
{
	private UILabel label;
	private int count = 0;

	void Start ()
	{
		GetLabelComponent ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void ItemIncrement()
	{	
		++count;
		for(int i = 0; i < count; i++) 
		label.text = i.ToString () + "/99";
	}

	/*public void ItemIncrementX(){
		count += 10;
		for(int i = 0; i < count; i++) 
			label.text = i.ToString () + "/99";
	}*/

	public void GetLabelComponent(){
		label = GameObject.Find("Label_Count").GetComponent<UILabel>();
	}



}
using UnityEngine;
using System.Collections;

public class ItemCounter : MonoBehaviour
{
	private UILabel[] label;
	private int count = 0;


	void Start ()
	{
		label = new UILabel[2];
		GetLabelComponent ();
	}
	
	public void LabelZeroIncrement(){	
		label[0].text = ClickCounter() + "/99";
	}

	public void LabelOneIncrement(){
		label[1].text = ClickCounter() + "/99";
	}

	public string ClickCounter(){
		++count;
		int i;
		for(i = 0; i < count; i++) {}
		return i.ToString();
	}

	public void GetLabelComponent(){
		label[0] = GameObject.Find("Label_Count_0").GetComponent<UILabel>();
		label[1] = GameObject.Find("Label_Count_1").GetComponent<UILabel>();
	}



}
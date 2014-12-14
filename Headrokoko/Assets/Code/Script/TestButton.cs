using UnityEngine;
using System.Collections;

public class TestButton : MonoBehaviour {
	public void Test_OnHoverOver () { Debug.Log ("Test_OnHoverOver"); }
	public void Test_OnHoverOut () { Debug.Log ("Test_OnHoverOut"); }
	public void Test_OnPress () { Debug.Log ("Test_OnPress"); }
	public void Test_OnRelease () { Debug.Log ("Test_OnRelease"); }
	public void Test_OnSelect () { Debug.Log ("Test_OnSelect"); }
	public void Test_OnDeselect () { Debug.Log ("Test_OnDeselect"); }
	public void Test_OnClickOrTap () { Debug.Log ("Test_OnClickOrTap"); }
	public void Test_OnDoubleClickOrTap () { Debug.Log ("Test_OnDoubleClickOrTap"); }
}
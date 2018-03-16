using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RuaContext.ParseText ("var sss=1;");
		RuaContext.ParseText ("aaa.ccc().ttt2();");
		RuaContext.ParseText ("aaa.bbb(aaa.qqq.ddd());");
//		aaa.ttt ();
//		RuaContext.ParseText ("aaa.bbb(aaa.qqq.ddd());");
//		RuaFunctionAddComponent add = new RuaFunctionAddComponent ();
//		add.gameObject = this.gameObject;
//		add.Excute ("Test");

	}

	void Update () {
		
	}
}

public class aaa {
	public static ccc qqq = new ccc();
	public static void bbb(int i) {
		Debug.LogError ("aaa.bbb" + i);
	}

	public static void ttt() {
		Debug.LogError ("ttt1");
	}

	public static ccc ccc() {
		return new ccc();
	}
}

public class ccc {
	public static int ddd() {
		Debug.LogError ("ccc.ddd");
		return 111;
	}

	public static void ttt2() {
		Debug.LogError ("ttt2");
	}
}
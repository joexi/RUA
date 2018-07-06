using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		RuaContext.ParseText ("var sss=1;");
//		RuaContext.ParseText ("aaa.ccc().ttt2();");
//		RuaContext.ParseText ("aaa.bbb(aaa.qqq.ddd());");
//		aaa.ttt ();
//		RuaContext.ParseText ("aaa.bbb(aaa.qqq.ddd());");
//		RuaFunctionAddComponent add = new RuaFunctionAddComponent ();
//		add.gameObject = this.gameObject;
//		add.Excute ("Test");
//		Debug.LogError(LengthOfLongestSubstring("cdd"));
		int[] aaa = new int[]{ 1, 2, 2 };
		RemoveDuplicates (aaa);
		for (int i = 0; i < aaa.Length; i++) {
			Debug.LogError (aaa [i]);
		}
	}

	void Update () {
		
	}

	public int RemoveDuplicates(int[] nums) {
		if (nums.Length == 0) {
			return 0;
		}
		int length = 1;
		int lastNumber = nums [0];
		for (int i = 1; i < nums.Length; i++) {
			int num_i = nums [i];
			if (num_i != lastNumber) {
				lastNumber = num_i;
				nums [length] = num_i;
				length++;
			}
		}
		return length;
	}

	public int LengthOfLongestSubstring(string s) {
		int currentIndex = 0;
		int maxLength = 0;
		int currentLength = 0;
		int offset = 0;
		for (int i = 0; i < s.Length; i++) {
			bool same = false;
			for (int j = currentIndex; j < currentIndex + currentLength; j++) {
				if (s[j] == s[i]) {
					offset = j - currentIndex + 1;
					same = true;
					break;
				}
			}
			if (same) {
				if (currentLength > maxLength) {
					maxLength = currentLength;
				}
				currentIndex += offset;
				currentLength = currentLength - offset + 1;
			}
			else {
				currentLength++;
			}
		}
		if (currentLength > maxLength) {
			maxLength = currentLength;
		}
		return maxLength;
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
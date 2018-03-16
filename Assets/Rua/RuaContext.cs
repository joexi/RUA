using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
public class RuaContext {

	public static void ParseText(string text) {
		string[] lines = text.Split (';');
		for (int i = 0; i < lines.Length; i++) {
			string line = lines [i];
			ParseLine (line);
		}
	}

	public static object ParseLine(string line) {
		for (int i = 0; i < line.Length; i++) {
			if (line [i] == '(' && line [i + 1] != ')') {
				string blocks = line.Substring (0, i);
				int startIndex = i + 1;
				if (startIndex < line.Length) {
					object param = ParseLine (line.Substring (startIndex, line.Length - startIndex));
					if (param != null) {
						return ParseBlock (blocks, new object[]{ param });
					} else {
						return ParseBlock (blocks);
					}
				} else {
					return ParseBlock (blocks);
				}
				break;
			}
		}
		return ParseBlock (line);
	}

	public static object ParseBlock(string block, object[] param = null) {
		string[] subBlocks = block.Split ('.');
		object returnValue = null;
		for (int i = 0; i < subBlocks.Length; i++) {
			returnValue = ParseBlock (returnValue, subBlocks [i], param);
		}
		return returnValue;
	}

	public static object ParseBlock(object obj, string subBlock, object[] param = null) {
		Debug.Log ("ParseBlock:" + obj + " " + subBlock);
		if (obj == null) {
			System.Type type = System.Type.GetType (subBlock);
			return Activator.CreateInstance (type);
		} else {
			System.Type type = obj.GetType ();
			subBlock = subBlock.Replace ("()", "");
			MethodInfo method = type.GetMethod (subBlock);
			if (method != null) {
				return method.Invoke (obj, param);
			} else {
				FieldInfo field = type.GetField (subBlock);
				if (field != null) {
					return field.GetValue (obj);
				} else {
					PropertyInfo property = type.GetProperty (subBlock);
					if (property != null) {
						return field.GetValue (obj);
					} else {
					}
				}
			}
		}
		return null;
	}



	private Dictionary<string, object> localVariables = new Dictionary<string, object>();

}



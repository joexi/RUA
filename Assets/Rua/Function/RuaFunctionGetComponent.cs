using UnityEngine;
using System.Collections;

public class RuaFunctionGetComponent : RuaFunction {

	public override object Excute (object param1)
	{
		base.Excute (param1);
		string component = param1 as string;
		return this.gameObject.GetComponent ("component");
	}
}

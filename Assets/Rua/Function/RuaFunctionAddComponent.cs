using UnityEngine;
using System.Collections;

public class RuaFunctionAddComponent : RuaFunction {

	public override object Excute (object param1)
	{
		base.Excute (param1);
		string component = param1 as string;
		return UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(this.gameObject, "Assets/Scripts/Rua/Unity/RuaFunctionAddComponent.cs (10,3)", component);
	}
}


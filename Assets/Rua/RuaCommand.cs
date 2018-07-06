using UnityEngine;
using System.Collections;

public class RuaCommand {
	private RuaContext context;
	public RuaCommand(string code) {
		
	}

	public RuaCommand() {

	}

	public virtual RuaCommand Make(RuaContext context, string code) {
		if (code.Contains ("=")) {
			RuaCommandSet rua = new RuaCommandSet (code);
			rua.context = context;
			return rua;
		}
		return null;
//		return new RuaCommandNormal (code);
	}
}

public class RuaCommandNormal {
	public RuaCommandNormal(string code){
		
	}
}

public class RuaCommandSet : RuaCommand {
	private RuaObject Left;
	private RuaObject Right;
	public RuaCommandSet(string code){
		string[] values = code.Split ('=');
	}
	public RuaCommandSet(){
		
	}
}
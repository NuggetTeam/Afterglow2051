using UnityEngine;
using UnityEditor;
using System.Collections;

public class CustomFungus :  ScriptableWizard{
	
	//GameObject CustomFlowchart = GameObject.Find("CustomFlowchart");
	
	[MenuItem ("Tools/CustomFlowchart")]
	
	static void CustomFlowchart() {	
	
		GameObject go = GameObject.Find("CustomFlowchart"); 
		Instantiate(go);
	}
    
}


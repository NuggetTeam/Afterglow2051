using UnityEngine;
using System.Collections;
using Fungus;

public class interactuable : MonoBehaviour {

	public Flowchart actualFlowchart;

	public bool tocar = false;

	public void LaunchFlowchart()
	{
		actualFlowchart.SendFungusMessage ("START");
	}

	public void SetFlowchart(Flowchart newFlowchart)
	{
		actualFlowchart = newFlowchart;
	}

	public void OnTriggerEnter(Collider col){
	
		if (col.gameObject.tag == "Player") {
		
			actualFlowchart.SendFungusMessage ("START");
		
		}
	
	}


}

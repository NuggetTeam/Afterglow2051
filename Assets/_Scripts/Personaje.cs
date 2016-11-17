using UnityEngine;
using System.Collections;
using Fungus;

public class Personaje : MonoBehaviour {

	public Flowchart actualFlowchart;
	
	public int Estado = 0;
	public int EstadoAnterior = 0;
	
	public bool Chupable = false;
	
	public int NAME;
	
	public void LaunchFlowchart()
	{
		actualFlowchart.SendFungusMessage ("START");
	}

	public void SetFlowchart(Flowchart newFlowchart)
	{
		actualFlowchart = newFlowchart;
	}
	
	public void ActualizarEstado(int x){
		
		EstadoAnterior = Estado;
		Estado = x;
		
	}
	
	public void ActivarChupable(){
		
		Chupable = true;
		
	}
	
	public int getName(){
		
		return NAME;
		
	}

	public void playAnimation(string AnimName){
		Debug.Log ("Mandado");
		gameObject.GetComponent<Animator> ().Play (AnimName);
	
	}
	
}

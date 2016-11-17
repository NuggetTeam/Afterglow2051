using UnityEngine;
using System.Collections;
using Fungus;

public class Acciones : MonoBehaviour {

	public int EstadoActual = 4;
	
	private GameObject LastTrigger;
	/*
	public Flowchart IRA;
	public Flowchart ALEGRIA;
	public Flowchart MIEDO;
	public Flowchart TRISTEZA;
	public Flowchart CALMA;	
	*/
	public Flowchart RECALMA;	
	public Flowchart ACTIVABLE;	
	
	public bool trigger;
	
	public GameObject colisionado; 

	public bool activo;

	public GameObject cursor;

	bool rotar = false;


	void Start () {

		activo = true;

		colisionado = null;
		
		trigger = false;
	
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.transform.tag == "Personaje"){
			
			LastTrigger = col.transform.gameObject;
			
			int EstadoAux = LastTrigger.GetComponent<Personaje>().Estado;
			
			colisionado = col.transform.gameObject;
			
			trigger = true;

			rotar = true;

			StartCoroutine ("RotarCursor");
			
			//----------------------------------------------------------Temporal
			
			//LastTrigger.GetComponent<Renderer>().material.color = GetColor(EstadoAux);
			
			//----------------------------------------------------------Temporal
			
		}

		if(col.transform.tag == "Personaje" || col.transform.tag == "Activable") cursor.GetComponent<Animator> ().Play ("Cerrar");
				
	}
	
	void OnTriggerStay(Collider col){

		if (activo) {

		if(col.transform.tag == "Activable"){
			
			if(Input.GetButtonDown("Submit") || Input.GetMouseButtonDown(0)){
					

				
					//col.transform.gameObject.GetComponent<Animator> ().SetTrigger ("Activar");

					//col.transform.gameObject.GetComponent<Animator> ().Play("Abrir");

					//col.transform.gameObject.GetComponent<Animator> ().ResetTrigger ("Activar");

					Debug.Log(col.transform.gameObject.name);
					col.GetComponent<interactuable> ().LaunchFlowchart ();

					//LaunchMoodFlowchart(6);
				
			}
			
		}
		
		else{ if(col.transform.tag == "Personaje"){
			


					if ((Input.GetButton ("Submit") || Input.GetMouseButtonDown (0)) && (!Input.GetButton ("Submit2") && !Input.GetMouseButtonDown (1))) {

						Debug.Log ("FlowchartMandado;");

						col.GetComponent<Personaje> ().LaunchFlowchart ();
				
					}
			
				}
		
			}
		}
		
		
		
	}

	void OnTriggerExit(Collider col){
		
		if(col.transform.tag == "Personaje"){
			
			//LastTrigger.GetComponent<Renderer>().material.color = GetColor(4);
			
			colisionado = null;
			
			trigger = false;
			
		}
		
		cursor.GetComponent<Animator> ().Play ("Abrir");

		rotar = false;
				
	}
	
	//----------------------------------------------------------Temporal
	public Color GetColor(int i){
	
	Color aux = Color.grey;
	
	/*switch(i){
	
		case 0: aux = Color.red;	break;
		case 1: aux = Color.cyan;	break;
		case 2: aux = Color.yellow;	break;
		case 3: aux = Color.green;	break;
		case 4: aux = Color.white;	break;
	
		default:aux = Color.white;	break;
	
	}*/
	
	return aux;
	
	}
	//----------------------------------------------------------Temporal

	public void LaunchMoodFlowchart(int x){
		
		switch(x){
		/*
		case 0: IRA.SendFungusMessage ("START"); break;
		case 1: MIEDO.SendFungusMessage ("START"); break;
		case 2: ALEGRIA.SendFungusMessage ("START"); break;
		case 3: TRISTEZA.SendFungusMessage ("START"); break;
		case 4: CALMA.SendFungusMessage ("START"); break;*/
		case 5: RECALMA.SendFungusMessage ("START"); break;
		case 6: ACTIVABLE.SendFungusMessage ("START"); break;
		default:RECALMA.SendFungusMessage ("START"); break;
		
		}
		
	}
	
	public void LaunchFlowchart(Flowchart f){
		
		f.SendFungusMessage("START");
		
	}
	
	IEnumerator RotarCursor(){
	
		while (rotar) {
		
			cursor.transform.Rotate (0f, 0f, -3f);
		
			yield return new WaitForSeconds (0.01f);

		}
		StartCoroutine ("StopRotarCursor");
		StopCoroutine ("RotarCursor");

	}

	IEnumerator StopRotarCursor(){

		while (!rotar) {

			if(cursor.transform.rotation.eulerAngles != new Vector3(0f,0f,0f))
			cursor.transform.Rotate (0f, 0f, 3f);

			yield return new WaitForSeconds (0.01f);

		}

		StopCoroutine ("StopRotarCursor");

	}


}













using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using Fungus;

public class GameController : MonoBehaviour {
	
	private GameObject player;
	public GameObject vision;
	public GameObject Camera;
	
	public int clicks = 8;
	public int contador = 0;
	
	public GameObject cube;
	
	public Bloom bloom;
	
	private bool funca = true;
	
	private bool trigger = true;
	
	public Camera cam;
	
	public GameObject Trail;
	
	//private GameObject LastTrigger;
	
	public int EstadoActual = 4;
	
	private GameObject LastTrigger;
	
	public Flowchart IRA;
	public Flowchart ALEGRIA;
	public Flowchart MIEDO;
	public Flowchart TRISTEZA;
	public Flowchart CALMA;	
	public Flowchart RECALMA;	
	public Flowchart ACTIVABLE;	
	
	public Flowchart CALMALUNCHY;	
	public Flowchart CALMAMARGARET;	
	public Flowchart CALMAJOHN;	
	
	private const int LUNCHY = 0;
	private const int MARGARET = 1;
	private const int JOHN = 2;

	public Animator cursor;
	
	
	bool active;

	bool blurring = false;

	public Transform [] Desactivables;
	public Transform [] ActivablesMiedo;
	public Transform [] ActivablesIra;


	// Use this for initialization
	void Start () {

		active = true;

		player = GameObject.FindWithTag("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.Escape)){Reiniciar();}
		
		if (vision.GetComponent<Acciones> ().trigger) {
		
			int EstadoAux = vision.GetComponent<Acciones> ().colisionado.GetComponent<Personaje> ().Estado;
			int EstadoAuxAnterior = vision.GetComponent<Acciones> ().colisionado.GetComponent<Personaje> ().EstadoAnterior;
			
			GameObject col; 
			
			//if(Input.GetKeyDown(KeyCode.T)){player.GetComponent<RigidbodyFPSWalker>().SetActive(!player.GetComponent<RigidbodyFPSWalker>().active);}



			if (Input.GetMouseButton (1) || Input.GetAxis ("LTrigger") > 0) {

					col = vision.GetComponent<Acciones> ().colisionado;

					StartCoroutine ("StartBlur");


				if ((Input.GetMouseButtonDown (0) || Input.GetAxis ("RTrigger") > 0) && trigger) {

				
					if(col.gameObject.GetComponent<Personaje>().Chupable){
					trigger = false;
					clickReceived (col, EstadoAux, EstadoAuxAnterior);}
				}
				
			} else {



				StopCoroutine ("StartBlur");
				StartCoroutine ("StopBlur");
			
			}
			
			if (Input.GetAxis ("RTrigger") == 0f) {
				trigger = true;
			}
		

			
		} else {

			StopCoroutine ("StartBlur");
			StartCoroutine ("StopBlur");

		}
		
	}
	

	
	public void Reiniciar(){
		
		Application.LoadLevel("Level");
		
	}
	
	public void PararPersonaje(){

		active = !active;

		vision.SetActive (active);

		player.GetComponent<RigidbodyFPSWalker>().active = !player.GetComponent<RigidbodyFPSWalker>().active;
		Camera.GetComponent<MouseLook>().active = !Camera.GetComponent<MouseLook>().active;


		
	}
	
	public void clickReceived(GameObject col, int EstadoAux, int EstadoAuxAnterior){
	
		if(funca){
	
			if(cube.GetComponent<Glow>().getAce()){

				cursor.SetTrigger ("Acierto");

				contador += 1;
			
				Debug.Log("Win");
			
			}
		
			else{

				cursor.SetTrigger ("Fallo");

				contador = 0; 

				Debug.Log("Fail de caballo"); 
			}
		
			//bloom.bloomIntensity = 1.8f + 0.8f * contador;	
			
			if (contador == clicks){//bloom.bloomIntensity = 1.8f; 
					funca = false; 
			
					cube.GetComponent<Glow>().glow = false;
					
					if(EstadoActual == 4){
					LaunchMoodFlowchart(col.GetComponent<Personaje>().Estado);
					col.GetComponent<Personaje>().ActualizarEstado(EstadoActual);

					vision.GetComponent<Acciones>().EstadoActual = EstadoAux;
					EstadoActual = EstadoAux;

				}
					
					else{
						if(col.GetComponent<Personaje>().EstadoAnterior == EstadoActual){
							
							switch(col.GetComponent<Personaje>().getName()){
	
								case LUNCHY : CALMALUNCHY.SendFungusMessage ("START"); break;
								case MARGARET : CALMAMARGARET.SendFungusMessage ("START"); break;
								case JOHN : CALMAJOHN.SendFungusMessage ("START"); break;
								default : CALMA.SendFungusMessage ("START"); break;
						
						}

							col.GetComponent<Personaje>().ActualizarEstado(EstadoActual);
							vision.GetComponent<Acciones>().EstadoActual = EstadoAux;
							EstadoActual = EstadoAux;
							LaunchMoodFlowchart(EstadoActual);


					}
						
						else{
							
							switch(col.GetComponent<Personaje>().getName()){
								
								case LUNCHY : CALMALUNCHY.SendFungusMessage ("START"); break;
								case MARGARET : CALMAMARGARET.SendFungusMessage ("START"); break;
								case JOHN : CALMAJOHN.SendFungusMessage ("START"); break;
								default : CALMA.SendFungusMessage ("START"); break;
							}
				
							col.GetComponent<Personaje>().ActualizarEstado(EstadoActual);
							vision.GetComponent<Acciones>().EstadoActual = EstadoAux;
							EstadoActual = EstadoAux;
							LaunchMoodFlowchart(EstadoActual);

					}
						
						
					}					
					
					contador = 0;
					
					//Instantiate(Trail, new Vector3(cube.transform.position.x,cube.transform.position.y + .2f, cube.transform.position.z) , cube.transform.rotation);
					
				}
			
			}
					
		else{ contador = 0; 					funca = true; 
			}
		
		
	}
	
	IEnumerator StartBlur(){
		
		cam.GetComponent<BlurOptimized>().enabled = true;
			if (!blurring) {
				
				blurring = true;
				
				while (cam.GetComponent<BlurOptimized> ().blurSize < 6f) {
						
				cam.GetComponent<BlurOptimized> ().blurSize += 0.01f;
			
				yield return new WaitForSeconds (0.01f);
			}
		}
		
	}
	
	IEnumerator StopBlur(){
			
		blurring = false;

		while(cam.GetComponent<BlurOptimized>().blurSize > 0f){
			
			cam.GetComponent<BlurOptimized>().blurSize -= 0.01f;
			
			yield return new WaitForSeconds(0.01f);
			
		}
		
		cam.GetComponent<BlurOptimized>().enabled = false;
		
		funca = true;
		
	}
	
		public void LaunchMoodFlowchart(int x){
		
		switch(x){
		
		case 0: IRA.SendFungusMessage ("START"); break;
		case 1: MIEDO.SendFungusMessage ("START"); break;
		case 2: ALEGRIA.SendFungusMessage ("START"); break;
		case 3: TRISTEZA.SendFungusMessage ("START"); break;
		case 4: CALMA.SendFungusMessage ("START"); break;
		case 5: RECALMA.SendFungusMessage ("START"); break;
		case 6: ACTIVABLE.SendFungusMessage ("START"); break;
		default:CALMA.SendFungusMessage ("START"); break;
		
		}
		
	}
	
	public void changeState(int x){
		
		EstadoActual = x;
		
	}

	public void desactivarCosas(){
	
		foreach (Transform x in Desactivables) {
		
			x.gameObject.SetActive (false);
		
		}
	
	}

	public void activarMiedos(){

		foreach (Transform x in ActivablesMiedo) {

			x.gameObject.SetActive (true);

		}

	}

	public void activarIras(){

		foreach (Transform x in ActivablesIra) {

			x.gameObject.SetActive (true);

		}

	}

}

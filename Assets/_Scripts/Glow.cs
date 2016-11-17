using UnityEngine;
using System.Collections;
//using UnityStandardAssets.ImageEffects;

public class Glow : MonoBehaviour {

	public Material mat;
	public Color baseColor;
	
	public float time;
	
	public float Latido1;
	[Range(0.00f, .2f)]
	public float Latido2;
	[Range(0.00f, .2f)]
	public float Latido3;
	[Range(0.00f, .2f)]
	public float Latido4;
	[Range(0.00f, .2f)]
	public float Latido5;
	
	private AudioSource ad;
	
	public AudioClip ac1;
	public AudioClip ac2;
	
	//public Bloom bloom;
	//public int clicks = 0; //De 8
	
	public bool acertable;
	
	public Light light;
	
	public bool glow = true;

	bool glowing = false;

	public GameObject GameController;
	
	void Start(){
	
		ad = gameObject.GetComponent<AudioSource>();
		
		acertable = false;
		
		
	
	}
	
	public bool getAce(){
		
		return acertable;
		
	}
	
	void OnTriggerEnter(Collider col){
		
		if(col.transform.tag == "Vision"){

			mat.SetColor ("_EmissionColor", Color.black*0f);

			light.intensity = 0;

			GameController.GetComponent<GameController>().cube = gameObject;
									
		}
		
	}	

	void OnTriggerStay(){

		if (Input.GetMouseButtonDown (1) || Input.GetAxis ("LTrigger") > 0) {

			if (!glowing) {

				StartCoroutine ("DoGlow");

				glow = true;

			}
		} 

		if (!Input.GetMouseButton (1) && Input.GetAxis ("LTrigger") == 0 ) {

			StopCoroutine ("DoGlow");

			glowing = false;

			mat.SetColor ("_EmissionColor", Color.black*0f);

			light.intensity = 0;

		} 

	}
	
	void OnTriggerExit(Collider col){
		
		if(col.transform.tag == "Vision"){
			
			StopCoroutine("DoGlow");
			
			GameController.GetComponent<GameController>().cube = null;

			mat.SetColor ("_EmissionColor", Color.black*0f);

			light.intensity = 0;

			glowing = false;

			
		}
		
	}
	
	IEnumerator DoGlow(){

		glowing = true;

		baseColor = GetColor(gameObject.GetComponent<Personaje>().Estado);
		
		light.color = baseColor;
		
		float emission = 0f;
		
		int patron = 0;
		
		while(glow){
			
			switch (patron){
			
				case 0:	
					
					if(emission >= 0.2f){acertable = true;}
					else{acertable = false;}
					
					mat.SetColor ("_EmissionColor", baseColor * emission);
					
					light.intensity = emission;
					
					emission += Latido1;
					
					yield return new WaitForSeconds(time);
					
					
					
					if(emission >= 1f){ 
					
						ad.clip = ac1;
						ad.Play();
					
						patron = 1; 
					
					}
						
					break;
				
				case 1:	
					
					acertable = true;
					
					mat.SetColor ("_EmissionColor", baseColor * emission);
				
					light.intensity = emission;
				
					emission -= Latido2;
					
					yield return new WaitForSeconds(time);
				
					if(emission <= 0f){ 
											 
						patron = 2; 
												
						}
						
					break;
				
				case 2:	
				
					if(emission >= 0.6f){acertable = true;}
					else{acertable = false;}
				
					mat.SetColor ("_EmissionColor", baseColor * emission);
					
					light.intensity = emission;
					
					emission += Latido3;
					
					yield return new WaitForSeconds(time);
				
					if(emission >= 1f){ 
					
						ad.clip = ac2;
						ad.Play();
						
						patron = 3; 
						
						}
						
					break;
				
				case 3:	
					
					acertable = true;
					
					mat.SetColor ("_EmissionColor", baseColor * emission);
					
					light.intensity = emission;
					
					emission -= Latido4;
					
					yield return new WaitForSeconds(time);
				
					if(emission <= 0f){
						
						
						
						patron = 4; 
						
						}
						
					break;
				
				case 4:	
					if(emission <= 0.4f ){acertable = true;}
					else{acertable = false;}
					
					
					mat.SetColor ("_EmissionColor", baseColor*0f);
				
					light.intensity = 0f;
				
					emission += Latido5;
					
					yield return new WaitForSeconds(time);
				
					if(emission >= 1f){ emission = 0f; patron = 0; }
						
					break;
				

					
			}
			
		}
		
		mat.SetColor ("_EmissionColor", baseColor*0f);
		light.intensity = 0f;
		yield return new WaitForSeconds(time);
		
	}
	
	public Color GetColor(int i){
	
		Color aux = Color.grey;
	
		switch(i){
	
			case 0: aux = Color.red;	break;
		case 1:	aux = new Color (0.5f, 0.4f, 1f, 1f);	break;
			case 2: aux = Color.yellow;	break;
			case 3: aux = Color.green;	break;
			case 4: aux = Color.white;	break;
	
			default:aux = Color.white;	break;
	
		}
	
	return aux;
	
	}
	
	
}

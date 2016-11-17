using UnityEngine;
using System.Collections;

public class LloydBarmanAnimationEvents : MonoBehaviour {

	public GameObject vasoEnMano, vasoFinal;
	public GameObject BotellaEnMano;

	public void QuitarVaso()
	{
		vasoEnMano.SetActive (false);
		vasoFinal.SetActive (true);

	}

	public void QuitarBotella(){
	
		BotellaEnMano.SetActive (false);
	
	}
}

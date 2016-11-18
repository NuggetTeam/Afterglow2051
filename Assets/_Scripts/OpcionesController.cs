using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OpcionesController : MonoBehaviour {

	public GameObject Opciones;

	public Toggle toggleFullscreen;
	public Dropdown DropdownResolution;
	public Toggle toggleVsync;
	public Toggle toggleAntialiasing;
	public Toggle toggleAnisotropic;
	public ToggleGroup toggleGroupAA;
	public Slider sliderQuality;
	public Slider sliderBrightness;
	
	public void Start(){
		
		Screen.lockCursor = false;
		
	}	

	public void FixedUpdate(){
		
		prepare();
		
	}
	
	void prepare(){
		
		toggleFullscreen.isOn = Screen.fullScreen;
		DropdownResolution.value = GetResolution();
		if(QualitySettings.vSyncCount < 1){toggleVsync.isOn = false;}

		sliderQuality.value = ReturnQuality();
		if(QualitySettings.antiAliasing < 1){toggleAntialiasing.isOn = false;}
		
	}
	
	public void _toggleOptions(){
		
		if(Opciones.activeSelf){ Opciones.SetActive(false); }
		else{Opciones.SetActive(true);}
		
	}
	
	public void _ChangeQuality(){
		
		switch((int)sliderQuality.value){
			
			case 0: QualitySettings.SetQualityLevel(0, true); break;
			case 1: QualitySettings.SetQualityLevel(1, true); break;
			case 2: QualitySettings.SetQualityLevel(2, true); break;
			case 3: QualitySettings.SetQualityLevel(3, true); break;
			
		}
		
	}
	
	public int ReturnQuality(){
		
		int r;
		
		switch(QualitySettings.GetQualityLevel()){
			
			case 0: return 0; break;
			case 1: return 1; break;
			case 2: return 2; break;
			case 3: return 3; break;
			
		}
		
		return 0;

		
	}
	
	public void _Fullscreen(){
		
		if(toggleFullscreen.isOn){
			
			Screen.fullScreen = true;
			
		}
		else{
			
			Screen.fullScreen = false;
			
		}
		
	}	
	

	public void _Antialiasing(){
		
		if(toggleAntialiasing.isOn){
			
			QualitySettings.antiAliasing = 2;
			
		}
		else{
			
			QualitySettings.antiAliasing = 0;
			
		}
		
	}
	
	public void _Anisotropic(){
		
		if(toggleAntialiasing.isOn){
			
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			
		}
		else{
			
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			
		}
		
	}
	

	public void _Vsync(){
		
		if(toggleVsync.isOn){
			
			QualitySettings.vSyncCount = 1;
			
		}
		else{
			
			QualitySettings.vSyncCount = 0;
			
		}
		
	}
	
	public void _SetResolution(){
		
		switch(DropdownResolution.value){
				
			case 0: Screen.SetResolution(1024, 576, Screen.fullScreen); break;
			case 1: Screen.SetResolution(1280, 720, Screen.fullScreen); break;
			case 2: Screen.SetResolution(1360, 768, Screen.fullScreen); break;
			case 3: Screen.SetResolution(1366, 768, Screen.fullScreen); break;
			case 4: Screen.SetResolution(1600, 900, Screen.fullScreen); break;	
			case 5: Screen.SetResolution(1920, 1080, Screen.fullScreen); break;	
				
		}
		
	}
	
	int GetResolution(){
		
		switch(Screen.width){
				
			case 1024: return 0; break;
			case 1280: return 1; break;
			case 1360: return 2; break;
			case 1366: return 3; break;
			case 1600: return 4; break;	
			case 1920: return 5; break;	
				
		}
		
		return 0;
		
	}
	

	public void _ChangeBrightness(){
		
		float x = sliderBrightness.value;
		
		RenderSettings.ambientLight = new Color(x, x, x, 1f);
				
	}
	
	public void _UnPause(){
		
		Time.timeScale = 1;
		
		gameObject.SetActive(false);		
	}
	
	public void _LoadScene(string scene){
		
		Application.LoadLevel(scene);
		
	}
	
}



// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using Fungus;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.ScriptControl)]
	[Tooltip("Sends a Message to a Game Object. See Unity docs for SendMessage.")]
	public class ChangeFlowchart : FsmStateAction
	{

		[RequiredField]
		[Tooltip("Personaje al que cambiar el diálogo.")]		
		public FsmOwnerDefault gameObject;

		[Tooltip("Flowchart para el personaje")]
		public Flowchart flowChart;


		public override void Reset()
		{
			gameObject = null;
			flowChart = null;
		}

		public override void OnEnter()
		{
			DoSendMessage();

			Finish();
		}

		void DoSendMessage()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}			


			if (go.tag == "Personaje") {
			
				go.GetComponent<Personaje> ().SetFlowchart (flowChart);

			}

			if (go.tag == "Activable") {
			
				go.GetComponent<interactuable> ().SetFlowchart (flowChart);
			
			}

		}
	}
}
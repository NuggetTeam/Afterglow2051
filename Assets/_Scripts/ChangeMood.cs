// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using Fungus;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.ScriptControl)]
	[Tooltip("Sends a Message to a Game Object. See Unity docs for SendMessage.")]
	public class ChangeMood : FsmStateAction
		{

		[RequiredField]
		[Tooltip("Personaje al que cambiar el mood.")]		
		public FsmOwnerDefault gameObject;

		[Tooltip("Mood")]
		public int Mood;


		public override void Reset()
		{
			gameObject = null;
			Mood = 4;
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

			go.GetComponent<Personaje> ().ActualizarEstado (Mood);
		}
	}
}
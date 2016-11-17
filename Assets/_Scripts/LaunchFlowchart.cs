// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;
using Fungus;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.ScriptControl)]
	[Tooltip("Sends a Message to a Game Object. See Unity docs for SendMessage.")]
	public class LaunchFlowchart : FsmStateAction
	{

		[RequiredField]


		[Tooltip("Flowchart que lanzar")]
		public Flowchart flowChart;


		public override void Reset()
		{

			flowChart = null;
		}

		public override void OnEnter()
		{
			DoSendMessage();

			Finish();
		}

		void DoSendMessage()
		{
				
			flowChart.SendFungusMessage ("START");
			
		}
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ExampleCompany.ExampleProduct.Structs
{
	[RequireComponent(typeof(CSharpEvents))]
	public class CSharpEvents_UnityEvents : MonoBehaviour
	{
		// UnityEvent that matches CSharpEvents.myCustomEvent
		[Serializable]
		public class MyCustomUnityEvent : UnityEvent<int> { }

		public MyCustomUnityEvent myCustomEvent;

		private CSharpEvents myEvents;

		public void Awake()
		{
			if(this.myCustomEvent == null)
				this.myCustomEvent = new MyCustomUnityEvent();
		}

		// Allows to drag and drop the slower Unity Event on the
		// faster delegate events when needed.
		// If you only work via scripting you get the faster
		// delegate events. If you work via drag and drop
		// you take a small overhead by calling the UnityEvent in the delegate.
		public void OnEnable()
		{
			this.myEvents = base.GetComponent<CSharpEvents>();
			this.myEvents.myCustomEvent += MyMethod;
		}

		public void OnDisable()
		{
			this.myEvents.myCustomEvent -= MyMethod;
		}

		private void MyMethod(int a)
		{
			myCustomEvent.Invoke(a);
		}
	}
}

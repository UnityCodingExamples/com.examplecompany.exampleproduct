using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ExampleCompany.ExampleProduct.Structs
{
	public class UnityEvents : MonoBehaviour
	{
		// UnityEvent with custom parameters.
		[Serializable]
		public class MyCustomUnityEvent : UnityEvent<int> { }

		// UnityEvent is used mainly in the UI system
		// but is available for everyone. It is a lot slower
		// than C# events but has serialization support.
		public UnityEvent myEvent;

		// This event has a custom parameter that needs to be specified
		// via inheritance from the UnityEvent base class.
		public MyCustomUnityEvent myCustomEvent;

		public void Awake()
		{
			if(this.myEvent == null)
				this.myEvent = new UnityEvent();

			if(this.myCustomEvent == null)
				this.myCustomEvent = new MyCustomUnityEvent();
		}

		public void Start()
		{
			this.myEvent.Invoke();
			this.myCustomEvent.Invoke(10);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExampleCompany.ExampleProduct.Structs
{
	public class CSharpEvents : MonoBehaviour
	{
		// Action is a common delegate for simple events. It is also possible
		// to create own delegates for events see: https://docs.microsoft.com/en-us/dotnet/standard/events/
		public event Action myEvent;

		public event Action<int> myCustomEvent;

		public void Start()
		{
			// Invoke via the "new" ?. operator.
			// It only calls the method if the event is not null.
			this.myEvent?.Invoke();
			this.myCustomEvent?.Invoke(10);
		}
	}
}

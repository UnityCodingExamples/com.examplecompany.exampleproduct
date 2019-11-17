using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExampleCompany.ExampleProduct.Structs
{
	[RequireComponent(typeof(CSharpEvents))]
	public class CSharpEvents_Subscriber : MonoBehaviour
	{
		private CSharpEvents myEvents;

		public void OnEnable()
		{
			this.myEvents = base.GetComponent<CSharpEvents>();
			this.myEvents.myCustomEvent += MyMethod;
		}

		// Unsubscribe when the component is disabled or destroyed
		// due to the fact that it is not guaranteed to be null when destroyed.
		// To avoid getting called when the object is destroyed you should always
		// consider to unsubscribe earlier (OnDisable etc).
		public void OnDisable()
		{
			this.myEvents.myCustomEvent -= MyMethod;
		}

		private void MyMethod(int a)
		{
			Debug.Log(a);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExampleCompany.ExampleProduct.Structs
{
	public class MergeVectorGarbageless : MonoBehaviour
	{
		// Has the same functionality as the garbage producing method but
		// stores the array on the stack. The profiler should show no
		// garbage collector runs.
		public void Update()
		{
			unsafe
			{
				int length = 256;
				Vector3* vectors = stackalloc Vector3[length];

				for(int i = 0; i < length; ++i)
					vectors[i] = new Vector3(i, i - 1, i - 2);

				length = length / 2;
				Vector3* merged = stackalloc Vector3[length];

				for(int i = 0; i < length; i += 2)
					merged[i] = vectors[i] + vectors[i + 1];
			}
		}
	}
}

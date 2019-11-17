using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExampleCompany.ExampleProduct.Structs
{
	public class MergeVectorGarbage : MonoBehaviour
	{
		// The "normal" way of creating arrays.
		// Each array is stored on the stack, so the garbage collector runs.
		// The profiler should show a peak each time the garbage is collected.
		public void Update()
		{
			int length = 256;
			Vector3[] vectors = new Vector3[length];

			for(int i = 0; i < vectors.Length; ++i)
				vectors[i] = new Vector3(i, i - 1, i - 2);

			Vector3[] merged = new Vector3[vectors.Length / 2];

			for(int i = 0; i < merged.Length; i += 2)
				merged[i] = vectors[i] + vectors[i + 1];
		}
	}
}

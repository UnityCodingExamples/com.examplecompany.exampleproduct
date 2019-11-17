using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using UnityEngine;

namespace ExampleCompany.ExampleProduct.Structs
{
	// see: https://gist.github.com/LuizZak/9cd03f8b090ffc56af15
	public class NormalLoop : MonoBehaviour
	{
		private Stopwatch sw;
		private int runs;
		private double total;
		private double avg;

		public void Awake()
		{
			this.sw = new Stopwatch();
		}

		public void Update()
		{
			this.sw.Restart();

			unsafe
			{
				const int len = 256 * 256;
				int* data = stackalloc int[len];
				int* ptr = data;

				int count = len;

				while (count-- > 0)
				{
					*(ptr++) = 0;
				}
			}

			this.sw.Stop();

			this.total += sw.Elapsed.TotalSeconds;
			this.avg = this.total / ++this.runs;

			if(this.runs % 100 == 0)
				UnityEngine.Debug.Log("Avg Time Normal Loop: " + this.avg);
		}
	}
}

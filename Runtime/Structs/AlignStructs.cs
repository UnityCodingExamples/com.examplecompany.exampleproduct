using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ExampleCompany.ExampleProduct.Structs
{
	public class AlignStructs : MonoBehaviour
	{
		// Bad aligned structure.
		struct A
		{
			byte b1; // 1 byte
			long l1; // 8 bytes
			long l2; // 8 bytes
			byte b2; // 1 byte
			long l3; // 8 bytes
		}

		// Better aligned structure.
		struct B
		{
			byte b1; // 1 byte
			byte b2; // 1 byte
			long l1; // 8 bytes
			long l2; // 8 bytes
			long l3; // 8 bytes
		}

		// Takes up the same space as B but has a higher
		// data density.
		struct C
		{
			byte b1; // 1 byte
			byte b2; // 1 byte
			byte b3; // 1 byte
			byte b4; // 1 byte
			byte b5; // 1 byte
			byte b6; // 1 byte
			byte b7; // 1 byte
			byte b8; // 1 byte
			long l1; // 8 bytes
			long l2; // 8 bytes
			long l3; // 8 bytes
		}

		// In ECS components should be small so that you
		// dont waste space. It allows to pack a lot of information together.
		// Together all three components are holding the same fields as B but taking up
		// less space.
		struct Comp1
		{
			long l1; // 8 bytes
			long l2; // 8 bytes
		}

		struct Comp2
		{
			byte b1; // 1 byte
			byte b2; // 1 byte
		}

		struct Comp3
		{
			long l3; // 8 bytes
		}

		public void Start()
		{
			unsafe
			{
				Debug.Log("struct size A: " + sizeof(A));
				Debug.Log("struct size B: " + sizeof(B));
				Debug.Log("struct size C: " + sizeof(B));
				Debug.Log("struct size of Comp1 + Comp2 + Comp 3: " + (sizeof(Comp1) + sizeof(Comp2) + sizeof(Comp3)));
			}
		}
	}
}

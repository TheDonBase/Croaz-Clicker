using UnityEngine;
using System.Collections;

namespace Core{
	public abstract class CoreClass : MonoBehaviour {
		public abstract void Start (); // Require the Initializer to do stuff.
		public abstract void Update(); // Require the Update function to do stuff upon update.
	}
}
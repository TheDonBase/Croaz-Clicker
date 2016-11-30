using UnityEngine;
using System.Collections;

namespace Core{
	public abstract class CoreButton : MonoBehaviour {
		public abstract void Start (); // Require the Initializer to do stuff.
		public abstract void Click (); // Require the Click method for handling the click events.
	}
}
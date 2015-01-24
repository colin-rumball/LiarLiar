using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace UnitySampleAssets._2D
{

    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D character;
		private bool jump;

        private void Awake()
        {
            character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            if(!jump)
            // Read the jump input in Update so button presses aren't missed.
            if (tag == "Player") {
				jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
			if (tag == "Player2") {
				jump = CrossPlatformInputManager.GetButtonDown("Jump2");
			}
        }

        private void FixedUpdate()
        {
			if (tag == "Player") {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            character.Move(h, false, jump);
            jump = false;
			}
			if (tag == "Player2") {
				float h = CrossPlatformInputManager.GetAxis("Horizontal2");
				// Pass all parameters to the character control script.
				character.Move(h, false, jump);
				jump = false;
			}
        }
    }
}
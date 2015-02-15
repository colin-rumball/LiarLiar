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
			if (Global.GamePlaying)
			{
	            if(!jump)
	            // Read the jump input in Update so button presses aren't missed.
	            if (tag == "Player") {
					jump = Input.GetButtonDown("Jump");
				}
				if (tag == "Player2") {
					jump = Input.GetButtonDown("Jump2");
				}
			}
        }

        private void FixedUpdate()
        {
			if (Global.GamePlaying)
			{
				if (tag == "Player") {
					float h = Input.GetAxis("Horizontal");
	            // Pass all parameters to the character control script.
	            character.Move(h, false, jump);
	            jump = false;
				}
				if (tag == "Player2") {
					float h = Input.GetAxis("Horizontal2");
					// Pass all parameters to the character control script.
					character.Move(h, false, jump);
					jump = false;
				}
			}
        }
    }
}
using ICities;
using UnityEngine;

namespace CustomCursor
{
    public class CustomCursors : IUserMod
    {
        public string Name
        {
            get { return "Custom Cursor"; }
        }

        public string Description
        {
            get { return "Use CustomPointer.png for the cursor pointer"; }
        }

        public class CustomMouseEvent : MonoBehaviour {
            public Texture2D cursorTexture = new Texture2D(48, 48);
            public CursorMode cursorMode = CursorMode.Auto;
            public Vector2 hotSpot = Vector2.zero;

            void Start()
            {
                string filename = "CustomPointer.png";
                var rawData = System.IO.File.ReadAllBytes(filename);
                cursorTexture.LoadImage(rawData);
                Update();
            }

            void Update()
            {
                UnityEngine.Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            }
        }
        
        public class Loader : LoadingExtensionBase
        {
            public override void OnLevelLoaded(LoadMode mode)
            {
                // Instantiate a custom object
                GameObject go = new GameObject("Custom Cursor Object");
                go.AddComponent<CustomMouseEvent>();

                base.OnLevelLoaded(mode);
            }
        }
    }
}

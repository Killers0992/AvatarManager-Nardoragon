using UnityEditor;

namespace AvatarManager.Core
{
    public class NardoragonMenu : EditorWindow
    {
        private BaseMenu _menuInstance;

        public BaseMenu MenuInstance
        {
            get
            {
                if (_menuInstance == null)
                {
                    rootVisualElement.Clear();

                    _menuInstance = AssetDatabase.LoadAssetAtPath<BaseMenu>("Packages/com.killers0992.avatarmanager-nardoragon/NardoragonMenu.asset");

                    _menuInstance.OnInitialize(this);
                }

                return _menuInstance;
            }
        }

        [MenuItem("AvatarManager/Open Nardoragon Menu")]
        public static void OpenWindow()
        {
            GetWindow<NardoragonMenu>();
        }

        public void OnGUI()
        {
            if (MenuInstance.MenuAssetInstance == null)
                MenuInstance.OnInitialize(this);

            MenuInstance.OnUpdate(this);
        }

        public void CreateGUI()
        {
            MenuInstance.OnCreateGUI(this);
        }
    }
}
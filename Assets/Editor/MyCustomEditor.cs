using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class MyCustomEditor : EditorWindow
{
	[MenuItem("Window/UI Toolkit/MyCustomEditor")]
    public static void ShowExample()
    {
        MyCustomEditor wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("MyCustomEditor");
    }

	[SerializeField]
	public AudioSource roar;

	[SerializeField]
	private VisualTreeAsset m_UXMLTree;

	private int m_ClickCount = 0;

	private const string m_ButtonPrefix = "button";

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("This is from the C# file");
        root.Add(label);

		//PUT BUTTON CODE HERE
		Button button = new Button();
		button.name = "button3";
		button.text = "This is button3.";
		rootVisualElement.Add(button);

		Toggle toggle = new Toggle();
		toggle.name = "toggle3";
		toggle.label = "Number?";
		rootVisualElement.Add(toggle);





        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/MyCustomEditor.uxml");
        VisualElement labelFromUXML = visualTree.Instantiate();
        root.Add(labelFromUXML);

		rootVisualElement.Add(m_UXMLTree.Instantiate());

		//Call the event handler
		SetupButtonHandler();
    }

	//Functions as the event handlers for your button click and number counts 
	private void SetupButtonHandler()
	{
		var buttons = rootVisualElement.Query<Button>();
		buttons.ForEach(RegisterHandler);
	}

	private void RegisterHandler(Button button)
	{
		button.RegisterCallback<ClickEvent>(DoRoar);
	}

	private void DoRoar(ClickEvent evt)
	{
		//why
		++m_ClickCount;

		//Because of the names we gave the buttons and toggles, we can use the
		//button name to find the toggle name.
		//i hate it though can it just be a custom name. also if this was a list.fdmklfjkdlsa
		Button button = evt.currentTarget as Button;
		string buttonNumber = button.name.Substring(m_ButtonPrefix.Length);
		//toggle? 
		string toggleName = "toggle" + buttonNumber;
		Toggle toggle = rootVisualElement.Q<Toggle>(toggleName);

		Debug.Log("Button Roar was clicked!" +
			(toggle.value ? " Count: " + m_ClickCount : ""));

		//THIS WONT PLAY because this is an editor only script
		//roar.Play ();

	}

	private void PrintClickMessage(ClickEvent evt)
	{
		++m_ClickCount;

		//Because of the names we gave the buttons and toggles, we can use the
		//button name to find the toggle name.
		Button button = evt.currentTarget as Button;
		string buttonNumber = button.name.Substring(m_ButtonPrefix.Length);
		string toggleName = "toggle" + buttonNumber;
		Toggle toggle = rootVisualElement.Q<Toggle>(toggleName);

		Debug.Log("Button was clicked!" +
			(toggle.value ? " Count: " + m_ClickCount : ""));
	}

}
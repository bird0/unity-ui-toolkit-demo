using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class ButtonHandler : MonoBehaviour
{
	[SerializeField]
	private UIDocument m_UIDocument;

	public AudioSource roar;

	private Button m_Button;

	public void Start()
	{
		var rootElement = m_UIDocument.rootVisualElement;

		//find the button by name
		m_Button = rootElement.Q<Button> ("button2");

		// clickable.clicked
		m_Button.clickable.clicked += OnButtonClicked; 

	}

	private void OnDestroy()
	{
		//
	}
		
	private void OnButtonClicked()
	{
		if (roar != null) {
			roar.Play ();
		}
		Debug.Log("The button is ferocious.");
	}
		
	private void OnToggleValueChanged(ChangeEvent<bool> evt)
	{
		//
	}
}

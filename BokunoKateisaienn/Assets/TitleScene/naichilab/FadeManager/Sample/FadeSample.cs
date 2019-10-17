using UnityEngine;
using System.Collections;

public class FadeSample : MonoBehaviour
{

	public void FadeScene ()
	{
		FadeManager.Instance.LoadScene ("TitleScene", 1.0f);
	}
}

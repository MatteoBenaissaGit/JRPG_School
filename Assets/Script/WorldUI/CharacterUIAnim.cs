using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterUIAnim : MonoBehaviour
{

	public Sprite[] Sprites;
	public int SpritePerFrame = 6;
	[SerializeField] private bool loop = true;
	[SerializeField] private bool destroyOnEnd = false;

	private int index = 0;
	private Image image;
	private int frame = 0;

	void Awake()
	{
		image = GetComponent<Image>();
	}

	void Update()
	{
		if (!loop && index == Sprites.Length) return;
		frame++;
		if (frame < SpritePerFrame) return;
		image.sprite = Sprites[index];
		frame = 0;
		index++;
		if (index >= Sprites.Length)
		{
			if (loop) index = 0;
			if (destroyOnEnd) Destroy(gameObject);
		}
	}
}
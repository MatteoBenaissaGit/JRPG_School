using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterUIAnim : MonoBehaviour
{

	public Sprite[] Sprites;
	public int SpritePerFrame = 6;
	[SerializeField] private bool _loop = true;
	[SerializeField] private bool _destroyOnEnd = false;

	private int _index = 0;
	private Image _image;
	private int _frame = 0;

	void Awake()
	{
		_image = GetComponent<Image>();
	}

	void Update()
	{
		if (!_loop && _index == Sprites.Length) return;
		_frame++;
		if (_frame < SpritePerFrame) return;
		_image.sprite = Sprites[_index];
		_frame = 0;
		_index++;
		if (_index >= Sprites.Length)
		{
			if (_loop) _index = 0;
			if (_destroyOnEnd) Destroy(gameObject);
		}
	}
}
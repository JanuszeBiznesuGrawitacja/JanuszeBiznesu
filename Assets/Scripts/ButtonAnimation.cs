using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler {
	public Vector2 defaultPos { get; private set; }
	private float defaultScale;
	public float shakePower = 15;
	public float offsetValue = 10;
	private RectTransform rt;
	private UnityEngine.UI.Button btn;
	private bool inited;
	private bool started;

	private void Start() {
		defaultScale = transform.localScale.x;
		rt = transform as RectTransform;
		btn = GetComponent<UnityEngine.UI.Button>();
		ResetButtonState();
		started = true;
	}

	private void GetDefaultPos() {
		if (rt == null)
			rt = transform as RectTransform;
		defaultPos = rt.anchoredPosition;

		inited = true;
		ResetBtnPos();
	}

	private void OnEnable() {
		ResetBtnPos();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		if (btn != null && btn.interactable == false)
			return;
		if (CanPlayAnimation())
			transform.DOScale(defaultScale * 1.1f, 0.5f);
	}

	public void OnPointerExit(PointerEventData eventData) {
		if (btn != null && btn.interactable == false)
			return;
		if (CanPlayAnimation())
			transform.DOScale(defaultScale * 1.0f, 0.5f);
	}

	public void OnPointerDown(PointerEventData eventData) {
		if (btn != null && btn.interactable == false)
			return;
		if (CanPlayAnimation())
			rt.DOAnchorPosY(defaultPos.y - offsetValue, 0.2f);
	}

	public void OnPointerUp(PointerEventData eventData) {
		if (btn != null && btn.interactable == false)
			return;
		if (CanPlayAnimation())
		{
			ResetBtnPos();
			rt.DOAnchorPosY(defaultPos.y + offsetValue, 0.2f);
			transform.DOShakePosition(0.4f, shakePower);
		}
	}

	public void ResetBtnPos() {
		if (inited)
		{
			rt.DOKill();
			transform.DOKill();
			rt.anchoredPosition = defaultPos;
			transform.localScale = new Vector3(defaultScale, defaultScale, defaultScale);
		}
		else if (started)
		{
			ResetButtonState();
		}
	}

	private bool lockRaycast;

	public void LockRaycasts() {
		lockRaycast = true;
	}

	private bool CanPlayAnimation() {
		return inited && !lockRaycast;
	}

	private IEnumerator init;

	public void ResetButtonState() {
		transform.DOKill();
		rt.DOKill();
		inited = false;
		lockRaycast = false;

		if (gameObject.activeInHierarchy)
		{
			if (init != null)
				StopCoroutine(init);
			init = DelayedInit();
			StartCoroutine(init);
		}
	}

	private IEnumerator DelayedInit() {
		yield return new WaitForSeconds(1);
		if (!inited)
			GetDefaultPos();
	}

	private void OnDisable() {
		if (init != null)
			StopCoroutine(init);
	}
}
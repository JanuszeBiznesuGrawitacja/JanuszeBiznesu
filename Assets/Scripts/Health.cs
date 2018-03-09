﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	public Slider healthBar;
	public float startHealthAmount = 30f;
	private float _currentHealth;

	public float CurrentHealth {
		get
		{
			return _currentHealth;
		}
		set
		{
			_currentHealth = Mathf.Clamp(value, 0, startHealthAmount);
			RefreshHealthBarUI();
			if (_currentHealth <= 0)
			{
				Die();
			}
		}
	}

	private void RefreshHealthBarUI() {
		healthBar.value = _currentHealth;
	}

	private void Start() {
		_currentHealth = startHealthAmount;
		healthBar.minValue = 0;
		healthBar.maxValue = startHealthAmount;
		healthBar.value = startHealthAmount;
	}

	public void LoseHealth(float amount) {
		CurrentHealth -= amount;
	}

	public void AddHealth(float amount) {
		CurrentHealth += amount;
	}

	private void Update() {
		LoseHealth(Time.deltaTime);
	}

	private void Die() {
		Destroy(gameObject);
	}
}
﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SleepDev.Inventory
{
    public class SimpleItemUI : ItemUI
    {
        [SerializeField] protected string _id;
        [SerializeField] protected Image _icon;
        [SerializeField] protected TextMeshProUGUI _countText;
        protected int _count;

        public override string Id
        {
            get => _id;
            set => _id = value;
        }

        public override void Pick()
        {
            IsPicked = true;
        }

        public override void Unpick()
        {
            IsPicked = false;
        }

        public override void SetCount(int count)
        {
            _count = count;
            _countText.text = $"x{count}";
        }

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }
        
        public void SetTextCount(string msg)
        {
            _countText.text = msg;
        }

        public override int GetCount()
        {
            return _count;
        }
    }
}
﻿using System.Collections.Generic;
using CoreUtils.Extensions;
using NUnit.Framework;
using Shouldly;

namespace CoreUtils.Tests.Extensions.CollectionExtensions
{
    [TestFixture]
    public class when_invoking_action_for_each_item
    {
        private List<int> _list;
        private int[] _items;

        [SetUp]
        public void Context()
        {
            _items = new[] {1, 2, 3};
            _list = new List<int>();

            _items.Each(_list.Add);
        }

        [Test]
        public void all_items_are_added_to_list()
        {
            _list.ShouldBe(_items);
        }
    }
}
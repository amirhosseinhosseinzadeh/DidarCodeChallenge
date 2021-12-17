using DidarCodeChallenge.Api.Models;
using DidarCodeChallenge.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using FluentAssertions;
using System.Collections.Generic;

namespace DidarCodeChallenge.Test.Services;

[TestFixture]
public class BinarySearchTreeServiceTest : BinarySearchTreeService
{
    private static readonly ServiceProvider _serviceProvider;
    private IBinarySerachTreeService _bstService;

    static BinarySearchTreeServiceTest()
    {
        var services = new ServiceCollection();
        services.AddScoped<IBinarySerachTreeService, BinarySearchTreeService>();
        _serviceProvider = services.BuildServiceProvider();
    }

    [SetUp]
    public void SetUp()
    {
        _bstService = _serviceProvider.GetRequiredService<IBinarySerachTreeService>();
    }

    [Test]
    public void ValueAddedToTheRightSideInBST()
    {
        Node root = new(25);
        _bstService.InsertNode(root, 24);
        _bstService.InsertNode(root, 26);
        root.Left.Value.Should().Be(24);
        root.Right.Value.Should().Be(26);
    }

    [Test]
    public void ValueMostNotExistsInResultWhenItsDeleted()
    {
        var lst1 = new List<int>()
        {
            2,1,3
        };
        var root1 = _bstService.BulkInsert(lst1);
        var ignoreValue1 = 12;
        var result1 = _bstService.DeleteNode(root1, ignoreValue1);
        var lst2 = new List<int>()
        {
            1,2,8,5,11,4,9,7,12
        };
        var root2 = _bstService.BulkInsert(lst2);
        var ignoreValue2 = 9;
        var result2 = _bstService.DeleteNode(root2, ignoreValue2);
        lst1.Remove(ignoreValue1);
        lst1.Sort();
        lst2.Remove(ignoreValue2);
        lst2.Sort();

        for (var i = 0; i < result1.Count; i++)
        {
            var value = lst1[i];
            value.Should().Be(result1[i]);
        }
        for (var i = 0; i < result2.Count; i++)
        {
            var value = lst2[i];
            value.Should().Be(result2[i]);
        }
    }

}
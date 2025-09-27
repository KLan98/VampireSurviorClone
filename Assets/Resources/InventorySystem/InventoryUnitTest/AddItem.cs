using System;
using NUnit.Framework;
using Moq;

[TestFixture]
public class InventoryLogicTests
{
    private Mock<ISlotClass> mockItemToAdd;
    private Mock<ISlotClass> mockItemDB;
    private Mock<IItem> mockItem;

    [SetUp]
    public void SetUp()
    {
        mockItemToAdd = new Mock<ISlotClass>();
        mockItemDB = new Mock<ISlotClass>();
        mockItem = new Mock<IItem>();
        
        mockItemToAdd.Setup(m => m.GetItem()).Returns(mockItem.Object);
    }

    [Test]
    public void AddItem_PlacesItemInFirstEmptySlot_AndMarksNewWeaponAdded()
    {
        ISlotClass[] itemDB = new ISlotClass[3];
        var inventory = new InventoryLogic(itemDB);

        inventory.AddItem(mockItemToAdd.Object);

        Assert.That(itemDB[0], Is.EqualTo(mockItemToAdd.Object));
    }

    [Test]
    public void AddItem_Throws_WhenItemToAddIsNull()
    {
    }

    [Test]
    public void AddItem_Throws_WhenInventoryIsFull()
    {

    }

    [Test]
    public void AddItem_Throws_WhenItemDatabaseIsNull()
    {

    }
}

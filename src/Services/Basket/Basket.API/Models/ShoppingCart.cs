﻿namespace Basket.API.Models;
public class ShoppingCart
{
    public string UserName { get; set; } = default!;
    public List<ShoppingCarItem> Items { get; set; } = new();
    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);
    public ShoppingCart(string userName)
    {
       UserName = userName; 
    }


    //Required for Mapping c
    public ShoppingCart()
    {
    }
}

